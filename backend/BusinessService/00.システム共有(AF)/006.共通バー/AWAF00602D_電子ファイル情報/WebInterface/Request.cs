// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 電子ファイル情報
//             リクエストインターフェース
// 作成日　　: 2023.03.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00602D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public Enum名称区分 kbn { get; set; }   //名称区分(事業区分)
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public string jigyocd { get; set; }     //事業コード
        public string title { get; set; }       //タイトル
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
    }

    /// <summary>
    /// プレビュー処理
    /// </summary>
    public class PreviewRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public int docseq { get; set; }         //ドキュメントシーケンス
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmUploadRequestBase
    {
        public string atenano { get; set; }         //宛名番号
        public SaveVM savevm { get; set; }          //電子ファイル情報(保存用)
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string atenano { get; set; }         //宛名番号
        public List<LockVM> locklist { get; set; }  //キーリスト(排他用)
    }

    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class DownloadRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public List<int> docseqs { get; set; }  //ドキュメントシーケンス
    }
}