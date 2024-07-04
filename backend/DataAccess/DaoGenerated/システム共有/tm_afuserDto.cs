// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             ユーザーマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afuserDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afuser";
		public string userid { get; set; }                        //ユーザーID
		public string pword { get; set; }                         //パスワード
		public string usernm { get; set; }                        //ユーザー名
		public string? syozokucd { get; set; }                    //所属グループコード
		public int? errorkaisu { get; set; }                      //ログインエラー回数
		public string yukoymdf { get; set; }                      //有効年月日（開始）
		public string yukoymdt { get; set; }                      //有効年月日（終了）
		public string pwordhenkoymd { get; set; }                 //パスワード変更年月日
		public bool kanrisyaflg { get; set; }                     //管理者フラグ
		public bool pnoeditflg { get; set; }                      //個人番号操作権限付与フラグ
		public bool alertviewflg { get; set; }                    //警告参照フラグ
		public bool authsetflg { get; set; }                      //権限設定フラグ
		public bool kanrisyakeisyoflg { get; set; }               //管理者継承フラグ
		public bool pnoeditkeisyoflg { get; set; }                //個人番号操作権限付与継承フラグ
		public bool alertviewkeisyoflg { get; set; }              //警告参照継承フラグ
		public bool authsisyokeisyoflg { get; set; }              //部署（支所）別更新権限継承フラグ
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
