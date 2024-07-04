// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             事業予定コーステーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyoteicourseDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkjigyoyoteicourse";
		public int courseno { get; set; }                         //コース番号
		public string coursenm { get; set; }                      //コース名
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
