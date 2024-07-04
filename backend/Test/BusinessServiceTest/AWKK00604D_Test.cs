using BCC.Affect.DataAccess;
using NPOI.SS.Formula.Functions;
using System.Data;

namespace BCC.Affect.Service.AWKK00604D
{
    [TestClass]
    public class AWKK00604D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitListTest()
        {
            var req = new InitRequest();
            req.pageitemseq = 1;     //画面項目ID
            req.gyoumukbn = "1";    //業務区分
            req.impno = "2";           //一括取込入力No
            req.inputkbn="1";     //入力区分
            req.inputtype = "1";    //入力方法
            req.msttable = "1";     //マスタチェックテーブル
        List<string> pageitemList = new List<string>();  //画面項目情報の(画面項目ID,項目名)のリスト
            pageitemList.Add("1,n1");
            req.pageitemList = pageitemList;
            req.editkbn = Enum編集区分.変更;       //編集区分
            var res = _service.InitDetail(req);
        }
    }
}