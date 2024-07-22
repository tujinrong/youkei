// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 会場保守
// 　　　　　　サービス処理
// 作成日　　: 2023.11.02
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00202G
{
    [DisplayName("会場保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00202G = "AWKK00202G";

        //地区検索
        private const string PROC_NAME = "sp_awkk00202g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(会場コード)
                res.selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true) ;

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWKK00202G);

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
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, parameters, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //会場情報一覧
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
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //会場情報(地区区分と地区 ダイアログボックス用)
                res.tikuList = GetTikuList(db, null);

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
                //会場情報マスタ
                var dto = db.tm_afkaijo.GetDtoByKey(req.kaijocd);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //会場情報
                res.mainInfo = Wraper.GetVM(dto);
                //地区区分情報、各地区区分の地区情報
                res.tikuList = GetTikuList(db, req.kaijocd);

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
                var kaijocd = DaSelectorService.GetCd(req.maininfo.kaijocd);
                var flg = db.tm_afkaijo.SELECT.WHERE.ByKey(kaijocd).Exists();
                if (req.editkbn == Enum編集区分.新規 && flg)
                {
                    res.SetServiceError(EnumMessage.E002003, "会場コード");
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dto = new tm_afkaijoDto();    //会場情報マスタ
                //更新の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto = db.tm_afkaijo.GetDtoByKey(kaijocd);
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //会場情報マスタ
                dto = Converter.GetDto(dto, req.maininfo, kaijocd);
                //会場情報サブマスタ
                var dtl = Converter.GetDtl(req.tikulist, kaijocd);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //会場情報マスタ
                    db.tm_afkaijo.INSERT.Execute(dto);
                }
                //更新の場合
                else
                {
                    //会場情報マスタ
                    db.tm_afkaijo.UpdateDto(dto, req.maininfo.upddttm!.Value);
                }

                //会場情報サブマスタ：差分更新
                db.tm_afkaijo_sub.UPDATE.WHERE.ByKey(kaijocd).Execute(dtl);

                //キャシュークリア
                DaSelectorService.ClearCache();

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 地区情報取得
        /// </summary>
        private List<TikuOneInitVM> GetTikuList(DaDbContext db, string? kaijocd)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //設定地区区分リスト
            var tikuList = DaNameService.GetNameList(db,
                EnumNmKbn.地区区分).Where(e => CBool(e.hanyokbn1) == true).OrderBy(e => CInt(e.nmcd)).ToList();
            var dtl = new List<tm_afkaijo_subDto>();
            if (!string.IsNullOrEmpty(kaijocd))
            {
                //会場情報サブマスタ
                dtl = db.tm_afkaijo_sub.SELECT.WHERE.ByKey(kaijocd).GetDtoList();
            }

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //地区区分情報、各地区区分の地区情報
            return Wraper.GetVMList(db, dtl, tikuList);
        }
    }
}
