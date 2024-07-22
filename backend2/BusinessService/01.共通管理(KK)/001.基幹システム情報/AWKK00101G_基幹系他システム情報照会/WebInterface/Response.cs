// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基幹系他システム情報照会
//             レスポンスインターフェース
// 作成日　　: 2023.10.03
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00101G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchPersonListResponse : CmSearchResponseBase
    {
        public List<PersonRowVM> kekkalist { get; set; }    //住民・住登外一覧
    }
    /// <summary>
    /// 検索処理(世帯一覧)
    /// </summary>
    public class SearchSetaiListResponse : DaResponseBase
    {
        public SetaiHeaderVM headerinfo { get; set; }  //世帯主情報
        public List<SetaiRowVM> kekkalist { get; set; } //世帯成員一覧
    }
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public PersonHeaderVM headerinfo { get; set; } //住民情報(ヘッダー)
    }
    /// <summary>
    /// 検索処理(詳細画面：ベース)
    /// </summary>
    public class SearchDetailResponseBase : DaResponseBase
    {
        public int rirekitotal { get; set; }    //総履歴数
        public int rirekinum { get; set; }      //履歴No.
    }
    /// <summary>
    /// 検索処理(詳細画面：住基タブ)
    /// </summary>
    public class SearchJuminDetailResponse : SearchDetailResponseBase
    {
        public JuminVM detailinfo { get; set; } //住民情報
    }
    /// <summary>
    /// 検索処理(詳細画面：課税・納税義務者タブ_課税)
    /// </summary>
    public class SearchKaZeiDetailResponse : SearchDetailResponseBase
    {
        public KazeiVM detailinfo { get; set; } //課税情報
    }
    /// <summary>
    /// 検索処理(詳細画面：課税・納税義務者タブ_納税)
    /// </summary>
    public class SearchNoZeiDetailResponse : SearchDetailResponseBase
    {
        public NozeiVM detailinfo { get; set; } //納税義務者情報
    }
    /// <summary>
    /// 検索処理(詳細画面：税額控除タブ全体)
    /// </summary>
    public class SearchKojoDetailResponse : SearchKojoDetailRowsResponse
    {
        public int rirekitotal { get; set; }                //総履歴数
        public int rirekinum { get; set; }                  //履歴No.
        public KojoHeaderVM detailheaderinfo { get; set; }  //控除情報(ヘッダー)
    }
    /// <summary>
    /// 検索処理(詳細画面：税額控除タブ明細)
    /// </summary>
    public class SearchKojoDetailRowsResponse : CmSearchResponseBase
    {
        public List<KojoRowVM> kekkalist { get; set; }      //控除情報(明細)
    }
    /// <summary>
    /// 検索処理(詳細画面：国保タブ)
    /// </summary>
    public class SearchKokuhoDetailResponse : SearchDetailResponseBase
    {
        public KokuhoVM detailinfo { get; set; } //国保情報
    }
    /// <summary>
    /// 検索処理(詳細画面：後期タブ)
    /// </summary>
    public class SearchKokiDetailResponse : SearchDetailResponseBase
    {
        public KokiVM detailinfo { get; set; } //後期情報
    }
    /// <summary>
    /// 検索処理(詳細画面：生保タブ)
    /// </summary>
    public class SearchSeihoDetailResponse : SearchDetailResponseBase
    {
        public SeihoVM detailinfo { get; set; } //生保情報
    }
    /// <summary>
    /// 検索処理(詳細画面：介護タブ)
    /// </summary>
    public class SearchKaigoDetailResponse : SearchDetailResponseBase
    {
        public KaigoVM detailinfo { get; set; } //介護情報
    }
    /// <summary>
    /// 検索処理(詳細画面：福祉タブ)
    /// </summary>
    public class SearchSyogaiDetailResponse : SearchDetailResponseBase
    {
        public SyogaiVM detailinfo { get; set; } //障害情報
    }
}