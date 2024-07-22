namespace BCC.Affect.Service.AWAF00601D
{
    [TestClass]
    public class AWAF00601D_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void InitTest()
        {
            InitRequest req = new()
            {
                userid = "jzy"
            };
            var res = service.Init(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "jzy",
                atenano = "800000000000001"
            };
            var res = service.Search(req);
        }

        [TestMethod]
        public void SaveTest()
        {
            var locklist = new List<LockVM>();
            for (int i = 1; i <= 10; i++)
            {
                locklist.Add(new LockVM
                {
                    memoseq = i,
                    upddttm = DateTime.Now
                });
            }

            //add
            var addList = new List<AddVM>();
            for (int i = 1;i <= 10;i++)
            {
                var addVm = new AddVM()
                {
                    jigyokbn = "1",
                    juyodo = "1",
                    title = $"test_add_{i}",
                    memo = $"test_add_{i}"
                };
                addList.Add(addVm);
            }

            //upd
            var updList = new List<UpdVM>();
/*            for (int i = 1; i <= 10; i++)
            {
                var updVm = new MemoVM()
                {

                };
                updList.Add(updVm);
            }*/


            var req = new SaveRequest();
            req.userid = "jzy";
            req.atenano = "100000000000005";
            
            req.locklist = locklist;
            req.addlist = addList;
            req.updlist = updList;
            var res = service.Save(req);
        }
    }
}