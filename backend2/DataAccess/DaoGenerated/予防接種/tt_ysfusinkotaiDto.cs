// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             風しん抗体検査テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_ysfusinkotaiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_ysfusinkotai";
		public string atenano { get; set; }                       //宛名番号
		public string sessyukenno { get; set; }                   //接種券番号
		public string jissiymd { get; set; }                      //実施日
		public string? jissikikancd { get; set; }                 //実施機関コード
		public string? jissikikannm { get; set; }                 //実施機関名
		public string? isicd { get; set; }                        //医師コード
		public string? isinm { get; set; }                        //医師名
		public string sessyuhanteicd { get; set; }                //接種判定コード
		public string? kotaikensahohocd { get; set; }             //抗体検査方法コード
		public string? kotaika { get; set; }                      //抗体価
		public string? tanicd { get; set; }                       //単位コード
		public string? kotaikensanocd { get; set; }               //抗体検査番号コード
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
