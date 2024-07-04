// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 対象サイン
// 　　　　　　サービス処理
// 作成日　　: 2024.02.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00404D
{
    [DisplayName("対象サイン")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return SearchResult(db, req);
            });
        }

        public static SearchResponse SearchResult(DaDbContext db, SearchRequest req)
        {
            var res = new SearchResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //個人基本情報取得
            var dto = db.tt_afatena.GetDtoByKey(req.atenano);

            //年度マスタ
            var dtl1 = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList().OrderBy(e => e.jigyocd).ThenBy(e => e.kensahohocd).ToList();

            //事業一覧
            var cdnmList = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.検診種別, Enum名称区分.略称, true);

            //事業コード一覧
            var cdList = dtl1.Select(e => e.jigyocd).Distinct().ToList();
            var keyList = new List<object[]>();
            foreach (var cd in cdList)
            {
                keyList.Add(new object[] { AWKK00801G.Service.MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, cd) });
            }
            //検査方法一覧
            var dtl2 = new List<tm_afhanyoDto>();
            foreach (var item in keyList)
            {
                dtl2.AddRange(DaHanyoService.GetHanyoDtl(db, CStr(item[0]), CInt(item[1])));
            }

            //パラメータを取得
            var param = AWSH00302G.Converter.GetParameters(new AWSH00302G.InitRequest { nendo = req.nendo, atenano = req.atenano });

            //検診履歴管理テーブル
            var dt = DaDbUtil.GetProcedureData(db, AWSH00302G.Service.PROC_NAME, param);

            //受診拒否理由テーブル
            var dtl4 = db.tt_shjyusinkyohiriyu.SELECT.WHERE.ByKey(req.nendo, req.atenano).GetDtoList();

            //受診拒否理由一覧
            var cdnmList2 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.受診拒否理由, Enum名称区分.名称, true);

            //健（検）診予約希望者詳細テーブル
            var dtl5 = db.tt_shkensinkibosyasyosai.SELECT.WHERE.
                        ByFilter(@$"{nameof(tt_shkensinkibosyasyosaiDto.nendo)} = @{nameof(tt_shkensinkibosyasyosaiDto.nendo)} and 
                                        {nameof(tt_shkensinkibosyasyosaiDto.atenano)} = @{nameof(tt_shkensinkibosyasyosaiDto.atenano)}",
                                    req.nendo, req.atenano).GetDtoList();
            //日程番号一覧
            var noList = dtl5.Select(e => e.nitteino).Distinct().ToList();
            var keyList2 = new List<object[]>();
            foreach (var nitteino in noList)
            {
                keyList2.Add(new object[] { req.nendo, nitteino });
            }
            //健（検）診予定テーブル
            var dtl6 = db.tt_shkensinyotei.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();

            //健（検）診予定テーブル（ヘッダ）
            var dto5 = db.tt_shkensinyotei.SELECT.WHERE.ByKey(new object[] { req.nendo, req.nitteino }).GetDto();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //個人基本情報
            res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.CommonBarHeaderBaseVM(), dto);

            //検診履歴管理テーブル
            var dtl3 = AWSH00302G.Wraper.GetDtl(dt.Rows);

            //検査方法と予定日の関係
            var keyList3 = Wraper.GetKeyList(dtl5, dtl6);

            //検診状況一覧
            res.kekkalist = Wraper.GetVMList(db, dto!, dto5, dtl1, dtl2, dtl3, dtl4, cdnmList, keyList3, cdnmList2);

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

            //正常返し
            return res;
        }
    }
}