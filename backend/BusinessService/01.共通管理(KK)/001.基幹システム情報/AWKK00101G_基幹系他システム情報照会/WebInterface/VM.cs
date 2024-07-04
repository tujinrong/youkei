// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 基幹系他システム情報照会
//             ビューモデル定義
// 作成日　　: 2023.10.03
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using Newtonsoft.Json;

namespace BCC.Affect.Service.AWKK00101G
{
    /// <summary>
    /// 検索処理(一覧画面ベース)
    /// </summary>
    public class RowBaseVM
    {
        public string atenano { get; set; }         //宛名番号
        public string name { get; set; }            //氏名
        public string kname { get; set; }           //カナ氏名
        public string sex { get; set; }             //性別
        public string bymd { get; set; }            //生年月日
        public string juminkbn { get; set; }        //住民区分
        public string keikoku { get; set; }         //警告内容
        public Enum住登区分 jutokbn { get; set; }   //住登区分
    }
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class PersonRowVM : RowBaseVM
    {
        public string adrs { get; set; }        //住所
        public string gyoseiku { get; set; }    //行政区
    }
    /// <summary>
    /// 検索処理(世帯一覧：ヘッダー)
    /// </summary>
    public class SetaiHeaderVM
    {
        public string setaino { get; set; }         //世帯番号
        public string kname { get; set; }           //カナ氏名
        public string name { get; set; }            //氏名
        public string kazeikbn_setai { get; set; }  //課税非課税区分（世帯）
        public string tosi_gyoseiku { get; set; }   //指定都市_行政区等(名称)
        public string adrs_yubin { get; set; }      //郵便番号
        public string adrs { get; set; }            //住所
        public List<TikuVM> tikulist { get; set; }  //地区一覧(ラベル、値)
    }
    /// <summary>
    /// 検索処理(世帯一覧)
    /// </summary>
    public class SetaiRowVM : RowBaseVM
    {
        public string age { get; set; }         //年齢
        public string zokuhyoki { get; set; }   //続柄
        public string hokenkbn { get; set; }    //保険区分
        public string kazeikbn { get; set; }    //課税区分
    }
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class PersonHeaderVM : CommonBarHeaderBase2VM
    {
        public string kazeikbn_setai { get; set; }  //課税非課税区分（世帯）
        public string hokenkbn { get; set; }        //保険区分
    }
    /// <summary>
    /// 住民情報(住基タブ)
    /// </summary>
    public class JuminVM
    {
        public int kojinrirekino { get; set; }                      //個人履歴番号
        public int kojinrireki_edano { get; set; }                  //個人履歴番号_枝番号
        public string upddttm { get; set; }                         //更新日時
        public string saisinflg { get; set; }                       //最新フラグ
        public string setaino { get; set; }                         //世帯番号
        public string senusinm { get; set; }                        //世帯主名(最新)
        [JsonIgnore]
        public string personalno { get; set; }                      //個人番号
        public string atenano { get; set; }                         //宛名番号
        public Enum住民種別 juminsyubetu { get; set; }              //住民種別
        public string juminsyubetunm { get; set; }                  //住民種別(名称)
        public string juminjotai { get; set; }                      //住民状態
        public string simeiyusenkbn { get; set; }                   //氏名優先区分(外国人のみ)
        public string kokunm { get; set; }                          //国籍名等(外国人のみ)
        public string simei_kana { get; set; }                      //氏名_フリガナ
        public string simei { get; set; }                           //氏名
        public string simei_gaikanji { get; set; }                  //氏名_外国人漢字(外国人のみ)
        public string simei_gairoma { get; set; }                   //氏名_外国人ローマ字(外国人のみ)
        public string tusyo_kana { get; set; }                      //通称_フリガナ(外国人のみ)
        public string tusyo { get; set; }                           //通称(外国人のみ)
        public string bymd { get; set; }                            //生年月日(不詳自動変換)
        public string bymd_fusyohyoki { get; set; }                 //生年月日_不詳表記
        public string zokuhyoki { get; set; }                       //続柄表記
        public string kyusi_kana { get; set; }                      //旧氏_フリガナ(日本人のみ)
        public string kyusi { get; set; }                           //旧氏(日本人のみ)
        public string adrs_yubin { get; set; }                      //住所_郵便番号
        public string tosi_gyoseikunm { get; set; }                 //指定都市_行政区等(名称)
        public string adrs_katagaki_kana { get; set; }              //住所_方書_フリガナ
        public string adrs { get; set; }                            //住所(住所_町字、住所_番地号表記、住所_方書)
        public List<TikuVM> tikulist { get; set; }                  //地区一覧(ラベル、値)
        public string kiteikbn { get; set; }                        //第30条45規定区分(外国人のみ)
        public string zairyu { get; set; }                          //在留資格等(名称)(外国人のみ)
        public string zairyu_year { get; set; }                     //在留期間（年）(外国人のみ)
        public string zairyu_month { get; set; }                    //在留期間（月）(外国人のみ)
        public string zairyu_day { get; set; }                      //在留期間（日）(外国人のみ)
        public string zairyumanryoymd { get; set; }                 //在留期間の満了の日(外国人のみ)
        public string juymd { get; set; }                           //住民となった年月日(不詳自動変換)(日本人のみ)
        public string juymd_fusyohyoki { get; set; }                //住民となった年月日_不詳表記(日本人のみ)
        public string gaijuymd { get; set; }                        //外国人住民となった年月日(不詳自動変換)(外国人のみ)
        public string gaijuymd_fusyohyoki { get; set; }             //外国人住民となった年月日_不詳表記(外国人のみ)
        public string tennyututiymd { get; set; }                   //転入通知年月日
        public string delidoymd { get; set; }                       //消除の異動年月日(不詳自動変換)
        public string delidoymd_fusyohyoki { get; set; }            //消除の異動年月日_不詳表記
        public string todokeymd { get; set; }                       //消除の届出年月日
        public string idoymd { get; set; }                          //異動年月日(不詳自動変換)
        public string idoymd_fusyohyoki { get; set; }               //異動年月日_不詳表記
        public string idotodokeymd { get; set; }                    //異動届出年月日
        public string idojiyu { get; set; }                         //異動事由
        public string tennyumaeadrs_yubin { get; set; }             //転入前住所_郵便番号
        public string tennyumaeadrs { get; set; }                   //転入前住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
        public string tennyumaeadrs_kokunm { get; set; }            //転入前住所_国名等
        public string tennyumaeadrs_gaiadrs { get; set; }           //転入前住所_国外住所
        public string tennyumaeadrs_senusisimei { get; set; }       //転入前住所_世帯主氏名
        public string tensyutuyoteiadrs_yubin { get; set; }         //転出先住所（予定）_郵便番号
        public string tensyutuyoteiadrs { get; set; }               //転出先住所（予定）(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
        public string tensyutuyoteiadrs_kokunm { get; set; }        //転出先住所（予定）_国名等
        public string tensyutuyoteiadrs_gaiadrs { get; set; }       //転出先住所（予定）_国外住所
        public string tensyutukakuteiadrs_yubin { get; set; }       //転出先住所（確定）_郵便番号
        public string tensyutukakuteiadrs { get; set; }             //転出先住所（確定）(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
        public string tenkyomaeadrs_yubin { get; set; }             //転居前住所_郵便番号
        public string tenkyomaeadrs_katagaki_kana { get; set; }     //転居前住所_方書_フリガナ
        public string tenkyomaeadrs { get; set; }                   //転居前住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
    }
    /// <summary>
    /// 課税情報(課税・納税義務者タブ)
    /// </summary>
    public class KazeiVM
    {
        public int kazeinendo { get; set; }             //課税年度
        public int kazeirirekino { get; set; }          //課税情報履歴番号
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
        public string kazeikbn { get; set; }            //課税非課税区分
        public string tosi_gyoseiku { get; set; }       //指定都市_行政区等(名称)
    }
    /// <summary>
    /// 納税義務者情報(課税・納税義務者タブ)
    /// </summary>
    public class NozeiVM
    {
        public int kazeinendo { get; set; }             //課税年度
        public int kojinrirekino { get; set; }          //個人履歴番号
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
        public string misinkokukbn { get; set; }        //未申告区分
        public string takazeikbn { get; set; }          //他団体課税対象者区分
        public string takazeisiku { get; set; }         //他団体課税対象者の課税先市区町村(名称)
        public string tosi_gyoseiku { get; set; }       //指定都市_行政区等(名称)
    }
    /// <summary>
    /// 控除情報(税額控除タブ：ヘッダー)
    /// </summary>
    public class KojoHeaderVM
    {
        public int kazeinendo { get; set; }     //課税年度
        public int kojorirekino { get; set; }   //税額控除情報履歴番号
        public string upddttm { get; set; }     //更新日時
        public string saisinflg { get; set; }   //最新フラグ
    }
    /// <summary>
    /// 控除情報(税額控除タブ：明細)
    /// </summary>
    public class KojoRowVM
    {
        public string kojocd { get; set; }          //税額・税額控除コード
        public string kojonm { get; set; }          //税額・税額控除名
        public string tosi_gyoseikunm { get; set; } //指定都市_行政区等(名称)
        public long kojokingaku { get; set; }       //税額控除金額
    }
    /// <summary>
    /// 国保情報(国保タブ)
    /// </summary>
    public class KokuhoVM
    {
        public int hihokensyarirekino { get; set; }             //被保険者履歴番号
        public string upddttm { get; set; }                     //更新日時
        public string saisinflg { get; set; }                   //最新フラグ
        public string sikutyosonhokenjano { get; set; }         //市区町村保険者番号
        public string hokenjanm { get; set; }                   //保険者名称
        public string kokuho_kigono { get; set; }               //国保記号番号
        public string kokuho_edano { get; set; }                //枝番
        public string kokuho_sikakukbn { get; set; }            //国保資格区分
        public string kokuho_sikakusyutokuymd { get; set; }     //国保資格取得年月日
        public string kokuho_sikakusyutokujiyu { get; set; }    //国保資格取得事由
        public string kokuho_sikakusosituymd { get; set; }      //国保資格喪失年月日
        public string kokuho_sikakusositujiyu { get; set; }     //国保資格喪失事由
        public string kokuho_tekiyoymdf { get; set; }           //国保適用開始年月日
        public string kokuho_tekiyoymdt { get; set; }           //国保適用終了年月日
        public string syokbn { get; set; }                      //証区分
        public string yukokigenymd { get; set; }                //有効期限
        public string marugakumaruenkbn { get; set; }           //マル学マル遠区分
    }
    /// <summary>
    /// 後期情報(後期タブ)
    /// </summary>
    public class KokiVM
    {
        public int rirekino { get; set; }                       //履歴番号
        public string upddttm { get; set; }                     //更新日時
        public string saisinflg { get; set; }                   //最新フラグ
        public string hihokensyano { get; set; }                //被保険者番号
        public string kojinkbnnm { get; set; }                  //個人区分(名称)
        public string hiho_sikakusyutokujiyunm { get; set; }    //被保険者資格取得事由(名称)
        public string hiho_sikakusyutokuymd { get; set; }       //被保険者資格取得年月日
        public string hiho_sikakusositujiyunm { get; set; }     //被保険者資格喪失事由(名称)
        public string hiho_sikakusosituymd { get; set; }        //被保険者資格喪失年月日
        public string hoken_tekiyoymdf { get; set; }            //保険者番号適用開始年月日
        public string hoken_tekiyoymdt { get; set; }            //保険者番号適用終了年月日
    }
    /// <summary>
    /// 生保情報(生保タブ)
    /// </summary>
    public class SeihoVM
    {
        public string fukusijimusyocd { get; set; }               //福祉事務所コード
        public string caseno { get; set; }                        //ケース番号
        public int inno { get; set; }                             //員番号
        public int ketteirirekino { get; set; }                   //決定履歴番号

        public int sinseirirekino { get; set; }         //申請履歴番号
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
        public string seihoymdf { get; set; }           //生活保護開始年月日
        public string teisiymd { get; set; }            //停止年月日
        public string teisikaijoymd { get; set; }       //停止解除年月日
        public string tanheikyukbn { get; set; }        //単併給区分(名称)
        public bool seikatufujoflg { get; set; }        //生活扶助フラグ
        public bool jutakufujoflg { get; set; }         //住宅扶助フラグ
        public bool kyoikufujoflg { get; set; }         //教育扶助フラグ
        public bool iryofujoflg { get; set; }           //医療扶助フラグ
        public bool syussanfujoflg { get; set; }        //出産扶助フラグ
        public bool seigyofujoflg { get; set; }         //生業扶助フラグ
        public bool sosaifujoflg { get; set; }          //葬祭扶助フラグ
        public string haisiymd { get; set; }            //廃止年月日
    }
    /// <summary>
    /// 介護情報(介護タブ)
    /// </summary>
    public class KaigoVM
    {
        public int sikakurirekino { get; set; }         //資格履歴番号
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
        public string kaigohokensyano { get; set; }     //介護保険者番号
        public string hihokensyano { get; set; }        //被保険者番号
        public string hihokensyakbn { get; set; }       //被保険者区分(名称)
        public string sikakusyutokuymd { get; set; }    //資格取得日
        public string sikakusosituymd { get; set; }     //資格喪失日
        public string yokaigoninteijokyo { get; set; }  //要介護認定状況(名称)
        public string yokaigojotaikbn { get; set; }     //要介護状態区分(名称)
        public string yokaigoninteiymd { get; set; }    //要介護認定日
        public string yokaigoyukoymdf { get; set; }     //要介護認定有効期間開始日
        public string yokaigoyukoymdt { get; set; }     //要介護認定有効期間終了日
        public string kohijukyusyano { get; set; }      //公費受給者番号
    }
    /// <summary>
    /// 障害情報(福祉タブ)
    /// </summary>
    public class SyogaiVM
    {
        public int rirekino { get; set; }           //履歴番号
        public string upddttm { get; set; }         //更新日時
        public string saisinflg { get; set; }       //最新フラグ
        public string sikakujotai { get; set; }     //資格状態(名称)
        public string tetyono { get; set; }         //手帳番号
        public string syokaikofuymd { get; set; }   //初回交付日
        public string henkanymd { get; set; }       //返還日
        public string syogaisyubetu { get; set; }   //障害種別(名称)
        public string sogotokyu { get; set; }       //総合等級(名称)
        public string tokeibui { get; set; }        //統計部位(名称)
        public string syogainm { get; set; }        //障害名
    }
    /// <summary>
    /// 地区モデル
    /// </summary>
    public class TikuVM
    {
        public string tikukbn { get; set; } //地区区分(名称)
        public string tiku { get; set; }    //地区(名称)
    }
}