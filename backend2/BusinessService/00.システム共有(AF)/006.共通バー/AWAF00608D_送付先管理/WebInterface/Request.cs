// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 送付先管理
//             リクエストインターフェース
// 作成日　　: 2023.11.14
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00608D
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }    //宛名番号
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string atenano { get; set; }         //宛名番号
        public string riyomokuteki { get; set; }    //利用目的
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public MainInfoVM maininfo { get; set; }            //会場情報メイン
        public Enum編集区分 editkbn { get; set; }           //編集区分
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class AutoSetRequest : DaRequestBase
    {
        public string adrs_yubin { get; set; }              //郵便番号	
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string atenano { get; set; }         //宛名番号
        public string riyomokuteki { get; set; }    //利用目的
        public DateTime upddttm { get; set; }       //更新日時
    }
}
