// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 基幹系他システム情報照会
//             リクエストインターフェース
// 作成日　　: 2023.10.03
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00101G
{
    /// <summary>
    /// 検索処理(世帯一覧)・初期化処理(詳細画面)
    /// </summary>
    public class CommonRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
    }
    /// <summary>
    /// 検索処理(詳細画面：共通)
    /// </summary>
    public class SearchCommonRequest : CommonRequest
    {
        public int rirekinum { get; set; }    //履歴No.
    }
    /// <summary>
    /// 検索処理(詳細画面：税額控除タブ全体)
    /// </summary>
    public class SearchKojoDetailRequest : CmSearchRequestBase
    {
        public int rirekinum { get; set; }      //履歴No.
        public string atenano { get; set; }     //宛名番号
    }
    /// <summary>
    /// 検索処理(詳細画面：税額控除タブ明細)
    /// </summary>
    public class SearchKojoDetailRowsRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public int kazeinendo { get; set; }     //課税年度
        public int kojorirekino { get; set; }   //税額控除情報履歴番号
    }
}