// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力履歴画面	
// 　　　　　  DB項目から画面項目に変換 
// 作成日　　: 2024.07.26
// 作成者　　: シュウ
// *******************************************************************
namespace BCC.Affect.Service.AWEU00305D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 出力履歴リストを取得
        /// </summary>
        public static List<RirekiVM> GetRirekiVMList(DaDbContext db, DataRowCollection rows)
        {
            var dataRows = rows.Cast<DataRow>().ToList();
            //rirekiseqリスト取得
            var rirekiseqList = dataRows.Select(r => r.CLng(nameof(tt_eurirekiDto.rirekiseq))).ToList();
            //EUC帳票出力履歴条件テーブル取得
            var rirekiseq2JyokensDict = db.tt_eurirekijyoken.SELECT.WHERE.ByKeyList(rirekiseqList).ORDER.By(nameof(tt_eurirekijyokenDto.jyokenseq)).GetDtoList()
                .GroupBy(x => x.rirekiseq)
                .ToDictionary(group => group.Key, group => group.ToList());
            //データ処理
            return dataRows.Select(x => GetRirekiVM(x, rirekiseq2JyokensDict)).ToList();
        }

        /// <summary>
        /// 出力履歴を取得
        /// </summary>
        private static RirekiVM GetRirekiVM(DataRow row, IReadOnlyDictionary<long, List<tt_eurirekijyokenDto>> rirekiseq2JyokensDict)
        {
            var vm = new RirekiVM();

            var jyotai = Enum.TryParse<Enum履歴出力状態区分>(row.Wrap(nameof(tt_eurirekiDto.jyotaikbn)), out var j) ? j.ToString() : string.Empty;
            var outputkbn = Enum.TryParse<Enum出力方式>(row.Wrap(nameof(RirekiVM.outputkbn)), out var o) ? o.ToString() : string.Empty;
            var rirekiseq = row.CLng(nameof(tt_eurirekiDto.rirekiseq));
            var rirekijyokenDtl = rirekiseq2JyokensDict.GetValueOrDefault(rirekiseq, new List<tt_eurirekijyokenDto>());
            
            vm.rirekiseq = rirekiseq;                                                                                //履歴シーケンス
            vm.regdttm = row.CDate(nameof(RirekiVM.regdttm));                                                        //登録日時
            vm.regusernm = row.Wrap(nameof(RirekiVM.regusernm));                                                     //登録ユーザー名
            vm.jyotai = jyotai;                                                                                      //状態区分
            vm.syoridttmf = row.CDate(nameof(RirekiVM.syoridttmf));                                                  //実行日時
            vm.outputkbn = outputkbn;                                                                                //出力方式
            vm.num = row.CNInt(nameof(RirekiVM.num));                                                                //結果件数
            vm.jyoken = row.Wrap(nameof(RirekiVM.jyoken));                                                           //検索条件
            vm.memo = row.Wrap(nameof(RirekiVM.memo));                                                               //検索条件メモ
            vm.fileflg = row.CBool(nameof(RirekiVM.fileflg));                                                        //ファイルフラグ
            vm.jyokenlist = rirekijyokenDtl.Select(x => new JyokenVM(x.jyokenseq, x.jyokenlabel, x.value)).ToList(); //検索条件リスト
            return vm;
        }
    }
}