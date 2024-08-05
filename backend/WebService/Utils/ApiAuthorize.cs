// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: API認証
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using Microsoft.AspNetCore.Mvc.Filters;

public enum Role
{
    User,
    Everyone
}

namespace JBD.GJS.WebService
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? new Role[] { };
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            //var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            //if (allowAnonymous)
            //    return;

            //var actionContext = context.HttpContext;
            //var tokenInfo = StringValues.Empty;
            //var userInfo = StringValues.Empty;
            //var sisyoInfo = StringValues.Empty;
            //actionContext.Request.Headers.TryGetValue("Token", out tokenInfo);
            //actionContext.Request.Headers.TryGetValue(nameof(tm_afuserDto.userid), out userInfo);
            //actionContext.Request.Headers.TryGetValue("regsisyo", out sisyoInfo);
            //if (!(StringValues.IsNullOrEmpty(tokenInfo)) && !(StringValues.IsNullOrEmpty(userInfo)))
            //{
            //    string token = tokenInfo.ToList()[0]!;
            //    string userid = userInfo.ToList()[0]!;
            //    string? regsisyo = null;
            //    if (sisyoInfo.Count != 0)
            //    {
            //        regsisyo = CStr(sisyoInfo.ToList()[0]);
            //    }

            //    if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(userid))
            //    {
            //        try
            //        {
            //            string msg = "";
            //            // using (){}の方が安全
            //            using (var db = new DaDbContext())
            //            {
            //                //db.Session.UserID = userid;
            //                if (!DaTokenService.Validate(db, token, ref userid, ref regsisyo, ref msg))
            //                {
            //                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //                }
            //                return;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            //        }
            //    }
            //}
            //context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }
}