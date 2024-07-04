// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             画面権限テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afauthgamenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afauthgamen";
		public Enumロール区分 rolekbn { get; set; }               //ロール区分
		public string roleid { get; set; }                        //ロールID
		public string kinoid { get; set; }						  //機能ID
		public Enumプログラム区分 programkbn { get; set; }        //プログラム区分
		public bool addflg { get; set; }                          //追加フラグ
		public bool updateflg { get; set; }                       //修正フラグ
		public bool deleteflg { get; set; }                       //削除フラグ
		public bool personalnoflg { get; set; }                   //個人番号利用フラグ
		public bool? keisyoflg { get; set; }                      //継承フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
