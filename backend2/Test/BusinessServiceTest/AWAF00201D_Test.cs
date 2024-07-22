using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00201D
{
    [TestClass]
    public class AWAF00201D_Test
    {
        private readonly Service service = new();

        [TestMethod]
        public void PwdUpdateTest()
        {
            SaveRequest req = new SaveRequest()
            {
                userid = "jzy",
                oldpword = "5a656b10d2dec100254fc5892f3e972a",
                newpword = "5a656b10d2dec100254fc5892f3e972a",
                //user_pwd_new_check = "abcd1234!",
            };
            var res = service.Save(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void GetCheckInfoTest()
        {
            DaRequestBase req = new DaRequestBase();
            //var res = service.Init(req);
            //Console.WriteLine(res);
        }
    }
}
