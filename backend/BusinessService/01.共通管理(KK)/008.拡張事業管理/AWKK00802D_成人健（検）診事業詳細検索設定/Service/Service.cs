// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 成人健（検）診事業詳細検索設定
// 　　　　　　サービス処理
// 作成日　　: 2024.01.15
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00802D
{
    [DisplayName("成人健（検）診事業詳細検索設定")]
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
                //機能ID
                var kinoid = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                            {nameof(tm_afkinoDto.kinoid)} like '{AWKK00801G.Service.AWSH001}%'", req.jigyocd).GetDto().kinoid;
                //詳細条件設定テーブル
                var dtl = db.tt_affilter.SELECT.WHERE.ByKey(kinoid).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検診画面ヘッダー情報
                res.headerinfo = AWKK00801G.Wraper.GetHeaderVM(db, dto);
                //右部分(独自)
                res.kekkalist1 = Wraper.GetVMList(dtl, Enum詳細検索条件区分.独自);

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
                //機能ID
                var kinoid = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                            {nameof(tm_afkinoDto.kinoid)} like '{AWKK00801G.Service.AWSH001}%'", req.jigyocd).GetDto().kinoid;
                //詳細条件設定テーブル
                var dtl = db.tt_affilter.SELECT.WHERE.ByKey(kinoid).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                dtl = Converter.GetDtl(req.kekkalist, dtl);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //詳細条件設定テーブル:差分更新
                db.tt_affilter.UPDATE.WHERE.ByKey(kinoid).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}