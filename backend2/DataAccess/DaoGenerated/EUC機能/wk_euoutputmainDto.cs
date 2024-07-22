// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             workテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euoutputmainDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "wk_euoutputmain";
		public long workseq { get; set; }                         //workシーケンス
		public string? token { get; set; }                          //トークン
		public bool batflg { get; set; }                          //バッチフラグ
    }
}
