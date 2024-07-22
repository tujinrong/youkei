// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             会場情報サブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkaijo_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afkaijo_sub";
		public string kaijocd { get; set; }                       //会場コード
		public Enum地区区分 tikukbn { get; set; }                 //地区区分
		public string tikucd { get; set; }                        //地区コード
    }
}
