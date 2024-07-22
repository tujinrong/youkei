using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWEU00301G;

[TestClass]
public class AWEU00301G_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void InitTest()
    {
        var res = _service.Init(new DaRequestBase());
    }

    [TestMethod]
    public void SearchTest()
    {
        var req = new SearchRequest();
        req.gyomukbn = "010";
        var res = _service.Search(req);
    }
}