using System.Data;
using System.Diagnostics;
using System.Reflection;
using AIplus.AIF.DBLib;
using BatchService.HangFire.Base;
using BatchService.Trigger.Base.Attributes;
using BCC.Affect.BatchService;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Npgsql;

namespace BatchService.Trigger.Base.Proxy.Interceptors;

public class BatchServiceProxyInterceptor : IInterceptor
{
    private readonly ILogger _logger;

    public BatchServiceProxyInterceptor(ILogger logger)
    {
        _logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
        var invocationMethodInfo = GetInvocationMethodInfo(invocation.Method);
        if (invocationMethodInfo.ShouldIntercept)
        {
            var db = SetDbContextArgumentValueIfExist(invocation, invocationMethodInfo.DbContextParamIndex, invocationMethodInfo.ReqParamIndex);
            if (db == null)
            {
                DoProceedWithoutDbContext(invocation);
            }
            else
            {
                DoProceedWithDbContext(db, invocationMethodInfo.IsolationLevel, invocation);
            }
        }
        else
        {
            invocation.Proceed();
        }
    }


    /// <summary>
    /// データベース・コンテキストがない場合のメソッド実行
    /// </summary>
    private void DoProceedWithoutDbContext(IInvocation invocation)
    {
        var stopwatch = Stopwatch.StartNew();
        var status = BtConst.SUCCESS_MSG;
        try
        {
            Init(invocation);
            invocation.Proceed();
            Destroy(invocation);
            stopwatch.Stop();
            HandleSuccessProxyResult(invocation, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            status = BtConst.FAIL_DEFAULT_MSG;
            _logger.Error($"An exception was thrown in method {invocation.Method.Name}", ex);
            stopwatch.Stop();
            HandleFailProxyResult(invocation, stopwatch.ElapsedMilliseconds, ex.Message);
        }
        finally
        {
            _logger.Info($"Batch processing finished in {stopwatch.ElapsedMilliseconds}ms, status: {status}.");
        }
    }

    /// <summary>
    /// データベース・コンテキストがあるときにメソッドを実行
    /// </summary>
    private void DoProceedWithDbContext(DaDbContext db, IsolationLevel isolationLevel, IInvocation invocation)
    {
        var stopwatch = Stopwatch.StartNew();
        var status = BtConst.SUCCESS_MSG;
        AiDbUtil.OpenConnection(db.Session.Connection!);
        NpgsqlTransaction? tran = null;
        try
        {
            tran = db.Connection.BeginTransaction(isolationLevel);
            Init(invocation);
            invocation.Proceed();
            Destroy(invocation);
            tran.Commit();
            stopwatch.Stop();
            HandleSuccessProxyResult(invocation, stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            tran?.Rollback();
            status = BtConst.FAIL_DEFAULT_MSG;
            _logger.Error($"An exception was thrown in method {invocation.Method.Name}", ex);
            stopwatch.Stop();
            HandleFailProxyResult(invocation, stopwatch.ElapsedMilliseconds, ex.Message);
        }
        finally
        {
            tran?.Dispose();
            db.Dispose();
            _logger.Info($"Batch processing finished in {stopwatch.ElapsedMilliseconds}ms, status: {status}.");
        }
    }

    /// <summary>
    /// バッチ実行前の操作
    /// </summary>
    private void Init(IInvocation invocation)
    {
        // _logger.Info($"Calling method {invocation.Method.Name} with parameters {string.Join(DaStrPool.C_COMMA, invocation.Arguments.Select(a => (a ?? string.Empty).ToString()))}...");
    }

    /// <summary>
    /// バッチ実行後の動作
    /// </summary>
    private void Destroy(IInvocation invocation)
    {
        // _logger.Info($"Method {invocation.Method.Name} returned {invocation.ReturnValue}");
    }

    /// <summary>
    /// 成功した実施結果
    /// </summary>
    private static void HandleSuccessProxyResult(IInvocation invocation, long spendTimeMs)
    {
        if (!invocation.Method.ReturnType.IsGenericType) return;
        if (invocation.Method.ReturnType == typeof(ExecuteResult<>))
        {
            var originResult = invocation.ReturnValue as ExecuteResult<object?>;
            invocation.ReturnValue = ExecuteResult<object?>.Success(originResult?.Data, spendTimeMs);
        }
        else if (invocation.Method.ReturnType == typeof(PageExecuteResult<>))
        {
            var originResult = invocation.ReturnValue as PageExecuteResult<object?>;
            invocation.ReturnValue = PageExecuteResult<object?>.Success(originResult?.Data, originResult?.Total ?? 0L, spendTimeMs);
        }
    }

    /// <summary>
    /// 実施に失敗した結果
    /// </summary>
    private static void HandleFailProxyResult(IInvocation invocation, long spendTimeMs, string msg)
    {
        if (!invocation.Method.ReturnType.IsGenericType) return;
        if (invocation.Method.ReturnType == typeof(ExecuteResult<>))
        {
            invocation.ReturnValue = ExecuteResult<object?>.Fail(null, spendTimeMs, msg);
        }
        else if (invocation.Method.ReturnType == typeof(PageExecuteResult<>))
        {
            invocation.ReturnValue = PageExecuteResult<object?>.Fail(spendTimeMs, msg);
        }
    }

    /// <summary>
    ///  ブロックされたメソッドに関する情報の取得
    /// </summary>
    private static InvocationMethodInfo GetInvocationMethodInfo(MethodInfo? invocationMethod)
    {
        if (invocationMethod == null || !invocationMethod.IsPublic || invocationMethod.IsStatic || !invocationMethod.IsVirtual)
        {
            return new InvocationMethodInfo(false);
        }

        var parameters = invocationMethod.GetParameters();
        int? dbContextParamIndex = null;
        int? reqParamIndex = null;

        for (var i = 0; i < parameters.Length && (dbContextParamIndex == null || reqParamIndex == null); i++)
        {
            var parameterType = parameters[i].ParameterType;
            dbContextParamIndex ??= parameterType == typeof(DaDbContext) ? i : dbContextParamIndex;
            reqParamIndex ??= parameterType == typeof(DaRequestBase) ? i : reqParamIndex;
        }

        var transactionalAttribute = invocationMethod.GetCustomAttribute<BatchMethodAttribute>();
        return new InvocationMethodInfo(true, dbContextParamIndex, reqParamIndex, transactionalAttribute?.IsolationLevel);
    }

    /// <summary>
    /// データベースコンテキストパラメータ値の設定
    /// </summary>
    private static DaDbContext? SetDbContextArgumentValueIfExist(IInvocation invocation, int? dbContextParamIndex, int? reqParamIndex)
    {
        if (dbContextParamIndex == null) return null;

        if (invocation.Arguments[dbContextParamIndex.Value] is DaDbContext db) return db;

        if (reqParamIndex == null)
        {
            db = new DaDbContext();
        }
        else
        {
            var req = invocation.Arguments[reqParamIndex.Value] as DaRequestBase;
            db = new DaDbContext(req ?? new DaRequestBase());
        }

        invocation.SetArgumentValue(dbContextParamIndex.Value, db);
        return db;
    }


    private sealed class InvocationMethodInfo
    {
        public readonly bool ShouldIntercept;
        public readonly int? DbContextParamIndex;
        public readonly int? ReqParamIndex;
        public readonly IsolationLevel IsolationLevel;

        public InvocationMethodInfo(bool shouldIntercept, int? dbContextParamIndex = null, int? reqParamIndex = null, IsolationLevel? isolationLevel = IsolationLevel.ReadCommitted)
        {
            ShouldIntercept = shouldIntercept;
            DbContextParamIndex = dbContextParamIndex;
            ReqParamIndex = reqParamIndex;
            IsolationLevel = isolationLevel ?? IsolationLevel.ReadCommitted;
        }
    }
}