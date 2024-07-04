// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             集団指導事業（フリー項目）入力情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansidofreeDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kksyudansidofree";
		public string gyomukbn { get; set; }                      //業務区分
		public int edano { get; set; }                            //枝番
		public string mosikomikekkakbn { get; set; }              //申込結果区分
		public string itemcd { get; set; }                        //項目コード
		public bool fusyoflg { get; set; }                        //不詳フラグ
		public double? numvalue { get; set; }                     //数値項目
		public string? strvalue { get; set; }                     //文字項目
    }
}
