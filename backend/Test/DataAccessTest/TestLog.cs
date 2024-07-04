using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using AIplus.AIF.DBLib;
using BCC.Affect.DataAccess;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.ComponentModel;
using System.Reflection;

namespace TestAILIB60.BCC.Affect.Service.AWSH00101G
{

    [TestClass]
    [DisplayName("テストService")]
    public class TestLog
    {
        private DaDbContext db = new DaDbContext();


        [TestMethod]
        [DisplayName("テストMethod")]
        public void TestMethodName()
        {
            MethodBase method = new StackTrace().GetFrame(0)!.GetMethod()!;
            var pid = DaUtil.GetKinoid(method);
            var mname = DaUtil.GetMethodDesc(method);
            var sname = DaUtil.GetServiceDesc(method);
        }


        [TestMethod]
        [DisplayName("テスト")]
        public void Test1()
        {
            DaRequestBase r = new DaRequestBase();
            r.userid = "userid";
            var seq= DaDbLogService.WriteMainLog(r);
            r.sessionid = seq;

            DaResponseBase res = new DaResponseBase();
            //DaDbLogService.UpdateLogx("serice", "method", DateTime.Now, r, res, "ip", "os", "browser");
        }

        /// <summary>
        /// バッチ処理のログ
        /// </summary>
        [TestMethod]
        public void TestBatchLog()
        {
            //初期処理
            db.Session.UserID = "test";
            DaDbLogService.WriteMainLog(db, "TestAILIB60", "TestLog", "TestBatchLog", "テスト");
            var batchList = new List<tt_afbatchlogDto>();
            var personList = new List<tt_aflogatenaDto>();
            DaDbLogService.AddBatchLog(batchList, "処理開始");

            //データ処理
            DaDbLogService.AddAtenaLog(personList, "12345", EnumAtenaActionType.検索);
            DaDbLogService.AddAtenaLog(personList, "12345", EnumAtenaActionType.検索, true, "個人番号を参照しました");
            DaDbLogService.AddAtenaLog(personList, "12345", EnumAtenaActionType.更新, false);

            DaDbLogService.WriteDbMessage(db, "テストです");
            //処理終了
            DaDbLogService.AddBatchLog(batchList, "処理終了");

            //バッチへ書き込み
            DaDbLogService.WriteAtenaLog(db, personList);
            DaDbLogService.WriteBatchLog(db, batchList);

            //処理結果
            DaDbLogService.UpdateMainLog(db, EnumLogStatus.要確認);
        }

        [TestMethod]
        public void Test2()
        {
            var bizReq = new DaRequestBase();
            var r = SetSession<DaRequestBase>(bizReq);

            //サービス実行
            //DaResponseBase res = (DaResponseBase)method.Invoke(service, new object[] { bizReq })!;

            //ログを記録
            DaResponseBase res = new DaResponseBase();
            using var db = new DaDbContext(r);
            DaDbLogService.UpdateMainLog(db, EnumLogStatus.正常終了);
            DaDbLogService.WriteTusinLog(db, r, (DaResponseBase)res!, "");
        }

        private REQ SetSession<REQ>(object req) where REQ : DaRequestBase, new()
        {
            REQ r = new REQ();
            try
            {
                if (req != null)
                {
                    r = (REQ)req;
                    r.ip = "ip";
                    r.os = "windows";
                    r.browser = "Browser";
                }
            }
            catch { }
            finally
            {
                r.sessionid = DaDbLogService.WriteMainLog(r);
            }
            return r;
        }
    }
}