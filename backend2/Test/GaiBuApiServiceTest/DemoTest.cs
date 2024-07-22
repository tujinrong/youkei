using GaibuApiService.GaibuDemo.Config;
using GaibuApiService.GaibuDemo.Domain.Requests;
using GaibuApiService.GaibuDemo.Session.Default;

namespace GaiBuApiServiceTest;

[TestClass]
public class DemoTest
{
    [TestMethod]
    public void TestLoginApi()
    {
        var demoRequest = new DemoRequest {service = "AWAF00301G", methodname = "Init"};
        demoRequest.request = new RequestJson { data = "{\"kbn\":1}" };
        
        var configuration = new DemoConfiguration("1","jR7aaquoY9mu47xnCWivXQ==","3");
        var sessionFactory = new DefaultDemoSessionFactory(configuration);
        var session = sessionFactory.OpenSession();
        
        var demoResponse = session.TestWebRequest(demoRequest);
    }
}