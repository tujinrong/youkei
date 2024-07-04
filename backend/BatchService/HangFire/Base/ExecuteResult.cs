// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ベースクラス
//            
// 作成日　　: 2023.01.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************

using BCC.Affect.BatchService;
namespace BatchService.HangFire.Base;

public sealed class ExecuteResult<T>
{
    public readonly ResultStatusCode Code;
    public readonly T? Data;
    public readonly string? Msg;
    public readonly long SpendTimeMs;
    public readonly bool SuccessFlg;

    private ExecuteResult(ResultStatusCode code, T? data, string? msg, long spendTimeMs)
    {
        Code = code;
        Data = data;
        Msg = msg;
        SpendTimeMs = spendTimeMs;
        SuccessFlg = code == ResultStatusCode.SUCCESS;
    }

    public static ExecuteResult<T> Success(long spendTimeMs = 0L)
    {
        return Success(default, spendTimeMs);
    }

    public static ExecuteResult<T> Success(T? data, long spendTimeMs = 0L)
    {
        return new ExecuteResult<T>(ResultStatusCode.SUCCESS, data, BtConst.SUCCESS_MSG, spendTimeMs);
    }

    public static ExecuteResult<T> Fail(long spendTimeMs = 0L, string msg = BtConst.FAIL_DEFAULT_MSG)
    {
        return Fail(default, spendTimeMs, msg);
    }

    public static ExecuteResult<T> Fail(T? data, long spendTimeMs = 0L, string msg = BtConst.FAIL_DEFAULT_MSG)
    {
        return new ExecuteResult<T>(ResultStatusCode.FAIL, data, msg, spendTimeMs);
    }
}

public sealed class PageExecuteResult<T>
{
    public readonly List<T> Data;
    public readonly ResultStatusCode Code;
    public readonly string? Msg;
    public readonly long SpendTimeMs;
    public readonly long Total;
    public readonly bool SuccessFlg;

    private PageExecuteResult(ResultStatusCode code, List<T>? data, string? msg, long spendTimeMs, long total)
    {
        Code = code;
        Data = data ?? new List<T>();
        Msg = msg;
        SpendTimeMs = spendTimeMs;
        Total = data == null || !data.Any() ? 0L : total;
        SuccessFlg = code == ResultStatusCode.SUCCESS;
    }

    public static PageExecuteResult<T> Success(List<T>? data, long total = 0L, long spendTimeMs = 0L)
    {
        return new PageExecuteResult<T>(ResultStatusCode.SUCCESS, data, BtConst.SUCCESS_MSG, spendTimeMs, total);
    }

    public static PageExecuteResult<T> Fail(long spendTimeMs = 0L, string msg = BtConst.FAIL_DEFAULT_MSG)
    {
        return new PageExecuteResult<T>(ResultStatusCode.FAIL, default, msg, spendTimeMs, 0L);
    }
}