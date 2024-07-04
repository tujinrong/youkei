// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 業務処理のリクエスト処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using BCC.Affect.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BCC.Affect.WebService
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
            var service = _serviceFactory.GetService(webReq.servicename);
            var method = service.GetType().GetMethod(webReq.methodname)!;

            // パラメータを取得
            var bizReq = RequestFactory.GetRequestObject(webReq.bizrequest, method.GetParameters()[0].ParameterType);

            //Sessionの設定
            var r = SetSession<DaRequestBase>(bizReq, true);
            r.sessionid = DaDbLogService.WriteMainLog(r);

            //サービス実行
            var res = (DaResponseBase)method.Invoke(service, new[] { bizReq })!;

            //ログを記録
            using (var db = new DaDbContext(r))
            {
                DaDbLogService.UpdateMainLog(db, res.returncode);
                DaDbLogService.WriteTusinLog(db, r, res, string.Empty);
            }

            //結果を返す
            return res;
        }
    }
}