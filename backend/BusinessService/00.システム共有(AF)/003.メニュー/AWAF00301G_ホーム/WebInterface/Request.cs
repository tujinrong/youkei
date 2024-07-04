// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ホーム
//             リクエストインターフェース
// 作成日　　: 2023.02.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00301G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public Enum名称区分 kbn { get; set; }   //名称区分(処理区分)
    }

    /// <summary>
    /// 検索処理(お知らせ)
    /// </summary>
    public class SearchInfoRequest : DaRequestBase
    {
        public Enum未読区分 readkbn { get; set; }   //未読区分
    }

    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class DownloadRequest : DaRequestBase
    {
        public long gaibulogseq { get; set; } //外部連携ログシーケンス
    }
}