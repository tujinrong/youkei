using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWKK00203G;
using NPOI.SS.Formula.Functions;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;

namespace BCC.Affect.Service.AWKK00203G
{
    [TestClass]
    public class AWKK00203G_Test
    {
        private readonly Service service = new();
 


              [TestMethod]
        public void Test()
        {
            //var editkbn = Enum編集区分.変更;
            //var upddttm = DateTime.Now.Date.AddDays(-1);
            //var mainInfo = new MainInfoVM()
            //{
            //    staffid = "0000000001",
            //    staffsimei = "鈴木葵",
            //    kanastaffsimei = "スズキアオイ",
            //    stopflg = false,
            //    syokusyu = "01",
            //    katudokbn = "1"
            //};

            //var jissijigyoSelectorList = new List<JissijigyoModel>
            //{
            //    new JissijigyoModel("2","乳がん検診",true),
            //    new JissijigyoModel("3","胃がん検診",false),
            //    new JissijigyoModel("5","肺がん検診",false),
            //    new JissijigyoModel("6","腹部エコー検診",false),
            //    new JissijigyoModel("8","子宮がん検診",false),
            //    new JissijigyoModel("9","肝炎検診",false)
            //};
            //var kikanlist = new List<string> { "0001" };

            //SaveDetailRequest req = new()
            //{
            //    editkbn = editkbn,
            //    upddttm = upddttm,
            //    mainInfo = mainInfo,
            //    kikanlist = kikanlist,
            //    jissijigyoSelectorList = jissijigyoSelectorList,
            //    userid = "1"
            //};

            //var res = service.Save(req);

            var req = new SearchDetailRequest
            {
                staffid = "0000000001"
            };

            var res = service.SearchDetail(req);
        }
    }
}
