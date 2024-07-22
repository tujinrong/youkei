/*namespace BCC.Affect.Service.AWEU00102D
{
    [TestClass]
    public class AWEU00102D_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void InitTest()
        {
            InitRequest req = new()
            {
                userid = "jzy",
            };
            var res = service.Init(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "jzy",
                tablenm = "temp_medical_examination"
            };
            var res = service.Search(req);
        }

        [TestMethod]
        public void SaveTest()
        {
            var itemnmlist = new List<string>();
            for (var i = 1; i <= 20; i++)
            {
                itemnmlist.Add($"test{i}");
            }
            SaveRequest req = new()
            {
                userid = "jzy",
                gyoumucd = "1",
                groupno = "01",
                groupnm = "test_group01",
                maintablenm = "temp_medical_examination",
                itemnmlist = itemnmlist
            };
            var res = service.Save(req);
        }
    }
}*/