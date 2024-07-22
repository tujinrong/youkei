// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 受診拒否設定
// 　　　　　　サービス処理
// 作成日　　: 2024.02.06
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00303D
{
    [DisplayName("受診拒否設定")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
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
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWSH00302G.Service.AWSH00302G);
                //個人番号操作フラグ
                var pFlg = personalflg && !string.IsNullOrEmpty(dto.personalno);

                //年度マスタ：検診事業コード一覧
                var keyList = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetKeyList().Select(e => e[1]).Cast<string>().OrderBy(e => e).Distinct().ToList();

                //事業一覧
                var cdnmList = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.検診種別, Enum名称区分.名称, true);

                //受診拒否理由テーブル
                var dtl1 = db.tt_shjyusinkyohiriyu.SELECT.WHERE.ByKey(req.nendo, req.atenano).GetDtoList();
                //汎用マスタ
                var dtl2 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.受診拒否理由);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //受診拒否理由情報一覧
                res.kekkalist = Wraper.GetVMList(keyList, dtl1, dtl2, cdnmList);

                //受診拒否理由一覧
                res.selectorlist = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.受診拒否理由, Enum名称区分.名称, false);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
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
                //受診拒否理由テーブル
                var dtl = Converter.GetDtl(req.kekkalist, req.nendo, req.atenano);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //受診拒否理由テーブル
                db.tt_shjyusinkyohiriyu.UPDATE.WHERE.ByKey(req.nendo, req.atenano).SetDiffLogParameter(null).Execute(dtl);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.更新);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}