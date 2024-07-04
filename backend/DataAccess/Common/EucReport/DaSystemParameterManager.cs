// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票ロジック処理
//            システム固定パラメータ処理
// 作成日　　: 2023.05.07
// 作成者　　: 呉
// 変更履歴　:
// *******************************************************************
using AIplus.AiReport.Interface;
using AIplus.AiReport.Models;
using AIplus.FreeQuery.Where;
using NPOI.POIFS.Crypt;

namespace BCC.Affect.DataAccess
{
    public interface IDaEucSystemParameterItem
    {
        object GetValue();

        string GetSQL();
    }
    public class DaEucSystemInfoBase
    {
        protected DaDbContext _db;

        protected ArConditionModel? _condition;
        public string UserID { get; protected set; }
        public string RegSisyo { get; protected set; }
    }

    public class DaEucSystemInfoBase_ReportID : DaEucSystemInfoBase
    {
        public string RptID { get; set; }
        public string YosikiID { get; set; }
    }

    public class DaEucSystemInfoBase_Gamen : DaEucSystemInfoBase
    {
        public EnumReportType ReportType { get; set; }
        public bool IsMakeWorkFlg { get; set; }
        public string WorkSeq { get; set; }
        public bool HasUpdHassoRireki { get; set; }
        /// <summary>
        /// 妊産婦フラグ
        /// </summary>
        public bool Ninsanpuflg { get; set; }

        /// <summary>
        /// 発行データ詳細区分
        /// </summary>
        public string Hakkodatasyosaikbn { get; set; }
    }

    /// <summary>
    /// システム固定項目
    /// </summary>
    public enum EnumSystemParameter
    {
        //画面項目
        P_HAKKOBI,                //発行日
        P_KIJYUNBI,               //基準日
        P_RIYOMOKUTEKI,           //送付先利用目的

        //内部項目
        P_RPT_ID,                //帳票ID
        P_YOSIKI_ID,             //様式ID
        P_RPT_GROUP_ID,          //帳票グループID
        P_KOJINRENRAKUSAKI_CD,   //個人連絡先
        P_GYOMU_KBN,             //業務区分
        P_SHUTU_KBN,             //出力区分
        P_SHUTU_MODE,            //実行モード
        P_WORK_SEQ,              //ワークシーケンス
        P_RIREKI_UPD_FLG,        //発行履歴更新フラグ 
        P_USER_ID,               //ユーザーID
        P_SISYO,                 //登録支所
        P_NINSANPU_FLG,        　//妊産婦フラグ 

        P_TYUSYUTU_TAISYO_CD,    //抽出対象コード
        P_NENDO,                 //年度
        P_TYUSYUTU_SEQ,          //抽出シーケンス
        P_TYUSYUTU_KBN,          //帳票出力区分
        P_YOSIKI_SYUBETU,        //様式種別
        P_HAKKODATASYOSAI_KBN,   //発行データ詳細区分

        出力日,
        出力日和暦,
        発行日,
        発行日和暦,
        基準日,
        基準日和暦,
        問い合わせ先,
        担当部署課,
        担当部署係,
        代表者,
        市町村コード,
        自治体名,
        県名,
        市長
    }
    public class DaSystemParameterManager
    {
        // システム固定項目を定義
        Dictionary<string, IDaEucSystemParameterItem> SystemParameterDic;

        public static List<string> NameList;
        public static List<string> JapNameList;

        private static Dictionary<EnumSystemParameter, string> JapNameDic = new Dictionary<EnumSystemParameter, string>{
            { EnumSystemParameter.P_HAKKOBI, DaEucService.発行日},
            { EnumSystemParameter.P_KIJYUNBI, DaEucService.基準日},
            { EnumSystemParameter.P_RIYOMOKUTEKI, DaEucService.送付先利用目的},

            { EnumSystemParameter.P_RPT_ID, "帳票ID"},
            { EnumSystemParameter.P_YOSIKI_ID, "様式ID"},
            { EnumSystemParameter.P_RPT_GROUP_ID, "帳票グループID"},
            { EnumSystemParameter.P_KOJINRENRAKUSAKI_CD, "個人連絡先"},
            { EnumSystemParameter.P_GYOMU_KBN, "業務区分" },
            { EnumSystemParameter.P_SHUTU_KBN, "出力区分"},
            { EnumSystemParameter.P_SHUTU_MODE, "実行モード"},
            { EnumSystemParameter.P_WORK_SEQ, "ワークシーケンス"},
            { EnumSystemParameter.P_RIREKI_UPD_FLG, "発行履歴更新フラグ"},
            { EnumSystemParameter.P_USER_ID, "ユーザーID"},
            { EnumSystemParameter.P_SISYO, "登録支所"},
            { EnumSystemParameter.P_NINSANPU_FLG, "妊産婦フラグ"},

            { EnumSystemParameter.P_TYUSYUTU_TAISYO_CD, "抽出対象コード"},
            { EnumSystemParameter.P_NENDO, "年度"},
            { EnumSystemParameter.P_TYUSYUTU_SEQ, "抽出シーケンス"},
            { EnumSystemParameter.P_TYUSYUTU_KBN, "帳票出力区分"},
            { EnumSystemParameter.P_YOSIKI_SYUBETU, "様式種別"},
            { EnumSystemParameter.P_HAKKODATASYOSAI_KBN, "発行データ詳細区分"},

             { EnumSystemParameter.出力日, "出力日" },
             { EnumSystemParameter.出力日和暦, "出力日（和暦）" },
             { EnumSystemParameter.発行日, "発行日" },
             { EnumSystemParameter.発行日和暦, "発行日（和暦）" },
             { EnumSystemParameter.基準日, "基準日" },
             { EnumSystemParameter.基準日和暦, "基準日（和暦）" },
             { EnumSystemParameter.問い合わせ先, "問い合わせ先" },
             { EnumSystemParameter.担当部署課, "担当部署（課）" },
             { EnumSystemParameter.担当部署係, "担当部署（係）" },
             { EnumSystemParameter.代表者, "代表者" },
             { EnumSystemParameter.市町村コード, "市町村コード" },
             { EnumSystemParameter.自治体名, "自治体名" },
             { EnumSystemParameter.県名, "県名" },
             { EnumSystemParameter.市長, "市長" }


        };

        static DaSystemParameterManager()
        {
            NameList = new List<string>();
            JapNameList = new List<string>();
            foreach (EnumSystemParameter item in Enum.GetValues(typeof(EnumSystemParameter)))
            {
                NameList.Add(item.ToString());
                JapNameList.Add(JapNameDic[item]);
            }
        }

        public DaSystemParameterManager(DaDbContext db, string workSeq, string rptID, string yosikiID, EnumReportType reportType,
            string reguserid, string? regsisyo, bool isMakeWorkFLg, bool hasUpdHassoRireki, ArConditionModel? condition)
        {
            SystemParameterDic = new Dictionary<string, IDaEucSystemParameterItem>()
            {
                { EnumSystemParameter.P_HAKKOBI.ToString(), new DaEucSystemInfo_HAKKOBI(db, condition) },
                { EnumSystemParameter.P_KIJYUNBI.ToString(), new DaEucSystemInfo_KIJYUNBI(db, condition) },
                { EnumSystemParameter.P_RIYOMOKUTEKI.ToString(), new DaEucSystemInfo_RIYOMOKUTEKI(db, condition) },

                { EnumSystemParameter.P_RPT_ID.ToString(), new DaEucSystemInfo_P_RPT_ID(db, rptID, yosikiID) },
                { EnumSystemParameter.P_YOSIKI_ID.ToString(),new DaEucSystemInfo_P_YOSIKI_ID(db, rptID, yosikiID) },
                { EnumSystemParameter.P_RPT_GROUP_ID.ToString(), new DaEucSystemInfo_P_RPT_GROUP_ID(db, rptID, yosikiID)},
                { EnumSystemParameter.P_KOJINRENRAKUSAKI_CD.ToString(), new DaEucSystemInfo_P_KOJINRENRAKUSAKI_CD(db, rptID, yosikiID)},
                { EnumSystemParameter.P_GYOMU_KBN.ToString(), new DaEucSystemInfo_P_GYOMU_KBN(db, rptID, yosikiID)},
                { EnumSystemParameter.P_SHUTU_KBN.ToString(), new DaEucSystemInfo_P_SHUTU_KBN(db, reportType)},
                { EnumSystemParameter.P_SHUTU_MODE.ToString(), new DaEucSystemInfo_P_SHUTU_MODE(db, isMakeWorkFLg)},
                { EnumSystemParameter.P_WORK_SEQ.ToString(), new DaEucSystemInfo_P_WORK_SEQ(db, workSeq)},
                { EnumSystemParameter.P_RIREKI_UPD_FLG.ToString(), new DaEucSystemInfo_P_RIREKI_UPD_FLG(db, hasUpdHassoRireki)},
                { EnumSystemParameter.P_USER_ID.ToString(), new DaEucSystemInfo_P_USER_ID(db, reguserid)},
                { EnumSystemParameter.P_SISYO.ToString(), new DaEucSystemInfo_P_SISYO(db, regsisyo!)},
                { EnumSystemParameter.P_NINSANPU_FLG.ToString(), new DaEucSystemInfo_P_NINSANPU_FLG(db, rptID)},

                { EnumSystemParameter.P_TYUSYUTU_TAISYO_CD.ToString(), new DaEucSystemInfo_TYUSYUTU_Str(db, EnumSystemParameter.P_TYUSYUTU_TAISYO_CD.ToString(), condition)},
                { EnumSystemParameter.P_NENDO.ToString(), new DaEucSystemInfo_TYUSYUTU_Int(db, EnumSystemParameter.P_NENDO.ToString(), condition)},
                { EnumSystemParameter.P_TYUSYUTU_SEQ.ToString(), new DaEucSystemInfo_TYUSYUTU_Int(db, EnumSystemParameter.P_TYUSYUTU_SEQ.ToString(), condition)},
                { EnumSystemParameter.P_TYUSYUTU_KBN.ToString(), new DaEucSystemInfo_TYUSYUTU_Str(db, EnumSystemParameter.P_TYUSYUTU_KBN.ToString(), condition)},
                { EnumSystemParameter.P_YOSIKI_SYUBETU.ToString(), new DaEucSystemInfo_TYUSYUTU_Str(db, EnumSystemParameter.P_YOSIKI_SYUBETU.ToString(), condition)},
                { EnumSystemParameter.P_HAKKODATASYOSAI_KBN.ToString(), new DaEucSystemInfo_P_HAKKODATASYOSAI_KBN(db, rptID, condition)},

                { JapNameDic[EnumSystemParameter.P_HAKKOBI], new DaEucSystemInfo_HAKKOBI(db, condition) },
                { JapNameDic[EnumSystemParameter.P_KIJYUNBI], new DaEucSystemInfo_KIJYUNBI(db, condition) },
                { JapNameDic[EnumSystemParameter.P_RIYOMOKUTEKI], new DaEucSystemInfo_RIYOMOKUTEKI(db, condition) },

                { JapNameDic[EnumSystemParameter.P_RPT_ID], new DaEucSystemInfo_P_RPT_ID(db, rptID, yosikiID) },
                { JapNameDic[EnumSystemParameter.P_YOSIKI_ID],new DaEucSystemInfo_P_YOSIKI_ID(db, rptID, yosikiID) },
                { JapNameDic[EnumSystemParameter.P_RPT_GROUP_ID], new DaEucSystemInfo_P_RPT_GROUP_ID(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.P_KOJINRENRAKUSAKI_CD], new DaEucSystemInfo_P_KOJINRENRAKUSAKI_CD(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.P_GYOMU_KBN], new DaEucSystemInfo_P_GYOMU_KBN(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.P_SHUTU_KBN], new DaEucSystemInfo_P_SHUTU_KBN(db, reportType)},
                { JapNameDic[EnumSystemParameter.P_SHUTU_MODE], new DaEucSystemInfo_P_SHUTU_MODE(db, isMakeWorkFLg)},
                { JapNameDic[EnumSystemParameter.P_WORK_SEQ], new DaEucSystemInfo_P_WORK_SEQ(db, workSeq)},
                { JapNameDic[EnumSystemParameter.P_RIREKI_UPD_FLG], new DaEucSystemInfo_P_RIREKI_UPD_FLG(db, hasUpdHassoRireki)},
                { JapNameDic[EnumSystemParameter.P_USER_ID], new DaEucSystemInfo_P_USER_ID(db, reguserid)},
                { JapNameDic[EnumSystemParameter.P_SISYO], new DaEucSystemInfo_P_SISYO(db, regsisyo)},
                { JapNameDic[EnumSystemParameter.P_NINSANPU_FLG], new DaEucSystemInfo_P_NINSANPU_FLG(db, rptID)},

                { JapNameDic[EnumSystemParameter.P_TYUSYUTU_TAISYO_CD], new DaEucSystemInfo_TYUSYUTU_Int(db, EnumSystemParameter.P_TYUSYUTU_TAISYO_CD.ToString(), condition)},
                { JapNameDic[EnumSystemParameter.P_NENDO], new DaEucSystemInfo_TYUSYUTU_Int(db, EnumSystemParameter.P_NENDO.ToString(), condition)},
                { JapNameDic[EnumSystemParameter.P_TYUSYUTU_SEQ], new DaEucSystemInfo_TYUSYUTU_Int(db, EnumSystemParameter.P_TYUSYUTU_SEQ.ToString(), condition)},
                { JapNameDic[EnumSystemParameter.P_TYUSYUTU_KBN], new DaEucSystemInfo_TYUSYUTU_Str(db, EnumSystemParameter.P_TYUSYUTU_KBN.ToString(), condition)},
                { JapNameDic[EnumSystemParameter.P_YOSIKI_SYUBETU], new DaEucSystemInfo_TYUSYUTU_Str(db, EnumSystemParameter.P_YOSIKI_SYUBETU.ToString(), condition)},
                { JapNameDic[EnumSystemParameter.P_HAKKODATASYOSAI_KBN], new DaEucSystemInfo_P_HAKKODATASYOSAI_KBN(db, rptID, condition)},

                { JapNameDic[EnumSystemParameter.出力日], new DaEucSystemInfo_出力日()},
                { JapNameDic[EnumSystemParameter.出力日和暦], new DaEucSystemInfo_出力日和暦()},
                { JapNameDic[EnumSystemParameter.発行日和暦], new DaEucSystemInfo_発行日_和暦(db, condition)},
                { JapNameDic[EnumSystemParameter.基準日和暦], new DaEucSystemInfo_基準日_和暦(db, condition)},
                { JapNameDic[EnumSystemParameter.問い合わせ先], new DaEucSystemInfo_問い合わせ先(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.担当部署課], new DaEucSystemInfo_担当部署課(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.担当部署係], new DaEucSystemInfo_担当部署係(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.代表者], new DaEucSystemInfo_代表者(db, rptID, yosikiID)},
                { JapNameDic[EnumSystemParameter.市町村コード], new DaEucSystemInfo_市町村コード(db)},
                { JapNameDic[EnumSystemParameter.自治体名], new DaEucSystemInfo_自治体名(db)},
                { JapNameDic[EnumSystemParameter.県名], new DaEucSystemInfo_県名(db)},
                { JapNameDic[EnumSystemParameter.市長], new DaEucSystemInfo_市長(db, rptID, yosikiID)},
                
            };
        }

        public Dictionary<string, string> GetSystemParameterDic()
        {
            var dic = new Dictionary<string, string>();
            foreach (var de in SystemParameterDic)
            {
                var key = $"@{de.Key}";
                var obj = de.Value;
                var value = obj.GetSQL();
                dic.Add(key, value);
            }
            return dic;
        }

        /// <summary>
        ///システム固定項目かどうかを判断
        /// </summary>
        public static bool IsSystemParameter(string parameterName)
        {
            string upperParameterName = parameterName.ToUpper();
            return NameList.Contains(upperParameterName) || JapNameList.Contains(upperParameterName);
        }
        /// <summary>
        ///システム固定項目Objectを取得 
        /// </summary>
        public IDaEucSystemParameterItem GetItem(string name)
        {
            if (IsSystemParameter(name.ToUpper()))
            {
                return SystemParameterDic[name.ToUpper()];
            }
            else
            {
                throw new ArgumentException("GetInfo");
            }
        }

        /// <summary>
        /// 基本的なパラメータを取得（プロシージャ提示用）
        /// </summary>
        /// <returns></returns>
        public static string[] GetparameterValues()
        {
            List<string> values = new();
            foreach (EnumSystemParameter param in Enum.GetValues(typeof(EnumSystemParameter)))
            {
                if (param != EnumSystemParameter.P_HAKKOBI &&
                    param != EnumSystemParameter.P_KIJYUNBI &&
                    param != EnumSystemParameter.P_RIYOMOKUTEKI)
                {
                    if (JapNameDic.TryGetValue(param, out var value))
                    {
                        values.Add(value);
                    }
                }
            }
            return values.ToArray();
        }
    }

    /// <summary>
    /// 発行日
    /// </summary>
    public class DaEucSystemInfo_HAKKOBI : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_HAKKOBI(DaDbContext db, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
        }

        public string GetSQL()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.発行日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return $"'{parsedDate:yyyy-MM-dd}'";
            }
            return $"'{DateTime.Today.ToString("yyyy-MM-dd")}'";
        }

        public object GetValue()
        {
            return "";
        }
    }

    /// <summary>
    /// 基準日
    /// </summary>
    public class DaEucSystemInfo_KIJYUNBI : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_KIJYUNBI(DaDbContext db, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
        }

        public string GetSQL()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.基準日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return $"'{parsedDate:yyyy-MM-dd}'";
            }
            return $"'{DateTime.Today.ToString("yyyy-MM-dd")}'";
        }

        public object GetValue()
        {
            return "";
        }
    }

    /// <summary>
    /// 送付先利用目的
    /// </summary>
    public class DaEucSystemInfo_RIYOMOKUTEKI : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_RIYOMOKUTEKI(DaDbContext db, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
        }

        public string GetSQL()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.送付先利用目的, out var value))
            {
                return $"'{value}'";
            }
            return $"''";
        }

        public object GetValue()
        {
            return "";
        }
    }

    /// <summary>
    /// 帳票ID
    /// </summary>
    public class DaEucSystemInfo_P_RPT_ID : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_RPT_ID(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }

        public string GetSQL()
        {
            return $"'{RptID}'";
        }

        public object GetValue()
        {
            return RptID;
        }
    }

    /// <summary>
    /// 様式ID
    /// </summary>
    public class DaEucSystemInfo_P_YOSIKI_ID : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_YOSIKI_ID(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }

        public string GetSQL()
        {
            return $"'{YosikiID}'";
        }

        public object GetValue()
        {
            return YosikiID;
        }
    }

    /// <summary>
    /// 帳票グループID
    /// </summary>
    public class DaEucSystemInfo_P_RPT_GROUP_ID : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_RPT_GROUP_ID(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }

        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        public object GetValue()
        {
            string sql = $"SELECT rptgroupid FROM tm_eurpt WHERE rptid = '{RptID}'";
            var list = _db.Session.Query<string>(sql);
            return list.Count() > 0 ? list[0] : "";
        }
    }

    /// <summary>
    /// 個人連絡先
    /// </summary>
    public class DaEucSystemInfo_P_KOJINRENRAKUSAKI_CD : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_KOJINRENRAKUSAKI_CD(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }

        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        public object GetValue()
        {
            string sql = $"SELECT T2.kojinrenrakusakicd FROM tm_eurpt T1 INNER JOIN tm_eurptgroup T2 ON T1.rptgroupid=T2.rptgroupid WHERE T1.rptid = '{RptID}'";
            var list = _db.Session.Query<string>(sql);
            return list.Count() > 0 ? list[0] : "";
        }
    }

    /// <summary>
    /// 業務区分
    /// </summary>
    public class DaEucSystemInfo_P_GYOMU_KBN : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_GYOMU_KBN(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }

        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        public object GetValue()
        {
            string sql = $"SELECT T2.gyomukbn FROM tm_eurpt T1 INNER JOIN tm_eurptgroup T2 ON T1.rptgroupid=T2.rptgroupid WHERE T1.rptid = '{RptID}'";
            var list = _db.Session.Query<string>(sql);
            return list.Count() > 0 ? list[0] : "";
        }
    }
    /// <summary>
    /// 出力区分 
    /// </summary>
    public class DaEucSystemInfo_P_SHUTU_KBN : DaEucSystemInfoBase_Gamen, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_SHUTU_KBN(DaDbContext db, EnumReportType reportType)
        {
            _db = db;
            ReportType = reportType;
        }

        public string GetSQL()
        {
            return $"{(int)GetValue()}";
        }

        public object GetValue()
        {
            switch (ReportType)
            {
                case EnumReportType.EXCEL:
                    return EnumSyutuKbn.EXCEL;
                case EnumReportType.PDF:
                    return EnumSyutuKbn.PDF;
                case EnumReportType.CSV:
                    return EnumSyutuKbn.CSV;
                default:
                    return -1;
            }
        }
    }

    /// <summary>
    /// 実行モード 
    /// </summary>
    public class DaEucSystemInfo_P_SHUTU_MODE : DaEucSystemInfoBase_Gamen, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_SHUTU_MODE(DaDbContext db, bool isMakeWorkFlg)
        {
            _db = db;
            IsMakeWorkFlg = isMakeWorkFlg;
        }

        public string GetSQL()
        {
            return $"{(int)GetValue()}";
        }

        public object GetValue()
        {
            switch (IsMakeWorkFlg!)
            {
                case true:
                    return EnumSyutuMode.検索;
                case false:
                    return EnumSyutuMode.出力;
            }
        }
    }

    /// <summary>
    /// ワークシーケンス 
    /// </summary>
    public class DaEucSystemInfo_P_WORK_SEQ : DaEucSystemInfoBase_Gamen, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_WORK_SEQ(DaDbContext db, string workSeq)
        {
            _db = db;
            WorkSeq = workSeq;
        }

        public string GetSQL()
        {
            return WorkSeq.ToString();
        }

        public object GetValue()
        {
            return WorkSeq;
        }
    }

    /// <summary>
    /// 発行履歴更新フラグ  
    /// </summary>
    public class DaEucSystemInfo_P_RIREKI_UPD_FLG : DaEucSystemInfoBase_Gamen, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_RIREKI_UPD_FLG(DaDbContext db, bool hasUpdHassoRireki)
        {
            _db = db;
            HasUpdHassoRireki = hasUpdHassoRireki;
        }

        public string GetSQL()
        {
            return $"{HasUpdHassoRireki}";
        }

        public object GetValue()
        {
            return HasUpdHassoRireki;
        }
    }

    /// <summary>
    /// 妊産婦フラグ 
    /// </summary>
    public class DaEucSystemInfo_P_NINSANPU_FLG : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_NINSANPU_FLG(DaDbContext db, string rptID)
        {
            _db = db;
            RptID = rptID;
        }

        public string GetSQL()
        {
            return $"{GetValue()}";
        }

        public object GetValue()
        {
            var rptDto = _db.tm_eurpt.GetDtoByKey(RptID);
            return rptDto == null ? false : rptDto.ninsanputorokunoflg;
        }
    }

    /// <summary>
    /// ユーザーID  
    /// </summary>
    public class DaEucSystemInfo_P_SISYO : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_SISYO(DaDbContext db, string userid)
        {
            _db = db;
            UserID = userid;
        }

        public string GetSQL()
        {
            return $"'{UserID}'";
        }

        public object GetValue()
        {
            return UserID;
        }
    }

    /// <summary>
    /// 登録支所  
    /// </summary>
    public class DaEucSystemInfo_P_USER_ID : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_USER_ID(DaDbContext db, string? regsisyo)
        {
            _db = db;
            RegSisyo = regsisyo;
        }

        public string GetSQL()
        {
            return $"'{RegSisyo}'";
        }

        public object GetValue()
        {
            return RegSisyo == null ? "" : RegSisyo;
        }
    }

    /// <summary>
    /// 抽出パネル情報
    /// </summary>
    public class DaEucSystemInfo_TYUSYUTU_Int : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        string _key;
        public DaEucSystemInfo_TYUSYUTU_Int(DaDbContext db, string key, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
            _key = key;
        }

        public string GetSQL()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(_key, out var value))
            {
                return $"{value}";
            }
            return $"null";
        }

        public object GetValue()
        {
            return "";
        }
    }

    /// <summary>
    /// 抽出パネル情報
    /// </summary>
    public class DaEucSystemInfo_TYUSYUTU_Str : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        string _key;
        public DaEucSystemInfo_TYUSYUTU_Str(DaDbContext db, string key, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
            _key = key;
        }

        public string GetSQL()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(_key, out var value))
            {
                return $"'{value}'";
            }
            return "null";
        }

        public object GetValue()
        {
            return "";
        }
    }

    /// <summary>
    /// 発行データ詳細区分
    /// </summary>
    public class DaEucSystemInfo_P_HAKKODATASYOSAI_KBN : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_P_HAKKODATASYOSAI_KBN(DaDbContext db, string rptID, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
            RptID = rptID;
        }

        public string GetSQL()
        {
            var hakkodatasyosaikbn = DaConvertUtil.CStr(GetValue());
            return hakkodatasyosaikbn == "" ? $"null" : $"'{hakkodatasyosaikbn}'";
        }

        public object GetValue()
        {
            var hakkodatasyosaikbn = "";
            var rptDto = _db.tm_eurpt.GetDtoByKey(RptID);
            //抽出パネル表示フラグ
            if (rptDto.tyusyutupanelflg)
            {
                if (_condition != null && _condition.searchDic.TryGetValue(EnumSystemParameter.P_TYUSYUTU_TAISYO_CD.ToString(), out var taisyocd))
                {
                    if (taisyocd != null)
                    {
                        //発行データ詳細区分
                        var dto = _db.tm_kktyusyutu.GetDtoByKey(taisyocd?.ToString() ?? "");
                        if (dto != null)
                        {
                            hakkodatasyosaikbn = dto.tyusyutudatasyosaikbn ?? "";
                        }
                    }
                }
            }
            else
            {
                //様式紐付け名
                if (!string.IsNullOrEmpty(rptDto.yosikihimonm))
                {
                    //紐付けコードをセット
                    var filter = $"{nameof(tm_eurptkensakuDto.rptid)} = '{rptDto.rptid}' and {nameof(tm_eurptkensakuDto.jyokenid)} = {rptDto.yosikihimonm}";
                    var dto = _db.tm_eurptkensaku.SELECT.WHERE.ByFilter(filter).GetDto();
                    if (dto != null)
                    {
                        if (_condition != null && _condition.searchDic.TryGetValue(dto.jyokenlabel!, out var value))
                        {
                            hakkodatasyosaikbn = $"{value}";
                        }
                    }
                }
            }
            return hakkodatasyosaikbn;
        }
    }

    public class DaEucSystemInfo_出力日 : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            return $"{DateTime.Today.ToString("yyyy-MM-dd")}";
        }
    }

    public class DaEucSystemInfo_出力日和暦 : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        public object GetValue()
        {
            return DaFormatUtil.FormatWaKjYMD(DateTime.Today);
        }
    }
    
    public class DaEucSystemInfo_発行日_和暦 : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_発行日_和暦(DaDbContext db, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
        }

        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        /// <summary>
        /// 発行日コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.発行日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return DaFormatUtil.FormatWaKjYMD(parsedDate);
            }
            return DaFormatUtil.FormatWaKjYMD(DateTime.Today);
        }
    }
    
    public class DaEucSystemInfo_基準日_和暦 : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_基準日_和暦(DaDbContext db, ArConditionModel? condition)
        {
            _db = db;
            _condition = condition;
        }

        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        /// <summary>
        /// 基準日コントロールから取得
        /// </summary>
        public object GetValue()
        {
            if (_condition != null && _condition.searchDic.TryGetValue(DaEucService.基準日, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
            {
                return DaFormatUtil.FormatWaKjYMD(parsedDate);
            }
            return DaFormatUtil.FormatWaKjYMD(DateTime.Today);
        }
    }


    public class DaEucSystemInfo_問い合わせ先 : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_問い合わせ先(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            if (YosikiID.StartsWith("0Z")) return "";
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(RptID, YosikiID).GetDto();
            var cd = rptSheet.toiawasesakicd!;
            //return DaSelectorService.GetName(_db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "4");
            var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.問い合わせ内容コード, cd);
            return (dto!=null)?dto.hanyokbn1 ?? "":"";
        }
    }
    public class DaEucSystemInfo_担当部署課 : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_担当部署課(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            if (YosikiID.StartsWith("0Z")) return "";
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(RptID, YosikiID).GetDto();
            var cd = rptSheet.kacd!;
            //return DaSelectorService.GetName(_db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "2");
            var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.課, cd);
            return (dto != null) ? dto.hanyokbn1 ?? "" : "";
        }
    }


    public class DaEucSystemInfo_担当部署係 : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_担当部署係(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        public object GetValue()
        {
            if (YosikiID.StartsWith("0Z")) return "";
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(RptID, YosikiID).GetDto();
            var cd = rptSheet.kakaricd!;
            //return DaSelectorService.GetName(_db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "3");
            var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.係, cd);
            return (dto != null) ? dto.hanyokbn1 ?? "" : "";

        }
    }

    public class DaEucSystemInfo_代表者 : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_代表者(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }

        public object GetValue()
        {
            if (YosikiID.StartsWith("0Z")) return "";
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(RptID, YosikiID).GetDto();
            var dairi = rptSheet.dairisyaflg;
            var daihyosya = DaSelectorService.GetName(_db, "6", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
            if (dairi)
            {
                var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.自治体情報, "6");
                if (string.IsNullOrEmpty(dto.hanyokbn1) || string.IsNullOrEmpty(dto.hanyokbn2))
                {
                    return daihyosya;
                }
                DateTime dt1, dt2;
                if (DateTime.TryParse(dto.hanyokbn1, out dt1) == false || DateTime.TryParse(dto.hanyokbn2, out dt2) == false)
                {
                    return daihyosya;
                }
                else if (dt1 <= DateTime.Today && DateTime.Today <= dt2)
                {
                    return DaSelectorService.GetName(_db, "7", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
                }
                else
                {
                    return daihyosya;
                }
            }
            else
            {
                return daihyosya;
            }
        }
    }
    public class DaEucSystemInfo_市町村コード : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_市町村コード(DaDbContext db)
        {
            _db = db;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            return DaSelectorService.GetName(_db, "1", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); ;
        }
    }
    public class DaEucSystemInfo_自治体名 : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_自治体名(DaDbContext db)
        {
            _db = db;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            return DaSelectorService.GetName(_db, "2", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); ;
        }
    }
    public class DaEucSystemInfo_県名 : DaEucSystemInfoBase, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_県名(DaDbContext db)
        {
            _db = db;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            return DaSelectorService.GetName(_db, "3", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1"); ;
        }
    }
    public class DaEucSystemInfo_市長 : DaEucSystemInfoBase_ReportID, IDaEucSystemParameterItem
    {
        public DaEucSystemInfo_市長(DaDbContext db, string rptID, string yosikiid)
        {
            _db = db;
            RptID = rptID;
            YosikiID = yosikiid;
        }
        public string GetSQL()
        {
            return $"'{GetValue()}'";
        }
        public object GetValue()
        {
            if (YosikiID.StartsWith("0Z")) return "";
            var rptSheet = _db.tm_euyosiki.SELECT.WHERE.ByKey(RptID, YosikiID).GetDto();
            var dairi = rptSheet.dairisyaflg;
            var daihyosya = DaSelectorService.GetName(_db, "4", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
            if (dairi)
            {
                var dto = DaHanyoService.GetHanyoDto(_db, EnumHanyoKbn.自治体情報, "6");
                if (string.IsNullOrEmpty(dto.hanyokbn1) || string.IsNullOrEmpty(dto.hanyokbn2))
                {
                    return daihyosya;
                }
                DateTime dt1, dt2;
                if (DateTime.TryParse(dto.hanyokbn1, out dt1) == false || DateTime.TryParse(dto.hanyokbn2, out dt2) == false)
                {
                    return daihyosya;
                }
                else if (dt1 <= DateTime.Today && DateTime.Today <= dt2)
                {
                    return DaSelectorService.GetName(_db, "5", Enum名称区分.名称, Enumマスタ区分.汎用マスタ, "1001", "1");
                }
                else
                {
                    return daihyosya;
                }
            }
            else
            {
                return daihyosya;
            }
        }
    }
}
