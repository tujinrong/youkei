namespace GaibuApiService.Base.Config;

public interface IHttpHeader
{
    IDictionary<string, string> GetHeaders();
}