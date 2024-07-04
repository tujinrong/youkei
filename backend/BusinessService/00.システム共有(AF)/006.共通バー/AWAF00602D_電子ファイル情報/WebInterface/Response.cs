// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 電子ファイル情報
//             レスポンスインターフェース
// 作成日　　: 2023.03.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00602D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist { get; set; }     //ドロップダウンリスト(事業区分)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public Common.CommonBarHeaderBaseVM headerinfo { get; set; }    //個人基本情報
        public List<SearchVM> kekkalist { get; set; }                   //ドキュメント情報
    }
}