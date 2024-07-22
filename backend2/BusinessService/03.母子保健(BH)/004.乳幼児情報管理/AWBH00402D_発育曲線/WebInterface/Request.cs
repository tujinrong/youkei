// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: -発育曲線
//             リクエストインターフェース
// 作成日　　: 2024.05.17
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00402D
{
    /// <summary>
    /// 発育曲線表示処理
    /// </summary>
    public class ShowCurveRequest : CmSearchRequestBase
    {
        public string bosikbn { get; set; } = AWBH00301G.母子種類._2;   //母子種類
        public string atenano { get; set; }                             //宛名番号
    }
}