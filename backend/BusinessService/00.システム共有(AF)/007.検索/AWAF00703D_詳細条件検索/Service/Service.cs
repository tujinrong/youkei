// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 詳細条件検索
// 　　　　　　サービス処理
// 作成日　　: 2023.04.25
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00703D
{
    [DisplayName("詳細条件検索")]
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
                //詳細条件設定テーブル
                var filter = $"{nameof(tt_affilterDto.kinoid)} = @{nameof(tt_affilterDto.kinoid)} and {nameof(tt_affilterDto.hyojiflg)} = @{nameof(tt_affilterDto.hyojiflg)}";
                var dtl = db.tt_affilter.SELECT.WHERE.ByFilter(filter, req.kinoid!, true).ORDER.By(nameof(tt_affilterDto.sort)).GetDtoList();
                //詳細条件(共通)
                var leftDtl = dtl.Where(d => d.jyokbn == Enum詳細検索条件区分.共通).ToList();
                //詳細条件(独自)
                var rightDtl = dtl.Where(d => d.jyokbn == Enum詳細検索条件区分.独自).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //共通(左)条件リスト
                res.leftlist = Wraper.GetVMList(db, leftDtl, req);
                //独自(右)条件リスト
                res.rightlist = Wraper.GetVMList(db, rightDtl, req);

                //正常返し
                return res;
            });
        }
    }
}