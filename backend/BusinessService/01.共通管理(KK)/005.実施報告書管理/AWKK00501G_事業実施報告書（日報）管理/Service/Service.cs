// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業実施報告書（日報）管理
// 　　　　　　サービス処理
// 作成日　　: 2023.11.09
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00501G
{
    [DisplayName("事業実施報告書（日報）管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00501G = "AWKK00501G";

        private const string PROC_NAME = "sp_awkk00501g_01";

        public const int MAX_SYUSSEKISYA = 99999;

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //会場情報マスタ
                var kaijoDtl = db.tm_afkaijo.SELECT
                    .SetSelectItems(nameof(tm_afkaijoDto.kaijocd), nameof(tm_afkaijoDto.kaijonm))
                    .ORDER.By(nameof(tm_afkaijoDto.kaijocd))
                    .GetDtoList();
                //事業従事者（担当者）情報マスタ
                var staffDtl = db.tm_afstaff.SELECT
                    .SetSelectItems(nameof(tm_afstaffDto.staffid), nameof(tm_afstaffDto.staffsimei))
                    .ORDER.By(nameof(tm_afstaffDto.staffid))
                    .GetDtoList();
                //事業従事者（担当者）サブマスタ
                var staffIdsStr = $"'{string.Join($"'{DaStrPool.C_COMMA}'", staffDtl.Select(x => x.staffid))}'";
                //登録事業(表示範囲)
                var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, req.kinoid!, Enum事業コードパターン.DB設定, null, true);
                var keyString = $"'{string.Join($"'{DaStrPool.C_COMMA}'", keyList)}'";
                var staffSubDtl = db.tm_afstaff_sub.SELECT
                    .WHERE.ByFilter($"{nameof(tm_afstaff_subDto.staffid)} IN ({staffIdsStr})" +
                    $" And {nameof(tm_afstaff_subDto.jissijigyo)} IN ({keyString})")
                    .ORDER.By(nameof(tm_afstaff_subDto.staffid), nameof(tm_afstaff_subDto.jissijigyo))
                    .GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(会場)
                res.selectorlist1 = kaijoDtl.Select(e => new DaSelectorModel(e.kaijocd, e.kaijonm)).ToList();
                //ドロップダウンリスト(事業)
                res.selectorlist2 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.実施報告事業コード, Enum名称区分.名称, true);
                //ドロップダウンリスト(従事者)
                var dtljujisya = staffDtl.Where(e => e.staffid != null && staffSubDtl.Any(sub => sub.staffid == e.staffid)).ToList();
                res.selectorlist3 = dtljujisya.Select(e => new DaSelectorModel(e.staffid, e.staffsimei)).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //会場情報マスタ
                var kaijoDtl = db.tm_afkaijo.SELECT
                    .SetSelectItems(nameof(tm_afkaijoDto.kaijocd), nameof(tm_afkaijoDto.kaijonm))
                    .WHERE.ByItem(nameof(tm_afkaijoDto.stopflg), false)
                    .ORDER.By(nameof(tm_afkaijoDto.kaijocd))
                    .GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(会場)
                res.selectorlist4 = kaijoDtl.Select(e => new DaSelectorModel(e.kaijocd, e.kaijonm)).ToList();
                //ドロップダウンリスト(事業)
                res.selectorlist5 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.実施報告事業コード, Enum名称区分.名称, false);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //日報一覧
                res.kekkalist = Wraper.GetVMList(pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchDetailResponse();
                //-------------------------------------------------------------
                //１.実施報告書（日報）情報データ取得
                //-------------------------------------------------------------
                //部署_支所
                var regsisyoHanyoDtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所);
                //新規場合汎用データ
                if (req.hokokusyono == null)
                {
                    var maxHokokusyono = db.tt_kkjissihokokusyo.SELECT.GetMax<int>(nameof(tt_kkjissihokokusyoDto.hokokusyono));
                    res.hokokusyono = maxHokokusyono + 1; //事業報告書番号
                    res.regsisyo = regsisyoHanyoDtl.Find(x => x.hanyocd == req.regsisyo)?.nm ?? string.Empty; //登録支所
                    return res;
                }

                //編集場合
                var dto = db.tt_kkjissihokokusyo.GetDtoByKey(req.hokokusyono.Value);
                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (dto == null!) throw new AiExclusiveException();
                //-------------------------------------------------------------
                //３.その他情報データ取得
                //-------------------------------------------------------------
                //会場情報マスタ
                var kaijoDtl = db.tm_afkaijo.SELECT.SetSelectItems(nameof(tm_afkaijoDto.kaijocd), nameof(tm_afkaijoDto.kaijonm)).GetDtoList();
                //実施報告事業汎用データ
                var jigyoHanyoDtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.実施報告事業コード);
                //実施報告書（日報）情報サブテーブル
                var staffidList = db.tt_kkjissihokokusyo_sub.SELECT.WHERE.ByKey(dto.hokokusyono).GetDtoList().Select(x => x.staffid).ToList();
                //事業従事者（担当者）情報マスタ
                var staffDtl = db.tm_afstaff.SELECT.WHERE.ByKeyList(staffidList).ORDER.By(nameof(tm_afstaffDto.staffid)).GetDtoList().ToList();
                //ユーザーマスタ
                var updUser = db.tm_afuser.GetDtoByKey(dto.upduserid);
                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                res.hokokusyono = dto.hokokusyono; //事業報告書番号
                res.upddttm = dto.upddttm; //更新日時
                res.updusernm = updUser?.usernm ?? string.Empty; //更新者
                res.regsisyo = regsisyoHanyoDtl.Find(x => x.hanyocd == dto.regsisyo)?.nm ?? string.Empty; //登録支所
                res.jissihokokusyo = Wraper.GetJissihokokusyoVM(dto, kaijoDtl, jigyoHanyoDtl); //事業実施報告書（日報）情報
                res.stafflist = Wraper.GetStaffVMList(db, staffDtl); //事業従事者リスト

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWKK00501G);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(従事者)")]
        public SearchRowResponse SearchRow(SearchRowRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchRowResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業従事者（担当者）情報マスタ
                var dto = db.tm_afstaff.GetDtoByKey(req.staffid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //事業従事者情報
                res.staffinfo = Wraper.GetStaffVM(db, dto);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public SaveResponse Save(SaveRequest req)
        {
            return Transction(req, db =>
            {
                var res = new SaveResponse();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (req.checkflg)
                {
                    //会場情報テーブル
                    var dtokaijo = db.tm_afkaijo.SELECT.WHERE.ByKey(DaSelectorService.GetCd(req.jissihokokusyo.kaijo)).GetDto();
                    //実施報告事業コード情報
                    var maincd = ((long)EnumHanyoKbn.実施報告事業コード / DaNameService.MAINCODE_DIGIT).ToString();
                    var subcd = (int)((long)EnumHanyoKbn.実施報告事業コード % DaNameService.MAINCODE_DIGIT);
                    var dtojigyo = db.tm_afhanyo.SELECT.WHERE.ByKey(maincd, subcd, DaSelectorService.GetCd(req.jissihokokusyo.jigyo)).GetDto();
                    //事業従事者（担当者）情報マスタ
                    var dtl = db.tm_afstaff.SELECT.WHERE.ByKeyList(req.staffids.ToList()).GetDtoList();
                    //利用停止データ登録確認
                    if ((dtokaijo != null && dtokaijo.stopflg)
                        || (dtojigyo != null && dtojigyo.stopflg)
                        || (dtl.Count > 0 && dtl.Any(e => e.stopflg == true)))
                    {
                        res.SetServiceAlert(EnumMessage.K000001, "使用停止のデータがあります。", "記入内容");
                        //異常返す
                        return res;
                    }

                    //正常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //事業実施報告書（日報）情報
                var dto = new tt_kkjissihokokusyoDto();
                //新規の場合
                if (req.upddttm == null)
                {
                    //重複データチェック
                    bool existflg = db.tt_kkjissihokokusyo.SELECT.WHERE.ByFilter($"{nameof(tt_kkjissihokokusyoDto.jigyocd)}=@jigyocd and   " +
                                                                                 $"{nameof(tt_kkjissihokokusyoDto.jissiymd)}=@jissiymd and " +
                                                                                 $"{nameof(tt_kkjissihokokusyoDto.kaijocd)}=@kaijocd and   " +
                                                                                 $"coalesce({nameof(tt_kkjissihokokusyoDto.timef)}, '') = @timef",
                                                                                 req.jissihokokusyo.jigyo,
                                                                                 req.jissihokokusyo.jissiymd,
                                                                                 req.jissihokokusyo.kaijo,
                                                                                 req.jissihokokusyo.timef).Exists();

                    if (existflg)
                    {
                        res.SetServiceError(EnumMessage.E001008, "事業、会場、実施日、開始時間");
                        //異常返す
                        return res;
                    }

                    //最大事業報告書番号取得
                    var maxHokokusyono = db.tt_kkjissihokokusyo.SELECT.GetMax<int>(nameof(tt_kkjissihokokusyoDto.hokokusyono));
                    req.hokokusyono = maxHokokusyono + 1;
                    dto = new tt_kkjissihokokusyoDto { hokokusyono = req.hokokusyono, regsisyo = req.regsisyo };
                }
                else
                {
                    //編集の場合
                    dto = db.tt_kkjissihokokusyo.GetDtoByKey(req.hokokusyono);
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //実施報告書（日報）情報
                dto = Converter.GetDto(dto, req.jissihokokusyo);
                //実施報告書（日報）情報サブ
                var subDtl = Converter.GetSubDtlAndKeys(dto.hokokusyono, req.staffids, out var keyList);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規
                if (req.upddttm == null)
                {
                    db.tt_kkjissihokokusyo.INSERT.Execute(dto);
                }
                //更新実施報告書（日報）情報
                else
                {
                    //更新場合排他チェック
                    if (req.upddttm.Value != dto?.upddttm) throw new AiExclusiveException();
                    db.tt_kkjissihokokusyo.UpdateDto(dto, req.upddttm.Value);
                }

                //実施報告書（日報）情報サブテーブル差分更新
                db.tt_kkjissihokokusyo_sub.UPDATE.WHERE.ByKey(req.hokokusyono).Execute(subDtl);
                res.hokokusyono = dto.hokokusyono; //事業報告書番号

                //キャシュークリア
                DaSelectorService.ClearCache();

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, db =>
            {
                //-------------------------------------------------------------
                //１.DB更新処理
                //-------------------------------------------------------------
                //実施報告書（日報）情報サブテーブル削除
                db.tt_kkjissihokokusyo_sub.DELETE.WHERE.ByKey(req.hokokusyono).Execute();
                //実施報告書（日報）情報削除
                db.tt_kkjissihokokusyo.DeleteByKey(req.hokokusyono, req.upddttm);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}