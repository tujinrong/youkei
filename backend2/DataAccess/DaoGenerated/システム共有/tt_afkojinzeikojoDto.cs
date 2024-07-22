// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【個人住民税】個人住民税税額控除情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeikojoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkojinzeikojo";
		public string atenano { get; set; }                       //宛名番号
		public int kazeinendo { get; set; }                       //課税年度
		public string kojocd { get; set; }                        //税額・税額控除コード
		public string? tosi_gyoseikucd { get; set; }              //指定都市_行政区等コード
		public long kojokingaku { get; set; }                     //税額控除金額
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
