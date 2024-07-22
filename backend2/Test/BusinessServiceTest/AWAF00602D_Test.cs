using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00602D
{
    [TestClass]
    public class AWAF00602D_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "jzy",
                atenano = "00022222222"
            };
            var res = service.Search(req);
        }

        [TestMethod]
        public void DeleteTest()
        {
            List<LockVM> locklist = new List<LockVM>() 
            { 
                new LockVM()
                {
                    docseq= 1,
                    upddttm = DateTime.Now
                },
                new LockVM()
                {
                    docseq= 2,
                    upddttm = DateTime.Now
                }
            };
            DeleteRequest req = new()
            {
                userid = "jzy",
                atenano = "111",
                locklist = locklist
            };
            var res = service.Delete(req);
        }

        [TestMethod]
        public void SaveTest()
        {
            List<DaFileModel> files = new List<DaFileModel>()
            {
                new DaFileModel("111",".png",Array.Empty<byte>())
            };
            SaveRequest req = new()
            {
                userid = "jzy",
                atenano = "test",
                //filenm = "testfile",
                //jigyocd = "1",
                //title = "test_save",
                //regsisyo = "test",
                files = files
            };
            var res = service.Save(req);
        }

        [TestMethod]
        public void PreviewTest()
        {
            PreviewRequest req = new()
            {
                userid = "jzy",
                atenano = "111",
                docseq = 1
            };
            var res = service.Preview(req);
        }

        [TestMethod]
        public void DownloadTest()
        {
            List<int> seqs = new List<int>() { 1, 2 };
            DownloadRequest req = new()
            {
                userid = "jzy",
                docseqs = seqs,
                atenano = "111"
            };
            var res = service.Download(req);
        }
    }
}