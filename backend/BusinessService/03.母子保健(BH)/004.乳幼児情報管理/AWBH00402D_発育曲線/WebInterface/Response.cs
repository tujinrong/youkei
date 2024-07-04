// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理-発育曲線
//             レスポンスインターフェース
// 作成日　　: 2024.05.17
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00402D
{
    /// <summary>
    /// 5.発育曲線表示処理
    /// </summary>
    public class ShowCurveResponse : CmSearchResponseBase
    {
        public HeaderInfoVM headerinfo { get; set; }                    //乳幼児情報（固定部分）
        public List<GraphListVM> graphlist { get; set; }                //発育曲線リスト
    }
}