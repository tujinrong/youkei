// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: プレビュー
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Microsoft.AspNetCore.Mvc;

namespace Jbd.Gjs.WebService
{
    [Authorize]
    [ApiController]
    [Route("api/AFCT/[controller]/[action]")]
    public class ReportPreviewController : WebControllerBase
    {
        public ReportPreviewController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        //[HttpPost]
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // 請求書のプレビュー画面
        //public async Task<IActionResult> ReportPreview([FromForm] UploadRequestModel uploadReq)
        //{
        //    object res;
        //    var service = _serviceFactory.GetService(uploadReq.servicename);
        //    var method = service.GetType().GetMethod(uploadReq.methodname)!;

        //    //todo パラメータを取得
        //    var bizReq = RequestFactory.GetRequestObject(uploadReq.bizrequest, method.GetParameters()[0].ParameterType);

        //    //Sessionの設定
        //    var r = SetSession<CmUploadRequestBase>(bizReq, true);
        //    //r.sessionid = DaDbLogService.WriteMainLog(r);

        //    //チェック
        //    if (uploadReq.filerequired && (uploadReq.files == null || !uploadReq.files.Any()))
        //    {
        //        var resp = new CmPreviewResponseBase();
        //        // TODO: no files to upload
        //        resp.SetServiceError("no file to upload");
        //        res = resp;
        //    }
        //    else
        //    {
        //        if (uploadReq.files != null && uploadReq.files.Any())
        //        {
        //            r.files = new List<DaFileModel>(uploadReq.files.Count);
        //            foreach (var f in uploadReq.files)
        //            {
        //                using var memoryStream = new MemoryStream(new byte[f.Length]);
        //                await f.OpenReadStream().CopyToAsync(memoryStream);
        //                var index = f.FileName.LastIndexOf(DaStrPool.C_DOT);
        //                var filenm = index < 0 ? f.FileName : f.FileName[..index];
        //                var filetype = index < 0 ? string.Empty : f.FileName[index..];
        //                r.files.Add(new DaFileModel(filenm, filetype, memoryStream.ToArray()));
        //            }
        //        }

        //        // Service execution
        //        res = method.Invoke(service, new object[] { r })!;
        //    }

        //    return Ok(res);
        //}

        //[HttpPost]
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult PreviewExistReport(WebRequestModel webReq)
        //{
        //    var service = _serviceFactory.GetService(webReq.servicename);
        //    var method = service.GetType().GetMethod(webReq.methodname)!;

        //    //パラメータを取得
        //    var bizReq = RequestFactory.GetRequestObject(webReq.bizrequest, method.GetParameters()[0].ParameterType);

        //    //todo Sessionの設定
        //    var r = SetSession<DaRequestBase>(bizReq, true);
        //    //r.sessionid = DaDbLogService.WriteMainLog(r);

        //    //Service execution
        //    var res = method.Invoke(service, new object[] { r });

        //    return Ok(res);
        //}
    }
}