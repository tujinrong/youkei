// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 一時対象サインデータ作成
//             サービス処理
// 作成日　　: 2024.02.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.BatchService.SYSTEM
{
    [DisplayName("スケジュール更新")]
    public class Service : BtServiceBase, IBtService
    {
        [DisplayName("スケジュール更新")]
        public void Execute(string? jobId, object? param = null, long? sessionseq = null, bool? nowFlg = false)
        {
            Transction(jobId, sessionseq, param, nowFlg, (db) =>
            {
                BtJobService.UpdateHolidaySchedule(db);
                
                var sql = "INSERT INTO tc_kklog(syoriymd,info1) values(now()," + "'SystemJob'" + ")";
                db.Session.Execute(sql);
            });
        }
    }
}