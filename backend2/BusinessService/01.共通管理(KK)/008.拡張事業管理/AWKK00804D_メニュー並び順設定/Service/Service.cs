// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メニュー並び順設定
// 　　　　　　サービス処理
// 作成日　　: 2023.12.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00804D
{
    [DisplayName("メニュー並び順設定")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 受診情報管理
        /// </summary>
        private const string KENSIN_OYAMENUID = "AWSH001";

        [DisplayName("検索処理")]
        public SearchResponse Search(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //画面リスト
                var menuDtl = db.tm_afmenu.SELECT.WHERE.ByItem(nameof(tm_afmenuDto.oyamenuid), KENSIN_OYAMENUID).
                                ORDER.By(nameof(tm_afmenuDto.orderseq)).GetDtoList();
                //機能ID一覧
                var kinoDtl = db.tm_afkino.SELECT.GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面一覧
                res.kekkalist = Wraper.GetVMList(menuDtl, kinoDtl);
                //親メニュー名
                res.oyamenunm = DaNameService.GetName(db, EnumNmKbn.メニュー, KENSIN_OYAMENUID);

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
                //画面リスト
                var menuDtl = db.tm_afmenu.SELECT.WHERE.ByItem(nameof(tm_afmenuDto.oyamenuid), KENSIN_OYAMENUID).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var dtl = Converter.GetDtl(req.kekkalist, menuDtl);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //メニューマスタ:差分更新
                db.tm_afmenu.UPDATE.WHERE.ByItem(nameof(tm_afmenuDto.oyamenuid), KENSIN_OYAMENUID).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}