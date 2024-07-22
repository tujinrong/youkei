// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人検診事業項目並び順設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.01.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00805D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 項目一覧取得
        /// </summary>
        public static List<SearchVM> GetVMList(List<tm_shfreeitemDto> dtl)
        {
            var list = new List<SearchVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(dto));
            }

            return list;
        }

        /// <summary>
        /// 項目明細(1行)
        /// </summary>
        private static SearchVM GetVM(tm_shfreeitemDto dto)
        {
            var vm = new SearchVM();
            vm.itemcd = dto.itemcd; //項目コード
            vm.itemnm = dto.itemnm; //項目名

            return vm;
        }
    }
}