using Hangfire.Dashboard;

namespace BCC.Affect.WebService;

public class HangfireAuthFilter : IDashboardAuthorizationFilter
{
    public bool Authorize(DashboardContext context)
    {
        //todo 認証
        return true;
    }
}