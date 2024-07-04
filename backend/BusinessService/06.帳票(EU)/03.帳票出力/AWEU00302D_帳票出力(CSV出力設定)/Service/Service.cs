// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(CSV出力設定)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using AIplus.AiReport.Enums;
using AIplus.AiReport.Utils;
using BCC.Affect.Service.Common;
using System.Text.RegularExpressions;

namespace BCC.Affect.Service.AWEU00302D
{
    [DisplayName("帳票出力(CSV出力設定)")]
    public class Service : CmServiceBase
    {
        [DisplayName("CSV出力設定初期化処理")]
        public DetailInitResponse DetailInit(DetailInitRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new DetailInitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //CSV出力パターンテーブル
                var dtl = db.tt_eucsv.SELECT.WHERE.ByKey(req.rptid, req.yosikiid).ORDER.By(nameof(tt_eucsvDto.outputptnno)).GetDtoList();
                var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(csvdrop)
                res.csvdroplist = dtl.Select(x => new DaSelectorModel(x.outputptnno.ToString(), x.outputptnnm)).ToList();
                if (yosikiDto != null && yosikiDto.outputptnno != null)
                {
                    res.outputptnno = yosikiDto.outputptnno;
                }
                //正常返し
                return res;
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, db =>
            {
                byte[] data;
                var res = new CmDownloadResponseBase();

                if (!string.IsNullOrEmpty(req.outputfilenm))
                {
                    int index = req.outputfilenm.IndexOf('.');
                    //ドットの前の部分を取得し、それ以外の場合は文字列全体を返します。
                    req.outputfilenm = index >= 0 ? req.outputfilenm.Substring(0, index) : req.outputfilenm;
                }
                //CSVフォーマット情報
                var csvFmtDic = new Dictionary<string, object>
                    {
                        { DaEucService.CONDITION_OUTPUTHEADER, req.csvoutputheader },
                        { DaEucService.CONDITION_ENCODING, req.csvencoding },
                        { DaEucService.CONDITION_BOM, req.csvbom },
                        { DaEucService.CONDITION_QUOTATION, req.csvquotation! },
                        //ファイル名

                        {DaEucService.CONDITION_FILE_NM, req.outputfilenm}
            };

                //検索情報
                var searchDic = CommonUtil.GetSearchDict(req.jyokenlist, req.tyusyutuinfo);
                //検索詳細情報
                var detailSearchDic = CommonUtil.GetDetailSearchDict(req.detailjyokenlist);

                //選択した宛名番号
                var selectedatenanolist = new List<string>();

                //宛名番号対象ある場合
                //エクスポートするすべてのデータをクエリする
                var filter = $"{nameof(wk_euatena_subDto.workseq)} = @{nameof(wk_euatena_subDto.workseq)} and {nameof(wk_euatena_subDto.formflg)} = @{nameof(wk_euatena_subDto.formflg)}";
                var atenaDtl = db.wk_euatena_sub.SELECT.WHERE.ByFilter(filter, req.workseq, true).GetDtoList();
                if (atenaDtl.Count() > 0)
                {
                    //選択した宛名番号
                    selectedatenanolist = atenaDtl.Select(e => e.atenano).ToList();
                }

                //ソート順情報
                var orderByList = CommonUtil.GetOrderByList();

                //CSV出力
                var result = DaEucService.MakeCSV(db, req.workseq.ToString(), req.rptid, req.yosikiid, csvFmtDic, req.csvpattern, searchDic, detailSearchDic, orderByList, req.memo ?? string.Empty,
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

                data = ArFileUtil.GetBytes(result.FileString, req.csvencoding, req.csvbom);

                var fileSuffix = $"{DaStrPool.C_DOT}{EnumFileTypeKbn.csv}";
                var fileNameNoSuffix = Wraper.GetFileNameNoSuffix(req.outputfilenm, fileSuffix);

                if (!string.IsNullOrEmpty(req.csvpattern))
                {
                    //EUC様式マスタ取得
                    var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);
                    if (yosikiDto == null)
                    {
                        throw new AiExclusiveException();
                    }
                    //出力パターン番号
                    yosikiDto.outputptnno = int.Parse(req.csvpattern);
                    //EUC様式マスタ
                    db.tm_euyosiki.UpdateDto(yosikiDto, yosikiDto.upddttm);
                }
                
                //正常返し
                return CmDownloadService.GetDownloadResponse(new DaFileModel(fileNameNoSuffix, fileSuffix, data));
            });
        }
    }
}