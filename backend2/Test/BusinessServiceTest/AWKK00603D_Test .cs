using BCC.Affect.DataAccess;
using NPOI.SS.Formula.Functions;
using System.Data;

namespace BCC.Affect.Service.AWKK00603D
{
    [TestClass]
    public class AWKK00603D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitListTest()
        {
            var req = new InitRequest();
            req.mappingkbn = "1";          //マッピング区分（【マッピング方法ド】ロップダウン初期化時用）
            List<string> fileitemList = new List<string>();  //取込ファイルIF情報の（ファイル項目ID,項目名）のリスト
            fileitemList.Add("1,n1");
            req.fileitemList = fileitemList;
            req.editkbn = Enum編集区分.変更;       //編集区分
            var res = _service.InitDetail(req);
        }
    }
}