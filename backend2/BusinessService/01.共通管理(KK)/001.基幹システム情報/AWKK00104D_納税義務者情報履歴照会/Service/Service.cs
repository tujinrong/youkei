// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 納税義務者情報履歴照会
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00104D
{
    [DisplayName("納税義務者情報履歴照会")]
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
                //【個人住民税】納税義務者情報履歴テーブル
                var dtl = db.tt_afkojinzeigimusya_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                            OrderByDescending(e => e.saisinflg).        //最新フラグ
                            ThenByDescending(e => e.kazeinendo).        //課税年度
                            ThenByDescending(e => e.kojinrirekino).     //個人履歴番号
                            ToList();

                //市区町村マスタ
                var dtl2 = db.tm_afsikutyoson.SELECT.GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //履歴一覧
                res.kekkalist = Wraper.GetVMList(db, dtl, dtl2);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }
    }
}