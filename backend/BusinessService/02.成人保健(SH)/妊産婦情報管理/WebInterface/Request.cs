// *******************************************************************
// 業務名称　: 各健康管理システム
// 機能概要　: 妊産婦情報管理
//             リクエストインターフェース
// 作成日　　: 2022.12.12
// 作成者　　: 韓
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.BH_kosin_ninsanpu
{
    /// <summary>
    /// 初期表示処理
    /// </summary>
    public class FormInit1Request : DaRequestBase
    {
        public string pgid { get; set; }                // プログラムＩＤ
    }

    /// <summary>
    /// 妊産婦情報入力で使用するデータを抽出する。
    /// </summary>
    public class Kensaku2Request : DaRequestBase
    {
        public string systemcd { get; set; }                   // 処理コード
        //public string userid { get; set; }                     // 操作者ＩＤ
        public string nendo { get; set; }                      // 年度
        public string kofuno { get; set; }                     // 交付番号
        public string edano { get; set; }                      // 枝番号
        public string kokojinno { get; set; }                  // 整理番号(子供)
        public bool sinkiflg { get; set; }                     // 新規フラグ
        public string seirino { get; set; }                    // 整理番号
        public string bymd { get; set; }                       // 生年月日
        public string kname { get; set; }                      // カナ氏名
        public string jokengyo { get; set; }                   // 行政区（条件あり/なし）
        public string[] gyoseiku { get; set; }                 // 行政区
        public string jokenjumin { get; set; }                 // 住民区分（条件あり/なし）
        public string[] juminkubun { get; set; }               // 住民区分
        public string jokennenrei { get; set; }                // 年齢範囲（条件あり/なし）
        public string kijunbi { get; set; }                    // 年齢基準日
        public string nenrei { get; set; }                     // 年齢
        public string jokentodokedesyusu { get; set; }         // 届出週数（条件あり/なし）
        public string todokedesyusuFrom { get; set; }          // 届出週数（From）
        public string todokedesyusuTo { get; set; }            // 届出週数（To）
        public string jokentodokedebi { get; set; }            // 届出日（条件あり/なし）
        public string todokedebiFrom { get; set; }             // 届出日（From）
        public string todokedebiTo { get; set; }               // 届出日（To）
        public string jokenbunben { get; set; }                // 分娩予定日範囲（条件あり/なし）
        public string bunbenyoteibiFrom { get; set; }          // 分娩予定日範囲（From）
        public string bunbenyoteibiTo { get; set; }            // 分娩予定日範囲（To）
        public string jokenninpukenshinbi { get; set; }        // 妊婦健診受診日範囲（条件あり/なし）
        public string ninpukenshinbiFrom { get; set; }         // 妊婦健診受診日（From）
        public string ninpukenshinbiTo { get; set; }           // 妊婦健診受診日（To）
        public string jokennninpukenshinhantei { get; set; }   // 妊婦健診判定（条件あり/なし）
        public string[] ninpukenshinhantei { get; set; }       // 妊婦健診判定
        public string pno { get; set; }                        // 個人番号
    }

    /// <summary>
    /// 妊産婦検索一覧再取得
    /// </summary>
    public class KensakuIchiranRequest : DaRequestBase
    {
        public string systemcd { get; set; }                   // 処理コード
        //public string userid { get; set; }                     // 操作者ＩＤ
        public string nendo { get; set; }                      // 年度
        public string kofuno { get; set; }                     // 交付番号
        public string edano { get; set; }                      // 枝番号
        public bool sinkiflg { get; set; }                     // 新規フラグ
        public string seirino { get; set; }                    // 整理番号
        public string bymd { get; set; }                       // 生年月日
        public string kname { get; set; }                      // カナ氏名
        public string jokengyo { get; set; }                   // 行政区（条件あり/なし）
        public string[] gyoseiku { get; set; }                 // 行政区
        public string jokenjumin { get; set; }                 // 住民区分（条件あり/なし）
        public string[] juminkubun { get; set; }               // 住民区分
        public string jokennenrei { get; set; }                // 年齢範囲（条件あり/なし）
        public string kijunbi { get; set; }                    // 年齢基準日
        public string nenrei { get; set; }                     // 年齢
        public string jokentodokedesyusu { get; set; }         // 届出週数（条件あり/なし）
        public string todokedesyusuFrom { get; set; }          // 届出週数（From）
        public string todokedesyusuTo { get; set; }            // 届出週数（To）
        public string jokentodokedebi { get; set; }            // 届出日（条件あり/なし）
        public string todokedebiFrom { get; set; }             // 届出日（From）
        public string todokedebiTo { get; set; }               // 届出日（To）
        public string jokenbunben { get; set; }                // 分娩予定日範囲（条件あり/なし）
        public string bunbenyoteibiFrom { get; set; }          // 分娩予定日範囲（From）
        public string bunbenyoteibiTo { get; set; }            // 分娩予定日範囲（To）
        public string jokenninpukenshinbi { get; set; }        // 妊婦健診受診日範囲（条件あり/なし）
        public string ninpukenshinbiFrom { get; set; }         // 妊婦健診受診日（From）
        public string ninpukenshinbiTo { get; set; }           // 妊婦健診受診日（To）
        public string jokennninpukenshinhantei { get; set; }   // 妊婦健診判定（条件あり/なし）
        public string[] ninpukenshinhantei { get; set; }       // 妊婦健診判定
        public string pno { get; set; }                        // 個人番号
    }

    /// <summary>
    /// 妊婦情報入力で編集した内容を各テーブルに更新する
    /// </summary>
    public class Toroku2Request : DaRequestBase
    {
        public string systemcd { get; set; }                      // 処理コード
        //public string userid { get; set; }                        // 操作者ＩＤ
        public string sinkiflg { get; set; }                      // 新規フラグ
        public string[] kensakuList { get; set; }                 // 検索条件項目
        public string[] headerItemList { get; set; }              // ヘッダー入力項目
        public string[] ninputitioyaList { get; set; }            // 妊婦・父親情報
        public string[] syuroujyokyoList { get; set; }            // 就労状況
        public string[] syusseirekiList { get; set; }             // 出生歴
        public string[] ninsinrekiList { get; set; }              // 妊娠歴
        public string[] kazokudokyoList { get; set; }             // 家族環境・同居の家族
        public string[] ninsinkiouList { get; set; }              // 妊娠既往歴
        public string[] syusoList { get; set; }                   // 主訴
        public string[] sintyoTaijuList { get; set; }             // 身長・体重
        public string[] gakkyuList { get; set; }                  // 母親学級
        public string[] sippeijyokyoList { get; set; }            // 現在の疾病治療状況
        public string[] hokensidoList { get; set; }               // 保健指導
        public string[] ninpukensinList { get; set; }             // 妊婦健康診査情報
        public string nsItemList { get; set; }                    // 妊産婦動的入力
        public string[] sanpukensin1List { get; set; }            // 産婦健康診査情報(１ヶ月)
        public string[] sanpukensin3List { get; set; }            // 産婦健康診査情報(３ヶ月)
        public string[] monsinList { get; set; }                  // 問診
        public string sougoukoment { get; set; }                  // 総合コメント
        public string freeitemcd { get; set; }                    // フリー項目ＩＤ
        public string inputdata { get; set; }                     // フリー項目入力値
        public string datatype { get; set; }                      // フリー項目データタイプ
        public string freeitemcdOnline { get; set; }              // オンライン申請情報ＩＤ
        public string inputOnlinedata { get; set; }               // オンライン申請情報入力値
        public string datatypeOnline { get; set; }                // オンライン申請情報データタイプ
        public string[] sienList { get; set; }                    // 支援計画
        public string[] sienCheckList { get; set; }               // 支援計画(チェック項目)
        public string[] sienPlanList { get; set; }                // 支援計画(プラン)
    }

    /// <summary>
    /// 妊産婦情報を削除する。
    /// </summary>

    public class SakujoRequest : DaRequestBase
    {
        public string systemcd { get; set; }             //システムコード
        //public string userid { get; set; }               //操作者ＩＤ
        public string nendo { get; set; }                //年度
        public string kofuno { get; set; }               //交付番号
        public string edano { get; set; }                //枝番号
    }

    /// <summary>
    /// 妊産婦情報入力で表示されている情報をコピー登録する
    /// </summary>
    public class CopyTorokuRequest : DaRequestBase
    {
        public string systemcd { get; set; }             //システムコード
        //public string userid { get; set; }               //操作者ＩＤ
        public string nendo { get; set; }                //年度
        public string kofuno { get; set; }               //交付番号
        public string edano { get; set; }                //枝番号
    }

    /// <summary>
    /// 住民情報取得で使用する情報を取得する
    /// </summary>
    public class JyuminRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string kojinno { get; set; }              // 個人番号
    }

    /// <summary>
    /// 住民となった日、住民でなくなった日、プッシュ通知希望情報有無を取得する
    /// </summary>
    public class JuJnYmdRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string kojinno { get; set; }              // 個人番号
    }

    /// <summary>
    /// 手帳番号取得
    /// </summary>
    public class GetTetyoBangoRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string nendo { get; set; }                //年度
        public string kofuno { get; set; }               //交付番号
        public string edano { get; set; }                //枝番号
        public string kofukbn { get; set; }              //交付区分
        public string nextkofukbn { get; set; }          //次の交付区分
    }

    /// <summary>
    /// 帳票出力処理
    /// </summary>
    public class RepCreate1Request : DaRequestBase
    {
        public string systemcd { get; set; }                   //システムコード
        //public string userid { get; set; }                     //操作者ＩＤ
        public string type { get; set; }                       //出力形式
        public string nendo { get; set; }                      //年度
        public string kofuno { get; set; }                     //母子手帳交付番号
        public string edano { get; set; }                      //母子手帳枝番
        public string todokymd { get; set; }                   //届出年月日
        public string hahaname { get; set; }                   //母氏名
        public string kijunymd { get; set; }                   //基準年月日
        public string[] ninpukensinJoseiList { get; set; }     //妊婦健康診査情報
    }

    /// <summary>
    /// 帳票出力を行う。
    /// </summary>
    public class RepCreateSienRequest : DaRequestBase
    {
        public string systemcd { get; set; }             //処理コード
        //public string userid { get; set; }               //操作者ＩＤ
        public string type { get; set; }                 //帳票種別
        public string bnendo { get; set; }               //対象者(年度)
        public string bkofuno { get; set; }              //対象者(番号)
        public string edano { get; set; }                //対象者(枝番)
    }

    /// <summary>
    /// 帳票出力を行う。(個人台帳)
    /// </summary>
    public class RepCreateKojinDaichouRequest : DaRequestBase
    {
        public string systemcd { get; set; }             //処理コード
        //public string userid { get; set; }               //操作者ＩＤ
        public string type { get; set; }                 //帳票種別
        public string bnendo { get; set; }               //対象者(年度)
        public string bkofuno { get; set; }              //対象者(番号)
        public string edano { get; set; }                //対象者(枝番)
    }

}