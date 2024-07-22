// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 使用履歴
//             サービス処理
// 作成日　　: 2024.07.15
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00202S
{
    [DisplayName("使用履歴")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 使用履歴検索
        /// </summary>
        private const string PROC_NAME = "sp_awaf00202s_01";

        [DisplayName("検索処理")]
        public SearchResponse Search(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータを取得
                var param = Converter.GetParameters(req);

                //使用履歴抽出
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME, param);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.kekkalist = Wraper.GetVMList(dt.Rows);

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
                //１.データ加工処理
                //-------------------------------------------------------------
                var dto = Converter.GetDto(req);

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //使用履歴テーブル:差分更新
                db.tt_afsiyorireki.UPDATE.WHERE.ByKey(req.userid, req.kinoid)
                    .Execute(new List<tt_afsiyorirekiDto>() { dto });

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}