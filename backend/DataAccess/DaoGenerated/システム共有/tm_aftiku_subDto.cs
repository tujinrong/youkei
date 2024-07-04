// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             地区情報サブマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftiku_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_aftiku_sub";
		public string tikukbn { get; set; }                       //地区区分
		public string tikucd { get; set; }                        //地区コード
		public string staffid { get; set; }                       //地区担当者
    }
}
