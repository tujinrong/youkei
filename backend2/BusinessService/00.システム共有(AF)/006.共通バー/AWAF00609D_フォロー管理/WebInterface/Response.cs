// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理(共通バー)
//             レスポンスインターフェース
// 作成日　　: 2023.12.26
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00609D
{
    /// <summary>
    /// 検索処理(内容画面)
    /// </summary>
    public class SearchFollowNaiyoListResponse : CmSearchResponseBase
    {
        public List<DaSelectorModel> haakukeiroList { get; set; }       //ドロップダウンリスト(把握経路)
        public List<DaSelectorModel> haakujigyoList { get; set; }       //ドロップダウンリスト(把握事業)
        public List<DaSelectorModel> followstatusList { get; set; }     //ドロップダウンリスト(フォロー状況)
        public List<DaSelectorModel> followjigyoList { get; set; }      //ドロップダウンリスト(フォロー事業)
        public Common.CommonBarHeaderBase3VM headerinfo { get; set; }   //住民情報
        public List<RowFollowContentVM> kekkalist { get; set; }         //結果リスト(フォロー内容一覧)
    }
}