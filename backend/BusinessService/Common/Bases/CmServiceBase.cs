// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ベースロジック
//             サービス処理
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using System.Diagnostics;
using System.Reflection;

namespace BCC.Affect.Service
{
    public class CmServiceBase
    {
        protected MethodBase? currentMethod { get; private set; }

        /// <summary>
        /// トランザクション処理（NoLock）NEW
        /// </summary>
        [DebuggerStepThrough()]
        public R Nolock<R>(DaRequestBase req, Func<DaDbContext, R> f) where R : DaResponseBase
        {
            currentMethod = new StackTrace().GetFrame(1)!.GetMethod()!;
            using var db = new DaDbContext(req);
            AiDbUtil.OpenConnection(db.Session.Connection!);
            // トランザクション
            using (var tran = db.Connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                try
                {
                    // サービス名とメソッド名を取得する
                    req.SetMethodInfo(currentMethod);

                    // 前処理
                    BeforeAction(db, req);
                    R res = f(db);

                    // 後処理
                    AfterAction(db, res);
                    tran.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return GetExcetionResponse<R>(db, ex, currentMethod.Name);
                }
            }
        }

        /// <summary>
        /// トランザクション処理（NoLock）NEW　延期Close、調査中
        /// </summary>
        [DebuggerStepThrough()]
        public R Nolock2<R>(DaRequestBase req, Func<DaDbContext, R> f) where R : DaResponseBase
        {
            currentMethod = new StackTrace().GetFrame(1)!.GetMethod()!;
            // 延期Close、調査中
            var db = new DaDbContext(req);
            AiDbUtil.OpenConnection(db.Session.Connection!);
            // トランザクション
            using (var tran = db.Connection.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                try
                {
                    // サービス名とメソッド名を取得する
                    req.SetMethodInfo(currentMethod);

                    // 前処理
                    BeforeAction(db, req);
                    R res = f(db);

                    // 後処理
                    AfterAction(db, res);
                    tran.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return GetExcetionResponse<R>(db, ex, currentMethod.Name);
                }
            }
        }

        /// <summary>
        /// トランザクション NEW
        /// </summary>
        [DebuggerStepThrough()]
        public R Transction<R>(DaRequestBase req, Func<DaDbContext, R> f) where R : DaResponseBase
        {
            currentMethod = new StackTrace().GetFrame(1)!.GetMethod()!;
            using var db = new DaDbContext(req);
            AiDbUtil.OpenConnection(db.Session.Connection!);
            // トランザクション
            using (var tran = db.Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    // サービス名とメソッド名を取得する
                    req.SetMethodInfo(currentMethod);

                    // 前処理
                    BeforeAction(db, req);
                    R res = f(db);

                    // 後処理
                    AfterAction(db, res);
                    tran.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return GetExcetionResponse<R>(db, ex, currentMethod.Name);
                }
            }

        }

        /// <summary>
        /// Lock処理 NEW
        /// </summary>
        [DebuggerStepThrough()]
        public R Lock<R>(DaRequestBase req, Func<DaDbContext, R> f) where R : DaResponseBase
        {
            currentMethod = new StackTrace().GetFrame(1)!.GetMethod()!;
            using var db = new DaDbContext(req);

            AiDbUtil.OpenConnection(db.Session.Connection!);
            // トランザクション
            using (var tran = db.Connection.BeginTransaction(System.Data.IsolationLevel.Serializable))
            {
                try
                {
                    // サービス名とメソッド名を取得する
                    req.SetMethodInfo(currentMethod);

                    // 前処理
                    BeforeAction(db, req);
                    R res = f(db);

                    // 後処理
                    AfterAction(db, res);
                    tran.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    return GetExcetionResponse<R>(db, ex, currentMethod.Name);
                }
            }

        }

        //private R GetExcetionResponse<R>(Exception ex, string method)
        //{
        //    AiDbUtil.OpenConnection(db!.Connection);
        //    R res = Activator.CreateInstance<R>();
        //    SetExceptionResponse(ex, (res as DaResponseBase)!);
        //    DaDbLogService.WriteDbException(db, ex);
        //    DaLogService.WriteException(method, ex);
        //    return res;
        //}

        /// <summary>
        /// 例外処理　NEW
        /// </summary>
        private R GetExcetionResponse<R>(DaDbContext db, Exception ex, string method)
        {
            AiDbUtil.OpenConnection(db!.Connection);
            R res = Activator.CreateInstance<R>();
            SetExceptionResponse(db, ex, (res as DaResponseBase)!);
            DaDbLogService.WriteDbException(db, ex);
            DaLogService.WriteException(method, ex);
            return res;
        }


        public void SetExceptionResponse(DaDbContext db, Exception ex, DaResponseBase res)
        {
            string method = GetMethodName(MethodName, ex);

            var currentMethod = new StackTrace().GetFrame(3)!.GetMethod()!;

            // 接続エラー
            if (ex is AiDbException e)
            {
                switch (e.ExcetionType)
                {
                    case EnumDbExcetionType.TimeOut:
                        {
                            // タイムアウトエラーとする。エラーメッセージを表示し、再実行は可能
                            res.returncode = EnumServiceResult.ServiceError;
                            res.message = DaMessageService.GetMsg(EnumMessage.CM_DBTIMEOUT_ERROR);

                            DaDbLogService.WriteDbMessage(db, res.message + e.StackTrace ?? string.Empty);
                            break;
                        }

                    case EnumDbExcetionType.DeadLock:
                        {
                            // エラーとする。エラーメッセージを表示し、再実行は可能
                            res.returncode = EnumServiceResult.ServiceError;
                            res.message = DaMessageService.GetMsg(EnumMessage.CM_DEADLOCK_ERROR);
                            DaDbLogService.WriteDbMessage(db, res.message + e.StackTrace ?? string.Empty);
                            break;
                        }

                    case EnumDbExcetionType.KeyDuplicate:
                        {
                            // エラーとする。エラーメッセージを表示し、再実行不可能
                            res.returncode = EnumServiceResult.ServiceError;
                            res.message = DaMessageService.GetMsg(EnumMessage.CM_KEYDUPLICATE_ERROR);
                            DaDbLogService.WriteDbMessage(db, res.message + e.StackTrace ?? string.Empty);
                            break;
                        }

                    default:
                        {
                            res.returncode = EnumServiceResult.Exception;
                            res.message = e.ExcetionMessage;
#if DEBUG 
                            string msg = string.Format("例外：{0}", e.Sql);
#else
                            var msg = DaMessageService.GetMsg(EnumMessage.CM_FATAL_ERROR);
#endif
                            DaDbLogService.WriteDbException(db, ex);
                            break;
                        }
                }
            }
            else if (ex is NullReferenceException 
                && (currentMethod.Name.StartsWith("InitDetail") || currentMethod.Name.StartsWith("SearchDetail")))
            {
                res.returncode = EnumServiceResult.InterruptionError;
                res.message = DaMessageService.GetMsg(EnumMessage.A000008);
            }
            else if (ex is AiConnectException)
            {
                res.returncode = EnumServiceResult.ServiceError;
                res.message = DaMessageService.GetMsg(EnumMessage.CM_DBCONN_ERROR);
                string logmsg = string.Format("{0} {1}", res.message, ex.Message);
                DaLogService.WriteMessage(method, logmsg);
            }

            // 項目エラーは画面内エラーとする。エラーメッセージを表示し、再実行は可能
            else if (ex is AiLogicException)
            {
                res.returncode = EnumServiceResult.ServiceError;
                res.message = ex.Message;
                //DaLogService.WirteEnventLog(DaLogService.Level.WARN, method, res.Message);
                //DaLogService.WriteLog(DaLogService.Level.WARN, method, res.message);
            }

            // 排他エラーはサービスエラーとする。エラーメッセージを表示し、再実行は可能
            else if (ex is AiExclusiveException)
            {
                res.returncode = EnumServiceResult.ServiceError;
                res.message = DaMessageService.GetMsg(EnumMessage.CM_EXCLUSIVE_ERROR);
                DaDbLogService.WriteDbException(db, ex);
            }

            // 認証エラーはサービスエラーとする。エラーメッセージを表示し、画面を失敗
            else if (ex is AiSecurityException)
            {
                //AiSecurityException e = (AiSecurityException)ex;
                res.returncode = EnumServiceResult.ServiceError;
                res.message = DaMessageService.GetMsg(EnumMessage.CM_AUTH_ERROR);
            }

            //ダウンロードファイルが存在しない場合、エラーとする
            else if (ex is FileNotFoundException)
            {
                res.returncode = EnumServiceResult.ServiceError;
                res.message = DaMessageService.GetMsg(EnumMessage.DOWNLOAD_NOTEXIST_ERROR);
            }

            // その他のエラーはエラー画面を表示
            else
            {
                res.returncode = EnumServiceResult.ServiceError;
                var msg = DaMessageService.GetMsg(EnumMessage.CM_FATAL_ERROR);
                res.message = $"{msg}({ex.Message})";
                DaLogService.WriteException("", ex);
            }
        }

        //public virtual void BeforeAction(DaRequestBase req)
        //{
        //    db.Session.SessionData[DaConst.SessionID] = req.sessionid;
        //    DaDbLogService.WriteDbMessage(db, "Begin Service");
        //}

        /// <summary>
        /// 処理前処理 NEW
        /// </summary>
        public virtual void BeforeAction(DaDbContext db, DaRequestBase req)
        {
            db.Session.SessionData[DaConst.SessionID] = req.sessionid;
            DaDbLogService.WriteDbMessage(db, "Begin Service");
        }

        /// <summary>
        /// 処理後処理 NEW
        /// </summary>
        public virtual void AfterAction(DaDbContext db, DaResponseBase res)
        {
            DaDbLogService.WriteDbMessage(db, "End Service");
        }

        //public virtual void AfterAction(DaResponseBase res)
        //{
        //    DaDbLogService.WriteDbMessage(db, "End Service");
        //}

        private static string MethodName
        {
            get
            {
                var method = new StackTrace().GetFrame(3)!.GetMethod()!;
                if (method.DeclaringType is null)
                {
                    return string.Empty;
                }
                string service = method.DeclaringType.FullName ?? "";
                int p = service.LastIndexOf(".");
                string s = service[..(p - 1)];
                p = s.LastIndexOf(".");
                service = service[(p + 1)..];
                return string.Format(" {0}.{1}", service, method.Name);
            }
        }

        private static string GetMethodName(string service, Exception ex)
        {
            if (ex is AiExcetionBase ebase)
            {
                if (ebase is not null)
                {
                    return string.Format(" {0}->{1}", service, ebase.MethodName);
                }
            }
            return service;
        }

    }
}
