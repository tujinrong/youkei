// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業実施報告書（日報）管理
//             レスポンスインターフェース
// 作成日　　: 2023.11.09
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK00501G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist3 { get; set; } //ドロップダウンリスト(従事者)
        public List<DaSelectorModel> selectorlist1 { get; set; } //ドロップダウンリスト(会場)
        public List<DaSelectorModel> selectorlist2 { get; set; } //ドロップダウンリスト(事業)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; } //結果リスト(日報一覧)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist4 { get; set; } //ドロップダウンリスト(会場)
        public List<DaSelectorModel> selectorlist5 { get; set; } //ドロップダウンリスト(事業)
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public long hokokusyono { get; set; }                   //事業報告書番号
        public DateTime? upddttm { get; set; }                  //更新日時
        public string? updusernm { get; set; }                  //更新者
        public string? regsisyo { get; set; }                   //登録支所
        public JissihokokusyoVM? jissihokokusyo { get; set; }   //事業実施報告書（日報）情報
        public List<StaffVM> stafflist { get; set; } = new();   //事業従事者リスト
        public bool exceloutflg { get; set; }                   //EXCEL出力フラグ
    }

    /// <summary>
    /// 検索処理(事業従事者情報)
    /// </summary>
    public class SearchRowResponse : DaResponseBase
    {
        public StaffVM staffinfo { get; set; }      //事業従事者情報
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveResponse : DaResponseBase
    {
        public long hokokusyono { get; set; }       //事業報告書番号
    }
}