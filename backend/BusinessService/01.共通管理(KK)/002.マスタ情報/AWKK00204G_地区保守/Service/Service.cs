// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 地区保守
// 　　　　　　サービス処理
// 作成日　　: 2023.09.22
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00204G
{
    [DisplayName("地区保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00204G = "AWKK00204G";

        //地区検索
        private const string PROC_NAME = "sp_awkk00204g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //地区リスト(表示)
                var keyList = DaNameService.GetNameList(db, EnumNmKbn.地区区分).Where(e => CBool(e.hanyokbn1)).Select(e => e.nmcd).ToList();
                //地区情報マスタ
                var dtl1 = db.tm_aftiku.SELECT.WHERE.ByKeyList(keyList).GetDtoList().OrderBy(e => e.tikukbn).ThenBy(e => e.tikucd).ToList();
                //地区情報サブマスタ
                var dtl2 = db.tm_aftiku_sub.SELECT.GetDtoList().OrderBy(e => e.tikukbn).ThenBy(e => e.tikucd).ThenBy(e => e.staffid).ToList();
                //スタッフ一覧
                var keyList2 = dtl2.Select(e => e.staffid).Distinct().ToList();
                //事業従事者（担当者）情報マスタ
                var dtl3 = db.tm_afstaff.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(地区区分)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.地区区分, Enum名称区分.名称).
                                    Where(e => keyList.Contains(e.value)).OrderBy(e => CInt(e.value)).ToList();
                //ドロップダウンリスト(地区コード)：連動あり
                res.selectorlist2 = dtl1.Select(e => new DaSelectorKeyModel(e.tikucd, e.kanatikunm, EnumToStr(e.tikukbn))).
                                    OrderBy(e => e.key).ThenBy(e => e.value).ToList();
                //ドロップダウンリスト(地区担当者)：連動なし
                res.selectorlist3 = dtl3.Select(e => new DaSelectorModel(e.staffid, e.staffsimei)).OrderBy(e => e.value).ToList();

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWKK00204G);

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
                //地区情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

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
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //地区情報マスタ
                var dto = db.tm_aftiku.GetDtoByKey(req.tikukbn, req.tikucd);
                //地区情報サブマスタ(担当者ID)
                var keyList = db.tm_aftiku_sub.SELECT.SetSelectItems(nameof(tm_aftiku_subDto.staffid)).
                                WHERE.ByKey(req.tikukbn, req.tikucd).GetDtoList().Select(e => e.staffid).ToList();
                //事業従事者（担当者）情報マスタ
                var dtl = db.tm_afstaff.SELECT.WHERE.ByKeyList(keyList).GetDtoList().OrderBy(e => e.staffid).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //地区情報
                res.maininfo = Wraper.GetVM(dto);
                //地区担当者情報
                res.stafflist = Wraper.GetVMList(db, dtl);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(担当者)")]
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
                //地区担当者情報
                res.staffinfo = Wraper.GetVM(db, dto);

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
                //地区区分(コード)
                var tikukbn = DaSelectorService.GetCd(req.maininfo.tikukbn);
                //マスタ存在チェック：新規ID存在する場合、エラーメッセージを返す
                var flg = db.tm_aftiku.SELECT.WHERE.ByKey(tikukbn, req.maininfo.tikucd).Exists();
                if (req.editkbn == Enum編集区分.新規 && flg)
                {
                    res.SetServiceError(EnumMessage.E002003, "地区コード");
                    //異常返す
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                var dto = new tm_aftikuDto();   //地区情報マスタ
                //更新の場合
                if (req.editkbn == Enum編集区分.変更)
                {
                    //地区情報マスタ
                    dto = db.tm_aftiku.GetDtoByKey(tikukbn, req.maininfo.tikucd);
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //地区情報マスタ
                dto = Converter.GetDto(dto, req.maininfo, tikukbn);
                //地区情報サブマスタ
                var dtl = Converter.GetDtl(req.stafflist, tikukbn, req.maininfo.tikucd);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //地区情報マスタ
                    db.tm_aftiku.INSERT.Execute(dto);
                }
                //更新の場合
                else
                {
                    //地区情報マスタ
                    db.tm_aftiku.UpdateDto(dto, req.maininfo.upddttm!.Value);
                }

                //地区情報サブマスタ：差分更新
                db.tm_aftiku_sub.UPDATE.WHERE.ByKey(tikukbn, req.maininfo.tikucd).Execute(dtl);

                //キャシュークリア
                DaSelectorService.ClearCache();

                //正常返し
                return res;
            });
        }
    }
}