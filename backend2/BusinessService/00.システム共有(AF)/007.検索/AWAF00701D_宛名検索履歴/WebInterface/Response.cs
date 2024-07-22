// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 宛名検索履歴
// 　　　　　　レスポンスインターフェース
// 作成日　　: 2024.07.17
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