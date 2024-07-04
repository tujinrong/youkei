// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メモ情報（世帯）
// 　　　　　　サービス処理
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00604D
{
    [DisplayName("メモ情報（世帯）")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00604D = "AWAF00604D";

        //検索処理
        private const string PROC_NAME = "sp_awaf00604d_01";

        [DisplayName("初期化処理")]
        public AWAF00601D.InitResponse Init(AWAF00601D.InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWAF00601D.Service();
                return service.GetInitResponse(req, db);
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
                //個人基本情報取得
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //世帯主の宛名番号取得
                var atenano = CmLogicUtil.GetSetainushi(db, dto.setaino);

                //世帯主基本情報取得(ヘッダー部)
                var setaiDto = db.tt_afatena.GetDtoByKey(atenano);

                //登録事業(表示範囲)
                var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.メモ, req.kinoid!, req.patternno, false);

                //パラメータ取得
                var param = Converter.GetParameters(dto.setaino, keyList);

                //メモ情報一覧取得(明細部)
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize);

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //登録事業
                var dtl1 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.メモ事業コード);
                //支所一覧
                var dtl2 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                res.headerinfo = Wraper.GetVM(db, setaiDto, dto.setaino);

                //画面項目設定(明細部)
                res.kekkalist = AWAF00601D.Wraper.GetVMList(db, pageList.dataTable.Rows, sisyoList, dtl1, dtl2);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //メモ情報（世帯）テーブル
                var dtl = db.tt_afmemosetai.SELECT.WHERE.ByKey(dto.setaino).GetDtoList();
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
                //メモ情報（世帯）テーブル
                var keyList = Converter.GetKeyList(req.setaino, req.locklist);                  //キーリスト(編集前)
                var oldDtl = db.tt_afmemosetai.SELECT.WHERE.ByKeyList(keyList).GetDtoList();    //編集前

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(oldDtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //最大メモシーケンス
                var maxSeq = req.addlist.Any() ? db.tt_afmemosetai.SELECT.WHERE.ByKey(req.setaino).GetMax<int>(nameof(tt_afmemosetaiDto.memoseq)) : 0;

                //メモ情報（世帯）テーブル
                var addDtl = Converter.GetDtl(req.addlist, req.setaino, maxSeq);     //新規リスト
                var updDtl = Converter.GetDtl(req.updlist, oldDtl);                  //更新リスト

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //メモ情報（世帯）テーブル
                db.tt_afmemosetai.INSERT.Execute(addDtl);                            //新規処理
                db.tt_afmemosetai.UPDATE.WHERE.ByKeyList(keyList).Execute(updDtl);   //差分更新

                //正常返し
                return new DaResponseBase();
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<tt_afmemosetaiDto> oldDtl, List<AWAF00601D.LockVM> locklist)
        {
            return oldDtl.Count == locklist.Count &&
                   oldDtl.All(dto => locklist.Exists(k => k.memoseq == dto.memoseq && k.upddttm == dto.upddttm));
        }
    }
}