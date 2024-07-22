// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業従事者検索
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2023.10.20
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00704D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string staffsimei { get; set; }  //事業従事者氏名
        public string syokusyu { get; set; }    //職種
        public string katudokbn { get; set; }   //活動区分
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
        public string? jigyocds { get; set; }   //実施事業(複数「,」で連結)
        public bool hasStopFlg { get; set; }    //使用停止sql
    }
}
