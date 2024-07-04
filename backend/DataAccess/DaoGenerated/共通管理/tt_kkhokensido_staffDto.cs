// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             保健指導担当者テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkhokensido_staffDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkhokensido_staff";
		public string hokensidokbn { get; set; }                  //保健指導区分
		public string gyomukbn { get; set; }                      //業務区分
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string mosikomikekkakbn { get; set; }              //申込結果区分
		public string staffid { get; set; }                       //担当者
    }
}
