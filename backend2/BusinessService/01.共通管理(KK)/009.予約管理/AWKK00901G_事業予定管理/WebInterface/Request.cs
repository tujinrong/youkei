// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業予定管理
//             リクエストインターフェース
// 作成日　　: 2024.03.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00901G
{
    /// <summary>
    /// 検索処理(一覧画面：日程)
    /// </summary>
    public class SearchNitteiListRequest : CmSearchRequestBase
    {
        public string? gyomukbn { get; set; }       //業務区分
        public string? jissiyoteiymdf { get; set; } //実施予定日(開始)
        public string? jissiyoteiymdt { get; set; } //実施予定日(終了)
        public string? jigyocd { get; set; }        //その他日程事業・保健指導事業コード
        public string? kaijocd { get; set; }        //会場コード
        public string? kikancd { get; set; }        //医療機関コード
        public string? staffid { get; set; }        //担当者
    }

    /// <summary>
    /// 検索処理(一覧画面：コース)
    /// </summary>
    public class SearchCourseListRequest : SearchNitteiListRequest
    {
        public string? coursenm { get; set; }   //コース名
        public int? kaisu { get; set; }         //回数
    }

    /// <summary>
    /// 初期化処理(詳細画面：日程)
    /// </summary>
    public class InitNitteiDetailRequest : DaRequestBase
    {
        public int? nitteino { get; set; }          //日程番号
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public bool copyflg { get; set; }           //コピーフラグ(コピーの場合、true)
    }

    /// <summary>
    /// 初期化処理(詳細画面：コース)
    /// </summary>
    public class InitCourseDetailRequest : DaRequestBase
    {
        public int? courseno { get; set; }          //コース番号
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public bool copyflg { get; set; }           //コピーフラグ(コピーの場合、true)
    }

    /// <summary>
    /// 保存処理(詳細画面：日程)
    /// </summary>
    public class SaveNitteiRequest : DaRequestBase
    {
        public int? nitteino { get; set; }              //日程番号
        public Enum編集区分 editkbn { get; set; }       //編集区分
        public NitteiDetailVM detailinfo { get; set; }  //日程情報(明細)
        public DateTime? upddttm { get; set; }          //更新日時(排他用)
    }

    /// <summary>
    /// 保存処理(詳細画面：コース)
    /// </summary>
    public class SaveCourseRequest : DaRequestBase
    {
        public int? courseno { get; set; }                      //コース番号
        public string coursenm { get; set; }                    //コース名
        public Enum編集区分 editkbn { get; set; }               //編集区分
        public List<CourseDetailVM> detailinfo { get; set; }    //コース情報(明細)
        public DateTime? upddttm { get; set; }                  //更新日時(排他用)
    }

    /// <summary>
    /// 削除処理(詳細画面：日程)
    /// </summary>
    public class DeleteNitteiRequest : DaRequestBase
    {
        public int nitteino { get; set; }       //日程番号
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }

    /// <summary>
    /// 削除処理(詳細画面：コース)
    /// </summary>
    public class DeleteCourseRequest : DaRequestBase
    {
        public int courseno { get; set; }       //コース番号
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }
}