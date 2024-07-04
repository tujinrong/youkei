// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予定管理
//             レスポンスインターフェース
// 作成日　　: 2024.03.01
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00901G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //業務区分一覧
        public List<DaSelectorKeyModel> selectorlist2 { get; set; } //予約事業一覧
        public List<DaSelectorModel> selectorlist3 { get; set; }    //会場一覧
        public List<DaSelectorModel> selectorlist4 { get; set; }    //医療機関一覧
        public List<DaSelectorModel> selectorlist5 { get; set; }    //担当者一覧
    }

    /// <summary>
    /// 検索処理(一覧画面：日程)
    /// </summary>
    public class SearchNitteiListResponse : CmSearchResponseBase
    {
        public List<NitteiRowVM> kekkalist { get; set; }    //日程情報
    }

    /// <summary>
    /// 検索処理(一覧画面：コース)
    /// </summary>
    public class SearchCourseListResponse : CmSearchResponseBase
    {
        public List<CourseRowVM> kekkalist { get; set; }    //コース情報
    }

    /// <summary>
    /// 初期化処理(詳細画面：日程)
    /// </summary>
    public class InitNitteiDetailResponse : InitListResponse
    {
        public NitteiHeaderVM headerinfo { get; set; }  //日程情報(ヘッダー)
        public NitteiDetailVM detailinfo { get; set; }  //日程情報(明細)
        public bool editflg { get; set; }               //編集フラグ
        public DateTime? upddttm { get; set; }          //更新日時(排他用)
    }

    /// <summary>
    /// 初期化処理(詳細画面：コース)
    /// </summary>
    public class InitCourseDetailResponse : InitListResponse
    {
        public CourseHeaderVM headerinfo { get; set; }          //コース情報(ヘッダー)
        public List<CourseDetailVM> detailinfo { get; set; }    //コース情報(明細)
        public bool editflg { get; set; }                       //編集フラグ
        public DateTime? upddttm { get; set; }                  //更新日時(排他用)
    }
}