// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 年度切替
// 　　　　　　サービス処理
// 作成日　　: 2024.01.31
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00304G
{
    [DisplayName("年度切替")]
    public class Service : CmServiceBase
    {

        //引継ぎ処理
        private const string PROC_NAME1 = "sp_awsh00304g_01";
        private const string PROC_NAME2 = "sp_awsh00304g_02";
        private const string HANYO1_STR = "1";

        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                res = (InitResponse)AWSH00301G.Service.GetInitResponse(db, res);
                //引継ぎ区分一覧
                res.selectorlist8 = DaNameService.GetSelectorList(db, EnumNmKbn.対象サイン引継ぎフラグ, Enum名称区分.名称);

                //年度マスタ
                var dtlshnendo = db.tm_shnendo.SELECT.GetDtoList();
                //年度：年度マスタの最新年度＋１
                res.nendo = dtlshnendo.Max(e => e.nendo) + 1;

                //正常返し
                return res;
            });
        }

        [DisplayName("引継ぎ処理")]
        public SearchResponse Search(AWSH00301G.SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度マスタ
                var dtl = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo - 1).GetDtoList()
                                                    .OrderBy(e => e.jigyocd).ThenBy(e => e.kensahohocd).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //情報一覧
                res.kekkalist = AWSH00301G.Service.GetRows(db, dtl).OrderBy(e => e.jigyocd).ToList();

                var lockDtl = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                var locklist = AWSH00301G.Service.GetRows(db, lockDtl).OrderBy(e => e.jigyocd).ToList();
                //排他チェック用リスト
                res.locklist = AWSH00301G.Wraper.GetVMList(locklist, lockDtl, AWSH00301G.Service.KENSAHOHOCD);

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
                //２.データ加工処理
                //-------------------------------------------------------------
                //年度マスタ
                var dtl = AWSH00301G.Converter.GetDtl(req.nendo, AWSH00301G.Service.KENSAHOHOCD, req.kekkalist, cdList);

                //-------------------------------------------------------------
                //３.チェック処理
                //-------------------------------------------------------------
                if (!AWSH00301G.Service.Check(oldDtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //年度マスタ
                db.tm_shnendo.UPDATE.WHERE.ByKey(req.nendo).Execute(dtl);

                //コントロ-ルマスタ
                var ctrlmaincd = "1000";
                var ctrlsubcd = 2;
                var ctrlcd = "02";
                var nendoMax = db.tm_shnendo.SELECT.GetMax<int>(nameof(tm_shnendoDto.nendo));
                var dtoCtrl = db.tm_afctrl.SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd, ctrlcd).GetDto();
                if (dtoCtrl != null)
                {
                    //テ-プル「年度マスタ」の最大年度値をセットする
                    dtoCtrl.value1 = CStr(nendoMax);
                    db.tm_afctrl.UPDATE.WHERE.ByKey(ctrlmaincd, ctrlsubcd, ctrlcd).Execute(dtoCtrl);
                }

                //引継ぎ処理：受診拒否理由テーブル
                if (CBool(req.hikitugikbn))
                {
                    //事業コードリスト
                    var cdList2 = req.kekkalist.Select(e => e.jigyocd).ToList();
                    //汎用マスタに汎用区分１の値「1」のデータリスト
                    var hanyocdList = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.受診拒否理由)
                                      .Where(d => d.hanyokbn1 == HANYO1_STR).Select(e => e.hanyocd).ToList();
                    //パラメータ取得
                    var param = Converter.GetParameters(req.nendo, cdList2, hanyocdList);
                    //DB更新
                    DaDbUtil.RunProcedure(db, PROC_NAME1, param);
                }

                //DB更新
                DaDbUtil.RunProcedure(db, PROC_NAME2, new List<AiKeyValue> { new($"{nameof(tm_shnendoDto.nendo)}_in", req.nendo) });

                //正常返し
                return new DaResponseBase();
            });
        }
        [DisplayName("バッチ実行処理")]
        public DaResponseBase DoBatch(AWSH00301G.SearchRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //パラメータ取得
                var param = AWSH00301G.Converter.GetParameters(req);
                BatchService.BtJobService.Execute(AWSH00301G.Service.ABSH00101G, req.sessionid, null, param);
                //正常返し
                return new DaResponseBase();
            });
        }
    }
}