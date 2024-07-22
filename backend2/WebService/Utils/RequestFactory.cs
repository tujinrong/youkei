// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: インスタンス管理
//
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.DataAccess;
using Newtonsoft.Json;

namespace BCC.Affect.WebService
{
    public class RequestFactory
    {
        /// <summary>
        /// パラメータを取得
        /// </summary>
        public static object GetRequestObject(CmRequestJson req, Type reqType)
        {
            // ユーザー情報設定
            var paramsStr = req.data;
            var para = JsonConvert.DeserializeObject(paramsStr, reqType);
            if (para == null) para = new DaRequestBase();
            return para;
        }
    }
}