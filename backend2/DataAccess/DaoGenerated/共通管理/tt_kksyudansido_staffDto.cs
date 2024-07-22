// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             集団指導担当者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kksyudansido_staffDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kksyudansido_staff";
		public string gyomukbn { get; set; }                      //業務区分
		public int edano { get; set; }                            //枝番
		public string mosikomikekkakbn { get; set; }              //申込結果区分
		public string staffid { get; set; }                       //担当者
    }
}
