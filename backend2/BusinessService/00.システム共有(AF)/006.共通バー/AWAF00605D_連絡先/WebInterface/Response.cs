// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 連絡先
//             レスポンスインターフェース
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00605D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<SearchVM> kekkalist { get; set; } //連絡先情報一覧
    }
}