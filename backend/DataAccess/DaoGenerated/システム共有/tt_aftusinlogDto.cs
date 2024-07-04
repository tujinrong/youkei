// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             通信ログテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aftusinlogDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_aftusinlog";
		public long tusinlogseq { get; set; }                     //通信ログシーケンス
		public long sessionseq { get; set; }                      //セッションシーケンス
		public DateTime syoridttmf { get; set; }                  //処理日時（開始）
		public DateTime syoridttmt { get; set; }                  //処理日時（終了）
		public string? msg { get; set; }                          //メッセージ
		public string? request { get; set; }                      //リクエスト
		public string? response { get; set; }                     //レスポンス
		public string? ipadrs { get; set; }                       //IPアドレス
		public string? os { get; set; }                           //OS
		public string? browser { get; set; }                      //ブラウザー情報
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
