// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             その他日程事業・保健指導事業マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kksonotasidojigyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kksonotasidojigyo";
		public string jigyocd { get; set; }                       //その他日程事業・保健指導事業コード
		public string jigyonm { get; set; }                       //その他日程事業・保健指導事業名
		public string gyomukbn { get; set; }                      //業務区分
		public bool yoyakuriyoflg { get; set; }                   //予約利用フラグ
		public bool homonriyoflg { get; set; }                    //訪問利用フラグ
		public bool sodanriyoflg { get; set; }                    //相談利用フラグ
		public bool syudanriyoflg { get; set; }                   //集団利用フラグ
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
