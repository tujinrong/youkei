// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: バッチ共通モデルクラス
//            
// 作成日　　: 
// 作成者　　: 
// 変更履歴　: 
// *******************************************************************
namespace BCC.Affect.BatchService
{
    /// <summary>
    /// 実行状況
    /// </summary>
    public class BtJobInfo
    {
        public DateTime zenjikkodttmf { get; set; } // 前回開始日時
        public DateTime zenjikkodttmt { get; set; } // 前回終了日時

        public DateTime? jikaijikkodttmt { get; set; }  //次回実行日時

    }
}