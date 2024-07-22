// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人住民税税額控除情報履歴照会
//             レスポンスインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00105D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //結果リスト(履歴一覧)
    }
}