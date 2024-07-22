// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予定管理
//             レスポンスインターフェース
// 作成日　　: 2024.02.13
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH00401G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; } //成人健（検）診予約日程事業一覧
        public List<DaSelectorModel> selectorlist2 { get; set; } //会場一覧
        public List<DaSelectorModel> selectorlist3 { get; set; } //医療機関一覧
        public List<DaSelectorModel> selectorlist4 { get; set; } //担当者一覧
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<ColumnInfoVM> columnInfos { get; set; }     //列情報
        public List<List<DataInfoVM>> kekkalist { get; set; }   //結果一覧(予約情報)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : GetEditYoyakuResponse
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //成人健（検）診予約日程事業一覧
        public List<DaSelectorModel> selectorlist2 { get; set; }    //会場一覧
        public List<DaSelectorModel> selectorlist3 { get; set; }    //医療機関一覧
        public List<DaSelectorModel> selectorlist4 { get; set; }    //担当者一覧
        public DetailVM maininfo { get; set; }                      //予定メイン情報
        public List<RowVM> kekkalist { get; set; }                  //予定定員情報一覧
        public bool editflg { get; set; }                           //編集フラグ
        public DateTime? upddttm { get; set; }                      //更新日時(排他用)
    }

    /// <summary>
    /// 編集可能予約一覧取得処理(詳細画面)
    /// </summary>
    public class GetEditYoyakuResponse : DaResponseBase
    {
        public List<RowKeyVM> editlist { get; set; }    //予定定員情報一覧(制御用)
    }
}