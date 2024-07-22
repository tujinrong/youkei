// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理
//             ビューモデル定義
// 作成日　　: 2023.11.24
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK00401G
{
    /// <summary>
    /// フォロー管理一覧情報(管理画面)
    /// </summary>
    public class RowFollowVM : CmHeaderBaseVM
    {
        public string atenano { get; set; }              //宛名番号
        public string adrs { get; set; }                 //住所
        public string followyoteiymd { get; set; }       //フォロー予定日
        public string followjissiymd { get; set; }       //フォロー実施日
        public string keikoku { get; set; }              //警告内容
    }

    /// <summary>
    /// フォロー内容一覧情報(内容画面)
    /// </summary>
    public class RowFollowContentVM : CommonBarHeaderBaseVM
    {
        public int follownaiyoedano { get; set; }               //フォロー内容枝番
        public string haakukeiro { get; set; }                  //把握経路
        public string haakujigyocd { get; set; }                //把握事業
        public string follownaiyo { get; set; }                 //フォロー内容
        public string followstatus { get; set; }                //フォロー状況
        public string followjigyocd { get; set; }               //フォロー事業
        public string followyoteiymd { get; set; }              //予定日
        public string followtm_yotei { get; set; }              //時間
        public string followkaijocd_yotei { get; set; }         //会場
        public string followstaffid_yotei { get; set; }         //担当者
        public string followjissiymd { get; set; }              //実施日
        public string followtm { get; set; }                    //時間
        public string followkaijocd { get; set; }               //会場
        public string followstaffid { get; set; }               //担当者
    }

    /// <summary>
    /// フォロー内容情報(結果画面)
    /// </summary>
    public class RowFollowKekkaVM : RowFollowKekkaDetailVM
    {
        public string atenano { get; set; }                     //宛名番号
        public int follownaiyoedano { get; set; }               //フォロー内容枝番
        public string? haakukeiro { get; set; }        　　     //把握経路
        public string? haakujigyocd { get; set; }               //把握事業
        public string followstatus { get; set; }                //フォロー状況
        public string? follownaiyo { get; set; }                //フォロー内容
    }

    /// <summary>
    /// フォロー予定結果一覧情報(結果画面)
    /// </summary>
    public class RowFollowKekkaDetailVM
    {
        public int edano { get; set; }                                //枝番
        public string followjigyocd { get; set; }                     //フォロー事業
        public string followhoho_yotei { get; set; }                  //方法
        public string followyoteiymd { get; set; }                    //予定日
        public string followtm_yotei { get; set; }                    //時間
        public string followkaijocd_yotei { get; set; }               //会場
        public string followstaffid_yotei { get; set; }               //担当者  
        public string followriyu { get; set; }                        //フォロー理由
        public string followhoho { get; set; }                        //方法
        public string followjissiymd { get; set; }                    //実施日   
        public string followtm { get; set; }                          //時間   
        public string followkaijocd { get; set; }                     //会場   
        public string followstaffid { get; set; }                     //担当者   
        public string followkekka { get; set; }                       //フォロー結果 
        public DateTime? upddttm { get; set; }                        //更新日時(排他用)
        public bool updflg { get; set; }                              //更新権限フラグ
    }

    /// <summary>
    /// フォロー予定情報(詳細画面)
    /// </summary>
    public class FollowDetailVM : FollowDetailYoteiInfoVM
    {
        public string atenano { get; set; }                          //宛名番号
        public int follownaiyoedano { get; set; }                    //フォロー内容枝番
        public int edano { get; set; }                               //枝番
        public int sinkiEdano { get; set; }                          //枝番新規用
        public string haakukeiro { get; set; }                       //把握経路
        public string haakujigyocd { get; set; }                     //把握事業
        public string follownaiyo { get; set; }                      //フォロー内容
        public string followjigyocd { get; set; }                    //フォロー事業
    }

    /// <summary>
    /// フォロー予定情報(詳細画面)
    /// </summary>
    public class FollowDetailYoteiInfoVM : FollowDetailKekkaInfoVM
    {
        public bool yoteiinputflg { get; set; }                           //フォロー予定入力フラグ
        public string? followhoho_yotei { get; set; }                     //フォロー方法
        public string? followyoteiymd { get; set; }                       //予定日
        public string? followtm_yotei { get; set; }                       //フォロー時間
        public string? followkaijocd_yotei { get; set; }                  //フォロー会場
        public string? followstaffid_yotei { get; set; }                  //フォロー担当者
        public string? followstaffid_yoteinm { get; set; }                //フォロー担当者名称
        public string? followriyu { get; set; }                           //フォロー理由
    }

    /// <summary>
    /// フォロー結果情報(詳細画面)
    /// </summary>
    public class FollowDetailKekkaInfoVM
    {
        public bool kekkainputflg { get; set; }           //フォロー結果入力フラグ
        public string? followhoho { get; set; }           //フォロー方法
        public string? followjissiymd { get; set; }       //実施日
        public string? followtm { get; set; }             //フォロー時間
        public string? followkaijocd { get; set; }        //フォロー会場   
        public string? followstaffid { get; set; }        //フォロー担当者
        public string? followstaffid_nm { get; set; }     //フォロー担当者名称
        public string? followkekka { get; set; }          //フォロー結果
        public DateTime? upddttmyotei { get; set; }       //更新日時(排他用)  予定情報テーブル利用
        public DateTime? upddttmkekka { get; set; }       //更新日時(排他用)  結果情報テーブル利用
        public bool updflg { get; set; }                  //更新権限フラグ
    }
}