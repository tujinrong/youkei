// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             メッセージコントロールマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmsgctrlDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afmsgctrl";
		public string ctrlmsgid { get; set; }                     //コントロールメッセージID
		public string ctrlmsgnm { get; set; }                     //コントロールメッセージ名
		public EnumMsgCtrlKbn msgkbn { get; set; }                //メッセージ区分
		public string errormsgid { get; set; }                    //エラーメッセージID
		public string alertmsgid { get; set; }                    //アラートメッセージID
		public string biko { get; set; }                          //備考
    }
}
