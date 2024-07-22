// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: データグループ新規作成
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00102D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string tablealias { get; set; } 　　　　　　　　　　//テーブル·別名
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string datasourceid { get; set; } 　　　　　　　　//データソースID
        public string datasourcenm { get; set; } 　　　　　　　　//データソース名称
        public string gyoumucd { get; set; } 　　　　　　　　　　//業務コード
        public string maintablealias { get; set; }　　　　　　　 //メインテーブル別名
        public HashSet<string> sqlcolumns { get; set; } 　　　　 //メインテーブルSQLカラム集合
    }
}