// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診結果・保健指導履歴照会
//             レスポンスインターフェース
// 作成日　　: 2024.02.13
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00610D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public PersonHeaderVM headerinfo { get; set; }   //住民情報

        public List<RowVM> kekkalist { get; set; }       //結果リスト(健（検）診結果・保健指導履歴照会情報一覧)
    }

    /// <summary>
    /// 遷移処理
    /// </summary>
    public class SearchSeniResponse : DaResponseBase
    {
        public string kinoid { get; set; }    //機能ID
    }
}