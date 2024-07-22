// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 警告情報照会
//             レスポンスインターフェース
// 作成日　　: 2023.09.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00607D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<SearchVM> kekkalist { get; set; } //警告情報一覧
    }
}