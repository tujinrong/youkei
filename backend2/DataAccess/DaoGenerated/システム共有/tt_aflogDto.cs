// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             メインログテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_aflog";
		public long sessionseq { get; set; }                      //セッションシーケンス
		public DateTime syoridttmf { get; set; }                  //処理日時（開始）
		public DateTime? syoridttmt { get; set; }                 //処理日時（終了）
		public int? milisec { get; set; }                         //処理時間
		public string statuscd { get; set; }                      //処理結果コード
		public string? kinoid { get; set; }                       //機能ID
		public string? service { get; set; }                      //サービス名
		public string? method { get; set; }                       //メソッド
		public string? methodnm { get; set; }                     //メソッド名
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
