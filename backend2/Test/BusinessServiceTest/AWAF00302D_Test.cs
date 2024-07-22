namespace BCC.Affect.Service.AWAF00302D
{
    [TestClass]
    public class AWAF00302D_Test
    {
        private readonly Service service = new();

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new();
            req.userid = "mcc";
            req.showkbn = Enum表示区分.すべて;
            //req.showkbn = Enumお知らせ区分.期限内;
            req.pagesize = 15;
            req.pagenum = 1;
            var res = service.Search(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void SaveTest()
        {
            //初期シーケンス番号の定義
            var keys = new List<long>();
            for (int i = 300; i <= 310; i++)
            {
                keys.Add(i);
            }

            //追加する必要があるデータを定義する
            List<InfoVM> insertList = new List<InfoVM>();
            for (int i = 1; i <= 100; i++)
            {
                InfoVM info = new InfoVM()
                {
                    //title = "insert_data_title" + i,
                    juyodo = "02",
                    kigenymd = DateTime.Today.AddDays(i),
                    syosai = "insert_data_syosai_" + i
                };
                insertList.Add(info);
            }

            //更新が必要なデータを定義し、infoseq が初期コレクションにないデータは削除されます
            List<UpdVM> updateList = new List<UpdVM>();
            for (int i = 300; i <= 305; i++)
            {
                UpdVM info = new()
                {
                    infoseq = i,
                    //title = "update_data_title" + i,
                    juyodo = "03",
                    kigenymd = DateTime.Today.AddDays(i),
                    syosai = "update_data_syosai_" + i,
                    readflg = true
                };
                updateList.Add(info);
            }

            SaveRequest req = new();
            req.userid = "jzy";
            //req.lockList = keys;
            req.addlist = insertList;
            req.updlist = updateList;
            var res = service.Save(req);
            Console.WriteLine(res);
        }
    }
}