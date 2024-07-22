using GaibuApiService.GaibuDemo.Config;
using GaibuApiService.GaibuDemo.Domain.Requests;
using GaibuApiService.GaibuDemo.Domain.Responses;

namespace GaibuApiService.GaibuDemo.Session.Default;

public class DefaultDemoSession : IDemoSession
{
    private readonly DemoConfiguration Configuration;

    public DefaultDemoSession(DemoConfiguration configuration)
    {
        Configuration = configuration;
    }

    public DemoResponse TestWebRequest(DemoRequest req)
    {
        var res = Configuration.Api.TestWebRequest(req);
        return res.Result;
    }

    public object DoSomeThing(object req)
    {
        var res = Configuration.Api.DoSomeThing(req);
        return res.Result;
    }
}