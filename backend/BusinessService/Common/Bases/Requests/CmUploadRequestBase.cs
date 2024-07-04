// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: アップロード処理
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2023.02.14
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service
{
    public class CmUploadRequestBase : DaRequestBase 
    {
        public List<DaFileModel> files { get; set; } = new List<DaFileModel>();     // ファイルリスト
    }
}