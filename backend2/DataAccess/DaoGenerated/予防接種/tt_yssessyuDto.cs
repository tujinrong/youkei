// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             予防接種テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_yssessyu";
		public string atenano { get; set; }                       //宛名番号
		public string sessyucd { get; set; }                      //接種種類コード
		public string kaisu { get; set; }                         //回数
		public int edano { get; set; }                            //枝番
		public string? sessyukenno { get; set; }                  //接種券番号
		public string jissikbn { get; set; }                      //実施区分
		public string sessyukbn { get; set; }                     //接種区分
		public string? jissiymd { get; set; }                     //実施日
		public string? hoteikbn { get; set; }                     //法定区分
		public string? jissikikancd { get; set; }                 //実施機関コード
		public string? jissikikannm { get; set; }                 //実施機関名
		public string? kaijocd { get; set; }                      //会場コード
		public string? kaijonm { get; set; }                      //会場名
		public string? isicd { get; set; }                        //医師コード
		public string? isinm { get; set; }                        //医師名
		public string? lotno { get; set; }                        //ロット番号
		public double? sessyuryo { get; set; }                    //接種量
		public string? vaccinemakercd { get; set; }               //ワクチンメーカーコード
		public string? vaccinenmcd { get; set; }                  //ワクチン名コード
		public string? tokubetunojijyo { get; set; }              //特別の事情
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
