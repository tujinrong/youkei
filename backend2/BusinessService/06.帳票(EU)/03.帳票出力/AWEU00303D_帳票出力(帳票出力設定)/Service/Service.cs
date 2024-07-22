// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(帳票出力設定)
//             サービス処理
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using System.Text;
using AIplus.AiReport.Enums;
using BCC.Affect.BatchService;
using BCC.Affect.Service.AWEU00301G;
using BCC.Affect.Service.Common;
using Hangfire;

namespace BCC.Affect.Service.AWEU00303D
{
    [DisplayName("帳票出力(帳票出力設定)")]
    public class Service : CmServiceBase
    {
        private static readonly BatchService.AWEU00303D.Service BATCH_SERVICE = new();

        [DisplayName("プレビュー処理")]
        public ReportPreviewResponse Preview(PreviewRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new ReportPreviewResponse();

                //検索情報
                var searchDic = CommonUtil.GetSearchDict(req.jyokenlist, req.tyusyutuinfo);
                //検索詳細情報
                var detailSearchDic = CommonUtil.GetDetailSearchDict(req.detailjyokenlist);

                //ソート順情報
                var orderByList = CommonUtil.GetOrderByList();

                //出力情報
                var outputInfoDic = CommonUtil.GetOutPutInfo(req.outPutInfo, req.outputfilenm);

                //帳票出力
                var result = DaEucService.MakeSheet(db, req.workseq.ToString(), req.rptid, req.yosikiid, PreviewRequest.outputtype, searchDic, detailSearchDic, outputInfoDic, orderByList, req.memo ?? string.Empty,
                    req.sessionid.ToString(), req.userid, req.regsisyo, false, req.hakusiflg, req.jyokensheetflg, req.rirekiupdflg);

                if (!result.Success)
                {
                    if (result.Error == ArEnumError.NoData)
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.A000008);
                        res.SetServiceAlert2(msg);
                        return res;
                    }
                    else
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E004007, "プレビュー処理");
                        res.SetServiceError(msg);
                        return res;
                    }
                }

                //todo total
                res.totalpagecount = result.PagingCount;
                //データ
                res.data = result.FileData ?? Encoding.UTF8.GetBytes(result.FileString);
                //ファイル名
                res.filenm = Wraper.GetPreviewFileName(req.outputfilenm);
                //コンテンツタイプ
                res.contenttype = CmFileUtil.GetMapping(EnumFileTypeKbn.pdf.ToString());

                //正常返し
                return res;
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new CmDownloadResponseBase();

                //ワークシーケンス取得
                var workSeq = req.workseq <= 0 ? DaEucService.GetWorkSeq(db, req.token).ToString() : req.workseq.ToString();
                //検索情報
                var searchDic = CommonUtil.GetSearchDict(req.jyokenlist, req.tyusyutuinfo);
                //検索詳細情報
                var detailSearchDic = CommonUtil.GetDetailSearchDict(req.detailjyokenlist);

                //ソート順情報
                var orderByList = CommonUtil.GetOrderByList();

                //出力情報
                var outputInfoDic = CommonUtil.GetOutPutInfo(req.outPutInfo, req.outputfilenm);

                //帳票出力
                var result = DaEucService.MakeSheet(db, workSeq, req.rptid, req.yosikiid, req.outputtype, searchDic, detailSearchDic, outputInfoDic, orderByList, req.memo ?? string.Empty,
                    req.sessionid.ToString(), req.userid, req.regsisyo, req.sqljikkoflg, req.hakusiflg, req.jyokensheetflg, req.rirekiupdflg);

                if (!result.Success)
                {
                    if (result.Error == ArEnumError.NoData)
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.A000008);
                        res.SetServiceAlert2(msg);
                        return res;
                    }
                    else
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E004007, "ダウンロード処理");
                        if (!string.IsNullOrEmpty(result.Message))
                        {
                            msg = result.Message;
                        }
                        res.SetServiceError(msg);
                        return res;
                    }
                }

                // ダウンロード処理が完了しました。
                res.message = DaMessageService.GetMsg(EnumMessage.DOWNLOAD_OK_INFO);
                //データ
                var data = result.FileData ?? Encoding.UTF8.GetBytes(result.FileString);
                //ファイル名
                var fileSuffix = Wraper.GetFileSuffixByOutputType(req.outputtype);
                //コンテンツタイプ
                var fileNameNoSuffix = Wraper.GetFileNameNoSuffix(req.outputfilenm, fileSuffix);

                //正常返し
                return CmDownloadService.GetDownloadResponse(new DaFileModel(fileNameNoSuffix, fileSuffix, data));
            });
        }

        [DisplayName("バッチ処理")]
        public DaResponseBase AddBatchJob(BatchRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();

                var jpExecutionTime = BtUtil.GetJapanTime(req.executiontime);

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (req.checkflg)
                {
                    if (jpExecutionTime.Date != DaUtil.Today)
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E064009);
                        res.SetServiceError(msg);
                        return res;
                    }
                    return res;
                }               

                var nowFlg = DaUtil.Now >= jpExecutionTime;
                jpExecutionTime = nowFlg ? DaUtil.Now : jpExecutionTime;
                var dateTimeOffsetInTokyo = new DateTimeOffset(jpExecutionTime, DaConst.TOKYO_TIME_ZONE_INFO.GetUtcOffset(jpExecutionTime));
                //TaskIdを作成する
                var nextTaskId = BtJobService.GetNewTaskId(db);
                var parameterModel = Wraper.GetBatchParameter(req, nowFlg);
                var hangfireJobId = BackgroundJob.Schedule(() => BATCH_SERVICE.Execute(nextTaskId, parameterModel, req.sessionid, nowFlg), dateTimeOffsetInTokyo);

                //タスクスケジュールマスタ情報を取得
                var scheduleDto = Converter.GetTaskScheduleDto(nextTaskId, hangfireJobId, jpExecutionTime);
                //タスクスケジュールマスタを登録
                db.tm_aftaskschedule.INSERT.Execute(scheduleDto);

                //正常返し
                return res;
            });
        }
    }
}