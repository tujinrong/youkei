// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導・集団指導項目並び順設定
// 　　　　　　サービス処理
// 作成日　　: 2024.01.23
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00807D
{
    [DisplayName("保健指導・集団指導項目並び順設定")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(AWKK00801G.SidoCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //指導（フリー項目）コントロールマスタ
                var dtl = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn), req.gyomukbn,
                                                                EnumToStr(req.mosikomikekkakbn), EnumToStr(req.itemyotokbn)).GetDtoList().
                                                                OrderBy(e => e.orderseq).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //指導項目一覧画面ヘッダー情報
                res.headerinfo = AWKK00801G.Wraper.GetHeaderVM(db, req);
                //項目一覧
                res.kekkalist = Wraper.GetVMList(dtl);

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
                //指導（フリー項目）コントロールマスタ
                var dtl = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(EnumToStr(req.sidokbn), req.gyomukbn,
                                                                EnumToStr(req.mosikomikekkakbn), EnumToStr(req.itemyotokbn)).GetDtoList().
                                                                OrderBy(e => e.orderseq).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //指導（フリー項目）コントロールマスタ
                dtl = Converter.GetDtl(req.kekkalist, dtl);

                //キーリスト取得
                var keyList = dtl.Select(e => new object[] { EnumToStr(req.sidokbn), req.gyomukbn,
                                                            EnumToStr(req.mosikomikekkakbn), EnumToStr(req.itemyotokbn), e.itemcd }).ToList();

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //指導（フリー項目）コントロールマスタ:差分更新
                db.tm_kksidofreeitem.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}