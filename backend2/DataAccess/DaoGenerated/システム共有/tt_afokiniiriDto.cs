// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             お気に入りテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afokiniiriDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afokiniiri";
		public string userid { get; set; }                        //ユーザーID
		public string kinoid { get; set; }                        //機能ID
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
