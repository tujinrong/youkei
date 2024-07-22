// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行対象者抽出情報管理（専用）
//             リクエストインターフェース
// 作成日　　: 2024.05.27
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK01301G
{
    [DisplayName("帳票発行対象者抽出情報管理（専用）")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK01301G = "AWKK01301G";
        //検索処理(一覧画面・全体)
        private const string PROC_NAME1 = "sp_awkk01301g_01";
        //検索処理(一覧画面・個別)
        private const string PROC_NAME2 = "sp_awkk01301g_02";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //抽出対象一覧
                var mstDtl = db.tm_kktyusyutu.SELECT.WHERE.ByItem(nameof(tm_kktyusyutuDto.tyusyutukinoid), req.kinoid)
                                             .ORDER.By(nameof(tm_kktyusyutuDto.orderseq)).GetDtoList();
                //年度管理されているかどうかの設定
                var nendoSetting = Common.Wraper.GetNendoSetting(db, req.kinoid);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(抽出対象)
                res.selectorlist = mstDtl.Select(e => new DaSelectorModel(e.tyusyututaisyocd, e.tyusyututaisyonm)).OrderBy(e => e.value).ToList();
                //年度表示フラグ設定
                res.nendoflg = (nendoSetting == 名称マスタ.システム.通知サイクル._1);

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
                //年度管理されているかどうかの設定
                var nendoSetting = Common.Wraper.GetNendoSetting(db, req.kinoid);
                //パラメータ設定
                var parameters = Converter.GetParameters(req, nendoSetting);

                //一覧データ取得（全体）
                var pageList1 = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize, req.orderby);
                //一覧データ取得（個別）
                var pageList2 = DaDbUtil.GetListData(db, PROC_NAME2, parameters, req.pagenum2, req.pagesize2, req.orderby2);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //抽出情報一覧（全体）
                res.kekkalist1 = Wraper.GetVMList(db, pageList1.dataTable.Rows);
                //抽出情報一覧（個別）
                res.kekkalist2 = Wraper.GetVMList(db, pageList2.dataTable.Rows);

                //ページャー設定（全体）
                res.totalpagecount = (pageList1.TotalCount + req.pagesize - 1) / req.pagesize;
                res.totalrowcount = pageList1.TotalCount;
                //ページャー設定（個別）
                res.totalpagecount2 = (pageList2.TotalCount + req.pagesize2 - 1) / req.pagesize2;
                res.totalrowcount2 = pageList2.TotalCount;

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度管理されているかどうかの設定
                var nendoSetting = Common.Wraper.GetNendoSetting(db, req.kinoid);

                //①抽出情報
                //抽出対象
                var mstDto = db.tm_kktyusyutu.SELECT.WHERE.ByKey(req.tyusyututaisyocd).GetDto();
                //抽出結果
                var dataDto = new tt_kktaisyosya_tyusyutuDto();
                //抽出した対象者
                var subDataDtl = new List<tt_kktaisyosya_tyusyutu_subDto>();

                //参照モードの場合
                if (req.tyusyutuseq != null)
                {
                    dataDto = db.tt_kktaisyosya_tyusyutu.SELECT.WHERE.ByKey(req.tyusyutuseq).GetDto();
                    subDataDtl = db.tt_kktaisyosya_tyusyutu_sub.SELECT.WHERE.ByKey(req.tyusyutuseq).GetDtoList();
                }

                //②フリー項目
                //抽出条件／抽出条件以外制御情報
                var freeMstDtl = db.tm_kktaisyosya_tyusyutufreeitem.SELECT.WHERE.ByKey(req.tyusyututaisyocd, 名称マスタ.システム.項目管理区分._1)
                                                                   .ORDER.By(nameof(tm_kktaisyosya_tyusyutufreeitemDto.orderseq)).GetDtoList();

                //（全体抽出のみ）抽出条件／抽出条件以外項目情報
                var jokenDataDtl = new List<tt_kktaisyosya_tyusyutufreeDto>();

                //（全体抽出のみ）参照モードの場合、項目情報を取得
                if (req.tyusyutuseq != null)
                {
                    //全項目データ
                    jokenDataDtl = db.tt_kktaisyosya_tyusyutufree.SELECT.WHERE.ByItemList(
                        new string[] { nameof(tt_kktaisyosya_tyusyutufreeDto.tyusyutuseq), nameof(tt_kktaisyosya_tyusyutufreeDto.itemcd) },
                        freeMstDtl.Select(e => new object[] { CLng(req.tyusyutuseq), CStr(e.itemcd) }).ToList()
                        ).GetDtoList();
                }

                //個別抽出の情報を取得する
                var atenainfo = new AtenaVM();
                var hakkeninfo = new List<HakkenVM>();
                var hakkenSetting = false;
                if (req.zentaikobetukbn == 名称マスタ.システム.全体個別区分._2)
                {
                    //宛名情報
                    var atenaDto = db.tt_afatena.SELECT.WHERE.ByKey(req.atenano!).GetDto();
                    atenainfo = Wraper.GetVM(db, atenaDto);
                    //発券情報表示の設定
                    hakkenSetting = Wraper.GetHakkenSetting(db, mstDto);

                    //本画面は発券情報を管理する、また抽出後に発券情報を参照する場合
                    if (hakkenSetting)
                    {
                        //発券情報を取得
                        var hakkenDtl = db.tt_kkhakken.SELECT.WHERE.ByItemList(
                            new string[] { nameof(tt_kkhakkenDto.nendo), nameof(tt_kkhakkenDto.tyusyututaisyocd), nameof(tt_kkhakkenDto.atenano) },
                            new List<object[]>() { new object[] { req.nendo!, mstDto.tyusyututaisyocd, req.atenano! } }
                            ).GetDtoList();
                        hakkeninfo = Wraper.GetVMList(db, mstDto, hakkenDtl);
                    }
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------

                //抽出情報取得
                res.tyusyutuinfo = Wraper.GetVM(db, mstDto, dataDto, subDataDtl, req.nendo, req.tyusyutunaiyo);

                //抽出条件／抽出条件以外を取得
                res.jokenlist1 = new List<FreeItemTyusyutuVM>();
                if (req.zentaikobetukbn == 名称マスタ.システム.全体個別区分._1)
                {
                    var jokenMstDtl = freeMstDtl.FindAll(e => e.tyusyutujyokenkbn == 名称マスタ.システム.抽出条件区分._1);
                    res.jokenlist1 = Wraper.GetFreeItemVMList(db, req, jokenMstDtl, jokenDataDtl, nendoSetting);
                }
                var jokenigaiMstDtl = freeMstDtl.FindAll(e => e.tyusyutujyokenkbn == 名称マスタ.システム.抽出条件区分._2);
                res.jokenlist2 = Wraper.GetFreeItemVMList(db, req, jokenigaiMstDtl, jokenDataDtl, nendoSetting);

                //宛名情報
                res.atenainfo = atenainfo;

                //発券情報
                res.hakkeninfo = hakkeninfo;

                //年度表示フラグ設定
                res.nendoflg = (nendoSetting == 名称マスタ.システム.通知サイクル._1);

                //発券情報表示フラグ設定
                res.hakkenhyojiflg = hakkenSetting;

                //正常返し
                return res;
            });
        }

        [DisplayName("抽出処理")]
        public ExtractResponse Extract(ExtractRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new ExtractResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------

                //年度管理されているかどうかの設定
                var nendoSetting = Common.Wraper.GetNendoSetting(db, req.kinoid);

                //抽出対象
                var mstDto = db.tm_kktyusyutu.SELECT.WHERE.ByKey(req.tyusyututaisyocd).GetDto();
                //抽出条件／抽出条件以外
                var itemDtl = db.tm_kktaisyosya_tyusyutufreeitem.SELECT.WHERE.ByKey(req.tyusyututaisyocd).GetDtoList();

                //ストアドファンクションの名称
                var stored = mstDto.storedfunction;
                //パラメータ設定
                var parameters = Converter.GetExtractParameters(req, nendoSetting, mstDto, itemDtl);

                //対象者データを抽出する
                var dt = DaDbUtil.GetProcedureData(db, stored, parameters);
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //抽出戻り値によって、エラーメッセージを表示するや処理結果を返す
                var vm = Wraper.GetVM(dt.Rows);

                switch ((EnumServiceResult)vm.actresultkbn)
                {
                    //抽出が無事実行できた場合、抽出シーケンスを返す
                    case EnumServiceResult.OK:
                        res.tyusyutuseq = vm.tyusyutuseq;
                        break;

                    //抽出結果がエラーの場合、エラーメッセージ（MSG種別：E）を返す
                    case EnumServiceResult.ServiceError:
                        res.SetServiceError((EnumMessage)Enum.Parse(typeof(EnumMessage), vm.messageid!), vm.messagetext!);
                        return res;

                    //抽出結果がアラートの場合、アラートメッセージ（MSG種別：K）を返す
                    case EnumServiceResult.ServiceAlert:
                        res.SetServiceAlert((EnumMessage)Enum.Parse(typeof(EnumMessage), vm.messageid!), vm.messagetext!);
                        return res;

                    default: throw new ArgumentException();
                }

                //正常返し
                return res;
            });
        }
    }
}