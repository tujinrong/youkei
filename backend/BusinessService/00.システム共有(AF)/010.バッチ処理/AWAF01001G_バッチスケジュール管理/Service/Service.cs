// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチスケジュール管理
// 　　　　　　サービス処理
// 作成日　　: 2024.02.06
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.BatchService;
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Ocsp;
using System;
using System.Threading.Tasks;

namespace BCC.Affect.Service.AWAF01001G
{
    [DisplayName("バッチスケジュール管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF01001G = "AWAF01001G";
        private const string PROC_NAME01 = "sp_awaf01001g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(処理区分)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.連携処理区分, Enum名称区分.名称);

                //ドロップダウンリスト(業務区分)
                res.selectorlist2 = DaNameService.GetSelectorList(db, EnumNmKbn.システム業務区分, Enum名称区分.名称);

                //ドロップダウンリスト(タスクID)
                res.selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.タスクスケジュール情報マスタ);

                //ドロップダウンリスト(処理結果)
                res.selectorlist4 = DaNameService.GetSelectorList(db, EnumNmKbn.処理結果コード, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME01, parameters, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //タスクスケジュール情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();

                //画面項目初期化
                //業務区分
                res.gyomukbnnmList = DaNameService.GetSelectorList(db, EnumNmKbn.システム業務区分, Enum名称区分.名称);
                //処理区分
                res.syorikbnnmList = DaNameService.GetSelectorList(db, EnumNmKbn.連携処理区分, Enum名称区分.名称);
                //モジュール	
                res.modulenmList = DaNameService.GetSelectorList(db, EnumNmKbn.モジュール, Enum名称区分.名称);
                //毎月の月
                res.tukinmList = DaNameService.GetSelectorList(db, EnumNmKbn.月, Enum名称区分.名称);
                //毎月の日(コード：名称)
                res.nichinmList = DaNameService.GetSelectorList(db, EnumNmKbn.日, Enum名称区分.名称);
                //毎月の週(コード：名称)
                res.syunmList = DaNameService.GetSelectorList(db, EnumNmKbn.週目, Enum名称区分.名称);
                //曜日(コード：名称)
                res.yobinmList = DaNameService.GetSelectorList(db, EnumNmKbn.曜日, Enum名称区分.名称);
                //間隔
                res.kurikaeshikannmList = DaNameService.GetSelectorList(db, EnumNmKbn.繰り返し間隔, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //バッチスケジュール情報マスタ
                var dto = db.tm_aftaskschedule.GetDtoByKey(req.taskid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //詳細画面情報
                res.mainInfo = Wraper.GetShosaiVM(db, dto);

                //正常返し
                return res;
            });
        }

        [DisplayName("登録処理")]
        public DaResponseBase Save(SaveDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                var dtoOld = new tm_aftaskscheduleDto();
                var flg = db.tm_aftaskschedule.SELECT.WHERE.ByKey(req.maininfo.taskid).Exists();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (req.editkbn == Enum編集区分.新規 && flg)
                {
                    res.SetServiceError(EnumMessage.E002003, "タスクID");
                    //異常返す
                    return res;
                }

                if (req.editkbn == Enum編集区分.変更)
                {

                    var dto = db.tm_aftaskschedule.SELECT.WHERE.ByKey(req.maininfo.taskid).GetDto();
                    //更新排他チェック
                    if (dto == null || dto.upddttm.Ticks == DaUtil.Now.Ticks)
                    {
                        throw new AiExclusiveException();
                    }

                    if (!string.IsNullOrEmpty(dto.statuscd) && (Enum処理結果区分)Enum.Parse(typeof(Enum処理結果区分), dto.statuscd) == Enum処理結果区分.実行中)
                    {
                        res.SetServiceError(EnumMessage.E004010, "タスクID");
                        //異常返す
                        return res;
                    }

                    //-------------------------------------------------------------
                    //２.データ取得
                    //-------------------------------------------------------------

                    //更新の場合
                    if (req.editkbn == Enum編集区分.変更)
                    {
                        //タスクスケジュール情報マスタ
                        dtoOld = db.tm_aftaskschedule.GetDtoByKey(req.maininfo.taskid);
                    }
                }

                //-------------------------------------------------------------
                //３.データ加工処理 & DB更新処理
                //-------------------------------------------------------------
                DateTime dttm = DaUtil.Now;

                //タスクスケジュール情報マスタ
                tm_aftaskscheduleDto aftaskscheduleDto = Converter.GetDto(dtoOld, req, dttm);

                string jobId = string.Empty;
                //  新規の場合、BATサービスのタスク登録を呼び出し、タスクIDを取得する
                if (req.editkbn == Enum編集区分.新規 && req.maininfo.jotai == "1")
                {
                    BtModel bj = BtJobService.GetBtModel(db, aftaskscheduleDto);
                    jobId = BtJobService.AddJob(db, bj);
                    aftaskscheduleDto.renkeiid = jobId;
                }
                if (req.editkbn == Enum編集区分.変更)
                {
                    var oldjotai = string.IsNullOrEmpty(dtoOld.renkeiid) ? "3" : dtoOld.stopflg ? "2" : "1";
                    BtModel bj = BtJobService.GetBtModel(db, aftaskscheduleDto);

                    if (oldjotai == "3" && req.maininfo.jotai == "1")
                    {
                        jobId = BtJobService.AddJob(db, bj);
                        aftaskscheduleDto.renkeiid = jobId;
                    }
                    else if (oldjotai == "3" && req.maininfo.jotai == "2")
                    {
                        aftaskscheduleDto.renkeiid = bj.TaskID;
                    }
                    else if (oldjotai != "3" && req.maininfo.jotai == "1")
                    {
                        BtJobService.UpdateJob(db, bj);
                    }
                    else if (oldjotai != "3" && req.maininfo.jotai != "1")
                    {
                        //JOBの削除(周期タスク)
                        BtJobService.DeleteJob(req.maininfo.taskid);
                    }

                }

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //タスクスケジュール情報マスタ
                    db.tm_aftaskschedule.INSERT.Execute(aftaskscheduleDto);
                }
                //更新の場合
                else
                {
                    //タスクスケジュール情報マスタ
                    db.tm_aftaskschedule.UpdateDto(aftaskscheduleDto, dtoOld.upddttm);
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return Delete(db, req);
            });
        }

        /// <summary>
        /// 削除処理(詳細画面)
        /// </summary>
        private DaResponseBase Delete(DaDbContext db, DeleteRequest req)
        {
            //-------------------------------------------------------------
            //１.DB更新処理
            //-------------------------------------------------------------

            var res = new DaResponseBase();
            var dto = db.tm_aftaskschedule.SELECT.WHERE.ByKey(req.taskid).GetDto();

            //排他チェック
            if (dto == null)
            {
                throw new AiExclusiveException();
            }

            if (!string.IsNullOrEmpty(dto.statuscd))
            {
                if ((Enum処理結果区分)Enum.Parse(typeof(Enum処理結果区分), dto.statuscd) == Enum処理結果区分.実行中)
                {
                    res.SetServiceError(EnumMessage.E004010, "タスクID");
                    //異常返す
                    return res;
                }
            }

            //タスクスケジュール情報マスタテーブル削除
            db.tm_aftaskschedule.DELETE.WHERE.ByKey(req.taskid).Execute();

            if (!string.IsNullOrEmpty(dto.renkeiid))
            {
                //JOBの削除(周期タスク)
                BtJobService.DeleteJob(req.taskid);

            }

            //正常返し
            return new DaResponseBase();
        }

        [DisplayName("バッチ実行処理")]
        public DaResponseBase Execute(ExeBatchDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                var dto = db.tm_aftaskschedule.SELECT.WHERE.ByKey(req.taskid).GetDto();
                if (!string.IsNullOrEmpty(dto.statuscd))
                {
                    if ((Enum処理結果区分)Enum.Parse(typeof(Enum処理結果区分), dto.statuscd) == Enum処理結果区分.実行中)
                    {
                        res.SetServiceError(EnumMessage.E004010, "タスクID");
                        //異常返す
                        return res;
                    }
                }
                if (string.IsNullOrEmpty(dto.renkeiid) || dto.stopflg)
                {
                    res.SetServiceError("タスクが未登録、使用停止の場合は、即時実行ができません。");
                    //異常返す
                    return res;
                }
                //パラメータ取得
                var param = Converter.GetBatchParameters(req);
                //タスクスケジュール情報マスタ
                BatchService.BtJobService.Execute(DaNameService.GetName(db, EnumNmKbn.モジュール, dto.modulecd), req.sessionid, req.taskid, param, true);
                //正常返し
                return new DaResponseBase();
            });
        }

    }
}
