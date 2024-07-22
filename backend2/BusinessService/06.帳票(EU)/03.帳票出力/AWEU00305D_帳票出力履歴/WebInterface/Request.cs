// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力履歴画面						
//         　  リクエストインターフェース
// 作成日　　: 2023.09.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00305D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string rptid { get; set; }                //帳票ID
        public string yosikiid { get; set; }             //様式ID
    }

    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class DownloadRequest : DaRequestBase
    {
        public long rirekiseq { get; set; }              //履歴シーケンス
    }
}