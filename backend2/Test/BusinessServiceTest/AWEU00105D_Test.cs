/*using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWEU00105D
{
    [TestClass]
    public class AWEU00105D_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void InitTest()
        {
            CommonRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                tableid = "T1"
            };
            var res = service.Init(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            CommonRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                tableid = "T"
            };
            var res = service.Search(req);
        }

        [TestMethod]
        public void InitItemTest()
        {
            CommonRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                tableid = "T"
            };
            var res = service.InitItem(req);
        }

        [TestMethod]
        public void AddItemTest()
        {
            var item = new AWEU00103G.GroupTableItemVM();
            item.itemid = "T_35";
            item.itemmeisyo = "exam_date";
            item.burui1 = string.Empty;
            item.burui2 = string.Empty;
            item.burui3 = string.Empty;
            item.itemryasyo = "実施日";
            item.sql = string.Empty;
            item.datatype = DaConvertUtil.EnumToStr(DataAccess.Enumデータタイプ.年月日);
            item.syukekbn = DaConvertUtil.EnumToStr(DataAccess.Enum集計区分.一覧項目);
            item.syukekcd = null;
            AddItemRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                grouptableitem = item
            };
            var res = service.AddItem(req);
        }

        [TestMethod]
        public void UpdItemTest()
        {
            CommonRequest req1 = new()
            {
                userid = "jzy",
                groupid = 5001,
                tableid = "T"
            };
            var vms = service.Search(req1);
            var d = vms.groupitems.Find(v => v.itemid == "T_35");

            var item = new AWEU00103G.GroupTableItemVM();
            item.itemid = "T_35";
            item.itemmeisyo = "exam_date";
            item.burui1 = string.Empty;
            item.burui2 = string.Empty;
            item.burui3 = string.Empty;
            item.itemryasyo = "実施日";
            item.sql = string.Empty;
            item.datatype = DaConvertUtil.EnumToStr(DataAccess.Enumデータタイプ.年月日);
            item.syukekbn = DaConvertUtil.EnumToStr(DataAccess.Enum集計区分.一覧項目);
            item.syukekcd = null;
            item.upddttm = d.upddttm;
            UpdateItemRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                grouptableitem = item
            };
            var res = service.UpdItem(req);
        }

        [TestMethod]
        public void DelItemTest()
        {
            CommonRequest req1 = new()
            {
                userid = "jzy",
                groupid = 5001,
                tableid = "T"
            };
            var vms = service.Search(req1);
            var d = vms.groupitems.Find(v => v.itemid == "T_35");
            DelItemRequest req = new()
            {
                userid = "jzy",
                groupid = 5001,
                itemid = "T_35",
                upddttm = d.upddttm,
                //upddttm = DateTime.Now,
            };
            var res = service.DelItem(req);
        }
    }
}*/