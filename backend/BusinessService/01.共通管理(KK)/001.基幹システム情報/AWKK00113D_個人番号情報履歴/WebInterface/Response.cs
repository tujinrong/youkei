// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人番号情報履歴
//             レスポンスインターフェース
// 作成日　　: 2023.11.09
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00113D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //結果リスト(履歴一覧)
    }
}