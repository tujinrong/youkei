// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行
//             レスポンスインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00701G
{
    /// <summary>
    /// 初期化処理(取込設定一覧画面)
    /// </summary>
    public class InitKimpListResponse : DaResponseBase
    {
        public string gyoumukbn { get; set; }                           //業務区分
        public string impkbn { get; set; }                              //一括取込入力区分
    }

    /// <summary>
    /// 検索処理(取込設定一覧画面)
    /// </summary>
    public class SearchKimpListResponse : CmSearchResponseBase
    {
        public List<KimpRowVM> kimpList { get; set; }    //汎用取込設定情報リスト
    }

    /// <summary>
    /// 初期検索処理(未処理一覧画面)
    /// </summary>
    public class SearchKimpDataListResponse : CmSearchResponseBase
    {
        public List<KimpDataRowVM> kimpDataList { get; set; }    //取込データ情報リスト
    }

    /// <summary>
    /// 初期検索処理(取込履歴一覧画面)
    /// </summary>
    public class SearchKimpHistoryListResponse : CmSearchResponseBase
    {
        public List<KimpHistoryRowVM> kimpHistoryList { get; set; }    //取込履歴情報リスト
    }

    /// <summary>
    /// チェック処理(取込（一括入力）編集画面)
    /// </summary>
    public class CheckInfoResponse : SaveWorkResponse
    {
        public int normalCnt { get; set; } = 0; //正常件数
        public int infoCnt { get; set; } = 0;   //情報件数
        public int warnCnt { get; set; } = 0;   //警告件数
        public int errCnt { get; set; } = 0;    //エラー件数
    }

    /// <summary>
    /// 仮保存処理(取込（一括入力）編集画面)
    /// </summary>
    public class SaveWorkResponse : DaResponseBase
    {
        public int impexeid { get; set; }       //取込実行ID
        public DateTime? upddttm { get; set; }  //更新日時
    }

    /// <summary>
    /// 初期化処理(取込（一括入力）編集画面)
    /// </summary>
    public class InitDetailResponse : CmSearchResponseBase
    {
        public DateTime? upddttm { get; set; }      //更新日時

        public int impexeid { get; set; }           //取込実行ID
        public int normalCnt { get; set; } = 0;     //正常件数
        public int infoCnt { get; set; } = 0;       //情報件数
        public int warnCnt { get; set; } = 0;       //警告件数
        public int errCnt { get; set; } = 0;        //エラー件数
        public int rownoMax { get; set; } = 0;      //最大行数
        public bool yeardispflg { get; set; }       //年度表示フラグ
        public string impkbn { get; set; }          //一括取込入力区分
        public string gyoumukbnnm { get; set; }     //業務区分名称
        public string impnm { get; set; }           //一括取込入力名
        public string? nendo { get; set; }          //初期表示年度
        public string? nendomax { get; set; }       //最大年度
        public List<PageItemHeaderModel> PageItemHeaderList { get; set; }                       //画面項目ヘッダーデータリスト
        public List<KimpDetailRowVM> detailList { get; set; }                                   //画面項目明細データリスト
        public Dictionary<int, List<DaSelectorModel>> cdchangeSelectorDic { get; set; }         //画面項目の入力区分がコード変換時用システムコードデータ
        public Dictionary<int, List<DaSelectorKeyModel>> cdchangeOldSelectorDic { get; set; }   //画面項目の入力区分がコード変換時用旧コードデータ
        public Dictionary<string, List<DaSelectorModel>> selectorDic { get; set; }              //画面項目の入力区分がプルダウンリスト時用データ

        public int pagenum { get; set; }            //ページNo.
    }

    /// <summary>
    /// 参照元項目入力後取得先項目の値を取得処理(取込（一括入力）編集画面)
    /// </summary>
    public class GetTargetItemValueResponse : DaResponseBase
    {
        public List<object[]> targetItemValueList { get; set; } //取得先項目の値リスト
    }

    /// <summary>
    /// 項目特定処理(取込（一括入力）編集画面)
    /// </summary>
    public class DoSpecialPageItemResponse : DaResponseBase
    {
        public List<object[]> targetItemValueList { get; set; } //取得先項目の値リスト
    }

    /// <summary>
    /// 関数値を取得処理(取込（一括入力）編集画面)
    /// </summary>
    public class DoKansuResponse : DaResponseBase
    {
        public List<object[]> KansuValueList { get; set; } //
    }

    /// <summary>
    /// 取込実行のプログレスバー
    /// </summary>
    public class ProcessTimerResponse : DaResponseBase
    {
        public string processnm { get; set; }   //処理内容
        public int value { get; set; }          //進捗値
    }
}