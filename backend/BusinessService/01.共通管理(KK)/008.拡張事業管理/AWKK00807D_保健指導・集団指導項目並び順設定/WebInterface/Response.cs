// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導・集団指導項目並び順設定
//             レスポンスインターフェース
// 作成日　　: 2024.01.23
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00807D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public AWKK00801G.SidoCommonHeaderVM headerinfo { get; set; }   //指導項目一覧画面ヘッダー情報
        public List<AWKK00805D.SearchVM> kekkalist { get; set; }        //項目一覧
    }
}