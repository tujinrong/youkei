// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報（世帯）
//             レスポンスインターフェース
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00604D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public HeaderVM headerinfo { get; set; }                    //世帯主基本情報
        public List<AWAF00601D.SearchVM> kekkalist { get; set; }    //メモ（世帯）情報
        public string[] jigyokbns { get; set; }                     //登録事業(登録範囲-CSV出力用)
    }
}