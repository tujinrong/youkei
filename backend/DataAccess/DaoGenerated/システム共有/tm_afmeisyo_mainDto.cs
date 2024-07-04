// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             名称メインマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmeisyo_mainDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afmeisyo_main";
		public string nmmaincd { get; set; }                      //名称メインコード
		public int nmsubcd { get; set; }                          //名称サブコード
		public string nmsubcdnm { get; set; }                     //名称サブコード名称
		public string? kananm { get; set; }                       //カナ名称
		public string? shortnm { get; set; }                      //略称
		public int? keta { get; set; }                            //桁数
		public string? biko { get; set; }                         //備考
    }
}
