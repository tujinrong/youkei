// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行履歴管理
//             レスポンスインターフェース
// 作成日　　: 2024.03.22
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF01101G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(帳票名)
        public List<DaSelectorModel> selectorlist2 { get; set; }        //ドロップダウンリスト(様式名)
        public List<DaSelectorModel> selectorlist3 { get; set; }        //ドロップダウンリスト(抽出対象)

    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }                      //結果リスト(帳票発行履歴一覧)
    }
}