using GaibuApiService.Base.Config;

namespace GaibuApiService.Base.Handler;

public class BaseHandler<T, API> : HttpClientHandler where T : BaseConfiguration<API> where API : IBaseApi
{
    protected readonly T Configuration;

    public BaseHandler(T configuration)
    {
        Configuration = configuration;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Set Http Request Headers
        foreach (var (key, value) in Configuration.GetHeaders())
        {
            request.Headers.Add(key, value);
        }

        //todo logger
        Console.WriteLine(request.ToString());
        var response = base.SendAsync(request, cancellationToken);
        //todo logger

        Console.WriteLine(response.Result.ToString());
        try
        {
            // Check response is success
            response.Result.EnsureSuccessStatusCode();

            // do other things
        }
        catch (HttpRequestException ex)
        {
            //todo logger
            Console.WriteLine($"Http request error, StatusCode: {ex.StatusCode}, Message: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new HttpRequestException("An error occurred when processing the HTTP response.", ex);
        }

        return response;
    }
}