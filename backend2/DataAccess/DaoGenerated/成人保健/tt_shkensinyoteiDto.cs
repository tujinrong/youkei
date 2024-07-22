// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             健（検）診予定テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyoteiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shkensinyotei";
		public int nendo { get; set; }                            //年度
		public int nitteino { get; set; }                         //日程番号
		public string jigyocd { get; set; }                       //成人健（検）診予約日程事業コード
		public string yoteiymd { get; set; }                      //実施予定日
		public string tmf { get; set; }                           //開始時間
		public string? tmt { get; set; }                          //終了時間
		public string kaijocd { get; set; }                       //会場コード
		public string? kikancd { get; set; }                      //医療機関コード
		public int teiin { get; set; }                            //定員
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
