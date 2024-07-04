// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             出生時状況（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnysyussyojijokyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnysyussyojijokyo";
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public int torokunorenban { get; set; }                   //登録番号連番
		public string hahaoyaatenano { get; set; }                //母親_宛名番号
		public string titioyaatenano { get; set; }                //父親_宛名番号
		public string hogosyaatenano { get; set; }                //保護者_宛名番号
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
