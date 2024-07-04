// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             CSV出力パターンサブテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eucsv_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_eucsv_sub";
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int outputptnno { get; set; }                      //出力パターン番号
		public string reportitemid { get; set; }                  //帳票項目ID
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
