// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票新規作成
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00202D
{
    /// <summary>
    /// 帳票初期化処理
    /// </summary>
    public class ReportGroupVM
    {
        public string rptgroupid { get; set; }  //帳票グループID
        public string rptgroupnm { get; set; }  //帳票グループ名
        public string gyoumucd { get; set; }    //業務コード
    }

    /// <summary>
    /// 帳票初期化処理
    /// </summary>
    public class DatasourceVM
    {
        public string datasourceid { get; set; }    //データソースID
        public string datasourcenm { get; set; }    //データソース名称
        public string gyoumucd { get; set; }        //業務コード
    }

    /// <summary>
    /// 帳票初期化処理
    /// </summary>
    public class YoshikiTypeVM
    {
        public Enum様式種別 yosikisyubetu { get; set; }             //様式種別
        public List<DaSelectorModel> yosikikbnlist { get; set; }    //様式種別詳細リスト
    }

    /// <summary>
    /// 別様式初期化処理
    /// </summary>
    public class ReportVM
    {
        public string rptid { get; set; }               //帳票ID
        public string rptnm { get; set; }               //帳票名
    }

    /// <summary>
    /// サブ帳票初期化処理
    /// </summary>
    public class ReportWithYosikiVM
    {
        public string rptid { get; set; }                       //帳票ID
        public string rptnm { get; set; }                       //帳票名
        public string gyoumu { get; set; }                      //業務
        public string rptgroup { get; set; }                    //帳票グループ
        public bool atenaflg { get; set; }                      //宛名フラグ
        public bool addresssealflg { get; set; }                //アドレスシールフラグ
        public bool barcodesealflg { get; set; }                //バーコードシール出力フラグ
        public bool hagakiflg { get; set; }                     //はがき出力フラグ
        public bool atenadaityoflg { get; set; }                //宛名台帳出力フラグ
        public bool kensuhyonenreiflg { get; set; }             //件数表(年齢別)出力フラグ
        public bool kensuhyogyoseikuflg { get; set; }           //件数表(行政区別)出力フラグ
        public List<DaSelectorModel> selectorlist { get; set; } //ドロップダウンリスト(様式)
    }
}