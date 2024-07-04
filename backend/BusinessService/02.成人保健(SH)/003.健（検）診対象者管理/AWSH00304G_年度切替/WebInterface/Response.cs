// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 年度切替
//             レスポンスインターフェース
// 作成日　　: 2024.01.31
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00304G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : AWSH00301G.InitResponse
    {
        public List<DaSelectorModel> selectorlist8 { get; set; }    //引継ぎ区分一覧
    }
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<AWSH00301G.RowVM> kekkalist { get; set; }  //情報一覧
        public List<AWSH00301G.LockVM> locklist { get; set; }  //排他チェック用リスト
    }
}