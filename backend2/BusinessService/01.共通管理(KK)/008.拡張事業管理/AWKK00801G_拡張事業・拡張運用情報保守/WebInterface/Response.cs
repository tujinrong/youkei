// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 拡事業・拡運用情報保守
//             レスポンスインターフェース
// 作成日　　: 2023.12.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00801G
{
    /// <summary>
    /// 初期化処理(選択画面)
    /// </summary>
    public class InitChoiceResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }        //業務区分一覧
        public List<DaSelectorKeyModel2> selectorlist2 { get; set; }    //種類区分一覧
    }

    /// <summary>
    /// 初期化処理(検診事業一覧画面)
    /// </summary>
    public class InitKensinListResponse : DaResponseBase
    {
        public List<KensinListRowVM> kekkalist { get; set; }    //検診事業一覧
        public bool insertflg { get; set; }                     //新規フラグ
        public string kensucnt { get; set; }                    //拡事業入力件数カウント
    }

    /// <summary>
    /// 初期化処理(検診事業詳細画面)
    /// </summary>
    public class InitKensinDetailResponse : DaResponseBase
    {
        public DateTime? upddttm { get; set; }                      //更新日時(排他用)
        public KensinCommonHeaderVM headerinfo { get; set; }        //検診共通画面ヘッダー情報
        public KensinDetailJigyoVM jigyoinfo { get; set; }          //検診事業情報(事業内容)
        public KensinDetailHohoVM hohoinfo { get; set; }            //検診事業情報(検査方法)
        public KensinDetailYoyakuVM yoyakuinfo { get; set; }        //検診事業情報(予約分類)
        public KensinDetailFreeVM freeinfo { get; set; }            //検診事業情報(フリー項目)
        public KensinDetailErrorchkVM errorchkinfo { get; set; }    //検診事業情報(エラーチェック)
        public List<DaSelectorModel> selectorlist1 { get; set; }    //精密検査実施区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist2 { get; set; }    //クーポン券表示区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist3 { get; set; }    //減免区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist4 { get; set; }    //生涯１回フラグドロップダウンリスト
        public List<DaSelectorModel> selectorlist5 { get; set; }    //メッセージ区分一覧ドロップダウンリスト
    }

    /// <summary>
    /// 保存処理(検診事業詳細画面)
    /// </summary>
    public class SaveKensinJigyoDetailResponse : DaResponseBase
    {
        public string kinoid { get; set; }   //機能ID(新規用)
    }

    /// <summary>
    /// 初期化処理(検診項目一覧画面)
    /// </summary>
    public class InitKensinItemListResponse : DaResponseBase
    {
        public KensinCommonHeaderVM headerinfo { get; set; }        //検診項目一覧画面ヘッダー情報
        public List<KensinItemListRowVM> kekkalist { get; set; }    //検診項目一覧
        public bool halfflg1 { get; set; }                           //半角タイプ入力上限値フラグ（一次）
        public bool dayflg1 { get; set; }                            //日付タイプ入力上限値フラグ（一次）
        public bool fullflg1 { get; set; }                           //全角タイプ入力上限値フラグ（一次）
        public bool cdflg1 { get; set; }                             //コードタイプ入力上限値フラグ（一次）
        public bool halfflg2 { get; set; }                           //半角タイプ入力上限値フラグ（精密）
        public bool dayflg2 { get; set; }                            //日付タイプ入力上限値フラグ（精密）
        public bool fullflg2 { get; set; }                           //全角タイプ入力上限値フラグ（精密）
        public bool cdflg2 { get; set; }                             //コードタイプ入力上限値フラグ（精密）
        public bool buttonflg { get; set; }                         //ボタン制御フラグ(新規・コピー)
        public string kensuichijicnt { get; set; }                  //拡事業入力件数カウント（一次）
        public string kensuseimitsucnt { get; set; }               //拡事業入力件数カウント（精密）
    }
    /// <summary>
    /// 初期化処理(検診項目詳細画面)
    /// </summary>
    public class InitKensinItemDetailResponse : GetCodejokenListResponse
    {
        public KensinCommonHeaderVM headerinfo { get; set; }            //検診項目詳細画面ヘッダー情報
        public KensinItemDetailInitVM detailinfo { get; set; }          //検診項目詳細
        public bool showkbn1 { get; set; }                              //表示区分(グループID2)
        public bool showkbn2 { get; set; }                              //表示区分(検査方法)
        public List<DaSelectorModel> selectorlist1 { get; set; }        //グループIDドロップダウンリスト
        public List<DaSelectorModel> selectorlist2 { get; set; }        //グループID2ドロップダウンリスト
        public List<DaSelectorModel> selectorlist3 { get; set; }        //メッセージ区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist4_1 { get; set; }      //入力タイプドロップダウンリスト（一次）
        public List<DaSelectorModel> selectorlist4_2 { get; set; }      //入力タイプドロップダウンリスト（精密）
        public List<DaSelectorModel> selectorlist8 { get; set; }        //検査方法ドロップダウンリスト
        public List<DaSelectorModel> selectorlist9 { get; set; }        //計算区分ドロップダウンリスト
        public List<DaSelectorKeyModel> selectorlist10 { get; set; }    //計算関数ID(内部)ドロップダウンリスト
        public string idNaibubiko { get; set; }                         //計算関数ID(内部)備考
        public List<DaSelectorKeyModel> selectorlist11 { get; set; }    //計算関数ID(DB)ドロップダウンリスト
        public string idDbbiko { get; set; }                            //計算関数ID(DB)備考
        public List<DaSelectorModel> selectorlist12 { get; set; }       //項目一覧ドロップダウンリスト
        public List<DaSelectorModel> selectorlist13 { get; set; }       //項目特定区分ドロップダウンリスト
        public bool deleteFlg { get; set; }                             //削除ボタン活性フラグ
        public DateTime? upddttm { get; set; }                          //更新日時(排他用)
    }
    /// <summary>
    /// 条件コードリスト取得(検診項目詳細画面)
    /// </summary>
    public class GetCodejokenListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist5 { get; set; }    //コード条件1ドロップダウンリスト
        public List<DaSelectorModel> selectorlist6 { get; set; }    //コード条件2ドロップダウンリスト
        public List<DaSelectorModel> selectorlist7 { get; set; }    //コード条件3ドロップダウンリスト
    }
    /// <summary>
    /// 初期化処理(指導項目一覧画面)
    /// </summary>
    public class InitSidoItemListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //指導区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist2 { get; set; }    //業務区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist3 { get; set; }    //申込結果ドロップダウンリスト
        public List<DaSelectorModel> selectorlist4 { get; set; }    //項目用途区分ドロップダウンリスト
    }
    /// <summary>
    /// 検索処理(指導項目一覧画面)
    /// </summary>
    public class SearchSidoItemListResponse : DaResponseBase
    {
        public List<ItemListRowBaseVM> kekkalist { get; set; }  //指導項目一覧
        public bool halfflg { get; set; }                       //半角タイプ入力上限値フラグ
        public bool dayflg { get; set; }                        //日付タイプ入力上限値フラグ
        public bool fullflg { get; set; }                       //全角タイプ入力上限値フラグ
        public bool cdflg { get; set; }                         //コードタイプ入力上限値フラグ
        public bool buttonflg { get; set; }                     //ボタン制御フラグ(新規・コピー)
        public string kensucnt { get; set; }                    //拡事業入力件数カウント
    }
    /// <summary>
    /// 初期化処理(指導項目詳細画面)
    /// </summary>
    public class InitSidoItemDetailResponse : GetCodejokenListResponse
    {
        public SidoCommonHeaderVM headerinfo { get; set; }          //指導項目詳細画面ヘッダー情報
        public SidoItemDetailVM detailinfo { get; set; }            //指導項目詳細
        public List<DaSelectorModel> selectorlist1 { get; set; }    //グループIDドロップダウンリスト
        public List<DaSelectorModel> selectorlist2 { get; set; }    //グループID2ドロップダウンリスト
        public List<DaSelectorModel> selectorlist3 { get; set; }    //メッセージ区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist4 { get; set; }    //入力タイプドロップダウンリスト
        public List<DaSelectorModel> selectorlist8 { get; set; }    //利用地域保健集計区分ドロップダウンリスト
        public List<DaSelectorModel> selectorlist9 { get; set; }    //項目特定区分ドロップダウンリスト
        public DateTime? upddttm { get; set; }                      //更新日時(排他用)
    }

    /// <summary>
    /// 検索処理(検診予約事業一覧画面)
    /// </summary>
    public class SearchKensinYoyakuJigyoListResponse : DaResponseBase
    {
        public List<KensinYoyakuListRowVM> kekkalist { get; set; }    //検診予約事業一覧
    }

    /// <summary>
    /// 初期化処理(検診予約事業詳細画面)
    /// </summary>
    public class InitKensinYoyakuJigyoDetailResponse : DaResponseBase
    {
        public KensinYoyakuDetailMainVM maininfo { get; set; }          //メイン情報
        public List<KensinYoyakuDetailRowVM> kekkalist { get; set; }    //検査方法一覧
        public List<DaSelectorModel> selectorlist1 { get; set; }        //料金パターンドロップダウンリスト
        public List<DaSelectorModel> selectorlist2 { get; set; }        //検診予約事業ドロップダウンリスト(新規の場合のみ)
    }
    /// <summary>
    /// 初期化処理(その他予約事業一覧画面)
    /// </summary>
    public class InitYoyakuSidoJigyoListResponse : DaResponseBase
    {
        public List<YoyakuSidoJigyoRowVM> kekkalist { get; set; }   //その他予約事業一覧
        public List<DaSelectorKeyModel> selectorlist { get; set; }  //業務区分ドロップダウンリスト
    }
}