// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.エラー一覧(行のエラー明細）
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00703D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 取込データエラー情報リストを取得する
        /// </summary>
        public static List<KimpErrRowVM> GetKimpErrRowVMList(DataTable dt)
        {
            var vmList = new List<KimpErrRowVM>();
            foreach (DataRow row in dt.Rows)
            {
                var vm = new KimpErrRowVM();
                vm.itemnm = row.Wrap(nameof(tt_kktorinyuryoku_misyoriitemDto.itemnm)); //項目名
                vm.val = row.Wrap(nameof(tt_kktorinyuryoku_misyoriitemDto.itemvalue)); //項目値
                vm.msg = row.Wrap(nameof(tt_kktorinyuryoku_errDto.msg));               //メッセージ
                vmList.Add(vm);
            }

            return vmList;
        }
    }
}
