// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予約希望者管理
//             リクエストインターフェース
// 作成日　　: 2024.03.07
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK00902G
{
    /// <summary>
    /// 検索処理(日程一覧画面)
    /// </summary>
    public class SearchNitteiListRequest : AWKK00901G.SearchNitteiListRequest
    {
        public int? courseno { get; set; }                  //コース番号
        public string? coursenm { get; set; }               //コース名
        public int? kaisu { get; set; }                     //回数
        public string? atenano { get; set; }                //宛名番号
        public override string? personalno { get; set; }    //個人番号
    }

    /// <summary>
    /// コース日程一覧画面(初期化処理/コピー処理)
    /// </summary>
    public class CourseListRequest : DaRequestBase
    {
        public int courseno { get; set; }   //コース番号
    }

    /// <summary>
    /// 初期化処理(予約者一覧画面)
    /// </summary>
    public class InitPersonListRequest : DaRequestBase
    {
        public int nitteino { get; set; }   //日程番号
    }

    /// <summary>
    /// 削除処理(予約者一覧画面)
    /// </summary>
    public class DeletePersonListRequest : DaRequestBase
    {
        public List<LockVM> locklist { get; set; }  //宛名番号(チェック対象)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public int nitteino { get; set; }           //日程番号
        public string atenano { get; set; }         //宛名番号
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }

    /// <summary>
    /// チェック処理(詳細画面)
    /// </summary>
    public class CheckRequest : InitDetailRequest
    {
        public bool taikiflg { get; set; }  //待機フラグ
    }

    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveRequest : InitDetailRequest
    {
        public DetailVM detailinfo { get; set; }    //予約情報
        public DateTime? upddttm { get; set; }      //更新日時(排他用)
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteDetailRequest : DaRequestBase
    {
        public int nitteino { get; set; }       //日程番号
        public string atenano { get; set; }     //宛名番号
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
}