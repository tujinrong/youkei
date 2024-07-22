// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 医療機関保守
//             リクエストインターフェース
// 作成日　　: 2023.12.6
// 作成者　　: CNC加恒
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00201G
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string kikancd { get; set; }         //医療機関コード（自治体独自）
        public string hokenkikancd { get; set; }    //保険医療機関コード
        public string kikannm { get; set; }         //医療機関名
        public string kanakikannm { get; set; }     //医療機関名カナ
        public string adrs { get; set; }            //住所
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string kikancd { get; set; }                     //医療機関コード
        public Enum編集区分 editkbn { get; set; }               //編集区分
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveDetailRequest : DaRequestBase
    {
        public DateTime upddttm { get; set; }                               //更新日時
        public MainInfoVM maininfo { get; set; }                            //医療機関情報メイン
        public List<JissijigyoModel> jissijigyoSelectorList { get; set; }   //実施事業ドロップダウンリスト
        public Enum編集区分 editkbn { get; set; }                           //編集区分
    }
}
