// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住登外者情報履歴照会
//             レスポンスインターフェース
// 作成日　　: 2023.11.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00112D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //結果リスト(履歴一覧)
    }
}