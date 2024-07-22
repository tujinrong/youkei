// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人住民税課税情報履歴照会
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00103D
{
    [DisplayName("個人住民税課税情報履歴照会")]
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
                //【個人住民税】個人住民税課税情報履歴テーブル
                var dtl = db.tt_afkojinzeikazei_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                            OrderByDescending(e => e.saisinflg).        //最新フラグ
                            ThenByDescending(e => e.kazeinendo).        //課税年度
                            ThenByDescending(e => e.kazeirirekino).     //課税情報履歴番号
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