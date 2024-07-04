// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             帳票権限テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afauthreportDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afauthreport";
		public Enumロール区分 rolekbn { get; set; }               //ロール区分
		public string roleid { get; set; }                        //ロールID
		public string repgroupid { get; set; }                    //グループID
		public bool tutisyooutflg { get; set; }                   //通知書出力フラグ
		public bool pdfoutflg { get; set; }                       //PDF出力フラグ
		public bool exceloutflg { get; set; }                     //EXCEL出力フラグ
		public bool othersflg { get; set; }                       //その他出力フラグ
		public bool personalnoflg { get; set; }                   //個人番号利用フラグ
		public bool? keisyoflg { get; set; }                      //継承フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
