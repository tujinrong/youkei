using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH001
{
    [TestClass]
    public class AWSH00101G_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void SearchTest()
        {
            var searchVm1 = new SearchVM();
            searchVm1.jyokbn = Enum詳細検索条件区分.共通;
            searchVm1.jyoseq = 1;
            searchVm1.cdlist = new List<string> { "1", "10" };//ok

            var searchVm2 = new SearchVM();
            searchVm2.jyokbn = Enum詳細検索条件区分.共通;
            searchVm2.jyoseq = 14;
            var ageVm = new AgeVM();
            ageVm.basedate = new DateTime(2020, 2, 29);
            ageVm.man = "15-20,22-27,33";
            ageVm.woman = "18-22,26-28,40";
            ageVm.both = "55-59,61";
            ageVm.unknown = "70-72,80";
            searchVm2.agevm = ageVm;

            var searchVm3 = new SearchVM();
            searchVm3.jyokbn = Enum詳細検索条件区分.独自;
            searchVm3.jyoseq = 9;
            var itemVm1 = new AWAF00703D.ItemVM();
            itemVm1.value1 = "2020";
            itemVm1.value2 = "2022";
            searchVm3.itemvm = itemVm1; //ok

            var searchVm4 = new SearchVM();
            searchVm4.jyokbn = Enum詳細検索条件区分.独自;
            searchVm4.jyoseq = 12;
            var itemVm2 = new AWAF00703D.ItemVM();
            itemVm2.value1 = "1";
            searchVm4.itemvm = itemVm2;//ok

            var searchVm5 = new SearchVM();
            searchVm5.jyokbn = Enum詳細検索条件区分.独自;
            searchVm5.jyoseq = 7;
            var itemVm3 = new AWAF00703D.ItemVM();
            itemVm3.value1 = "2022-01-01";
            itemVm3.value2 = "2022-12-22";
            searchVm5.itemvm = itemVm3;//ok

            var searchVm6 = new SearchVM();
            searchVm6.jyokbn = Enum詳細検索条件区分.独自;
            searchVm6.jyoseq = 11;
            var itemVm4 = new AWAF00703D.ItemVM();
            itemVm4.value1 = "2022-08-01";
            searchVm6.itemvm = itemVm4;//ok

            var searchVm7 = new SearchVM();
            searchVm7.jyokbn = Enum詳細検索条件区分.独自;
            searchVm7.jyoseq = 14;
            var itemVm5 = new AWAF00703D.ItemVM();
            itemVm5.value1 = "0000-00-00";
            searchVm7.itemvm = itemVm5;//ok

            var searchVm8 = new SearchVM();
            searchVm8.jyokbn = Enum詳細検索条件区分.独自;
            searchVm8.jyoseq = 10;
            var itemVm6 = new AWAF00703D.ItemVM();
            itemVm6.yearflg = true;
            itemVm6.value1 = "0000-00-00";
            itemVm6.value2 = "0000-00-00";
            searchVm8.itemvm = itemVm6;

            var searchVm9 = new SearchVM();
            searchVm9.jyokbn = Enum詳細検索条件区分.共通;
            searchVm9.jyoseq = 14;
            var birthVm = new BirthVM();
            var man = new AWAF00703D.ItemVM();
            man.yearflg = true;
            // man.monthflg = true;
            man.dayflg = true;
            man.value1 = "2023-06-01";
            man.value2 = "2023-06-08";
            birthVm.man = man;

            var woman = new AWAF00703D.ItemVM();
            // woman.yearflg = true;
            woman.monthflg = true;
            // woman.dayflg = true;
            woman.value1 = "2015-06-01";
            woman.value2 = "2023-06-08";
            birthVm.woman = woman;

            var both = new AWAF00703D.ItemVM();
            // both.yearflg = true;
            both.monthflg = true;
            // both.dayflg = true;
            both.value1 = "2022-01-01";
            both.value2 = "2023-02-02";
            birthVm.both = both;

            var unknown = new AWAF00703D.ItemVM();
            // unknown.yearflg = true;
            unknown.monthflg = true;
            // unknown.dayflg = true;
            unknown.value1 = "2015-06-01";
            unknown.value2 = "2023-06-08";
            birthVm.unknown = unknown;
            searchVm9.birthvm = birthVm;

            var syosailist = new List<SearchVM>();
            syosailist.Add(searchVm1);
            // syosailist.Add(searchVm2);
            syosailist.Add(searchVm3);
            syosailist.Add(searchVm4);
            syosailist.Add(searchVm5);
            syosailist.Add(searchVm6);
            syosailist.Add(searchVm7);
            // syosailist.Add(searchVm8);
            syosailist.Add(searchVm9);

            SearchRequest req = new()
            {
                userid = "jzy",
                pagenum = 1,
                pagesize = 20,
                orderby = 0,
                //queryflg = false,

                //kinoid = "AWSH00101G",
                nendo = 2022,
                atenano = "",
                //personalno = "",
                name = "",
                kname = "",
                bymd = "",
                syosailist = syosailist
            };
            var res = _service.Search(req);
        }

        [TestMethod]
        public void InitTest()
        {
            InitDetailRequest req = new()
            {
                userid = "jzy",
                //kinoid = "AWSH00101G",
                atenano = "800000000000028",
                nendo = 2022
            };
            var res = _service.InitDetail(req);
        }

        //[TestMethod]
        //public void KijunTest()
        //{
        //    GetKijunRequest req = new()
        //    {
        //        userid = "jzy",
        //        kinoid = "AWSH00101G",
        //        atenano = "800000000000028",
        //        // atenano = "800000000000007",
        //        nendo = "2022",
        //        jissiymd1 = DateTime.Today,
        //        jissiymd2 = DateTime.Today,
        //        freeitemlist = new List<Common.FreeItemVM> {new(){groupid = EnumKensinKbn.一次,itemcd = "1"}}
        //    };
        //    var res = _service.GetKijun(req);
        //}
    }
}