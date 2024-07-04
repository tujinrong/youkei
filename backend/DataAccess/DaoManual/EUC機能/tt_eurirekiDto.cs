// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUC帳票検索履歴テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eurirekiDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_eurireki";
        public long rirekiseq { get; set; }                       //履歴シーケンス
        public string rptid { get; set; }                         //帳票ID
        public string yosikiid { get; set; }                      //様式ID
        public Enum出力方式 outputkbn { get; set; }                //出力方式
        public string? memo { get; set; }                         //検索条件メモ
        public Enum履歴出力状態区分 jyotaikbn { get; set; }          //状態区分
        public int? num { get; set; }                             //結果件数
        public DateTime syoridttmf { get; set; }                  //処理日時（開始）
        public DateTime? syoridttmt { get; set; }                 //処理日時（終了）
        public int? milisec { get; set; }                         //処理時間
        public string filenm { get; set; }                        //ファイル名
        public byte[]? filedata { get; set; }                     //結果ファイル
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
