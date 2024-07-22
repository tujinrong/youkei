// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診対象者設定
// 　　　　　　サービス処理
// 作成日　　: 2024.01.30
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00301G
{
    [DisplayName("健（検）診対象者設定")]
    public class Service : CmServiceBase
    {
        //機能ID
        public const string ABSH00101G = "ABSH00101G";
        public const string KENSAHOHOCD = "0"; //検査方法なしの場合、検査方法コードの保存値

        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //正常返し
                return GetInitResponse(db, res);
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度マスタ
                var dtl = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList().OrderBy(e => e.jigyocd).ThenBy(e => e.kensahohocd).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //情報一覧
                res.kekkalist = GetRows(db, dtl).OrderBy(e => e.jigyocd).ToList();
                //排他チェック用リスト
                res.locklist = Wraper.GetVMList(res.kekkalist, dtl, KENSAHOHOCD);

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
                //年度マスタ
                var oldDtl = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                //検査方法なし事業一覧
                var cdList = db.tm_shkensinjigyo.SELECT.WHERE.ByFilter($"{nameof(tm_shkensinjigyoDto.kensahoho_setflg)} = @{nameof(tm_shkensinjigyoDto.kensahoho_setflg)}", false).
                                GetKeyList().Select(e => e[0]).Cast<string>().ToList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(oldDtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var dtl = Converter.GetDtl(req.nendo, KENSAHOHOCD, req.kekkalist, cdList);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //年度マスタ:差分更新
                db.tm_shnendo.UPDATE.WHERE.ByKey(req.nendo).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
        /// <summary>
        /// 初期化処理(共通)
        /// </summary>
        public static InitResponse GetInitResponse(DaDbContext db, InitResponse res)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //事業一覧
            var selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.検診種別, Enum名称区分.名称, false);
            //事業コード一覧
            var cdList = selectorlist1.Select(e => e.value).ToList();
            var keyList = new List<object[]>();
            foreach (var cd in cdList)
            {
                keyList.Add(new object[] { AWKK00801G.Service.MAINCD1, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, cd) });
            }
            //検査方法一覧
            var dtl = db.tm_afhanyo.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //事業一覧
            res.selectorlist1 = selectorlist1;
            //検査方法一覧
            res.selectorlist2 = Wraper.GetSelectorList(cdList, dtl).OrderBy(e => e.value).ToList();
            //性別一覧
            res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.性別_システム, Enum名称区分.名称);
            //基準日区分一覧
            res.selectorlist4 = DaNameService.GetSelectorList(db, EnumNmKbn.年齢基準日区分, Enum名称区分.名称);
            //保険区分一覧
            res.selectorlist5 = DaNameService.GetSelectorList(db, EnumNmKbn.保険区分_共通管理, Enum名称区分.名称);
            //特殊処理一覧
            res.selectorlist6 = DaNameService.GetSelectorList(db, EnumNmKbn.健_検_診対象者特殊条件, Enum名称区分.名称);
            //年度マスタ
            var dtlshnendo = db.tm_shnendo.SELECT.GetDtoList();
            //年度：年度マスタの最新年度
            res.nendo = dtlshnendo.Max(e => e.nendo);

            //正常返し
            return res;
        }
        /// <summary>
        /// 検索処理(共通)
        /// </summary>
        public static List<RowVM> GetRows(DaDbContext db, List<tm_shnendoDto> dtl2)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //成人健（検）診事業マスタ
            var dtl1 = db.tm_shkensinjigyo.SELECT.GetDtoList();
            //事業一覧
            var cdList1 = dtl1.Select(e => e.jigyocd).ToList();
            //検査方法なし事業一覧
            var cdList2 = dtl1.Where(e => !e.kensahoho_setflg).Select(e => e.jigyocd).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //情報一覧
            return Wraper.GetVMList(cdList1, cdList2, dtl2);
        }
        [DisplayName("バッチ実行処理")]
        public DaResponseBase DoBatch(SearchRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //パラメータ取得
                var param = Converter.GetParameters(req);
                BatchService.BtJobService.Execute(ABSH00101G, req.sessionid, null, param, null);
                //正常返し
                return new DaResponseBase();
            });
        }
        /// <summary>
        /// 排他チェック
        /// </summary>
        public static bool Check(List<tm_shnendoDto> oldDtl, List<LockVM> locklist)
        {
            return oldDtl.Count == locklist.Count &&
                   oldDtl.All(dto => locklist.Exists(e => e.jigyocd == dto.jigyocd &&
                    (e.kensahohocd == null ? KENSAHOHOCD : e.kensahohocd) == dto.kensahohocd &&
                    e.upddttm == dto.upddttm));
        }
    }
}