// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             母子健康手帳交付（固定）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnsbosikenkotetyokofuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnsbosikenkotetyokofu";
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public int torokunorenban { get; set; }                   //登録番号連番
		public string bositetyokofubi { get; set; }               //母子健康手帳交付日
		public string bositetyokofuno { get; set; }               //母子健康手帳交付番号
		public int bositetyokofunoedano { get; set; }             //母子健康手帳交付番号枝番
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
