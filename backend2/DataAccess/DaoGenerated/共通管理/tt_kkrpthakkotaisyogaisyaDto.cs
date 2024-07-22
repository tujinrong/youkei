// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             帳票発行対象外者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkrpthakkotaisyogaisyaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkrpthakkotaisyogaisya";
		public string atenano { get; set; }                       //宛名番号
		public string rptgroupid { get; set; }                    //帳票グループID
		public string uketukeymd { get; set; }                    //受付日
		public string? taisyogairiyu { get; set; }                //対象外理由
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
