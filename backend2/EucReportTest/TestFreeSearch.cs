using AIplus.AiReport.ReportDef;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using AIplus.FreeQuery;
using BCC.Affect.DataAccess;


using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EucReportTest
{
    [TestClass]
    public class TestFreeSearch
    {
        const string JIGYO_KENSIN = "090";
        [TestMethod]
        public void Test1()
        {
            using DaDbContext db = new DaDbContext();
            //int sqlCount = 1;
            var items = new List<FrSelectItem>();
            //**氏名 
            items.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei)));
            //**生年月日
            items.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.simei)));
            //**性別
            items.Add(new FrSelectItem(tt_afatenaDto.TABLE_NAME, nameof(tt_afatenaDto.sex)));
            //**年度										
            items.Add(new FrSelectItem(KensinView.TABLE_NAME, KensinView.nendo));
            //**実施日
            items.Add(new FrSelectItem(KensinView.TABLE_NAME, KensinView.jissiymd1));
            //**受診番号 
            //items.Add(new FrSelectItem(tt_shfreeDto.TABLE_NAME, nameof(tt_shfreeDto.strvalue), 0, "1000"));

            //Where条件
            var conditon = new FrCondition();
            conditon.PageNo = 0;
            conditon.PageRowCount = 10;
            conditon.ConditionModel = new FrConditionModel(KensinView.TABLE_NAME, nameof(KensinView.nendo), "2022").
                And(KensinView.TABLE_NAME, nameof(KensinView.nendo), "2022").
                AndSub(KensinView.TABLE_NAME, nameof(KensinView.nendo), FrEnumValueOprator.NE, "2021").
                    Or(KensinView.TABLE_NAME, nameof(KensinView.nendo), "2022").Or(KensinView.TABLE_NAME, nameof(KensinView.nendo), "2023").
                EndSub();

            //並び替えの設定
            var defaultOrderList = new List<FrOrderItem>()
            {
                new FrOrderItem(tt_afatenaDto.TABLE_NAME,nameof(tt_afatenaDto.simei), FrEnumOrder.ASC)
            };

            //成人保健フリー項目テーブル
            var freeItemList = DaFreeItemService.GetKensinList(db, JIGYO_KENSIN);

            ////結果の取得
            //var result = DaFreeQuery.GetKensinQuery(db.Session, JIGYO_KENSIN, items, conditon, defaultOrderList, 0, false, freeItemList);
            //if (result.Count < 1000)
            //{
            //    result = DaFreeQuery.GetKensinQuery(db.Session, JIGYO_KENSIN, items, conditon, defaultOrderList, 0, true, freeItemList);
            //}
        }
    }
}