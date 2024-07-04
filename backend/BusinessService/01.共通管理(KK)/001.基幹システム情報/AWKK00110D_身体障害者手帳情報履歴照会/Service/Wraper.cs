// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 身体障害者手帳情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00110D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 障害情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afsyogaitetyo_rekiDto> dtl)
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
        /// 障害情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afsyogaitetyo_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                                                      //履歴No.
            vm.rirekino = dto.rirekino;                                                                                    //履歴番号
            vm.tetyono = CStr(dto.tetyono);                                                                                //手帳番号
            vm.syokaikofuymd = FormatWaKjYMD(CNDate(dto.syokaikofuymd));                                                   //初回交付日
            vm.henkanymd = FormatWaKjYMD(CNDate(dto.henkanymd));                                                           //返還日
            vm.syogaisyubetunm = DaNameService.GetName(db, EnumNmKbn.身体障害者手帳障害種別, CStr(dto.syogaisyubetucd));   //障害種別(名称)
            vm.sogotokyunm = DaNameService.GetName(db, EnumNmKbn.身体障害者手帳総合等級, CStr(dto.sogotokyucd));           //総合等級(名称)
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                     //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                    //最新フラグ

            return vm;
        }
    }
}