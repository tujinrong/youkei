// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: バッチスケジュール管理
//             レスポンスインターフェース
// 作成日　　: 2024.02.06
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF01001G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(処理区分)
        public List<DaSelectorModel> selectorlist2 { get; set; }        //ドロップダウンリスト(業務区分)
        public List<DaSelectorModel> selectorlist3 { get; set; }        //ドロップダウンリスト(タスク名)
        public List<DaSelectorModel> selectorlist4 { get; set; }        //ドロップダウンリスト(前回処理結果)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }                      //結果リスト(バッチスケジュール一覧)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public List<DaSelectorModel> gyomukbnnmList { get; set; }       //業務区分
        public List<DaSelectorModel> syorikbnnmList { get; set; }       //処理区分
        public List<DaSelectorModel> modulenmList { get; set; }		    //モジュール
        public List<DaSelectorModel> tukinmList { get; set; }           //毎月の月
        public List<DaSelectorModel> nichinmList { get; set; }          //毎月の日(コード：名称)			
        public List<DaSelectorModel> syunmList { get; set; }            //毎月の週(コード：名称)
        public List<DaSelectorModel> yobinmList { get; set; }           //曜日(コード：名称)
        public List<DaSelectorModel> kurikaeshikannmList { get; set; }  //間隔
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public MainInfoVM mainInfo { get; set; }                        //バッチスケジュール管理情報

    }
}