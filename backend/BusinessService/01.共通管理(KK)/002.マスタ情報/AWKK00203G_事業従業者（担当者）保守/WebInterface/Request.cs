// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業従事者（担当者）保守
//             リクエストインターフェース
// 作成日　　: 2023.12.4
// 作成者　　: 劉誠
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK00203G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string staffid { get; set; }             //事業従業者ID
        public string kikancd { get; set; }             //医療機関(コード)
        public string syokusyu { get; set; }            //職種
        public string katudokbn { get; set; }           //活動区分
        public string staffsimei { get; set; }          //事業従事者氏名
        public string kanastaffsimei { get; set; }      //事業従事者カナ氏名


    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string staffid { get; set; }                  //事業従業者ID
        public Enum編集区分 editkbn { get; set; }            //編集区分
    }

    /// <summary>
    /// 登録処理(詳細画面)
    /// </summary>
    public class SaveDetailRequest : DaRequestBase
    {
        public DateTime upddttm { get; set; }                               //更新日時
        public MainInfoVM mainInfo { get; set; }                            //事業従業者（担当者）メイン情報
        public List<string> kikanlist { get; set; }                         //医療機関リスト
        public List<JissijigyoModel> jissijigyoSelectorList { get; set; }   //実施事業ドロップダウンリスト
        public Enum編集区分 editkbn { get; set; }                            //編集区分
    }

}