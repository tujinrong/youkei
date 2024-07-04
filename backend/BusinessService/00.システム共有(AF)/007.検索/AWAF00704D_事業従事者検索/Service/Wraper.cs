// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業従事者検索
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.20
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00704D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 事業従事者（担当者）情報一覧
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            List<SearchVM> list = new List<SearchVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 事業従事者（担当者）情報(1件)
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new SearchVM();
            vm.staffid = row.Wrap(nameof(SearchVM.staffid));                            //事業従事者ID
            vm.staffsimei = row.Wrap(nameof(SearchVM.staffsimei));                      //事業従事者氏名
            vm.kanastaffsimei = row.Wrap(nameof(SearchVM.kanastaffsimei));              //事業従事者カナ氏名
            var syokusyu = row.Wrap(nameof(tm_afstaffDto.syokusyu));
            vm.syokusyunm = DaNameService.GetName(db, EnumNmKbn.職種, syokusyu);        //職種
            var katudokbn = row.Wrap(nameof(tm_afstaffDto.katudokbn));
            vm.katudokbnnm = DaNameService.GetName(db, EnumNmKbn.活動区分, katudokbn);  //活動区分

            return vm;
        }
    }
}
