// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票管理(一覧)
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.AWEU00306D;

namespace BCC.Affect.Service.AWEU00201G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string? gyoumucd { get; set; }       //業務コード
        public string? rptgroupid { get; set; }     //帳票グループID
        public string? rptnm { get; set; }          //帳票名
        public string? yosikinm { get; set; }       //様式名
        public string? yoshikibunrui { get; set; }  //様式分類
        public string? yosikisyubetu { get; set; }  //様式種別
    }

    /// <summary>
    /// 初期化処理(詳細画面：共通部分)
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public string rptid { get; set; }                     //帳票ID
        public string? yosikiid { get; set; }                 //様式ID-枝番
        public Enum帳票様式 kbn { get; set; }                 //帳票様式
        public Enum様式作成方法? yosikihouhou { get; set; }   //様式作成方法
        public string? datasourceid { get; set; }             //データソースID
        public string? procnm { get; set; }                   //プロシージャ名称
        public Enum編集区分 editkbn { get; set; }             //編集区分
    }

    /// <summary>
    /// 帳票キー共有リクエスト
    /// </summary>
    public class YosikiRequestTabBase : DaRequestBase
    {
        public string rptid { get; set; }       //帳票ID
        public string yosikiid { get; set; }    //様式ID
        public int? yosikieda { get; set; }     //様式枝番
        public string? datasourceid { get; set; }   //データソースID
    }

    /// <summary>
    /// 帳票様式共通
    /// </summary>
    public class YosikiCommonRequest : YosikiRequestTabBase
    {
        public Enum帳票様式 kbn { get; set; }                 //帳票様式
        public Enum編集区分 editkbn { get; set; }             //編集区分
        public string? procnm { get; set; }                 　//プロシージャ名称
        public string? sql { get; set; }                      //プロシージャ内容
        public Enum様式作成方法? yosikihouhou { get; set; }   //様式作成方法
    }

    /// <summary>
    /// 検索条件
    /// </summary>
    public class CheckDataTypeRequestBase : DaRequestBase
    {
        public EnumDataType? datatype { get; set; }         //データタイプ
        public Enumコントロール? controlkbn { get; set; }   //種類
        public string? syokiti { get; set; }               //初期値
        public string sqlcolumn { get; set; }             //SQLカラム
    }
    
    /// <summary>
    /// 検索条件以外
    /// </summary>
    public class InitSpecialConditionsRequest : DaRequestBase
    {
        public bool isDataSource { get; set; }                  //データソース
    }

    /// <summary>
    /// SQL解析(様式設定タブ)
    /// </summary>
    public class ParseAndFormatSqlRequest : DaRequestBase
    {
        public string sql { get; set; }                                     //SQL
        public List<ReportItemDetailVM> itemlist { get; set; } = new();     //様式項目リスト
        public List<SearchConditionVM> conditionlist { get; set; } = new(); //検索条件リスト
    }

    /// <summary>
    /// 検索処理(条件追加)
    /// </summary>
    public class SearchConditionDetailRequest : DaRequestBase
    {
        public int jyokenseq { get; set; }  //条件シーケンス
    }

    /// <summary>
    /// 検索処理(条件追加)
    /// </summary>
    public class SearchJokenDetailRequest : DaRequestBase
    {
        public int? controlkbn { get; set; }                   //コントロール区分
        public string mastercd { get; set; }                   //名称マスタコード
        public string masterpara { get; set; }                 //名称マスタパラメータ
        public string? nendohanikbn { get; set; }             //年度範囲区分
    }

    /// <summary>
    /// プロシージャの解析(様式設定タブ)
    /// </summary>
    public class ParseAndFormatProcedureRequest : DaRequestBase
    {
        public string sql { get; set; }                                     //SQL
        public List<ReportItemDetailVM> itemlist { get; set; } = new();     //様式項目リスト
        public List<SearchConditionVM> conditionlist { get; set; } = new(); //検索条件リスト
        public string? mainprocedurenm { get; set; }                        //帳票プロシージャ名
        public string? procedurenm { get; set; }                      　    //様式プロシージャ名
        public Enum帳票様式 kbn { get; set; }                               //帳票様式
        public string rptid { get; set; }                                   //帳票ID
    } 

    /// <summary>
    /// 初期化処理(項目定義タブ)
    /// </summary>
    public class InitItemsTabRequest : DaRequestBase
    {
        public Enum様式種別 yosikisyubetu { get; set; }     //様式種別
        public Enum様式作成方法 yosikihouhou { get; set; }  //様式作成方法
        public string? datasourceid { get; set; }           //データソースID
    }

    /// <summary>
    /// 検索処理(Excelマッピング)
    /// </summary>
    public class SearchExcelMappingTabRequest : DaRequestBase
    {
        public string rptid { get; set; }                   //帳票ID
        public string yosikiid { get; set; }                //様式ID
        public int? yosikieda { get; set; }                 //様式枝番
        public Enum様式種別詳細 yosikikbn { get; set; }     //様式種別詳細
        public bool meisaiflg { get; set; }                 //明細有無
        public string? meisaikoteikbn { get; set; }         //行（列）固定区分
        public bool excelStatus { get; set; }               //excelStatus
    }

    /// <summary>
    /// 初期化処理(特殊項目)(Excelマッピングタブ)
    /// </summary>
    public class InitSpecialItemsRequest : DaRequestBase
    {
        public bool isPageReport { get; set; }                  //台帳
        public bool IsCross { get; set; }                       //クロス集計
        public bool isDataSource { get; set; }                  //データソース
        public EnumEucPublicPrivate naigaikbn { get; set; }     //内外区分
    }
    /// <summary>
    /// エクセルテンプレートファイルのダウンロード処理
    /// </summary>
    public class DownloadExcelTemplateRequest : CmUploadRequestBase
    {
        public List<List<CellVM>> celldatas { get; set; } = new(); //全シートのセル
    }

    /// <summary>
    /// 画面全件情報保存処理
    /// </summary>
    public class SaveProjectRequest : CmUploadRequestBase
    {
        public string rptid { get; set; }                                   //帳票ID
        public string rptnm { get; set; }                                   //帳票名
        public string yosikiid { get; set; }                                //様式ID
        public int yosikieda { get; set; }                                  //様式枝番
        public string yosikinm { get; set; }                                //様式名
        public Enum様式種別 yosikisyubetu { get; set; }                             //様式種別
        public Enum様式種別詳細 yosikikbn { get; set; }                        //様式種別詳細
        public Enum帳票様式 kbn { get; set; }                               //帳票様式
        public bool updflag { get; set; }                                   //更新識別
        public DateTime? upddttm { get; set; }                              //更新日時
        public Enum様式作成方法 yosikihouhou { get; set; }                  //様式作成方法
        public string? datasourceid { get; set; }                           //帳票データソースID
        public string? sql { get; set; }                                    //SQL
        public string? procnm { get; set; }                                 // プロシージャ名
        public ReportTabInfoVM rptDetailParam { get; set; }                 //帳票設定タブ情報
        public YosikiTabInfoVM styleDetailParam { get; set; }               //様式設定タブ情報
        public List<ReportItemDetailVM> definitionValue { get; set; }       //項目定タブ情報
        public List<SearchConditionVM> rptConditionList { get; set; }       //検索条件タブ情報
        public List<ExcelMappingVM> excelData { get; set; }                 //Excelマッピングタブ情報
        public bool checkflg { get; set; } = false;         　　　　　　　　//チェックフラグ
    }
}