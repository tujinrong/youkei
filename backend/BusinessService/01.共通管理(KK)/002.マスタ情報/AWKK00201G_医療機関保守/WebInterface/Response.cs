// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 医療機関保守
//             レスポンスインターフェース
// 作成日　　: 2023.12.6
// 作成者　　: CNC張加恒
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00201G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }     //ドロップダウンリスト(医療機関コード)
        public List<DaSelectorModel> selectorlist2 { get; set; }     //ドロップダウンリスト(保険医療機関コード)
        public bool exceloutflg { get; set; }                        //EXCEL出力フラグ
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse: CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }                  //結果リスト(医療機関一覧)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public List<JissijigyoModel> jissijigyoList { get; set; }               //実施事業リスト
        public List<DaSelectorModel> syozokuisikaiList { get; set; }            //所属医師会リスト
        public List<DaSelectorModel> gyoSelectorList { get; set; }          //業務ドロップダウンリスト
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : InitDetailResponse
    {
        public MainInfoVM mainInfo { get; set; }                            //医療機関情報メイン
        public List<JissijigyoModel> jissijigyoSelectorList { get; set; }   //実施事業ドロップダウンリスト
        public DateTime? upddttm { get; set; }                              //更新日時
    }
}
