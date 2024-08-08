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
        }
    }
}