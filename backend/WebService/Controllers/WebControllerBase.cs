// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: WEB処理のベースクラス
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************

using BusinessService.Jbd.Gjs.Db;
using Microsoft.AspNetCore.Mvc;

namespace Jbd.Gjs.WebService
{
    public class WebControllerBase : Controller
    {
        // Core では Server.MapPath が使えないことの対応
        protected readonly IWebHostEnvironment _hostingEnvironment;
        protected readonly ServiceFactory _serviceFactory;

        public WebControllerBase(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _serviceFactory = serviceFactory;
        }

        /// <summary>
        /// リクエストSessionを設定
        /// </summary>
        protected TReq SetSession<TReq>(object? req, bool authflg) where TReq : DaRequestBase, new()
        {
            var r = new TReq();
            try
            {
                if (req != null)
                {
                    r = (TReq)req;
                    r.ip = GetInfo(nameof(DaRequestBase.ip))!;
                    r.os = GetInfo(nameof(DaRequestBase.os))!;
                    r.browser = GetInfo(nameof(DaRequestBase.browser))!;
                    if (authflg)
                    {
                        r.token = GetInfo("Token")!;
                        r.USER_ID = GetInfo(nameof(DaRequestBase.USER_ID))!;
                        //r.regsisyo = GetInfo(nameof(DaRequestBase.regsisyo));
                        r.kinoid = GetInfo(nameof(DaRequestBase.kinoid));
                    }
                }
            }
            catch
            {
                // ignored
            }
            finally
            {

            }

            return r;
        }

        /// <summary>
        /// フロントエンドヘッダー情報取得
        /// </summary>
        private string? GetInfo(string nm)
        {
            switch (nm)
            {
                case nameof(DaRequestBase.ip):
                    return GetIp();
                case nameof(DaRequestBase.os):
                case nameof(DaRequestBase.browser):
                case nameof(DaRequestBase.USER_ID):
                case "Token":
                    return Request.Headers[nm].FirstOrDefault() ?? string.Empty;
                //case nameof(DaRequestBase.regsisyo):
                //    return Request.Headers[nm].FirstOrDefault();
                case nameof(DaRequestBase.kinoid):
                    return Request.Headers[nm].FirstOrDefault();
                default:
                    throw new Exception("DaRequestBase name error");
            }
        }

        /// <summary>
        /// クライアントIPを取得する
        /// </summary>
        private string GetIp()
        {
            var ip = Request.Headers["X-Forwarded-For"].FirstOrDefault() ?? string.Empty;
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            }

            if (string.IsNullOrEmpty(ip) || ip.Contains("::1") || ip.Contains("::ffff:"))
            {
                ip = "127.0.0.1";
            }

            return ip;
        }
    }
}