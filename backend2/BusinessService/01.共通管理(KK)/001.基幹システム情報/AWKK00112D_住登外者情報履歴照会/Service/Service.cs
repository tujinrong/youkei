// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 住登外者情報履歴照会
// 　　　　　　サービス処理
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00112D
{
    [DisplayName("住登外者情報履歴照会")]
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
                //住登外者情報テーブル
                var dtl = db.tt_afjutogai.SELECT.WHERE.ByKey(req.atenano).GetDtoList().OrderByDescending(e => e.saisinflg).ThenByDescending(e => e.rirekino).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //履歴一覧
                res.kekkalist = new Wraper().GetVMList(db, dtl);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }
    }
}