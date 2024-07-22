// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 医療機関検索
// 　　　　　　リクエストインターフェース
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00702D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string kikannm { get; set; }         //医療機関名
        public string kanakikannm { get; set; }     //医療機関名カナ
        public string? patternno { get; set; }      //パターンNo.(ドロップダウンリストコード)
        public string? jigyocds { get; set; }       //実施事業(複数「,」で連結)
        public string? hokenkikancd { get; set; }   //保険医療機関コード
        public bool hasStopFlg { get; set; }        //使用停止sql
    }
}