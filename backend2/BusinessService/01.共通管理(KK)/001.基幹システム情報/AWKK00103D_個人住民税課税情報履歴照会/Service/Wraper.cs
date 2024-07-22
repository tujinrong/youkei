// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人住民税課税情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00103D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 課税情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afkojinzeikazei_rekiDto> dtl)
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
        /// 課税情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afkojinzeikazei_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                                                       //履歴No.
            vm.kazeinendo = dto.kazeinendo;                                                                                 //課税年度
            vm.kazeirirekino = dto.kazeirirekino;                                                                           //課税情報履歴番号
            vm.kazeikbn = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, dto.kazeikbn);                                //課税非課税区分
            vm.tosi_gyoseikunm = DaNameService.GetName(db, EnumNmKbn.指定都市_行政区等コード, CStr(dto.tosi_gyoseikucd));   //指定都市_行政区等(名称)
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                      //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                     //最新フラグ

            return vm;
        }
    }
}