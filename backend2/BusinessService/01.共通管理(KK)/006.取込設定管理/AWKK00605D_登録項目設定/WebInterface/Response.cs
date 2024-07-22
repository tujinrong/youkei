// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.登録項目設定情報ダイアログ画面
//             レスポンスインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00605D
{
    /// <summary>
    /// 初期化処理(取込設定：登録項目設定情報ダイアログ画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        //ドロップダウンリストの初期化データ
        public List<DaSelectorModel> pageitemseqList { get; set; }  //【データ元画面項目ID】のドロップダウンリスト
        public List<DaSelectorModel> syorikbnList { get; set; }     //【処理区分】のドロップダウンリスト
    }
}