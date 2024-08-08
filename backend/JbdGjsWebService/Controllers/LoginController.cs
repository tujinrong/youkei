// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログインのWEB処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using JbdGjsService.JBD.GJS.Db;
using JbdGjsService.JBD.GJS.Service.GJ0000;
using Microsoft.AspNetCore.Mvc;

namespace JBD.GJS.WebService
{
    [ApiController]
    [Route("api/AFCT/[controller]")]
    public class LoginController : WebControllerBase
    {

        public LoginController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        [HttpPost]
        public Object Login(WebRequestModel webReq)
        {
            // サービス
            var service = _serviceFactory.GetService(webReq.SERVICE_NAME);
            var method = service.GetType().GetMethod(webReq.METHOD_NAME)!;

            // パラメータを取得
            var bizReq = RequestFactory.GetRequestObject(webReq.BIZ_REQUEST, method.GetParameters()[0].ParameterType);

            //Sessionの設定
            var r = SetSession<DaRequestBase>(bizReq, false);

            r.sessionid = DaDbLogService.WriteMainLog(r);

            //サービス実行
            var res = (LoginResponse)method.Invoke(service, new object[] { bizReq })!;

            //ログを記録

            r.Service = webReq.SERVICE_NAME;
            r.Method = webReq.METHOD_NAME;
            using (var db = new DaDbContext(r))
            {
                DaDbLogService.UpdateMainLog(db, EnumLogStatus.正常終了);
                DaDbLogService.WriteTusinLog(db, r, res , String.Empty);
            }
            return res;
        }
    }
}