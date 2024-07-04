// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             健（検）診予定担当者テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyotei_staffDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shkensinyotei_staff";
		public int nendo { get; set; }                            //年度
		public int nitteino { get; set; }                         //日程番号
		public string staffid { get; set; }                       //担当者
    }
}
