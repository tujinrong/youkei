// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理
//             レスポンスインターフェース
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.BH_kosin_ninsanpu
{
    /// <summary>
    /// 初期表示処理
    /// </summary>
    public class FormInit1Response : DaResponseBase
    {
        public string msyoricd { get; set; }                      // システムコード
        public string murl { get; set; }                          // affect.htmlのURL
        public List<SQLKkkikan> kikan { get; set; }               // 分娩場所/実施機関
        public List<SQLKkstaffSub> isi { get; set; }              // 医師(医師名)
        public List<SQLKkstaffSub> staff { get; set; }            // 医師(医師名)スタッフ(担当保健師/母子推進委員/担当者)
        public List<SQLKkcf1> umu { get; set; }                   // 貧血/偏食/産婦訪問/妊娠高血圧症候群
        public List<SQLKkcf1> hoken { get; set; }                 // 保険区分
        public List<SQLKkcf1> sinkikofu { get; set; }             // 新規交付
        public List<SQLKkcf1> hakkokubun { get; set; }            // 発行区分
        public List<SQLKkcf1> hakkobasyo { get; set; }            // 発行場所
        public List<SQLKkcf1> kinmukubn { get; set; }             // 勤務区分
        public List<SQLKkcf1> thoho { get; set; }                 // 通勤方法
        public List<SQLKkcf1> kenko { get; set; }                 // 子供の健康状態
        public List<SQLKkcf1> ninsinrekikubun { get; set; }       // 妊娠歴区分
        public List<SQLKkcf1> sizenjinkokubun { get; set; }       // 自然・人工
        public List<SQLKkcf1> jyukyo { get; set; }                // 住居情報
        public List<SQLKkcf1> soon { get; set; }                  // 騒音
        public List<SQLKkcf1> hiatari { get; set; }               // 日当り
        public List<SQLKkcf1> sikkan { get; set; }                // 疾患有無
        public List<SQLKkcf1> nyoken { get; set; }                // 尿（糖）/尿（蛋白）/尿（潜血）/浮腫
        public List<SQLKkcf1> snaiyo { get; set; }                // 主訴　内容
        public List<SQLKkcf1> syojyo { get; set; }                // 症状
        public List<SQLKkcf1> sippei { get; set; }                // 疾病名
        public List<SQLKkcf1> hnaiyo { get; set; }                // 保健指導 要管理内容
        public List<SQLKkcf1> hfhouhou { get; set; }              // 保健指導 フォロー方法
        public List<SQLKkcf1> insyu { get; set; }                 // 飲酒種類
        public List<SQLKkcf1> eiyo { get; set; }                  // 栄養強化対象
        public List<SQLKkcf1> gyunyu { get; set; }                // 牛乳
        public List<SQLKkcf1> sidonaiyo { get; set; }             // 指導内容
        public List<SQLKkcf1> kenkaisu { get; set; }              // 妊婦健診回数
        public List<SQLKkcf1> yosan { get; set; }                 // 予算区分
        public List<SQLKkcf1> khosiki { get; set; }               // 検診方式
        public List<SQLKkcf1> kkekka { get; set; }                // 検査結果
        public List<SQLKkcf1> sikyukekka { get; set; }            // 子宮がん結果
        public List<SQLKkcf1> siksikkan { get; set; }             // 疾患名
        public List<SQLKkcf1> tken { get; set; }                  // 超音波検査
        public List<SQLKkcf1> tkekka { get; set; }                // 超音波結果
        public List<SQLKkcf1> hatuiku { get; set; }               // 胎児発育評価検査
        public List<SQLKkcf1> hantei { get; set; }                // 総合判定/判定
        public List<SQLKkcf1> nyuin { get; set; }                 // 入院
        public List<SQLKkcf1> byomei1 { get; set; }               // 病名１
        public List<SQLKkcf1> byomei2 { get; set; }               // 病名２
        public List<SQLKkcf1> byomei3 { get; set; }               // 病名３
        public List<SQLKkcf1> byomei4 { get; set; }               // 病名４
        public List<SQLKkcf1> renraku { get; set; }               // 市町村連絡事項
        public List<SQLKkcf1> sinjokyo { get; set; }              // 身体の状況
        public List<SQLKkcf1> kibun { get; set; }                 // 気分の異常
        public List<SQLKkcf1> gekkei { get; set; }                // 月経開始時期
        public List<SQLKkcf1> fusyu { get; set; }                 // 検査結果（浮腫）
        public SQLGyoResponse mjgyo { get; set; }                 // 詳細検索（妊婦）行政区
        public SQLKkcf1 jkbn { get; set; }                        // 詳細検索（妊婦）住民区分指定
        public SQLKkcf1 syohantei { get; set; }                   // 詳細検索（妊婦）妊婦健診判定指定
        public List<SQLKkcf1> tncheck { get; set; }               // 特定妊婦チェック該当/非該当
        public List<SQLKkcf1> tnchecklabels { get; set; }         // 特定妊婦チェックリスト項目名一覧
        public List<SQLKkcf1> tncheck100 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck200 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck300 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck400 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck500 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck600 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck700 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck800 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck900 { get; set; }            // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck1000 { get; set; }           // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck1100 { get; set; }           // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tncheck1200 { get; set; }           // 特定妊婦チェックリスト情報
        public List<SQLKkcf1> tnhoho { get; set; }                // 特定妊婦支援計画　方法
        public List<SQLKkcf1> tnhinagata { get; set; }            // 特定妊婦支援計画　雛型
        public List<SQLKkcf1> tnkekka { get; set; }               // 特定妊婦支援計画　評価結果
        public List<SQLKkcf1> tnhohomain { get; set; }            // 特定妊婦支援計画　主なフォロー方法
        public string jujncheck { get; set; }                     // 健診日、住民日付チェック
        public SQLGetTC_BHKKITEM nsitem { get; set; }             // 妊産婦動的項目管理マスタより抽出
        public List<SQLGetKKITEM_CFCD> cfmap { get; set; }        // 動的項目　コンボボックスの値
        public List<SQLBHGetFreeList2> cfmap1 { get; set; }       // フリー項目リスト内容(TC_KKTIKU用大字)
        public List<SQLBHGetFreeList2> cfmap2 { get; set; }       // フリー項目リスト内容(TC_KKTIKU用行政区)
        public List<SQLBHGetFreeList2> cfmap3 { get; set; }       // フリー項目リスト内容(TC_KKTIKU用納組)
        public List<SQLBHGetFreeList2> cfmap4 { get; set; }       // フリー項目リスト内容(TC_KKTIKU用小学校区)
        public List<SQLBHGetFreeList2> cfmap5 { get; set; }       // フリー項目リスト内容(TC_KKTIKU用中学校区)
        public List<SQLBHGetFreeList3> cfmap6 { get; set; }       // フリー項目リスト内容(TC_KKKIKAN用)
        public List<SQLBHGetFreeList4> cfmap7 { get; set; }       // フリー項目リスト内容(TC_KKSTAFF用)
        public List<SQLKkcf1> mfreeg { get; set; }                // フリー項目グループ（コンボボックス用）
        public List<SQLKkcf1> mfreeg2 { get; set; }               // フリー項目グループ２（コンボボックス用）
        public SQLBhGetFitem mfree { get; set; }                  // フリー項目
        public SQLBhGetFlist1 mfreecf1 { get; set; }              // フリー項目リスト内容(TC_KKCF用)
        public SQLBhGetFlist2 mfreecf2 { get; set; }              // フリー項目リスト内容(TC_KKTIKU用)
        public SQLBhGetFlist3 mfreecf3 { get; set; }              // フリー項目リスト内容(TC_KKKIKAN用)
        public SQLBhGetFlist4 mfreecf4 { get; set; }              // フリー項目リスト内容(TC_KKSTAFF用)
        public List<SQLKkcf1> mfreeonlineg { get; set; }          // オンライン申請情報グループ（コンボボックス用）
        public List<SQLKkcf1> mfreeonlineg2 { get; set; }         // オンライン申請情報グループ２（コンボボックス用）
        public SQLBhGetFitem mfreeonline { get; set; }            // オンライン申請情報フリー項目
        public SQLBhGetFlist1 mfreeonlinecf1 { get; set; }        // オンライン申請情報フリー項目リスト内容(TC_KKCF用)
        public SQLBhGetFlist2 mfreeonlinecf2 { get; set; }        // オンライン申請情報フリー項目リスト内容(TC_KKTIKU用)
        public SQLBhGetFlist3 mfreeonlinecf3 { get; set; }        // オンライン申請情報フリー項目リスト内容(TC_KKKIKAN用)
        public SQLBhGetFlist4 mfreeonlinecf4 { get; set; }        // オンライン申請情報フリー項目リスト内容(TC_KKSTAFF用)
        public SQLGetPAuthority mpadauth { get; set; }            // 各種権限取得
        public string enabled { get; set; }                       // （個人）権限
        public string enabled1 { get; set; }                      // 総合支援情報管理権限
        public SQLGetMADAuthority mmadauth { get; set; }          // メモ・ドキュメント機能の権限
        public string mmsgflg { get; set; }                       // 除票者メッセージフラグ
        public string monpushuse { get; set; }                    // プッシュ通知希望情報使用/未使用制御
        public string mgenoauth { get; set; }                     // ジェノグラム使用権限
        public string mkazokuauth { get; set; }                   // 家族構成使用権限
        public string mbhhokatu { get; set; }                     // 子育て世代包括支援機能使用/未使用制御
        public string mbhkojindaichou { get; set; }               // 個人台帳ボタン(妊産婦)の使用/未使用設定情報
        public string mbhsanputitle1 { get; set; }                // 産婦健康診査情報(上段)名称設定
        public string mbhsanputitle2 { get; set; }                // 産婦健康診査情報(下段)名称設定
    }

    /// <summary>
    /// 機関マスタ取得SQL
    /// </summary>
    public class SQLKkkikan
    {
        public string data { get; set; }                 // データコード
        public string label { get; set; }                // 内容
    }

    /// <summary>
    /// スタッフマスタ取得SQL
    /// </summary>
    public class SQLKkstaffSub
    {
        public string data { get; set; }                 // データコード
        public string label { get; set; }                // 内容
    }

    /// <summary>
    /// CFを抽出するためのSQL文を返す。
    /// </summary>
    public class SQLKkcf1
    {
        public string data { get; set; }                 // データコード
        public string label { get; set; }                // 内容
        public string biko { get; set; }                 // 備考
        public string kbn1 { get; set; }                 // 課税区1
        public string kbn2 { get; set; }                 // 課税区2
        public string kbn3 { get; set; }                 // 課税区3
        public int keta { get; set; }                    // 桁数
    }

    /// <summary>
    /// 行政区を抽出するためのSQL文を返す。
    /// </summary>
    public class SQLGyoResponse
    {
        public string data { get; set; }                 // データコード
        public string label { get; set; }                // 内容
        public string filteritem { get; set; }           // 管轄コード
    }

    /// <summary>
    /// 動的項目情報取得SQL
    /// </summary>
    public class SQLGetTC_BHKKITEM
    {
        public string BOSIKBN { get; set; }              // 母子保健区分
        public string GETUKAIKBN { get; set; }           // 月齢回数区分
        public string KENSINKBN { get; set; }            // 健診区分
        public string ITEMCD { get; set; }               // 項目ＣＤ
        public int ITEMEDA { get; set; }                 // 項目枝番
        public string ITEMNM { get; set; }               // 項目名称
        public string DATATYPE { get; set; }             // データタイプ
        public string TANI { get; set; }                 // 単位
        public int CFID { get; set; }                    // コントロールファイルＩＤ
        public string CFMAINCD { get; set; }             // ＣＦメインＣＤ
        public string CFSUBCD { get; set; }              // ＣＦサブＣＤ
        public string SYOKITI { get; set; }              // 初期値
        public int NARABI { get; set; }                  // 並び順
        public string SIYOFLG { get; set; }              // 使用フラグ
        public int BNENDO { get; set; }                  // 母子手帳年度
        public Int32 BKOFUNO { get; set; }               // 母子手帳交付番号
        public int EDANO { get; set; }                   // 枝番号
        public string KENKAISU { get; set; }             // 健診回数
        public string DATATYPE1 { get; set; }            // データタイプ１
        public string DATATYPE2 { get; set; }            // データタイプ２
        public float DATATYPE3 { get; set; }             // データタイプ３
        public string DATATYPE4 { get; set; }            // データタイプ４
        public DateTime DATATYPE5 { get; set; }          // データタイプ５
    }

    /// <summary>
    /// 動的項目で使用するコンボボックスのMAINCDとSUBCDを取得するSQL
    /// </summary>
    public class SQLGetKKITEM_CFCD
    {
        public int cfid { get; set; }                         // コントロールファイルＩＤ
        public string cfmaincd { get; set; }                  // ＣＦメインＣＤ
        public string cfsubcd { get; set; }                   // ＣＦサブＣＤ
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKTIKU用)取得用SQL作成。
    /// </summary>
    public class SQLBHGetFreeList2
    {
        public string maincd { get; set; }                     // ＣＦメインＣＤ
        public string data { get; set; }                       // データコード
        public string label { get; set; }                      // 名称
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKKIKAN用)取得用SQL作成。
    /// </summary>
    public class SQLBHGetFreeList3
    {
        public string data { get; set; }                       // 機関コード
        public string label { get; set; }                      // 機関名称
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKSTAFF用)取得用SQL作成。
    /// </summary>
    public class SQLBHGetFreeList4
    {
        public string data { get; set; }                       // スタッフコード
        public string label { get; set; }                      // スタッフ名称
    }

    /// <summary>
    /// フリー項目取得用SQL作成。
    /// </summary>
    public class SQLBhGetFitem
    {
        public string GROUPID { get; set; }                     // グループＩＤ
        public string GROUPID2 { get; set; }                    // グループＩＤ２
        public string GROUPNM { get; set; }                     // グループ名称
        public string ITEMCD { get; set; }                      // 項目ＣＤ
        public int DATATYPE { get; set; }                       // データタイプ
        public int CFID { get; set; }                           // コントロールファイルＩＤ
        public string MAINCD { get; set; }                      // メインＣＤ
        public string SUBCD { get; set; }                       // サブＣＤ
        public string BIKO { get; set; }                        // 備考
        public string INPUTDATA { get; set; }                   // 入力データ
        public string NAIYO { get; set; }                       // 内容
        public int HISSU { get; set; }                          // 必須チェック
        public string VALDATA { get; set; }                     // 初期値
        public int SEISUKETA { get; set; }                      // 整数部桁数
        public int SYOSUKETA { get; set; }                      // 小数部桁数
        public int ORDERID { get; set; }                        // 並び替え用
        public string KENSINKBN { get; set; }                   // 健診区分
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKCF用)取得用SQL作成。
    /// </summary>
    public class SQLBhGetFlist1
    {
        public string maincd { get; set; }                     // メインＣＤ
        public string subcd { get; set; }                      // サブＣＤ
        public string cd { get; set; }                         // データコード
        public string naiyo { get; set; }                      // 内容
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKTIKU用)取得用SQL作成。
    /// </summary>
    public class SQLBhGetFlist2
    {
        public string maincd { get; set; }                     // メインＣＤ
        public string cd { get; set; }                         // データコード
        public string naiyo { get; set; }                      // 内容
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKKIKAN用)取得用SQL作成。
    /// </summary>
    public class SQLBhGetFlist3
    {
        public string cd { get; set; }                         // データコード
        public string naiyo { get; set; }                      // 内容
    }

    /// <summary>
    /// フリー項目リスト内容(TC_KKSTAFF用)取得用SQL作成。
    /// </summary>
    public class SQLBhGetFlist4
    {
        public string cd { get; set; }                         // データコード
        public string naiyo { get; set; }                      // 内容
    }

    /// <summary>
    ///  個人番号・帳票の操作権限を取得するSQLを返却する
    /// </summary>
    public class SQLGetPAuthority
    {
        public string pnoflg { get; set; }                      // 個人番号フラグ
        public string paeflg { get; set; }                      // 帳票出力権限(PDF・EXCEL)フラグ
        public string csvflg { get; set; }                      // 帳票出力権限(CSV)フラグ
    }

    /// <summary>
    ///  メモ機能・ドキュメント管理機能の操作権限を取得する
    /// </summary>
    public class SQLGetMADAuthority
    {
        public string memoflg { get; set; }                     // メモ機能使用フラグ
        public string docflg { get; set; }                      // ドキュメント管理機能使用フラグ
    }

    /// <summary>
    /// 妊産婦情報入力で使用するデータを抽出する。
    /// </summary>
    public class Kensaku2Response : DaResponseBase
    {
        public SQLGetNyuryokuKensaku mparam { get; set; }          // 母子手帳番号
        public string cmeisai { get; set; }                        // 検索ヒット件数
        public string haita { get; set; }                          // 検索結果が1件
        public SQLGetSyussyo syuseireki { get; set; }              // 出生歴
        public SQLGetNinsinreki ninsinreki { get; set; }           // 妊娠歴
        public SQLGetDokyo dokyo { get; set; }                     // 家族環境・同居の家族
        public SQLGetSyuso syuso { get; set; }                     // 主訴
        public SQLGetGakkyu gakkyu { get; set; }                   // 母親学級
        public SQLGetSippei sippei { get; set; }                   // 現在の疾病治療状況
        public SQLGetSido hokensido { get; set; }                  // 保健指導
        public SQLGetYokanri yokanri { get; set; }                 // 要管理内容
        public SQLGetMonsin monsin { get; set; }                   // 問診の入力内容
        public SQLGetNinpukensin ninken { get; set; }              // 妊婦健診マスタより抽出
        public SQLGetTC_BHKKITEM nsitem { get; set; }              // 妊産婦動的項目管理マスタより抽出
        public List<SQLGetKKITEM_CFCD> cfmap { get; set; }         // コンボボックスの値を取得
        public List<SQLBHGetFreeList2> cfmap1 { get; set; }        // フリー項目リスト内容(TC_KKTIKU用大字)
        public List<SQLBHGetFreeList2> cfmap2 { get; set; }        // フリー項目リスト内容(TC_KKTIKU用行政区)
        public List<SQLBHGetFreeList2> cfmap3 { get; set; }        // フリー項目リスト内容(TC_KKTIKU用納組)
        public List<SQLBHGetFreeList2> cfmap4 { get; set; }        // フリー項目リスト内容(TC_KKTIKU用小学校区)
        public List<SQLBHGetFreeList2> cfmap5 { get; set; }        // フリー項目リスト内容(TC_KKTIKU用中学校区)
        public List<SQLBHGetFreeList3> cfmap6 { get; set; }        // フリー項目リスト内容(TC_KKKIKAN用)
        public List<SQLBHGetFreeList4> cfmap7 { get; set; }        // フリー項目リスト内容(TC_KKSTAFF用)
        public SQLGetSanpu sanpu { get; set; }                     // 産婦健診マスタより抽出
        public string mmemomsg { get; set; }                       // メモ情報有無メッセージフラグ
        public SQLMemo mmemof { get; set; }                        // メモの入力内容があるか確認する
        public int mdocf { get; set; }                             // ドキュメント管理情報有無取得
        public string mdvmsg { get; set; }                         // 世帯DV対象者取得処理
        public SQLGetKojin mkojin { get; set; }                    // 個人照会
        public SQLSetaiKosei msetai { get; set; }                  // 世帯構成員情報取得
        public SQLGetTetyobango mtetyo { get; set; }               // 母子手帳番号一覧取得
        public int mpushf { get; set; }                            // プッシュ通知希望情報有無取得
        public int mgenof { get; set; }                            // ジェノグラム情報有無取得
        public int mkazokuf { get; set; }                          // 家族構成情報取得
        public int mhomonf { get; set; }                           // 訪問指導情報の有無を取得する
        public int msodanf { get; set; }                           // 健康相談情報の有無を取得する
        public int mkkikanf { get; set; }                          // 関係機関情報取得
        public SQLGetKojinNinpukensin mninken { get; set; }        // 妊婦健診情報
        public SQLGetKojinYokanri myokanri { get; set; }           // 要管理内容
        public string mykmsg { get; set; }                         // 要管理内容有メッセージ表示フラグ
        public SQLBhNsGetKojinFree mfree { get; set; }             // フリー項目取得
        public SQLBhNsGetKojinFree mfreeonline { get; set; }       // オンライン申請情報取得
        public SQLGetKojinSien sien { get; set; }                  // 支援計画内容
        public SQLGetKojinSienPlan sienplan { get; set; }          // 支援計画プラン内容
        public string siensub { get; set; }                        // 支援計画内容(LISTへのチェック部分)
        public string kensaku { get; set; }                        // 妊産婦検索　一覧情報を取得する

    }

    /// <summary>
    /// 妊産婦発行情報管理マスタ,妊産婦基本情報管理マスタ,妊産婦住登外父母情報管理マスタ取得SQL
    /// </summary>
    public class SQLGetNyuryokuKensaku
    {
        public int BNENDO { get; set; }                            // 母子手帳年度
        public Int32 BKOFUNO { get; set; }                         // 母子手帳交付番号
        public int BEDANO { get; set; }                            // 母子手帳枝番
        public string JUNI { get; set; }                           // 出生順位
        public string HESINKI { get; set; }                        // 新規交付
        public Boolean HEKETUFLG { get; set; }                     // 血族結婚フラグ
        public string HEMKOJINNO { get; set; }                     // 母整理番号
        public string HEFKOJINNO { get; set; }                     // 父整理番号
        public string HSSATO { get; set; }                         // 里帰り
        public string HSADRS { get; set; }                         // 里帰り住所
        public string HSSNNAME { get; set; }                       // 里帰り世帯主
        public string HSTEL { get; set; }                          // 里帰り電話番号
        public string HEHOMON { get; set; }                        // 訪問希望
        public string HEHOKENSI { get; set; }                      // 担当保健師
        public string HESUISIN { get; set; }                       // 母子推進委員
        public Boolean HETUTIFLG { get; set; }                     // 通知希望フラグ
        public Boolean HEMUKOFLG { get; set; }                     // 無効フラグ
        public string HEMUKORIYU { get; set; }                     // 無効理由
        public DateTime HETODOKYMD { get; set; }                   // 届出年月日
        public string HESYUSU { get; set; }                        // 妊娠週数
        public Boolean HEBUNFLG { get; set; }                      // 分娩後フラグ
        public string HEHOKEN { get; set; }                        // 保険区分
        public Boolean HEHONFLG { get; set; }                      // 本人フラグ
        public DateTime HEGEKKEYMD { get; set; }                   // 最終月経年月日
        public string HETETYOS { get; set; }                       // 市手帳
        public string HETETYOK { get; set; }                       // 県手帳
        public DateTime HEYOTEIYMD { get; set; }                   // 分娩予定年月日
        public string HEYOTEI { get; set; }                        // 分娩予定場所
        public string HEYOTEITA { get; set; }                      // 分娩予定場所その他
        public string HEHAKKOKBN { get; set; }                     // 発行区分
        public string HEHAKKO { get; set; }                        // 発行場所
        public string KMKSAKI { get; set; }                        // 勤務先
        public string KMKINMU { get; set; }                        // 勤務区分
        public string KMKTEL { get; set; }                         // 勤務先電話番号
        public int KMBKYUKA { get; set; }                          // 出産前休暇週数
        public int KMAKYUKA { get; set; }                          // 出産後休暇週数
        public DateTime KMTAIYMD { get; set; }                     // 退職予定年月日
        public string KMIKUJI { get; set; }                        // 育児休業
        public string KMSIGOTO { get; set; }                       // 仕事内容
        public string KMTHOHO { get; set; }                        // 通勤方法
        public int KMTJIKAN { get; set; }                          // 通勤時間
        public string KZPET { get; set; }                          // ペット
        public string KZPCMNT { get; set; }                        // ペットコメント
        public string KZENMEI { get; set; }                        // 園名
        public string KZJUKYO { get; set; }                        // 住居
        public int KZKTATE { get; set; }                           // 階建
        public int KZKSU { get; set; }                             // 階数
        public string KZSOON { get; set; }                         // 騒音
        public string KZHIATARI { get; set; }                      // 日当り
        public string NKSIKKAN { get; set; }                       // 既往疾患
        public string NKSIKKANTA { get; set; }                     // 既往疾患その他
        public string NKKOUKETUATU { get; set; }                   // 妊娠高血圧症候群
        public string NKTYUDOKU { get; set; }                      // 妊娠中毒
        public string NKHBS { get; set; }                          // 妊娠ＨＢＳ抗原
        public string NKSANJOKU { get; set; }                      // 妊娠産褥期
        public string NKATL { get; set; }                          // ＡＴＬ
        public string NKKIOTA { get; set; }                        // 既往その他
        public float STSINTYO { get; set; }                        // 身長
        public float STTAIJUN { get; set; }                        // 体重妊娠前
        public float STTAIJUB { get; set; }                        // 体重分娩時
        public float STBMI { get; set; }                           // ＢＭＩ
        public string HSKYORYOKU { get; set; }                     // 育児協力
        public string HSKYOSYA { get; set; }                       // 協力者
        public string HSTANTO1 { get; set; }                       // 保健指導担当者１
        public string HSTANTO2 { get; set; }                       // 保健指導担当者２
        public string HSSAKESYU { get; set; }                      // 飲酒種類
        public float HSSAKERYO { get; set; }                       // 飲酒量
        public int HSHONSU { get; set; }                           // 喫煙数
        public string HSEIYO { get; set; }                         // 栄養強化対象
        public string HSHENSYOKU { get; set; }                     // 偏食
        public string HSGYU { get; set; }                          // 牛乳
        public float HSGYURYO { get; set; }                        // 牛乳量
        public string HSCMNT { get; set; }                         // 保健指導コメント
        public string SOGOCMNT { get; set; }                       // 総合コメント
        public string HAHAKOJINNO { get; set; }                    // 母整理番号
        public string HAHASETAINO { get; set; }                    // 母世帯番号
        public string JKBN { get; set; }                           // 住民区分
        public string HAHAKNAME { get; set; }                      // 母カナ氏名
        public string HAHANAME { get; set; }                       // 母氏名母
        public DateTime HAHABYMD { get; set; }                     // 母生年月日
        public string HAHAAGE { get; set; }                        // 母年齢
        public string BUNBENAGE { get; set; }                      // 分娩予定年齢
        public string HAHAKETUEKI { get; set; }                    // 母血液型
        public string HAHAADRS { get; set; }                       // 母住所
        public string HAHATEL { get; set; }                        // 母電話番号
        public string HAHAFAX { get; set; }                        // 母ＦＡＸ
        public string HAHAGYO { get; set; }                        // 母行政区
        public string HAHATEL1 { get; set; }                       // 母電話番号１
        public string HAHAMADRS1 { get; set; }                     // 母メールアドレス１
        public string HAHATEL2 { get; set; }                       // 母電話番号２
        public string HAHAMADRS2 { get; set; }                     // 母メールアドレス２
        public string DVFLG { get; set; }                          // ＤＶフラグ
        public string TITIKOJINNO { get; set; }                    // 父整理番号
        public string TITISETAINO { get; set; }                    // 父世帯番号
        public string TITIKNAME { get; set; }                      // 父カナ氏名
        public string TITINAME { get; set; }                       // 父氏名
        public DateTime TITIBYMD { get; set; }                     // 父生年月日
        public string TITIAGE { get; set; }                        // 父年齢
        public string TITIKETUEKI { get; set; }                    // 父血液型
        public string TITIADRS { get; set; }                       // 父住所
        public string TITITEL { get; set; }                        // 父電話番号
        public string TITIFAX { get; set; }                        // 父ＦＡＸ
        public string TITIGYO { get; set; }                        // 父行政区
        public string TITITEL1 { get; set; }                       // 父電話番号１
        public string TITIMADRS1 { get; set; }                     // 父メールアドレス１
        public string TITITEL2 { get; set; }                       // 父電話番号２
        public string TITIMADRS2 { get; set; }                     // 父メールアドレス２
        public string TITISYOKU { get; set; }                      // 父職業
        public string TITIKAISYA { get; set; }                     // 父勤務先
        public string TATAI { get; set; }                          // 多胎妊娠
        public string KOKOJINNO { get; set; }                      // 子整理番号
        public string KOSETAINO { get; set; }                      // 子世帯番号
        public string KONAME { get; set; }                         // 子氏名
        public string KOADRS { get; set; }                         // 子住所
        public string KOTEL1 { get; set; }                         // 子電話番号１
        public string KOMADRS1 { get; set; }                       // 子メールアドレス１
        public string KOTEL2 { get; set; }                         // 子電話番号２
        public string KOMADRS2 { get; set; }                       // 子メールアドレス２
        public string KOTEL { get; set; }                          // 子電話番号
        public string KOFAX { get; set; }                          // 子ＦＡＸ
        public string HOGOKOJINNO { get; set; }                    // 保護整理番号
        public string HOGOKNAME { get; set; }                      // 保護カナ氏名
        public string HOGONAME { get; set; }                       // 保護氏名
        public DateTime HOGOBYMD { get; set; }                     // 保護生年月日
        public string HOGOAGE { get; set; }                        // 保護年齢
        public string HOGOADRS { get; set; }                       // 保護住所
        public string HOGOTEL { get; set; }                        // 保護電話番号
        public string HOGOZOKUNM { get; set; }                     // 保護属氏名
    }

    /// <summary>
    /// 個人妊産婦出生歴管理マスタ取得SQL
    /// </summary>
    public class SQLGetSyussyo
    {
        public int bnendo { get; set; }                            // 母子手帳年度
        public Int32 bkofuno { get; set; }                         // 母子手帳交付番号
        public string edano { get; set; }                          // 枝番号
        public int juni { get; set; }                              // 出生順位
        public string kojinno { get; set; }                        // 整理番号
        public int nenrei { get; set; }                            // 母親年齢
        public int taiju { get; set; }                             // 出生時体重
        public int nsyusu { get; set; }                            // 妊娠週数
        public string ijo { get; set; }                            // 妊婦異常
        public string kenko { get; set; }                          // 子健康状態
        public string biko { get; set; }                           // 備考
    }

    /// <summary>
    /// 個人妊妊産婦妊娠歴管理マスタ取得SQL
    /// </summary>
    public class SQLGetNinsinreki
    {
        public int bnendo { get; set; }                            // 母子手帳年度
        public Int32 bkofuno { get; set; }                         // 母子手帳交付番号
        public int edano { get; set; }                             // 枝番号
        public int rowno { get; set; }                             // 出生順位
        public string kojinno { get; set; }                        // 整理番号
        public DateTime ninsinymd { get; set; }                    // 妊娠年月日
        public string nrekicd { get; set; }                        // 妊娠歴ＣＤ
        public string jinkosizen { get; set; }                     // 人工自然
        public int nsyusu { get; set; }                            // 妊娠週数
        public string biko { get; set; }                           // 備考
    }

    /// <summary>
    /// 妊産婦同居管理マスタ取得SQL
    /// </summary>
    public class SQLGetDokyo
    {
        public int bnendo { get; set; }                            // 母子手帳年度
        public Int32 bkofuno { get; set; }                         // 母子手帳交付番号
        public int edano { get; set; }                             // 枝番号
        public int rowno { get; set; }                             // 行番号
        public string simei { get; set; }                          // 氏名
        public int nenrei { get; set; }                            // 年齢
        public string tuzuki { get; set; }                         // 続柄
        public Boolean hoikuflg { get; set; }                      // 昼間保育者フラグ
        public Boolean soudanflg { get; set; }                     // 育児相談フラグ
        public Boolean kyoryokflg { get; set; }                    // 育児協力フラグ
        public string biko { get; set; }                           // 備考
    }

    /// <summary>
    /// 妊産婦主訴管理マスタ取得SQL
    /// </summary>
    public class SQLGetSyuso
    {
        public int bnendo { get; set; }                         // 母子手帳年度
        public Int32 bkofuno { get; set; }                      // 母子手帳交付番号
        public int edano { get; set; }                          // 枝番号
        public string naiyocd { get; set; }                     // 内容ＣＤ
        public string sido { get; set; }                        // 指導事項
    }

    /// <summary>
    /// 妊産婦母親学級管理マスタ取得SQL
    /// </summary>
    public class SQLGetGakkyu
    {
        public int bnendo { get; set; }                           // 母子手帳年度
        public Int32 bkofuno { get; set; }                        // 母子手帳交付番号
        public int edano { get; set; }                            // 枝番号
        public DateTime sankaymd { get; set; }                    // 参加年月日
        public int maxketu { get; set; }                          // 最高血圧
        public int minketu { get; set; }                          // 最低血圧
        public string to { get; set; }                            // 糖
        public string tanpaku { get; set; }                       // 蛋白
        public string senketu { get; set; }                       // 潜血
        public string hsyojo { get; set; }                        // 症状
        public string cmnt { get; set; }                          // コメント
    }

    /// <summary>
    /// 妊産婦疾病状況管理マスタ取得SQL
    /// </summary>
    public class SQLGetSippei
    {
        public int bnendo { get; set; }                           // 母子手帳年度
        public Int32 bkofuno { get; set; }                        // 母子手帳交付番号
        public int edano { get; set; }                            // 枝番号
        public string sippeicd { get; set; }                      // 疾病ＣＤ
        public string tiryo { get; set; }                         // 治療
        public string nyuin { get; set; }                         // 入院
        public string biko { get; set; }                          // 備考
    }

    /// <summary>
    /// 妊産婦保健指導管理マスタ取得SQL
    /// </summary>
    public class SQLGetSido
    {
        public int bnendo { get; set; }                           // 母子手帳年度
        public Int32 bkofuno { get; set; }                        // 母子手帳交付番号
        public int edano { get; set; }                            // 枝番号
        public string sidocd { get; set; }                        // 指導ＣＤ
        public DateTime sidoymd { get; set; }                     // 指導年月日
        public string tanto1 { get; set; }                        // 担当者１
        public string tanto2 { get; set; }                        // 担当者２
        public string cmnt { get; set; }                          // コメント
        public string sonota { get; set; }                        // その他
    }

    /// <summary>
    /// 妊産婦要管理内容管理マスタ取得SQL
    /// </summary>
    public class SQLGetYokanri
    {
        public int bnendo { get; set; }                           // 母子手帳年度
        public Int32 bkofuno { get; set; }                        // 母子手帳交付番号
        public int edano { get; set; }                            // 枝番号
        public string kanricd { get; set; }                       // 管理ＣＤ
        public string fhouhou { get; set; }                       // フォロー方法
        public DateTime fyoteiymd { get; set; }                   // フォロー予定年月日
        public DateTime fkanymd { get; set; }                     // フォロー完了年月日
        public string biko { get; set; }                          // 備考
    }

    /// <summary>
    /// 妊産婦問診管理マスタ取得SQL
    /// </summary>
    public class SQLGetMonsin
    {
        public int bnendo { get; set; }                            // 母子手帳年度
        public Int32 bkofuno { get; set; }                         // 母子手帳交付番号
        public int edano { get; set; }                             // 枝番号
        public string kensinkbn { get; set; }                      // 健診区分
        public string monsincd { get; set; }                       // 問診ＣＤ
        public int monsineda { get; set; }                         // 問診枝番
        public string datatype1 { get; set; }                      // データタイプ１
        public string datatype2 { get; set; }                      // データタイプ２
        public float datatype3 { get; set; }                       // データタイプ３
        public string datatype4 { get; set; }                      // データタイプ４
        public DateTime datatype5 { get; set; }                    // データタイプ５
    }

    /// <summary>
    /// 妊婦健診管理マスタ取得SQL
    /// </summary>
    public class SQLGetNinpukensin
    {
        public int bnendo { get; set; }                              //母子手帳年度
        public int bkofuno { get; set; }                             //母子手帳交付番号
        public int edano { get; set; }                               //枝番号
        public string kenkaisu { get; set; }                         //健診回数
        public string kofuno { get; set; }                           //交付番号
        public bool hakkoflg { get; set; }                           //発行フラグ
        public bool syokanflg { get; set; }                          //償還払フラグ
        public DateTime? juriymd { get; set; }                       //受理年月日
        public DateTime? jusinymd { get; set; }                      //受診年月日
        public int? syusu { get; set; }                              //妊娠週数
        public string kikancd { get; set; }                          //実施機関
        public string yosancd { get; set; }                          //予算区分
        public string isicd { get; set; }                            //医師名
        public string khosiki { get; set; }                          //検診方式
        public double? ketto { get; set; }                           //血糖検査
        public int? syokugo { get; set; }                            //食後時間
        public double? gurukosu { get; set; }                        //グルコース
        public string kansetuk { get; set; }                         //間接クームス
        public string hinketu { get; set; }                          //貧血
        public double? syokuso { get; set; }                         //血色素検査
        public string hbskogen { get; set; }                         //ＨＢｓ抗原
        public string hcvkogen { get; set; }                         //ＨＣＶ抗原
        public string hcvkotai { get; set; }                         //ＨＣＶ抗体
        public string baidoku { get; set; }                          //梅毒血清検査
        public string hiv { get; set; }                              //ＨＩＶ
        public string fusin { get; set; }                            //風しん
        public string tpurazuma { get; set; }                        //トキソプラズマ
        public string htlv { get; set; }                             //ＨＴＬＶ
        public string atl { get; set; }                              //ＡＴＬ
        public string ssaibo { get; set; }                           //子宮頚がん細胞診
        public string ssaikin { get; set; }                          //子宮頚管細菌検査
        public string brensa { get; set; }                           //Ｂ型溶血性連鎖球菌
        public string sikyukekka { get; set; }                       //子宮がん検診
        public string siksikkan { get; set; }                        //子宮がん疾患
        public string tken { get; set; }                             //超音波検査
        public string tkofuno { get; set; }                          //超音波交付番号
        public bool thakkoflg { get; set; }                          //超音波発行フラグ
        public string tkekka { get; set; }                           //超音波結果
        public int? maxketu { get; set; }                            //最高血圧
        public int? minketu { get; set; }                            //最低血圧
        public string fusyu { get; set; }                            //浮腫
        public double? taiju { get; set; }                           //体重
        public string hatuiku { get; set; }                          //胎児発育評価検査
        public string nyoto { get; set; }                            //尿糖
        public string tanpaku { get; set; }                          //尿蛋白
        public string keton { get; set; }                            //尿ケトン体
        public string hantei { get; set; }                           //総合判定
        public string nyuin { get; set; }                            //入院
        public string byomei1 { get; set; }                          //病名１
        public string byomei2 { get; set; }                          //病名２
        public string byomei3 { get; set; }                          //病名３
        public string byomei4 { get; set; }                          //病名４
        public string renraku1 { get; set; }                         //連絡事項１
        public string renraku2 { get; set; }                         //連絡事項２
        public string renrakuta { get; set; }                        //連絡事項その他
        public string biko { get; set; }                             //備考
    }

    /// <summary>
    /// 産婦健診管理マスタ取得SQL
    /// </summary>
    public class SQLGetSanpu
    {
        public int bnendo { get; set; }                              //母子手帳年度
        public int bkofuno { get; set; }                             //母子手帳交付番号
        public int edano { get; set; }                               //枝番号
        public string getukbn { get; set; }                          //月齢区分
        public DateTime? jusinymd { get; set; }                      //受診年月日
        public bool tasiflg { get; set; }                            //他市町村受診フラグ
        public string kikancd { get; set; }                          //実施機関
        public int? maxketu { get; set; }                            //最高血圧
        public int? minketu { get; set; }                            //最低血圧
        public double? syokuso { get; set; }                         //血色素
        public string nyoto { get; set; }                            //糖
        public string tanpaku { get; set; }                          //蛋白
        public string senketu { get; set; }                          //潜血
        public string sinjokyo { get; set; }                         //身体状況
        public string kibun { get; set; }                            //気分の異常
        public string gekkei { get; set; }                           //月経開始時期
        public string homon { get; set; }                            //訪問
        public string hantei { get; set; }                           //判定結果
        public bool ketuflg { get; set; }                            //高血圧異常フラグ
        public bool tanflg { get; set; }                             //蛋白異常フラグ
        public bool fusyuflg { get; set; }                           //浮腫異常フラグ
        public bool hinflg { get; set; }                             //貧血異常フラグ
        public bool toflg { get; set; }                              //糖異常フラグ
        public bool senflg { get; set; }                             //潜血異常フラグ
        public bool taflg { get; set; }                              //その他異常フラグ
        public string biko { get; set; }                             //備考
    }

    /// <summary>
    /// メモ情報有無SQL文を返す。
    /// </summary>
    public class SQLMemo
    {
        public int memof { get; set; }                           // 期限
        public int tyuif { get; set; }                           // 注意
    }

    /// <summary>
    /// 個人照会 個人情報取得SQL
    /// </summary>
    public class SQLGetKojin
    {
        public string name { get; set; }                            // 氏名
        public int age { get; set; }                                // 年齢
        public string kijun { get; set; }                           // 基準
        public string hoken { get; set; }                           // 保険
        public string kazei { get; set; }                           // 課税
        public string gyonm { get; set; }                           // 名称
        public string adrs { get; set; }                            // アドレス
        public string tel { get; set; }                             // 電話番号
        public string setaino { get; set; }                         // 世帯番号
        public DateTime juymd { get; set; }                         // 住民となった日
        public DateTime jnymd { get; set; }                         // 住民でなくなった日
    }

    /// <summary>
    /// 世帯構成取得SQL
    /// </summary>
    public class SQLSetaiKosei
    {
        public string kojinno { get; set; }                        // 整理番号
        public string name { get; set; }                           // 氏名
        public string zokunm { get; set; }                         // 続柄名称
        public string jkbn { get; set; }                           // 住民区分
    }

    /// <summary>
    /// 世帯構成取得SQL
    /// </summary>
    public class SQLGetTetyobango
    {
        public int bnendo { get; set; }                            // 母子手帳年度
        public int bkofuno { get; set; }                           // 母子手帳交付番号
        public int bedano { get; set; }                            // 続柄名称母子手帳枝番
        public string hesinkikbn { get; set; }                     // 新規交付区分
        public string hesinki { get; set; }                        // 新規交付
        public DateTime hakkoymd { get; set; }                     // 届出年月日
    }

    /// <summary>
    /// 個人照会　　妊婦健診管理マスタ取得SQL
    /// </summary>
    public class SQLGetKojinNinpukensin
    {
        public string kenkaisu { get; set; }                         // 健診回数
        public DateTime? jusinymd { get; set; }                      // 受診年月日
        public string hantei { get; set; }                           // 判定結果
        public string biko { get; set; }                             // 備考
    }

    /// <summary>
    /// 個人照会　妊産婦要管理内容管理マスタ取得SQL
    /// </summary>
    public class SQLGetKojinYokanri
    {
        public string naiyo { get; set; }                           // 内容
        public string fhouhou { get; set; }                         // フォロー方法
        public DateTime? fyoteiymd { get; set; }                    // フォロー予定年月日
        public DateTime? fkanymd { get; set; }                      // フォロー完了年月日
        public string biko { get; set; }                            // 備考
    }

    /// <summary>
    /// フリー項目取得用SQL作成（個人確定）
    /// </summary>
    public class SQLBhNsGetKojinFree
    {
        public string groupid { get; set; }                          // グループＩＤ
        public string groupid2 { get; set; }                         // グループＩＤ２
        public string groupnm { get; set; }                          // グループ名
        public string itemcd { get; set; }                           // 項目ＣＤ
        public string itemnm { get; set; }                           // 項目名
        public int datatype { get; set; }                            // データタイプ
        public int cfid { get; set; }                                // コントロールファイルＩＤ
        public string maincd { get; set; }                           // メインＣＤ
        public string subcd { get; set; }                            // サブＣＤ
        public string biko { get; set; }                             // 備考
        public string inputdata { get; set; }                        // 管理項目
        public string naiyo { get; set; }                            // 内容
        public int hissu { get; set; }                               // 必須チェック
        public string valdata { get; set; }                          // 初期値
        public int seisuketa { get; set; }                           // 整数部桁数
        public int syosuketa { get; set; }                           // 小数部桁数
        public int orderid { get; set; }                             // 並び替え用
        public int kenkaisu { get; set; }                            // 健診回数
    }

    /// <summary>
    /// 支援計画情報取得SQL
    /// </summary>
    public class SQLGetKojinSien
    {
        public string gaito { get; set; }                            //特定妊婦
        public string biko01 { get; set; }                           //特定妊婦チェックリスト①備考
        public string biko02 { get; set; }                           //特定妊婦チェックリスト②備考
        public string biko03 { get; set; }                           //特定妊婦チェックリスト③備考
        public string biko04 { get; set; }                           //特定妊婦チェックリスト④備考
        public string biko05 { get; set; }                           //特定妊婦チェックリスト⑤備考
        public string biko06 { get; set; }                           //特定妊婦チェックリスト⑥備考
        public string biko07 { get; set; }                           //特定妊婦チェックリスト⑦備考
        public string biko08 { get; set; }                           //特定妊婦チェックリスト⑧備考
        public string biko09 { get; set; }                           //特定妊婦チェックリスト⑨備考
        public string biko10 { get; set; }                           //特定妊婦チェックリスト⑩備考
        public string biko11 { get; set; }                           //特定妊婦チェックリスト⑪備考
        public string biko12 { get; set; }                           //特定妊婦チェックリスト⑫備考
        public string biko { get; set; }                             //その他
        public DateTime? keikakuymd { get; set; }                    //計画作成日
        public string keikakustaff { get; set; }                     //計画作成者
        public string sogokadai { get; set; }                        //総合的な課題
        public string mokuhyo { get; set; }                          //目標と具体策の提案
        public string keikakuhohomain { get; set; }                  //主な計画方法
        public string rank { get; set; }                             //ランク
        public DateTime? sogohyokaymd { get; set; }                  //評価年月日
        public string sogohyokastaff { get; set; }                   //評価者
        public string sogohyokanaiyo { get; set; }                   //評価内容
        public string sogohyokakekka { get; set; }                   //評価結果
    }

    /// <summary>
    /// 支援計画(プラン)情報取得SQL
    /// </summary>
    public class SQLGetKojinSienPlan
    {
        public string planno { get; set; }                           //計画番号
        public DateTime? keikakuymd { get; set; }                    //計画日
        public string keikakutime { get; set; }                      //計画時
        public string keikakuhoho { get; set; }                      //計画方法
        public string keikakustaff { get; set; }                     //計画担当者
        public string keikakunaiyo { get; set; }                     //計画内容
        public DateTime? sienymd { get; set; }                       //支援年月日
        public string sienstime { get; set; }                        //時間(開始)
        public string sienhoho { get; set; }                         //支援方法
        public string sienstaff { get; set; }                        //担当者
        public string siennaiyo { get; set; }                        //支援内容
        public DateTime? hyokaymd { get; set; }                      //評価年月日
        public string hyokastaff { get; set; }                       //評価担当者
        public string hyokakekka { get; set; }                       //評価結果
        public string hyokanaiyo { get; set; }                       //評価内容
        public int sienno { get; set; }                              //支援番号
        public string siensyozoku { get; set; }                      //担当所属
        public string sienkbn { get; set; }                          //支援区分
        public string sienetime { get; set; }                        //時間(終了)
        public int? sienage { get; set; }                            //年齢
        public int? sienagem { get; set; }                           //年齢(月)
        public string sienkekka { get; set; }                        //支援結果
        public string jikai { get; set; }                            //次回予定
        public DateTime? jikaiymd { get; set; }                      //次回予定日
        public string jikaiyostime { get; set; }                     //次回予定時間(開始)
        public string jikaiyoetime { get; set; }                     //次回予定時間(終了)
        public bool jikaikakuninflg { get; set; }                    //次回確認フラグ
        public string sodankankei { get; set; }                      //相談者,本人との関係
        public string sodankojinno { get; set; }                     //相談者,整理番号
        public string sodanname { get; set; }                        //相談,氏名
        public string sodanrenraku { get; set; }                     //相談者,連絡先
        public string bibo { get; set; }                             //備忘録
        public bool bibokakuninflg { get; set; }                     //備忘録確認フラグ
        public bool tyuiflg { get; set; }                            //注意フラグ
        public DateTime? adddate { get; set; }                       //登録日
        public string tuserid { get; set; }                          //登録者
        public bool delcanf { get; set; }                            //削除可能フラグ
    }

    /// <summary>
    /// 妊婦検索一覧取得
    /// </summary>
    public class SQLGetNinpuKensaku
    {
        public int bnendo { get; set; }                              // 母子手帳年度
        public int bkofuno { get; set; }                             // 母子手帳交付番号
        public int bedano { get; set; }                              // 続柄名称母子手帳枝番
        public string name { get; set; }                             // 氏名
        public DateTime? bymd { get; set; }                          // 生年月日
        public DateTime? hetodokymd { get; set; }                    // 届出年月日
        public int hesyusu { get; set; }                             // 妊娠週数
        public string heyoteiymd { get; set; }                       // 分娩予定年月日
        public string adrs { get; set; }                             // アドレス
        public string jkbn { get; set; }                             // 住民区分
        public string juni { get; set; }                             // 取込対象
        public string kojinno { get; set; }                          // 整理番号
        public string name1 { get; set; }                            // 氏名
        public string sex { get; set; }                              // 性別
        public DateTime? kobymd { get; set; }                        // 子生年月日
    }


}