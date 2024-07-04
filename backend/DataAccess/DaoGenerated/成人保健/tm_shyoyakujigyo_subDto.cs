// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             成人健（検）診予約日程事業サブマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shyoyakujigyo_subDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_shyoyakujigyo_sub";
		public int nendo { get; set; }                            //年度
		public string jigyocd { get; set; }                       //成人健（検）診予約日程事業コード
		public string kensin_jigyocd { get; set; }                //検診種別
		public string kensahohocd { get; set; }                   //成人健（検）診検査方法コード
		public bool optionflg { get; set; }                       //オプションフラグ
    }
}
