// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             母子保健データリストマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhdatalistDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhdatalist";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhdatalistcd { get; set; }                  //母子データリストコード
		public string bhdatalistname { get; set; }                //母子データリスト名称
		public string rirekikanrimax { get; set; }                //履歴管理最大
		public string bhkanripatterncd { get; set; }              //母子管理パターンコード
    }
}
