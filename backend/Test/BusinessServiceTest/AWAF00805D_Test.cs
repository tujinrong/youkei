
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using NPOI.SS.Formula.Functions;

namespace BCC.Affect.Service.AWAF00805D
{
    [TestClass]
    public class AWAF00804G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////初期化処理テスト用
        //public void InitTest()
        //{
        //    var req = new InitRequest
        //    {
        //        userid = "11",                                          //ユーザーID
        //        cd = "AWKK00301G-1",
        //    };

        //    var res = _service.Init(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //保存処理テスト用
        public void SaveTest()
        {
            var req = new SaveRequest
            {
                userid = "11",                                          //ユーザーID
                cd = "AWKK00301G-1",
                upddttm1 = CNDate("2023/03/01 11:00:00"),
            };

            var cdnmlist2 = new List<string>()
            {
                "5","6","7",
            };

            var cdnmlist3 = new List<string>()
            {
                "5","7","8",
            };

            var cdnmlist4 = new List<string>()
            {
                "5","8","9",
            };

            var detailinfo = new SaveVM()
            {
                cdnm1 = "5",
                cdnmlist2 = cdnmlist2,
                cdnmlist3 = cdnmlist3,
                cdnmlist4 = cdnmlist4,
                flg1 = false,
                flg2 = true,
                flg3 = true,
                flg4 = true,
            };
            req.detailinfo = detailinfo;

            var res = _service.Save(req);

            var str = res.ToString();
        }
    }
}