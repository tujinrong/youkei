// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人検診事業項目並び順設定
// 　　　　　　サービス処理
// 作成日　　: 2024.01.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00805D
{
    [DisplayName("成人検診事業項目並び順設定")]
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
                //汎用マスタ：事業名
                var dto = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.検診種別, req.jigyocd);

                //成人保健検診結果（フリー）項目コントロールマスタ
                var dtl = db.tm_shfreeitem.SELECT.WHERE.ByKey(req.jigyocd).GetDtoList();
                //固定項目一覧(左)
                var dtl1 = dtl.Where(e => e.haitiflg).OrderBy(e => e.orderseq).ToList();
                //フリー項目一覧(右)
                var dtl2 = dtl.Where(e => !e.haitiflg).OrderBy(e => e.orderseq).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検診項目一覧画面ヘッダー情報
                res.headerinfo = AWKK00801G.Wraper.GetHeaderVM(db, dto);
                //固定項目一覧(左)
                res.kekkalist1 = Wraper.GetVMList(dtl1);
                //フリー項目一覧(右)
                res.kekkalist2 = Wraper.GetVMList(dtl2);

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
                //成人保健検診結果（フリー）項目コントロールマスタ
                var dtl = db.tm_shfreeitem.SELECT.WHERE.ByKey(req.jigyocd).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //成人保健検診結果（フリー）項目コントロールマスタ
                dtl = Converter.GetDtl(req.kekkalist1, req.kekkalist2, dtl);

                //キーリスト取得
                var keyList = dtl.Select(e => new object[] { e.jigyocd, e.itemcd }).ToList();

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //成人保健検診結果（フリー）項目コントロールマスタ:差分更新
                db.tm_shfreeitem.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}