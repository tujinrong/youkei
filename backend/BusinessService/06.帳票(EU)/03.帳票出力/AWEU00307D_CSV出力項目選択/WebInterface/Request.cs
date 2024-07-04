// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: CSV出力項目選択
//             リクエストインターフェース
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00307D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string rptid { get; set; }           //帳票ID
        public string yosikiid { get; set; }        //様式ID
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : InitRequest
    {
        public int outputptnno { get; set; }        //出力パターン番号
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : SearchRequest
    {
        public string outputptnnm { get; set; }      //出力パターン名
        public List<string> kekkalist { get; set; }  //帳票項目リスト(出力用、ソート済)
        public DateTime? upddttm { get; set; }       //更新日時
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : SearchRequest
    {
        public DateTime upddttm { get; set; }        //更新日時
    }
}