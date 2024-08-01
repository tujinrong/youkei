// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ベースロジック
//             リクエストインターフェースベース
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json;
using System.Reflection;

namespace Jbd.Gjs.Common
{
    public class DaRequestBase
    {
        public string Service;                      //機能ID
        public string ServiceDesc;                  //サービス日本語名
        public string Method;                       //処理名
        public string MethodDesc;                   //処理日本語名
        public long sessionid;                      //セッションID
        [JsonIgnore]
        public string ip;                           //IP
        [JsonIgnore]
        public string os;                           //OS
        [JsonIgnore]
        public string browser;                      //ブラウザー
        public string userid { get; set; }          //ユーザーID
        public string? regsisyo { get; set; }       //支所
        [JsonIgnore]
        public string token;                        //トークン
        [JsonIgnore]
        public string? kinoid;                      //機能ID(画面)
        public void SetMethodInfo(MethodBase method)
        {
            Service = DaUtil.GetKinoid(method);
            Method = method!.Name;
            ServiceDesc = DaUtil.GetServiceDesc(method);
            MethodDesc = DaUtil.GetMethodDesc(method);
        }
    }
}