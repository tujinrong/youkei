// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             保健指導申込情報（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhokensido_mosikomiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkhokensido_mosikomi";
		public string hokensidokbn { get; set; }                  //保健指導区分
		public string gyomukbn { get; set; }                      //業務区分
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string jigyocd { get; set; }                       //その他日程事業・保健指導事業コード
		public string? yoteiymd { get; set; }                     //実施予定日
		public string? yoteitm { get; set; }                      //予定開始時間
		public string? kaijocd { get; set; }                      //会場コード
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
