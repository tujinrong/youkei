// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.ファイルIF情報ダイアログ画面
//             レスポンスインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00602D
{
    /// <summary>
    /// 初期化処理(取込設定：取込ファイルIF情報ダイアログ画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> datatypeList { get; set; }     //【データ型】ドロップダウンリスト
        
        public List<DaSelectorModel> fmtcheckList { get; set; }     //【フォーマットチェック】ドロップダウンリスト

        public List<DaSelectorModel> fmtchangeList { get; set; }    //【フォーマット変換】ドロップダウンリスト
    }

    /// <summary>
    /// 初期化処理(フォーマット)
    /// </summary>
    public class InitFormatListResponse : DaResponseBase
    {
        public List<DaSelectorModel> formatList { get; set; }      //【フォーマット】ドロップダウンリスト
    }
}