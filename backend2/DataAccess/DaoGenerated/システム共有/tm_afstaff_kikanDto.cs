// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             事業従事者（担当者）所属機関
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afstaff_kikanDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afstaff_kikan";
		public string staffid { get; set; }                       //事業従事者ID
		public string kikancd { get; set; }                       //医療機関コード（自治体独自）
    }
}
