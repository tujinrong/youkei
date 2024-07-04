// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             実施報告書（日報）情報サブテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjissihokokusyo_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkjissihokokusyo_sub";
		public long hokokusyono { get; set; }                     //事業報告書番号
		public string staffid { get; set; }                       //事業従事者ID
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
