using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWEU00205D;

[TestClass]
public class AWEU00205D_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void Init_Test()
    {
        var res = _service.Init(new DaRequestBase());
    }

    [TestMethod]
    public void InitMaster_Test()
    {
        var res = _service.InitMaster(new DaRequestBase());
    }

    [TestMethod]
    public void InitFormat_Test()
    {
        var res = _service.InitFormat(new DaRequestBase());
    }
}