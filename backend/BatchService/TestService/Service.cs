// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 一時対象サインデータ作成
//             サービス処理
// 作成日　　: 2024.02.07
// 作成者　　: 唐
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.BatchService.ABSH00102G
{
    [DisplayName("一時対象サインデータ作成TEST")]
    public class Service : BtServiceBase, IBtService
    {
        //[DisplayName("一時対象サインデータ作成TEST")]
        public void Execute(string? jobId, object? param = null, long? sessionseq = null, bool? nowFlg = false)
        {
            Transction(jobId, sessionseq, param, nowFlg, (db) =>
            {
                //using var db = new DaDbContext();
                //AiDbUtil.OpenConnection(db.Session.Connection!);

                var sql = "INSERT INTO tc_kklog(syoriymd,info1) values(now()," + "'ABSH00102G'" + ")";
                db.Session.Execute(sql);
            });
        }
    }
}