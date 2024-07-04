// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 宛名検索履歴
// 　　　　　　レスポンスインターフェース
// 作成日　　: 2023.03.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00701D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }     //宛名番号
    }
}