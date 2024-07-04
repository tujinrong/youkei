// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             母子保健項目テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhitem";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhsyosaimenyucd { get; set; }               //母子詳細メニューコード
		public string bhsyosaitabcd { get; set; }                 //母子詳細タブコード
		public string bhdatalistcd { get; set; }                  //母子データリストコード
		public string atenano { get; set; }                       //宛名番号
		public int kensinkaisu { get; set; }                      //履歴回数
		public string itemcd { get; set; }                        //項目コード
		public bool? fusyoflg { get; set; }                       //不詳フラグ
		public double? numvalue { get; set; }                     //数値項目
		public string? strvalue { get; set; }                     //文字項目
    }
}
