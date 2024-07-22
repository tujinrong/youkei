// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-乳幼児情報一覧
// 　　　　　　サービス処理
// 作成日　　: 2024.05.28
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00303D
{
    [DisplayName("妊産婦情報管理-乳幼児情報一覧")]
    public class Service : CmServiceBase
    {
        [DisplayName("乳幼児情報一覧画面検索処理")]
        public SearchListResponse SearchJyoseiList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        /// 乳幼児情報一覧画面検索処理
        /// </summary>
        private SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {
            var res = new SearchListResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、宛名情報取得
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //B、ヘッダー情報を取得
            res.headerinfo = Wraper.GetVM(db, atenadto);

            //C、乳幼児情報一覧情報を取得
            res.kekkalist = GetListInfo(db, res.headerinfo);

            //正常返し
            return res;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        ///乳幼児情報一覧情報を取得
        /// </summary>
        private static List<ListInfoVM> GetListInfo(DaDbContext db, HeaderInfoVM vm)
        {
            var listinfovm = new List<ListInfoVM>();

            //母子健康手帳交付（固定）テーブル
            var dtl = db.tt_bhnsbosikenkotetyokofu.SELECT.WHERE.ByKey(vm.atenano).GetDtoList().OrderBy(e => e.torokuno).ThenBy(e => e.torokunorenban);

            if (dtl !=  null) { listinfovm = Wraper.GetListInfoVMList(db, vm, dtl); }

            return listinfovm;
        }
    }
}