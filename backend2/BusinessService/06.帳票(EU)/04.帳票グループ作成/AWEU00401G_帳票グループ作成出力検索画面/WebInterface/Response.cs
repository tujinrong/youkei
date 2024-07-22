// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ作成検索画面		
//          　 レスポンスインターフェース 
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00401G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> groupList { get; set; } // 帳票グループのドロップダウンリスト
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; } // 検索結果リスト
    }

    /// <summary>
    /// 帳票グループID処理
    /// </summary>
    public class SearchMaxGroupidResponse : DaResponseBase
    {
        public string maxGroupid { get; set; }     // 帳票グループID
    }
}