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
    public class JobNextExecutionInfo
    {
        public string JobId { get; set; }
        public DateTime? NextExecutionTime { get; set; }
    }
}