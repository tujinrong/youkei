// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             帳票発行抽出対象マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afrpthakkotyusyututaisyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afrpthakkotyusyututaisyo";
		public string taisyocd { get; set; }                      //抽出対象CD
		public string rptid { get; set; }                         //帳票№
		public string yosikiid { get; set; }                      //帳票様式
		public string taisyonm { get; set; }                      //抽出対象名
		public string gyomucd { get; set; }                       //業務コード
		public string noticecycle { get; set; }                   //通知サイクル
		public bool? jogaiflg { get; set; }                       //再抽出除外フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
