// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業従事者（担当者）保守
//             レスポンスインターフェース
// 作成日　　: 2023.12.4
// 作成者　　: 劉誠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00203G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> staffidSelectorList { get; set; }      //事業従業者IDドロップダウンリスト
        public List<DaSelectorModel> kikanSelectorList { get; set; }        //医療機関ドロップダウンリスト
        public List<DaSelectorModel> syokusyunmSelectorList { get; set; }   //職種ドロップダウンリスト
        public List<DaSelectorModel> katudokbnnmSelectorList { get; set; }  //活動区分ドロップダウンリスト
        public bool exceloutflg { get; set; }                               //EXCEL出力フラグ
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<StaffRowVM> kekkaList { get; set; }                     //事業従業者（担当者）情報リスト
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public DateTime? upddttm { get; set; }                              //更新日時
        public MainInfoVM mainInfo { get; set; }                            //事業従業者（担当者）メイン情報
        public List<string> kikanlist { get; set; }                         //医療機関リスト
        public List<DaSelectorKeyModel> kikanSelectorList { get; set; }        //医療機関ドロップダウンリスト
        public List<JissijigyoModel> jissijigyoSelectorList { get; set; }   //実施事業ドロップダウンリスト
        public List<DaSelectorModel> gyoSelectorList { get; set; }          //業務ドロップダウンリスト

    } 
 
}