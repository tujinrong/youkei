// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ユーザー管理
//             レスポンスインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00901G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorKeyModel> selectorlist1 { get; set; } //ドロップダウンリスト(ユーザー)
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(所属)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<UserRowVM> kekkalist1 { get; set; }     //結果リスト(ユーザー)
        public List<SyozokuRowVM> kekkalist2 { get; set; }  //結果リスト(所属)
    }

    /// <summary>
    /// 詳細画面ベース
    /// </summary>
    public class SearchAuthResponse : DaResponseBase
    {
        public List<GamenVM> kekkalist1 { get; set; }       //画面機能権限リスト(所属)
        public List<CmBarVM> kekkalist2 { get; set; }       //共通機能権限リスト(所属)
        public List<ReportVM> kekkalist3 { get; set; }      //帳票権限リスト(所属)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : SearchAuthResponse
    {
        public UserInfoVM? maininfo1 { get; set; }          //ユーザー情報
        public SyozokuInfoVM? maininfo2 { get; set; }       //所属グループ情報
        public List<GamenVM>? kekkalist4 { get; set; }      //画面機能権限リスト(ユーザー)
        public List<CmBarVM>? kekkalist5 { get; set; }      //共通機能権限リスト(ユーザー)
        public List<ReportVM>? kekkalist6 { get; set; }     //帳票権限リスト(ユーザー)
        public List<CmSisyoVM> sisyolist { get; set; }      //支所一覧リスト(全て)
        public bool pnoeditflg { get; set; }                //個人番号操作権限付与フラグ(ログインユーザー)
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : SearchAuthResponse
    {
        public RoleAuthBaseVM authvm { get; set; }  //権限(所属)
    }
}