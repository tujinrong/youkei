// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告情報照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.09.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWAF00607D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 警告情報一覧
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, List<tt_afsiensotitaisyosya_rekiDto> dtl)
        {
            var list = new List<SearchVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto));
            }
            return list;
        }

        /// <summary>
        /// 警告情報(1行)
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, tt_afsiensotitaisyosya_rekiDto dto)
        {
            var vm = new SearchVM();
            vm.rirekino = dto.rirekino;                                                             //履歴番号
            vm.siensotiymdf = FormatWaKjYMD(dto.siensotiymdf);                                      //支援措置開始年月日
            vm.siensotiymdt = FormatWaKjYMD(dto.siensotiymdt);                                      //支援措置終了年月日
            vm.siensotikbn = DaNameService.GetName(db, EnumNmKbn.支援措置区分, dto.siensotikbn);    //支援措置区分
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                              //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                             //最新フラグ

            return vm;
        }
    }
}