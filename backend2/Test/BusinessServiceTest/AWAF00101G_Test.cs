using System.Security.Cryptography;
using System.Text;

namespace BCC.Affect.Service.AWAF00101G
{
    [TestClass]
    public class AWAF00101G_Test
    {
        private readonly Service service = new();

        [TestMethod]
        public void LoginTest()
        {
            const string pword = "1";
            var req = new LoginRequest();
            req.userid = "abcd123456";
            req.pword = Sha256($"{req.userid}{pword}");
            req.ip = "127.0.0.1";
            req.os = "windows";
            req.browser = "edge";

            var res = service.Login(req);
            Console.WriteLine(res);
        }

        private static string Sha256(string input)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToHexString(sha256.ComputeHash(Encoding.UTF8.GetBytes(input))).ToLower();
        }
    }
}