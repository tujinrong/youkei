// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 例外処理
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using Microsoft.AspNetCore.Mvc.Filters;

namespace BCC.Affect.WebService
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext executedContext)
        {
            var actionExecutedContext = executedContext.HttpContext.RequestServices.GetService(typeof(ActionExecutedContext)) as ActionExecutedContext;
            //todo 屠
            string logmsg = string.Empty;
            // log記録
            if (actionExecutedContext == null)
            {
                logmsg = logmsg = string.Format("{0}" + Environment.NewLine + "{1}", executedContext.Exception.Message, executedContext.Exception.StackTrace);
            }
            else
            {
                logmsg = string.Format("{0}" + Environment.NewLine + "{1}", actionExecutedContext!.Exception!.Message, actionExecutedContext.Exception.StackTrace);
            }
            //DaLogUtil.WirteEnventLog(DaLogUtil.Level.ERROR, actionExecutedContext.HttpContext.Request.Path.ToString(), logmsg);
            //DaLogUtil.WriteLog(DaLogUtil.Level.ERROR, actionExecutedContext.HttpContext.Request.Path.ToString(), logmsg);

            base.OnException(executedContext);
        }
    }
}