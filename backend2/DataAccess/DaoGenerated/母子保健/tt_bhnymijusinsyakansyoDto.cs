// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             未受診者勧奨（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnymijusinsyakansyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnymijusinsyakansyo";
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string mijusinhaakuymd { get; set; }               //未受診把握日
		public string mijusinjigyo { get; set; }                  //未受診事業
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
