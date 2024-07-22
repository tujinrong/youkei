using GaibuApiService.GaibuDemo.Config;
using GaibuApiService.GaibuDemo.Handler;
using Refit;

namespace GaibuApiService.GaibuDemo.Session.Default;

public class DefaultDemoSessionFactory : IDemoSessionFactory
{
    private readonly DemoConfiguration Configuration;

    public DefaultDemoSessionFactory(DemoConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IDemoSession OpenSession()
    {
        var handler = new DemoHandler(Configuration) { UseProxy = false };
        Configuration.HttpClient = new HttpClient(handler) { Timeout = Configuration.TimeOut };
        Configuration.Api = RestService.For<IDemoApi>(Configuration.HttpClient, Configuration.RefitSettings);
        Configuration.HttpClient.BaseAddress = new Uri(Configuration.Api.BaseUrl);
        return new DefaultDemoSession(Configuration);
    }
}