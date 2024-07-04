// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(固定)
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00106D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<ItemDaiBunruiVM> itemdaibunruilist { get; set; }      //項目大分類リスト
        public List<DaSelectorModel> selectorlist { get; set; }           //ドロップダウンリスト(固定検索条件区分)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public Enum検索条件区分 jyokenkbn { get; set; }                    //検索条件区分
        public string jyokenlabel { get; set; }                            //ラベル
        public string daibunrui { get; set; }                              //大分類
        public string itemid { get; set; }                                 //項目ID
        public string sqlcolumn { get; set; }                              //SQLカラム
        public string itemhyojinm { get; set; }                            //表示名称
        public string datatype { get; set; }                               //データ型
        public string? syokiti { get; set; }                               //初期値
        public string sql { get; set; }                                    //SQL
        public DateTime upddttm { get; set; }                              //更新日時
    }

    /// <summary>
    /// 条件SQL取得
    /// </summary>
    public class SqlResponse : DaResponseBase
    {
        public string sql { get; set; }                                     //SQL
    }
}