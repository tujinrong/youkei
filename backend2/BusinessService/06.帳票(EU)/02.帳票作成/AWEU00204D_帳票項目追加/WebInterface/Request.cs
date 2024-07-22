// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票項目追加
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00204D
{
    /// <summary>
    /// 一覧項目ツリー検索処理
    /// </summary>
    public class SearchNormalTreeRequest : DaRequestBase
    {
        public string? datasourceid { get; set; }     //データソースID
        public HashSet<string> itemids { get; set; }  //一覧項目ID

        public string? procnm { get; set; }            //プロシージャ名称
        public string? sql { get; set; }              //プロシージャ内容
    }

    /// <summary>
    /// 集計項目ツリー検索処理
    /// </summary>
    public class SearchStatisticTreeRequest : SearchNormalTreeRequest
    {
        public Enum集計区分? crosskbn { get; set; } //集計区分
    }

    /// <summary>
    /// 集計項目検索処理
    /// </summary>
    public class SearchStatisticRequest : DaRequestBase
    {
        public string? datasourceid { get; set; }     //データソースID
        public HashSet<string> itemids { get; set; }  //一覧項目ID
        public Enum集計区分? crosskbn { get; set; }   //集計区分
        public string? itemid { get; set; }           //項目ID

        public string? procnm { get; set; }           //プロシージャ名称
        public string? sql { get; set; }              //プロシージャ内容
    }
    /// <summary>
    /// チェック処理
    /// </summary>
    public class CheckRequest : DaRequestBase
    {
        public string? yosikiitemid { get; set; }    //様式項目ID
        public string? sqlcolumn { get; set; }      //SQLカラム
        public string? formatkbn { get; set; }      //フォーマット区分
        public string? formatkbn2 { get; set; }     //フォーマット区分2
    }
}