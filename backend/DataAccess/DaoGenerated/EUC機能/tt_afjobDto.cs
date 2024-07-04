// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             ジョブ管理テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjobDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afjob";
		public int jobseq { get; set; }                           //ジョブシーケンス
		public string? servernm { get; set; }                     //実行サーバー
		public string jikokbn { get; set; }                       //実行区分
		public DateTime? yoteidttm { get; set; }                  //予定実行日時
		public string? teijitm { get; set; }                      //定時実行時刻
		public string assemby { get; set; }                       //実行モジュール名
		public string nmspace { get; set; }                       //命名空間
		public string programid { get; set; }                     //プログラムID
		public string method { get; set; }                        //メソッド
		public string? pram { get; set; }                         //パラメータ
		public DateTime? syoridttmf { get; set; }                 //処理日時（開始）
		public DateTime? syoridttmt { get; set; }                 //処理日時（終了）
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
