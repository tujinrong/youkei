// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             妊娠届出アンケート（固定）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsninsintodokedeanketoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnsninsintodokedeanketo";
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
