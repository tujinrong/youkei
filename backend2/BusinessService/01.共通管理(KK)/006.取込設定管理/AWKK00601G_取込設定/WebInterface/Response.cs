// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定
//             レスポンスインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00601G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> gyoumuSelectorList { get; set; }    //業務ドロップダウンリスト
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkaList { get; set; }    //取込設定情報リスト
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public DateTime? upddttm { get; set; }  //更新日時

        public HeaderVM hearderData { get; set; }                       //詳細画面:ヘッダー情報
        public FileInfoVM fileinfoData { get; set; }                    //詳細画面:基本情報
        public List<FileIFVM> fileifList { get; set; }                  //詳細画面:ファイルI/F情報
        public List<CodeChangeVM> codechangeList { get; set; }          //詳細画面:取込コード変換情報
        public List<ItemMappingVM> itemmappingList { get; set; }        //詳細画面:マッピング設定情報
        public List<PageItemVM> pageitemList { get; set; }              //詳細画面:画面項目情報
        public List<InsertVM> insertList { get; set; }                  //詳細画面:登録仕様情報

        public List<ChangeCodeMainVM> changeCodeMainList { get; set; }  //詳細画面:変換コードメイン情報

        //詳細画面:ヘッダー情報のドロップダウンリストの初期化データ
        public List<DaSelectorModel> gyoumukbnList { get; set; }        //【業務区分】のドロップダウンリスト
        public List<DaSelectorModel> impkbnList { get; set; }           //【一括取込入力区分】のドロップダウンリスト
        public List<DaSelectorModel> regupdkbnList { get; set; }        //【登録区分】のドロップダウンリスト
        public List<DaSelectorModel> nendohanikbnList { get; set; }     //【年度範囲区分】のドロップダウンリスト
        public List<DaSelectorKeyModel> headtableidList { get; set; }   //【テーブル】のドロップダウンリスト(tableid,nm,親テーブル)

        //詳細画面:基本情報のドロップダウンリストの初期化データ
        public List<DaSelectorModel> filetypeList { get; set; }         //【ファイル形式】のドロップダウンリスト
        public List<DaSelectorModel> filenmruleList { get; set; }       //【エンコード】のドロップダウンリスト
        public List<DaSelectorModel> datakbnList { get; set; }          //【データ形式】のドロップダウンリスト
        public List<DaSelectorModel> quoteskbnList { get; set; }        //【引用符存在区分】のドロップダウンリスト
        public List<DaSelectorModel> dividekbnList { get; set; }        //【区切り記号】のドロップダウンリスト

        //詳細画面:変換コード情報のドロップダウンリストの初期化データ
        public List<DaSelectorModel> changekbnList { get; set; }        //【変換区分】ドロップダウンリスト

        //詳細画面:ストアドプロシージャ情報のドロップダウンリストの初期化データ
        public List<DaSelectorModel> procchkList { get; set; }          //【チェック用】のドロップダウンリスト
        public List<DaSelectorModel> procbeforeList { get; set; }       //【更新前処理】のドロップダウンリスト
        public List<DaSelectorModel> procafterList { get; set; }        //【更新後処理】のドロップダウンリスト

        public byte[] errorbytebuffer { get; set; }//エラーファイル出力用
    }

    /// <summary>
    /// 変換コード情報：本システムコード初期化処理(詳細画面)
    /// </summary>
    public class InitSystemCodeResponse : DaResponseBase
    {
        public List<DaSelectorModel> systemcodeList { get; set; }    //【本システムコード】ドロップダウンリスト
    }

    /// <summary>
    /// 登録項目設定情報：テーブル初期化処理(詳細画面)
    /// </summary>
    public class InitBobyTableResponse : DaResponseBase
    {
        public List<DaSelectorModel> bodytableidList { get; set; }    //【テーブル】ドロップダウンリスト
    }

    /// <summary>
    /// 登録項目設定情報：明細一覧初期化処理(詳細画面)
    /// </summary>
    public class InitTableFieldResponse : DaResponseBase
    {
        public InsertVM insertVM { get; set; }    //テーブルの登録項目設定情報
    }

    /// <summary>
    /// ストアドプロシージャ情報：ドロップダウンリストの初期化データ(詳細画面)
    /// </summary>
    public class ReSearchProcResponse : DaResponseBase
    {
        //詳細画面:ストアドプロシージャ情報のドロップダウンリストの初期化データ
        public List<DaSelectorModel> procchkList { get; set; }          //【チェック用】のドロップダウンリスト
        public List<DaSelectorModel> procbeforeList { get; set; }       //【更新前処理】のドロップダウンリスト
        public List<DaSelectorModel> procafterList { get; set; }        //【更新後処理】のドロップダウンリスト
    }

    /// <summary>
    /// 登録処理
    /// </summary>
    public class SaveDetailResponse : DaResponseBase
    {
        public string impno { get; set; }   //一括取込入力No
        public DateTime? upddttm { get; set; }  //更新日時
    }

    /// <summary>
    /// アップロード処理
    /// </summary>
    public class UploadResponse : DaResponseBase
    {
        public UploadData uploadData { get; set; } //アップロードデータ

        public byte[] errorbytebuffer { get; set; }//エラーファイル出力用
    }
}