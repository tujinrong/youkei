// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 成人検診事業項目並び順設定
//             リクエストインターフェース
// 作成日　　: 2024.01.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00805D
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
        public List<SaveVM> kekkalist1 { get; set; }  //固定項目一覧(左)
        public List<SaveVM> kekkalist2 { get; set; }  //フリー項目一覧(右)
    }
}