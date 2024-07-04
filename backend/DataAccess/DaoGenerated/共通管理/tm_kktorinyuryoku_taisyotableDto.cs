// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力対象テーブルマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_taisyotableDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku_taisyotable";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public string tablenm { get; set; }                       //テーブル物理名
    }
}
