// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【生活保護】生活保護受給情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afseihoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afseiho";
		public string atenano { get; set; }                       //宛名番号
		public string seihoymdf { get; set; }                     //生活保護開始年月日
		public string teisiymd { get; set; }                      //停止年月日
		public string? teisikaijoymd { get; set; }                //停止解除年月日
		public string? tanheikyukbn { get; set; }                 //単併給区分
		public bool? seikatufujoflg { get; set; }                 //生活扶助フラグ
		public bool? jutakufujoflg { get; set; }                  //住宅扶助フラグ
		public bool? kyoikufujoflg { get; set; }                  //教育扶助フラグ
		public bool? iryofujoflg { get; set; }                    //医療扶助フラグ
		public bool? syussanfujoflg { get; set; }                 //出産扶助フラグ
		public bool? seigyofujoflg { get; set; }                  //生業扶助フラグ
		public bool? sosaifujoflg { get; set; }                   //葬祭扶助フラグ
		public string? haisiymd { get; set; }                     //廃止年月日
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
