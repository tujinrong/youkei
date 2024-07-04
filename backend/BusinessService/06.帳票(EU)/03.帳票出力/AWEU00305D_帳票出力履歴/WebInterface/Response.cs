// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力履歴画面		
//          　 レスポンスインターフェース 
// 作成日　　: 2023.04.26
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00305D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<RirekiVM> kekkalist { get; set; }　//検索結果リスト
    }
}