// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住登外者情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.09
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00112D
{ 
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 住民情報履歴一覧
        /// </summary>
        public List<RowVM> GetVMList(DaDbContext db, List<tt_afjutogaiDto> dtl)
        {
            var rirekinum = 0;
            var list = new List<RowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto, ++rirekinum));
            }
            return list;
        }
        /// <summary>
        /// 住民情報履歴(1行)
        /// </summary>
        private RowVM GetVM(DaDbContext db, tt_afjutogaiDto dto, int rirekinum)
        {

            //住民種別内容
            var juminbetunm = AWKK00111G.Wraper.MNm(db, dto.jutogaisyasyubetu, EnumNmKbn.住民種別);
            //住民状態内容
            var juminjotainm = AWKK00111G.Wraper.MNm(db, dto.jutogaisyajotai, EnumNmKbn.住民状態);
            //異動事由（名称）
            var idojiyu = AWKK00111G.Wraper.MNm(db, CStr(dto.idojiyu), EnumNmKbn.住登外者異動事由);

            var vm = new RowVM()
            {
                rirekinum = rirekinum,                                      //履歴No.
                rirekino = dto.rirekino,                                    //履歴番号
                name = dto.simei_yusen,                                     //氏名（氏名_優先）
                juminjotai = $"{CStr(juminbetunm)}{CStr(juminjotainm)}",    //住民区分（住民種別内容、住民状態内容）
                idoymd = dto.idoymd,                                        //異動年月日
                idojiyu = idojiyu,                                          //異動事由（名称）
                adrs = GetAdrs(dto),                                        //住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
                upddttm = FormatWaKjDttm(dto.upddttm),                      //更新日時
                saisin = FormatFlgStr(dto.saisinflg),                       //最新（名称）
            };

            return vm;
        }

        /// <summary>
        /// 住所取得
        /// </summary>
        private static string GetAdrs(tt_afjutogaiDto dto)
        {
            var adrs1 = CStr(dto.adrs_todofuken);                           //住所_都道府県
            var adrs2 = CStr(dto.adrs_sikunm);                              //住所_市区郡町村名
            var adrs3 = CStr(dto.adrs_tyoaza);                              //住所_町字
            var adrs4 = CStr(dto.adrs_bantihyoki);                          //住所_番地号表記
            var adrs5 = CStr(dto.adrs_katagaki);                            //住所_方書

            return $"{adrs1}{adrs2}{adrs3}{adrs4}{adrs5}";
        }
    }
}