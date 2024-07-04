// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             workテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
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
