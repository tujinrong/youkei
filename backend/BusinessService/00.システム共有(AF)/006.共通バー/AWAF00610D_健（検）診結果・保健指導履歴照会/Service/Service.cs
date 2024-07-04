// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診結果・保健指導履歴照会
// 　　　　　　サービス処理
// 作成日　　: 2024.02.13
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00610D
{
    [DisplayName("健（検）診結果・保健指導履歴照会")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00610D = "AWAF00610D";

        //健（検）診結果・保健指導履歴照会検索(内容画面)
        private const string PROC_NAME1 = "sp_awaf00610d_01";

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize, req.orderby);

                //住民情報取得(ヘッダー部)
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //住民情報
                res.headerinfo = Wraper.GetVM(db, dto);

                //実施者
                var selectorlist = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);
                var dtlhanyo = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.検診種別);  //汎用マスタ
                var dtlshkensin = db.tm_shkensinjigyo.SELECT.GetDtoList();             //成人健（検）診事業マスタ
                var dtljigyo = db.tm_kksonotasidojigyo.SELECT.GetDtoList();            //その他日程事業・保健指導事業マスタ

                //健（検）診結果・保健指導履歴照会情報一覧
                res.kekkalist = Wraper.GetVMList(db, dto, dtljigyo, selectorlist, dtlhanyo, dtlshkensin, pageList.dataTable.Rows)
                                      .OrderByDescending(e => e.ksymd)
                                      .ThenByDescending(e => e.jissiymd)
                                      .ThenByDescending(e => e.jissitm)
                                      .ThenBy(e => e.jigyocd)
                                      .ThenBy(e => e.kensinkaisu)
                                      .ThenBy(e => e.hokensidokbn)
                                      .ThenBy(e => e.gyomukbn)
                                      .ThenBy(e => e.edano)
                                      .ToList();

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("遷移処理")]
        public SearchSeniResponse SearchSeni(SearchSeniRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchSeniResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var dto = new tm_afkinoDto();
                //機能マスタ
                if (string.IsNullOrEmpty(req.kinoid2))
                {
                    dto = db.tm_afkino.SELECT.WHERE.ByFilter($@"{nameof(tm_afkinoDto.hanyokbn)} = @{nameof(tm_afkinoDto.hanyokbn)} and 
                                                             {nameof(tm_afkinoDto.kinoid)} like '{AWKK00801G.Service.AWSH001}%'", req.jigyocd).GetDto();
                }
                else
                {
                    dto = db.tm_afkino.SELECT.WHERE.ByKey(req.kinoid2).GetDto();
                }
                if (dto == null) return res;

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                var kinonm = dto.hyojinm;

                //画面起動中チェック
                if (req.kinoids.Contains(dto.kinoid))
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E001011, $"{kinonm}画面");
                    //異常返し
                    return res;
                }
                //アクセス権限チェック
                var gamenDtl = db.tt_afauthgamen.SELECT.WHERE
                                                       .ByKey(EnumToStr(Enumロール区分.ユーザー), req.userid)
                                                       .GetDtoList().Where(d => d.programkbn == Enumプログラム区分.画面).ToList();
                var existFlg = gamenDtl.Where(e => e.kinoid == dto.kinoid).Count() > 0 ? true : false;

                if (!existFlg)
                {
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.E001012, $"{kinonm}画面");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                res.kinoid = dto.kinoid;

                //正常返し
                return res;
            });
        }
    }
}