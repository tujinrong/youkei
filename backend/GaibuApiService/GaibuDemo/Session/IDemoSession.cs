using GaibuApiService.Base.Session;
using GaibuApiService.GaibuDemo.Domain.Requests;
using GaibuApiService.GaibuDemo.Domain.Responses;

namespace GaibuApiService.GaibuDemo.Session;

public interface IDemoSession : IBaseSession
{
    DemoResponse TestWebRequest(DemoRequest req);
    object DoSomeThing(object req);
}