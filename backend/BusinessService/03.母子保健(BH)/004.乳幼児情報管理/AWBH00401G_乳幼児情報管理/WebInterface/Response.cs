// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 乳幼児情報管理
//             レスポンスインターフェース
// 作成日　　: 2024.03.08
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00401G
{
    /// <summary>
    /// 1.乳幼児一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public string syosaititle { get; set; }                         //詳細項目タイトル
        public List<NyuyoujiListVM> kekkalist { get; set; }             //結果リスト(乳幼児一覧)
    }

    /// <summary>
    /// 2.3.乳幼児詳細画面検索処理(一覧画面)
    /// </summary>
    public class SearchDetailResponse : SearchSyosaiResponse
    {
        public HeaderInfoVM headerinfo { get; set; }                    //乳幼児情報（固定部分）
        public List<MenuInfoVM> menulist { get; set; }                  //乳幼児メニュー種類一覧
        public List<DaSelectorModel> grouplist1 { get; set; }           //フリー項目グループ１リスト
        public List<DaSelectorModel> grouplist2 { get; set; }           //フリー項目グループ２リスト
    }

    /// <summary>
    /// 4.乳幼児フリー検索処理(メニュー／タブ／回数をクリック)
    /// 4.新規ボタンを押下
    /// </summary>
    public class SearchSyosaiResponse : CmSearchResponseBase
    {
        public List<TabInfoVM> tablist { get; set; }                    //乳幼児タブ一覧
        public int maxkaisu { get; set; }                               //最大回数（新規の場合は最大履歴回数＋１）
        public List<KaisuInfoVM> kaisulist { get; set; }                //回数タブ一覧（新規の場合は最大履歴回数＋１も含める）
        public List<FixItemDispInfoVM> fixitemlist { get; set; }        //乳幼児固定項目情報（表示用）
        public List<FreeItemDispInfoVM> freeitemlist { get; set; }      //乳幼児フリー項目情報（表示用）
    }

    /// <summary>
    /// 5.父母親情報検索処理
    /// </summary>
    public class SearchAtenaInfoResponse : CmSearchResponseBase
    {
        public string AtenaInfo { get; set; }                           //父母親情報
    }

    /// <summary>
    /// 6.保存/7.削除処理(詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase { }

}