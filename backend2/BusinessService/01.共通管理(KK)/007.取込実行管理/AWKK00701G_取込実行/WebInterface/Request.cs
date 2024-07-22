// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行
//             リクエストインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00701G
{
    /// <summary>
    /// 検索処理(取込設定一覧画面)
    /// </summary>
    public class SearchKimpListRequest : CmSearchRequestBase
    {
        public string gyoumukbn { get; set; }   //業務区分
        public string impkbn { get; set; }      //一括取込入力区分
        public string impnm { get; set; }       //一括取込入力名
    }

    /// <summary>
    /// 削除処理(未処理一覧画面)
    /// </summary>
    public class DeleteKimpListRequest : DaRequestBase
    {
        public List<LockVM> locklist { get; set; }  //排他キーリスト
    }

    /// <summary>
    /// 初期化処理(取込（一括入力）編集画面)
    /// </summary>
    public class InitDetailRequest : CmSearchRequestBase
    {
        public int? impexeid { get; set; }          //取込実行ID
        public string impno { get; set; }           //一括取込入力No
        public Enum編集区分 editkbn { get; set; }   //編集区分
        public int? rowNo { get; set; }             //行番号
    }

    /// <summary>
    /// チェック処理(取込（一括入力）編集画面)
    /// </summary>
    public class DetailRequest : ProcessTimerRequest
    {
        public int impexeid { get; set; }                       //取込実行ID
        public string impno { get; set; }                       //一括取込入力No
        public List<KimpDetailRowVM> detailList { get; set; }   //画面項目一覧画面
        public DateTime? upddttm { get; set; }                  //更新日時
        public Enum編集区分 editkbn { get; set; }               //編集区分
        public string nendo { get; set; }                       //年度
    }

    /// <summary>
    /// 保存処理(取込（一括入力）編集画面)
    /// </summary>
    public class SaveRequest : ProcessTimerRequest
    {
        public int impexeid { get; set; }       //取込実行ID
        public string impno { get; set; }       //一括取込入力No
        public string nendo { get; set; }       //年度
    }

    /// <summary>
    /// 削除処理(取込（一括入力）編集画面)
    /// </summary>
    public class DeleteDetailRequest : DaRequestBase
    {
        public int impexeid { get; set; }           //取込実行ID
        public List<int> rownoList { get; set; }    //行番号
        public DateTime? upddttm { get; set; }      //更新日時
    }

    /// <summary>
    /// 参照元項目入力後参照先項目の値を取得処理(取込（一括入力）編集画面)
    /// </summary>
    public class GetTargetItemValueRequest : DaRequestBase
    {
        public string impno { get; set; }       //一括取込入力No
        public int pageitemseq { get; set; }    //画面項目ID
        public string val { get; set; }         //項目値
    }

    /// <summary>
    /// 取込履歴ファイルダウンロード処理(取込履歴一覧画面)
    /// </summary>
    public class KimpHistoryFileDownRequest : DaRequestBase
    {
        public int rirekiid { get; set; }       //履歴番号
    }

    /// <summary>
    /// 項目特定処理(取込（一括入力）編集画面)
    /// </summary>
    public class DoSpecialPageItemRequest : DaRequestBase
    {
        public string impno { get; set; }                       //一括取込入力No
        public int pageitemseq { get; set; }                    //画面項目ID
        public KimpDetailRowVM detailRowVM { get; set; }        //明細行データ
    }
    /// <summary>
    /// 関数値を取得処理 (取込（一括入力）編集画面)
    /// </summary>
    public class DoKansuRequest : DaRequestBase
    {
        public string impno { get; set; }                       //一括取込入力No
        public string inputhoho { get; set; }                   //入力方法
        public int pageitemseq { get; set; }                    //画面項目ID
        public KimpDetailRowVM detailRowVM { get; set; }        //明細行データ
    }
    /// <summary>
    /// 取込実行のプログレスバー
    /// </summary>
    public class ProcessTimerRequest : DaRequestBase
    {
        public string processKey { get; set; }  //処理キー
    }
}