// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予約希望者管理
//             レスポンスインターフェース
// 作成日　　: 2024.03.07
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK00902G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitNitteiListResponse : AWKK00901G.InitListResponse
    {
        public List<DaSelectorModel> selectorlist6 { get; set; }    //コース一覧
    }

    /// <summary>
    /// 検索処理(日程一覧画面)
    /// </summary>
    public class SearchNitteiListResponse : CmSearchResponseBase
    {
        public List<NitteiRowVM> kekkalist { get; set; }    //日程情報
    }

    /// <summary>
    /// 初期化処理(コース一覧画面)
    /// </summary>
    public class InitCourseListResponse : DaResponseBase
    {
        public CourseHeaderVM headerinfo { get; set; }      //コース情報(ヘッダー)
        public List<CourseRowVM> kekkalist { get; set; }    //コース情報(明細)
        public bool editflg { get; set; }                   //編集フラグ(コピーボタン)
    }

    /// <summary>
    /// 初期化処理(予約者一覧画面)
    /// </summary>
    public class InitPersonListResponse : DaResponseBase
    {
        public PersonHeaderVM headerinfo { get; set; }      //日程基本情報(ヘッダー)
        public PersonDetailVM detailinfo { get; set; }      //日程基本情報(明細)
        public List<PersonRowVM> kekkalist { get; set; }    //結果一覧
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public PersonHeaderVM headerinfo { get; set; }          //日程基本情報
        public CommonBarHeaderBase3VM personinfo { get; set; }  //希望者情報
        public DetailVM detailinfo { get; set; }                //予約情報
        public DateTime? upddttm { get; set; }                  //更新日時(排他用)
    }

    /// <summary>
    /// チェック処理(詳細画面)
    /// </summary>
    public class CheckResponse : DaResponseBase
    {
        public bool overflg { get; set; }   //定員オーバーフラグ
    }
}