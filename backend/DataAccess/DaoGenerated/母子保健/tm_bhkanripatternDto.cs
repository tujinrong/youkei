// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             母子保健管理パターンマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhkanripatternDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhkanripattern";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhkanripatterncd { get; set; }              //母子管理パターンコード
		public string bhkanripatternname { get; set; }            //母子管理パターン名称
    }
}
