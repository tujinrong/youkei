// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報
// 　　　　　　サービス処理
// 作成日　　: 2024.07.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.コントロールマスタ.システム;

namespace BCC.Affect.Service.AWAF00601D
{
    [DisplayName("メモ情報")]
    public class Service : CmServiceBase
    {
        //検索処理
        private const string PROC_NAME = "sp_awaf00601d_01";

        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetInitResponse(req, db);
            });
        }

        /// <summary>
        /// メモ共通初期化処理
        /// </summary>
        public InitResponse GetInitResponse(InitRequest req, DaDbContext db)
        {
            var res = new InitResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //重要度
            res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.重要度, req.kbn1);

            //登録事業
            res.selectorlist2 = CmLogicUtil.GetJigyocdSelectorList(db, Enum事業コード区分.メモ, req.kinoid!, req.kbn2, req.patternno, false);

            //表示フラグ(登録支所)
            res.showflg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, config情報._05).BoolValue1;

            //登録支所(名称)
            res.regsisyo = res.showflg && !string.IsNullOrEmpty(req.regsisyo)
                ? DaHanyoService.GetName(db, EnumHanyoKbn.部署_支所, req.kbn3, req.regsisyo)
                : string.Empty;

            //CSV出力フラグ
            res.csvoutflg = CmLogicUtil.GetCsvoutflg(db, req.token, req.userid, req.regsisyo, req.kinoid!);

            //正常返し
            return res;
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
                //個人基本情報取得(ヘッダー部)
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //登録事業(表示範囲)
                var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.メモ, req.kinoid!, req.patternno, false);

                //パラメータ取得
                var param = Converter.GetParameters(req.atenano, keyList);

                //メモ情報一覧取得(明細部)
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize);

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //登録事業(全範囲)
                var dtl1 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.メモ事業コード);
                //支所一覧
                var dtl2 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.CommonBarHeaderBaseVM(), dto);

                //画面項目設定(明細部)
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, sisyoList, dtl1, dtl2);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //メモテーブル
                var dtl = db.tt_afmemo.SELECT.WHERE.ByKey(req.atenano).GetDtoList();
                //登録事業(登録範囲-CSV出力用)
                res.jigyokbns = dtl.Where(x => keyList.Contains(x.jigyokbn)).Select(e => e.jigyokbn).Distinct().ToArray();

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
                //メモテーブル
                var keyList = Converter.GetKeyList(req.atenano, req.locklist);          //キーリスト(編集前)
                var oldDtl = db.tt_afmemo.SELECT.WHERE.ByKeyList(keyList).GetDtoList(); //編集前

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(oldDtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //最大メモシーケンス
                var maxSeq = req.addlist.Any() ? db.tt_afmemo.SELECT.WHERE.ByKey(req.atenano).GetMax<int>(nameof(tt_afmemoDto.memoseq)) : 0;

                //メモテーブル
                var addDtl = Converter.GetDtl(req.addlist, req.atenano, maxSeq);     //新規リスト
                var updDtl = Converter.GetDtl(req.updlist, oldDtl);                  //更新リスト

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //メモテーブル
                db.tt_afmemo.INSERT.SetDiffLogParameter(null).Execute(addDtl);                            //新規処理
                db.tt_afmemo.UPDATE.WHERE.ByKeyList(keyList).SetDiffLogParameter(null).Execute(updDtl);   //差分更新

                //正常返し
                return new DaResponseBase();
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<tt_afmemoDto> oldDtl, List<LockVM> locklist)
        {
            return oldDtl.Count == locklist.Count &&
                   oldDtl.All(dto => locklist.Exists(k => k.memoseq == dto.memoseq && k.upddttm == dto.upddttm));
        }
    }
}