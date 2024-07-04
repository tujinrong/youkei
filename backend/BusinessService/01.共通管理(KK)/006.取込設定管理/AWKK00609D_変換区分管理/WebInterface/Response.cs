// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.変換区分管理画面
// 　　　　　　レスポンスインターフェース
// 作成日　　: 2024.03.06
// 作成者　　: 高
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00609D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> codeManagerTableList { get; set; }                         // 【コ-ド管理テ-プル】のドロップダウンリスト
        public List<ChangeCodeMainExVM> changeCodeMainExList { get; set; }                     //変換コードメイン補充情報
    }

    /// <summary>
    /// 初期化処理(【メインコード】のドロップダウンリスト)
    /// </summary>
    public class InitMaincdResponse : DaResponseBase
    {
        public List<DaSelectorModel> maincdList { get; set; }                                   // 【メインコード】のドロップダウンリスト
    }

    /// <summary>
    /// 初期化処理(【サブコード】のドロップダウンリスト)
    /// </summary>
    public class InitSubcdResponse : DaResponseBase
    {
        public List<DaSelectorModel> subcdList { get; set; }                                    // 【サブコード】のドロップダウンリスト
    }
}