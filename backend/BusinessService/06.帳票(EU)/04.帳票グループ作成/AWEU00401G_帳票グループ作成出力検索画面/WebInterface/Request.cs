// *******************************************************************
// 業務名称　: 帳票グループ作成
// 機能概要　: 帳票グループ出力検索画面							
//          　 リクエストインターフェース 
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00401G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string? rptgroupid { get; set; }  //帳票グループID
    }

    public class SearchMaxGroupidRequest : DaRequestBase
    {
        public string packageMark { get; set; }  //パッケージ/独自 
    }
}