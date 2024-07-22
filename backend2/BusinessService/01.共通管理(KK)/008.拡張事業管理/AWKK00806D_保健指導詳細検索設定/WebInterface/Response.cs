// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 保健指導詳細検索設定
//             レスポンスインターフェース
// 作成日　　: 2024.01.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00806D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<AWKK00802D.SearchVM> kekkalist1 { get; set; }       //右部分(独自)
    }
}