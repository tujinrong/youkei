using System.Text.Json.Serialization;

namespace GaibuApiService.GaibuDemo.Domain.Others;

public class Sisyo
{
    [JsonPropertyName("sisyocd")]
    public string cd { get; set; } //支所コード
    [JsonPropertyName("sisyonm")]
    public string nm { get; set; } //支所名
}