// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検索条件編集(固定)
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00106D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string datasourceid { get; set; }             //データソースID
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : InitRequest
    {
        public int jyokenid { get; set; }                    //条件ID
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
        public string datasourceid { get; set; }             //データソースID
        public Enum検索条件区分 jyokenkbn { get; set; }      //検索条件区分
        public string sqlcolumn { get; set; }                //項目SEQ
        public string jyokenlabel { get; set; }              //ラベル
        public string sql { get; set; }                      //SQL
        public string syokiti { get; set; }                  //初期値
        public int jyokenid { get; set; }                    //条件ID
        public DateTime? upddttm { get; set; }                //更新日時
    }


    /// <summary>
    /// 条件SQL取得
    /// </summary>
    public class SqlRequest : DaRequestBase
    {
        public string sqlcolumn { get; set; }                //SQLカラム
        public string value { get; set; }                    //値
    }
}