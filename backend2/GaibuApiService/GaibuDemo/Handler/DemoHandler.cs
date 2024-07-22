using GaibuApiService.Base.Handler;
using GaibuApiService.GaibuDemo.Config;

namespace GaibuApiService.GaibuDemo.Handler;

public class DemoHandler : BaseHandler<DemoConfiguration, IDemoApi>
{
    public DemoHandler(DemoConfiguration configuration) : base(configuration)
    {
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        //override this method and do something special in your handler
        Console.WriteLine("do something...");
        return base.SendAsync(request, cancellationToken);
    }
}