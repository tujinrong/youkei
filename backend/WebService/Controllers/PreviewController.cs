// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: プレビュー
//
// 作成日　　: 2023.03.09
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using System.Net;
using BCC.Affect.DataAccess;
using BCC.Affect.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BCC.Affect.WebService
{
    [Authorize]
    [ApiController]
    [Route("api/AFCT/[controller]")]
    public class PreviewController : WebControllerBase
    {
        public PreviewController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Preview(WebRequestModel webReq)
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
            var res = (CmPreviewResponseBase)method.Invoke(service, new[] { bizReq })!;

            //ログを記録
            //DaDbLogService.UpdateLog(webReq.servicename, webReq.methodname, startTime, r, res, GetIp(), GetOS(), GetBrowser());
            using (var db = new DaDbContext(r))
            {
                DaDbLogService.UpdateMainLog(db, res.returncode);
                DaDbLogService.WriteTusinLog(db, r, res!, string.Empty);
            }

            Response.Headers.Append(nameof(CmPreviewResponseBase.returncode), new StringValues(((int)res.returncode).ToString()));
            Response.Headers.Append(nameof(CmPreviewResponseBase.message), new StringValues(WebUtility.UrlEncode(res.message)));
            if (res.returncode == EnumServiceResult.OK)
            {
                return new FileStreamResult(new MemoryStream(res.data), res.contenttype);
            }

            return Ok();
        }
    }
}