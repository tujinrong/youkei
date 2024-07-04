// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             機能マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkinoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afkino";
		public string kinoid { get; set; }                        //機能ID
		public string hyojinm { get; set; }                       //表示名称
		public string? programid { get; set; }                    //プログラムID（共用）
		public string? hanyokbn { get; set; }                     //汎用区分
    }
}
