// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: モデル定義
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************

namespace Jbd.Gjs.WebService
{
    public class WebRequestModel
    {
        //[FromBody]

        public string SERVICE_NAME { get; set; }
        public string METHOD_NAME { get; set; }
        public CmRequestJson BIZ_REQUEST { get; set; }

    }

    public class CmRequestJson
    {
        public string DATA { get; set; }       //データ
    }
}