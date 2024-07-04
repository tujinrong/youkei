// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             出力順パターンテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eusortDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_eusort";
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int sortptnno { get; set; }                        //出力順パターン番号
		public string sortptnnm { get; set; }                     //出力順パターン名
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
