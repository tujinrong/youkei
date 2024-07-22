// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診結果・保健指導履歴照会
//             リクエストインターフェース
// 作成日　　: 2024.02.13
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00610D
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }    //宛名番号
    }

    /// <summary>
    /// 遷移処理
    /// </summary>
    public class SearchSeniRequest : DaRequestBase
    {
        public string jigyocd { get; set; }             //事業コード
        public List<string> kinoids { get; set; }       //開いた機能ID
        public string? kinoid2 { get; set; }            //一覧選択機能ID（保健指導・集団指導結果情報）
    }
}
