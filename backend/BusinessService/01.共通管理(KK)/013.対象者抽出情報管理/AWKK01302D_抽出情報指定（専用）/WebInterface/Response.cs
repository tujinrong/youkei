// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 抽出情報指定（専用）
//             レスポンスインターフェース
// 作成日　　: 2024.06.03
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK01302D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorKeyModel> selectorlist { get; set; }              //ドロップダウンリスト(抽出対象)
        public bool nendoflg { get; set; }                                      //年度表示フラグ
    }
    /// <summary>
    /// 個別除外チェック
    /// </summary>
    public class CheckResponse : DaResponseBase
    {
        public TyusyutuVM tyusyutuinfo { get; set; }                            //抽出対象情報（帳票出力画面遷移用）
    }
}