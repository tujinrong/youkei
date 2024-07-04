// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(帳票出力設定)バッチ処理
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using System.Data;

namespace BCC.Affect.BatchService.AWEU00303D
{
    [DisplayName("帳票出力(帳票出力設定)バッチ処理")]
    public class Service : BtServiceBase, IBtService
    {
        [DisplayName("帳票出力バッチ処理")]
        public void Execute(string? jobId, object? param = null, long? sessionseq = null, bool? nowFlg = false)
        {
            Transction(jobId, sessionseq, param, nowFlg, db =>
            {
                if (param is not ParameterModel pm) throw new ArgumentException("param is not ParameterModel.");
                var workseq = GetWorkSeqStr(db, pm);
                var result = DaEucService.MakeSheet(db, workseq, pm.rptid, pm.yosikiid, pm.reporttype, pm.searchdic, pm.detaildearchdic, pm.outputInfoDic, pm.orderbylist, pm.memo, pm.sessionseq,
                    pm.reguserid, pm.regsisyo, pm.hasupdatesql, pm.isblank, pm.hasconditionsheet, pm.hasupdhassorireki,true);
            });
        }

        /// <summary>
        /// ワークシーケンス取得
        /// </summary>
        private static string GetWorkSeqStr(DaDbContext db, ParameterModel pm)
        {
            if (pm.workseq > 0) return pm.workseq.Value.ToString();
            var token = Guid.NewGuid().ToString("N");
            var workSeq = DaEucService.GetWorkSeq(db, token);
            DaEucService.MakeWorkTable(db, token, pm.rptid, pm.yosikiid, pm.searchdic, pm.detaildearchdic, pm.orderbylist);

            //EUC帳票マスタを取得
            var dto = db.tm_eurpt.GetDtoByKey(pm.rptid);
            //帳票グループマスタを取得
            if (dto != null)
            {
                //差分更新 
                string sql = $@" 
                  UPDATE wk_euatena_sub SET formflg = false
                         WHERE atenano in (
                         select 
                          t1.atenano    as atenano     --宛名番号 
                        from wk_euatena_sub t1    
                        inner join tt_afatena t2 on t1.atenano = t2.atenano 
                        left join tt_kkrpthakkotaisyogaisya t3 on t1.atenano = t3.atenano 
                        and t3.rptgroupid  = '{dto.rptgroupid}'       
                        where t1.workseq = {workSeq}   
                        and (t2.siensotikbn <> '' or t3.taisyogairiyu <> '') 
                         ) and workseq = {workSeq} "
                          .Trim();

                var rptDtl = DaDbUtil.GetDataTable(db, sql);
            }
            return workSeq.ToString();
        }
    }
}