// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.プロシージャ一覧画面
// 　　　　　　サービス処理
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00608D
{
    [DisplayName("取込設定：プロシージャ一覧画面")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00608D = "AWKK00608D";

        [DisplayName("初期化処理(取込設定：プロシージャ一覧画面)")]
        public InitResponse InitDetail(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //プロシージャマスタ
                List<tm_kktorinyuryoku_procDto> dtl = db.tm_kktorinyuryoku_proc.SELECT.WHERE.ByItem(nameof(tm_kktorinyuryoku_procDto.prockbn), req.prockbn).ORDER.By(nameof(tm_kktorinyuryoku_procDto.procnm)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.procList = dtl.Select(d => new DaSelectorModel(d.procseq.ToString(), d.procnm)).ToList();

                //正常返し
                return res;
            });
        }
    }
}