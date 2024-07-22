// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             会場情報マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkaijoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afkaijo";
		public string kaijocd { get; set; }                       //会場コード
		public string kaijonm { get; set; }                       //会場名
		public string kanakaijonm { get; set; }                   //会場名（カナ）
		public string adrs { get; set; }                          //住所
		public string katagaki { get; set; }                      //方書
		public string kaijorenrakusaki { get; set; }              //会場連絡先
		public string? gyoseikucd { get; set; }                   //行政区
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
