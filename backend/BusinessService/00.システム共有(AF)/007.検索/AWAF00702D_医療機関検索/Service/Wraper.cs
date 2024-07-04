// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 医療機関検索
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.03.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00702D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 医療機関一覧
        /// </summary>
        public static List<SearchVM> GetVMList(DataRowCollection rows)
        {
            List<SearchVM> list = new List<SearchVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(row));
            }
            return list;
        }

        /// <summary>
        /// 医療機関(1件)
        /// </summary>
        private static SearchVM GetVM(DataRow row)
        {
            var vm = new SearchVM();
            vm.kikancd = row.Wrap(nameof(SearchVM.kikancd));                                                    //医療機関コード（自治体独自）
            vm.hokenkikancd = row.Wrap(nameof(tm_afkikanDto.hokenkikancd));                                     //保険医療機関コード
            vm.kikannm = row.Wrap(nameof(SearchVM.kikannm));                                                    //医療機関名
            vm.kanakikannm = row.Wrap(nameof(SearchVM.kanakikannm));                                            //医療機関名カナ
            vm.adrsfull = $"{row.Wrap(nameof(tm_afkikanDto.adrs))}{row.Wrap(nameof(tm_afkikanDto.katagaki))}";  //住所
            return vm;
        }
    }
}