// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 料金内訳
//             レスポンスインターフェース
// 作成日　　: 2024.02.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00403D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public HeaderVM headerinfo { get; set; }    //個人基本情報
        public List<RowVM> kekkalist { get; set; }  //自己負担金情報
    }
}