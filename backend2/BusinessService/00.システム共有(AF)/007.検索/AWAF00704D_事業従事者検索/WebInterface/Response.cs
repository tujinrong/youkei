// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業従事者検索
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2023.10.20
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00704D
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(職種)
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(活動区分)
    }

    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }     //事業従事者（担当者）情報
    }
}
