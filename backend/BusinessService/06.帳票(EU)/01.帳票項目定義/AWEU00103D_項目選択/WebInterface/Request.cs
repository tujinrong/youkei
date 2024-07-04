// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目選択
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00103D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string datasourceid { get; set; }            //データソースID
        public string? daibunrui { get; set; }              //大分類
        public string? tyubunrui { get; set; }              //中分類
        public string? syobunrui { get; set; }              //小分類
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public string datasourceid { get; set; }            //データソースID
        public HashSet<string> sqlcolumns { get; set; }     //SQLカラム集合
    }
}