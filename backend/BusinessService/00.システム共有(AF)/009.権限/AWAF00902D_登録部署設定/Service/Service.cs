// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 登録部署設定
// 　　　　　　サービス処理
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWAF00801G;

namespace BCC.Affect.Service.AWAF00902D
{
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //支所汎用リスト
                var dtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.部署_支所)
                    .OrderBy(d => d.hanyocd).ToList();
                //汎用メインコード
                var maincd = ((long)EnumHanyoKbn.部署_支所 / 100000000L).ToString();
                //汎用サブコード
                var subcd = (int)((long)EnumHanyoKbn.部署_支所 % 100000000L);
                //汎用メインマスタ
                var subDto = db.tm_afhanyo_main.GetDtoByKey(maincd, subcd);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //汎用メインコード
                res.hanyomaincd = DaNameService.GetCdNm(db, EnumNmKbn.汎用マスタメインコード, req.kbn1, maincd);
                //汎用サブコード
                res.hanyosubcd = Wraper.GetCdNm(req.kbn2, subDto);
                //画面項目設定(ヘッダー部)
                Wraper.SetHeader(res, subDto);
                //汎用データリスト
                res.kekkalist = Wraper.GetVMList(dtl);

                //汎用データリスト(ロック用)
                res.locklist = res.kekkalist.Select(e => new LockVM(e.hanyocd, e.upddttm)).ToList();

                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var service = new AWAF00801G.Service();
                //正常返し
                return service.CommonSave(db, req);
            });
        }
    }
}