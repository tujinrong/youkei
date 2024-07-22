// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             名称マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmeisyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afmeisyo";
		public string nmmaincd { get; set; }                      //名称メインコード
		public int nmsubcd { get; set; }                          //名称サブコード
		public string nmcd { get; set; }                          //名称コード
		public string nm { get; set; }                            //名称
		public string? kananm { get; set; }                       //カナ名称
		public string? shortnm { get; set; }                      //略称
		public string? biko { get; set; }                         //備考
		public string? hanyokbn1 { get; set; }                    //汎用区分1
		public string? hanyokbn2 { get; set; }                    //汎用区分2
		public string? hanyokbn3 { get; set; }                    //汎用区分3
    }
}
