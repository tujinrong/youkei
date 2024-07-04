// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 成人検診事業項目並び順設定
//             レスポンスインターフェース
// 作成日　　: 2024.01.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00805D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public AWKK00801G.KensinCommonHeaderVM headerinfo { get; set; }   //検診項目一覧画面ヘッダー情報
        public List<SearchVM> kekkalist1 { get; set; }                      //固定項目一覧(左)
        public List<SearchVM> kekkalist2 { get; set; }                      //フリー項目一覧(右)
    }
}