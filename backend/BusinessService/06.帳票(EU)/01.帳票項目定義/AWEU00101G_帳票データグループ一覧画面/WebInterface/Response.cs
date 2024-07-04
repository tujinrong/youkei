// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票データグループ一覧
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00101G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist { get; set; }                  //ドロップダウンリスト(業務)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }                           //データグループ情報
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailTabResponse : DaResponseBase
    {
        public string datasourceid { get; set; }                                //データソースID
        public string maintablealias { get; set; }                              //メインテーブル別名
        public string datasourcenm { get; set; }                                //データソース名称
        public string gyoumu { get; set; }                                      //業務
        public DateTime upddttm { get; set; }                                   //更新日時
        public DatasourceTableVM maindata { get; set; }                         //メインテーブル
        public List<DatasourceTableVM> joindata { get; set; }                   //結合テーブルリスト
        public List<DatasourceTableVM> masterdata { get; set; }                 //マスタテーブルリスト
        public List<DatasourceTableVM> freedata { get; set; }                   //フリーテーブルリスト
        public List<DatasourceTableVM> viewdata { get; set; }                   //Viewリスト
    }

    /// <summary>
    /// 検索処理(詳細画面:検索条件タブ(通常))
    /// </summary>
    public class SearchConditionTabResponse : DaResponseBase
    {
        public List<ConditionVM> conditionlist { get; set; }                    //検索条件(通常)リスト
    }

    /// <summary>
    /// 検索処理(詳細画面:その他条件タブ)
    /// </summary>
    public class SearchOtherConditionTabResponse : DaResponseBase
    {
        public List<FixedConditionVM> fixedconditionlist { get; set; }           //検索条件(その他条件)リスト
    }

    /// <summary>
    /// 戻る更新時刻
    /// </summary>
    public class SaveResponse : DaResponseBase
    {
        public DateTime upddttm { get; set; }                                   //更新日時
    }
}