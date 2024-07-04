// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             【住民基本台帳】住民情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afjuminDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_afjumin";
        public string atenano { get; set; }                       //宛名番号
        public string setaino { get; set; }                       //世帯番号
        public Enum住民種別 juminsyubetu { get; set; }            //住民種別
        public string juminjotai { get; set; }                    //住民状態
        public string idoymd { get; set; }                        //異動年月日
        public bool idoymd_fusyoflg { get; set; }                 //異動年月日_不詳フラグ
        public string? idoymd_fusyohyoki { get; set; }            //異動年月日_不詳表記
        public string? idotodokeymd { get; set; }                 //異動届出年月日
        public string idojiyu { get; set; }                       //異動事由
        public string simei { get; set; }                         //氏名
        public string? simei_gairoma { get; set; }                //氏名_外国人ローマ字
        public string? simei_gaikanji { get; set; }               //氏名_外国人漢字
        public string? simei_kana { get; set; }                   //氏名_フリガナ
        public string? kyusi { get; set; }                        //旧氏
        public string? kyusi_kana { get; set; }                   //旧氏_フリガナ
        public string? tusyo { get; set; }                        //通称
        public string? tusyo_kana { get; set; }                   //通称_フリガナ
        public string? simeiyusenkbn { get; set; }                //氏名優先区分
        public string simei_yusen { get; set; }                   //氏名_優先
        public string? simei_kana_yusen { get; set; }             //氏名_フリガナ_優先
        public string sex { get; set; }                           //性別
        public string sexhyoki { get; set; }                      //性別表記
        public string bymd { get; set; }                          //生年月日
        public bool bymd_fusyoflg { get; set; }                   //生年月日_不詳フラグ
        public string? bymd_fusyohyoki { get; set; }              //生年月日_不詳表記
        public string zokucd1 { get; set; }                       //続柄コード1
        public string? zokucd2 { get; set; }                      //続柄コード2
        public string? zokucd3 { get; set; }                      //続柄コード3
        public string? zokucd4 { get; set; }                      //続柄コード4
        public string zokuhyoki { get; set; }                     //続柄表記
        public string adrs_sikucd { get; set; }                   //住所_市区町村コード
        public string adrs_tyoazacd { get; set; }                 //住所_町字コード
        public string? tosi_gyoseikucd { get; set; }              //指定都市_行政区等コード
        public string adrs_todofuken { get; set; }                //住所_都道府県
        public string adrs_sikunm { get; set; }                   //住所_市区郡町村名
        public string? adrs_tyoaza { get; set; }                  //住所_町字
        public string? adrs_bantihyoki { get; set; }              //住所_番地号表記
        public string? adrs_bantiedanum { get; set; }             //住所_番地枝番数値
        public string? adrs_katagakicd { get; set; }              //住所_方書コード
        public string? adrs_katagaki { get; set; }                //住所_方書
        public string? adrs_katagaki_kana { get; set; }           //住所_方書_フリガナ
        public string adrs_yubin { get; set; }                    //住所_郵便番号
        public string? juymd { get; set; }                        //住民となった年月日
        public bool? juymd_fusyoflg { get; set; }                 //住民となった年月日_不詳フラグ
        public string? juymd_fusyohyoki { get; set; }             //住民となった年月日_不詳表記
        public string? tennyumaeadrs_sikucd { get; set; }         //転入前住所_市区町村コード
        public string? tennyumaeadrs_tyoazacd { get; set; }       //転入前住所_町字コード
        public string? tennyumaeadrs_todofuken { get; set; }      //転入前住所_都道府県
        public string? tennyumaeadrs_sikunm { get; set; }         //転入前住所_市区郡町村名
        public string? tennyumaeadrs_tyoaza { get; set; }         //転入前住所_町字
        public string? tennyumaeadrs_bantihyoki { get; set; }     //転入前住所_番地号表記
        public string? tennyumaeadrs_katagaki { get; set; }       //転入前住所_方書
        public string? tennyumaeadrs_yubin { get; set; }          //転入前住所_郵便番号
        public string? tennyumaeadrs_kokunmcd { get; set; }       //転入前住所_国名コード
        public string? tennyumaeadrs_kokunm { get; set; }         //転入前住所_国名等
        public string? tennyumaeadrs_gaiadrs { get; set; }        //転入前住所_国外住所
        public string? tennyumaeadrs_senusisimei { get; set; }    //転入前住所_世帯主氏名
        public string? tenkyomaeadrs_sikucd { get; set; }         //転居前住所_市区町村コード
        public string? tenkyomaeadrs_tyoazacd { get; set; }       //転居前住所_町字コード
        public string? tenkyomaeadrs_todofuken { get; set; }      //転居前住所_都道府県
        public string? tenkyomaeadrs_sikunm { get; set; }         //転居前住所_市区郡町村名
        public string? tenkyomaeadrs_tyoaza { get; set; }         //転居前住所_町字
        public string? tenkyomaeadrs_bantihyoki { get; set; }     //転居前住所_番地号表記
        public string? tenkyomaeadrs_katagakicd { get; set; }     //転居前住所_方書コード
        public string? tenkyomaeadrs_katagaki { get; set; }       //転居前住所_方書
        public string? tenkyomaeadrs_katagaki_kana { get; set; }  //転居前住所_方書_フリガナ
        public string? tenkyomaeadrs_yubin { get; set; }          //転居前住所_郵便番号
        public string? todokeymd { get; set; }                    //消除の届出年月日
        public string? delidoymd { get; set; }                    //消除の異動年月日
        public bool? delidoymd_fusyoflg { get; set; }             //消除の異動年月日_不詳フラグ
        public string? delidoymd_fusyohyoki { get; set; }         //消除の異動年月日_不詳表記
        public string? tennyututiymd { get; set; }                //転入通知年月日
        public string? tensyutuyoteiadrs_sikucd { get; set; }     //転出先住所（予定）_市区町村コード
        public string? tensyutuyoteiadrs_tyoazacd { get; set; }   //転出先住所（予定）_町字コード
        public string? tensyutuyoteiadrs_todofuken { get; set; }  //転出先住所（予定）_都道府県
        public string? tensyutuyoteiadrs_sikunm { get; set; }     //転出先住所（予定）_市区郡町村名
        public string? tensyutuyoteiadrs_tyoaza { get; set; }     //転出先住所（予定）_町字
        public string? tensyutuyoteiadrs_bantihyoki { get; set; } //転出先住所（予定）_番地号表記
        public string? tensyutuyoteiadrs_katagaki { get; set; }   //転出先住所（予定）_方書
        public string? tensyutuyoteiadrs_kokunmcd { get; set; }   //転出先住所（予定）_国名コード
        public string? tensyutuyoteiadrs_kokunm { get; set; }     //転出先住所（予定）_国名等
        public string? tensyutuyoteiadrs_gaiadrs { get; set; }    //転出先住所（予定）_国外住所
        public string? tensyutuyoteiadrs_yubin { get; set; }      //転出先住所（予定）_郵便番号
        public string? tensyutukakuteiadrs_sikucd { get; set; }   //転出先住所（確定）_市区町村コード
        public string? tensyutukakuteiadrs_tyoazacd { get; set; } //転出先住所（確定）_町字コード
        public string? tensyutukakuteiadrs_todofuken { get; set; }  //転出先住所（確定）_都道府県
        public string? tensyutukakuteiadrs_sikunm { get; set; }   //転出先住所（確定）_市区郡町村名
        public string? tensyutukakuteiadrs_tyoaza { get; set; }   //転出先住所（確定）_町字
        public string? tensyutukakuteiadrs_bantihyoki { get; set; }  //転出先住所（確定）_番地号表記
        public string? tensyutukakuteiadrs_katagaki { get; set; } //転出先住所（確定）_方書
        public string? tensyutukakuteiadrs_yubin { get; set; }    //転出先住所（確定）_郵便番号
        public string? gaijuymd { get; set; }                     //外国人住民となった年月日
        public bool? gaijuymd_fusyoflg { get; set; }              //外国人住民となった年月日_不詳フラグ
        public string? gaijuymd_fusyohyoki { get; set; }          //外国人住民となった年月日_不詳表記
        public string? kokunmcd { get; set; }                     //国籍等_国名コード
        public string? kokunm { get; set; }                       //国籍名等
        public string? kiteikbn { get; set; }                     //第30条45規定区分
        public string? zairyucd { get; set; }                     //在留資格等コード
        public string? zairyucd_year { get; set; }                //在留期間等コード_年
        public string? zairyucd_month { get; set; }               //在留期間等コード_月
        public string? zairyucd_day { get; set; }                 //在留期間等コード_日
        public string? zairyumanryoymd { get; set; }              //在留期間の満了の日
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
        public string? personalno { get; set; }                   //個人番号
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
