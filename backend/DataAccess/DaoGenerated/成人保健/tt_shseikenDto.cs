// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             成人保健精密検査結果（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shseikenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shseiken";
		public string jigyocd { get; set; }                       //検診種別
		public string atenano { get; set; }                       //宛名番号
		public int nendo { get; set; }                            //実施年度
		public int kensinkaisu { get; set; }                      //検診回数
		public string? jissiymd { get; set; }                     //実施日
		public int? jissiage { get; set; }                        //実施年齢
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
