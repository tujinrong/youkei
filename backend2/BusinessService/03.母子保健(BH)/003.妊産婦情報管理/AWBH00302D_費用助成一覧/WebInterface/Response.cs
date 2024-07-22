// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-費用助成一覧
//             レスポンスインターフェース
// 作成日　　: 2024.05.14
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00302D
{
    /// <summary>
    /// 8.費用助成一覧画面検索処理
    /// </summary>
    public class SearchJyoseiListResponse : CmSearchResponseBase
    {
        public JyoseiHeaderInfoVM headerinfo { get; set; }              //費用助成情報（ヘッダー情報）
        public List<JyoseiListInfoVM> jyoseilist { get; set; }          //費用助成一覧
        public JyoseiFooterInfoVM footerinfo { get; set; }              //費用助成情報（フッター情報）
    }

    /// <summary>
    /// 9.保存(費用助成一覧)/10.削除(費用助成一覧)
    /// </summary>
    public class CommonResponse : DaResponseBase { }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> kensyuruilist { get; set; }        //ドロップダウンリスト(助成券種類リスト)
        public List<DaSelectorModel> kingakulimitlist { get; set; }     //ドロップダウンリスト(助成上限額リスト)
    }
}