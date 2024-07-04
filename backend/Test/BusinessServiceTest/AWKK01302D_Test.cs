using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK01302D
{
    [TestClass]
    public class AWKK01302D_Test
    {
        private readonly Service _service = new();
       
        [TestMethod]
        public void InitTest()
        {
            //年度管理する
            InitRequest req = new()
            {
                kinoid = "AWKK01301G"
            };
            var res = _service.Init(req);
            //年度管理しない
            InitRequest req2 = new()
            {
                kinoid = "AWYS99999G"
            };
            var res2 = _service.Init(req2);
        }

        [TestMethod]
        public void CheckTest()
        {   
            //CheckRequest req = new()
            //{
            //    kinoid2 = "AWKK01301G",
            //    tyusyututaisyocd = "1999",
            //    atenano = "000000000900028",
            //    nendo = 2024,
            //    userid = "1"
            //};
            //var res = _service.Check(req);

            CheckRequest req2 = new()
            {
                kinoid = "AWKK01301G",
                tyusyututaisyocd = "1999",
                atenano = "800000000900028",
                nendo = 2024,
                userid = "1"
            };
            var res2 = _service.Check(req2);
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