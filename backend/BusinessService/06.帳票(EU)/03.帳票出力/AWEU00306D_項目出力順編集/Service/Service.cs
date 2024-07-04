// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目出力順編集
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00306D
{
    [DisplayName("項目出力順編集")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUC様式マスタ取得
                var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);
                //出力順パターンテーブル取得
                var sortDtl = db.tt_eusort.SELECT.WHERE.ByKey(req.rptid, req.yosikiid).ORDER.By(nameof(tt_eusortDto.sortptnno)).GetDtoList();
                var sortDto = sortDtl.FirstOrDefault(x => x.sortptnno == yosikiDto.sortptnno);
                //判断sortSubDtlの値を取得するかどうか
                var hasSort = yosikiDto.sortptnno > 0 && sortDto != null;
                var sortSubDtl = new List<tt_eusort_subDto>();
                if (hasSort) 
                {
                    //出力順パターンサブテーブル取得
                    sortSubDtl = db.tt_eusort_sub.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, yosikiDto.sortptnno!.Value).ORDER.By(nameof(tt_eusort_subDto.orderseq)).GetDtoList();
                }
                //EUC帳票項目マスタ取得
                var rptItemDtl = db.tm_eurptitem.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, EucConstant.NOT_SUB_YOSIKIEDA).GetDtoList()
                    .OrderBy(x => x.orderseq)
                    .ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(出力順)
                res.selectorlist1 = sortDtl.Select(x => new DaSelectorModel(x.sortptnno.ToString(), x.sortptnnm)).ToList();
                //ドロップダウンリスト(項目)
                res.selectorlist2 = rptItemDtl.Select(x => new DaSelectorModel(x.yosikiitemid, x.reportitemnm)).ToList();
                //出力順パターン番号
                res.sortptnno = hasSort ? yosikiDto.sortptnno.ToString() : null;
                //出力順の項目詳細リスト
                res.sortsublist = Wraper.GetSortSubVMList(sortSubDtl);
                //出力順更新日時
                res.sortupddttm = sortDto?.upddttm;
                //様式更新日時
                res.yosikiupddttm = yosikiDto.upddttm; 　　　　　　　　　　                                                 

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (!int.TryParse(DaSelectorService.GetCd(req.sortptnno), out var sortptnno))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E003006, $"出力順パターン番号「{req.sortptnno}」");
                    res.SetServiceError(msg);
                    return res;
                }
                //出力順パターンテーブル取得
                var sortDto = db.tt_eusort.GetDtoByKey(req.rptid, req.yosikiid, sortptnno);
                if (sortDto == null!)
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //出力順パターンサブテーブル取得
                var sortSubDtl = db.tt_eusort_sub.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, sortptnno).ORDER.By(nameof(tt_eusort_subDto.orderseq)).GetDtoList();

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //出力順の項目詳細リスト
                res.sortsublist = Wraper.GetSortSubVMList(sortSubDtl);
                //出力順更新日時
                res.sortupddttm = sortDto.upddttm;      

                //正常返し
                return res;
            });
        }

        [DisplayName("新規処理")]
        public DaResponseBase Add(AddRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (!AddCheck(db, req, res)) return res;

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //EUC様式マスタ取得
                var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);
                //最大のsortptnno取得
                var nextNo = db.tt_eusort.SELECT.WHERE.ByKey(req.rptid, req.yosikiid).GetMax<int>(nameof(tt_eusortDto.sortptnno)) + 1;

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                if (yosikiDto != null) yosikiDto.sortptnno = nextNo;
                var sortDto = Converter.GetAddSortDto(req, nextNo);
                var sortSubDtl = Converter.GetAddSortSubDtl(req, nextNo);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //出力順パターンテーブル登録
                db.tt_eusort.INSERT.Execute(sortDto);
                //出力順パターンサブテーブル登録
                db.tt_eusort_sub.INSERT.Execute(sortSubDtl);
                //EUC様式マスタ更新
                if (yosikiDto != null && req.yosikiupddttm.HasValue)
                {
                    DateTime yosikiupddttmValue = req.yosikiupddttm.Value;
                    db.tm_euyosiki.UpdateDto(yosikiDto, yosikiupddttmValue);
                }
                //正常返し
                return res;
            });
        }

        [DisplayName("更新処理")]
        public DaResponseBase Update(UpdateRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //出力順パターン番号
                var sortptnno = DaConvertUtil.CInt(DaSelectorService.GetCd(req.sortptnno));

                //更新チェック
                if (!UpdateCheck(db, req, res, sortptnno)) return res;

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //EUC様式マスタ取得
                var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                if (yosikiDto != null) yosikiDto.sortptnno = sortptnno;
                //出力順情報取得(更新)
                var sortDto = Converter.GetUpdateSortDto(req, sortptnno);
                //出力順パターンサブ情報リスト取得(更新)
                var sortSubDtl = Converter.GetUpdateSortSubDtl(req, sortptnno);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //出力順パターンサブテーブル削除
                db.tt_eusort_sub.DELETE.WHERE.ByKey(req.rptid, req.yosikiid, sortptnno).Execute();
                //出力順パターンサブテーブル登録
                db.tt_eusort_sub.INSERT.Execute(sortSubDtl);
                //出力順パターンテーブル登録
                db.tt_eusort.UPDATE.Execute(sortDto);
                //EUC様式マスタ更新
                if (yosikiDto != null && req.yosikiupddttm.HasValue)
                {
                    DateTime yosikiupddttmValue = req.yosikiupddttm.Value;
                    db.tm_euyosiki.UpdateDto(yosikiDto, yosikiupddttmValue);
                }
                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (!int.TryParse(DaSelectorService.GetCd(req.sortptnno), out var sortptnno))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E003006, $"出力順パターン番号「{req.sortptnno}」");
                    res.SetServiceError(msg);
                    return res;
                }

                //排他
                if (!db.tt_eusort.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, sortptnno).Exists())
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var yosikiDto = db.tm_euyosiki.GetDtoByKey(req.rptid, req.yosikiid);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //出力順パターンサブテーブル削除
                db.tt_eusort_sub.DELETE.WHERE.ByKey(req.rptid, req.yosikiid, sortptnno).Execute();
                //出力順パターンテーブル削除
                db.tt_eusort.DeleteByKey(req.rptid, req.yosikiid, sortptnno, req.sortupddttm);
                if (yosikiDto.sortptnno == sortptnno)
                {
                    //EUC様式マスタ更新
                    yosikiDto.sortptnno = null;
                    db.tm_euyosiki.UpdateDto(yosikiDto, req.yosikiupddttm);
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 新規チェック
        /// </summary>
        private static bool AddCheck(DaDbContext db, AddRequest req, DaResponseBase res)
        {
            string addCheckfilter =$"{nameof(tt_eusortDto.rptid)} = @{nameof(tt_eusortDto.rptid)} " +
                                    $"AND {nameof(tt_eusortDto.yosikiid)} = @{nameof(tt_eusortDto.yosikiid)} " +
                                    $"AND {nameof(tt_eusortDto.sortptnnm)} = @{nameof(tt_eusortDto.sortptnnm)}";

            //出力順パターンテーブル
            if (db.tt_eusort.SELECT.WHERE.ByFilter(addCheckfilter, req.rptid, req.yosikiid, req.sortptnnm).Exists())
            {
                var message = DaMessageService.GetMsg(EnumMessage.E002003, "出力順パターン名");
                res.SetServiceError(message);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 更新チェック
        /// </summary>
        private static bool UpdateCheck(DaDbContext db, UpdateRequest req, DaResponseBase res, int sortptnno)
        {
            //排他
            if (!db.tt_eusort.SELECT.WHERE.ByKey(req.rptid, req.yosikiid, sortptnno).Exists())
            {
                throw new AiExclusiveException();
            }

            //出力順パターン名重複チェック
            string updateCheckFilter = $"{nameof(tt_eusortDto.rptid)} = @{nameof(tt_eusortDto.rptid)} " +
                                        $"AND {nameof(tt_eusortDto.yosikiid)} = @{nameof(tt_eusortDto.yosikiid)} " +
                                        $"AND {nameof(tt_eusortDto.sortptnno)} != @{nameof(tt_eusortDto.sortptnno)} " +
                                        $"AND {nameof(tt_eusortDto.sortptnnm)} = @{nameof(tt_eusortDto.sortptnnm)}";

            if (db.tt_eusort.SELECT.WHERE.ByFilter(updateCheckFilter, req.rptid, req.yosikiid, sortptnno, req.sortptnnm).Exists())
            {
                var message = DaMessageService.GetMsg(EnumMessage.E002003, "出力順パターン名");
                res.SetServiceError(message);
                return false;
            }

            return true;
        }
    }
}