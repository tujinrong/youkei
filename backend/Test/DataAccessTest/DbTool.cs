using AIplus.AIF.DBLib;
using BCC.Affect.DataAccess;
using Npgsql;
using System.Data;
using System.Diagnostics;
using System.Transactions;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;

namespace TestAILIB60.TestAILIB60
{

    [TestClass]
    public class DbTool
    {
        private DaDbContext db = new DaDbContext();
        /// <summary>
        /// 追加、削除サンプル
        /// </summary>
        [TestMethod]
        public void RefreshFunction()
        {
            var info = AiGlobal.DbInfoProvider.GetProcParameterList(db.Session, "euc_0023_00013");

            Console.WriteLine(info);
        }

    }
}