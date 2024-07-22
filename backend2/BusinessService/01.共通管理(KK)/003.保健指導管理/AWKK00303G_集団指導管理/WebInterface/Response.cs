// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 集団指導管理
//             レスポンスインターフェース
// 作成日　　: 2023.12.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00303G
{
    /// <summary>
    /// 1.初期化処理(個人詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public InitDetailVM initdetail { get; set; }                    //個人詳細画面_基本情報等タブリスト初期化
    }

    /// <summary>
    /// 2.集団指導一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<SyudanListVM> kekkalist { get; set; }               //結果リスト(結果一覧)
    }

    /// <summary>
    /// 3,4フリー項目検索
    /// 8,9参加者フリー項目検索
    /// </summary>
    public class SearchFreeItemResponse : DaResponseBase
    {
        public List<DaSelectorModel> grouplist1 { get; set; }           //フリー項目グループ１リスト
        public List<DaSelectorModel> grouplist2 { get; set; }           //フリー項目グループ２リスト
        public List<FreeItemDispInfoVM> freeitemlist { get; set; }      //フリー項目情報（表示用）
    }

    /// <summary>
    /// 3.個別入力画面検索処理(集団指導管理の検索結果一覧の行をクリックした場合)
    /// 4.指導情報検索処理テスト用（個別入力画面のタブを選択（申込／結果））
    /// </summary>
    public class SearchDetailResponse : SearchFreeItemResponse
    {
        public bool editflg { get; set; }                               //編集フラグ
        public ParamInfoVM paraminfo { get; set; }                      //親画面引き続き情報（表示用）
        public JigyoFixInfoVM fixinfo { get; set; }                     //個別入力画面固定情報（表示用）
    }

    /// <summary>
    /// 5.参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ））
    /// </summary>
    public class SearchSankasyaListResponse : DaResponseBase
    {
        public bool inputflg { get; set; }                              //申込情報入力
        public string jigyo { get; set; }                               //事業（コード : 名称）で表示
        public List<SankasyaInfoVM> sankasyalist { get; set; }          //参加者基本情報（表示用）
    }

    /// <summary>
    /// 6.7.保存/削除処理(個別入力画面)
    /// 10.11.参加者保存/参加者削除処理(参加者詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase { }

    /// <summary>
    /// 8,9.参加者詳細画面検索処理
    /// </summary>
    public class SearchSankasyaDetailResponse : SearchFreeItemResponse
    {
        public bool editflg { get; set; }                               //編集フラグ
        public HeaderInfoVM headerinfo { get; set; }                    //参加者詳細画面ヘッダー情報（表示用）
        public SankasyaFixInfoVM fixinfo { get; set; }                  //参加者詳細画面固定情報（表示用）
    }

}