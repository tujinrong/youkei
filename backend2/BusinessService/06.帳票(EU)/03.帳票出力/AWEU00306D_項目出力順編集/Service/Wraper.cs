// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目出力順編集
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00306D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 出力順パターンサブリスト取得
        /// </summary>
        public static List<SortSubVM> GetSortSubVMList(IEnumerable<tt_eusort_subDto> sortSubDtl)
        {
            return sortSubDtl.Select(GetSortSubVM).ToList();
        }

        /// <summary>
        /// 出力順パターンサブ取得
        /// </summary>
        private static SortSubVM GetSortSubVM(tt_eusort_subDto dto)
        {
            var vm = new SortSubVM();
            vm.reportitemid = dto.reportitemid;     //帳票項目ID
            vm.descflg = dto.descflg;               //降順フラグ
            vm.pageflg = dto.pageflg;               //改ページフラグ
            return vm;
        }
    }
}