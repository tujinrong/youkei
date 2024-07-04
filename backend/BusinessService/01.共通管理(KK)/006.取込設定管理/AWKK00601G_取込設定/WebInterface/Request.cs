// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定
//             リクエストインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00601G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string gyoumukbn { get; set; }   //業務区分
        public string impnm { get; set; }       //一括取込入力名
    }

    /// <summary>
    /// 共通処理(詳細画面)
    /// </summary>
    public class DetailCommonRequest : DaRequestBase
    {
        public string impno { get; set; }       //一括取込入力No
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DetailCommonRequest
    {
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public bool isUpload { get; set; }          //アップロード処理フラグ
        public UploadData uploadData { get; set; }  //アップロードデータ
    }

    /// <summary>
    /// 削除処理(詳細画面)
    /// </summary>
    public class DeleteDetailRequest : DetailCommonRequest
    {
        public DateTime? upddttm { get; set; }  //更新日時
    }

    /// <summary>
    /// 変換コード情報：コード変換区分初期化処理(詳細画面)
    /// </summary>
    public class InitCodeChangeRequest : DaRequestBase
    {
        public string gyoumukbn { get; set; }   //業務区分
        public string impno { get; set; }       //一括取込入力No
    }

    /// <summary>
    /// 変換コード情報：本システムコード初期化処理(詳細画面)
    /// </summary>
    public class InitSystemCodeRequest : InitCodeChangeRequest
    {
        public ChangeCodeMainVM changeCodeMainData { get; set; }   //変換コードメイン情報
    }

    /// <summary>
    /// 登録項目設定情報：テーブル変換区分初期化処理(詳細画面)
    /// </summary>
    public class InitBodyTableRequest : DaRequestBase
    {
        public List<string> seletedTableIDList { get; set; }   //ヘッダーに選択したテーブル物理ID(TA,TB)
    }

    /// <summary>
    /// 登録項目設定情報：明細一覧初期化処理(詳細画面)
    /// </summary>
    public class InitTableFieldRequest : DaRequestBase
    {
        public string tableid { get; set; }   //テーブル物理ID
    }

    /// <summary>
    /// 登録処理(詳細画面)
    /// </summary>
    public class SaveDetailRequest : DaRequestBase
    {
        public DateTime? upddttm { get; set; }                          //更新日時
        public Enum編集区分 editkbn { get; set; }                       //編集区分

        public HeaderVM hearderData { get; set; }                       //詳細画面:ヘッダー情報
        public FileInfoVM fileinfoData { get; set; }                    //詳細画面:基本情報
        public List<FileIFVM> fileifList { get; set; }                  //詳細画面:ファイルI/F情報
        public List<CodeChangeVM> codechangeList { get; set; }          //詳細画面:取込コード変換情報
        public List<ItemMappingVM> itemmappingList { get; set; }        //詳細画面:マッピング設定情報
        public List<PageItemVM> pageitemList { get; set; }              //詳細画面:画面項目情報
        public List<InsertVM> insertList { get; set; }                  //詳細画面:登録仕様情報

        public List<ChangeCodeMainVM> changeCodeMainList { get; set; }  //詳細画面:変換コードメイン情報
    }

    /// <summary>
    /// アップロード処理
    /// </summary>
    public class UploadRequest : CmUploadRequestBase
    {
        public string impno { get; set; }           //一括取込入力No
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }

    /// <summary>
    /// エラーファイル出力用
    /// </summary>
    public class ErrorDownloadRequest : DaRequestBase
    {
        public byte[] errorbytebuffer;  //エラー
    }

    /// <summary>
    /// 「並び順」重複エラーチェック処理(詳細画面)
    /// </summary>
    public class CheckOrderSeqRequest : DaRequestBase
    {
        public int orderseq { get; set; }       //並び順シーケンス
        public string gyoumukbn { get; set; }   //業務区分
        public string impkbn { get; set; }      //一括取込入力区分
        public string impno { get; set; }       //一括取込入力No
    }
}