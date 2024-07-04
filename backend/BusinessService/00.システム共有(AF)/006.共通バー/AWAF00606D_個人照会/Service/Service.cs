// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人照会
// 　　　　　　サービス処理
// 作成日　　: 2023.09.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00606D
{
    [DisplayName("個人照会")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //宛名テーブル:個人基本情報取得(ヘッダー部)
                var dto1 = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto1, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //宛名テーブル:世帯成員一覧取得
                var dtl = db.tt_afatena.SELECT.WHERE.ByItem(nameof(tt_afatenaDto.setaino), dto1.setaino).GetDtoList().
                            OrderBy(e => CmLogicUtil.CIntJuminjotaiSort(e.juminjotai)). //住民状態
                            ThenBy(e => e.jutokbn).                                     //住登区分
                            ThenBy(e => e.zokucd1).                                     //続柄コード1
                            ThenBy(e => e.zokucd2).                                     //続柄コード2
                            ThenBy(e => e.zokucd3).                                     //続柄コード3
                            ThenBy(e => e.zokucd4).                                     //続柄コード4
                            ThenBy(e => e.bymd).                                        //生年月日
                            ThenBy(e => e.atenano).                                     //宛名番号
                            ToList();

                //【個人住民税】個人住民税課税情報テーブル
                var dtl2 = db.tt_afkojinzeikazei.SELECT.WHERE.ByItem(nameof(tt_afkojinzeikazeiDto.atenano), req.atenano).GetDtoList();
                var dto2 = dtl2.Find(e => e.kazeinendo == dtl2.Max(e => e.kazeinendo));

                //【国民健康保険】国保資格情報テーブル
                var dto3 = db.tt_afkokuho.GetDtoByKey(req.atenano);

                //【後期高齢者医療】被保険者情報テーブル
                var dto4 = db.tt_afkokihoken.GetDtoByKey(req.atenano);

                //【生活保護】生活保護受給情報テーブル
                var dto5 = db.tt_afseiho.GetDtoByKey(req.atenano);

                //【介護保険】被保険者情報テーブル
                var dto6 = db.tt_afkaigo.GetDtoByKey(req.atenano);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //個人基本情報
                res.headerinfo = Wraper.GetVM(db, dto1, alertviewflg);
                //住民情報その他情報
                res.detailinfo1 = Wraper.GetVM(db, dto1, dtl, alertviewflg);
                //課税・保険・介護情報
                res.detailinfo2 = Wraper.GetVM(db, dto1, dto2, dto3, dto4, dto5, dto6);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }
    }
}