// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目編集
//             レスポンスインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00104D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<TableVM> tablelist { get; set; }             //テーブルリスト
        public List<DaSelectorModel> selectorlist1 { get; set; } //ドロップダウンリスト(使用区分)
        public List<DaSelectorModel> selectorlist2 { get; set; } //ドロップダウンリスト(集計項目区分)
        public List<DaSelectorModel> selectorlist3 { get; set; } //ドロップダウンリスト(データ型)
        public List<String> tableNamelist { get; set; }          //テーブル物理名リスト
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public bool editflg { get; set; }                        //編集可能フラグ
        public string itemhyojinm { get; set; }                  //表示名称
        public string sqlcolumn { get; set; }                    //SQLカラム
        public string tablealias { get; set; }                   //テーブル別名
        public string itemid { get; set; }                       //項目ID
        public string kanrentablealias { get; set; }             //関連テーブル別名
        public string daibunrui { get; set; }                    //大分類
        public string? tyubunrui { get; set; }                   //中分類
        public string? syobunrui { get; set; }                   //小分類
        public Enum使用区分 usekbn { get; set; }                 //使用区分
        public Enum出力項目区分 itemkbn { get; set; }            //todo 出力項目区分
        public Enum集計項目区分? syukeikbn { get; set; }         //集計項目区分
        public EnumDataType datatype { get; set; }               //データ型
        public string? mastercd { get; set; }                    //名称マスタコード
        public string? masterpara { get; set; }                  //名称マスタパラメータ
        public DateTime upddttm { get; set; }                    //更新日時
    }
}