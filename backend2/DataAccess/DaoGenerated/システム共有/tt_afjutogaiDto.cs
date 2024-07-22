// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             住登外者情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjutogaiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afjutogai";
		public string atenano { get; set; }                       //宛名番号
		public int rirekino { get; set; }                         //履歴番号
		public string setaino { get; set; }                       //世帯番号
		public string jutogaisyasyubetu { get; set; }             //住登外者種別
		public string jutogaisyajotai { get; set; }               //住登外者状態
		public string idoymd { get; set; }                        //異動年月日
		public string idotodokeymd { get; set; }                  //異動届出年月日
		public string? idojiyu { get; set; }                      //異動事由
		public string simei { get; set; }                         //氏名
		public string? si { get; set; }                           //氏_日本人
		public string? mei { get; set; }                          //名_日本人
		public string? simei_gairoma { get; set; }                //氏名_外国人ローマ字
		public string? simei_gaikanji { get; set; }               //氏名_外国人漢字
		public string? simei_kana { get; set; }                   //氏名_フリガナ
		public string? simei_kana_seion { get; set; }             //氏名_フリガナ_清音化
		public string? si_kana { get; set; }                      //氏_日本人_フリガナ
		public string? si_kana_seion { get; set; }                //氏_日本人_フリガナ_清音化
		public string? mei_kana { get; set; }                     //名_日本人_フリガナ
		public string? mei_kana_seion { get; set; }               //名_日本人_フリガナ_清音化
		public string? tusyo { get; set; }                        //通称
		public string? tusyo_kana { get; set; }                   //通称_フリガナ
		public string? tusyo_kana_seion { get; set; }             //通称_フリガナ_清音化
		public string? tusyo_kanastatus { get; set; }             //通称_フリガナ確認状況
		public string simei_yusen { get; set; }                   //氏名_優先
		public string? simei_kana_yusen { get; set; }             //氏名_フリガナ_優先
		public string? simei_kana_yusen_seion { get; set; }       //氏名_フリガナ_優先_清音化
		public string? sex { get; set; }                          //性別
		public string? sexhyoki { get; set; }                     //性別表記
		public string? bymd { get; set; }                         //生年月日
		public bool? bymd_fusyoflg { get; set; }                  //生年月日_不詳フラグ
		public string? bymd_fusyohyoki { get; set; }              //生年月日_不詳表記
		public string? adrs_sikucd { get; set; }                  //住所_市区町村コード
		public string? adrs_tyoazacd { get; set; }                //住所_町字コード
		public string? tosi_gyoseikucd { get; set; }              //指定都市_行政区等コード
		public string? adrs_todofuken { get; set; }               //住所_都道府県
		public string? adrs_sikunm { get; set; }                  //住所_市区郡町村名
		public string? adrs_tyoaza { get; set; }                  //住所_町字
		public string? adrs_bantihyoki { get; set; }              //住所_番地号表記
		public string? adrs_katagaki { get; set; }                //住所_方書
		public string? adrs_katagaki_kana { get; set; }           //住所_方書_フリガナ
		public string? adrs_yubin { get; set; }                   //住所_郵便番号
		public string? adrs_kokunmcd { get; set; }                //住所_国名コード
		public string? adrs_kokunm { get; set; }                  //住所_国名等
		public string? adrs_gaiadrs { get; set; }                 //住所_国外住所
		public string? hokenkbn { get; set; }                     //保険区分
		public string nayosemotoflg { get; set; }                 //名寄せ元フラグ
		public string? nayosesakiatenano { get; set; }            //名寄せ先宛名番号
		public string togoatenaflg { get; set; }                  //統合宛名フラグ
		public string sansyofukaflg { get; set; }                 //他業務参照不可フラグ
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string? renkeimotosousauserid { get; set; }        //連携元操作者ID
		public DateTime? renkeimotosousadttm { get; set; }        //連携元操作日時
		public bool saisinflg { get; set; }                       //最新フラグ
		public string regbusyocd { get; set; }                    //登録部署
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
