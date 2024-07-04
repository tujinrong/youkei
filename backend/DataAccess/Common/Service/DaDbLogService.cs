// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログ処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace BCC.Affect.DataAccess
{
    public class DaDbLogService
    {
        private const int MAX_CHARS=120;

        #region メインログ、通信ログ

        /// <summary>
        /// メインログファイルの作成
        /// </summary>
        public static long WriteMainLog(DaRequestBase r)
        {
            var displayName = GetDisplayName();

            using (var db = new DaDbContext(r))
            {
                AiDbUtil.OpenConnection(db.Session.Connection!);

                if (db.Session.UserID == null)
                {
                    db.Session.UserID = r.userid;
                }
                var dto = new tt_aflogDto()
                {
                    syoridttmf = DaUtil.Now,
                    syoridttmt = DaUtil.Now,
                    milisec = 0,
                    reguserid = r.userid ?? string.Empty,
                    statuscd = "0",
                    regdttm = DaUtil.Now
                };
                dto.reguserid = r.userid ?? string.Empty;

                db.tt_aflog.INSERT.Execute(dto);

                return dto.sessionseq;
            }
        }

        /// <summary>
        /// メインログファイルの作成
        /// </summary>
        public static long WriteMainLog(DaDbContext db, string kinoid, string service, string method, string methodnm)
        {
            var dto = new tt_aflogDto()
            {
                syoridttmf = DaUtil.Now,
                syoridttmt = DaUtil.Now,
                milisec = 0,
                statuscd = "0",
                kinoid = kinoid,
                service = service,
                method = method,
                methodnm = methodnm,

                reguserid = db.Session.UserID!.ToString() ?? "",
                regdttm = DaUtil.Now
            };
            //dto.reguserid = r.userid ?? string.Empty;
            db.tt_aflog.INSERT.Execute(dto);
            //セッションシーケンスをセット
            db.Session.SessionData[DaConst.SessionID] = dto.sessionseq;
            return dto.sessionseq;
        }
        /// <summary>
        /// 処理ログに書き込み
        /// </summary>
        public static long WriteMainLog(DaDbContext db, tt_aflogDto dto)
        {
            db.tt_aflog.INSERT.Execute(dto);
            return dto.sessionseq;
        }

        /// <summary>
        /// 処理ログの更新
        /// </summary>
        public static void UpdateMainLog(DaDbContext db, tt_aflogDto dto)
        {
            db.tt_aflog.UPDATE.Execute(dto);
        }

        public static void UpdateMainLog(DaDbContext db, EnumServiceResult result)
        {
            switch (result)
            {
                case EnumServiceResult.OK:
                case EnumServiceResult.Hidden:
                    UpdateMainLog(db, EnumLogStatus.正常終了);
                    break;

                case EnumServiceResult.ServiceAlert:
                    UpdateMainLog(db, EnumLogStatus.要確認);
                    break;

                case EnumServiceResult.Exception:
                    UpdateMainLog(db, EnumLogStatus.処理停止);
                    break;

                default:
                    UpdateMainLog(db, EnumLogStatus.異常終了);
                    break;
            }
        }

        /// <summary>
        /// ログ結果を更新
        /// </summary>
        /// <param name="db"></param>
        /// <param name="status"></param>
        public static void UpdateMainLog(DaDbContext db, EnumLogStatus status)
        {
            long sessionSeq = (long)db.Session.SessionData[DaConst.SessionID];

            //データを取得
            var dto = db.tt_aflog.SELECT.WHERE.ByKey(sessionSeq).GetDto();

            //処理時間を計算
            DateTime time = DaUtil.Now;
            dto.syoridttmt = time;
            DateTime startTime = dto.syoridttmf;
            dto.milisec = Convert.ToInt32(time.Subtract(startTime).TotalMilliseconds);
            dto.statuscd = ((int)status).ToString();

            var dic = db.Session.SessionData;
            dto.kinoid = dic.ContainsKey(nameof(DaRequestBase.Service)) ? (string)dic[nameof(DaRequestBase.Service)] : string.Empty;
            dto.service = dic.ContainsKey(nameof(DaRequestBase.ServiceDesc)) ? (string)dic[nameof(DaRequestBase.ServiceDesc)] : string.Empty;
            dto.method = dic.ContainsKey(nameof(DaRequestBase.Method)) ? (string)dic[nameof(DaRequestBase.Method)] : string.Empty;
            dto.methodnm = dic.ContainsKey(nameof(DaRequestBase.MethodDesc)) ? (string)dic[nameof(DaRequestBase.MethodDesc)] : string.Empty;

            db.tt_aflog.UPDATE.Execute(dto);
        }

        /// <summary>
        /// 通信ログ
        /// </summary>
        public static long WriteTusinLog(DaDbContext db, DaRequestBase request, DaResponseBase response, string? msg)
        {
            try
            {
                tt_aftusinlogDto dto = new tt_aftusinlogDto();
                dto.sessionseq = request.sessionid;
                dto.request = JsonConvert.SerializeObject(request);
                dto.response = JsonConvert.SerializeObject(response);
                dto.syoridttmf = DaUtil.Now;
                dto.syoridttmt = DaUtil.Now;                    //TODO：仮の通信ログの終了時間
                dto.msg = msg;
                dto.ipadrs = request.ip;
                dto.browser = request.browser;
                dto.os = request.os;
                dto.reguserid = (string)db.Session.UserID!;
                dto.regdttm = DaUtil.Now;
                db.tt_aftusinlog.INSERT.Execute(dto);
                return dto.tusinlogseq;
            }
            catch { }
            return 0L;
        }

        /// <summary>
        /// 通信ログ
        /// </summary>
        public static void UpdateTusinLog(DaDbContext db, long logSeq)
        {
            try
            {
                tt_aftusinlogDto dto = new tt_aftusinlogDto();
                dto.sessionseq = logSeq;
                dto.syoridttmt = DaUtil.Now;   
                db.tt_aftusinlog.UPDATE.SetUpdateItems(nameof(dto.syoridttmt)).Execute(dto);
            }
            catch { }
        }


        /// <summary>
        /// 通信ログ
        /// </summary>
        public static void WriteTusinLog(DaDbContext db, string msg, string request,
                                            string response, string ipadrs, string os, string browser)
        {
            try
            {
                tt_aftusinlogDto dto = new tt_aftusinlogDto();
                dto.syoridttmf = DaUtil.Now;
                dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
                dto.request = request;
                dto.response = response;
                dto.ipadrs = ipadrs;
                dto.browser = browser;
                dto.os = os;

                dto.reguserid = (string)db.Session.UserID!;
                dto.regdttm = DaUtil.Now;
                db.tt_aftusinlog.INSERT.Execute(dto);
            }
            catch { }
        }

        /// <summary>
        /// 通信ログ
        /// </summary>
        public static void WriteTusinLog(DaDbContext db, tt_aftusinlogDto dto)
        {
            db.tt_aftusinlog.INSERT.Execute(dto);
        }
        #endregion

        #region バッチログ
        /// <summary>
        /// バッチログ
        /// </summary>
        public static void WriteBatchLog(DaDbContext db, string msg)
        {
            try
            {
                tt_afbatchlogDto dto = new tt_afbatchlogDto();
                dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
                dto.syoridttmf = DaUtil.Now;
                dto.msg = msg;
                dto.reguserid = (string)db.Session.UserID!;
                dto.regdttm = DaUtil.Now;
                db.tt_afbatchlog.INSERT.Execute(dto);
            }
            catch { }
        }

        /// <summary>
        /// バッチログ
        /// </summary>
        public static void WriteBatchLog(DaDbContext db, string msg, string param)
        {
            tt_afbatchlogDto dto = new()
            {
                sessionseq = (long)db.Session.SessionData[DaConst.SessionID],
                syoridttmf = DaUtil.Now,
                msg = msg,
                pram = param,
            };
            db.tt_afbatchlog.INSERT.Execute(dto);
        }

        /// <summary>
        /// バッチログ
        /// </summary>
        public static void WriteBatchLog(DaDbContext db, tt_afbatchlogDto dto)
        {
            db.tt_afbatchlog.INSERT.Execute(dto);
        }

        /// <summary>
        /// バッチログの追加（複数場合使用）
        /// </summary>
        public static void AddBatchLog(List<tt_afbatchlogDto> dtoList, string msg, string param = "")
        {
            tt_afbatchlogDto dto = new()
            {
                syoridttmf = DaUtil.Now,
                msg = msg,
                pram = param,
                regdttm = DaUtil.Now
            };
            dtoList.Add(dto);
        }

        /// <summary>
        /// バッチログ（複数場合使用）
        /// </summary>
        public static void WriteBatchLog(DaDbContext db, List<tt_afbatchlogDto> dtoList)
        {
            var sessionSeq = (long)db.Session.SessionData[DaConst.SessionID];
            foreach (var dto in dtoList)
            {
                dto.sessionseq = sessionSeq;
            }
            db.tt_afbatchlog.INSERT.SetBulkInsert().Execute(dtoList);
        }

        #endregion

        #region 外部連携
        /// <summary>
        /// 外部連携
        /// </summary>
        public static void WriteGaibuLog(DaDbContext db, tt_afgaibulogDto dto)
        {
            db.tt_afgaibulog.INSERT.Execute(dto);
        }

        /// <summary>
        /// 外部連携（通信の場合）
        /// </summary>
        public static void WriteGaibuLog(DaDbContext db, string msg, string ipadrs, EnumGaibuKbn kbn, EnumGaibuDataType kbn2)
        {
            tt_afgaibulogDto dto = new tt_afgaibulogDto()
            {
                sessionseq = (long)db.Session.SessionData[DaConst.SessionID],
                syoridttmf = DaUtil.Now,
                msg = msg,
                ipadrs = ipadrs,
                kbn = ((int)kbn).ToString(),
                kbn2 = ((int)kbn2).ToString()
            };
            db.tt_afgaibulog.INSERT.Execute(dto);
        }

        /// <summary>
        /// 外部連携（ファイルの場合）
        /// </summary>
        public static void WriteGaibuLog(DaDbContext db, string apidata, string filenm, EnumFileTypeKbn filetype, int filesize, byte[] filedata)
        {
            tt_afgaibulogDto dto = new tt_afgaibulogDto()
            {
                sessionseq = (long)db.Session.SessionData[DaConst.SessionID],
                syoridttmf = DaUtil.Now,
                apidata = apidata,
                filenm = filenm,
                filetype = filetype,
                filesize = filesize,
                filedata = filedata,
            };
            db.tt_afgaibulog.INSERT.Execute(dto);
        }
        #endregion

        #region 宛名ログ
        /// <summary>
        /// 宛名ログ
        /// </summary>
        public static void WriteAtenaLog(DaDbContext db, string atenano, string msg = "")
        {
            try
            {
                if (msg == "") msg = GetDisplayName();

                tt_aflogatenaDto dto = new tt_aflogatenaDto();
                dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
                dto.atenano = atenano;
                dto.usekbn = ((int)EnumAtenaActionType.検索).ToString();   //TODO
                dto.msg = msg;
                dto.reguserid = (string)db.Session.UserID!;
                dto.regdttm = DaUtil.Now;
                db.tt_aflogatena.INSERT.Execute(dto);
            }
            catch { }
        }
        /// <summary>
        /// 宛名ログ
        /// </summary>
        public static void WriteAtenaLog(DaDbContext db, IList list,
            EnumAtenaActionType usekbn = EnumAtenaActionType.検索, bool pnouseflg = false,
            string msg = "")
        {
            try
            {
                if (msg == "") msg = GetDisplayName();

                var sesssionSeq = (long)db.Session.SessionData[DaConst.SessionID];
                List<tt_aflogatenaDto> dtoList = new List<tt_aflogatenaDto>();
                foreach (var item in list)
                {
                    tt_aflogatenaDto dto = new tt_aflogatenaDto();
                    dto.sessionseq = sesssionSeq;
                    var pi = item.GetType().GetProperty(nameof(tt_afatenaDto.atenano))!;
                    dto.atenano = pi.GetValue(item)?.ToString() ?? "";
                    dto.usekbn = ((int)usekbn).ToString();
                    dto.pnouseflg = pnouseflg;
                    dto.reguserid = (string)db.Session.UserID!;
                    dto.regdttm = DaUtil.Now;
                    dto.msg = msg;
                    dtoList.Add(dto);
                }
                db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
            }
            catch { }
        }

        /// <summary>
        /// 宛名ログ
        /// </summary>
        public static void WriteAtenaLog(DaDbContext db, MethodBase? method, IEnumerable enumerable,
            EnumAtenaActionType usekbn = EnumAtenaActionType.検索, bool pnouseflg = false,
            string? msg = null)
        {
            try
            {
                msg = string.IsNullOrEmpty(msg) ? GetDisplayName(method) : msg;

                var sesssionSeq = (long)db.Session.SessionData[DaConst.SessionID];
                var dtoList = new List<tt_aflogatenaDto>();
                foreach (var item in enumerable)
                {
                    var dto = new tt_aflogatenaDto();
                    dto.sessionseq = sesssionSeq;
                    var pi = item.GetType().GetProperty(nameof(tt_afatenaDto.atenano))!;
                    dto.atenano = pi.GetValue(item)?.ToString() ?? string.Empty;
                    dto.usekbn = EnumToStr(usekbn);
                    dto.pnouseflg = pnouseflg;
                    dto.reguserid = (string)db.Session.UserID!;
                    dto.regdttm = DaUtil.Now;
                    dto.msg = msg;
                    dtoList.Add(dto);
                }
                db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
            }
            catch { }
        }

        /// <summary>
        /// 宛名ログ
        /// </summary>
        public static void WriteAtenaLog(DaDbContext db, string atenano, bool pnouseflg, EnumAtenaActionType usekbn, string? msg = null)
        {
            try
            {
                //if (string.IsNullOrEmpty(msg)) msg = GetDisplayName();

                tt_aflogatenaDto dto = new tt_aflogatenaDto();
                dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
                dto.atenano = atenano;
                dto.usekbn = ((int)usekbn).ToString();
                dto.pnouseflg = pnouseflg;
                dto.msg = msg;
                dto.reguserid = (string)db.Session.UserID!;
                dto.regdttm = DaUtil.Now;
                db.tt_aflogatena.INSERT.Execute(dto);
            }
            catch { }
        }

        /// <summary>
        /// 宛名ログ
        /// </summary>
        public static void WriteAtenaLog(DaDbContext db, tt_aflogatenaDto dto)
        {
            db.tt_aflogatena.INSERT.Execute(dto);
        }

        /// <summary>
        /// 宛名ログ(複数場合）
        /// </summary>
        public static void AddAtenaLog(List<tt_aflogatenaDto> dtoList, string atenano, EnumAtenaActionType usekbn, bool pnouseflg = false, string msg = "")
        {
            if (msg == "") msg = GetDisplayName();

            tt_aflogatenaDto dto = new tt_aflogatenaDto();
            dto.atenano = atenano;
            dto.usekbn = ((int)usekbn).ToString();
            dto.pnouseflg = pnouseflg;
            dto.regdttm = DaUtil.Now;
            dto.msg = msg;
            dtoList.Add(dto);
        }

        /// <summary>
        /// 宛名ログ（複数場合）
        /// </summary>
        public static void WriteAtenaLog(DaDbContext db, List<tt_aflogatenaDto> dtoList)
        {
            var sesssionSeq = (long)db.Session.SessionData[DaConst.SessionID];
            foreach (var dto in dtoList)
            {
                dto.sessionseq = sesssionSeq;
                dto.reguserid = (string)db.Session.UserID!;
            }
            db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
        }
        #endregion

        #region　共通ログ
        /// <summary>
        /// 汎用メッセージ出力。処理要のメッセージ、DEBUGメッセージに出力可。
        /// </summary>
        public static void WriteDbMessage(DaDbContext db, string msg)
        {
            tt_aflogdbDto dto = new tt_aflogdbDto();
            dto.msg = msg;
            dto.sessionseq = (long)db.Session.SessionData[DaConst.SessionID];
            dto.reguserid = db.Session.UserID == null ? DaConst.LOG_ERR_VALUE : db.Session.UserID.ToString()!;
            dto.regdttm = DaUtil.Now;
            InsertDto(db.Session, dto);
        }

        /// <summary>
        /// 汎用例外メッセージ出力
        /// </summary>
        public static void WriteDbException(DaDbContext db, Exception ex)
        {
            try
            {
                tt_aflogdbDto dto = new tt_aflogdbDto();
                dto.msg = $"{ex.Message} {ex.StackTrace}";
                dto.reguserid = db.Session.UserID!.ToString()!;
                dto.regdttm = DaUtil.Now;
                InsertDto(db.Session, dto);
            }
            catch { }
        }

        /// <summary>
        /// DBログ処理
        /// </summary>
        public static void LogDelegate(AiSessionContext session, DateTime beginTime, DateTime endTime, string sql, DataTable dt, int result)
        {
            if (dt != null && (dt.TableName == tt_aflogDto.TABLE_NAME
                || dt.TableName == tt_aftusinlogDto.TABLE_NAME
                || dt.TableName == tt_afbatchlogDto.TABLE_NAME
                || dt.TableName == tt_afgaibulogDto.TABLE_NAME
                || dt.TableName == tt_aflogatenaDto.TABLE_NAME
                || dt.TableName == tt_aflogdbDto.TABLE_NAME
                || dt.TableName == tt_aflogcolumnDto.TABLE_NAME))
            {
                return;
            }
            if (session == null || (long)session.SessionData[DaConst.SessionID] == 0L || (long)session.SessionData[DaConst.SessionID] == -1L)
            {
                return;
            }
            if (sql.Contains("information_schema")) return;

            var dto = new tt_aflogdbDto();
            dto.sessionseq = (long)session.SessionData[DaConst.SessionID];
            if (session.SessionData != null && session.SessionData.Any())
            {
                var userId = session.UserID;
                dto.reguserid = userId == null ? DaConst.LOG_ERR_VALUE : userId.ToString()!;
            }
            else
            {
                dto.reguserid = DaConst.LOG_ERR_VALUE;
            }
            dto.regdttm = DaUtil.Now;
            dto.sql = sql;

            InsertDto(session, dto);
        }

        /// <summary>
        /// 更新項目処理
        /// </summary>
        public static void DiffDelegate(AiSessionContext session, string tableName, EnumActionType diffType, DataTable oldDt, DataTable newDt, object? param)
        {
            if (tableName == tt_aflogDto.TABLE_NAME
                || tableName == tt_aftusinlogDto.TABLE_NAME
                || tableName == tt_afbatchlogDto.TABLE_NAME
                || tableName == tt_afgaibulogDto.TABLE_NAME
                || tableName == tt_aflogatenaDto.TABLE_NAME
                || session == null || (long)session.SessionData[DaConst.SessionID] == 0L || (long)session.SessionData[DaConst.SessionID] == -1L)
            {
                return;
            }
            List<tt_aflogcolumnDto> lst;
            var tableInfo = AiGlobal.DbInfoProvider.GetTableInfo(session, tableName);

            switch (diffType)
            {
                case EnumActionType.Insert:
                    {
                        lst = AddList(tableName, session, newDt, tableInfo);
                        //宛名ログ
                        if (param != null)
                        {
                            AtenaLog(session, diffType, newDt, param);
                        }
                        break;
                    }
                case EnumActionType.Update:
                    {
                        lst = UpdList(tableName, session, oldDt, newDt, tableInfo);
                        //宛名ログ
                        if (param != null && param.GetType() == typeof(List<string>))
                        {
                            AtenaLog(session, diffType, newDt, param);
                        }
                        break;
                    }

                default:
                    {
                        lst = DelList(tableName, session, oldDt, tableInfo);
                        //宛名ログ
                        if (param != null)
                        {
                            AtenaLog(session, diffType, oldDt, param);
                        }
                        break;
                    }
            }

            if (session is not null)
            {
                foreach (var row in lst)
                {
                    row.reguserid = (string)session.UserID!;
                    row.regdttm = DaUtil.Now;
                }
            }

            InsertDto(session!, lst);
        }

        private static void AtenaLog(AiSessionContext session, EnumActionType diffType, DataTable dt, object? param)
        {
            if (session.DbContext == null) throw new ArgumentException();
            if (param == null) throw new ArgumentException(); ;

            var dtoList = new List<tt_aflogatenaDto>();
            List<string> pnoDic;
            if (param.GetType() == typeof(object))
            {
                pnoDic = new List<string>();
            }
            else
            {
                pnoDic = (List<string>)param;
            }

            var listkey = nameof(AtenaLog) + diffType.ToString();
            if (session.SessionData.ContainsKey(listkey)==false)
            {
                session.SessionData.Add(listkey, new HashSet<string>());
            }
            HashSet<string> lst = (HashSet<string>)session.SessionData[listkey];
            foreach (DataRow dr in dt.Rows)
            {
                tt_aflogatenaDto dto = new tt_aflogatenaDto();
                dto.atenano = dr["atenano"].ToString()!;
                //１個のSession内、同じ宛名のログを１個のみ出力する
                if (lst.Contains(dto.atenano) == false)
                {
                    dto.usekbn = diffType switch { EnumActionType.Insert => "1", EnumActionType.Update => "2", EnumActionType.Delete => "3", _ => throw new ArgumentException() };
                    dto.pnouseflg = pnoDic.Contains(dto.atenano);
                    dto.regdttm = DaUtil.Now;
                    //dto.msg = msg;
                    dtoList.Add(dto);

                    lst.Add(dto.atenano);   
                }
            }

            var db = (DaDbContext)session.DbContext!;
            db.tt_aflogatena.INSERT.SetBulkInsert().Execute(dtoList);
        }

        public static void WriteService(DaDbContext db, tt_aflogdbDto dto)
        {
            try
            {
                InsertDto(db.Session, dto);
            }
            catch { }
        }
        #endregion

        #region private

        private static void InsertDto(AiSessionContext session, List<tt_aflogcolumnDto> lst)
        {
            var dt1 = Gettt_aflogcolumnDt(session);
            AiDtoUtil.SetDataTable(lst, dt1);
            DaDbUtil.BulkInsert(session, dt1, tt_aflogcolumnDto.TABLE_NAME, true);
        }

        private static List<tt_aflogcolumnDto> AddList(string tablename, AiSessionContext session, DataTable dt, AiTableInfo tableInfo)
        {
            var lst = new List<tt_aflogcolumnDto>();
            var tm = DaUtil.Now;
            //string reguserid = dt.Rows[0].ToStr(nameof(tm_afuserDto.upduserid));
            var keys = tableInfo.KeyList.Select(e => e.FieldName).ToList();
            foreach (DataRow dr in dt.Rows)
            {
                lst.AddRange(GetAddList(tablename, keys, tm, session, dr));
            }
            return lst;
        }

        private static List<tt_aflogcolumnDto> UpdList(string tablename, AiSessionContext session, DataTable olddt, DataTable newDt, AiTableInfo tableInfo)
        {
            var tm = DaUtil.Now;
            var lst = new List<tt_aflogcolumnDto>();
            //string reguserid ="";
            //if (newDt.Rows.Count > 0)
            //{
            //    if (newDt.Rows[0].ToStr(nameof(tm_afuserDto.upduserid)) !="")
            //    {
            //        reguserid = newDt.Rows[0].ToStr(nameof(tm_afuserDto.reguserid));
            //    }
            //}
            var dic1 = new Dictionary<string, DataRow>();
            var keys = tableInfo.KeyList.Select(e => e.FieldName).ToList();
            foreach (DataRow dr in olddt.Rows)
            {
                string[] keyValues = keys.Select(e => dr.CStr(e)).ToArray();
                string keyData = string.Join(",", keyValues);
                dic1.Add(keyData, dr);
            }

            var dic2 = new Dictionary<string, DataRow>();
            foreach (DataRow dr in newDt.Rows)
            {
                string[] keyValues = keys.Select(e => dr.CStr(e)).ToArray();
                string keyData = string.Join(",", keyValues);
                dic2.Add(keyData, dr);
            }

            // 更新
            foreach (var key in dic1.Keys)
            {
                if (dic2.ContainsKey(key))
                {
                    lst.AddRange(GetUpdList(tablename, keys, tm, session, dic1[key], dic2[key]));
                }
            }

            // 新規
            foreach (var key in dic2.Keys)
            {
                if (dic1.ContainsKey(key) == false)
                {
                    lst.AddRange(GetAddList(tablename, keys, tm, session, dic2[key]));
                }
            }

            // 削除
            foreach (var key in dic1.Keys)
            {
                if (dic2.ContainsKey(key) == false)
                {
                    lst.AddRange(GetDelList(tablename, keys, tm, session, dic1[key]));
                }
            }

            return lst;
        }

        private static List<tt_aflogcolumnDto> DelList(string tablename, AiSessionContext session, DataTable dt, AiTableInfo tableInfo)
        {
            var lst = new List<tt_aflogcolumnDto>();
            var tm = DaUtil.Now;
            var keys = tableInfo.KeyList.Select(e => e.FieldName).ToList();
            foreach (DataRow dr in dt.Rows)
            {
                lst.AddRange(GetDelList(tablename, keys, tm, session, dr));
            }

            return lst;
        }
        private static List<tt_aflogcolumnDto> GetAddList(string tableName, List<string> keys, DateTime tm, AiSessionContext session, DataRow dr)
        {
            var lst = new List<tt_aflogcolumnDto>();
            string[] keyValues = keys.Select(e => dr[e].ToString() ?? string.Empty).ToArray();
            string keyData = string.Join(",", keyValues);
            for (int i = 0; i< dr.Table.Columns.Count ; i++)
            {
                var col = dr.Table.Columns[i];
                switch (col.ColumnName ?? string.Empty)
                {
                    case nameof(tm_afuserDto.reguserid):
                    case nameof(tm_afuserDto.regdttm):
                    case nameof(tm_afuserDto.upduserid):
                    case nameof(tm_afuserDto.upddttm):
                        {
                            continue;
                        }
                }
                string value = dr[i].ToString() ?? string.Empty;
                if (!string.IsNullOrEmpty(value))
                {
                    for (int c = 0; c< value.Length; c += MAX_CHARS)
                    {
                        var dto = new tt_aflogcolumnDto();
                        dto.sessionseq =(session.SessionData.ContainsKey(DaConst.SessionID))?
                                        (long)session.SessionData[DaConst.SessionID]:-1;                        // セッションID
                        dto.regdttm = tm;                                         // 時刻
                        dto.tablenm = tableName;                                  // テーブル名
                        dto.henkokbn = ((int)EnumActionType.Insert).ToString();   // 更新区分
                        dto.reguserid = session.UserID == null ? DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
                        if (dto.reguserid.Length > 10)
                        {
                            dto.reguserid = DaConst.LOG_ERR_VALUE;
                        }

                        dto.keys = keyData;                  　                 // キー
                        dto.itemnm = dr.Table.Columns[i].ColumnName;            // 項目名
                        dto.valuebefore = null;                            　　 // 変更前内容
                        dto.valueafter = new string(value.Skip(c).Take(MAX_CHARS).ToArray());
                        lst.Add(dto);
                    }
                }
            }

            return lst;
        }

        private static List<tt_aflogcolumnDto> GetDelList(string tableName, List<string> keys, DateTime tm, AiSessionContext session, DataRow dr)
        {
            var isLogKey = false;
            if (isLogKey)
            {
                //レコード単位のログ
                var lst = new List<tt_aflogcolumnDto>();

                string[] keyValues = keys.Select(e => dr.CStr(e)).ToArray();
                string keyData = string.Join(",", keyValues);
                var dto = new tt_aflogcolumnDto();
                dto.sessionseq = (long)session.SessionData[DaConst.SessionID];                        // セッションID
                dto.regdttm = tm;                                         // 時刻
                dto.tablenm = tableName;                                  // テーブル名
                dto.henkokbn = ((int)EnumActionType.Delete).ToString();   // 更新区分
                dto.reguserid = session.UserID == null ? DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
                if (dto.reguserid.Length > 10)
                {
                    dto.reguserid = DaConst.LOG_ERR_VALUE;
                }

                dto.keys = keyData;                                     // キー
                lst.Add(dto);

                return lst;
            }
            else
            {
                //各項目単位でのログ出力
                var lst = new List<tt_aflogcolumnDto>();
                string[] keyValues = keys.Select(e => dr[e].ToString() ?? string.Empty).ToArray();
                string keyData = string.Join(",", keyValues);
                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    var col = dr.Table.Columns[i];
                    switch (col.ColumnName ?? string.Empty)
                    {
                        case nameof(tm_afuserDto.reguserid):
                        case nameof(tm_afuserDto.regdttm):
                        case nameof(tm_afuserDto.upduserid):
                        case nameof(tm_afuserDto.upddttm):
                            {
                                continue;
                            }
                    }
                    string value = dr[i].ToString() ?? string.Empty;
                    if (!string.IsNullOrEmpty(value))
                    {
                        for (int c = 0; c < value.Length; c += MAX_CHARS)
                        {
                            var dto = new tt_aflogcolumnDto();
                            dto.sessionseq = (session.SessionData.ContainsKey(DaConst.SessionID)) ?
                                            (long)session.SessionData[DaConst.SessionID] : -1;                        // セッションID
                            dto.regdttm = tm;                                         // 時刻
                            dto.tablenm = tableName;                                  // テーブル名
                            dto.henkokbn = ((int)EnumActionType.Delete).ToString();   // 更新区分
                            dto.reguserid = session.UserID == null ? DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
                            if (dto.reguserid.Length > 10)
                            {
                                dto.reguserid = DaConst.LOG_ERR_VALUE;
                            }

                            dto.keys = keyData;                                    // キー
                            dto.itemnm = dr.Table.Columns[i].ColumnName;            // 項目名
                            dto.valuebefore = null;                               // 変更前内容
                            dto.valueafter = new string(value.Skip(c).Take(120).ToArray());
                            lst.Add(dto);
                        }
                    }
                }

                return lst;

            }
        }

        private static List<tt_aflogcolumnDto> GetUpdList(string tableName, List<string> keys, DateTime tm, AiSessionContext session, DataRow dr1, DataRow dr2)
        {
            var lst = new List<tt_aflogcolumnDto>();
            for (int i = 0; i < dr1.Table.Columns.Count; i++)
            {
                string[] keyValues = keys.Select(e => dr1[e].ToString() ?? string.Empty).ToArray();
                string keyData = string.Join(",", keyValues);
                var col = dr1.Table.Columns[i];
                switch (col.ColumnName ?? string.Empty)
                {
                    case nameof(tm_afuserDto.reguserid):
                    case nameof(tm_afuserDto.regdttm):
                    case nameof(tm_afuserDto.upduserid):
                    case nameof(tm_afuserDto.upddttm):
                        {
                            continue;
                        }
                }
                string value1 = dr1[i].ToString() ?? string.Empty.Trim();
                string value2 = dr2[i].ToString() ?? string.Empty.Trim();
                if ((value1 ?? string.Empty) != (value2 ?? string.Empty))
                {
                    for (int c = 0, loopTo1 = Math.Max(value1!.Length, value2!.Length); c <= loopTo1; c += MAX_CHARS)
                    {
                        var dto = new tt_aflogcolumnDto();
                        dto.sessionseq = (long)session.SessionData[DaConst.SessionID];                      // セッションID
                        dto.regdttm = tm;                                       // 時刻
                        dto.tablenm = tableName;                                  // テーブル名
                        dto.henkokbn = ((int)EnumActionType.Update).ToString();   // 更新区分
                        dto.reguserid = session.UserID == null ? DaConst.LOG_ERR_VALUE : session.UserID.ToString()!; // 更新者
                        if (dto.reguserid.Length > 10)
                        {
                            dto.reguserid = DaConst.LOG_ERR_VALUE;
                        }
                        dto.keys = keyData;                                     // キー
                        dto.itemnm = dr1.Table.Columns[i].ColumnName;           // 項目名
                        dto.valuebefore = new string(value1.Skip(c).Take(MAX_CHARS).ToArray()); // 変更前内容
                        dto.valueafter = new string(value2.Skip(c).Take(MAX_CHARS).ToArray());
                        lst.Add(dto);
                    }
                }
            }
            return lst;
        }

        private static void InsertDto(AiSessionContext session, tt_aflogdbDto dto)
        {
            var dt = Gettt_aflogdbDt(session);
            var userId = session.UserID;
            dto.reguserid = userId == null ? DaConst.LOG_ERR_VALUE : userId.ToString()!;
            dto.regdttm = DaUtil.Now;
            AiDtoUtil.SetDataTable(dto, dt);
            DaDbUtil.BulkInsert(session, dt, tt_aflogdbDto.TABLE_NAME, true);
        }

        private static string GetDisplayName(MethodBase? method = null)
        {
            try
            {
                method ??= new StackTrace().GetFrame(2)?.GetMethod()!;
                var attribute = method.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
                return attribute.DisplayName;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// メインログテーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_aflogDt()
        {
            var dt = new DataTable();
            dt.Columns.Add(nameof(tt_aflogDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_aflogDto.syoridttmf), typeof(DateTime));
            dt.Columns.Add(nameof(tt_aflogDto.syoridttmt), typeof(DateTime));
            dt.Columns.Add(nameof(tt_aflogDto.milisec), typeof(int));
            dt.Columns.Add(nameof(tt_aflogDto.statuscd));
            dt.Columns.Add(nameof(tt_aflogDto.kinoid));
            dt.Columns.Add(nameof(tt_aflogDto.service));
            dt.Columns.Add(nameof(tt_aflogDto.method));
            dt.Columns.Add(nameof(tt_aflogDto.methodnm));
            dt.Columns.Add(nameof(tt_aflogDto.reguserid));
            dt.Columns.Add(nameof(tt_aflogDto.regdttm), typeof(DateTime));
            return dt;
        }

        /// <summary>
        /// 通信ログテーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_aftusinlogDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(nameof(tt_aftusinlogDto.tusinlogseq), typeof(long));
            dt.Columns.Add(nameof(tt_aftusinlogDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_aftusinlogDto.syoridttmf), typeof(DateTime));
            dt.Columns.Add(nameof(tt_aftusinlogDto.msg));
            dt.Columns.Add(nameof(tt_aftusinlogDto.request));
            dt.Columns.Add(nameof(tt_aftusinlogDto.response));
            dt.Columns.Add(nameof(tt_aftusinlogDto.ipadrs));
            dt.Columns.Add(nameof(tt_aftusinlogDto.os));
            dt.Columns.Add(nameof(tt_aftusinlogDto.browser));
            dt.Columns.Add(nameof(tt_aftusinlogDto.reguserid));
            dt.Columns.Add(nameof(tt_aftusinlogDto.regdttm), typeof(DateTime));
            return dt;
        }

        /// <summary>
        /// バッチログテーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_afbatchlogDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(nameof(tt_afbatchlogDto.batchlogseq), typeof(long));
            dt.Columns.Add(nameof(tt_afbatchlogDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_afbatchlogDto.syoridttmf), typeof(DateTime));
            dt.Columns.Add(nameof(tt_afbatchlogDto.msg));
            dt.Columns.Add(nameof(tt_afbatchlogDto.pram));
            dt.Columns.Add(nameof(tt_afbatchlogDto.reguserid));
            dt.Columns.Add(nameof(tt_afbatchlogDto.regdttm), typeof(DateTime));

            return dt;
        }

        /// <summary>
        /// 外部連携処理結果履歴テーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_afgaibulogDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(nameof(tt_afgaibulogDto.gaibulogseq), typeof(int));
            dt.Columns.Add(nameof(tt_afgaibulogDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_afgaibulogDto.syoridttmf), typeof(DateTime));
            dt.Columns.Add(nameof(tt_afgaibulogDto.msg));
            dt.Columns.Add(nameof(tt_afgaibulogDto.ipadrs));
            dt.Columns.Add(nameof(tt_afgaibulogDto.kbn));
            dt.Columns.Add(nameof(tt_afgaibulogDto.kbn2));
            dt.Columns.Add(nameof(tt_afgaibulogDto.apidata));
            dt.Columns.Add(nameof(tt_afgaibulogDto.filenm));
            dt.Columns.Add(nameof(tt_afgaibulogDto.filetype), typeof(short));
            dt.Columns.Add(nameof(tt_afgaibulogDto.filesize), typeof(int));
            dt.Columns.Add(nameof(tt_afgaibulogDto.filedata));
            dt.Columns.Add(nameof(tt_afgaibulogDto.reguserid));
            dt.Columns.Add(nameof(tt_afgaibulogDto.regdttm), typeof(DateTime));

            return dt;
        }

        /// <summary>
        /// 宛名番号ログテーブルテーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_aflogatenaDt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(nameof(tt_aflogatenaDto.atenalogseq), typeof(int));
            dt.Columns.Add(nameof(tt_aflogatenaDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_aflogatenaDto.atenano));
            dt.Columns.Add(nameof(tt_aflogatenaDto.pnouseflg), typeof(bool));
            dt.Columns.Add(nameof(tt_aflogatenaDto.usekbn));
            dt.Columns.Add(nameof(tt_aflogatenaDto.msg));
            dt.Columns.Add(nameof(tt_aflogatenaDto.reguserid));
            dt.Columns.Add(nameof(tt_aflogatenaDto.regdttm), typeof(DateTime));

            return dt;
        }


        /// <summary>
        /// DB操作ログテーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_aflogdbDt(AiSessionContext session)
        {
            var dt = new DataTable();
            dt.Columns.Add(nameof(tt_aflogdbDto.dblogseq), typeof(long));
            dt.Columns.Add(nameof(tt_aflogdbDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_aflogdbDto.sql), typeof(string));
            dt.Columns.Add(nameof(tt_aflogdbDto.msg), typeof(string));
            dt.Columns.Add(nameof(tt_aflogdbDto.reguserid), typeof(string));
            dt.Columns.Add(nameof(tt_aflogdbDto.regdttm), typeof(DateTime));
            return dt;
        }

        /// <summary>
        /// テーブル項目値変更ログテーブルDataTable作成
        /// </summary>
        private static DataTable Gettt_aflogcolumnDt(AiSessionContext session)
        {
            var dt = new DataTable();
            dt.Columns.Add(nameof(tt_aflogcolumnDto.columnlogseq), typeof(long));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.sessionseq), typeof(long));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.tablenm), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.henkokbn), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.keys), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.itemnm), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.valuebefore), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.valueafter), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.reguserid), typeof(string));
            dt.Columns.Add(nameof(tt_aflogcolumnDto.regdttm), typeof(DateTime));
            return dt;
        }

        #endregion
    }
}