// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メニュー並び順設定
//             レスポンスインターフェース
// 作成日　　: 2023.12.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00804D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }  //画面一覧
        public string oyamenunm { get; set; }       //親メニュー名
    }
}