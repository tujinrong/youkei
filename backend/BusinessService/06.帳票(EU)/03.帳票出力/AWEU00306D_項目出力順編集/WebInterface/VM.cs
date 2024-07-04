// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目出力順編集
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00306D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class SortSubVM
    {
        public string reportitemid { get; set; } //帳票項目ID
        public bool descflg { get; set; }        //降順フラグ
        public bool pageflg { get; set; }        //改ページフラグ
    }
}