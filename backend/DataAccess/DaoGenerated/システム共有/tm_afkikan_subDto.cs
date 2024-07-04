// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             医療機関サブマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkikan_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afkikan_sub";
		public string kikancd { get; set; }                       //医療機関コード（自治体独自）
		public string jissijigyo { get; set; }                    //医療機関・事業従事者（担当者）事業コード
    }
}
