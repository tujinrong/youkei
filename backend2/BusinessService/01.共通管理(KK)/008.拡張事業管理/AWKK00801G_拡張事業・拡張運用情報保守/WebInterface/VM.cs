// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 拡事業・拡運用情報保守
//             ViewModel定義
// 作成日　　: 2023.12.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00801G
{
    /// <summary>
    /// ドロップダウンリスト(種類)
    /// </summary>
    public class DaSelectorKeyModel2 : DaSelectorModel
    {
        public string key { get; set; }     //キー項目(連動フィルター用)
        public string comment { get; set; } //説明
    }
    /// <summary>
    /// 検診事業一覧画面行モデル
    /// </summary>
    public class KensinListRowVM
    {
        public string jigyocd { get; set; }                         //事業コード
        public string jigyonm { get; set; }                         //事業名
        public Enum事業区分 jigyokbn { get; set; }                  //事業区分
        public string jigyokbnnm { get; set; }                      //事業区分名
        public Enum精密検査実施区分 seikenjissikbn { get; set; }    //精密検査実施区分
        public string seikenjissikbnnm { get; set; }                //精密検査実施区分名
        public string kinoid { get; set; }                          //機能ID
    }
    /// <summary>
    /// 検診共通画面ヘッダーモデル
    /// </summary>
    public class KensinCommonHeaderVM
    {
        public string jigyonm { get; set; }         //事業名
        public string jigyoshortnm { get; set; }    //事業名略称
    }
    /// <summary>
    /// 検診事業詳細(事業内容)
    /// </summary>
    public class KensinDetailJigyoVM
    {
        public string? kinoid { get; set; }         //機能ID
        public string hyojinm { get; set; }         //機能表示名称
        public string seikenjissikbn { get; set; }  //精密検査実施区分(コード：名称)
        public string cuponhyojikbn { get; set; }   //クーポン券表示区分(コード：名称)
        public string genmenkbn { get; set; }       //減免区分(コード：名称)
        public string syogaiikaiflg { get; set; }   //生涯１回フラグ
    }
    /// <summary>
    /// 検診事業詳細(検査方法)
    /// </summary>
    public class KensinDetailHohoVM : KensinDetailHohoSaveVM
    {
        public string kensahoho_maincdnm { get; set; }                  //検査方法メインコード名

    }
    /// <summary>
    /// 検診事業詳細(検査方法):保存処理
    /// </summary>
    public class KensinDetailHohoSaveVM
    {
        public bool kensahoho_setflg { get; set; }                      //検査方法設定フラグ
        public string kensahoho_subcdnm { get; set; }                   //検査方法サブコード名
        public List<KensinDetailHohoRowVM> kekkalist { get; set; }      //検査方法一覧

    }
    /// <summary>
    /// 検診事業詳細(予約分類)
    /// </summary>
    public class KensinDetailYoyakuVM : KensinDetailYoyakuSaveVM
    {
        public string yoyakubunrui_maincdnm { get; set; }               //予約分類メインコード名
    }
    /// <summary>
    /// 検診事業詳細(予約分類):保存処理
    /// </summary>
    public class KensinDetailYoyakuSaveVM
    {
        public string yoyakubunrui_subcdnm { get; set; }                //予約分類サブコード名
        public List<KensinDetailYoyakuRowVM> kekkalist { get; set; }    //予約分類一覧
    }
    /// <summary>
    /// 検診事業詳細(フリー項目)
    /// </summary>
    public class KensinDetailFreeVM : KensinDetailFreeSaveVM
    {
        public string groupid2_maincdnm { get; set; }           //グループ2メインコード名
    }
    /// <summary>
    /// 検診事業情報(エラーチェック)
    /// </summary>
    public class KensinDetailErrorchkVM
    {
        public string yoyakuchk { get; set; }                   //予約画面チェック区分
        public string kensinchk { get; set; }                   //健（検）診画面チェック区分
    }
    /// <summary>
    /// 検診事業詳細(フリー項目):保存処理
    /// </summary>
    public class KensinDetailFreeSaveVM
    {
        public string groupid2_subcdnm { get; set; }            //グループ2サブコード名
        public List<DaSelectorModel> kekkalist { get; set; }    //検査分類名一覧
    }
    /// <summary>
    ///検診事業情報(エラーチェック):保存処理
    /// </summary>
    public class KensinDetailErrorchkSaveVM
    {
        public string yoyakuchk { get; set; }                   //予約画面チェック区分
        public string kensinchk { get; set; }                   //健（検）診画面チェック区分
    }
    /// <summary>
    /// 検査方法行モデル
    /// </summary>
    public class KensinDetailHohoRowVM
    {
        public string kensahohocd { get; set; }         //検査方法コード
        public string kensahohonm { get; set; }         //検査方法名
        public string kensahohoshortnm { get; set; }    //検査方法略称
    }
    /// <summary>
    /// 予約行モデル
    /// </summary>
    public class KensinDetailYoyakuRowVM
    {
        public string yoyakubunrui { get; set; }            //予約分類コード
        public string yoyakubunruinm { get; set; }          //予約分類名
        public string yoyakubunruishortnm { get; set; }     //予約分類表示名
        public List<string> yoyakubunruilist { get; set; }  //検査方法コード一覧
    }
    /// <summary>
    /// 検診項目一覧画面行モデル
    /// </summary>
    public class KensinItemListRowVM : ItemListRowBaseVM
    {
        public string riyokensahohonms { get; set; }    //利用検査方法名(複数)
        public bool haitiflg { get; set; }              //画面配置フラグ
    }
    /// <summary>
    /// 検診項目詳細画面初期化モデル
    /// </summary>
    public class KensinItemDetailInitVM : KensinItemDetailSaveVM
    {
        public int? keisanparamnum { get; set; }            //計算パラメータ数
    }
    /// <summary>
    /// 検診項目詳細保存モデル
    /// </summary>
    public class KensinItemDetailSaveVM : FreeItemDetailBaseVM
    {
        public bool rirekiflg { get; set; }                 //履歴管理フラグ
        public int? hyojinendof { get; set; }               //表示年度（開始）
        public int? hyojinendot { get; set; }               //表示年度（終了）
        public string keisankbn { get; set; }               //計算区分(コード：名称)
        public string keisansusiki { get; set; }            //計算数式
        public string? keisankansu { get; set; }            //計算関数ID(コード：名称)
        public List<string> keisanparams { get; set; }      //計算パラメータ(複数)
        public List<string> riyokensahohocds { get; set; }  //利用検査方法コード(複数)
    }
    /// <summary>
    /// 指導項目一覧画面行モデル
    /// </summary>
    public class SidoItemListRowVM : ItemListRowBaseVM
    {
        public Enum項目用途区分 itemyotokbn { get; set; }   //項目用途区分
    }
    /// <summary>
    /// 項目一覧画面行ベースモデル
    /// </summary>
    public class ItemListRowBaseVM
    {
        public string itemcd { get; set; }                      //項目コード
        public string itemnm { get; set; }                      //項目名
        public string kakutyokbn { get; set; }                  //拡領域使用
        public Enum事業区分 pkgdokujikbn { get; set; }          //PKG標準・独自区分
        public string pkgdokujikbnnm { get; set; }              //PKG標準・独自区分
        public Enum入力タイプ分類 inputtypekbn { get; set; }    //入力タイプ分類
        public string inputtypekbnnm { get; set; }              //項目タイプ
        public string groupnm { get; set; }                     //グループID名
        public string groupid { get; set; }                     //グループID
        public Enumフリー項目区分区分 itemkbn { get; set; }     //項目区分(一覧内容リンク判断用)
    }
    /// <summary>
    /// 指導共通画面ヘッダーモデル
    /// </summary>
    public class SidoCommonHeaderVM
    {
        public string sidokbnnm { get; set; }           //指導区分名称
        public string gyomukbnnm { get; set; }          //業務区分名称
        public string mosikomikekkakbnnm { get; set; }  //申込結果区分名称
        public string itemyotokbnnm { get; set; }       //項目用途区分名称
    }
    /// <summary>
    /// 項目詳細モデルベース
    /// </summary>
    public class FreeItemDetailBaseVM
    {
        public string? itemcd { get; set; }                 //項目コード
        public string itemnm { get; set; }                  //項目名
        public string? group { get; set; }                  //グループID(コード：名称)
        public string? group2 { get; set; }                 //グループID2(コード：名称)
        public string? inputtype { get; set; }              //入力タイプ(コード：名称)
        public string? codejoken1 { get; set; }             //コード条件1(コード：名称)
        public string? codejoken2 { get; set; }             //コード条件2(コード：名称)
        public string? codejoken3 { get; set; }             //コード条件3(コード：名称)
        public string? keta { get; set; }                   //入力桁
        public bool hissuflg { get; set; }                  //必須フラグ
        public string hanif { get; set; }                   //入力範囲（開始）
        public string hanit { get; set; }                   //入力範囲（終了）
        public bool inputflg { get; set; }                  //入力フラグ
        public string msgkbn { get; set; }                  //メッセージ区分(コード：名称)
        public string tani { get; set; }                    //単位
        public string syokiti { get; set; }                 //初期値
        public string? komokutokuteikbn { get; set; }       //項目特定区分
        public string biko { get; set; }                    //備考
    }
    /// <summary>
    /// 指導項目詳細保存モデル
    /// </summary>
    public class SidoItemDetailVM : FreeItemDetailBaseVM
    {
        public List<string> syukeikbns { get; set; }    //利用地域保健集計区分(複数)
    }
    /// <summary>
    /// 検診予約事業一覧画面行モデル
    /// </summary>
    public class KensinYoyakuListRowVM
    {
        public string jigyocd { get; set; }         //事業コード
        public string jigyonm { get; set; }         //事業名
        public string ryokinpatternnm { get; set; } //料金パターン名
        public string jigyonaiyo { get; set; }      //事業内容
    }
    /// <summary>
    /// 検診予約事業詳細画面行モデル
    /// </summary>
    public class KensinYoyakuDetailRowVM : KensinYoyakuDetailRowSaveVM
    {
        public string jigyonm { get; set; }         //検診事業名
        public string kensahohonm { get; set; }     //検査方法名
        public bool jissieditflg { get; set; }      //実施編集フラグ`
    }
    /// <summary>
    /// 検診予約事業詳細画面行モデル(保存用)
    /// </summary>
    public class KensinYoyakuDetailRowSaveVM
    {
        public bool jissiflg { get; set; }          //実施フラグ
        public string jigyocd { get; set; }         //検診事業コード
        public string kensahohocd { get; set; }     //検査方法コード
        public bool optionflg { get; set; }         //オプションフラグ
    }
    /// <summary>
    /// 検診予約事業詳細メイン情報
    /// </summary>
    public class KensinYoyakuDetailMainVM : KensinYoyakuDetailMainBaseVM
    {
        public string jigyonm { get; set; } //予約日程事業名(変更の場合のみ)
    }
    /// <summary>
    /// 検診予約事業詳細メイン情報(ベース)
    /// </summary>
    public class KensinYoyakuDetailMainBaseVM
    {
        public string ryokinpatterncdnm { get; set; }   //料金パターン(コード：名称)
        public DateTime? upddttm { get; set; }          //更新日時(排他用)
    }
    /// <summary>
    /// 検診予約事業詳細メイン情報(保存用)
    /// </summary>
    public class KensinYoyakuDetailMainSaveVM : KensinYoyakuDetailMainBaseVM
    {
        public string jigyocdnm { get; set; } //予約日程事業名(新規の場合のみ)
    }
    /// <summary>
    /// 予約指導事業行モデル
    /// </summary>
    public class YoyakuSidoJigyoRowVM : YoyakuSidoJigyoRowSaveVM
    {
        public DateTime? upddttm { get; set; }  //更新日時
        public bool editflg { get; set; }       //編集フラグ(業務区分)
    }
    /// <summary>
    /// 予約指導事業行モデル(保存用)
    /// </summary>
    public class YoyakuSidoJigyoRowSaveVM
    {
        public string jigyocd { get; set; }         //その他日程事業・保健指導事業コード
        public string jigyonm { get; set; }         //その他日程事業・保健指導事業名
        public bool stopflg { get; set; }           //使用停止フラグ
        public string gyomukbncdnm { get; set; }    //業務区分(コード：名称)
        public bool yoyakuriyoflg { get; set; }     //予約利用フラグ
        public bool homonriyoflg { get; set; }      //訪問利用フラグ
        public bool sodanriyoflg { get; set; }      //相談利用フラグ
        public bool syudanriyoflg { get; set; }     //集団利用フラグ
    }
    /// <summary>
    /// 排他チェック用モデル(予約指導事業)
    /// </summary>
    public class YoyakuSidoJigyoLockVM
    {
        public string jigyocd { get; set; }     //その他日程事業・保健指導事業コード
        public DateTime upddttm { get; set; }   //更新日時
    }
}