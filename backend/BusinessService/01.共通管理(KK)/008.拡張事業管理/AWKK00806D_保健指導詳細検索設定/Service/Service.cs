// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導詳細検索設定
// 　　　　　　サービス処理
// 作成日　　: 2024.01.24
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00806D
{
    [DisplayName("保健指導詳細検索設定")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //詳細条件設定テーブル
                var dtl = db.tt_affilter.SELECT.WHERE.ByKey(AWKK00801G.Service.AWKK00301G).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //右部分(独自)
                res.kekkalist1 = AWKK00802D.Wraper.GetVMList(dtl, Enum詳細検索条件区分.独自);

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
                //詳細条件設定テーブル
                var dtl = db.tt_affilter.SELECT.WHERE.ByKey(AWKK00801G.Service.AWKK00301G).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                dtl = AWKK00802D.Converter.GetDtl(req.kekkalist, dtl);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //詳細条件設定テーブル:差分更新
                db.tt_affilter.UPDATE.WHERE.ByKey(AWKK00801G.Service.AWKK00301G).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}