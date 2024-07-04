// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             【個人住民税】個人住民税課税情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeikazeiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkojinzeikazei";
		public string atenano { get; set; }                       //宛名番号
		public int kazeinendo { get; set; }                       //課税年度
		public string? tosi_gyoseikucd { get; set; }              //指定都市_行政区等コード
		public string kazeikbn { get; set; }                      //課税非課税区分
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
