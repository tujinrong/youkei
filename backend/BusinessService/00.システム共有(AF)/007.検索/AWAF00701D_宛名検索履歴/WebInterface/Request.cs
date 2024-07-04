// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 宛名検索履歴
// 　　　　　　リクエストインターフェース
// 作成日　　: 2023.03.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00701D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string kinoid { get; set; }   //機能ID
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string kinoid { get; set; }   //機能ID
        public string atenano { get; set; }     //宛名番号
    }
}