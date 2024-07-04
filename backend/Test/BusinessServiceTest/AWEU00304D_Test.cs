using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00304D;

[TestClass]
public class AWEU00304D_Test
{
    private readonly Service _service = new();

    [TestMethod]
    public void SearchWarningsTest()
    {
        var jyokenlist = new List<KensakuJyokenVM>();
        //empty
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken1", value = null });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken2", value = string.Empty });
        //single value
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken3", value = "123" });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken4", value = 99 });
        //range value
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken5", value = new[] { 100, 200 } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken6", value = new[] { "111", "333" } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken7", value = new[] { 1000.23, 2333.98 } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken8", value = new[] { "2023-11-11", "2024-12-12" } });
        //multi value
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken9", value = new[] { 1, 2, 3, 4, 5, 88 } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken10", value = new[] { "1", "2", "3", "44" } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken11", value = new List<string> { "1", "2", "99" } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken12", value = new HashSet<double> { 1, 2, 3, 888 } });
        jyokenlist.Add(new KensakuJyokenVM { jyokenlabel = "jyoken13", value = new HashSet<byte> { 1, 3, 178, byte.MaxValue } });

        var req = new SearchWarningsRequest();
        req.rptid = "0001";
        req.token = "zwclJuo8jwmLoOoCAJlwRw==";
        req.userid = "1";
        req.workseq = null;
        req.jyokenlist = jyokenlist;
        var response = _service.SearchWarnings(req);
    }
}