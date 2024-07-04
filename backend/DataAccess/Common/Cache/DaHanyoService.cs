// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 汎用マスタ
//
// 作成日　　: 2023.07.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public static class DaHanyoService
    {
        /// <summary>
        /// 汎用データ(1件)
        /// </summary>
        public static tm_afhanyoDto GetHanyoDto(DaDbContext db, EnumHanyoKbn kbn, string cd)
        {
            var maincd = ((long)kbn / DaNameService.MAINCODE_DIGIT).ToString();
            var subcd = (int)((long)kbn % DaNameService.MAINCODE_DIGIT);
            return db.tm_afhanyo.GetDtoByKey(maincd, subcd, cd);
        }
        /// <summary>
        /// 汎用データ(1件)
        /// </summary>
        public static tm_afhanyoDto GetHanyoDto(DaDbContext db, string maincd, int subcd, string cd)
        {
            return db.tm_afhanyo.GetDtoByKey(maincd, subcd, cd);
        }
        /// <summary>
        /// 汎用データ一覧
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoDtl(DaDbContext db, string maincd, int subcd)
        {
            return db.tm_afhanyo.SELECT.WHERE.ByKey(maincd, subcd).GetDtoList().OrderBy(e => e.orderseq == null).ThenBy(e => e.orderseq).ThenBy(e => e.hanyocd).ToList();
        }
        /// <summary>
        /// 汎用データ一覧
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoDtl(DaDbContext db, EnumHanyoKbn kbn)
        {
            var maincd = ((long)kbn / DaNameService.MAINCODE_DIGIT).ToString();
            var subcd = (int)((long)kbn % DaNameService.MAINCODE_DIGIT);
            return GetHanyoDtl(db, maincd, CInt(subcd));
        }
        /// <summary>
        /// 汎用データ一覧
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoDtl(DaDbContext db, string keycd)
        {
            var keys = keycd.Split(DaStrPool.C_DASHED);
            return GetHanyoDtl(db, keys[0], CInt(keys[1]));
        }
        /// <summary>
        /// 汎用データ一覧
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoDtl(List<tm_afhanyoDto> dtl, EnumHanyoKbn kbn)
        {
            var maincd = ((long)kbn / 100000000L).ToString();
            var subcd = (int)((long)kbn % 100000000L);
            return dtl.Where(e => e.hanyomaincd == maincd && e.hanyosubcd == subcd).ToList();
        }
        /// <summary>
        /// 汎用データ一覧(使用停止を除く)
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoNoDelDtl(DaDbContext db, string maincd, int subcd)
        {
            return GetHanyoDtl(db, maincd, subcd).Where(e => !e.stopflg).ToList();
        }
        /// <summary>
        /// 汎用データ一覧(使用停止を除く)
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoNoDelDtl(DaDbContext db, EnumHanyoKbn kbn)
        {
            return GetHanyoDtl(db, kbn).Where(e => !e.stopflg).ToList();
        }
        /// <summary>
        /// 汎用データ一覧(使用停止を除く)
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoNoDelDtl(DaDbContext db, string keycd)
        {
            return GetHanyoDtl(db, keycd).Where(e => !e.stopflg).ToList();
        }
        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, EnumHanyoKbn kbn1, Enum名称区分 kbn2, bool hasStopFlg)
        {
            return GetSelectorList(hasStopFlg ? GetHanyoDtl(db, kbn1) : GetHanyoNoDelDtl(db, kbn1), kbn2);
        }
        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, string keycd, Enum名称区分 kbn, bool hasStopFlg)
        {
            return GetSelectorList(hasStopFlg ? GetHanyoDtl(db, keycd) : GetHanyoNoDelDtl(db, keycd), kbn);
        }
        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(DaDbContext db, string hanyomaincd, int hanyosubcd, Enum名称区分 kbn, bool hasStopFlg = false)
        {
            return GetSelectorList(hasStopFlg ? GetHanyoDtl(db, hanyomaincd, hanyosubcd) : GetHanyoNoDelDtl(db, hanyomaincd, hanyosubcd), kbn);
        }

        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(DaDbContext db, EnumHanyoKbn kbn1, Enum名称区分 kbn2, string cd)
        {
            var CdNm = GetCdNm(db, kbn1, kbn2, cd);
            if (!string.IsNullOrEmpty(CdNm))
            {
                return CdNm.Split(DaConst.SELECTOR_DELIMITER)[1].ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(List<tm_afhanyoDto> dtl, Enum名称区分 kbn, string cd)
        {
            var CdNm = GetCdNm(dtl, kbn, cd);
            if (!string.IsNullOrEmpty(CdNm))
            {
                return CdNm.Split(DaConst.SELECTOR_DELIMITER)[1].ToString();
            }
            return string.Empty;
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(List<tm_afhanyoDto> dtl, EnumHanyoKbn kbn1, Enum名称区分 kbn2, string cd)
        {
            var maincd = ((long)kbn1 / 100000000L).ToString();
            var subcd = (int)((long)kbn1 % 100000000L);
            return GetName(dtl, maincd, subcd, kbn2, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetName(List<tm_afhanyoDto> dtl, string maincd, int subcd, Enum名称区分 kbn, string cd)
        {
            var dtl2 = dtl.Where(e => e.hanyomaincd == maincd && e.hanyosubcd == subcd).ToList();
            return GetName(dtl2, kbn, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(DaDbContext db, EnumHanyoKbn kbn1, Enum名称区分 kbn2, string cd)
        {
            var maincd = ((long)kbn1 / 100000000L).ToString();
            var subcd = (int)((long)kbn1 % 100000000L);
            return GetCdNm(db, maincd, subcd, kbn2, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(DaDbContext db, string keycd, Enum名称区分 kbn, string cd)
        {
            var keys = keycd.Split(DaStrPool.C_DASHED);
            return GetCdNm(db, keys[0], CInt(keys[1]), kbn, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(DaDbContext db, string maincd, int subcd, Enum名称区分 kbn, string cd)
        {
            var dtl = GetHanyoDtl(db, maincd, subcd);
            return GetCdNm(dtl, kbn, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(List<tm_afhanyoDto> dtl, EnumHanyoKbn kbn1, Enum名称区分 kbn2, string cd)
        {
            var maincd = ((long)kbn1 / 100000000L).ToString();
            var subcd = (int)((long)kbn1 % 100000000L);
            return GetCdNm(dtl, maincd, subcd, kbn2, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(List<tm_afhanyoDto> dtl, string keycd, Enum名称区分 kbn, string cd)
        {
            var keys = keycd.Split(DaStrPool.C_DASHED);
            return GetCdNm(dtl, keys[0], CInt(keys[1]), kbn, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(List<tm_afhanyoDto> dtl, string maincd, int subcd, Enum名称区分 kbn, string cd)
        {
            var lst = dtl.Where(x => x.hanyomaincd == maincd && x.hanyosubcd == subcd).ToList();
            return GetCdNm(lst, kbn, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        public static string GetCdNm(List<tm_afhanyoDto> dtl, Enum名称区分 kbn, string cd)
        {
            if (string.IsNullOrEmpty(cd)) return string.Empty;
            var dto = dtl.Find(x => x.hanyocd == cd);
            if (dto == null) throw new Exception("汎用データ error");
            switch (kbn)
            {
                case Enum名称区分.名称:
                    return $"{cd}{DaConst.SELECTOR_DELIMITER}{dto.nm}";
                case Enum名称区分.カナ:
                    return $"{cd}{DaConst.SELECTOR_DELIMITER}{dto.kananm}";
                case Enum名称区分.略称:
                    return $"{cd}{DaConst.SELECTOR_DELIMITER}{dto.shortnm}";
                default:
                    throw new Exception("Enum名称区分 error");
            }
        }
        /// <summary>
        /// 名称区分選択
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(List<tm_afhanyoDto> dtl, Enum名称区分 kbn)
        {
            switch (kbn)
            {
                case Enum名称区分.名称:
                    return dtl.Select(d => new DaSelectorModel(d.hanyocd, d.nm)).ToList();
                case Enum名称区分.カナ:
                    return dtl.Select(d => new DaSelectorModel(d.hanyocd, d.kananm)).ToList();
                case Enum名称区分.略称:
                    return dtl.Select(d => new DaSelectorModel(d.hanyocd, d.shortnm)).ToList();
                default:
                    throw new Exception("Enum名称区分 error");
            }
        }
    }
}