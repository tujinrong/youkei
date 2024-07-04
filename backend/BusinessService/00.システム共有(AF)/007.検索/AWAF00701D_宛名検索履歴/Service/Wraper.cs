// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 宛名検索履歴
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.03.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00701D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(row => GetVM(db, row)).ToList();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new SearchVM();
            vm.atenano = row.Wrap(nameof(SearchVM.atenano));                //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));          //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));    //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                      //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                             //生年月日
            return vm;
        }
    }
}