// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             宛名ワークテーブルサブ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class wk_euatena_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "wk_euatena_sub";
		public long workseq { get; set; }                         //ワークシーケンス
		public string atenano { get; set; }                       //宛名番号
		public bool formflg { get; set; }                         //出力フラグ
		public bool taisyoflg { get; set; }                       //対象外者フラグ
		public bool taisyooutflg { get; set; }                    //対象外出力可能フラグ
    }
}
