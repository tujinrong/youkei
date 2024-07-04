// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コントロール情報保守
// 　　　　　　サービス処理
// 作成日　　: 2023.07.18
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00802G
{
    [DisplayName("コントロール情報保守")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00802G = "AWAF00802G";

        [DisplayName("メインコード初期化処理")]
        public AWAF00801G.InitMainCodeResponse InitMainCode(AWAF00801G.InitMainCodeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new AWAF00801G.InitMainCodeResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(メインコード)
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.コントロールマスタメインコード, req.kbn);

                //EXCEL出力フラグ
                res.exceloutflg = CmLogicUtil.GetExceloutflg(db, req.token, req.userid, req.regsisyo, AWAF00802G);

                //正常返し
                return res;
            });
        }

        [DisplayName("サブコード初期化処理")]
        public AWAF00801G.InitSubCodeResponse InitSubCode(InitSubCodeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new AWAF00801G.InitSubCodeResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //コントロールメインマスタ
                var dtl = db.tm_afctrl_main.SELECT.WHERE.ByKey(req.ctrlmaincd).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(サブコード)
                res.selectorlist = Wraper.GetSelectorList(dtl, req.kbn);

                //正常返し
                return res;
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
                var ctrlmaincd = DaSelectorService.GetCd(req.ctrlmaincd);       //コントロールメインコード
                var ctrlsubcd = CInt(DaSelectorService.GetCd(req.ctrlsubcd));   //コントロールサブコード

                //コントロールマスタ
                var dtl = db.tm_afctrl.SELECT.WHERE.ByKey(ctrlmaincd, ctrlsubcd).ORDER.By(nameof(tm_afctrlDto.ctrlcd)).GetDtoList();

                //コントロールメインマスタ
                var subDto = db.tm_afctrl_main.GetDtoByKey(ctrlmaincd, ctrlsubcd);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                res.biko = subDto?.biko ?? string.Empty;

                //画面項目設定(明細部)
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
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //コントロールキーリスト取得
                var ctrlmaincd = DaSelectorService.GetCd(req.ctrlmaincd);     //コントロールメインコード
                var ctrlsubcd = CInt(DaSelectorService.GetCd(req.ctrlsubcd)); //コントロールサブコード
                var keyList = Converter.GetKeyList(ctrlmaincd, ctrlsubcd, req.savelist);

                //編集前のコントロールマスタリスト取得
                var oldDtl = db.tm_afctrl.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(req.savelist, oldDtl)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //更新リスト
                var updDtl = Converter.GetDtl(req.savelist, oldDtl);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //差分更新
                db.tm_afctrl.UPDATE.WHERE.ByKeyList(keyList).Execute(updDtl);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<SaveVM> savelist, List<tm_afctrlDto> oldDtl)
        {
            return savelist.Count == oldDtl.Count
                   && savelist.All(x => oldDtl.Any(d => x.ctrlcd == d.ctrlcd && x.upddttm == d.upddttm));
        }
    }
}