// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 世帯検索
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2023.11.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00706D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string kname { get; set; }           //世帯主カナ氏名
        public string name { get; set; }            //世帯主氏名
        public string adrs_yubin { get; set; }      //世帯郵便番号
        public string adrs { get; set; }            //世帯住所
    }
}