// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 名称マスタ
//
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using Microsoft.Extensions.Caching.Memory;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class DaNameService
    {
        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;
        public const long MAINCODE_DIGIT = 100000000L;

        /// <summary>
        /// キャシュークリア
        /// </summary>
        public static void ClearCache()
        {
            _cache?.Clear();
        }

        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, EnumNmKbn nmKbn, Enum名称区分 kbn)
            => DaSelectorService.GetSelectorList(db, kbn, Enumマスタ区分.名称マスタ, false, ((long)nmKbn).ToString());

        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, string maincd, int subcd, Enum名称区分 kbn)
            => DaSelectorService.GetSelectorList(db, kbn, Enumマスタ区分.名称マスタ, false, maincd, subcd.ToString());

        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(List<tm_afmeisyoDto> dtl, Enum名称区分 kbn)
        {
            switch (kbn)
            {
                case Enum名称区分.名称:
                    return dtl.Select(d => new DaSelectorModel(d.nmcd, d.nm)).ToList();
                case Enum名称区分.カナ:
                    return dtl.Select(d => new DaSelectorModel(d.nmcd, d.kananm)).ToList();
                case Enum名称区分.略称:
                    return dtl.Select(d => new DaSelectorModel(d.nmcd, d.shortnm)).ToList();
                default:
                    throw new Exception("Enum名称区分 error");
            }
        }

        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(DaDbContext db, EnumNmKbn nmKbn, Enum名称区分 kbn, string cd)
            => DaSelectorService.GetCdNm(db, cd, kbn, Enumマスタ区分.名称マスタ, ((long)nmKbn).ToString());

        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(DaDbContext db, EnumNmKbn nmKbn, string cd)
              => DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, ((long)nmKbn).ToString());

        /// <summary>
        /// カナ名称取得
        /// </summary>
        public static string GetKanaName(DaDbContext db, EnumNmKbn nmKbn, string cd)
              => DaSelectorService.GetName(db, cd, Enum名称区分.カナ, Enumマスタ区分.名称マスタ, ((long)nmKbn).ToString());

        /// <summary>
        /// 略称取得
        /// </summary>
        public static string GetShortName(DaDbContext db, EnumNmKbn nmKbn, string cd)
              => DaSelectorService.GetName(db, cd, Enum名称区分.略称, Enumマスタ区分.名称マスタ, ((long)nmKbn).ToString());

        /// <summary>
        /// 汎用区分1取得
        /// </summary>
        public static string GetKbn1(DaDbContext db, EnumNmKbn nmKbn, string nmCd)
        {
            var list = GetNameList(db, nmKbn);
            var row = list.Find(x => x.nmcd == nmCd);
            if (row == null) return string.Empty;
            return (row.hanyokbn1 != null) ? row.hanyokbn1 : string.Empty;
        }

        /// <summary>
        /// 汎用区分1取得
        /// </summary>
        public static string GetKbn1(DaDbContext db, string maincd, int subcd, string nmCd)
        {
            var list = GetNameList(db, maincd, subcd);
            var row = list.Find(x => x.nmcd == nmCd);
            if (row == null) return string.Empty;
            return (row.hanyokbn1 != null) ? row.hanyokbn1 : string.Empty;
        }

        /// <summary>
        /// 汎用区分2取得
        /// </summary>
        public static string GetKbn2(DaDbContext db, EnumNmKbn nmKbn, string nmCd)
        {
            var list = GetNameList(db, nmKbn);
            var row = list.Find(x => x.nmcd == nmCd);
            if (row == null) return string.Empty;
            return (row.hanyokbn2 != null) ? row.hanyokbn2 : string.Empty;
        }
        /// <summary>
        /// 汎用区分3取得
        /// </summary>
        public static string GetKbn3(DaDbContext db, EnumNmKbn nmKbn, string nmCd)
        {
            var list = GetNameList(db, nmKbn);
            var row = list.Find(x => x.nmcd == nmCd);
            if (row == null) return string.Empty;
            return (row.hanyokbn3 != null) ? row.hanyokbn3 : string.Empty;
        }

        /// <summary>
        /// 備考取得
        /// </summary>
        public static string GetBiko(DaDbContext db, EnumNmKbn nmKbn, string nmCd)
        {
            var list = GetNameList(db, nmKbn);
            var row = list.Find(x => x.nmcd == nmCd);
            if (row == null) return string.Empty;
            return (row.biko != null) ? row.biko : string.Empty;
        }

        /// <summary>
        /// 名称リスト取得
        /// </summary>
        public static List<tm_afmeisyoDto> GetNameList(DaDbContext db, EnumNmKbn nmKbn)
        {
            string maincd = ((long)nmKbn / DaNameService.MAINCODE_DIGIT).ToString();
            int subcd = (int)((long)nmKbn % DaNameService.MAINCODE_DIGIT);
            return GetNameList(db, maincd, subcd);
        }

        /// <summary>
        /// 名称区分取得
        /// </summary>
        public static EnumNmKbn GetNmKbn(string maincd, int subcd)
        {
            return (EnumNmKbn)(CInt(maincd) * MAINCODE_DIGIT + subcd);
        }

        /// <summary>
        /// 名称一覧の取得
        /// </summary>
        private static List<tm_afmeisyoDto> GetNameList(DaDbContext db, string maincd, int subcd)
        {
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }

            var key = $"{maincd}-{subcd}";
            List<tm_afmeisyoDto> data;
            if (!_cache.TryGetValue(key, out data!))
            {
                string sql = $"SELECT * FROM {tm_afmeisyoDto.TABLE_NAME} " +
                    $"WHERE {nameof(tm_afmeisyoDto.nmmaincd)}='{maincd}' AND {nameof(tm_afmeisyoDto.nmsubcd)}={subcd} " +
                    $"ORDER BY {nameof(tm_afmeisyoDto.nmmaincd)}, {nameof(tm_afmeisyoDto.nmsubcd)}";
                data = db.Session.Query<tm_afmeisyoDto>(sql);
                _cache.Set(key, data, TimeSpan.FromMinutes(CACHE_MINIUTE));
            }
            return data;
        }
    }
}