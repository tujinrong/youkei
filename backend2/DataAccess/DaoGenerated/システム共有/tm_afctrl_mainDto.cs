// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             コントロールメインマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afctrl_mainDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afctrl_main";
		public string ctrlmaincd { get; set; }                    //コントロールメインコード
		public int ctrlsubcd { get; set; }                        //コントロールサブコード
		public string ctrlsubcdnm { get; set; }                   //コントロールサブコード名称
		public string? kananm { get; set; }                       //カナ名称
		public string? shortnm { get; set; }                      //略称
		public string? biko { get; set; }                         //備考
    }
}
