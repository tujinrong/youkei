// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             宛名テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afatenaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afatena";
		public string atenano { get; set; }                       //宛名番号
		public string setaino { get; set; }                       //世帯番号
		public Enum住登区分 jutokbn { get; set; }                 //住登区分
		public Enum住民種別 juminsyubetu { get; set; }            //住民種別
		public string juminjotai { get; set; }                    //住民状態
		public string juminkbn { get; set; }                      //住民区分
		public string simei { get; set; }                         //氏名
		public string? simei_kana { get; set; }                   //氏名_フリガナ
		public string? simei_kana_seion { get; set; }             //氏名_フリガナ_清音化
		public string? tusyo { get; set; }                        //通称
		public string? tusyo_kana { get; set; }                   //通称_フリガナ
		public string? tusyo_kana_seion { get; set; }             //通称_フリガナ_清音化
		public string simei_yusen { get; set; }                   //氏名_優先
		public string? simei_kana_yusen { get; set; }             //氏名_フリガナ_優先
		public string? simei_kana_yusen_seion { get; set; }       //氏名_フリガナ_優先_清音化
		public string sex { get; set; }                           //性別
		public string? bymd { get; set; }                         //生年月日
		public bool? bymd_fusyoflg { get; set; }                  //生年月日_不詳フラグ
		public string? bymd_fusyohyoki { get; set; }              //生年月日_不詳表記
		public string? zokucd1 { get; set; }                      //続柄コード1
		public string? zokucd2 { get; set; }                      //続柄コード2
		public string? zokucd3 { get; set; }                      //続柄コード3
		public string? zokucd4 { get; set; }                      //続柄コード4
		public string zokuhyoki { get; set; }                     //続柄表記
		public string adrs_sikucd { get; set; }                   //住所_市区町村コード
		public string adrs_tyoazacd { get; set; }                 //住所_町字コード
		public string? tosi_gyoseikucd { get; set; }              //指定都市_行政区等コード
		public string adrs1 { get; set; }                         //住所1
		public string? adrs2 { get; set; }                        //住所2
		public string? adrs_katagakicd { get; set; }              //住所_方書コード
		public string adrs_yubin { get; set; }                    //住所_郵便番号
		public string? tikukanricd1 { get; set; }                 //地区管理コード1
		public string? tikukanricd2 { get; set; }                 //地区管理コード2
		public string? tikukanricd3 { get; set; }                 //地区管理コード3
		public string? tikukanricd4 { get; set; }                 //地区管理コード4
		public string? tikukanricd5 { get; set; }                 //地区管理コード5
		public string? tikukanricd6 { get; set; }                 //地区管理コード6
		public string? tikukanricd7 { get; set; }                 //地区管理コード7
		public string? tikukanricd8 { get; set; }                 //地区管理コード8
		public string? tikukanricd9 { get; set; }                 //地区管理コード9
		public string? tikukanricd10 { get; set; }                //地区管理コード10
		public string? gyoseikucd { get; set; }                   //行政区コード
		public string? siensotikbn { get; set; }                  //支援措置区分
		public string? personalno { get; set; }                   //個人番号
		public string? kazeikbn { get; set; }                     //課税非課税区分
		public string? kazeikbn_setai { get; set; }               //課税非課税区分（世帯）
		public string? hokenkbn { get; set; }                     //保険区分
		public string? genmenkbn_tokutei { get; set; }            //減免区分（特定健診）
		public string? genmenkbn_gan { get; set; }                //減免区分（がん検診）
    }
}
