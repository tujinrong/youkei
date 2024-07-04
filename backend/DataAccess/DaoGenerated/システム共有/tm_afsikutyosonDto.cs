// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             市区町村マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afsikutyosonDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afsikutyoson";
		public string sikucd { get; set; }                        //市区町村コード
		public string todofukennm { get; set; }                   //都道府県名
		public string todofukennm_kana { get; set; }              //都道府県名_カナ
		public string todofukennm_eiji { get; set; }              //都道府県名_英字
		public string? gunnm { get; set; }                        //郡名
		public string? gunnm_kana { get; set; }                   //郡名_カナ
		public string? gunnm_eiji { get; set; }                   //郡名_英字
		public string sikunm { get; set; }                        //市区町村名
		public string sikunm_kana { get; set; }                   //市区町村名_カナ
		public string sikunm_eiji { get; set; }                   //市区町村名_英字
		public string? seireisikunm { get; set; }                 //政令市区名
		public string? seireisikunm_kana { get; set; }            //政令市区名_カナ
		public string? seireisikunm_eiji { get; set; }            //政令市区名_英字
		public string koryokuhasseiymd { get; set; }              //効力発生日
		public string haisiymd { get; set; }                      //廃止日
		public string? biko { get; set; }                         //備考
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
