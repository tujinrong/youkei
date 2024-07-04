// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.変換区分管理画面
// 　　　　　　ビューモデル定義
// 作成日　　: 2024.03.08
// 作成者　　: 高
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00601G;

namespace BCC.Affect.Service.AWKK00609D
{
    /// <summary>
    /// 変換コードメイン補充情報モデル
    /// </summary>
    public class ChangeCodeMainExVM : ChangeCodeMainVM
    {
        public List<DaSelectorModel> rowMaincdList { get; set; }                   // 行【メインコード】のドロップダウンリスト
        public List<DaSelectorModel> rowSubcdList { get; set; }                    // 行【サブコード】のドロップダウンリスト
    }
}