// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 会場保守
//             レスポンスインターフェース
// 作成日　　: 2023.11.02
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00202G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }     //ドロップダウンリスト(会場コード)
        public bool exceloutflg { get; set; }                        //EXCEL出力フラグ
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse: CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }                  //結果リスト(会場一覧)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public List<TikuOneInitVM> tikuList { get; set; }           //地区リスト
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : InitDetailResponse
    {
        public MainInfoVM mainInfo { get; set; }                    //会場情報メイン
    }
}
