// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             CSV出力パターンテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eucsvDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_eucsv";
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int outputptnno { get; set; }                      //出力パターン番号
		public string outputptnnm { get; set; }                   //出力パターン名
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
