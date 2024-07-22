// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人住民税税額控除情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00105D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }          //履歴No.
        public int kazeinendo { get; set; }         //課税年度
        public int kojorirekino { get; set; }       //税額控除情報履歴番号
        public string upddttm { get; set; }         //更新日時
        public string saisinflg { get; set; }       //最新フラグ
    }
}