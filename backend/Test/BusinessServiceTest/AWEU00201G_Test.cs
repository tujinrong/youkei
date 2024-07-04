using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWEU00201G
{
    [TestClass]
    public class AWEU00201G_Test
    {
        private readonly Service service = new();


        [TestMethod]
        public void ParseAndFormatSql_Test()
        {
            ParseAndFormatSqlRequest req = new()
            {
                sql = @"SELECT t1.regdttm                                                            as regdttm,   --登録日時
               t2.usernm                                                                             as regusernm, --ユーザー名
               t1.jyotaikbn                                                                          as jyotaikbn, --状態区分
               t1.syoridttmf                                                                         as syoridttmf,--処理日時（開始）
               t1.outputkbn                                                                          as outputkbn, --出力方式
               t1.num                                                                                as num,       --結果件数
               (SELECT STRING_AGG(concat(te.jyokenlabel, '=', te.value), '\n' ORDER BY te.jyokenseq)
                FROM tt_eurirekijyoken te
                WHERE te.rirekiseq = t1.rirekiseq)                                                   as jyoken,    --条件
               t1.memo                                                                               as memo,      --検索条件メモ
               t1.rirekiseq                                                                          as rirekiseq  --履歴シーケンス
        FROM tt_eurireki t1
                 LEFT JOIN tm_afuser t2 ON t1.reguserid = t2.userid
        where t1.rptid = @rptid
          and t1.yosikiid = @yosikiid"
            };
            var res = service.ParseAndFormatSql(req);
        }

        [TestMethod]
        public void InitFunctions_Test()
        {
            //var res = service.InitProcedure(new DaRequestBase());
        }
        
        [TestMethod]
        public void ParseAndFormatProcedure_Test()
        {
            //var functionRes = service.InitProcedure(new DaRequestBase());

            var req = new ParseAndFormatProcedureRequest()
            {
                //sql = functionRes.functionlist[0].src,
                //procedurenm = functionRes.functionlist[0].name
            };
            
            var res = service.ParseAndFormatProcedure(req);
        }
    }
}