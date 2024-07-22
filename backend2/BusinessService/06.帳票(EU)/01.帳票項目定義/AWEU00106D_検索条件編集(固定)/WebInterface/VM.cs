// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索条件編集(固定)
//             ビューモデル定義
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00106D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class ItemDaiBunruiVM
    {
        public string daibunrui { get; set; } 　　　　　　　　　　　　　//大分類
        public List<DatasourceItemVM> itemlist { get; set; } 　　　　　 //項目リスト
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public class DatasourceItemVM
    {
        public string itemid { get; set; }                             //項目ID
        public string sqlcolumn { get; set; }                          //SQLカラム
        public string itemhyojinm { get; set; }                        //表示名称
        public string datatype { get; set; }                           //データ型
    }
}