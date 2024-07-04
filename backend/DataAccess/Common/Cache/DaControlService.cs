// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コントロールマスタ
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using Microsoft.Extensions.Caching.Memory;
using NPOI.POIFS.Crypt;
using NPOI.POIFS.Crypt.Dsig;
using static BCC.Affect.DataAccess.DaControlService;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class DaControlService
    {

        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;


        /// <summary>
        /// キャシュークリア
        /// </summary>
        public static void ClearCache()
        {
            _cache?.Clear();
        }

        public static List<tm_afctrlDtoEx> GetList(DaDbContext db, params EnumCtrlKbn[] ctrlKbns)
        {
            var list = GetList(db);
            if (ctrlKbns == null || ctrlKbns.Length == 0)
            {
                return list;
            }
            var dic = GetDic(db);
            return dic.Where(d => ctrlKbns.Contains(d.Key)).SelectMany(d => d.Value).ToList();
        }

        public static List<tm_afctrlDtoEx> GetList(DaDbContext db, string ctrlmaincd, int ctrlsubcd)
        {
            var dic = GetDic(db);
            return dic.TryGetValue((EnumCtrlKbn)(CInt(ctrlmaincd) * 100000000L + ctrlsubcd), out var dtl) ? dtl : new List<tm_afctrlDtoEx>(0);
        }

        public static tm_afctrlDtoEx GetRow(DaDbContext db, EnumCtrlKbn ctrlKbn, string ctrCd)
        {
            var dic = GetDic(db);
            return dic[ctrlKbn].Find(x => x.ctrlcd == ctrCd)!;
        }

        public static SystemConfig GetSystemConfig(DaDbContext db)
        {
            var dic = GetDic(db);
            var value = dic[EnumCtrlKbn.config情報].Find(x => x.ctrlcd == DaCodeConst.コントロールマスタ.システム.config情報._01)?.value1;
            SystemConfig systemConfig = new SystemConfig();
            systemConfig.TokenTimeout = value != null ? TimeSpan.Parse(value!) : new TimeSpan(0, 1, 0, 0);
            return systemConfig;
        }

        private static List<tm_afctrlDtoEx> GetList(DaDbContext db)
        {
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }

            List<tm_afctrlDtoEx> list;
            if (!_cache.TryGetValue("LIST", out list!))
            {
                list = db.tm_afctrl.SELECT.GetDtoList().Select(x => new tm_afctrlDtoEx(x)).ToList();
                _cache.Set("LIST", list, TimeSpan.FromMinutes(CACHE_MINIUTE));

            }

            return list;
        }

        private static Dictionary<EnumCtrlKbn, List<tm_afctrlDtoEx>> GetDic(DaDbContext db)
        {
            var list = GetList(db);
            var dic = new Dictionary<EnumCtrlKbn, List<tm_afctrlDtoEx>>();
            foreach (var row in list)
            {
                var key = (EnumCtrlKbn)(int.Parse(row.ctrlmaincd) * 100000000L + row.ctrlsubcd);
                if (!dic.ContainsKey(key))
                {
                    dic[key] = new List<tm_afctrlDtoEx>();
                }
                dic[key].Add(row);
            }

            return dic;
        }


        public class SystemConfig
        {
            public TimeSpan TokenTimeout;
        }
    }

    public class tm_afctrlDtoEx : tm_afctrlDto
    {
        public EnumDataType EnumDataType;
        public int IntValue1 => (EnumDataType == EnumDataType.整数) ? CInt(value1) : throw new ArgumentException();
        public int IntValue2 => (EnumDataType == EnumDataType.整数 && rangeflg) ? CInt(value2) : throw new ArgumentException();
        public decimal DecValue1 => (EnumDataType == EnumDataType.小数) ? CDec(value1) : throw new ArgumentException();
        public decimal DecValue2 => (EnumDataType == EnumDataType.小数 && rangeflg) ? CDec(value2) : throw new ArgumentException();
        public string StringValue1 => (EnumDataType == EnumDataType.文字列) ? CStr(value1) : throw new ArgumentException();
        public string StringValue2 => (EnumDataType == EnumDataType.文字列 && rangeflg) ? CStr(value2) : throw new ArgumentException();
        public DateTime DateTimeValue1 => (EnumDataType == EnumDataType.日付) ? CDate(value1) : throw new ArgumentException();
        public DateTime DateTimeValue2 => ((EnumDataType == EnumDataType.日付) && rangeflg) ? CDate(value2) : throw new ArgumentException();
        public TimeSpan TimeSpanValue1 => (EnumDataType == EnumDataType.時間) ? CTimeSpan(value1) : throw new ArgumentException();
        public TimeSpan TimeSpanValue2 => ((EnumDataType == EnumDataType.時間) && rangeflg) ? CTimeSpan(value2) : throw new ArgumentException();
        public bool BoolValue1 => (EnumDataType == EnumDataType.フラグ) ? CBool(value1) : throw new ArgumentException();
        public bool BoolValue2 => ((EnumDataType == EnumDataType.フラグ) && rangeflg) ? CBool(value2) : throw new ArgumentException();

        public int? nIntValue1 => (EnumDataType == EnumDataType.整数) ? CNInt(value1) : throw new ArgumentException();
        public int? nIntValue2 => (EnumDataType == EnumDataType.整数 && rangeflg) ? CNInt(value2) : throw new ArgumentException();
        public decimal? nDecValue1 => (EnumDataType == EnumDataType.小数) ? CNDec(value1) : throw new ArgumentException();
        public decimal? nDecValue2 => (EnumDataType == EnumDataType.小数 && rangeflg) ? CNDec(value2) : throw new ArgumentException();
        public string? nStringValue1 => (EnumDataType == EnumDataType.文字列) ? value1 : throw new ArgumentException();
        public string? nStringValue2 => (EnumDataType == EnumDataType.文字列 && rangeflg) ? value2 : throw new ArgumentException();
        public DateTime? nDateTimeValue1 => (EnumDataType == EnumDataType.日付) ? CNDate(value1) : throw new ArgumentException();
        public DateTime? nDateTimeValue2 => ((EnumDataType == EnumDataType.日付) && rangeflg) ? CNDate(value2) : throw new ArgumentException();
        public TimeSpan? nTimeSpanValue1 => (EnumDataType == EnumDataType.時間) ? CNTimeSpan(value1) : throw new ArgumentException();
        public TimeSpan? nTimeSpanValue2 => ((EnumDataType == EnumDataType.時間) && rangeflg) ? CNTimeSpan(value2) : throw new ArgumentException();
        public bool? nBoolValue1 => (EnumDataType == EnumDataType.フラグ) ? CNBool(value1) : throw new ArgumentException();
        public bool? nBoolValue2 => ((EnumDataType == EnumDataType.フラグ) && rangeflg) ? CNBool(value2) : throw new ArgumentException();

        public tm_afctrlDtoEx(tm_afctrlDto dto)
        {
            ctrlmaincd = dto.ctrlmaincd;         //コントロールメインコード
            ctrlsubcd = dto.ctrlsubcd;          //コントロールサブコード
            ctrlcd = dto.ctrlcd;                //コントロールコード
            itemnm = dto.itemnm;                //項目名称
            datatype = dto.datatype;            //データ型
            rangeflg = dto.rangeflg;            //範囲フラグ
            value1 = dto.value1;                //値１
            value2 = dto.value2;                //値２
            EnumDataType = dto.datatype;
        }
    }
}