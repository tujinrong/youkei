// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             新生児聴覚検査結果（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnytyokakukensakekkaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnytyokakukensakekka";
		public string atenano { get; set; }                       //宛名番号
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
