namespace BCC.Affect.Service.AWEU00306D;

[TestClass]
public class AWEU00306D_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void Init_Test()
    {
        var request = new InitRequest();
        request.rptid = "0001";
        request.yosikiid = "0001";
        var response = _service.Init(request);
    }
    
    [TestMethod]
    public void Search_Test()
    {
        var request = new SearchRequest();
        request.rptid = "0001";
        request.yosikiid = "0001";
        request.sortptnno = "1";
        var response = _service.Search(request);
    }
}