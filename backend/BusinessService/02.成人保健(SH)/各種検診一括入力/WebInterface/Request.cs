// *******************************************************************
// 業務名称　: 各健康管理システム
// 機能概要　: 各種検診一括入力
//             リクエストインターフェース
// 作成日　　: 2022.12.12
// 作成者　　: 韓
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.KK_kosin_ikkatu
{
    /// <summary>
    /// 取込処理画面で使用する種別コードを抽出する。
    /// </summary>
    public class FormInitImpRequest : DaRequestBase
    {
        public string pgid { get; set; }                // プログラムＩＤ
        public string jikkokbn { get; set; }            // 実行区分(1:取込処理,2:一括入力)
    }

    /// <summary>
    /// 取込エラーリストの出力を行う
    /// </summary>
    public class RepCreateRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string nendo { get; set; }                // 年度
        public string syoricd { get; set; }              // 処理コード
        public string edano { get; set; }                // 健診回数(枝番号)
        public string yosikicd { get; set; }             // 様式コード
        public string jikkokbn { get; set; }             // 実行区分
        public string taisyo { get; set; }               // 対象リスト
        public string outputtype { get; set; }           // 出力種類
    }

    /// <summary>
    /// 個人情報を取得する
    /// </summary>
    public class KojinKensakuRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string kojinno { get; set; }              // 個人番号
        public string gyono { get; set; }                // 行番号
        public string yosikicd { get; set; }             // 様式コード
    }

    /// <summary>
    /// 取込情報の履歴情報を取得する
    /// </summary>
    public class RirekiRequest : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string syoricd { get; set; }               // 処理CD
        public string edano { get; set; }                 // 処理CD枝番号
    }

    /// <summary>
    /// 取込情報画面で使用するデータを抽出する。
    /// </summary>

    public class Kensaku1Request : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string syoricd { get; set; }               // 処理コード
        public string edano { get; set; }                 // 枝番号
        public string nendo { get; set; }                 // 対象年度
    }

    /// <summary>
    /// 取込情報画面で使用するデータグリッド用のレイアウトデータを抽出する。
    /// </summary>
    public class LayoutRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string yosikicd { get; set; }             // 様式コード
        public string jikkokbn { get; set; }             // 実行区分
    }

    /// <summary>
    /// 取込情報画面で使用するデータグリッドのデータを取得する
    /// </summary>
    public class GetFileDataRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string filename { get; set; }             // ファイル名
        public string yosikicd { get; set; }             // 様式コード
        public string syoricd { get; set; }              // 処理コード
        public string edano { get; set; }                // 枝番号
    }

    /// <summary>
    /// 一括入力で使用するデータグリッドのデータを取得する
    /// </summary>
    public class JikkoRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string filename { get; set; }             // ファイル名
        public string yosikicd { get; set; }             // 様式コード
        public string syoricd { get; set; }              // 処理コード
        public string edano { get; set; }                // 枝番号
    }

    /// <summary>
    /// 一括入力画面で使用する種別コードを抽出する。
    /// </summary>
    public class FormInitIkkatuRequest : DaRequestBase
    {
        public string pgid { get; set; }                 // プログラムＩＤ
        public string jikkokbn { get; set; }             // 実行区分(1:取込処理,2:一括入力)
        public string yosikicd { get; set; }             // 様式コード
    }

    /// <summary>
    /// 一括入力画面で使用するデータグリッドの情報を取得する
    /// </summary>
    public class SentakuRequest : DaRequestBase
    {
        public string systemcd { get; set; }             // 処理コード
        public string yosikicd { get; set; }             // 様式コード
        public string filename { get; set; }             // ファイル名
        public string jikkokbn { get; set; }             // 実行区分(1:取込処理,2:一括入力)
    }

    /// <summary>
    /// 初期値を取得する
    /// </summary>
    public class SyokiRequest : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string nendo { get; set; }                 // 対象年度
        public string syoricd { get; set; }               // 処理コード
        public string edano { get; set; }                 // 枝番号
        public string gyono { get; set; }                 // 行番号
        public string taisyo { get; set; }                // 対象リスト
        public string yosikicd { get; set; }              // 様式コード
    }

    /// <summary>
    /// 個人情報を取得する
    /// </summary>
    public class SaikeisanRequest : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string nendo { get; set; }                 // 対象年度
        public string syoricd { get; set; }               // 処理コード
        public string edano { get; set; }                 // 枝番号
        public string gyono { get; set; }                 // 行番号
        public string taisyo { get; set; }                // 対象リスト
        public string yosikicd { get; set; }              // 様式コード
    }

    /// <summary>
    /// 一括入力画面のデータグリッドの情報をチェックする。
    /// </summary>
    public class ImportIkkatuCheckRequest : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string nendo { get; set; }                 // 対象年度
        public string syoricd { get; set; }               // 処理コード
        public string edano { get; set; }                 // 枝番号
        public string yosikicd { get; set; }              // 様式コード
        public string jikkokbn { get; set; }              // 実行区分(1:取込処理,2:一括入力)
        public string syorikbn { get; set; }              // 処理区分(1:ｴﾗｰﾁｪｯｸ,2:登録,3ｴﾗｰﾘｽﾄ,4:csv)
        public string taisyo { get; set; }                // 対象リスト
    }

    /// <summary>
    /// 一括入力画面グリッドをCSV出力する
    /// </summary>
    public class preTorokuRequest : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string nendo { get; set; }                 // 対象年度
        public string syoricd { get; set; }               // 処理コード
        public string edano { get; set; }                 // 枝番号
        public string item { get; set; }                  // 項目名リスト
        public string taisyo { get; set; }                // 対象リスト
        public string sfileName { get; set; }             // 保存ファイル名
        public string yosikicd { get; set; }              // 様式コード
    }

    /// <summary>
    /// 一括入力画面グリッドを登録する
    /// </summary>
    public class Toroku1Request : DaRequestBase
    {
        public string systemcd { get; set; }              // 処理コード
        public string nendo { get; set; }                 // 対象年度
        public string syoricd { get; set; }               // 処理コード
        public string edano { get; set; }                 // 枝番号
        public string yosikicd { get; set; }              // 様式コード
        public string jikkokbn { get; set; }              // 実行区分(1:取込処理,2:一括入力)
        public string keizokukbn { get; set; }            // 処理継続区分(0:ﾜｰｸﾃｰﾌﾞﾙ削除のみ実行、1:登録実行)
        public string taisyo { get; set; }                // 対象者リスト
        public string fileNm { get; set; }                // 取込ファイル名、修正再開ファイル名
    }

}