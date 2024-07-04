// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログインのWEB処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using BCC.Affect.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BCC.Affect.WebService
{
    [ApiController]
    [Route("api/AFCT/[controller]")]
    public class LoginController : WebControllerBase
    {
        public LoginController(IWebHostEnvironment hostingEnvironment, ServiceFactory serviceFactory) : base(hostingEnvironment, serviceFactory)
        {
        }

        [HttpPost]
        public object Login(WebRequestModel webReq)
        {
            // サービス
            var service = _serviceFactory.GetService(webReq.servicename);
            var method = service.GetType().GetMethod(webReq.methodname)!;

            // パラメータを取得
            var bizReq = RequestFactory.GetRequestObject(webReq.bizrequest, method.GetParameters()[0].ParameterType);

            //Sessionの設定
            var r = SetSession<DaRequestBase>(bizReq, false);

            r.sessionid = DaDbLogService.WriteMainLog(r);

            //サービス実行
            var res = method.Invoke(service, new object[] { bizReq })!;

            //ログを記録
            r.Service = webReq.servicename;
            r.Method = webReq.methodname;
            using (var db = new DaDbContext(r))
            {
                if (r.userid != DaConst.SYSTEM && db.tm_afuser.SELECT.WHERE.ByKey(r.userid).Exists() == false)
                {
                    //ユーザーが存在しない場合、IDをログを記録するためのものに設定
                    r.userid = DaConst.SYSTEM;
                }
                DaDbLogService.UpdateMainLog(db, EnumLogStatus.正常終了);
                DaDbLogService.WriteTusinLog(db, r, (DaResponseBase)res!, string.Empty);
            }
            return res;
        }
    }
}