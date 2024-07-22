// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUC帳票権限
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eureportkegenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eureportkegen";
		public int reportid { get; set; }                         //帳票ID
		public int seq { get; set; }                              //権限Seq
		public string kengenkbn { get; set; }                     //権限区分
		public string unit { get; set; }                          //ユーザー・グループコード
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
