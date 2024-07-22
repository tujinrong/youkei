// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             バッチログテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afbatchlogDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afbatchlog";
		public long batchlogseq { get; set; }                     //バッチログシーケンス
		public long sessionseq { get; set; }                      //セッションシーケンス
		public DateTime syoridttmf { get; set; }                  //処理日時（開始）
		public DateTime syoridttmt { get; set; }                  //処理日時（終了）
		public string? msg { get; set; }                          //メッセージ
		public string? pram { get; set; }                         //パラメータ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
