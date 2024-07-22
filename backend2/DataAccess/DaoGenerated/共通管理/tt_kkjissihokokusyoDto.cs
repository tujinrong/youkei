// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             実施報告書（日報）情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjissihokokusyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkjissihokokusyo";
		public long hokokusyono { get; set; }                     //事業報告書番号
		public string jigyocd { get; set; }                       //事業実施報告書（日報）事業コード
		public string jissiymd { get; set; }                      //実施日
		public string kaijocd { get; set; }                       //会場コード
		public string? timef { get; set; }                        //開始時間
		public string? timet { get; set; }                        //終了時間
		public int? syussekisya { get; set; }                     //出席者数
		public string? jissinaiyo { get; set; }                   //実施内容
		public string? haifusiryo { get; set; }                   //配布資料
		public string? baitai { get; set; }                       //媒体
		public int? mantotalnum { get; set; }                     //男性延べ人数
		public int? womantotalnum { get; set; }                   //女性延べ人数
		public int? fumeitotalnum { get; set; }                   //性別不明延べ人数
		public int? mannum { get; set; }                          //男性実人数
		public int? womannum { get; set; }                        //女性実人数
		public int? fumeinum { get; set; }                        //性別不明実人数
		public string? comment { get; set; }                      //コメント
		public string? hanseipoint { get; set; }                  //反省点
		public string? jigyomokuteki { get; set; }                //事業目的
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
