// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 成人健（検）診事業詳細検索設定
//             レスポンスインターフェース
// 作成日　　: 2024.01.15
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00802D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public AWKK00801G.KensinCommonHeaderVM headerinfo { get; set; } //検診画面ヘッダー情報
        public List<SearchVM> kekkalist1 { get; set; }                  //右部分(独自)
    }
}