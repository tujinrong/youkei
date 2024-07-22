// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理(一覧)
//             ビューモデル定義
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00306D;

namespace BCC.Affect.Service.AWEU00201G
{
    /// <summary>
    /// 一覧検索明細情報
    /// </summary>
    public class SearchVM
    {
        public string gyoumu { get; set; }          //業務
        public string rptgroupnm { get; set; }      //帳票グループ名
        public string rptid { get; set; }           //帳票ID
        public string rptnm { get; set; }           //帳票名
        public string yosikiideda { get; set; }     //様式id-枝番
        public string yosikidenm { get; set; }      //様式名-サブ様式名
        public string yosikiid { get; set; }        //様式ID
        public int yosikieda { get; set; }          //様式枝番
        public string yosikinm { get; set; }        //様式名
        public string kbn { get; set; }             //様式分類
        public string yosikisyubetu { get; set; }   //様式種別
        public string yosikikbn { get; set; }       //様式種別詳細
        public string datasourcenm { get; set; }    //データソース名称
    }

    /// <summary>
    /// 帳票設定タブ情報
    /// </summary>
    public class ReportTabInfoVM
    {
        public string rptgroupnm { get; set; }          //帳票グループ名
        public string rptgroupid { get; set; }          //帳票グループID
        public string gyoumu { get; set; }              // 業務
        public string rptbiko { get; set; }             //帳票説明
        public bool atenaflg { get; set; }              //宛名フラグ
        public bool ninsanpuflg { get; set; }           //妊産婦フラグ
        public bool addresssealflg { get; set; }        //アドレスシールフラグ固定様式
        public bool barcodesealflg { get; set; }        //バーコードシール固定様式
        public bool hagakiflg { get; set; }             //はがき固定様式
        public bool atenadaityoflg { get; set; }        //宛名台帳　固定様式
        public bool kensuhyonenreiflg { get; set; }     //件数表(年齢別)固定様式
        public bool kensuhyogyoseikuflg { get; set; }   //件数表(行政区別)固定様式
        public string? yosikihimonm { get; set; }       //様式紐付け名
        public List<SearchConditionVM> jyokenLabels { get; set; }  //選択した固定条件
        public bool tyusyutupanelflg { get; set; }      //抽出パネル表示フラグ
        public int? orderseq { get; set; }              //並びシーケンス
    }

    /// <summary>
    /// 様式設定タブ情報
    /// </summary>
    public class YosikiTabInfoVM
    {
        public Enum様式種別 yosikisyubetu { get; set; }                     //様式種別
        public string? meisaikoteikbn { get; set; }                         //行（列）固定区分
        public bool meisaiflg { get; set; }                                 //明細有無
        public Enum様式種別詳細 yosikikbn { get; set; }                     //様式種別詳細
        public Enum様式作成方法 yosikihouhou { get; set; }                  //様式作成方法
        public string hakokbn { get; set; }                                 //帳票発行履歴管理区分
        public bool? hakoflg { get; set; }                                  //帳票発行履歴管理フラグ
        public bool distinctflg { get; set; }                               //重複データ排除フラグ
        public bool? nulltozeroflg { get; set; }                             //空白値ゼロ出力フラグ
        public bool? pdfflg { get; set; }                                    //PDF 出力形式
        public bool? excelflg { get; set; }                                  //EXCEL 出力形式
        public bool? otherflg { get; set; }                                  //other 出力形式
        public int? sortptnno { get; set; }                                  //出力順パターン
        public bool? updateflg { get; set; }                                //更新フラグ
        public string updatesql { get; set; }                               //更新SQL
        public Enum内外区分 naigaikbn { get; set; }                         //内外区分
        public bool koinnmflg { get; set; }                                 // 市区町村印字 公印
        public bool koinpicflg { get; set; }                                // 電子更新印字公印
        public bool dairisyaflg { get; set; }                               // 職務代理者適用 公印
        public string toiawasesakicd { get; set; }                          //問い合わせ
        public string hanyocd { get; set; }                                 //問い合わせ内容
        public int? himozukejyokenid { get; set; }                          //様式紐付け条件ID
        public string? himozukevalue { get; set; }                          //様式紐付け値       
        public int? orderseq { get; set; }                                   //並びシーケンス
        public string? kacd { get; set; }                                   //課コード
        public string? kakaricd { get; set; }                               //係コード
        public bool? gyomuflg { get; set; }                                 //業務画面使用フラグ
        public bool? tutisyoflg { get; set; }                               //通知書出力フラグ
        public DateTime? yosikiUpddttm { get; set; }                        //様式更新日時
        public DateTime? yosikisyosaiUpddttm { get; set; }                  //様式詳細更新日時
    }

    /// <summary>
    /// 項目定義明細情報
    /// </summary>
    public class ReportItemDetailVM
    {
        public string yosikiitemid { get; set; }        //様式項目ID
        public string reportitemnm { get; set; }        //帳票項目名称
        public string csvitemnm { get; set; }           //CSV項目名称
        public string sqlcolumn { get; set; }           //SQLカラム
        public string tablealias { get; set; }          //テーブル別名
        public Enum並び替え orderkbn { get; set; }      //並び替え
        public int? orderkbnseq { get; set; }           //並び替えシーケンス
        public int? orderseq { get; set; }              //並びシーケンス
        public bool reportoutputflg { get; set; }       //帳票出力フラグ
        public bool csvoutputflg { get; set; }          //CSV出力フラグ
        public bool headerflg { get; set; }             //ヘッダーフラグ
        public bool kaipageflg { get; set; }            //改ページフラグ
        public Enum出力項目区分 itemkbn { get; set; }   //項目区分
        public string? formatkbn { get; set; }          //フォーマット区分
        public string? formatkbn2 { get; set; }         //フォーマット区分2
        public string? formatsyosai { get; set; }       //フォーマット詳細
        public int? height { get; set; }                //高
        public int? width { get; set; }                 //幅
        public int? offsetx { get; set; }               //X軸オフセット
        public int? offsety { get; set; }               //Y軸オフセット
        public string? blankvalue { get; set; }         //白紙表示
        public string? mastercd { get; set; }           //名称マスタコード
        public string? masterpara { get; set; }         //名称マスタパラメータ
        public string? keyvaluepairsjson { get; set; }  //複数のキー・値・ペアjson
        public Enum集計区分? crosskbn { get; set; }     //集計区分
        public string? syukeihoho { get; set; }         //集計方法
        public string? kbn1 { get; set; }         //小計区分
        public int? level { get; set; }                 //集計レベル
        public string? daibunrui { get; set; }          //大分類
    }

    /// <summary>
    /// 並び替え設定(項目定義タブ)
    /// </summary>
    public class SortLineParam : DaRequestBase
    {
        public int sortptnno { get; set; }                   //出力順パターン
        public List<SortSubVM> sortsublist { get; set; }    //出力順の項目詳細リスト
    }

    /// <summary>
    /// 選択検索条件情報
    /// </summary>
    public class SelectedSearchConditionVM
    {
        public int jyokenid { get; set; }           //条件ID
        public string datasourceid { get; set; }    //データソースID
        public bool hissuflg { get; set; }          //必須フラグ
        public string jyokenlabel { get; set; }     //ラベル
    }

    /// <summary>
    /// 検索条件情報
    /// </summary>
    public class SearchConditionVM : SelectedSearchConditionVM
    {
        public string jyokenkbn { get; set; }                   //検索条件区分
        public string jyokenlabel { get; set; }                 //ラベル
        public string tableid { get; set; }                     //テーブルID
        public string? variables { get; set; }                  //変数名
        public string daibunrui { get; set; }                   //大分類
        public string itemid { get; set; }                      //項目ID
        public string itemnm { get; set; } = string.Empty;      //項目物理名
        public string label { get; set; }                       //項目名  
        public Enumコントロール controlkbn { get; set; }        //種類
        public string? sql { get; set; }                        //SQL
        public string tablealias { get; set; }                  //テーブル名
        public string? mastercd { get; set; }                   //名称マスタコード
        public string? masterpara { get; set; }                 //名称マスタパラメータ
        public string? sansyomotosql { get; set; }              //参照元SQL
        public int? datatype { get; set; }                      //データ型
        public string? nendohanikbn { get; set; }               //年度範囲区分
        public string? syokiti { get; set; }                    //初期値
        public string nendo { get; set; }                       //初期表示年度
        public string nendomax { get; set; }                    //最大年度
        public int jyokenseq { get; set; }                      //条件シーケンス
        public string sqlcolumn { get; set; }                   //SQLカラム
        public int orderseq { get; set; }                       //並び順シーケンス
        public string? aimaikbn { get; set; }                   //曖昧検索区分
        public List<DaSelectorModel>? selectlist { get; set; }  //選択リスト
    }

    /// <summary>
    /// Excelマッピング情報
    /// </summary>
    public class ExcelMappingVM : DaResponseBase
    {
        public string templatefilenm { get; set; }                              //テンプレートファイル名
        public byte[] templatefiledata { get; set; }                            //テンプレートファイル
        public int? endrow { get; set; }                                        //テンプレート終了行
        public int? endcol { get; set; }                                        //テンプレート終了列
        public Enumページサイズ pagesize { get; set; } = Enumページサイズ.A4;     //ページサイズ
        public bool landscape { get; set; } = false;                            //出力方向
        public bool rowdetailflg { get; set; }                                  //行明細フラグ
        public int? startrow { get; set; }                                      //テンプレート明細開始行
        public int? loopmaxrow { get; set; }                                    //１ページあたりの最大行数
        public int? looprow { get; set; }                                       //1明細あたりの行数
        public bool coldetailflg { get; set; }                                  //列明細フラグ
        public int? startcol { get; set; }                                      //明細開始列数
        public int? loopmaxcol { get; set; }                                    //１ページあたりの最大列数
        public int? loopcol { get; set; }                                       //1明細あたりの列数
        public List<List<CellVM>> celldatas { get; set; } = new();              //全シートのセル
    }

    /// <summary>
    /// エクセルセル
    /// </summary>
    public class CellVM
    {
        public int rowindex { get; set; }     //行インデックス
        public int columnindex { get; set; }  //列インデックス
        public object? value { get; set; }    //値
    }

    /// <summary>
    /// プロシージャ情報
    /// </summary>
    public class ProcedureVM
    {
        public string name { get; set; }        //関数名
        public string src { get; set; }         //関数のソース
        public string description { get; set; } //関数説明

        public ProcedureVM(string name, string src, string? description = null)
        {
            this.name = name;
            this.src = src;
            this.description = description ?? string.Empty;
        }
    }

    /// <summary>
    /// サブ様式情報
    /// </summary>
    public class SubYosikiDataVM
    {
        public bool hakoflg { get; set; }           //帳票発行履歴更新フラグ
        public string? himozukevalue { get; set; }  //様式紐付け値
        public int? himozukejyokenid { get; set; }  //様式紐付け条件ID
        public bool pdfflg { get; set; }            //PDF 出力形式
        public bool excelflg { get; set; }          //EXCEL 出力形式
        public bool otherflg { get; set; }          //other 出力形式
        public bool? updateflg { get; set; }        //更新フラグ
        public string updatesql { get; set; }       //更新SQL
        public Enum内外区分 naigaikbn { get; set; } //内外区分
    }

    // AIplus 2024-06-24 SHOU ADD Start
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchCtlVM
    {
        public string ctrlcd { get; set; }          //コントロールコード
        public object value { get; set; }           //値
        public string biko { get; set; }            //備考
        public DateTime upddttm { get; set; }       //更新日時
    }
    // AIplus 2024-06-24 SHOU ADD End
}