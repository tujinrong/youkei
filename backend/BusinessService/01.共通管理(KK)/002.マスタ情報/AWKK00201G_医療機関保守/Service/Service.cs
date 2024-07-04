// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 医療機関保守
// 　　　　　　サービス処理
// 作成日　　: 2023.12.6
// 作成者　　: CNC張加恒
// 変更履歴　:
// *******************************************************************

using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00201G
{
    [DisplayName("医療機関保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00201G = "AWKK00201G";

        //医療機関検索
        private const string PROC_NAME01 = "sp_awkk00201g_01";
        private const string PROC_NAME02 = "sp_awkk00201g_02";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(医療機関コード)
                res.selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);
                res.selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ_保険, true);
                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWKK00201G);

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
                //医療機関情報一覧
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
                //実施事業初期化
                var jissijigyoSelectorList = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード);
                res.jissijigyoList = jissijigyoSelectorList.Select(e => new JissijigyoModel(e.hanyocd, e.nm, false, e.hanyokbn1!)).ToList();

                res.syozokuisikaiList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(EnumHanyoKbn.医師会));

                //医療機関_事業従事者業務区分ドロップダウンリストの初期化データ
                res.gyoSelectorList = DaNameService.GetSelectorList(db, EnumNmKbn.医療機関_事業従事者業務区分, Enum名称区分.名称);

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
                //医療機関情報マスタ
                var dto = db.tm_afkikan.GetDtoByKey(req.kikancd);

                //所属医師会リストを取得
                res.syozokuisikaiList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(EnumHanyoKbn.医師会));

                //医療機関_事業従事者業務区分ドロップダウンリストの初期化データ
                res.gyoSelectorList = DaNameService.GetSelectorList(db, EnumNmKbn.医療機関_事業従事者業務区分, Enum名称区分.名称);

                //医療機関サブマスタ(実施事業)
                var dtl2 = db.tm_afkikan_sub.SELECT.WHERE.ByKey(req.kikancd).GetDtoList();
                var jissijigyolist = dtl2.Select(dtl2 => dtl2.jissijigyo).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //医療機関情報
                res.mainInfo = Wraper.GetVM(dto);

                //実施事業
                //パラメータ設定             
                var parameters = Converter.GetParameters(req.kikancd);
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME02, parameters);

                //列名を変える
                ColumnsNameChange(dt);

                //実施事業情報
                res.jissijigyoSelectorList = Wraper.GetSubVM(db, dt.Rows);

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

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //重複チェック
                var kikancd = req.maininfo.kikancd;
                var flg = db.tm_afkikan.SELECT.WHERE.ByKey(kikancd).Exists();
                if (req.editkbn == Enum編集区分.新規 && flg)
                {
                    res.SetServiceError(EnumMessage.E002003, "医療機関コード（自治体独自）");
                    //異常返す
                    return res;
                }

                //保険医療機関コード重複チェック
                var dto = db.tm_afkikan.SELECT.WHERE.ByItem(nameof(tm_afkikanDto.hokenkikancd), req.maininfo.hokenkikancd).GetDto();
                if (dto != null && dto.kikancd != kikancd)
                {
                    res.SetServiceError(EnumMessage.E014014);
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dtoOld = new tm_afkikanDto();
                //更新の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    //医療機関マスタ
                    dtoOld = db.tm_afkikan.GetDtoByKey(kikancd);
                }
                //-------------------------------------------------------------
                //３.データ加工処理 & DB更新処理
                //-------------------------------------------------------------
                DateTime dttm = DaUtil.Now;
                //医療機関マスタ
                tm_afkikanDto afkikanDto = Converter.GetDto(dtoOld, req, dttm);
                //医療機関サブマスタ
                List<tm_afkikan_subDto> afkikan_subDtl = Converter.GetDtl(kikancd, req);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //医療機関マスタ
                    db.tm_afkikan.INSERT.Execute(afkikanDto);
                }
                //更新の場合
                else
                {
                    //医療機関マスタ
                    db.tm_afkikan.UpdateDto(afkikanDto, dtoOld.upddttm);
                }

                //医療機関サブマスタ：差分更新
                db.tm_afkikan_sub.UPDATE.WHERE.ByKey(kikancd).Execute(afkikan_subDtl);

                //キャシュークリア
                DaSelectorService.ClearCache();

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 列名を変える
        /// </summary>
        private void ColumnsNameChange(DataTable dt)
        {
            if (dt.Columns.Count > 1)
            {
                dt.Columns[0].ColumnName = nameof(tm_afhanyoDto.hanyocd);
                dt.Columns[1].ColumnName = nameof(tm_afhanyoDto.nm);
                dt.Columns[2].ColumnName = nameof(tm_afhanyoDto.hanyokbn1);
            }
        }

    }
}
