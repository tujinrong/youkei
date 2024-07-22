// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-乳幼児情報一覧
//             レスポンスインターフェース
// 作成日　　: 2024.05.28
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00303D
{
    /// <summary>
    /// 乳幼児情報一覧画面検索処理
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public HeaderInfoVM headerinfo { get; set; }            //乳幼児情報（ヘッダー情報）
        public List<ListInfoVM> kekkalist { get; set; }         //乳幼児情報（一覧情報）
    }
}