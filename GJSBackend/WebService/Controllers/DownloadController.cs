// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ダウンロード
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using System.Net;
using BusinessService.Jbd.Gjs.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebService.Common.Base.Response;

namespace Jbd.Gjs.WebService
{
    [Authorize]
    [ApiController]
    [Route("api/AFCT/[controller]/[action]")]
    public class DownloadController : WebControllerBase
    {
        public DownloadController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        [HttpPost]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult WebRequestDownload(WebRequestModel webReq)
        {
            // アプリケーションルートの物理パスを取得
            // wwwroot の物理パスは WebRootPath プロパティを使う
            // DaGlobal.Path.ServerPath = _hostingEnvironment.ContentRootPath;

            //初期処理
            var service = _serviceFactory.GetService(webReq.SERVICE_NAME);
            var method = service.GetType().GetMethod(webReq.METHOD_NAME)!;

            // パラメータを取得
            var bizReq = RequestFactory.GetRequestObject(webReq.BIZ_REQUEST, method.GetParameters()[0].ParameterType);

            //Sessionの設定
            var r = SetSession<DaRequestBase>(bizReq, true);
            //r.sessionid = DaDbLogService.WriteMainLog(r);

            //サービス実行
            var res = (CmDownloadResponseBase)method.Invoke(service, new[] { bizReq })!;

            //ログを記録  modify sf
            //DaDbLogService.UpdateLog(webReq.servicename, webReq.methodname, startTime, r, res, GetIp(), GetOS(), GetBrowser());
            //using (var db = new DaDbContext(r))
            //{
            //    DaDbLogService.UpdateMainLog(db, res.returncode);
            //    DaDbLogService.WriteTusinLog(db, r, res, string.Empty);
            //}

            Response.Headers.Append(nameof(CmDownloadResponseBase.returncode), new StringValues(((int)res.returncode).ToString()));
            Response.Headers.Append(nameof(CmDownloadResponseBase.message), new StringValues(WebUtility.UrlEncode(res.message)));
            //if (res.returncode == EnumServiceResult.OK)
            //{
            //    switch (res.downloadtype)
            //    {
            //        case EnumDownloadType.File:
            //            //ファイルでダウンロードするする場合
            //            // Content-Disposition ヘッダを設定
            //            Response.Headers.Append(DaConst.Content_Disposition, $"attachment;filename={res.filenm}");
            //            // （RFC 6266 対応してないので注意）
            //            return new PhysicalFileResult(res.filefullnm, res.contenttype);

            //        case EnumDownloadType.Data:
            //            //データでダウンロードする場合
            //            return File(res.data, res.contenttype, res.filenm);

            //        default:
            //            throw new NotImplementedException();
            //    }
            //}

            return Ok();
        }

        //[HttpPost]
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public async Task<IActionResult> UploadDownload([FromForm] UploadRequestModel uploadReq)
        //{
        //    //CmDownloadResponseBase res;

        //    var service = _serviceFactory.GetService(uploadReq.servicename);
        //    var method = service.GetType().GetMethod(uploadReq.methodname)!;

        //    //パラメータを取得
        //    var bizReq = RequestFactory.GetRequestObject(uploadReq.bizrequest, method.GetParameters()[0].ParameterType);

        //    ////Sessionの設定
        //    //var r = SetSession<CmUploadRequestBase>(bizReq, true);
        //    //r.sessionid = DaDbLogService.WriteMainLog(r);

        //    ////チェック
        //    //if (uploadReq.files == null || !uploadReq.files.Any())
        //    //{
        //    //    res = new CmDownloadResponseBase();
        //    //    res.SetServiceError(EnumMessage.FILE_NOTEXIST_ERROR);
        //    //}
        //    //else
        //    //{
        //    //    r.files = new List<DaFileModel>(uploadReq.files.Count);
        //    //    foreach (var f in uploadReq.files)
        //    //    {
        //    //        using var memoryStream = new MemoryStream(new byte[f.Length]);
        //    //        await f.OpenReadStream().CopyToAsync(memoryStream);

        //    //        var index = f.FileName.LastIndexOf(DaStrPool.C_DOT);
        //    //        var filenm = index < 0 ? f.FileName : f.FileName[..index];
        //    //        var filetype = index < 0 ? string.Empty : f.FileName[index..];
        //    //        r.files.Add(new DaFileModel(filenm, filetype, memoryStream.ToArray()));
        //    //    }

        //    //    // Service execution
        //    //    res = (CmDownloadResponseBase)method.Invoke(service, new object[] { r })!;
        //    //}

        //    //ログを記録
        //    //using (var db = new DaDbContext(r))
        //    //{
        //    //    DaDbLogService.UpdateMainLog(db, res.returncode);
        //    //    DaDbLogService.WriteTusinLog(db, r, res, string.Empty);
        //    //}

        //    //Response.Headers.Append(nameof(CmDownloadResponseBase.returncode), new StringValues(((int)res.returncode).ToString()));
        //    //Response.Headers.Append(nameof(CmDownloadResponseBase.message), new StringValues(WebUtility.UrlEncode(res.message)));
        //    //if (res.returncode == EnumServiceResult.OK)
        //    //{
        //    //    switch (res.downloadtype)
        //    //    {
        //    //        case EnumDownloadType.File:
        //    //            //ファイルでダウンロードするする場合
        //    //            // Content-Disposition ヘッダを設定
        //    //            Response.Headers.Append(DaConst.Content_Disposition, new StringValues($"attachment;filename={res.filenm}"));
        //    //            // （RFC 6266 対応してないので注意）
        //    //            return new PhysicalFileResult(res.filefullnm, res.contenttype);

        //    //        case EnumDownloadType.Data:
        //    //            //データでダウンロードする場合
        //    //            return File(res.data, res.contenttype, res.filenm);

        //    //        default:
        //    //            throw new NotImplementedException();
        //    //    }
        //    //}

        //    return Ok();
        //}
    }
}