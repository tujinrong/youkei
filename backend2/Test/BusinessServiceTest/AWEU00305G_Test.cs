namespace BCC.Affect.Service.AWEU00305D;

[TestClass]
public class AWEU00305G_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void SearchTest()
    {
        var req = new SearchRequest();
        req.rptid = "0001";
        req.yosikiid = "0001";

        //var res = _service.Search(req);
    }
}