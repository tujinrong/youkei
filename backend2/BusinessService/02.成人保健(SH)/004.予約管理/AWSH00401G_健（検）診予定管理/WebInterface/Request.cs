// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予定管理
//             リクエストインターフェース
// 作成日　　: 2024.02.13
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00401G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public int nendo { get; set; }          //年度
        public string? yoteiymdf { get; set; }  //実施予定日(開始)
        public string? yoteiymdt { get; set; }  //実施予定日(終了)
        public string? jigyocd { get; set; }    //成人健（検）診予約日程事業コード
        public string? kaijocd { get; set; }    //会場コード
        public string? kikancd { get; set; }    //医療機関コード
        public string? staffid { get; set; }    //従事者（担当者）
    }
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public int nendo { get; set; }              //年度
        public int? nitteino { get; set; }          //日程番号
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public bool copyflg { get; set; }           //コピーフラグ(コピーの場合、true)
    }
    /// <summary>
    /// 編集可能予約一覧取得処理(詳細画面)
    /// </summary>
    public class GetEditYoyakuRequest : DaRequestBase
    {
        public int nendo { get; set; }      //年度
        public string jigyocd { get; set; } //成人健（検）診予約日程事業コード
    }
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : InitDetailRequest
    {
        public DetailSaveVM maininfo { get; set; }      //予定メイン情報
        public List<RowSaveVM> kekkalist { get; set; }  //予定定員情報一覧
        public DateTime? upddttm { get; set; }          //更新日時(排他用)
    }
    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public int nendo { get; set; }          //年度
        public int nitteino { get; set; }       //日程番号
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
}