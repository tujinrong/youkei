// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人番号情報履歴
//             リクエストインターフェース
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00113D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string atenano { get; set; } //宛名番号
    }
}