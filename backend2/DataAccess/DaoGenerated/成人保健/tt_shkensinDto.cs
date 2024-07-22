// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             成人保健一次検診結果（固定項目）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shkensin";
		public string jigyocd { get; set; }                       //検診種別
		public string atenano { get; set; }                       //宛名番号
		public int nendo { get; set; }                            //実施年度
		public int kensinkaisu { get; set; }                      //検診回数
		public string jissiymd { get; set; }                      //実施日
		public int? jissiage { get; set; }                        //実施年齢
		public string? kensahohocd { get; set; }                  //検査方法
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
