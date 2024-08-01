// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 業務処理のリクエスト処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using BusinessService.Jbd.Gjs.Db;
using BusinessService.Jbd.Gjs.Service.GJ0000;
using Microsoft.AspNetCore.Mvc;

namespace Jbd.Gjs.WebService
{
    [Authorize]
    [ApiController]
    [Route("api/AFCT/[controller]")]
    public class WebRequestController : WebControllerBase
    {
        public WebRequestController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        [HttpPost]
        public object WebRequest(WebRequestModel webReq)
        {
            //初期処理
            var service = _serviceFactory.GetService(webReq.SERVICE_NAME);
            var method = service.GetType().GetMethod(webReq.METHOD_NAME)!;

            // パラメータを取得
            var bizReq = RequestFactory.GetRequestObject(webReq.BIZ_REQUEST, method.GetParameters()[0].ParameterType);

            //Sessionの設定
            var r = SetSession<DaRequestBase>(bizReq, true);
            r.sessionid = DaDbLogService.WriteMainLog(r);

            //サービス実行
            var res = (UserInfoResponse)method.Invoke(service, new[] { bizReq })!;

            //ログを記録
            r.Service = webReq.SERVICE_NAME;
            r.Method = webReq.METHOD_NAME;
            using (var db = new DaDbContext(r))
            {
                db.Session.UserID = res.userid;
                DaDbLogService.UpdateMainLog(db, res.returncode);
                DaDbLogService.WriteTusinLog(db, r, res, string.Empty);
            }

            //結果を返す
            return res;
        }
    }
}