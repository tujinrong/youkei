// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 住民情報履歴照会
//             リクエストインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00102D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string atenano { get; set; } //宛名番号
    }
}