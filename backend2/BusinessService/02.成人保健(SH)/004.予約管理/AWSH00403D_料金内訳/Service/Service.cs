// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 料金内訳
// 　　　　　　サービス処理
// 作成日　　: 2024.02.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00403D
{
    [DisplayName("料金内訳")]
    public class Service : CmServiceBase
    {
        //検索処理
        private const string PROC_NAME = "sp_awsh00403d_01";
        //エラーメッセージ
        public const string ERR_MSG = "計算エラー";

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);
                //検診事業一覧
                var dtl = db.tm_shkensinjigyo.SELECT.GetDtoList();
                //健（検）診予定テーブル
                var dtl2 = db.tt_shkensinyotei.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                //検診事業コードリスト(検査方法あり)
                var cdList = dtl.Where(e => e.kensahoho_setflg).ToList().Select(e => e.jigyocd).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var vmList = req.kekkalist.Select(e => new MoneyKeyBase3VM()
                {
                    jigyocd = e.jigyocd,
                    kensahohocd = cdList.Contains(e.jigyocd) ? DaSelectorService.GetCd(e.kensahohocdnm) : AWSH00301G.Service.KENSAHOHOCD,
                    nitteino = CInt(e.nitteino)
                }).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                res.headerinfo = Wraper.GetHeaderVM(db, dto);

                ////自己負担金情報
                //res.kekkalist = Wraper.GetVMList(keyList2, dtl, dto, selectorList);

                //自己負担金情報
                res.kekkalist = Calculate(db, req.nendo, vmList, dto, dtl, dtl2);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 計算処理
        /// </summary>
        public static List<RowVM> Calculate(DaDbContext db, int nendo, List<MoneyKeyBase3VM> keyList, tt_afatenaDto dto,
                                        List<tm_shkensinjigyoDto> dtl1, List<tt_shkensinyoteiDto> dtl2)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //年度マスタ
            var keyList2 = keyList.Select(e => new object[] { nendo, e.jigyocd, e.kensahohocd }).ToList();
            var dtl3 = db.tm_shnendo.SELECT.WHERE.ByKeyList(keyList2).GetDtoList();
            //成人健（検）診予約日程事業マスタ
            var dtl4 = db.tm_shyoyakujigyo.SELECT.WHERE.ByKey(nendo).GetDtoList();
            //キーリスト
            var keys = new string[] { nameof(tm_shjikofutankinDto.nendo), nameof(tm_shjikofutankinDto.kensin_jigyocd),
                                        nameof(tm_shjikofutankinDto.ryokinpattern),nameof(tm_shjikofutankinDto.kensahohocd),
                                        nameof(tm_shjikofutankinDto.genmenkbn)};
            var vmList = Wraper.GetKeyList(keyList, dtl1, dtl2, dtl3, dtl4, dto);
            var keyList3 = vmList.Select(e => new object[] { nendo, e.jigyocd, e.ryokinpattern, e.kensahohocd, e.genmenkbn }).ToList();

            //自己負担金マスタ
            var dtl = db.tm_shjikofutankin.SELECT.WHERE.ByItemList(keys, keyList3).GetDtoList();
            //検診事業と基準日関係一覧
            var keyList4 = vmList.Select(e => new object[] { e.jigyocd, e.kensahohocd, e.kijunymd}).ToList();
            //検診事業略称一覧
            var selectorList = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.検診種別, Enum名称区分.略称, true);

            //事業コード一覧
            var cdList = dtl3.Select(e => e.jigyocd).Distinct().ToList();
            //検査方法一覧
            var dtl5 = new List<tm_afhanyoDto>();
            foreach (var cd in cdList)
            {
                dtl5.AddRange(DaHanyoService.GetHanyoDtl(db, AWKK00801G.Service.MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, cd)));
            }

            //自己負担金情報
            var kekkalist = Wraper.GetVMList(keyList4, dtl, dtl5, dto, selectorList);

            return kekkalist;
        }
    }
}