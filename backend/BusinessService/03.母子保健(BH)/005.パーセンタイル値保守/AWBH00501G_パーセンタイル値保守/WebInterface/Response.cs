// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: パーセンタイル値保守
//             レスポンスインターフェース
// 作成日　　: 2024.06.01
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00501G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> buicdlist { get; set; }        //ドロップダウンリスト(部位リスト)
        public List<DaSelectorModel> sexlist { get; set; }          //ドロップダウンリスト(性別リスト)
    }

    /// <summary>
    /// パーセンタイル値保守画面検索処理
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<PasentairuListVM> kekkalist { get; set; }       //結果リスト(結果一覧)
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class CommonResponse : DaResponseBase { }
}