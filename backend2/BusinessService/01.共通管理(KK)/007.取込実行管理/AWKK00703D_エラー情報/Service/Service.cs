// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行.エラー一覧(行のエラー明細）
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00703D
{
    [DisplayName("取込実行")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00703D = "AWKK00703D";
        //初期検索処理
        private const string PROC_NAME1 = "sp_awkk00703d_01";

        [DisplayName("初期化処理(エラー一覧(行のエラー明細）)")]
        public InitListResponse InitList(InitListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = GetParameters(req);

                //取込データエラー情報を取得する
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME1, parameters);

                if (dt != null && dt.Rows.Count > 0)
                {
                    //取込データエラー情報
                    res.kimpErrList = Wraper.GetKimpErrRowVMList(dt);
                    res.rowno = req.rowno;                                                      //行番号
                    res.atenano = dt.Rows[0].Wrap(nameof(tt_kktorinyuryoku_errDto.atenano));    //宛名番号
                    res.shimei = dt.Rows[0].Wrap(nameof(tt_kktorinyuryoku_errDto.simei));       //氏名
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 検索パラメータを取得
        /// </summary>
        public List<AiKeyValue> GetParameters(InitListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(tt_kktorinyuryoku_errDto.impjikkoid)}_in", req.impexeid),   //取込実行ID
                new($"{nameof(tt_kktorinyuryoku_errDto.rowno)}_in", req.rowno)            //行番号
            };

            return paras;
        }
    }
}