// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目選択
//             ビューモデル定義
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00103D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class TableItemVM
    {
        public string itemid { get; set; }      //項目ID
        public string itemhyojinm { get; set; } //表示名称
        public string sqlcolumn { get; set; }   //SQLカラム
        public string daibunrui { get; set; }   //大分類
        public string tyubunrui { get; set; }   //中分類
        public string syobunrui { get; set; }   //小分類
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class TableVM
    {
        public string tablealias { get; set; }                 //テーブル·別名
        public string tablenm { get; set; }                    //テーブル物理名
    }
}