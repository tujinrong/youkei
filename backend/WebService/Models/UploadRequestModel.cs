// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: アップロード
//             モデル定義
// 作成日　　: 2023.03.08
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.WebService
{
    public class UploadRequestModel
    {
        public string servicename { get; set; }
        public string methodname { get; set; }
        public CmRequestJson bizrequest { get; set; }
        public IFormFileCollection? files { get; set; }
        public bool filerequired { get; set; } = true;
    }
}