using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00801G
{
    [TestClass]
    public class AWAF00801G_Test
    {

        private readonly Service service = new();

        //[TestMethod]
        //public void InitSubCodeInfo()
        //{
        //    SearchRequest req = new()
        //    {
        //        userid = "jzy"
        //    };
        //    var res = service.InitSubCodeInfo(req);
        //}

        //[TestMethod]
        //public void SaveSubCodeInfo()
        //{
        //    SaveSubCodeInfoRequest req = new()
        //    {
        //        userid = "jzy",
        //        editkbn= Enum編集区分.変更

        //    };

        //    req.subcdInfoVM = new SubCodeInfoVM();
        //    req.subcdInfoVM.hanyomaincd = "1002";
        //    req.subcdInfoVM.hanyosubcd = 6;
        //    req.subcdInfoVM.hanyosubcdnm = "1002-6";
        //    req.subcdInfoVM.userryoikikaisicd = 90000;
        //    req.subcdInfoVM.keta = 5;

        //    var res = service.SaveSubCodeInfo(req);
        //}

        //[TestMethod]
        //public void SearchMainCdTest()
        //{
        //    InitMainCodeRequest req = new()
        //    {
        //        userid = "jzy"
        //    };
        //    var res = service.InitMainCode(req);
        //}

        //[TestMethod]
        //public void SearchSubCdTest()
        //{
        //    InitSubCodeRequest req = new()
        //    {
        //        userid = "jzy",
        //        hanyomaincd = "2019"
        //    };
        //    var res = service.InitSubCode(req);
        //}

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "jzy",
                hanyomaincd = "1002",
                hanyosubcd = "6"
            };
            var res = service.Search(req);
        }

        //[TestMethod]
        //public void SaveTest()
        //{
        //    SaveRequest req = new();
        //    req.userid = "jzy";
        //    req.hanyomaincd = "2019 : xxx";
        //    req.hanyosubcd = "1 : xxx";
        //    req.locklist = new List<LockVM>();
        //    req.savelist = new List<HanyoVM>();
        //    for (int i = 1; i <= 20; i++)
        //    {
        //        var c = new LockVM();
        //        c.hanyocd = i.ToString();
        //        c.upddttm = DaUtil.Now;
        //        req.locklist.Add(c);
        //    }
        //    //add
        //    for (int i = 21; i <= 30; i++)
        //    {
        //        var vm = new HanyoVM();
        //        vm.hanyocd = i.ToString();
        //        vm.nm = i.ToString();
        //        vm.kananm = i.ToString();
        //        vm.shortnm = i.ToString();
        //        vm.biko = i.ToString();
        //        vm.hanyokbn1 = i.ToString();
        //        vm.hanyokbn2 = i.ToString();
        //        vm.hanyokbn3 = i.ToString();
        //        req.savelist.Add(vm);
        //    }

        //    //upd
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        var vm = new HanyoVM();
        //        vm.hanyocd = i.ToString();
        //        vm.nm = $"My_Test{i}";
        //        vm.kananm = i.ToString();
        //        vm.shortnm = i.ToString();
        //        vm.biko = i.ToString();
        //        vm.hanyokbn1 = i.ToString();
        //        vm.hanyokbn2 = i.ToString();
        //        vm.hanyokbn3 = i.ToString();
        //        //vm.upddttm = DaUtil.Now;
        //        req.savelist.Add(vm);
        //    }
        //    var res = service.Save(req);
        //}
    }
}