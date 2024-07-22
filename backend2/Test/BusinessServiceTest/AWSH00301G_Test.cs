using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using NPOI.SS.Formula.Functions;

namespace BCC.Affect.Service.AWSH00301G
{
    [TestClass]
    public class AWSH00301G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////検索画面一覧テスト用
        //public void InitTest()
        //{
        //    var req = new DaRequestBase
        //    {
        //        userid = "11",                                          //ユーザーID
        //    };

        //    var res = _service.Init(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////検索画面一覧テスト用
        //public void SearchTest()
        //{
        //    var req = new SearchRequest
        //    {
        //        userid = "11",                                          //ユーザーID

        //        nendo = 2022,                                           //年度
        //    };

        //    var res = _service.Search(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //保存処理テスト用
        public void SaveTest()
        {
            var req = new SaveRequest
            {
                userid = "11",                              //ユーザーID
                nendo = 2022,                               //年度
            };

            var kekkalist = new List<RowVM>();
            var rowvm = new RowVM()
            {
                jigyocd = "00007",                          //成人健（検）診事業コード
                //yoyakuchk = "1",                          //予約画面チェック区分
                //kensinchk = "1",                          //健（検）診画面チェック区分
            };

            var rows = new List<HohoRowVM>();
            var hohoromvm = new HohoRowVM()
            {
                kensahohocd = "2",                          //検査方法コード
                sex = "1",                                  //性別コード
                age = "0-20,30,50",                         //年齢コード
                kijunkbn = "0",                             //年齢基準日区分コード
                kijunymd = "2024-04-01",                    //年齢計算基準日
                hokenkbn = "10",                            //保険区分コード
                tokusyu = "1",                              //特殊コード
                sql = "select atenano from tt_afatena t1 where t1.setaino='000000000800027'",            //SQL文
            };

            var locklist = new List<LockVM>();
            var lockvm = new LockVM()
            {
                jigyocd = "00007",                          //成人健（検）診事業コード
                kensahohocd = "2",                          //検査方法コード
                upddttm = CDate("2023/03/01 11:00:00"),     //更新日時
            };

            rows.Add(hohoromvm);
            rowvm.rows = rows;
            kekkalist.Add(rowvm);
            locklist.Add(lockvm);

            req.kekkalist = kekkalist;
            req.locklist = locklist;

            var res = _service.Save(req);

            var str = res.ToString();
        }
    }
}