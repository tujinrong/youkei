// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             宛名ワークテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euatenaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "wk_euatena";
		public long workseq { get; set; }                         //ワークシーケンス
		public string? token { get; set; }                        //トークン
		public string? jikoymd { get; set; }                      //作成日
		public bool batflg { get; set; }                          //バッチフラグ
    }
}
