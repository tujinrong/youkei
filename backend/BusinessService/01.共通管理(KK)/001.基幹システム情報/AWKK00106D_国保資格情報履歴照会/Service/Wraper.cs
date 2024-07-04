// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 国保資格情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00106D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 国保情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afkokuho_rekiDto> dtl)
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
        /// 国保情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afkokuho_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                       //履歴No.
            vm.hihokensyarirekino = dto.hihokensyarirekino;                                 //被保険者履歴番号
            vm.kokuho_kigono = dto.kokuho_kigono;                                           //国保記号番号
            vm.kokuho_edano = dto.kokuho_edano;                                             //枝番
            vm.kokuho_sikakusyutokuymd = FormatWaKjYMD(CDate(dto.kokuho_sikakusyutokuymd)); //国保資格取得年月日
            vm.kokuho_sikakusosituymd = FormatWaKjYMD(CNDate(dto.kokuho_sikakusosituymd));  //国保資格喪失年月日
            //国保資格取得事由
            vm.kokuho_sikakusyutokujiyu = DaNameService.GetName(db, EnumNmKbn.国保資格取得事由_集約システム, dto.kokuho_sikakusyutokujiyu);
            //国保資格喪失事由
            vm.kokuho_sikakusositujiyu = DaNameService.GetName(db, EnumNmKbn.国保資格喪失事由_集約システム, CStr(dto.kokuho_sikakusositujiyu));
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                      //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                     //最新フラグ

            return vm;
        }
    }
}