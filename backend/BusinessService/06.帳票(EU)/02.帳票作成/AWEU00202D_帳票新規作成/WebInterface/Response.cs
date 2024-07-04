// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票新規作成
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00202D
{
    /// <summary>
    /// 帳票初期化処理
    /// </summary>
    public class InitReportResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(業務)
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(作成方法)
        public List<DaSelectorModel> functionlist { get; set; }     //プロシージャのドロップダウンリスト
        public List<DaSelectorModel> selectorlist3 { get; set; }    //ドロップダウンリスト(様式種別)
        public List<DaSelectorModel> selectorlist4 { get; set; }    //ドロップダウンリスト(内外区分)
        public List<DaSelectorModel> selectorlist5 { get; set; }    //ドロップダウンリスト(明細有無)
        public List<DaSelectorModel> selectorlist6 { get; set; }    //ドロップダウンリスト(行列固定)
        public List<ReportGroupVM> rptgrouplist { get; set; }       //帳票グループリスト
        public List<DatasourceVM> datasourcelist { get; set; }      //データソースリスト
        public List<YoshikiTypeVM> yoshikitypelist { get; set; }    //様式種別詳細リスト
    }

    /// <summary>
    /// 別様式初期化処理
    /// </summary>
    public class InitOtherYosikiResponse : DaResponseBase
    {
        public List<ReportVM> reportlist { get; set; }              //帳票リスト
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(様式種別)
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(内外区分)
        public List<DaSelectorModel> selectorlist3 { get; set; }    //ドロップダウンリスト(明細有無)
        public List<DaSelectorModel> selectorlist4 { get; set; }    //ドロップダウンリスト(行列固定)
        public List<YoshikiTypeVM> yoshikitypelist { get; set; }    //様式種別詳細リスト
    }

    /// <summary>
    /// サブ帳票初期化処理
    /// </summary>
    public class InitSubReportResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }            //ドロップダウンリスト(作成方法)
        public List<DaSelectorModel> selectorlist2 { get; set; }            //ドロップダウンリスト(帳票種別)
        public List<DaSelectorModel> selectorlist3 { get; set; }            //ドロップダウンリスト(明細有無)
        public List<DaSelectorModel> selectorlist4 { get; set; }            //ドロップダウンリスト(行列固定)
        public List<DatasourceVM> datasourcelist { get; set; }              //データソースリスト
        public List<ReportWithYosikiVM> reportwithyosikilist { get; set; }  //ドロップダウンリスト(帳票様式)
        public List<YoshikiTypeVM> yoshikitypelist { get; set; }            //様式種別詳細リスト
    }

}