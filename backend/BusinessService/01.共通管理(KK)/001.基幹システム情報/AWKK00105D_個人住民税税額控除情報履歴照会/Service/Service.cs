 // *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人住民税税額控除情報履歴照会
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00105D
{
    [DisplayName("個人住民税税額控除情報履歴照会")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(AWKK00102D.SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //【個人住民税】個人住民税税額控除情報履歴テーブル：履歴単位
                var dtl = db.tt_afkojinzeikojo_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                            OrderByDescending(e => e.saisinflg).        //最新フラグ
                            ThenByDescending(e => e.kazeinendo).        //課税年度
                            ThenByDescending(e => e.kojorirekino).      //税額控除情報履歴番号
                            ThenByDescending(e => e.upddttm).           //更新日時
                            GroupBy(e => new { e.kazeinendo, e.kojorirekino }).
                            ToList();

                //【個人住民税】個人住民税税額控除情報履歴テーブル：履歴データ(各履歴の1条目)
                var dtl2 = new List<tt_afkojinzeikojo_rekiDto>();
                for (int i = 0; i < dtl.Count; i++)
                {
                    var dtl3 = dtl[i].ToList();
                    dtl2.Add(dtl3[0]);
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //履歴一覧
                res.kekkalist = Wraper.GetVMList(db, dtl2);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }
    }
}