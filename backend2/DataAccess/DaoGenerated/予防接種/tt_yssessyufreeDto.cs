// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             予防接種（フリー項目）接種テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyufreeDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_yssessyufree";
		public string atenano { get; set; }                       //宛名番号
		public string sessyucd { get; set; }                      //接種種類コード
		public string kaisu { get; set; }                         //回数
		public int edano { get; set; }                            //枝番
		public string itemcd { get; set; }                        //項目コード
		public bool? fusyoflg { get; set; }                       //不詳フラグ
		public double? numvalue { get; set; }                     //数値項目
		public string? strvalue { get; set; }                     //文字項目
    }
}
