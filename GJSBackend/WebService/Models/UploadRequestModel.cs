// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: アップロード
//             モデル定義
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
namespace Jbd.Gjs.WebService
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