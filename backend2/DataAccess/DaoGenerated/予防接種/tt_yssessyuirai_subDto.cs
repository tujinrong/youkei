// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             予防接種依頼サブテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyuirai_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_yssessyuirai_sub";
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string sessyucd { get; set; }                      //接種種類コード
		public string kaisu { get; set; }                         //回数
    }
}
