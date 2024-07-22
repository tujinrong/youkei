// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 警告情報照会
// 　　　　　　サービス処理
// 作成日　　: 2023.09.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00607D
{
    [DisplayName("警告情報照会")]
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
                var dtl = db.tt_afsiensotitaisyosya_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                            OrderByDescending(e => e.saisinflg).ThenByDescending(e => e.siensotiymdf).ThenByDescending(e => e.rirekino).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //警告情報一覧
                res.kekkalist = Wraper.GetVMList(db, dtl);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

    }
}