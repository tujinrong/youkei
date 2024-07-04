// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お知らせ
// 　　　　　　サービス処理
// 作成日　　: 2023.01.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00302D
{
    [DisplayName("お知らせ")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// お知らせ一覧取得
        /// </summary>
        const string PROC_NAME = "sp_awaf00302d_01";

        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //全ユーザー一覧を取得(ログインユーザーを除く)
                var allUsers = db.tm_afuser.SELECT.WHERE.ByFilter($"{nameof(tm_afuserDto.userid)} != @{nameof(tm_afuserDto.userid)}", req.userid).
                                ORDER.By(nameof(tm_afuserDto.userid)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //重要度区分取得
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.重要度, req.kbn);
                //ユーザー一覧リスト(全て、ログインユーザーを除く)
                res.userlist = allUsers.Select(e => new UserVM() { userid = e.userid, usernm = e.usernm }).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                SearchResponse res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ取得
                var param = Converter.GetParameters(req);

                //お知らせ一覧取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, req.userid);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

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
                //お知らせテーブル
                var oldKeyList = req.locklist.Select(e => e.infoseq).ToList();              //キーリスト(編集前)
                var oldDtl = db.tt_afinfo.SELECT.WHERE.ByKeyList(oldKeyList).GetDtoList()
                    .Where(e => e.reguserid == req.userid).ToList();                        //お知らせテーブル(DB)
                //排他チェック用(DB)
                var checklist1 = oldDtl.Select(e => new LockVM { infoseq = e.infoseq, upddttm = e.upddttm }).ToList();
                //キーリスト(お知らせ内容更新用)
                var keyList = checklist1.Select(e => e.infoseq).ToList();
                //キーリスト(既読記録更新用)
                var keyList2 = req.locklist2.Select(k => new object[] { k.infoseq, req.userid }).ToList();
                //キーリスト(既読記録リセット用)
                var keyList3 = Converter.GetKeyList(req.updlist, oldDtl);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(checklist1, req.locklist))
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //お知らせテーブル
                var addDtl = Converter.GetDtl(req.addlist);         //新規リスト
                var updDtl = Converter.GetDtl(req.updlist, oldDtl); //編集後リスト

                //お知らせ確認状態テーブル
                var updDtl2 = Converter.GetDtl(req.updlist, req.userid); //既読更新リスト

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //お知らせテーブル
                db.tt_afinfo.INSERT.Execute(addDtl);                            //新規
                db.tt_afinfo.UPDATE.WHERE.ByKeyList(keyList).Execute(updDtl);   //差分更新

                //お知らせ確認状態テーブル(既読記録差分更新)
                db.tt_afinfo_user.UPDATE.WHERE.ByKeyList(keyList2).Execute(updDtl2);

                if (keyList3.Count > 0)
                {
                    //お知らせ確認状態テーブル(既読記録リセット)
                    db.tt_afinfo_user.DELETE.WHERE.ByKeyList(keyList3).Execute();
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<LockVM> checklist1, List<LockVM> checklist2)
        {
            return checklist1.Count == checklist2.Count &&
                checklist1.All(x => checklist2.Exists(e => e.infoseq == x.infoseq && e.upddttm == x.upddttm));
        }
    }
}