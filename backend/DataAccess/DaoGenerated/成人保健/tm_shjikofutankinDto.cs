// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             自己負担金マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shjikofutankinDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_shjikofutankin";
		public int nendo { get; set; }                            //年度
		public string kensin_jigyocd { get; set; }                //検診種別
		public string ryokinpattern { get; set; }                 //料金パターン
		public string kensahohocd { get; set; }                   //検査方法コード
		public string sex { get; set; }                           //性別
		public string agehani { get; set; }                       //年齢範囲
		public string genmenkbn { get; set; }                     //減免区分
		public int jusinkingaku { get; set; }                     //受診金額
		public int? kingaku_sityosonhutan { get; set; }           //金額（市区町村負担）
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
