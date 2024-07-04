// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 各種検診対象者保守
//             リクエストインターフェース
// 作成日　　: 2024.02.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00302G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : Common.PersonSearchRequest
    {
        public int nendo { get; set; }  //年度
    }
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public int nendo { get; set; }      //年度
        public string atenano { get; set; } //宛名番号
    }
    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public int nendo { get; set; }              //年度
        public string atenano { get; set; }         //宛名番号
        public List<Row3VM> kekkalist { get; set; } //検診状況一覧(基準日変更可能検診のみ)
    }
    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public string genmenkbn_tokuteicdnm { get; set; }   //減免区分（特定健診）(コード：名称)
        public string genmenkbn_gancdnm { get; set; }       //減免区分（がん検診）(コード：名称)
    }
}