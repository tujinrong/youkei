// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 警告内容・帳票発行対象外者設定
//             サービス処理
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00304D
{
    [DisplayName("警告内容・帳票発行対象外者設定")]
    public class Service : CmServiceBase
    {
        //検索処理
        private const string PROC_NAME = "sp_aweu00304g_01";

        [DisplayName("警告内容検索処理")]
        public SearchWarningsResponse SearchWarnings(SearchWarningsRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchWarningsResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUC帳票マスタ
                var rptDto = db.tm_eurpt.GetDtoByKey(req.rptid);
                //ワークシーケンス取得
                var workSeq = GetWorkSeq(db, req, ref res);
                if (res.returncode != EnumServiceResult.OK)
                {
                    return res;
                }

                //パラメータを取得
                var parameters = Converter.GetParameters(workSeq, rptDto);
                //検索実行
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定総ページ数、総件数
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //ワークシーケンス 
                res.workseq = workSeq;
                //DB項目から画面項目に変換
                res.kekkalist = Wraper.GetWarningList(db, pageList.dataTable.Rows, alertviewflg, req.workseq);

                //ワーク初期の場合
                if (req.workseq == null)
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
                        and t3.rptgroupid  = '{rptDto.rptgroupid}'       
                        where t1.workseq = {workSeq}   
                        and (t2.siensotikbn <> '' or t3.taisyogairiyu <> '') 
                         ) and workseq = {workSeq} "
                              .Trim();

                    var rptDtl = DaDbUtil.GetDataTable(db, sql);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("警告チェックの処理")]
        public DaResponseBase UpdateWarnCheckbox(UpdateWarnCheckboxRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();

                //宛名ワークテーブルサブ情報(警告内容)を取得
                wk_euatena_subDto dto = Converter.GetWarnDto(req);
                //宛名ワークテーブルサブを更新
                db.wk_euatena_sub.UPDATE.WHERE.ByKey(dto.workseq, dto.atenano).Execute(dto);

                //正常返し
                return res;
            });
        }

        [DisplayName("警告内容の選ぶの処理")]
        public DaResponseBase UpdateWarningDetails(UpdateWarningDetailsRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();

                if (req.warningContents.Count > 0)
                {
                    //キーリスト(編集前)
                    var keyList = req.warningContents.Select(k => new object[] { req.workseq, k.atenano }).ToList();

                    //宛名ワークテーブルサブ情報(警告内容)リストを取得
                    var dtl = Converter.GetWarningDetails(req);
                    //宛名ワークテーブルサブを更新
                    db.wk_euatena_sub.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl); //差分更新   
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// ワークシーケンス取得
        /// </summary>
        private static long GetWorkSeq(DaDbContext db, SearchWarningsRequest req, ref SearchWarningsResponse res)
        {
            if (req.workseq > 0)
            {
                return req.workseq.Value;
            }
            //ワークシーケンス取得
            var workSeq = DaEucService.GetWorkSeq(db, req.token);
            req.jyokenlist ??= new List<KensakuJyokenVM>();
            //検索情報
            var searchDic = CommonUtil.GetSearchDict(req.jyokenlist, req.tyusyutuinfo);
            //検索詳細情報
            var detailSearchDic = CommonUtil.GetDetailSearchDict(req.detailjyokenlist);
            //ソート順情報
            var orderByList = CommonUtil.GetOrderByList();
            //ワークテーブルを作成
            var ret = DaEucService.MakeWorkTable(db, req.token, req.rptid, req.yosikiid, searchDic, detailSearchDic, orderByList);
            if (ret < 1)
            {
                res.SetServiceAlert2(EnumMessage.A000008);
            }
            return workSeq;
        }
    }
}