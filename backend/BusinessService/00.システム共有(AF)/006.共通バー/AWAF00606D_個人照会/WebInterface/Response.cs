// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人照会
//             レスポンスインターフェース
// 作成日　　: 2023.09.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00606D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public HeaderVM headerinfo { get; set; }        //個人基本情報
        public Tab1DetailVM detailinfo1 { get; set; }   //住民情報その他情報
        public Tab2DetailVM detailinfo2 { get; set; }   //課税・保険・介護情報
    }
}