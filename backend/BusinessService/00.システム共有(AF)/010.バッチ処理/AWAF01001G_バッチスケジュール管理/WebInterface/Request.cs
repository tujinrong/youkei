// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチスケジュール管理
//             リクエストインターフェース
// 作成日　　: 2024.02.06
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF01001G
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string kbn { get; set; }             //処理区分
        public string gyomukbn { get; set; }        //業務区分
        public string tasknm { get; set; }          //タスク名
        public string statuscd { get; set; }        //前回処理結果     
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string taskid { get; set; }           //タスクID
        public Enum編集区分 editkbn { get; set; }    //編集区分
    }

    /// <summary>
    /// 実行処理
    /// </summary>
    public class ExeBatchDetailRequest : DaRequestBase
    {
        public string taskid { get; set; }     　　　　      //タスクID

        public Enum処理結果区分 statuscd { get; set; }       //処理結果区分
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveDetailRequest : DaRequestBase
    {
        public DateTime? upddttm { get; set; }       //更新日時
        public MainInfoVM maininfo { get; set; }     //スケジュール管理情報
        public Enum編集区分 editkbn { get; set; }    //編集区分
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string taskid { get; set; }          //タスクID

    }
}