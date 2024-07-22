// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人検索
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2024.04.01
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00705D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> sexlist { get; set; }         //ドロップダウンリスト(性別)
        public List<DaSelectorModel> juminkbnlist { get; set; }    //ドロップダウンリスト(住民区分)
        public List<DaSelectorModel> hokenkbnlist { get; set; }    //ドロップダウンリスト(保険区分)
        public string[] juminkbns { get; set; }                    //ドロップダウンリスト(住民区分)初期値
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }     //個人情報
    }
}