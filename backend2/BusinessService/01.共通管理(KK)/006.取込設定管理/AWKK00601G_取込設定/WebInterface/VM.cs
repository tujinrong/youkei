// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定
//             ビューモデル定義
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00601G
{
    /// <summary>
    /// 汎用取込設定情報モデル(一覧画面)
    /// </summary>
    public class RowVM
    {
        public string impno { get; set; }       //一括取込入力No
        public string impnm { get; set; }       //一括取込入力名
        public string impkbn { get; set; }      //一括取込入力区分
        public string gyoumukbn { get; set; }   //業務区分
        public string memo { get; set; }        //説明
    }

    /// <summary>
    /// ヘッダー情報モデル(詳細画面)
    /// </summary>
    public class HeaderVM
    {
        public string gyoumukbn { get; set; }           //業務区分
        public string impno { get; set; }               //一括取込入力No
        public string impnm { get; set; }               //一括取込入力名
        public string impkbn { get; set; }              //一括取込入力区分
        public bool yeardispflg { get; set; }           //年度表示フラグ
        public string regupdkbn { get; set; }           //登録区分
        public string? nendohanikbn { get; set; }       //年度範囲区分
        public string? memo { get; set; }               //説明
        public string? procchk { get; set; }            //チェックプロシージャ名
        public string? procbefore { get; set; }         //更新前プロシージャ名
        public string? procafter { get; set; }          //更新後プロシージャ名
        public int orderseq { get; set; }               //並び順シーケンス
        public List<string> tableidList { get; set; }   //対象テーブル物理名リスト
    }

    /// <summary>
    /// 取込ファイルの基本情報モデル(詳細画面)
    /// </summary>
    public class FileInfoVM
    {
        public string filetype { get; set; }        //ファイル形式
        public string fileencode { get; set; }      //ファイルエンコード	
        public string? filenmrule { get; set; }     //ファイル名称
        public bool filenmruleflg { get; set; }     //正規表現
        public string datakbn { get; set; }         //データ形式	
        public int? recordlen { get; set; }         //レコード長	
        public string? quoteskbn { get; set; }      //引用符存在区分	
        public string? dividekbn { get; set; }      //区切り記号
        public int headerrows { get; set; }         //ヘッダー行数
        public int footerrows { get; set; }         //フッター行数
    }

    /// <summary>
    /// 取込ファイルIF情報モデル(詳細画面)
    /// </summary>
    public class FileIFVM
    {
        public int fileitemseq { get; set; }        //ファイル項目ID	
        public string itemnm { get; set; }      　　//項目名
        public bool keyflg { get; set; }            //キーフラグ
        public string keyflgName { get; set; }      //キーフラグ（名称）
        public bool requiredflg { get; set; }       //必須フラグ
        public string requiredflgName { get; set; } //必須フラグ（名称）
        public string datatype { get; set; }        //データ型
        public string datatypeName { get; set; }    //データ型（名称）
        public int len { get; set; }                //桁数
        public int? len2 { get; set; }              //桁数（小数部）
        public string? format { get; set; }         //フォーマット
        public string? formatName { get; set; }     //フォーマット（名称）
        public string? fmtcheck { get; set; }       //フォーマットチェック
        public string? fmtcheckName { get; set; }   //フォーマットチェック（名称）
        public string? fmtchange { get; set; }      //フォーマット変換
        public string? fmtchangeName { get; set; }  //フォーマット変換（名称）
        public string? memo { get; set; }           //備考
    }

    /// <summary>
    /// 変換コードメイン情報モデル(詳細画面)
    /// </summary>
    public class ChangeCodeMainVM
    {
        public int codehenkankbn { get; set; }        //コード変換区分
        public string henkankbnnm { get; set; }       //変換区分名称
        public string codekanritablenm { get; set; }  //コード管理テーブル名
        public string maincd { get; set; }            //メインコード
        public string subcd { get; set; }             //サブコード
        public string? sonotajoken { get; set; }      //その他条件
    }

    /// <summary>
    /// 取込コード変換情報モデル(詳細画面)
    /// </summary>
    public class CodeChangeVM
    {
        public int cdchangekbn { get; set; }        //コード変換区分
        public List<CodeChangeDetailVM> codechangedetailList { get; set; }  //取込コード変換情報明細リスト
    }

    /// <summary>
    /// 取込コード変換明細情報モデル(詳細画面)
    /// </summary>
    public class CodeChangeDetailVM
    {
        public int cdchangekbn { get; set; }        //コード変換区分
        public string oldcode { get; set; }         //元コード
        public string? oldcodememo { get; set; }    //元コード説明
        public string newcode { get; set; }         //変換後コード
        public string? newcodememo { get; set; }    //変換後コード説明		
    }

    /// <summary>
    /// マッピング設定情報モデル(詳細画面)
    /// </summary>
    public class ItemMappingVM
    {
        public int pageitemseq { get; set; }            //画面項目ID
        public string pageitemnm { get; set; }          //画面項目名
        public string? fileitemseq { get; set; }        //ファイル項目(ファイル項目ID,カンマ区切り)
        public string fileitemseqName { get; set; }     //ファイル項目(ファイル項目名,カンマ区切り)（名称）
        public string mappingkbn { get; set; }          //マッピング区分
        public string mappingkbnName { get; set; }      //マッピング区分（名称）
        public string? mappingmethod { get; set; }      //マッピング方法
        public string mappingmethodName { get; set; }   //マッピング方法	（名称）
        public int? substrfrom { get; set; }            //指定桁数（開始）
        public int? substrto { get; set; }              //指定桁数（終了） 
    }

    /// <summary>
    /// 画面項目情報モデル(詳細画面)
    /// </summary>
    public class PageItemVM
    {
        public int pageitemseq { get; set; }            //画面項目ID
        public string itemnm { get; set; }              //項目名
        public string wktablecolnm { get; set; }        //ワークテーブルカラム名
        public string inputkbn { get; set; }            //入力区分
        public string inputkbnName { get; set; }        //入力区分（名称）
        public string inputtype { get; set; }           //入力方法
        public string inputtypeName { get; set; }       //入力方法（名称）
        public string? hikisu { get; set; }             //引数
        public string? hikisuName { get; set; }         //引数（名称）
        public int len { get; set; }                    //桁数
        public int? len2 { get; set; }                  //桁数（小数部）
        public int width { get; set; }                  //幅
        public string? format { get; set; }             //フォーマット
        public string formatName { get; set; }          //フォーマット（名称）
        public string requiredflg { get; set; }         //必須フラグ	
        public string requiredflgName { get; set; }     //必須フラグ	（名称）
        public bool uniqueflg { get; set; }             //一意フラグ	
        public string uniqueflgName { get; set; }       //一意フラグ	（名称）
        public string? seiki { get; set; }              //正規表現	
        public string dispinputkbn { get; set; }        //表示入力設定区分
        public string dispinputkbnName { get; set; }    //表示入力設定区分（名称）
        public int? sortno { get; set; }                //並び順
        public int? fromitemseq { get; set; }           //参照元項目ID
        public string fromitemseqName { get; set; }     //参照元項目ID（名称）
        public string? fromfieldid { get; set; }        //参照元フィールド
        public string fromfieldidName { get; set; }     //参照元フィールド（名称）
        public string? targetfieldid { get; set; }      //取得先フィールド
        public string targetfieldidName { get; set; }   //取得先フィールド（名称）
        public bool? nendoflg { get; set; }             //年度フラグ
        public string nendoflgName { get; set; }        //年度フラグ（名称）
        public string? yearchkflg { get; set; }         //年度チェック
        public string yearchkflgName { get; set; }      //年度チェック（名称）
        public string? minval { get; set; }             //最小値
        public string? maxval { get; set; }             //最大値
        public string? defaultval { get; set; }         //初期値
        public string? fixedval { get; set; }           //固定値
        public string? msttable { get; set; }           //マスタチェックテーブル
        public string msttableName { get; set; }        //マスタチェックテーブル（名称）
        public string? mstjyoken { get; set; }          //マスタチェック条件
        public string? mstfield { get; set; }           //マスタチェック項目
        public string mstfieldName { get; set; }        //マスタチェック項目（名称）
        public string jherrlelkbn { get; set; }         //条件必須エラーレベル区分
        public string jherrlelkbnName { get; set; }     //条件必須エラーレベル区分（名称）
        public int? jhitemseq { get; set; }             //条件必須項目ID
        public string jhitemseqName { get; set; }       //条件必須項目ID（名称）
        public string? jhenzan { get; set; }            //条件必須演算子
        public string jhenzanName { get; set; }         //条件必須演算子（名称）
        public string? jhval { get; set; }              //条件必須値  
        public string? jigyocd { get; set; }            //事業コード
        public string jigyocdName { get; set; }         //事業コード（名称）
        public string? itemkbn { get; set; }            //項目特定区分
        public string itemkbnName { get; set; }         //項目特定区分（名称）
    }

    /// <summary>
    /// 登録項目情報モデル(詳細画面)
    /// </summary>
    public class InsertVM
    {
        public string tableid { get; set; }                         //テーブル物理名
        public List<InsertDetailVM> insertdetailList { get; set; }  //登録項目明細情報リスト
    }

    /// <summary>
    /// 登録項目明細情報モデル(詳細画面)
    /// </summary>
    public class InsertDetailVM
    {
        public string tableid { get; set; }                             //テーブル物理名
        public int recno { get; set; }                                  //レコードNo
        public string fieldid { get; set; }                             //フィールド物理名
        public string fieldnm { get; set; }                             //フィールド論理名
        public string syorikbn { get; set; }                            //処理区分
        public string syorikbnName { get; set; }                        //処理区分（名称）
        public int? pageitemseq { get; set; }                           //データ元画面項目ID	
        public string? itemnm { get; set; }                             //データ元画面項目（名称）
        public string? fixedval { get; set; }                           //固定値
        public string? datamototablenm { get; set; }                    //データ元テーブル
        public string? datamototableronrinm { get; set; }               //データ元テーブル(論理名)
        public string? datamotofieldnm { get; set; }                    //データ元フィールド
        public string? datamotofieldronrinm { get; set; }               //データ元フィールド(論理名)
        public string? saibankey { get; set; }                          //採番キー
        public string? saibankeyronrinm { get; set; }                   //採番キー(論理名)
    }

    /// <summary>
    /// 取込設定アップロードエラーモデル(詳細画面)
    /// </summary>
    public class UploadErrorVM
    {
        public int sheetNo { get; set; }        //シートNo
        public string sheetName { get; set; }   //シート名
        public string rowIndex { get; set; }    //行
        public string title { get; set; }       //項目名（タイトル名）
        public string itemValue { get; set; }   //項目値
        public string errMsg { get; set; }      //エラー内容

    }

    /// <summary>
    /// アップロードデータ
    /// </summary>
    public class UploadData : DaResponseBase
    {
        public HeaderVM hearderData { get; set; }                       //詳細画面:ヘッダー情報
        public FileInfoVM fileinfoData { get; set; }                    //詳細画面:基本情報
        public List<FileIFVM> fileifList { get; set; }                  //詳細画面:ファイルI/F情報
        public List<CodeChangeVM> codechangeList { get; set; }          //詳細画面:取込コード変換情報
        public List<ItemMappingVM> itemmappingList { get; set; }        //詳細画面:マッピング設定情報
        public List<PageItemVM> pageitemList { get; set; }              //詳細画面:画面項目情報
        public List<InsertVM> insertList { get; set; }                  //詳細画面:登録仕様情報
        public List<ChangeCodeMainVM> changeCodeMainList { get; set; }  //詳細画面:変換コードメイン情報
    }
}