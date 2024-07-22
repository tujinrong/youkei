using System.Text.Json.Serialization;

namespace GaibuApiService.GaibuDemo.Domain.Requests;

public class DemoRequest
{
    [JsonPropertyName("servicename")] 
    public string service { get; set; }
    
    public string methodname { get; set; }
    
    [JsonPropertyName("bizrequest")] 
    public RequestJson request { get; set; }
}

public class RequestJson
{
    public string data { get; set; }
}