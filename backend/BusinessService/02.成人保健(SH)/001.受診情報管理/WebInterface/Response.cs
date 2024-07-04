// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検診結果管理
//             レスポンスインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH001
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public bool showflg1 { get; set; }  //表示フラグ(精密)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<KsRowVM> kekkalist { get; set; }    //検診結果
        public bool transflg { get; set; }              //遷移フラグ
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : InitListResponse
    {
        public bool showflg2 { get; set; }                      //表示フラグ(クーポン)
        public bool showflg3 { get; set; }                      //表示フラグ(一次検査方法)
        public KsHeaderVM headerinfo { get; set; }              //個人基本情報
        public KsTimeSearchVM kekka { get; set; }               //該当回目の検診結果
        public List<KsLockVM> keylist { get; set; }             //キーリスト(全ての回目)
        public List<DaSelectorModel> grouplist1 { get; set; }   //成人保健フリー項目グループ１リスト
        public List<DaSelectorModel> grouplist2 { get; set; }   //成人保健フリー項目グループ２リスト
        public List<DaSelectorModel> selectorlist { get; set; } //ドロップダウンリスト(検査方法)
        public string? coupon { get; set; }                     //クーポン番号
        public bool addflg { get; set; }                        //複数可能フラグ
        public bool editflg1 { get; set; }                      //編集フラグ(一次：権限)
        public bool editflg2 { get; set; }                      //編集フラグ(精密：権限)
        public bool delflg { get; set; }                        //削除フラグ(削除ボタン)   
        public string errormsgid { get; set; }                  //エラーメッセージID
        public string alertmsgid { get; set; }                  //アラートメッセージID
    }

    /// <summary>
    /// 保存/削除処理(詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase
    {
        public string atenano { get; set; }                 //宛名番号
        public List<KsStatusVM> statuslist { get; set; }    //状態一覧(編集後)
    }

    /// <summary>
    /// 基準値取得処理
    /// </summary>
    public class GetKijunResponse : DaResponseBase
    {
        public List<Common.KjItemVM> kekkalist { get; set; }    //項目基準値リスト
    }

    /// <summary>
    /// 実施年齢取得処理
    /// </summary>
    public class GetAgeResponse : DaResponseBase
    {
        public int? jissiage { get; set; }   //実施年齢
    }

    /// <summary>
    /// 精密検診チェック処理
    /// </summary>
    public class SeiKenEditCheckResponse : DaResponseBase
    {
        public bool editflg3 { get; set; }  //編集フラグ(精密：一次結果)
    }

    /// <summary>
    /// 計算処理
    /// </summary>
    public class CalculateResponse : DaResponseBase
    {
        public List<KsCalculateVM> kekkalist { get; set; }  //結果項目一覧(計算されたデータのみ)
    }

    /// <summary>
    /// 新規追加権限チェック処理(詳細画面)
    /// </summary>
    public class AuthCheckResponse : DaResponseBase
    {
        public bool authflg { get; set; }  //新規追加権限チェックフラグ
    }
}