// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 例外処理
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Microsoft.AspNetCore.Mvc.Filters;

namespace JBD.GJS.WebService
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext executedContext)
        {
            var actionExecutedContext = executedContext.HttpContext.RequestServices.GetService(typeof(ActionExecutedContext)) as ActionExecutedContext;
            //todo 
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

            base.OnException(executedContext);
        }
    }
}