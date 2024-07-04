// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 地区保守
//             リクエストインターフェース
// 作成日　　: 2023.09.22
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00204G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string tikukbn { get; set; } //地区区分(コード：名称)
        public string tiku { get; set; }    //地区(コード：名称)
        public string staff { get; set; }   //地区担当者(コード：名称)
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string tikukbn { get; set; }     //地区区分(コード)
        public string tikucd { get; set; }      //地区コード
    }

    /// <summary>
    /// 検索処理(地区担当者情報)
    /// </summary>
    public class SearchRowRequest : DaRequestBase
    {
        public string staffid { get; set; }     //地区担当者ID
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public SaveMainVM maininfo { get; set; }        //地区情報
        public List<string> stafflist { get; set; }     //地区担当者情報
        public Enum編集区分 editkbn { get; set; }       //編集区分
    }
}