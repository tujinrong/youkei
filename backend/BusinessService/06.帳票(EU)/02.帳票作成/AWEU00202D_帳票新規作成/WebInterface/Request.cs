// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票新規作成
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00202D
{
    /// <summary>
    /// チェック処理
    /// </summary>
    public class CheckRequest : DaRequestBase
    {
        public Enum帳票様式 kbn { get; set; }   //帳票様式
        public string rptid { get; set; }       //帳票ID
        public string rptnm { get; set; }       //帳票名
        public string yosikinm { get; set; }    //様式名
    }

}