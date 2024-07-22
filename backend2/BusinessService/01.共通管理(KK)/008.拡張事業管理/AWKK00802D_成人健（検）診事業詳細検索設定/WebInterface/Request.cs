// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人健（検）診事業詳細検索設定
//             リクエストインターフェース
// 作成日　　: 2024.01.15
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00802D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string jigyocd { get; set; } //成人健（検）診事業コード
    }
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : SearchRequest
    {
        public List<SaveVM> kekkalist { get; set; }  //画面一覧
    }
}