// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: フォロー管理
//             レスポンスインターフェース
// 作成日　　: 2023.11.24
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK00401G
{
    /// <summary>
    /// 管理一覧（初期表示）
    /// </summary>
    public class SearchFollowListResponse : CmSearchResponseBase
    {
        public List<RowFollowVM> kekkalist { get; set; }    //フォロー管理一覧
    }

    /// <summary>
    /// 検索処理(内容画面)
    /// </summary>
    public class SearchFollowNaiyoListResponse : CmSearchResponseBase
    {
        public List<DaSelectorModel> haakukeiroList { get; set; }    //ドロップダウンリスト(把握経路)
        public List<DaSelectorModel> haakujigyoList { get; set; }    //ドロップダウンリスト(把握事業)
        public List<DaSelectorModel> followstatusList { get; set; }  //ドロップダウンリスト(フォロー状況)
        public List<DaSelectorModel> followjigyoList { get; set; }   //ドロップダウンリスト(フォロー事業)
        public GamenHeaderBase2VM headerinfo { get; set; }           //住民情報
        public List<RowFollowContentVM> kekkalist { get; set; }      //結果リスト(フォロー内容一覧)
    }

    /// <summary>
    /// 新規処理(結果画面)
    /// </summary>
    public class InitFollowNaiyoResponse : CmSearchResponseBase
    {
        public List<DaSelectorModel> haakukeiroList { get; set; }       //ドロップダウンリスト(把握経路)
        public List<DaSelectorModel> haakujigyoList { get; set; }       //ドロップダウンリスト(把握事業)
        public List<DaSelectorModel> followstatusList { get; set; }           //ドロップダウンリスト(フォロー状況)
        public List<DaSelectorModel> followjigyoList { get; set; }      //ドロップダウンリスト(フォロー事業)
        public List<DaSelectorModel> followstaffidList { get; set; }    //ドロップダウンリスト(担当)
        public int follownaiyoedano { get; set; }                       //フォロー内容枝番
        public bool showflg { get; set; }                               //表示フラグ(登録支所)
        public string regsisyo { get; set; }                            //登録支所
    }

    /// <summary>
    /// 検索処理(結果画面)
    /// </summary>
    public class SearchFollowNaiyoResponse : CmSearchResponseBase
    {
        public RowFollowKekkaVM followkekkavm { get; set; }         //フォロー内容情報
        public List<RowFollowKekkaVM> kekkalist { get; set; }       //結果リスト(フォロー予定結果情報一覧)
        public bool showflg { get; set; }                           //表示フラグ(登録支所)
        public string regsisyo { get; set; }                        //登録支所
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchFollowDetailResponse : CmSearchResponseBase
    {
        public bool zenkaisetflg { get; set; }                                //前回結果情報セットフラグ
        public FollowDetailVM followdetailvm { get; set; }                    //フォロー予定情報(詳細画面)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitFollowDetailResponse : CmSearchResponseBase
    {
        public List<DaSelectorModel> followjigyoList { get; set; }            //ドロップダウンリスト(フォロー事業)
        public List<DaSelectorModel> followhoho_yoteiList { get; set; }       //ドロップダウンリスト(フォロー方法)
        public List<DaSelectorModel> followkaijocd_yoteiList { get; set; }    //ドロップダウンリスト(フォロー会場)
        public List<DaSelectorModel> followhohoList { get; set; }             //ドロップダウンリスト(フォロー方法)
        public List<DaSelectorModel> followkaijocdList { get; set; }          //ドロップダウンリスト(フォロー会場)
        public List<DaSelectorModel> followstaffid_yoteiList { get; set; }    //ドロップダウンリスト(フォロー担当者  フォロー予定情報)
        public List<DaSelectorModel> followstaffidList { get; set; }           //ドロップダウンリスト(フォロー担当者  フォロー結果情報)
        public FollowDetailVM followdetailvm { get; set; }                    //フォロー予定情報(詳細画面)
        public bool zenkaisetflg { get; set; }                                //前回結果情報セットフラグ
        public bool showflg { get; set; }                                     //表示フラグ(登録支所)
        public string regsisyo { get; set; }                                  //登録支所
    }

    /// <summary>
    /// 前回結果情報セット処理(詳細画面)
    /// </summary>
    public class FollowDetailPreKekkaResponse : DaResponseBase
    {
        public bool yoteiinputflg { get; set; }                                     //フォロー予定入力フラグ
        public string? followhoho_yotei { get; set; }                               //フォロー方法
        public string? followyoteiymd { get; set; }                                 //予定日
        public string? followtm_yotei { get; set; }                                 //フォロー時間
        public string? followkaijocd_yotei { get; set; }                            //フォロー会場
        public string? followstaffid_yotei { get; set; }                            //フォロー担当者
        public string? followstaffid_yoteinm { get; set; }                          //フォロー担当者名称
        public string? followriyu { get; set; }                                     //フォロー理由
        public bool zenkaisetflg { get; set; }                                      //前回結果情報セットフラグ
    }

    /// <summary>
    /// 予定情報セット処理(詳細画面)
    /// </summary>
    public class FollowDetailKekkaResponse : DaResponseBase
    {
        public FollowDetailKekkaInfoVM kekkadetailinfovm { get; set; }              //フォロー結果情報(詳細画面)
    }
}
