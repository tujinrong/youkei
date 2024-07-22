// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUC帳票コントロールマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eucontrolDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eucontrol";
		public int controlid { get; set; }                        //コントロールid
		public string controlnm { get; set; }                     //コントロール名
		public string controlurl { get; set; }                    //部品URL
		public string inputkbn { get; set; }                      //入力データタイプ
		public string controltype { get; set; }                   //コントロール種別
    }
}
