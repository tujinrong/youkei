// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 自己負担金情報保守
//             リクエストインターフェース
// 作成日　　: 2024.03.05
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00601G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchListRequest : DaRequestBase
    {
        public int nendo { get; set; }                //年度
        public string kensin_jigyocd { get; set; }    //成人健(検)診事業名
        public string ryokinpattern { get; set; }     //料金パターン
    }

    /// <summary>
    /// 年度変更処理
    /// </summary>
    public class SearchNendoRequest : DaRequestBase
    {
        public int nendo { get; set; }                //年度
    }

    /// <summary>
    /// 年度変更処理
    /// </summary>
    public class SearchHikitsudugiRequest : DaRequestBase
    {
        public int nendo { get; set; }                //年度
        public int jigyocd { get; set; }              //事業コード
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public int nendo { get; set; }                //年度
        public string kensin_jigyocd { get; set; }    //成人健(検)診事業名
        public string ryokinpattern { get; set; }     //料金パターン
        public List<LockVM> locklist { get; set; }    //排他キーリスト
        public List<RowVM> savelist { get; set; }    //自己負担金データリスト
    }
}