// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             成人健（検）診予約日程事業マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shyoyakujigyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_shyoyakujigyo";
		public int nendo { get; set; }                            //年度
		public string jigyocd { get; set; }                       //成人健（検）診予約日程事業コード
		public string ryokinpattern { get; set; }                 //料金パターン
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
