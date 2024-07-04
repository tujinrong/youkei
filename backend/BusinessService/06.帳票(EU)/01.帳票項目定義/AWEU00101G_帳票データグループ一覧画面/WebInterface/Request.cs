// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票データグループ一覧
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00101G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string gyoumucd { get; set; }                                  //業務コード
        public string? datasourcenm { get; set; }                             //データソース名称
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailTabRequest : DaRequestBase
    {
        public string datasourceid { get; set; }                              //データソースID
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteRequest : InitDetailTabRequest
    {
        public DateTime upddttm { get; set; }                               //更新日時
    }

    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveRequest : DeleteRequest
    {
        public string datasourcenm { get; set; }                            //データソース名称
        public string gyoumu { get; set; }                                  //業務
    }

    /// <summary>
    /// 項目削除処理(詳細画面)
    /// </summary>
    public class DeleteItemsRequest : CmSaveRequestBase
    {
        public string datasourceid { get; set; }                           //データソースID
        public List<DeleteTableItemVM> deleteitemlist { get; set; }
    }

    /// <summary>
    /// 検索処理(詳細画面:検索条件)
    /// </summary>
    public class SearchConditionTabRequest : DaRequestBase
    {
        public string datasourceid { get; set; }                          //データソースID
        public string status { get; set; }                                //ステータス
    }
}