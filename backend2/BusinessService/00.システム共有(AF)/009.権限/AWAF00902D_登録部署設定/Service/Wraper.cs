// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 登録部署設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.08.28
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00902D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 汎用メインマスタ
        /// </summary>
        public static void SetHeader(SearchResponse res, tm_afhanyo_mainDto dto)
        {
            res.biko = dto.biko ?? string.Empty;    //備考
            res.keta = dto.keta;                    //桁数
            res.iflg = true;                        //INSERT可能フラグ
            res.uflg = true;                        //UPDATE可能フラグ
            res.dflg = false;                       //DELETE可能フラグ
        }

        /// <summary>
        /// 汎用マスタ
        /// </summary>
        public static List<HanyoVM> GetVMList(List<tm_afhanyoDto> dtl)
        {
            return dtl.Select(d =>
            {
                var vm = new HanyoVM();
                vm.hanyocd = d.hanyocd;                 //汎用コード
                vm.nm = d.nm;                           //名称
                vm.kananm = CStr(d.kananm);             //カナ名称
                vm.shortnm = CStr(d.shortnm);           //略称
                vm.biko = CStr(d.biko);                 //備考
                vm.hanyokbn1 = CStr(d.hanyokbn1);       //汎用区分1
                vm.hanyokbn2 = CStr(d.hanyokbn2);       //汎用区分2
                vm.hanyokbn3 = CStr(d.hanyokbn3);       //汎用区分3
                vm.stopflg = d.stopflg;                 //使用停止フラグ
                vm.upddttm = d.upddttm;                 //更新日時
                return vm;
            }).ToList();
        }

        /// <summary>
        /// 汎用サブコード取得
        /// </summary>
        public static string GetCdNm(Enum名称区分 kbn, tm_afhanyo_mainDto dto)
        {
            var nm = string.Empty;
            switch (kbn)
            {
                case Enum名称区分.名称:
                    nm = dto.hanyosubcdnm;
                    break;
                case Enum名称区分.カナ:
                    nm = dto.kananm;
                    break;
                case Enum名称区分.略称:
                    nm = dto.shortnm;
                    break;
                default:
                    throw new Exception("Enum名称区分 error");
            }

            return $"{dto.hanyosubcd}{DaConst.SELECTOR_DELIMITER}{nm}";
        }
    }
}