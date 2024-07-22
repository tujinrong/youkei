// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 各種検診対象者保守
//             レスポンスインターフェース
// 作成日　　: 2024.02.02
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH00302G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<PersonRowVM> kekkalist { get; set; }    //対象者一覧
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public GamenHeaderBase2VM headerinfo { get; set; }          //個人基本情報
        public string genmenkbn_tokuteicdnm { get; set; }           //減免区分（特定健診）(コード：名称)
        public string genmenkbn_gancdnm { get; set; }               //減免区分（がん検診）(コード：名称)
        public List<DaSelectorModel> selectorlist1 { get; set; }    //減免区分（特定健診）一覧
        public List<DaSelectorModel> selectorlist2 { get; set; }    //減免区分（がん検診）一覧
        public List<Row2VM> kekkalist { get; set; }                 //検診状況一覧
    }
    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public List<RowVM> kekkalist { get; set; } //検診状況一覧(基準日変更可能検診のみ)
    }
}