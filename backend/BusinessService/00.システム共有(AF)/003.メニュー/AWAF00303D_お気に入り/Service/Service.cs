// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お気に入り
//             サービス処理
// 作成日　　: 2023.01.23
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00303D
{
    [DisplayName("お気に入り")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //お気に入りテーブル
                var exist = db.tt_afokiniiri.SELECT.WHERE.ByKey(req.userid, req.kinoid).Exists();    //存在フラグ

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //更新区分取得
                res.statuskbn = exist ? Enumお気に入り区分.あり : Enumお気に入り区分.なし;

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public CommonResponse Search(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CommonResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //お気に入りテーブル
                var dtl = db.tt_afokiniiri.SELECT.WHERE.ByKey(req.userid).ORDER.By(nameof(tt_afokiniiriDto.orderseq)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.kekkalist = Wraper.GetKinoidList(dtl);

                //正常返し
                return res;
            });
        }

        [DisplayName("更新処理")]
        public CommonResponse Update(UpdateRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new CommonResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //お気に入りテーブル
                var dtl = db.tt_afokiniiri.SELECT.WHERE.ByKey(req.userid).ORDER.By(nameof(tt_afokiniiriDto.orderseq)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                dtl = Converter.GetDtl(dtl, req);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //お気に入りテーブル
                db.tt_afokiniiri.UPDATE.WHERE.ByKey(req.userid).Execute(dtl);   //差分更新

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //お気に入りリスト(画面)を更新
                res.kekkalist = Wraper.GetKinoidList(dtl);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public CommonResponse Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new CommonResponse();
                //-------------------------------------------------------------
                //１.削除処理(排他を無くすため)
                //-------------------------------------------------------------
                //ログインユーザーのお気に入りリストをすべて削除
                db.tt_afokiniiri.DELETE.WHERE.ByItem(nameof(tt_afokiniiriDto.userid), req.userid).Execute();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var kinoids = req.kinoids.Distinct().ToList();
                var dtl = Converter.GetDtl(req.userid, kinoids);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                db.tt_afokiniiri.INSERT.Execute(dtl);

                res.kekkalist = kinoids;
                //正常返し
                return res;
            });
        }
    }
}