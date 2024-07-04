// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お知らせ
//             レスポンスインターフェース
// 作成日　　: 2022.01.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00302D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist { get; set; } //ドロップダウンリスト(重要度)
        public List<UserVM> userlist { get; set; }              //ユーザー一覧リスト(全て、ログインユーザーを除く)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }  //お知らせ情報
    }
}