// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             事業予定テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyoteiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkjigyoyotei";
		public int nitteino { get; set; }                         //日程番号
		public string jigyocd { get; set; }                       //その他日程事業・保健指導事業コード
		public int? courseno { get; set; }                        //コース番号
		public int? kaisu { get; set; }                           //回数
		public string? jissinaiyo { get; set; }                   //実施内容
		public string jissiyoteiymd { get; set; }                 //実施予定日
		public string tmf { get; set; }                           //開始時間
		public string? tmt { get; set; }                          //終了時間
		public string kaijocd { get; set; }                       //会場コード
		public string? kikancd { get; set; }                      //医療機関コード
		public int teiin { get; set; }                            //定員
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
