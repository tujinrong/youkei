// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人番号情報履歴
//             ビューモデル定義
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00113D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }          //履歴No.
        public int rirekino { get; set; }           //履歴番号
        public string personalno { get; set; }      //個人番号（AES復号化）
        public string upddttm { get; set; }         //更新日時
        public string saisin { get; set; }          //最新（名称）
    }
}