// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目出力順編集
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00306D
{
    public class InitRequest : DaRequestBase
    {
        public string rptid { get; set; }         //帳票ID
        public string yosikiid { get; set; }      //様式ID
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string rptid { get; set; }        //帳票ID
        public string yosikiid { get; set; }     //様式ID
        public string sortptnno { get; set; }    //出力順パターン番号
    }

    /// <summary>
    /// 新規処理
    /// </summary>
    public class AddRequest : DaRequestBase
    {
        public string rptid { get; set; }                   //帳票ID
        public string yosikiid { get; set; }                //様式ID
        public string sortptnnm { get; set; }               //出力順パターン名
        public List<SortSubVM> sortsublist { get; set; }    //出力順の項目詳細リスト
        public DateTime? yosikiupddttm { get; set; }         //様式更新日時
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public class UpdateRequest : DaRequestBase
    {
        public string rptid { get; set; }                   //帳票ID
        public string yosikiid { get; set; }                //様式ID
        public string sortptnno { get; set; }               //出力順パターン番号
        public string sortptnnm { get; set; }               //出力順パターン名
        public List<SortSubVM> sortsublist { get; set; }    //出力順の項目詳細リスト
        public DateTime sortupddttm { get; set; }           //出力順更新日時
        public DateTime? yosikiupddttm { get; set; }         //様式更新日時
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string rptid { get; set; }                 //帳票ID
        public string yosikiid { get; set; }              //様式ID
        public string sortptnno { get; set; }             //出力順パターン番号
        public DateTime sortupddttm { get; set; }         //出力順更新日時
        public DateTime yosikiupddttm { get; set; }       //様式更新日時
    }
}