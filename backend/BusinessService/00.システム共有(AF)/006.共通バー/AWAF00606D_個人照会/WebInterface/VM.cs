// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人照会
//             ビューモデル定義
// 作成日　　: 2023.09.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00606D
{
    /// <summary>
    /// 個人基本情報
    /// </summary>
    public class HeaderVM : CommonBarHeaderBase2VM
    {
        public string gyoseiku { get; set; }    //行政区(名称)
    }
    /// <summary>
    /// 住民情報その他情報
    /// </summary>
    public class Tab1DetailVM
    {
        public string age_nendo { get; set; }           //年齢(年度末)
        public string agekijunymd_nendo { get; set; }   //年齢計算基準日(年度末)
        public string setaino { get; set; }             //世帯番号
        public List<RowVM> kekkalist { get; set; }      //世帯情報一覧
    }
    /// <summary>
    /// 課税・保険・介護情報
    /// </summary>
    public class Tab2DetailVM
    {
        public string kazeikbn_setai { get; set; }                //課税非課税区分（世帯）
        public string hokenkbn { get; set; }                      //保険区分
        public string kazeikbn { get; set; }                      //課税非課税区分
        public string kokuho_kigono { get; set; }                 //国保記号番号
        public string kokuho_edano { get; set; }                  //枝番
        public string kokuho_sikakusyutokuymd { get; set; }       //国保資格取得年月日
        public string kokuho_sikakusosituymd { get; set; }        //国保資格喪失年月日
        public string hihokensyano1 { get; set; }                 //被保険者番号(後期高齢者医療)
        public string hiho_sikakusyutokuymd { get; set; }         //被保険者資格取得年月日
        public string hiho_sikakusosituymd { get; set; }          //被保険者資格喪失年月日
        public string seihoymdf { get; set; }                     //生活保護開始年月日
        public string teisiymd { get; set; }                      //停止年月日
        public string teisikaijoymd { get; set; }                 //停止解除年月日
        public string haisiymd { get; set; }                      //廃止年月日
        public string yokaigojotaikbnnm { get; set; }             //要介護状態区分(名称)
        public string hihokensyano2 { get; set; }                 //被保険者番号(介護保険)
        public string yokaigoninteiymd { get; set; }              //要介護認定日
        public string yokaigoyukoymdf { get; set; }               //要介護認定有効期間開始日
        public string yokaigoyukoymdt { get; set; }               //要介護認定有効期間終了日
    }

    /// <summary>
    /// 世帯情報(1件)
    /// </summary>
    public class RowVM
    {
        public string atenano { get; set; }     //宛名番号
        public string name { get; set; }        //氏名
        public string kname { get; set; }       //カナ氏名
        public string zokuhyoki { get; set; }   //続柄
        public string sex { get; set; }         //性別
        public string bymd { get; set; }        //生年月日
        public string juminkbn { get; set; }    //住民区分
        public string keikoku { get; set; }     //警告内容
        public bool stopflg { get; set; }       //除票者フラグ
    }
}