// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行履歴管理
//             リクエストインターフェース
// 作成日　　: 2024.03.22
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF01101G
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string rptid { get; set; }             //帳票名
        public string yosikiid { get; set; }          //様式名
        public string nendo { get; set; }             //年度
        public string taisyocd { get; set; }          //抽出対象
        public string hakkodttmf { get; set; }        //発行日時(開始)
        public string hakkodttmt { get; set; }        //発行日時(終了)

    }
}