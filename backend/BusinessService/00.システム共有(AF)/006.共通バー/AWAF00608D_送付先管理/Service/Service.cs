// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 送付先管理
// 　　　　　　サービス処理
// 作成日　　: 2023.11.14
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.コントロールマスタ.システム;

namespace BCC.Affect.Service.AWAF00608D
{
    [DisplayName("送付先管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00608D = "AWAF00608D";
        public const string TYOAZACD_NULL = "9999999";
        public static string riyoumokuteiUpd = string.Empty;

        //送付先管理検索
        private const string PROC_NAME = "sp_awaf00608d_01";

        [DisplayName("一覧初期化処理")]
        public InitListResponse InitList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, parameters, req.pagenum, req.pagesize);

                //住民情報取得(ヘッダー部)
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, config情報._03).BoolValue1;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //住民情報
                res.headerinfo = Wraper.GetVM(db, dto, adrsFlg);

                //送付先管理情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWAF00608D);

                //利用目的新規用フラグ 未使用利用目的ない場合は新規できない
                var dtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.利用目的);
                res.sinkiflg = res.kekkalist.Count == dtl.Count ? false : true;

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("詳細初期化処理")]
        public InitDetailResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //支所一覧
                var dtl = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);
                //表示フラグ(登録支所)
                res.showflg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, config情報._05).BoolValue1;

                res.regsisyo = res.showflg && !string.IsNullOrEmpty(req.regsisyo)
                   ? DaHanyoService.GetName(db, EnumHanyoKbn.部署_支所, Enum名称区分.名称, req.regsisyo)
                   : string.Empty;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト初期化
                GetInitList(db, res);

                //正常返し
                return res;
            });
        }

        [DisplayName("詳細検索処理")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //利用目的一覧
                var dtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.利用目的);

                //支所一覧
                var dtl2 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);

                //送付先管理情報
                var dto = db.tt_afsofusaki.GetDtoByKey(req.atenano, req.riyomokuteki) ?? new tt_afsofusakiDto();

                //保存チェック用
                riyoumokuteiUpd = dto.riyomokuteki;
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //市区町村マスタ
                var existsflg1 = db.tm_afsikutyoson.SELECT.WHERE.ByKey(dto.adrs_sikucd).Exists();
                //町字マスタ
                var existsflg2 = db.tm_aftyoaza.SELECT.WHERE.ByKey(dto.adrs_sikucd, dto.adrs_tyoazacd).Exists();

                //送付先管理情報
                res.mainInfo = Wraper.GetVM(dto, sisyoList, dtl, dtl2, existsflg1, existsflg2);

                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理(事前)
                //-------------------------------------------------------------
                //業務チェック処理
                if (req.checkflg)
                {
                    //郵便番号と市区町村、町字内容を一致チェック
                    var dtotyoaza = GetTyoazaDto(db, req.maininfo.adrs_yubin);

                    if (req.maininfo.adrs_tyoazacd != dtotyoaza?.tyoazaid)
                    {
                        res.SetServiceAlert(EnumMessage.K000001, "郵便番号と町字情報が不一致です。", "入力内容");
                        //異常返す
                        return res;
                    }

                    var dtosikutyoson = new tm_afsikutyosonDto();
                    if (dtotyoaza != null)
                    {
                        dtosikutyoson = GetSikutyosonDto(db, dtotyoaza.sikucd);

                        if (req.maininfo.adrs_sikucd != dtosikutyoson?.sikucd)
                        {
                            res.SetServiceAlert(EnumMessage.K000001, "郵便番号と市区町村情報が不一致です。", "入力内容");
                            //異常返す
                            return res;
                        }
                    }

                    //正常返し
                    return res;
                }

                var atenano = DaSelectorService.GetCd(req.maininfo.atenano);
                var riyomokuteki = req.maininfo.riyomokuteki;
                var flg = db.tt_afsofusaki.SELECT.WHERE.ByKey(atenano, riyomokuteki).Exists();
                if (flg)
                {
                    if (req.editkbn == Enum編集区分.新規 || (riyoumokuteiUpd != riyomokuteki && req.editkbn == Enum編集区分.変更))
                    {
                        res.SetServiceError(EnumMessage.E002003, "利用目的");
                        //異常返す
                        return res;
                    }
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dto = new tt_afsofusakiDto();    //送付先管理情報
                //更新の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto = db.tt_afsofusaki.GetDtoByKey(atenano, riyomokuteki);
                }

                var dto2 = db.tm_afsikutyoson.GetDtoByKey(req.maininfo.adrs_sikucd);

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //送付先管理情報
                dto = Converter.GetDto(dto, req.maininfo, dto2);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //送付先管理テーブル
                    db.tt_afsofusaki.INSERT.SetDiffLogParameter(null).Execute(dto);
                }
                //更新の場合
                else
                {
                    //送付先管理テーブル
                    db.tt_afsofusaki.UpdateDto(dto, req.maininfo.upddttm!.Value);
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
                //-------------------------------------------------------------
                //１.DB更新処理
                //-------------------------------------------------------------
                db.tt_afsofusaki.DeleteByKey(req.atenano, req.riyomokuteki, req.upddttm);

                //正常返し
                return new DaResponseBase();
            });
        }

        [DisplayName("自動入力処理")]
        public AutoSetResponse AutoSet(AutoSetRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new AutoSetResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //町字マスタ
                var dtotyoaza = GetTyoazaDto(db, req.adrs_yubin);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dtotyoaza, EnumMessage.E004006, "郵便番号", "町字情報")) return res;  //異常返し

                var dtosikutyoson = new tm_afsikutyosonDto();
                if (dtotyoaza != null)
                {
                    dtosikutyoson = GetSikutyosonDto(db, dtotyoaza.sikucd);

                    //存在チェック
                    if (!CmCheckService.CheckDeleted(res, dtosikutyoson, EnumMessage.E004006, "郵便番号", "町字情報")) return res;  //異常返し
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //送付先管理情報
                res.autoset = Wraper.GetVM(dtotyoaza, dtosikutyoson);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 詳細画面ドロップダウンリスト初期化
        /// </summary>
        private void GetInitList(DaDbContext db, InitDetailResponse res)
        {
            //ドロップダウンリスト(利用目的)
            var dtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.利用目的);
            res.riyomokutekiList = Wraper.GetVMList(dtl);

            //ドロップダウンリスト(登録事由)
            res.torokujiyuList = DaNameService.GetSelectorList(db, EnumNmKbn.登録事由, Enum名称区分.名称);

            //ドロップダウンリスト(市区町村)
            var sityosonList = db.tm_afsikutyoson.SELECT.GetDtoList().
                        Select(e => new DaSelectorModel(e.sikucd, $"{e.todofukennm}{e.gunnm}{e.sikunm}"))
                        .OrderBy(e => e.value).ToList();
            res.sityosonList = sityosonList;

            //ドロップダウンリスト(町字)
            var dtl2 = db.tm_aftyoaza.SELECT.WHERE.ByKeyList(sityosonList.Select(e => e.value).ToList()).GetDtoList();
            res.tyoazaList = Wraper.GetVMTyoazaList(dtl2);
        }

        /// <summary>
        /// 郵便番号利用、町字マスタ取得
        /// </summary>
        private tm_aftyoazaDto? GetTyoazaDto(DaDbContext db, string yubin)
        {
            var dtl = db.tm_aftyoaza.SELECT.WHERE
                                            .ByItem(nameof(tm_aftyoazaDto.yubin), yubin).GetDtoList();
            var dtotyoaza = dtl.Where(e => string.IsNullOrEmpty(e.haisiymd) ||
                                DateTime.TryParse(e.haisiymd, out var parsedDate) && DateTime.Now < parsedDate)
                               .ToList().FirstOrDefault();
            return dtotyoaza;
        }

        /// <summary>
        /// 市区町村マスタ取得
        /// </summary>
        private tm_afsikutyosonDto? GetSikutyosonDto(DaDbContext db, string sikucd)
        {
            var dtl2 = db.tm_afsikutyoson.SELECT.WHERE.ByKey(sikucd).GetDtoList();
            var dtosikutyoson = dtl2.Where(e => string.IsNullOrEmpty(e.haisiymd) ||
                                 DateTime.TryParse(e.haisiymd, out var parsedDate) && DateTime.Now < parsedDate)
                                .ToList().FirstOrDefault();

            return dtosikutyoson;
        }
    }
}
