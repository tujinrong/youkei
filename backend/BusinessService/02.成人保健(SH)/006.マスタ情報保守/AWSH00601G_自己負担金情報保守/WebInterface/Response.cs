// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 自己負担金情報保守
//             レスポンスインターフェース
// 作成日　　: 2024.03.05
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00601G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public int nendo { get; set; }                                  //年度
        public List<int> nendolist { get; set; }                        //年度範囲
        public bool hikitsudugiflg { get; set; }                        //「前年度引続ぎ」活性フラグ
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(成人健(検)診事業名)
        public List<DaSelectorModel> selectorlist2 { get; set; }        //ドロップダウンリスト(料金パターン)
    }

    /// <summary>
    /// 年度変更処理(一覧画面)
    /// </summary>
    public class SearchNendoResponse : DaResponseBase
    {
        public bool hikitsudugiflg { get; set; }                        //「前年度引続ぎ」活性フラグ
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(成人健(検)診事業名)
        public List<DaSelectorModel> selectorlist2 { get; set; }        //ドロップダウンリスト(料金パターン)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist3 { get; set; }        //ドロップダウンリスト(検査方法)
        public List<DaSelectorModel> selectorlist4 { get; set; }        //ドロップダウンリスト(減免区分＝1(特定健診)、減免区分＝2(がん検診))
        public List<DaSelectorModel> selectorlist5 { get; set; }        //ドロップダウンリスト(性別)
        public List<RowVM> kekkalist { get; set; }                      //結果リスト(検索結果一覧)
        public List<LockVM> locklist { get; set; }                      //排他チェック用リスト
    }
}