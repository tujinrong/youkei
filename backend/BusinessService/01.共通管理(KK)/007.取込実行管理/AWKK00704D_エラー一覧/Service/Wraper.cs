// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.エラー一覧
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00704D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 取込データエラー情報リストを取得する
        /// </summary>
        public static List<KimpErrRowVM> GetKimpErrRowVMList(DataTable dt)
        {
            List<KimpErrRowVM> vmList = new List<KimpErrRowVM>();
            int no = 0;
            foreach (DataRow row in dt.Rows)
            {
                no++;
                var vm = new KimpErrRowVM();
                vm.No = no;                                                             //画面連番
                vm.rowno = row.CInt(nameof(tt_kktorinyuryoku_errDto.rowno));            //行番号
                vm.atenano = row.Wrap(nameof(tt_kktorinyuryoku_errDto.atenano));        //宛名番号
                vm.shimei = row.Wrap(nameof(tt_kktorinyuryoku_errDto.simei));           //氏名
                vm.itemnm = row.Wrap(nameof(tt_kktorinyuryoku_misyoriitemDto.itemnm));  //項目名
                vm.val = row.Wrap(nameof(tt_kktorinyuryoku_misyoriitemDto.itemvalue));  //項目値
                vm.msg = row.Wrap(nameof(tt_kktorinyuryoku_errDto.msg));                //メッセージ
                vmList.Add(vm);
            }

            return vmList;
        }
    }
}
