// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 保健指導・集団指導項目並び順設定
//             リクエストインターフェース
// 作成日　　: 2024.01.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00807D
{
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : AWKK00801G.SidoCommonRequest
    {
        public List<AWKK00805D.SaveVM> kekkalist { get; set; } //項目一覧
    }
}