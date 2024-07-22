// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理(一覧)
//             レスポンスインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00105D;

namespace BCC.Affect.Service.AWEU00201G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; } //ドロップダウンリスト(業務)
        public List<DaSelectorModel> selectorlist2 { get; set; } //ドロップダウンリスト(帳票グループ)
        public List<DaSelectorModel> selectorlist3 { get; set; } //ドロップダウンリスト(帳票様式)
        public List<DaSelectorModel> selectorlist4 { get; set; } //ドロップダウンリスト(様式種別)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<SearchVM> kekkalist { get; set; }   //検索結果リスト
    }

    /// <summary>
    /// 初期化処理(詳細画面：新規・共通部分)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public string? yosikiid { get; set; }                           //様式ID
        public int? yosikieda { get; set; }                             //様式枝番
        public Enum様式作成方法 yosikihouhou { get; set; }             //様式作成方法
        public string? datasourceid { get; set; }                       //帳票データソースID
        public string? datasourcenm { get; set; }                       //帳票データソース名称
        public string? sql { get; set; }                                //SQL
        public string? procnm { get; set; }                             // プロシージャ名
        public List<DaSelectorModel> selectorlist3 { get; set; }        //ドロップダウンリスト(内外区分)
        public List<DaSelectorModel> selectorlist4 { get; set; }        //ドロップダウンリスト(利用目的)
        public List<DaSelectorModel> settinglist { get; set; }          //ドロップダウンリスト(問い合わせ先設定リスト)
        public List<DaSelectorModel> kacdList { get; set; }             //ドロップダウンリスト(課コード)
        public List<DaSelectorModel> kakaricdList { get; set; }         //ドロップダウンリスト(係コード)
        public List<DaSelectorModel> hakokbnList { get; set; }          //ドロップダウンリスト(帳票発行履歴区分)

        public List<DaSelectorModel> selectorlist { get; set; }         //様式紐付名のドロップダウンリスト
        public List<SearchConditionVM> himozukevalueList { get; set; }  //様式紐付け値のドロップダウンリスト
        public string[] parameterList { get; set; }                     //パラメータリスト
    }

    /// <summary>
    /// 検索処理(帳票設定タブ)
    /// </summary>
    public class SearchReportTabResponse : DaResponseBase
    {
        public ReportTabInfoVM rptDetailParam { get; set; }             //帳票設定タブ情報

        public List<DaSelectorModel> jyokenLabellist { get; set; } = new(); //固定条件
        public DateTime? upddttm { get; set; }                          //更新日時
    }

    /// <summary>
    /// 検索処理(様式設定タブ)
    /// </summary>
    public class SearchYosikiTabResponse : DaResponseBase
    {
        public YosikiTabInfoVM styleDetailParam { get; set; }               //様式設定タブ情報

        public List<DaSelectorModel> jyokenLabellist { get; set; } = new(); //固定条件
    }

    /// <summary>
    /// SELECT文の解析
    /// </summary>
    public class ParseAndFormatSqlResponse : DaResponseBase
    {
        public string sql { get; set; }                             //SQL
        public List<ReportItemDetailVM> itemlist { get; set; }      //様式項目リスト
        public List<SearchConditionVM> conditionlist { get; set; }  //検索条件リスト
    }

    /// <summary>
    /// プロシージャの解析
    /// </summary>
    public class ParseAndFormatProcedureResponse : DaResponseBase
    {
        public string sql { get; set; }                             //SQL
        public List<ReportItemDetailVM> itemlist { get; set; }      //様式項目リスト
        public List<SearchConditionVM> conditionlist { get; set; }  //検索条件リスト
        public string procedurenm { get; set; }                     //プロシージャ名
    }

    /// <summary>
    /// 初期化処理/検索処理(項目定義タブ)
    /// </summary>
    public class InitItemsTabResponse : DaResponseBase
    {
        public List<ReportItemDetailVM> reportitemlist { get; set; }        //帳票項目リスト
    }

    /// <summary>
    /// 初期化処理（検索条件タブ）
    /// </summary>
    public class InitConditionTabResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //DataTypeドロップダウンリスト
        public List<DaSelectorModel> selectorlist2 { get; set; }    //コントロールドロップダウンリスト
        public List<MasterVM> masterlist { get; set; }              //マスタリスト
    }
    /// <summary>
    /// 初期化処理(検索条件以外タブ)
    /// </summary>
    public class InitSpecialConditionsResponse : DaResponseBase
    {
        public List<SearchConditionVM> specialConditions { get; set; }          //検索条件以外リスト
        public List<string> labels { get; set; }                                //TODO
    }
    /// <summary>
    /// 検索処理（検索条件タブ）
    /// </summary>
    public class SearchConditionTabResponse : DaResponseBase
    {
        public List<SearchConditionVM> itemlist { get; set; } = new();              //普通全て検索条件リスト
        public List<SelectedSearchConditionVM> selectedjokenlist { get; set; }      //普通条件の選択したリスト
        public List<SearchConditionVM> selectedProcedjoklist { get; set; } = new(); //プロシージャの検索条件の選択したリスト(含む条件追加)
        public List<SearchConditionVM> selectedjokenOtherlist { get; set; }         //検索条件以外の選択したリスト
        public List<SearchConditionVM> conditionAddlist { get; set; }               //データソースの検索条件-条件追加リスト
    }

    /// <summary>
    /// 検索処理(条件追加)（検索条件タブ）
    /// </summary>
    public class SearchConditionDetailResponse : DaResponseBase
    {
        public SearchConditionVM eurptkensaku { get; set; }  //検索条件情報
    }

    /// <summary>
    /// 初期化処理(特殊項目)(Excelマッピングタブ)
    /// </summary>
    public class InitSpecialItemsResponse : DaResponseBase
    {
        public List<string> specialitemlist { get; set; }   //特殊項目リスト
    }

    /// <summary>
    /// 検索処理(Excelマッピングタブ)
    /// </summary>
    public class SearchExcelMappingTabResponse : DaResponseBase
    {
        public ExcelMappingVM excelmappingdata { get; set; }    //Excelマッピング情報
    }

    /// <summary>
    /// 条件追加のドロップダウンリストを取得
    /// </summary>
    public class SearchJokenResponse : DaResponseBase
    {
        public List<DaSelectorModel>? selectlist { get; set; }  //選択リスト
        public int masterCount { get; set; }                    //リストCount 
        public string? nendo { get; set; }                      //初期表示年度
        public string? nendomax { get; set; }                   //最大年度
    }
}