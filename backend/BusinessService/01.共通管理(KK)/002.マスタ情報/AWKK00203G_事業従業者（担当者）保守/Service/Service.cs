// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業従事者（担当者）保守
// 　　　　　　サービス処理
// 作成日　　: 2023.12.4
// 作成者　　: 劉誠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00203G
{
    [DisplayName("事業従事者（担当者）保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00203G = "AWKK00203G";

        //検索処理(一覧画面)
        private const string PROC_NAME01 = "sp_awkk00203g_01";
        private const string PROC_NAME02 = "sp_awkk00203g_02";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //事業従業者IDドロップダウンリストの初期化データ
                res.staffidSelectorList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);

                //医療機関ドロップダウンリストの初期化データ
                res.kikanSelectorList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);

                //職種ドロップダウンリストの初期化データ
                res.syokusyunmSelectorList = DaNameService.GetSelectorList(db, EnumNmKbn.職種, Enum名称区分.名称);

                //活動区分ドロップダウンリストの初期化データ
                res.katudokbnnmSelectorList = DaNameService.GetSelectorList(db, EnumNmKbn.活動区分, Enum名称区分.名称);

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWKK00203G);

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

                //パラメータ設定
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME01, parameters, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------

                //汎用取込設定情報一覧
                res.kekkaList = Wraper.GetVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

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

                //医療機関_事業従事者業務区分ドロップダウンリストの初期化データ
                res.gyoSelectorList = DaNameService.GetSelectorList(db, EnumNmKbn.医療機関_事業従事者業務区分, Enum名称区分.名称);

                if (req.editkbn == Enum編集区分.変更)
                {
                    //-------------------------------------------------------------
                    //１.データ取得
                    //-------------------------------------------------------------

                    //事業従事者（担当者）マスタ
                    var dto = db.tm_afstaff.GetDtoByKey(req.staffid);

                    //事業従事者（担当者）サブマスタ(実施事業)
                    var dtl1 = db.tm_afstaff_sub.SELECT.WHERE.ByKey(req.staffid).GetDtoList();
                    var jissijigyolist = dtl1.Select(dtl => dtl.jissijigyo).ToList();

                    //事業従事者（担当者）所属医療機関
                    var dtl2 = db.tm_afstaff_kikan.SELECT.WHERE.ByKey(req.staffid).GetDtoList();
                    var kikanlist = dtl2.Select(dtl => dtl.kikancd).ToList();

                    //-------------------------------------------------------------
                    //２.データ加工処理
                    //-------------------------------------------------------------

                    //事業従事者（担当者) 基本情報
                    res.mainInfo = Wraper.GetVM(dto);
                    //基本情報更新時間
                    res.upddttm = dto.upddttm;

                    //所属医療機関リストプルダウンリスト
                    var kikanSelectorList = db.tm_afkikan.SELECT.GetDtoList();
                    res.kikanSelectorList = Wraper.GetKikanSelector(kikanSelectorList);

                    //所属医療機関リスト
                    res.kikanlist = kikanlist;

                    //実施事業
                    //パラメータ設定             
                    var parameters = Converter.GetParameters(req.staffid);
                    //事業従事者（担当者)　実施事業情報を取得する
                    var dt = DaDbUtil.GetProcedureData(db, PROC_NAME02, parameters);

                    //列名を変える
                    ColumnsNameChange(dt);

                    //事業従事者（担当者)　実施事業情報
                    res.jissijigyoSelectorList = Wraper.GetSubVM(db, dt.Rows);
                }
                else
                {
                    //実施事業初期化
                    var jissijigyoSelectorList = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード);
                    res.jissijigyoSelectorList = jissijigyoSelectorList.Select(e => new JissijigyoModel(e.hanyocd, e.nm, false, e.hanyokbn1!)).ToList();

                    //医療機関初期化
                    var kikanSelectorList = db.tm_afkikan.SELECT.WHERE.ByItem(nameof(tm_afkikanDto.stopflg), false).GetDtoList();
                    res.kikanSelectorList = Wraper.GetKikanSelector(kikanSelectorList);
                }

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

                var staffid = req.mainInfo.staffid;
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //重複チェック
                var flg = db.tm_afstaff.SELECT.WHERE.ByKey(staffid).Exists();
                if (req.editkbn == Enum編集区分.新規 && flg)
                {
                    res.SetServiceError(EnumMessage.E002003, "事業従業者（担当者)");
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dtoOld = new tm_afstaffDto();

                //更新の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    //事業従事者（担当者）マスタ
                    dtoOld = db.tm_afstaff.GetDtoByKey(staffid);
                    //排他チェック
                    if (dtoOld == null || dtoOld.upddttm != req.upddttm)
                    {
                        throw new AiExclusiveException();
                    }

                }
                //-------------------------------------------------------------
                //３.データ加工処理 & DB更新処理
                //-------------------------------------------------------------

                //カナ変換(ひらがな=>カタカナ)
                req.mainInfo.kanastaffsimei = DaConvertUtil.ToKatakana(req.mainInfo.kanastaffsimei);

                //時間取得
                DateTime dttm = DaUtil.Now;

                //事業従事者（担当者）マスタ
                tm_afstaffDto afstaffDto = Converter.GetDto(dtoOld, req, dttm);
                //事業従事者（担当者）サブマスタ
                List<tm_afstaff_subDto> afstaff_subDtl = Converter.GetDtl(staffid, req);
                //医療機関マスタ
                List<tm_afstaff_kikanDto> kikanDtl = Converter.GetkikanDto(staffid, req);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //事業従事者（担当者）マスタ
                    db.tm_afstaff.INSERT.Execute(afstaffDto);

                }
                //更新の場合
                else
                {
                    //事業従事者（担当者）マスタ
                    db.tm_afstaff.UpdateDto(afstaffDto, dtoOld.upddttm);

                    //関連テーブルを削除
                    DeleteData(db, staffid);
                }

                //事業従事者（担当者）サブマスタ
                db.tm_afstaff_sub.INSERT.Execute(afstaff_subDtl);

                //事業従事者（担当者）所属機関
                db.tm_afstaff_kikan.INSERT.Execute(kikanDtl);

                //正常返し
                return res;
            });
        }
        /// <summary>
        /// 関連テーブルを削除
        /// </summary>
        private void DeleteData(DaDbContext db, string staffid)
        {
            //事業従事者（担当者）サブマスタ
            db.tm_afstaff_sub.DELETE.WHERE.ByKey(staffid).Execute();
            //事業従事者（担当者）所属機関
            db.tm_afstaff_kikan.DELETE.WHERE.ByKey(staffid).Execute();
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