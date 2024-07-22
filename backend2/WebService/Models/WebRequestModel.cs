// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: モデル定義
//
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using Microsoft.AspNetCore.Mvc;

namespace BCC.Affect.WebService
{
    public class WebRequestModel
    {
        //[FromBody]
        public string servicename { get; set; }
        public string methodname { get; set; }
        public CmRequestJson bizrequest { get; set; }
    }

    public class CmRequestJson
    {
        public string data { get; set; }       //データ
    }
}