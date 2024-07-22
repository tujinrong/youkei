// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目編集
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00104D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string datasourceid { get; set; }                                  //データソースID
        public string? sqlcolumn { get; set; }                                    //SQLカラム
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string datasourceid { get; set; }                                  //データソースID
        public string sqlcolumn { get; set; }                                     //SQLカラム
    }

    /// <summary>
    /// 新規/更新処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public string datasourceid { get; set; }                                  //データソースID
        public string sqlcolumn { get; set; }                                     //SQLカラム
        public string? oldsqlcolumn { get; set; }                                  //旧SQLカラム
        public DateTime? upddttm { get; set; }                                      //更新日時

        public string tablealias { get; set; }                                     //テーブル別名
        public string itemid { get; set; }                                         //項目ID
        public string itemhyojinm { get; set; }                                    //表示名称
        public string daibunrui { get; set; }                                      //大分類
        public string? tyubunrui { get; set; }                                     //中分類
        public string? syobunrui { get; set; }                                     //小分類
        public Enum使用区分 usekbn { get; set; }                                   //使用区分
        public Enum出力項目区分 itemkbn { get; set; } = Enum出力項目区分.普通項目; //todo 出力項目区分
        public Enum集計項目区分? syukeikbn { get; set; }                           //集計項目区分
        public EnumDataType datatype { get; set; }                                 //データ型
        public string? mastercd { get; set; }                                      //名称マスタコード
        public string? masterpara { get; set; }                                    //名称マスタパラメータ
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : SearchRequest
    {
        public DateTime upddttm { get; set; }                                      //更新日時 
    }
}