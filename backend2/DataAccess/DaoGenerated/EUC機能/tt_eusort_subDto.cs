// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             出力順パターンサブテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eusort_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_eusort_sub";
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int sortptnno { get; set; }                        //出力順パターン番号
		public string reportitemid { get; set; }                  //帳票項目ID
		public bool descflg { get; set; }                         //降順フラグ
		public bool pageflg { get; set; }                         //改ページフラグ
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
