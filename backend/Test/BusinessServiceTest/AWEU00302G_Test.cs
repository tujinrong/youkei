/*using Newtonsoft.Json;

namespace BCC.Affect.Service.AWEU00302G;

[TestClass]
public class AWEU00302G_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void InitTest()
    {
        var req = new InitRequest();
        req.rptid = 12;
        var res = _service.Init(req);
    }

    [TestMethod]
    public void SearchTest()
    {
        const int rptid = 12;
        var req1 = new InitRequest();
        req1.rptid = rptid;
        var conditions = _service.Init(req1).searchconditions;

        var req2 = new SearchRequest();
        req2.rptid = rptid;
        req2.conditions = conditions;
        var res = _service.Search(req2);
        var resJson = JsonConvert.SerializeObject(res);
    }
}*/