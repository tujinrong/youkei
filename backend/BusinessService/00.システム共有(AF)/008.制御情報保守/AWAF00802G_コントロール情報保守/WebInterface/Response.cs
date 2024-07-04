// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コントロール情報保守
//             レスポンスインターフェース
// 作成日　　: 2023.07.18
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00802G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public string biko { get; set; }              //説明
        public List<SearchVM> kekkalist { get; set; } //コントロールデータリスト
    }
}