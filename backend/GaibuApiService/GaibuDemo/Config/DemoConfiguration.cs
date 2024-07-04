using GaibuApiService.Base.Config;

namespace GaibuApiService.GaibuDemo.Config;

/// <summary>
/// Demo Configuration
/// </summary>
public class DemoConfiguration : BaseConfiguration<IDemoApi>
{
    public readonly string Userid;
    public readonly string Token;
    public readonly string Regsisyo;

    public DemoConfiguration(string userid, string token, string regsisyo)
    {
        Userid = userid;
        Token = token;
        Regsisyo = regsisyo;
    }

    public override IDictionary<string, string> GetHeaders()
    {
        return new Dictionary<string, string>
        {
            [nameof(Userid)] = Userid,
            [nameof(Token)] = Token,
            [nameof(Regsisyo)] = Regsisyo
        };
    }
}