// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: データグループ新規作成
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00102D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<TableVM> tablelist { get; set; }                //メインテーブルリスト
        public List<DaSelectorModel> selectorlist { get; set; }     //業務区分リスト
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<TableVM> jointablelist { get; set; }           //その他テーブルリスト
        public List<TableItemVM> tableitemlist { get; set; }       //テーブル項目リスト
        public List<string> daibunruilist { get; set; }  //大分類リスト
    }
}