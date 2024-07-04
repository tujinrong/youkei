// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: インタフェース
//             
// 作成日　　: 2024.01.17
// 作成者　　: 屠
// 変更履歴　: 
// *******************************************************************
namespace BCC.Affect.BatchService
{
    public interface IBtService : IBatchService
    {
        void Execute(string? taskID, object? param = null, long? sessionseq = null,bool? nowFlg = false);
    }


    public interface IBatchService
    {
    }
}