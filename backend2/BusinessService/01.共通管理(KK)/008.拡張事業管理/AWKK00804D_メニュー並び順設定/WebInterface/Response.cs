// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メニュー並び順設定
//             レスポンスインターフェース
// 作成日　　: 2023.12.25
// 作成者　　: 
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