// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 妊産婦情報管理
//             レスポンスインターフェース
// 作成日　　: 2024.02.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00301G
{
    /// <summary>
    /// 1.妊産婦一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public string syosaititle { get; set; }                         //詳細項目タイトル
        public List<NinsanpuListVM> kekkalist { get; set; }             //結果リスト(妊産婦一覧)
    }

    /// <summary>
    /// 2.3.妊産婦詳細画面検索処理(一覧画面)
    /// </summary>
    public class SearchDetailResponse : SearchSyosaiResponse
    {
        public HeaderInfoVM headerinfo { get; set; }                    //妊産婦情報（ヘッダー情報）
        public List<MenuInfoVM> menulist { get; set; }                  //妊産婦メニュー
        public List<DaSelectorModel> grouplist1 { get; set; }           //フリー項目グループ１リスト
        public List<DaSelectorModel> grouplist2 { get; set; }           //フリー項目グループ２リスト
    }

    /// <summary>
    /// 4.妊産婦フリー検索処理(メニュー／タブ／回数をクリック)
    /// 4.新規ボタンを押下
    /// </summary>
    public class SearchSyosaiResponse : CmSearchResponseBase
    {
        public long torokuno { get; set; }                              //登録番号
        public List<TabInfoVM> tablist { get; set; }                    //妊産婦タブ一覧
        public int maxkaisu { get; set; }                               //最大回数（新規の場合は最大履歴回数＋１）
        public int limitkaisu { get; set; }                             //上限回数
        public List<KaisuInfoVM> kaisulist { get; set; }                //回数タブ一覧（新規の場合は最大履歴回数＋１も含める）
        public List<FixItemDispInfoVM> fixitemlist { get; set; }        //妊産婦固定項目情報（表示用）
        public List<FreeItemDispInfoVM> freeitemlist { get; set; }      //妊産婦フリー項目情報（表示用）
    }

    /// <summary>
    /// 5.医療機関検索
    /// </summary>
    public class SearchKikanNMResponse : CmSearchResponseBase
    {
        public string KikanNM { get; set; }                             //医療機関名称
    }

    /// <summary>
    /// 6.医師検索
    /// </summary>
    public class SearchIshiNMResponse : CmSearchResponseBase
    {
        public string ishinm { get; set; }                              //医師名称
    }

    /// <summary>
    /// 7.保存(詳細画面)/8.削除処理(詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase { }
}