// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             妊産婦ワークテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euninsanpu_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "wk_euninsanpu_sub";
		public long workseq { get; set; }                         //ワークシーケンス
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
    }
}
