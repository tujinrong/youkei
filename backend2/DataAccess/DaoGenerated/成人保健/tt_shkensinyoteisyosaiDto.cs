// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             健（検）診予定詳細テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinyoteisyosaiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shkensinyoteisyosai";
		public int nendo { get; set; }                            //年度
		public int nitteino { get; set; }                         //日程番号
		public string jigyocd { get; set; }                       //検診種別
		public string yoyakubunruicd { get; set; }                //予約分類コード
		public int teiin_kensin { get; set; }                     //定員(検診)
    }
}
