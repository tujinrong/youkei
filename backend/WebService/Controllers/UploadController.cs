// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: アップロード
//             	
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using BCC.Affect.DataAccess;
using BCC.Affect.Service;
using Microsoft.AspNetCore.Mvc;

namespace BCC.Affect.WebService
{
    [Authorize]
    [ApiController]
    [Route("api/AFCT/[controller]")]
    public class UploadController : WebControllerBase
    {
        public UploadController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        [HttpPost]
        public async Task<DaResponseBase> Upload([FromForm] UploadRequestModel uploadReq)
        {
            DaResponseBase res;

            var service = _serviceFactory.GetService(uploadReq.servicename);
            var method = service.GetType().GetMethod(uploadReq.methodname)!;

            //パラメータを取得
            var bizReq = RequestFactory.GetRequestObject(uploadReq.bizrequest, method.GetParameters()[0].ParameterType);

            //Sessionの設定
            var r = SetSession<CmUploadRequestBase>(bizReq, true);
            r.sessionid = DaDbLogService.WriteMainLog(r);

            //チェック
            if (uploadReq.filerequired && (uploadReq.files == null || !uploadReq.files.Any()))
            {
                res = new DaResponseBase();
                res.SetServiceError(EnumMessage.FILE_NOTEXIST_ERROR);
            }
            else
            {
                if (uploadReq.files != null && uploadReq.files.Any())
                {
                    r.files = new List<DaFileModel>(uploadReq.files.Count);
                    foreach (var f in uploadReq.files)
                    {
                        using var memoryStream = new MemoryStream(new byte[f.Length]);
                        await f.OpenReadStream().CopyToAsync(memoryStream);

                        var index = f.FileName.LastIndexOf(DaStrPool.C_DOT);
                        var filenm = index < 0 ? f.FileName : f.FileName[..index];
                        var filetype = index < 0 ? string.Empty : f.FileName[index..];
                        r.files.Add(new DaFileModel(filenm, filetype, memoryStream.ToArray()));
                    }
                }

                // Service execution
                res = (DaResponseBase)method.Invoke(service, new object[] { r })!;
            }

            //ログを記録
            using (var db = new DaDbContext(r))
            {
                DaDbLogService.UpdateMainLog(db, res.returncode);
                DaDbLogService.WriteTusinLog(db, r, res, string.Empty);
            }
            return res;
        }
    }
}