// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象外者管理
// 　　　　　　サービス処理
// 作成日　　: 2023.12.20
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWKK01001G
{
    [DisplayName("帳票発行対象外者管理")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理(一覧画面)")]
        public SearchResponse Search(Common.PersonSearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
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
                var conditon = CmSearchUtil.GetSearchJyoken(db, req.kinoid!, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
                //連絡先の事業コード
                var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, req.kinoid!);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果
                var result = DaFreeQuery.GetTaisyogaiQuery(db, renraku_jigyocd, conditon, req.orderby, true);
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
                //宛名
                var afatenaDto = db.tt_afatena.GetDtoByKey(req.atenano);
                //存在チェック
                if (!CmCheckService.CheckDeleted(res, afatenaDto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //権限取得
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);
                //暗号化
                var publickey = string.Empty;   //公開キー(暗号化)
                var privatekey = string.Empty;  //秘密キー(復号化)
                //キー取得
                DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

                //帳票グループ一覧取得
                var mstDtl = db.tm_eurptgroup.SELECT.GetDtoList();

                //帳票発行対象外者テーブル
                var dtl = db.tt_kkrpthakkotaisyogaisya.SELECT.WHERE.ByKey(req.atenano).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.GamenHeaderBaseVM(), afatenaDto, personalflg, publickey);  //個人基本情報
                //画面項目設定(明細部)
                res.kekkalist = Wraper.GetVMList(db, mstDtl, dtl);

                //業務区分ドロップダウンリスト
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);

                //rsaキー
                res.rsaprivatekey = privatekey;

                //個人番号操作フラグ
                var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);
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
                //帳票発行対象外者テーブル
                var oldDtl = db.tt_kkrpthakkotaisyogaisya.SELECT.WHERE.ByKey(req.atenano).GetDtoList();
                //権限取得
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(oldDtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //帳票発行対象外者テーブル
                var dtl = Converter.GetDtl(req.savelist, oldDtl, req.atenano);   //更新リスト
                //個人番号操作フラグ
                var pFlg = personalflg && CmLogicUtil.GetPersonalnoFlg(db, req.atenano);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //帳票発行対象外者テーブル
                db.tt_kkrpthakkotaisyogaisya.UPDATE.WHERE.ByKey(req.atenano).SetDiffLogParameter(pFlg).Execute(dtl);   //差分更新

                //正常返し
                return new DaResponseBase();
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<tt_kkrpthakkotaisyogaisyaDto> oldDtl, List<LockVM> locklist)
        {
            return oldDtl.Count == locklist.Count &&
                   oldDtl.All(dto => locklist.Exists(e => e.rptgroupid == dto.rptgroupid && e.upddttm == dto.upddttm));
        }
    }
}