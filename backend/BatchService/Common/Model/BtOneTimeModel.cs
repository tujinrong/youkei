// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチ共通モデルクラス
//            
// 作成日　　: 2023.01.12
// 作成者　　: 屠
// 変更履歴　: 
// *******************************************************************
namespace BCC.Affect.BatchService
{
    /// <summary>
    /// 一回実行の場合
    /// </summary>
    public class BtOneTimeModel
    {
        public DateTime shoridttmf { get; set; } // 処理開始日時
        public DateTime shoridttmt { get; set; } // 処理終了日時
      
    }
}