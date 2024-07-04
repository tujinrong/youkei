// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診予約希望者管理
//             レスポンスインターフェース
// 作成日　　: 2024.02.19
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH00402G
{
    /// <summary>
    /// 初期化処理(予約者一覧画面)
    /// </summary>
    public class InitPersonListResponse : DaResponseBase
    {
        public HeaderVM headerinfo { get; set; }                //日程基本情報
        public List<RowVM> kekkalist1 { get; set; }             //結果一覧(予約情報)
        public List<ColumnInfoVM> columnInfos { get; set; }     //列情報
        public List<List<DataInfoVM>> kekkalist2 { get; set; }  //結果一覧(予約者情報)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : CalculateResponse
    {
        public HeaderVM headerinfo { get; set; }            //日程基本情報
        public PersonVM personinfo { get; set; }            //希望者情報
        public string biko { get; set; }                    //備考
        public DateTime? upddttm { get; set; }              //更新日時(排他用)
        public List<DetailRowVM> kekkalist { get; set; }    //予約一覧
    }

    /// <summary>
    /// 計算処理
    /// </summary>
    public class CalculateResponse : DaResponseBase
    {
        public MoneyVM moneyinfo { get; set; }  //自己負担金情報
    }

    /// <summary>
    /// 定員チェック処理
    /// </summary>
    public class CheckTeiinResponse : DaResponseBase
    {
        public List<string> kekkalist { get; set; } //待機変更必要検診事業一覧
        public bool overflg { get; set; }           //全体定員オーバーフラグ
    }
}