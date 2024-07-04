using BCC.Affect.DataAccess;
using System.Data;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;
namespace BCC.Affect.Service.testryu
{
    [TestClass]
    public class testryu
    {
        [TestMethod]
        public void tst()
        {
            string s = "@ # $ % ^ & * - _ ! + = [ ] { } |  : ' , . ? / ` ~ \" ( ) ;";
            var symbolArray = s.Replace(" ", "").Split();
            var list = s.Replace(" ", "").ToCharArray();
            var symbolregex = $"\\{string.Join("\\", list)}";
            var b = s.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            bool flg = new bool();
            string expression = "2 * (3 + 4)";
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);

        }
        [TestMethod]
        public void tst2()
        {
            var s1 = "2000-02-29";
            var s2 = "2023-03-01";
            var bymd = CDate(s1);
            var kijunymd = CDate(s2);
            var time = DateTime.MinValue + (kijunymd - bymd);
            var time2 = kijunymd - bymd;
            int years = kijunymd.Year - bymd.Year;
            int months = kijunymd.Month - bymd.Month;
            int days = kijunymd.Day - bymd.Day;
            if (days < 0)
            {
                months -= 1;
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
            var s3 = $"{time.Year - 1}歳{time.Month - 1}か月";
            var s4 = $"{years}歳{months}か月";
            var key = "naiyo_123_123";
            var keycd = $"{key}".Replace(nameof(KensinyoyakuView3.naiyo), string.Empty);
            var keycd2 = key.Replace(nameof(KensinyoyakuView3.naiyo), string.Empty);

            var hyojinm = $"{DaStrPool.BRACKET_START}{CmLogicUtil.GetKakuYoyakuSidoGyomukbn("01").ToString().Substring(0, 2)}{DaStrPool.BRACKET_END}実施日";

            List<string> numbers = new List<string> { "5", "2", "8", "1", "7" };

            numbers.Sort();
            var str = "AWSH00101G";
            var ssss = str.Substring(7, 2);
            var orderseq = 0;
            for (var i = 1; i < 100; i++)
            {
                var m = -1;
                m = orderseq++;          //並びシーケンス
            }
            var list2 = new List<bool>();
            list2.Add(true);
            list2.Add(false);
            list2.Add(true);
            var list3 = list2.OrderBy(e => e).ToList();
            var d = FormatWaKjDttm2(DateTime.Now);                                              //更新日時
            var obj = new object[] { "keisyoflg", "継承フラグ", "tm_afgamen" };
            var list = new List<object[]>();
            list.Add(obj);
            list.Add(obj);
            list.Add(obj);
            list.Add(obj);
            list.Add(obj);
            var vm = list.Select(e => new DaSelectorKeyModel(e[0].ToString(), null, e[2].ToString())).DistinctBy(e => new { e.key, e.value }).OrderBy(e => e.key).ThenBy(e => e.value).ToList();
        }
    }
}