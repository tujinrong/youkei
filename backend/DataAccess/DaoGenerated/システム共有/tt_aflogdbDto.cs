// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             DB操作ログテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogdbDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_aflogdb";
		public long dblogseq { get; set; }                        //DB操作ログシーケンス
		public long? sessionseq { get; set; }                     //セッションシーケンス
		public string? sql { get; set; }                          //SQL
		public string? msg { get; set; }                          //メッセージ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
