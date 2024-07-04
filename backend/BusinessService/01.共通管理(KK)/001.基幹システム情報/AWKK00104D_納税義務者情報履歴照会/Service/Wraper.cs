// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 納税義務者情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00104D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 納税情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afkojinzeigimusya_rekiDto> dtl, List<tm_afsikutyosonDto> dtl2)
        {
            var rirekinum = 0;
            var list = new List<RowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto, ++rirekinum, dtl2));
            }
            return list;
        }
        /// <summary>
        /// 納税情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afkojinzeigimusya_rekiDto dto, int rirekinum, List<tm_afsikutyosonDto> dtl)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                                                       //履歴No.
            vm.kojinrirekino = dto.kojinrirekino;                                                                           //個人履歴番号
            vm.kazeinendo = dto.kazeinendo;                                                                                 //課税年度
            vm.misinkokukbn = DaNameService.GetName(db, EnumNmKbn.未申告区分, dto.misinkokukbn);                            //未申告区分
            vm.takazeikbn = DaNameService.GetName(db, EnumNmKbn.他団体課税対象者区分, dto.takazeikbn);                      //他団体課税対象者区分
            //他団体課税対象者の課税先市区町村(名称)
            var dto2 = dtl.Find(e => e.sikucd == CStr(dto.takazeisikucd));
            if (dto2 != null)
            {
                vm.takazeisikunm = $"{dto2.todofukennm}{dto2.gunnm}{dto2.sikunm}{dto2.seireisikunm}";
            }
            vm.tosi_gyoseikunm = DaNameService.GetName(db, EnumNmKbn.指定都市_行政区等コード, CStr(dto.tosi_gyoseikucd));   //指定都市_行政区等(名称)
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                      //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                     //最新フラグ

            return vm;
        }
    }
}