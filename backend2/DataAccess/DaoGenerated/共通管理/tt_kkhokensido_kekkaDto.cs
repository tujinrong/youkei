// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             保健指導結果情報（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhokensido_kekkaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkhokensido_kekka";
		public string hokensidokbn { get; set; }                  //保健指導区分
		public string gyomukbn { get; set; }                      //業務区分
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string jigyocd { get; set; }                       //その他日程事業・保健指導事業コード
		public string jissiymd { get; set; }                      //実施日
		public string tmf { get; set; }                           //開始時間
		public string? tmt { get; set; }                          //終了時間
		public string? kaijocd { get; set; }                      //会場コード
		public string syukeikbn { get; set; }                     //地域保健集計区分
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
