// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導・集団指導項目並び順設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.01.23
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00805D;

namespace BCC.Affect.Service.AWKK00807D
{
    public class Wraper : CmWraperBase
    {

        /// <summary>
        /// 項目一覧取得
        /// </summary>
        public static List<SearchVM> GetVMList(List<tm_kksidofreeitemDto> dtl)
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
        private static SearchVM GetVM(tm_kksidofreeitemDto dto)
        {
            var vm = new SearchVM();
            vm.itemcd = dto.itemcd; //項目コード
            vm.itemnm = dto.itemnm; //項目名

            return vm;
        }
    }
}