// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 地区保守
//             レスポンスインターフェース
// 作成日　　: 2023.09.22
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00204G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(地区区分)
        public List<DaSelectorKeyModel> selectorlist2 { get; set; }     //ドロップダウンリスト(地区コード)
        public List<DaSelectorModel> selectorlist3 { get; set; }        //ドロップダウンリスト(地区担当者)
        public bool exceloutflg { get; set; }                           //EXCEL出力フラグ
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //結果リスト(地区一覧)
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public SaveMainVM maininfo { get; set; }            //地区情報
        public List<SubInfoVM> stafflist { get; set; }      //地区担当者情報
    }

    /// <summary>
    /// 検索処理(地区担当者情報)
    /// </summary>
    public class SearchRowResponse : DaResponseBase
    {
        public SubInfoVM staffinfo { get; set; }    //地区担当者情報
    }
}