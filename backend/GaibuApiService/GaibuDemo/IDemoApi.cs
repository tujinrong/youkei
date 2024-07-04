using GaibuApiService.Base;
using GaibuApiService.GaibuDemo.Domain.Requests;
using GaibuApiService.GaibuDemo.Domain.Responses;
using Refit;

namespace GaibuApiService.GaibuDemo;

/**
 * This is a demo api interface
 */
public interface IDemoApi : IBaseApi
{
    //Base url for the api
    public new string BaseUrl => "https://demo.health.aiplus.best";

    #region Versions

    const string VERSION_V1 = "v1";
    const string VERSION_V2 = "v2";

    #endregion

    //Latest version
    const string LATEST_VERSION = VERSION_V2;

    /// <summary>
    /// path must start with '/'
    /// This is a login demo endpoint
    /// </summary>
    [Post("/api/AFCT/WebRequest")]
    Task<DemoResponse> TestWebRequest([Body] DemoRequest req);

    /**
     * This is a demo endpoint
     */
    [Post($"/{LATEST_VERSION}/doSomeThing")]
    Task<object> DoSomeThing([Body] object req);
}