// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             集団指導参加者結果情報（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_sankasyakekkaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kksyudansido_sankasyakekka";
		public string gyomukbn { get; set; }                      //業務区分
		public int edano { get; set; }                            //枝番
		public string atenano { get; set; }                       //宛名番号
		public string? syukeikbn { get; set; }                    //地域保健集計区分
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
