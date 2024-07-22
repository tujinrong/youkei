// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 各種検診一括入力
//             レスポンスインターフェース
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.KK_kosin_ikkatu
{
    /// <summary>
    /// 取込処理画面で使用する種別コードを抽出する。
    /// </summary>
    public class FormInitImpResponse : DaResponseBase
    {
        public string systemcd { get; set; }                      // 処理コード
        public string muplurl { get; set; }                       // アップロードURL
        public SQLKkcf msyurui { get; set; }                      // 種類
        public string mdispctrlflg { get; set; }                  // 登録処理後画面制御実行フラグ
    }

    /// <summary>
    /// CFを抽出するためのSQL文を返す。
    /// </summary>
    public class SQLKkcf
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
    /// 取込エラーリストの出力を行う
    /// </summary>
    public class RepCreateResponse : DaResponseBase
    {
        public string syorinm { get; set; }                       // 処理名称
        public SQLKktoriikkatuitem status { get; set; }           // 抽出項目
    }

    /// <summary>
    /// 項目取得処理
    /// </summary>
    public class SQLKktoriikkatuitem
    {
        public string komokucd { get; set; }                   // 項目コード
        public string komokunm { get; set; }                   // 項目名称
        public string tblnm { get; set; }                      // 対象テーブル名称
        public string fldnm { get; set; }                      // 対象フィールド名称
        public string fldkeyflg { get; set; }                  // 対象フィールドKEYフラグ
        public string setdata { get; set; }                    // 設定値
        public string disptypekbn { get; set; }                // 項目タイプ区分
        public string cfmaincd { get; set; }                   // CFメインコード
        public string cfsubcd { get; set; }                    // CFサブコード
        public string hissuchkkbn { get; set; }                // 必須チェック区分
        public string typechkkbn { get; set; }                 // 項目タイプチェック区分
        public string dispvisflg { get; set; }                 // 画面表示フラグ
        public string dispupdflg { get; set; }                 // 画面修正可能フラグ
        public string disptabflg { get; set; }                 // 画面タブ移動可能フラグ
        public int dispwidth1 { get; set; }                    // 画面列幅
        public int dispwidth2 { get; set; }                    // 画面列幅
        public int dispketasu { get; set; }                    // 画面桁数
        public int disporderid { get; set; }                   // 画面並び順
        public int reporderid { get; set; }                    // 帳票並び順
        public string dispsyoki { get; set; }                  // 画面初期値
        public string inpketasu { get; set; }                  // 取込データ桁数
        public string inporderid { get; set; }                 // 取込データ並び順
        public string inpformat { get; set; }                  // 取込変換書式
        public string gyono { get; set; }                      // 行番号
        public string error { get; set; }                      // エラー内容
    }

    /// <summary>
    /// 個人情報を取得する
    /// </summary>
    public class KojinKensakuResponse : DaResponseBase
    {
        public string minfo { get; set; }                      // XMLデータを作成：PGごとで変更
    }

    /// <summary>
    /// 取込情報の履歴情報を取得する
    /// </summary>
    public class RirekiResponse : DaResponseBase
    {
        public SQLKktoriikkatulog rireki { get; set; }         // 取込・一括入力取込処理履歴
    }

    /// <summary>
    /// 取込・一括入力取込処理履歴マスタ情報取得
    /// </summary>
    public class SQLKktoriikkatulog
    {
        public string TAISYO { get; set; }                     // 取込対象
        public string PATHNAME { get; set; }                   // ファイル名(フルパス)
        public string SYORIYMD { get; set; }                   // 処理年月日
        public string USERID { get; set; }                     // 操作者ＩＤ
        public int INPUTKENSU { get; set; }                    // 入力件数
        public int OUTPUTKENSU { get; set; }                   // 取込件数
    }

    /// <summary>
    /// 取込情報画面で使用するデータを抽出する。
    /// </summary>
    public class Kensaku1Response : DaResponseBase
    {
        public SQLKktoriikkatu meisai { get; set; }         // 明細情報
    }

    /// <summary>
    /// 明細情報取得
    /// </summary>
    public class SQLKktoriikkatu
    {
        public string syoricd { get; set; }                    // 処理コード
        public int edano { get; set; }                         // 枝番号
        public string syorinm { get; set; }                    // 処理名称
        public string yosikicd { get; set; }                   // 様式コード
        public string insupdkbn { get; set; }                  // 登録更新区分
        public string jikkokbn { get; set; }                   // 実行区分
        public string nendosiyoflG { get; set; }               // 年度使用フラグ
        public string filepath { get; set; }                   // ファイルパス
        public string filenm { get; set; }                     // ファイル名称
        public string hfilenm { get; set; }                    // 編集ファイル名称
        public int orderid { get; set; }                       // 並び順
        public string dispchkflg { get; set; }                 // 画面入力時チェックフラグ
        public string disprowflg { get; set; }                 // 画面行自動作成フラグ
        public string dispaddflg { get; set; }                 // 画面追加可能フラグ
        public string dispdelflg { get; set; }                 // 画面削除可能フラグ
        public DateTime syoriymd { get; set; }                 // 処理年月日
        public string username { get; set; }                   // 使用者名
        public string uplflg { get; set; }                     // 更新フラグ
    }

    /// <summary>
    /// 取込情報画面で使用するデータグリッド用のレイアウトデータを抽出する。
    /// </summary>
    public class LayoutResponse : DaResponseBase
    {
        public SQLKktoriikkatuitem1 dlayout { get; set; }         // レイアウトデータ
    }

    /// <summary>
    /// 取込・一括入力処理項目マスタ取得
    /// </summary>
    public class SQLKktoriikkatuitem1
    {
        public string yosikicd { get; set; }                      // 様式コード
        public string komokucd { get; set; }                      // 項目コード
        public string komokunm { get; set; }                      // 項目名称
        public string tblnm { get; set; }                         // 対象テーブル名称
        public string fldnm { get; set; }                         // 対象フィールド名称
        public string fldkeyflg { get; set; }                     // 対象フィールドKEYフラグ
        public string setdata { get; set; }                       // 設定値
        public string disptypekbn { get; set; }                   // 項目タイプ区分
        public string himodukecd { get; set; }                    // 紐付けコード
        public string cfmaincd { get; set; }                      // CFメインコード
        public string cfsubcd { get; set; }                       // CFサブコード
        public string hissuchkkbn { get; set; }                   // 必須チェック区分
        public string typechkkbn { get; set; }                    // 項目タイプチェック区分
        public string dispvisflg { get; set; }                    // 画面表示フラグ
        public string dispupdflg { get; set; }                    // 画面修正可能フラグ
        public string disptabflg { get; set; }                    // 画面タブ移動可能フラグ
        public int dispwidth1 { get; set; }                       // 画面列幅
        public int dispwidth2 { get; set; }                       // 画面列幅
        public int dispketasu { get; set; }                       // 画面桁数
        public int disporderid { get; set; }                      // 画面並び順
        public int reporderid { get; set; }                       // 帳票並び順
        public string dispsyoki { get; set; }                     // 画面初期値
        public int inpketasu { get; set; }                        // 取込データ桁数
        public int inporderid { get; set; }                       // 取込データ並び順
        public string inpformat { get; set; }                     // 取込変換書式
        public string dispformat { get; set; }                    // 表示変換書式
        public string getdataflg { get; set; }                    // データ取得フラグ
        public string orderid { get; set; }                       // 並び替え用
    }

    /// <summary>
    /// 取込情報画面で使用するデータグリッドのデータを取得する
    /// </summary>
    public class GetFileDataResponse : DaResponseBase
    {
        public SQLMyosiki myosiki { get; set; }                  // 取込ファイル様式
        public SQLMfiledata mfiledata { get; set; }              // 取込項目
        public SQLMkojin mkojin { get; set; }                    // 個人情報
    }

    /// <summary>
    /// 取込ファイル様式取得
    /// </summary>
    public class SQLMyosiki
    {
        public string KEISIKIKBN { get; set; }                     // データ形式区分
        public string MOJICDKBN { get; set; }                      // 文字コード区分
        public string KUGIRIKBN { get; set; }                      // 区切り記号区分
        public string INYOFUKBN { get; set; }                      // 引用符区分
        public string HEADERROW { get; set; }                      // ヘッダー部行数
    }

    /// <summary>
    /// 取込項目取得
    /// </summary>
    public class SQLMfiledata
    {
        public string komokucd { get; set; }                       // 項目コード
        public int inpketasu { get; set; }                         // 取込データ桁数
    }

    /// <summary>
    /// 個人情報取得
    /// </summary>
    public class SQLMkojin
    {
        public string komokucd { get; set; }                      // 項目コード
        public string komokunm { get; set; }                      // 項目名称
        public string tblnm { get; set; }                         // 対象テーブル名称
        public string fldnm { get; set; }                         // 対象フィールド名称
        public string setdata { get; set; }                       // 設定値
        public string disptypekbn { get; set; }                   // 項目タイプ区分
        public string typechkkbn { get; set; }                    // 項目タイプチェック区分
        public string cfmaincd { get; set; }                      // CFメインコード
        public string cfsubcd { get; set; }                       // CFサブコード
        public string getdataflg { get; set; }                    // データ取得フラグ
    }

    /// <summary>
    /// 一括入力で使用するデータグリッドのデータを取得する
    /// </summary>
    public class JikkoResponse : DaResponseBase
    {
        public SQLMyosiki myosiki { get; set; }                  // 取込ファイル様式
        public SQLMfiledata mfiledata { get; set; }              // 取込項目
        public SQLMkojin mkojin { get; set; }                    // 個人情報
    }

    /// <summary>
    /// 一括入力画面で使用する種別コードを抽出する。
    /// </summary>
    public class FormInitIkkatuResponse : DaResponseBase
    {
        public string msyoricd { get; set; }                     // 処理コード
        public SQLMuplurl muplurl { get; set; }                  // アップロードURL
        public SQLMsyori msyori { get; set; }                    // 処理選択
        public SQLKktoriikkatuitem1 mitemf1 { get; set; }        // 項目フィルタ1
        public SQLKkcf mitemf2 { get; set; }                     // 項目フィルタ2
        public string mdispctrlflg { get; set; }                 // 登録処理後画面制御実行フラグ
    }

    /// <summary>
    /// アップロードURL取得
    /// </summary>
    public class SQLMuplurl
    {
        public string uplurl { get; set; }                       // アップロードURL
        public string uplfol { get; set; }                       // アップロードfol
    }

    /// <summary>
    /// 処理選択取得
    /// </summary>
    public class SQLMsyori
    {
        public string SYORICD { get; set; }                    // 処理コード
        public int EDANO { get; set; }                         // 枝番号
        public string SYORINM { get; set; }                    // 処理名称
        public string YOSIKICD { get; set; }                   // 様式コード
        public string INSUPDKBN { get; set; }                  // 登録更新区分
        public string JIKKOKBN { get; set; }                   // 実行区分
        public string NENDOSIYOFLG { get; set; }               // 年度使用フラグ
        public string FILEPATH { get; set; }                   // ファイルパス
        public string FILENM { get; set; }                     // ファイル名称
        public string HFILENM { get; set; }                    // 編集ファイル名称
        public int ORDERID { get; set; }                       // 並び順
        public string DISPCHKFLG { get; set; }                 // 画面入力時チェックフラグ
        public string DISPROWFLG { get; set; }                 // 画面行自動作成フラグ
        public string DISPADDFLG { get; set; }                 // 画面追加可能フラグ
        public string DISPDELFLG { get; set; }                 // 画面削除可能フラグ
        public string CHKSTORED { get; set; }                  // 入力チェック用ストアドプロシージャ
        public string BEFSTORED { get; set; }                  // 前処理用ストアドプロシージャ
        public string AFTSTORED { get; set; }                  // 後処理用ストアドプロシージャ
    }

    /// <summary>
    /// 一括入力画面で使用するデータグリッドの情報を取得する
    /// </summary>
    public class SentakuResponse : DaResponseBase
    {
        public SQLMyosiki myosiki { get; set; }                  // 取込ファイル様式
        public string mcsvdata { get; set; }                     // CSVデータ
        public List<SQLMcflist> mcflist { get; set; }            // 一括入力画面コード内容(TC_KKCF用)
        public List<SQLMkikanlist> mkikanlist { get; set; }      // 一括入力画面施設内容(TC_KKKIKAN用)
        public List<SQLMstafflist> mstafflist { get; set; }      // 一括入力画面スタッフ内容(TC_KKSTAFF用)
    }

    /// <summary>
    /// 一括入力画面コード内容(TC_KKCF用)
    /// </summary>
    public class SQLMcflist
    {
        public string maincd { get; set; }                     // CFメインコード
        public string subcd { get; set; }                      // CFサブコード
        public string cd { get; set; }                         // ＣＤ
        public string naiyo { get; set; }                      // 内容
    }

    /// <summary>
    ///  一括入力画面施設内容(TC_KKKIKAN用)
    /// </summary>
    public class SQLMkikanlist
    {
        public string cd { get; set; }                        // 機関ＣＤ
        public string naiyo { get; set; }                     // 施設名称
        public string hcd { get; set; }                       // 全国共通医療機関コード
    }

    /// <summary>
    ///  一括入力画面スタッフ内容(TC_KKSTAFF用)
    /// </summary>
    public class SQLMstafflist
    {
        public string cd { get; set; }                        // スタッフＣＤ
        public string naiyo { get; set; }                     // 氏名
    }

    /// <summary>
    /// 初期値を取得する
    /// </summary>
    public class SyokiResponse : DaResponseBase
    {
        public string towncd { get; set; }                    // 市町村コード取得
        public SQLMkojin1 mkojin { get; set; }                 // 初期値
    }

    public class SQLMkojin1
    {
        public string yosikicd { get; set; }                      // 様式コード            
        public string komokucd { get; set; }                      // 項目コード            
        public string komokunm { get; set; }                      // 項目名称              
        public string tblnm { get; set; }                         // 対象テーブル名称      
        public string fldnm { get; set; }                         // 対象フィールド名称    
        public string setdata { get; set; }                       // 設定値                
        public string disptypekbn { get; set; }                   // 項目タイプ区分        
        public string typechkkbn { get; set; }                    // 項目タイプチェック区分
        public string cfmaincd { get; set; }                      // CFメインコード 
        public string cfsubcd { get; set; }                       // CFサブコード   
        public string dispsyoki { get; set; }                     // 画面初期値
    }

    /// <summary>
    ///  個人情報を取得する
    /// </summary>
    public class SaikeisanResponse : DaResponseBase
    {
        public SQLMkojin2 mkojin { get; set; }                    // 再計算結果取得
    }

    /// <summary>
    /// 再計算結果取得
    /// </summary>
    public class SQLMkojin2
    {
        public string yosikicd { get; set; }                      // 様式コード            
        public string komokucd { get; set; }                      // 項目コード            
        public string komokunm { get; set; }                      // 項目名称              
        public string tblnm { get; set; }                         // 対象テーブル名称      
        public string fldnm { get; set; }                         // 対象フィールド名称    
        public string setdata { get; set; }                       // 設定値                
        public string disptypekbn { get; set; }                   // 項目タイプ区分        
        public string typechkkbn { get; set; }                    // 項目タイプチェック区分
        public string cfmaincd { get; set; }                      // CFメインコード 
        public string cfsubcd { get; set; }                       // CFサブコード   
        public string dispformat { get; set; }                    // 表示変換書式
    }

    /// <summary>
    /// 一括入力画面のデータグリッドの情報をチェックする。
    /// </summary>
    public class ImportIkkatuCheckResponse : DaResponseBase
    {
        public SQLMerrcnt merrcnt { get; set; }                  // エラーチェック結果を取得(件数)
        public SQLMerrgyo merrgyo { get; set; }                  // エラーチェック結果を取得(行数)
        public SQLMerror merror { get; set; }                    // エラーチェック結果を取得
        public string mparam { get; set; }                       // パラメータを返却(処理区分)
    }

    /// <summary>
    /// エラーチェック結果を取得(件数)
    /// </summary>
    public class SQLMerrcnt
    {
        public string errorcnt { get; set; }                      // エラー結果(件数)
        public string warningcnt { get; set; }                    // 警告結果(件数)
        public string infocnt { get; set; }                       // 情報結果(件数)
    }

    /// <summary>
    /// エラーチェック結果を取得(行数)
    /// </summary>
    public class SQLMerrgyo
    {
        public string total { get; set; }                         // 総行数(行数)
        public string errwarngyo { get; set; }                    // エラー警告結果(行数)
        public string errorgyo { get; set; }                      // エラー結果(行数)
        public string warninggyo { get; set; }                    // 警告結果(行数)
        public string infogyo { get; set; }                       // 情報結果(行数)
    }

    /// <summary>
    /// エラーチェック結果を取得
    /// </summary>
    public class SQLMerror
    {
        public string gyono { get; set; }                         // 行番号
        public string komokucd { get; set; }                      // 項目コード
        public string errorkbn { get; set; }                      // エラー区分
        public string errorcd { get; set; }                       // エラーコード
        public string error { get; set; }                         // エラー
    }

    /// <summary>
    /// 一括入力画面グリッドをCSV出力する
    /// </summary>
    public class preTorokuResponse : DaResponseBase
    {
        public List<SQLStatus> status { get; set; }               // CSV作成用のデータ
    }

    /// <summary>
    /// CSV作成用のデータテーブルを作成する
    /// </summary>
    public class SQLStatus
    {
        public string yosikicd { get; set; }                       // 様式コード
        public string keisikikbn { get; set; }                     // データ形式区分
        public string mojicdkbn { get; set; }                      // 文字コード区分
        public string kugirikbn { get; set; }                      // 区切り記号区分
        public string inyofukbn { get; set; }                      // 引用符区分
        public string headerrow { get; set; }                      // ヘッダー部行数
    }

    /// <summary>
    /// 一括入力画面グリッドを登録する
    /// </summary>
    public class TorokuResponse : DaResponseBase
    {
        public SQLMerrgyo merrgyo { get; set; }                  // エラーチェック結果を取得(行数)
        public string mparam { get; set; }                       // パラメータを返却(処理区分)
    }
}