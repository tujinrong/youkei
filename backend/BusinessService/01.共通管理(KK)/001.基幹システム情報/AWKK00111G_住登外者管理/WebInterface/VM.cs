// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住登外者管理
//             ビューモデル定義
// 作成日　　: 2023.11.09
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00111G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM
    {
        public string atenano { get; set; }             //宛名番号
        public int rirekino { get; set; }               //履歴番号
        public string stopflg { get; set; }             //削除
        public string name { get; set; }                //氏名
        public string kname { get; set; }               //カナ氏名
        public string sexhyoki { get; set; }            //性別（名称）
        public string juminkbn { get; set; }            //住民区分（住民種別内容、住民状態内容）
        public string bymd { get; set; }                //生年月日
        public string adrs { get; set; }                //住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
        public string keikoku { get; set; }             //警告内容
    }

    /// <summary>
    /// 住登外者詳細_ヘッダー部(メイン：ベース)
    /// </summary>
    public class BaseInfoVM
    {
        public string atenano { get; set; }	            //宛名番号		
        public string name { get; set; }	            //氏名			
        public string kname { get; set; }	            //カナ氏名		
        public string sex { get; set; }	                //性別			
        public string bymd { get; set; }	            //生年月日		
        public string juminkbnnm { get; set; }	        //住民区分（内容）
        public string age { get; set; }	                //年齢			
        public string agekijunymd { get; set; }	        //年齡計算基準日		
        public string kazeikbn_setai { get; set; }      //課税非課税区分（世帯）		
        public string hokenkbn { get; set; }            //保険区分（名称）
        public string stop { get; set; }	            //削除			
        public string keikoku { get; set; }	            //警告有無		
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailVM
    {
        public bool fusyoflg { get; set; }                              //生年月日不詳フラグフラグ
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(異動事由)
        public List<DaSelectorModel> selectorlist2 { get; set; }        //ドロップダウンリスト(行政区等)
        public List<DaSelectorModelExp> selectorlist3 { get; set; }     //ドロップダウンリスト(市区町村)(市区町村コード、都道府県＋市区名、都道府県、市区名)
        public List<DaSelectorKeyModel> selectorlist4 { get; set; }     //ドロップダウンリスト(町字)
        public List<DaSelectorModel> selectorlist5 { get; set; }        //ドロップダウンリスト(住民種別)
        public List<DaSelectorModel> selectorlist6 { get; set; }        //ドロップダウンリスト(住民状態)
        public List<DaSelectorModel> selectorlist7 { get; set; }        //ドロップダウンリスト(性別)
        public List<DaSelectorModel> selectorlist8 { get; set; }        //ドロップダウンリスト(国名等)
        public List<DaSelectorModel> selectorlist9 { get; set; }        //ドロップダウンリスト(保険区分)
        public List<DaSelectorModel> selectorlist10 { get; set; }       //ドロップダウンリスト(他業務参照不可)
        public List<DaSelectorModel> dokujisystemnmlist { get; set; }   //参照独自施策システム等リスト
        public List<DaSelectorModel> sansyogyomunmlist { get; set; }    //参照業務リスト
        public List<DaSelectorModel> selectorlist11 { get; set; }       //ドロップダウンリスト(名寄せ元)
        public List<DaSelectorModel> selectorlist12 { get; set; }       //ドロップダウンリスト(統合宛名フラグ)
        public List<DaSelectorModel> selectorlist13 { get; set; }       //ドロップダウンリスト(登録部署)
    }

    /// <summary>
    /// 住登外者詳細_基本情報等タブ（メイン：保存用）
    /// </summary>
    public class MainInfoVM
    {
        public int rirekino { get; set; }               //履歴番号
        public DateTime? upddttm { get; set; }          //更新日時(排他も利用)
        public string saisin { get; set; }              //最新
        public string stop { get; set; }                //削除
        public string? idoymd { get; set; }             //異動年月日
        public string idotodokeymd { get; set; }        //異動届出年月日
        public string idojiyu { get; set; }             //異動事由
        public string setaino { get; set; }             //世帯番号（I/O）
        public string senusinm { get; set; }            //世帯主名			
        public string? adrs_yubin { get; set; }         //郵便番号（I/O）			
        public string? tosi_gyoseikucd { get; set; }    //指定都市_行政区等コード（I/O）
        public string? adrs_sikucd { get; set; }        //市区町村（I/O）			
        public string? adrs_todofuken { get; set; }     //都道府県			
        public string? adrs_sikunm { get; set; }        //市区町村名			
        public string adrs_tyoazacd { get; set; }       //町字コード（I/O）		
        public string? adrs_tyoaza { get; set; }        //町字名（I/O）				
        public string? adrs_bantihyoki { get; set; }    //番地号表記（I/O）			
        public string? adrs_katagaki_kana { get; set; } //方書(フリガナ)（I/O）			
        public string? adrs_katagaki { get; set; }      //方書(漢字)（I/O）			
        public string atenano { get; set; }             //宛名番号（I/O）			
        public string? personalno { get; set; }         //個人番号（I/O）			
        public string jutogaisyasyubetu { get; set; }   //住登外者種別（I/O）			
        public string jutogaisyajotai { get; set; }     //住登外者状態（I/O）			
        public string juminkbn { get; set; }            //住民区分			
        public string? si_kana { get; set; }            //氏_日本人_フリガナ（I/O）		
        public string? mei_kana { get; set; }           //名_日本人_フリガナ（I/O）		
        public string? si { get; set; }                 //氏_日本人（I/O）			
        public string? mei { get; set; }                //名_日本人（I/O）			
        public string? simei_kana { get; set; }         //氏名_フリガナ（I/O）			
        public string? simei_gaikanji { get; set; }     //氏名_外国人漢字（I/O）			
        public string? simei_gairoma { get; set; }      //氏名_外国人ローマ字（I/O）		
        public string? tusyo_kana { get; set; }         //通称_フリガナ（I/O）			
        public string? tusyo { get; set; }              //通称漢字（I/O）			
        public string? tusyo_kanastatus { get; set; }   //通称_フリガナ確認状況（I/O）		
        public string sex { get; set; }                 //性別（I/O）				
        public string? bymd { get; set; }               //生年月日（I/O）			
        public bool bymd_fusyoflg { get; set; }         //生年月日_不詳フラグ（I/O）		
        public string? bymd_fusyohyoki { get; set; }    //生年月日(不詳表記)（I/O）		
        public string? adrs_kokunmcd { get; set; }      //住所_国名コード（I/O）			
        public string adrs_kokunm { get; set; }         //住所_国名等			
        public string? adrs_gaiadrs { get; set; }       //住所_国外住所（I/O）			
        public string? hokenkbn { get; set; }           //保険区分（I/O）			
        public string sansyofuka { get; set; }          //他業務参照不可（I/O）			
        public List<RefListVM> dokujisystemcdlist { get; set; } //参照独自施策システム等リスト(コード)（I/O）
        public List<RefListVM> sansyogyomucdlist { get; set; }  //参照業務リスト(コード)（I/O）
        public string nayosemotoflg { get; set; }       //名寄せ元（I/O）			
        public string? nayosesakiatenano { get; set; }  //名寄せ先宛名番号（I/O）		
        public string togoatenaflg { get; set; }        //統合宛名フラグ			
        public string regbusyocd { get; set; }          //登録部署（I/O）		
    }

    /// <summary>
    /// 宛名情報（保存用）
    /// </summary>
    public class AtenaInfoVM
    {
        public string atenano { get; set; }             //宛名番号
        public string setaino { get; set; }             //世帯番号
        public Enum住登区分 jutokbn { get; set; }       //住登区分2
        public Enum住民種別 juminsyubetu { get; set; }  //住民種別
        public string juminjotai { get; set; }          //住民状態
        public string juminkbn { get; set; }            //住民区分
        public string simei { get; set; }               //氏名
        public string? simei_kana { get; set; }         //氏名_フリガナ
        public string? tusyo { get; set; }              //通称
        public string? tusyo_kana { get; set; }         //通称_フリガナ
        public string simei_yusen { get; set; }         //氏名_優先
        public string? simei_kana_yusen { get; set; }   //氏名_フリガナ_優先
        public string sex { get; set; }                 //性別
        public string? sexhyoki { get; set; }           //性別表記
        public string? bymd { get; set; }               //生年月日
        public bool? bymd_fusyoflg { get; set; }        //生年月日_不詳フラグ
        public string? bymd_fusyohyoki { get; set; }    //生年月日_不詳表記
        public string zokuhyoki { get; set; }           //住登外：「未設定」
        public string adrs_sikucd { get; set; }         //住所_市区町村コード
        public string adrs_tyoazacd { get; set; }       //住所_町字コード
        public string? tosi_gyoseikucd { get; set; }    //指定都市_行政区等コード
        public string adrs1 { get; set; }               //住所1
        public string? adrs2 { get; set; }              //住所2
        public string? adrs_katagakicd { get; set; }    //住所_方書コード
        public string adrs_yubin { get; set; }          //住所_郵便番号
        public string? personalno { get; set; }         //個人番号		
    }

    /// <summary>
    /// 参照業務リストと参照独自施策システム等リスト用
    /// </summary>
    public class RefListVM
    {
        public string hanyocd { get; set; }             //汎用コード
        public string nm { get; set; }                  //名称
    }

    /// <summary>
    /// 世帯情報モデル
    /// </summary>
    public class SetaiInfoVM
    {
        public string setaino { get; set; }                             //世帯番号
        public string simei_yusen { get; set; }                         //世帯主氏名(氏名_優先)
        public string adrs_yubin { get; set; }                          //住所_郵便番号
        public string? tosi_gyoseikucd { get; set; }                    //指定都市_行政区等コード
        public string adrs_sikucd { get; set; }                         //住所_市区町村コード
        public string adrs_todofuken { get; set; }                      //住所_都道府県
        public string adrs_sikunm { get; set; }                         //住所_市区郡町村名
        public string adrs_tyoazacd { get; set; }                       //住所_町字コード
        public string adrs_tyoaza { get; set; }                         //町字名
        public string adrs_bantihyoki { get; set; }                     //番地号表記
        public string adrs_katagaki_kana { get; set; }                  //方書(フリガナ)   
        public string adrs_katagaki { get; set; }                       //方書(漢字)      
    }

    /// <summary>
    /// 編集状態モデル
    /// </summary>
    public class StatusVM
    {
        public EnumActionType statuskbn { get; set; }   //状態区分
    }

    /// <summary>
    /// 住登外者詳細_基本情報（世帯情報）
    /// </summary>
    public class SeitaiInfoVM
    {
        public string setaino { get; set; }             //世帯番号（I/O）
        public string? adrs_yubin { get; set; }         //郵便番号（I/O）			
        public string? tosi_gyoseikucd { get; set; }    //指定都市_行政区等コード（I/O）
        public string? adrs_sikucd { get; set; }        //市区町村（I/O）			
        public string adrs_tyoazacd { get; set; }       //町字コード（I/O）		
        public string? adrs_tyoaza { get; set; }        //町字名（I/O）				
        public string? adrs_bantihyoki { get; set; }    //番地号表記（I/O）			
        public string? adrs_katagaki_kana { get; set; } //方書(フリガナ)（I/O）			
        public string? adrs_katagaki { get; set; }      //方書(漢字)（I/O）
        public string? adrs_todofuken { get; set; }     //都道府県		
        public string? adrs_sikunm { get; set; }        //市区町村名		
    }

    /// <summary>
    /// 住登外者詳細_基本情報（郵便情報）
    /// </summary>
    public class YubinInfoVM
    {
        public string? adrs_sikucd { get; set; }        //市区町村コード		
        public string adrs_tyoazacd { get; set; }       //町字コード	
        public string? adrs_tyoaza { get; set; }        //町字名				
        public string? adrs_todofuken { get; set; }     //都道府県		
        public string? adrs_sikunm { get; set; }        //市区町村名		
    }


    /// <summary>
    /// 住登外者詳細_基本情報（異動情報）
    /// </summary>
    public class IdoInfoVM
    {
        public string idoymd { get; set; }              //異動年月日
        public string idotodokeymd { get; set; }        //異動届出年月日
        public string idojiyu { get; set; }             //異動事由
    }

    /// <summary>
    /// 住登外者詳細_同一世帯員情報
    /// </summary>
    public class SeitaiDictVM
    {
        public string atenano { get; set; }             //宛名番号
    }

    /// <summary>
    /// 市区町村コード、市区町村全名称、都道府県名称（リスト表示しない）、市区町村名（リスト表示しない）を格納用
    /// 例：市区町村リストの表示内容　
    /// </summary>
    public class DaSelectorModelExp : DaSelectorModel
    {
        public string expname1 { get; set; }   //都道府県名称
        public string expname2 { get; set; }   //市区町村名

        public DaSelectorModelExp(string? value, string? label, string? expname1, string? expname2) : base(value, label)
        {
            this.expname1 = expname1 ?? string.Empty;
            this.expname2 = expname2 ?? string.Empty;
        }
    }
}