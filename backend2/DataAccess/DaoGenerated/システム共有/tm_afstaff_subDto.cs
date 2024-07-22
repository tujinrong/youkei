// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             事業従事者（担当者）サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afstaff_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afstaff_sub";
		public string staffid { get; set; }                       //事業従事者ID
		public string jissijigyo { get; set; }                    //医療機関・事業従事者（担当者）事業コード
    }
}
