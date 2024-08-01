// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログインのWEB処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using BusinessService.Jbd.Gjs.Db;
using Microsoft.AspNetCore.Mvc;

namespace Jbd.Gjs.WebService
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

            // 获取 Service 类型
            //Type vbClassType = Type.GetType("BusinessService.Jbd.Gjs.Service." + webReq.servicename + ".Service, BusinessService");

            //// 创建 Service 类实例
            //object vbClassInstance = Activator.CreateInstance(vbClassType);

            //// 获取 Login 方法信息
            //MethodInfo loginMethod = vbClassType.GetMethod(webReq.methodname);

            //LoginRequest request = new LoginRequest();
            //request.userid = "gjs";
            //request.pword = "gjs";

            //// 准备方法参数
            //object[] parameters = new object[] { request };
            //var res = method.Invoke(service, new object[] { bizReq })!;

            //// 调用方法
            ////LoginResponse result = (LoginResponse)loginMethod.Invoke(vbClassInstance, parameters);
            //Type loginResponseType = result.GetType();
            //PropertyInfo returnCodeProperty = loginResponseType.GetProperty("returncode");
            //PropertyInfo messageProperty = loginResponseType.GetProperty("message");

            //if (returnCodeProperty != null && messageProperty != null)
            //{
            //    Console.WriteLine($"Return Code: {returnCodeProperty.GetValue(result)}");
            //    Console.WriteLine($"Message: {messageProperty.GetValue(result)}");
            //}

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
                //if (r.userid != DaConst.SYSTEM && db.tm_afuser.SELECT.WHERE.ByKey(r.userid).Exists() == false)
                //{
                //    //ユーザーが存在しない場合、IDをログを記録するためのものに設定
                //    r.userid = DaConst.SYSTEM;
                //}
                DaDbLogService.UpdateMainLog(db, EnumLogStatus.正常終了);
                DaDbLogService.WriteTusinLog(db, r, (DaResponseBase)res , String.Empty);
            }
            return res;
        }
    }
}