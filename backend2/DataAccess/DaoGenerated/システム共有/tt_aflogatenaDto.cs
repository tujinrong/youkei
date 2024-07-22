// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             宛名番号ログテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogatenaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_aflogatena";
		public long atenalogseq { get; set; }                     //宛名番号ログシーケンス
		public long sessionseq { get; set; }                      //セッションシーケンス
		public string atenano { get; set; }                       //宛名番号
		public bool pnouseflg { get; set; }                       //個人番号操作フラグ
		public string usekbn { get; set; }                        //操作区分
		public string? msg { get; set; }                          //メッセージ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
