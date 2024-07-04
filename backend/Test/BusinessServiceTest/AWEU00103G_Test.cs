/*namespace BCC.Affect.Service.AWEU00103G
{
    [TestClass]
    public class AWEU00103G_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void InitTest()
        {
            InitRequest req = new()
            {
                userid = "jzy",
                groupid = 5001
            };
            var res = service.Init(req);
        }

        [TestMethod]
        public void SaveTest()
        {
            InitRequest req = new()
            {
                userid = "jzy",
                groupid = 5001
            };
            var res1 = service.Init(req);

            SaveRequest req1 = new()
            {
                userid = "jzy",
                groupid = 5001,
                groupno = "99",
                groupnm = "xxx",
                gyoumu = "2 : xxx",
                upddttm = res1.group.upddttm
            };
            var res = service.Save(req1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            DeleteRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                upddttm = DateTime.Now
            };
            var res = service.Delete(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            CommonRequest req = new()
            {
                userid = "jzy",
                groupid = 5
            };
            var res = service.Search(req);
        }
    }
}*/