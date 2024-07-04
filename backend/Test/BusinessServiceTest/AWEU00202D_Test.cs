using BCC.Affect.DataAccess;
namespace BCC.Affect.Service.AWEU00202D;

[TestClass]
public class AWEU00202D_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void OtherInit_Test()
    {
        var otherInitResponse = _service.InitOtherYosiki(new DaRequestBase());
    }
}