// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力履歴画面		
//          　 レスポンスインターフェース 
// 作成日　　: 2024.07.26
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