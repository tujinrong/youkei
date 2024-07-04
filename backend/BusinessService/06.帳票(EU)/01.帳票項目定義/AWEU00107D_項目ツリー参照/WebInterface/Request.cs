// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目ツリー参照
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00107D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string datasourceid { get; set; } //データソースID
    }
}