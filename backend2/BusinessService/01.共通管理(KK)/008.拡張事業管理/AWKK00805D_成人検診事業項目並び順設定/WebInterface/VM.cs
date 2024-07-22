// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人検診事業項目並び順設定
//             ViewModel定義
// 作成日　　: 2024.01.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00805D
{
    /// <summary>
    /// 並び順設定行モデル(表示用)
    /// </summary>
    public class SearchVM : SaveVM
    {
        public string itemnm { get; set; } //項目名
    }
    /// <summary>
    /// 並び順設定行モデル(保存用)
    /// </summary>
    public class SaveVM
    {
        public string itemcd { get; set; }  //項目コード
    }
}