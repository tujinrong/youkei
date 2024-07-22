// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索条件編集(通常)
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00105D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string datasourceid { get; set; }         //データソースID
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : InitRequest
    {
        public int jyokenid { get; set; }                //条件ID
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : SearchRequest
    {
        public string jyokenkbn { get; set; }      //検索条件区分
        public DateTime upddttm { get; set; }                //更新日時
    }

    /// <summary>
    /// 新規処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public string datasourceid { get; set; }         //データソースID
        public string sqlcolumn { get; set; }            //SQLカラム
        public string jyokenlabel { get; set; }          //ラベル
        public Enumコントロール controlkbn { get; set; } //コントロール区分
        public string sql { get; set; }                  //SQL
        public string? mastercd { get; set; }            //名称マスタコード
        public string? masterpara { get; set; }          //名称マスタパラメータ
        public string? sansyomotosql { get; set; }       //参照元SQL
        public string? nendohanikbn { get; set; }        //年度範囲区分
        public string? syokiti { get; set; }             //初期値
        public string? aimaikbn { get; set; }            //曖昧検索区分
        public int jyokenid { get; set; }                //条件ID
        public DateTime? upddttm { get; set; }            //更新日時
    }

    /// <summary>
    /// 条件SQL取得
    /// </summary>
    public class SqlRequest : DaRequestBase
    {
        public string sqlcolumn { get; set; }            //SQLカラム
        public Enumコントロール controlkbn { get; set; } //コントロール区分
    }

    public class SearchJokenDetailRequest : DaRequestBase
    {
        public int? controlkbn { get; set; }                   //コントロール区分
        public string mastercd { get; set; }                   //名称マスタコード
        public string masterpara { get; set; }                 //名称マスタパラメータ
    }
}