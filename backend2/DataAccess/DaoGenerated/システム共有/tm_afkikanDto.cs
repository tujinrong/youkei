// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             医療機関マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afkikanDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afkikan";
		public string kikancd { get; set; }                       //医療機関コード（自治体独自）
		public string hokenkikancd { get; set; }                  //保険医療機関コード
		public string kanakikannm { get; set; }                   //医療機関名カナ
		public string kikannm { get; set; }                       //医療機関名
		public string yubin { get; set; }                         //郵便番号
		public string adrs { get; set; }                          //住所
		public string? katagaki { get; set; }                     //方書
		public string? tel { get; set; }                          //電話番号
		public string? fax { get; set; }                          //FAX番号
		public string? syozokuisikai { get; set; }                //所属医師会
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
