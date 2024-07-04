// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力テーブルマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_tableDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku_table";
		public string tablenm { get; set; }                       //テーブル物理名
		public string tableronrinm { get; set; }                  //テーブル論理名
		public bool imptaisyoflg { get; set; }                    //取込対象フラグ
		public bool sansyoflg { get; set; }                       //参照対象フラグ
		public bool sonzaicheckflg { get; set; }                  //存在チェック対象フラグ
		public int orderseq { get; set; }                         //並びシーケンス
		public string? oyatablenm { get; set; }                   //親テーブル
    }
}
