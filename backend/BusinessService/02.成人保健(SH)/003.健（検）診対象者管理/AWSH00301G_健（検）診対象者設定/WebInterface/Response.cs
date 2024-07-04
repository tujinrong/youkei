// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診対象者設定
//             レスポンスインターフェース
// 作成日　　: 2024.01.30
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00301G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //事業一覧
        public List<DaSelectorKeyModel> selectorlist2 { get; set; } //検査方法一覧
        public List<DaSelectorModel> selectorlist3 { get; set; }    //性別一覧
        public List<DaSelectorModel> selectorlist4 { get; set; }    //基準日区分一覧
        public List<DaSelectorModel> selectorlist5 { get; set; }    //保険区分一覧
        public List<DaSelectorModel> selectorlist6 { get; set; }    //特殊処理一覧
        public int nendo { get; set; }                              //年度
    }
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //情報一覧
        public List<LockVM> locklist { get; set; }  //排他チェック用リスト
    }
}