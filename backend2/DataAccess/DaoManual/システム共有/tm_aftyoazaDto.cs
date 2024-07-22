// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             町字マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftyoazaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_aftyoaza";
		public string sikucd { get; set; }                        //市区町村コード
		public string tyoazaid { get; set; }                      //町字ID
		public Enum町字区分 tyoazakbn { get; set; }               //町字区分コード
		public string? oazatyonm { get; set; }                    //大字・町名
		public string? oazatyonm_kana { get; set; }               //大字・町名_カナ
		public string? oazatyonm_eiji { get; set; }               //大字・町名_英字
		public string? tyomeinm { get; set; }                     //丁目名
		public string? tyomeinm_kana { get; set; }                //丁目名_カナ
		public string? tyomeinm_suji { get; set; }                //丁目名_数字
		public string? koazanm { get; set; }                      //小字名
		public string? koazanm_kana { get; set; }                 //小字名_カナ
		public string? koazanm_eiji { get; set; }                 //小字名_英字
		public string jukyoflg { get; set; }                      //住居表示フラグ
		public string? jukyocd { get; set; }                      //住居表示方式コード
		public string? oazatyo_tusyoflg { get; set; }             //大字・町_通称フラグ
		public string? koaza_tusyoflg { get; set; }               //小字_通称フラグ
		public string? oazatyo_gaijiflg { get; set; }             //大字・町_外字フラグ
		public string? koaza_gaijiflg { get; set; }               //小字_外字フラグ
		public string? statusflg { get; set; }                    //状態フラグ
		public string? kibanflg { get; set; }                     //起番フラグ
		public string? koryokuhasseiymd { get; set; }             //効力発生日
		public string? haisiymd { get; set; }                     //廃止日
		public string? siryocd { get; set; }                      //原典資料コード
		public string? yubin { get; set; }                        //郵便番号
		public string? biko { get; set; }                         //備考
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
