// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 生活保護受給情報履歴履歴照会
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00108D
{
    [DisplayName("生活保護受給情報履歴履歴照会")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(AWKK00102D.SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //【生活保護】生活保護受給情報履歴テーブル
                var dtl = db.tt_afseiho_reki.SELECT.WHERE.ByItem(nameof(tt_afseiho_rekiDto.atenano), req.atenano).GetDtoList().
                            OrderByDescending(e => e.saisinflg).        //最新フラグ
                            ThenByDescending(e => e.sinseirirekino).    //申請履歴番号
                            ThenBy(e => e.fukusijimusyocd).             //福祉事務所コード
                            ThenByDescending(e => e.ketteirirekino).    //決定履歴番号
                            ThenByDescending(e => e.caseno).            //ケース番号
                            ThenBy(e => e.inno).                        //員番号
                            ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //履歴一覧
                res.kekkalist = Wraper.GetVMList(db, dtl);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }
    }
}