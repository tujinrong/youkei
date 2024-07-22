// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 各種事業コード設定（共通バー）
// 　　　　　　サービス処理
// 作成日　　: 2024.01.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00804G
{
    [DisplayName("各種事業コード設定（共通バー）")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //対象一覧
                var dtl1 = DaNameService.GetNameList(db, EnumNmKbn.各種事業コード設定対象).OrderBy(e => e.nmcd).ToList();

                //集約コード設定一覧(個人連絡先)
                var dtl2 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.連絡先事業コード管理);
                //集約コード設定一覧(メモ情報)
                var dtl3 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.メモ事業コード管理);
                //集約コード設定一覧(電子ファイル情報)
                var dtl4 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.電子ファイル事業コード管理);
                //集約コード設定一覧(フォロー管理)
                var dtl5 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.フォロー事業コード管理);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面一覧
                res.kekkalist = Wraper.GetVMList(db, dtl1, dtl2, dtl3, dtl4, dtl5);

                //正常返し
                return res;
            });
        }
    }
}