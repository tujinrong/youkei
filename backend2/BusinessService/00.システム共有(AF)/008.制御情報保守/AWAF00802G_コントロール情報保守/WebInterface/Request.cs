// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: コントロール情報保守
//             リクエストインターフェース
// 作成日　　: 2023.07.18
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00802G
{
    /// <summary>
    /// 初期化(サブコード)
    /// </summary>
    public class InitSubCodeRequest : AWAF00801G.InitMainCodeRequest
    {
        public string ctrlmaincd { get; set; } //コントロールメインコード
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string ctrlmaincd { get; set; } //コントロールメインコード
        public string ctrlsubcd { get; set; }  //コントロールサブコード
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : SearchRequest
    {
        public List<SaveVM> savelist { get; set; } //コントロールデータリスト
    }
}