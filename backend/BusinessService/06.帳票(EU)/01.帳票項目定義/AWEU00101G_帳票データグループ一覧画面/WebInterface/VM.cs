// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票データグループ一覧
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00101G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchVM
    {
        public string datasourceid { get; set; }                         //データソースID
        public string datasourcenm { get; set; }                         //データソース名称
        public string gyoumu { get; set; }                               //業務
        public string maintablehyojinm { get; set; }                     //メインテーブル名称
        public string maintablenm { get; set; }                          //メインテーブル物理名
    }

    /// <summary>
    /// データソーステーブル
    /// </summary>
    public class DatasourceTableVM
    {
        public string tablealias { get; set; }                          //テーブル·別名
        public string tablenm { get; set; }                             //テーブル物理名
        public string tablehyojinm { get; set; }                        //テーブル名称
        public List<DatasourceTableItemVM> itemlist { get; set; }       //データソース項目リスト
        public DateTime upddttm { get; set; }                           //更新日時
    }

    /// <summary>
    /// データソース項目
    /// </summary>
    public class DatasourceTableItemVM : DeleteTableItemVM
    {
        public string itemid { get; set; }                             //データソース項目ID
        public string itemhyojinm { get; set; }                        //表示名称
        public string daibunrui { get; set; }                          //大分類
        public string? tyubunrui { get; set; }                         //中分類
        public string? syobunrui { get; set; }                         //小分類
    }

    /// <summary>
    /// 項目削除処理
    /// </summary>
    public class DeleteTableItemVM
    {
        public string sqlcolumn { get; set; }                          //SQLカラム
        public DateTime upddttm { get; set; }                          //更新日時
    }

    /// <summary>
    /// 検索条件(通常)
    /// </summary>
    public class ConditionVM
    {
        public int jyokenid { get; set; }                               //条件ID
        public string jyokenlabel { get; set; }                         //ラベル
        public string sql { get; set; }                                 //SQL
        public string control { get; set; }                             //コントロール
        public string? aimaikbn { get; set; }                           //曖昧検索区分
    }

    /// <summary>
    /// 検索条件(固定)
    /// </summary>
    public class FixedConditionVM
    {
        public int jyokenid { get; set; }                              //条件ID
        public string jyokenlabel { get; set; }                        //ラベル
        public string sql { get; set; }                                //SQL
        public string jyokenkbn { get; set; }                          //検索条件区分
        public string? variables { get; set; }                         //変数名
        public string tablealias { get; set; }                         //テーブル名
        public Enumコントロール controlkbn { get; set; }               //コントロール区分
        public string? mastercd { get; set; }                          //名称マスタコード
        public string? masterpara { get; set; }                        //名称マスタパラメータ
        public string? sansyomotosql { get; set; }                     //参照元SQL
        public EnumDataType datatype { get; set; }                     //データ型
        public string? aimaikbn { get; set; }                       　　//曖昧検索区分
    }
}