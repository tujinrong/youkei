// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行対象外者管理
//             レスポンスインターフェース
// 作成日　　: 2023.12.20
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK01001G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //一覧情報
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public GamenHeaderBaseVM headerinfo { get; set; }       //個人基本情報
        public List<DaSelectorModel> selectorlist { get; set; } //業務区分一覧
        public List<InitVM> kekkalist { get; set; }             //結果リスト(対象外者情報)
    }
}