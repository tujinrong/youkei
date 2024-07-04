// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.変換区分管理画面
// 　　　　　　リクエストインターフェース
// 作成日　　: 2024.03.06
// 作成者　　: 高
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00601G;

namespace BCC.Affect.Service.AWKK00609D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public List<ChangeCodeMainVM> changeCodeMainList { get; set; }           //変換コードメイン情報
    }

    /// <summary>
    /// 初期化処理(【メインコード】のドロップダウンリスト)
    /// </summary>
    public class InitMaincdRequest : DaRequestBase
    {
        public string tablename { get; set; }                                   //コード管理テーブル名
    }
    /// <summary>
    /// 初期化処理(【サブコード】のドロップダウンリスト) 
    /// </summary>
    public class InitSubcdRequest : DaRequestBase
    {
        public string tablename { get; set; }                                   //コード管理テーブル名
        public string maincd { get; set; }                                      //メインコード
    }
}