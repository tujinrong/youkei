// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             事業予定担当者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyotei_staffDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkjigyoyotei_staff";
		public int nitteino { get; set; }                         //日程番号
		public string staffid { get; set; }                       //担当者
    }
}
