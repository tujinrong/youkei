// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メニュー並び順設定
//             ViewModel定義
// 作成日　　: 2023.12.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00804D
{
    /// <summary>
    /// 並び順設定行モデル(表示用)
    /// </summary>
    public class SearchVM : SaveVM
    {
        public string hyojinm { get; set; } //機能表示名称
    }
    /// <summary>
    /// 並び順設定行モデル(保存用)
    /// </summary>
    public class SaveVM
    {
        public string kinoid { get; set; }  //機能ID
    }
}