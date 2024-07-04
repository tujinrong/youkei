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
    public class JobNextExecutionInfo
    {
        public string JobId { get; set; }
        public DateTime? NextExecutionTime { get; set; }
    }
}