// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 使用履歴
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.02.15
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00202S
{
    public class Wraper : CmWraperBase
    {
        //ユーザー管理
        private const string AWAF00901G = "AWAF00901G";
        private const string AWAF00901G_NAME = "ユーザー管理";

        /// <summary>
        /// 使用履歴リスト
        /// </summary>
        public static List<SiyorirekiVM> GetVMList(DataRowCollection rows)
        {
            List<SiyorirekiVM> list = new List<SiyorirekiVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(row));
            }
            return list;
        }

        /// <summary>
        /// 使用履歴
        /// </summary>
        private static SiyorirekiVM GetVM(DataRow row)
        {
            var vm = new SiyorirekiVM();
            vm.kinoid = row.Wrap(nameof(SiyorirekiVM.kinoid));     //機能ID
            vm.hyojinm = row.Wrap(nameof(SiyorirekiVM.hyojinm));         //表示名称
            if (vm.kinoid == AWAF00901G)
            {
                vm.hyojinm = AWAF00901G_NAME;
            }
            return vm;
        }
    }
}