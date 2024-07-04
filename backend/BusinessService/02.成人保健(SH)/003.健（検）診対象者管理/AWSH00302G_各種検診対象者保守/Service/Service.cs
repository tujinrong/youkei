// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 各種検診対象者保守
// 　　　　　　サービス処理
// 作成日　　: 2024.02.02
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00302G
{
    [DisplayName("各種検診対象者保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        public const string AWSH00302G = "AWSH00302G";
        public const string PROC_NAME = "sp_awsh00302g_01";

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (!string.IsNullOrEmpty(req.atenano))
                {
                    //宛名テーブル
                    var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                    //存在チェック
                    if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し
                }

                //-------------------------------------------------------------
                //２.条件設定
                //-------------------------------------------------------------
                //個人番号復号化
                req.SetPersonalno();
                //固定の検索条件
                var fixedCondition = Common.Converter.GetFixedCondition(req);
                //詳細の検索条件
                var conditon = CmSearchUtil.GetSearchJyoken(db, AWSH00302G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
                //連絡先の事業コード
                var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, AWSH00302G);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果
                var result = DaFreeQuery.GetTaisyosignQuery(db, renraku_jigyocd, req.nendo, conditon, req.orderby, true);
                //総件数
                var total = result.Count;
                //結果一覧
                var pageData = result.Data;
                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //ページャー設定
                res.SetPageInfo(total, req.pagesize);
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(db, pageData.Rows, alertviewflg, adrsFlg);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人基本情報取得
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

                //権限関連
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWSH00302G);
                //個人番号操作フラグ
                var pFlg = personalflg && !string.IsNullOrEmpty(dto.personalno);
                //暗号化
                var publickey = string.Empty;   //公開キー(暗号化)
                var privatekey = string.Empty;  //秘密キー(復号化)
                //キー取得
                DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //年度マスタ
                var dtl1 = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList().OrderBy(e => e.jigyocd).ThenBy(e => e.kensahohocd).ToList();

                //事業一覧
                var cdnmList = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.検診種別, Enum名称区分.略称, true);
                //事業コード一覧
                var cdList = dtl1.Select(e => e.jigyocd).Distinct().ToList();
                var keyList = new List<object[]>();
                foreach (var cd in cdList)
                {
                    keyList.Add(new object[] { AWKK00801G.Service.MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, cd) });
                }
                //検査方法一覧
                var dtl2 = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //パラメータを取得
                var param = Converter.GetParameters(req);
                //検診履歴管理テーブル
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME, param);
                //受診拒否理由テーブル
                var dtl4 = db.tt_shjyusinkyohiriyu.SELECT.WHERE.ByKey(req.nendo, req.atenano).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //個人基本情報
                res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.GamenHeaderBase2VM(), dto, personalflg, publickey, alertviewflg, adrsFlg);

                //減免区分（特定健診）(コード：名称)
                res.genmenkbn_tokuteicdnm = DaHanyoService.GetCdNm(db, EnumHanyoKbn.減免区分_特定健診, Enum名称区分.名称, CStr(dto?.genmenkbn_tokutei));
                //減免区分（がん検診）(コード：名称)
                res.genmenkbn_gancdnm = DaHanyoService.GetCdNm(db, EnumHanyoKbn.減免区分_がん検診, Enum名称区分.名称, CStr(dto?.genmenkbn_gan));

                //検診履歴管理テーブル
                var dtl3 = Wraper.GetDtl(dt.Rows);
                //検診状況一覧
                res.kekkalist = Wraper.GetVMList(db, dto!, dtl1, dtl2, dtl3, dtl4, cdnmList);

                //減免区分（特定健診）一覧
                res.selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.減免区分_特定健診, Enum名称区分.名称, true);
                //減免区分（がん検診）一覧
                res.selectorlist2 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.減免区分_がん検診, Enum名称区分.名称, true);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.検索);

                //rsaキー
                res.rsaprivatekey = privatekey;

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
                //個人基本情報取得
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //権限関連
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWSH00302G);
                //個人番号操作フラグ
                var pFlg = personalflg && !string.IsNullOrEmpty(dto.personalno);

                //年度マスタ
                var dtl = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList().OrderBy(e => e.jigyocd).ThenBy(e => e.kensahohocd).ToList();

                //受診拒否理由テーブル
                var dtl2 = db.tt_shjyusinkyohiriyu.SELECT.WHERE.ByKey(req.nendo, req.atenano).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検診状況一覧
                res.kekkalist = Wraper.GetVMList(db, dto!, req.kekkalist, dtl, dtl2);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理(詳細画面)")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);
                //権限取得
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);
                //個人番号操作フラグ
                var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //減免区分（特定健診）
                dto.genmenkbn_tokutei = DaSelectorService.GetCd(req.genmenkbn_tokuteicdnm);
                //減免区分（がん検診）
                dto.genmenkbn_gan = DaSelectorService.GetCd(req.genmenkbn_gancdnm);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //宛名テーブル
                db.tt_afatena.UPDATE.Execute(dto!);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.更新);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}