// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理(共通バー)
//             ビューモデル定義
// 作成日　　: 2023.12.27
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00609D
{
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
}