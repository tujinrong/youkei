using Refit;

namespace GaibuApiService.Base.Config;

public class BaseConfiguration<T> : IHttpHeader where T : IBaseApi
{
    private static readonly HttpClient DEFAULT_CLIENT = new();
    private static readonly RefitSettings DEFAULT_SETTINGS = new();

    public T Api { get; set; }
    public TimeSpan TimeOut { get; set; } = TimeSpan.FromSeconds(60d);
    public HttpClient HttpClient { get; set; } = DEFAULT_CLIENT;
    public RefitSettings RefitSettings { get; set; } = DEFAULT_SETTINGS;
    
    public virtual IDictionary<string, string> GetHeaders()
    {
        return new Dictionary<string, string>();
    }
}