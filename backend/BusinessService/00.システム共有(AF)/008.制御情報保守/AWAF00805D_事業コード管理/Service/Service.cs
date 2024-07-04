// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業コード管理
// 　　　　　　サービス処理
// 作成日　　: 2024.01.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00805D
{
    [DisplayName("事業コード管理")]
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
                //集約コード設定一覧(個人連絡先)
                var dto1 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.連絡先事業コード管理, req.cd);
                //集約コード設定一覧(メモ情報)
                var dto2 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.メモ事業コード管理, req.cd);
                //集約コード設定一覧(電子ファイル情報)
                var dto3 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.電子ファイル事業コード管理, req.cd);
                //集約コード設定一覧(フォロー管理)
                var dto4 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.フォロー事業コード管理, req.cd);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定対象表示名称
                res.nm = DaNameService.GetName(db, EnumNmKbn.各種事業コード設定対象, req.cd);
                //集約コード一覧
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.事業集約コード, Enum名称区分.名称);
                //事業コード設定
                var hanyokbn1 = DaNameService.GetKbn1(db, EnumNmKbn.各種事業コード設定対象, req.cd);
                //集約コード情報
                res.detailinfo = Wraper.GetVM(db, hanyokbn1, dto1?.hanyokbn1, dto2?.hanyokbn1, dto3?.hanyokbn1, dto4?.hanyokbn1);

                //更新日時(排他用：個人連絡先)
                res.upddttm1 = dto1?.upddttm;
                //更新日時(排他用：メモ情報)
                res.upddttm2 = dto2?.upddttm;
                //更新日時(排他用：電子ファイル情報)
                res.upddttm3 = dto3?.upddttm;
                //更新日時(排他用：フォロー管理)
                res.upddttm4 = dto4?.upddttm;

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
                //集約コード設定一覧(個人連絡先)
                var dto1 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.連絡先事業コード管理, req.cd);
                //集約コード設定一覧(メモ情報)
                var dto2 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.メモ事業コード管理, req.cd);
                //集約コード設定一覧(電子ファイル情報)
                var dto3 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.電子ファイル事業コード管理, req.cd);
                //集約コード設定一覧(フォロー管理)
                var dto4 = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.フォロー事業コード管理, req.cd);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (dto1?.upddttm != req.upddttm1 || dto2?.upddttm != req.upddttm2 || dto3?.upddttm != req.upddttm3 || dto4?.upddttm != req.upddttm4)
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //集約コード
                var dtl = Converter.GetDtl(req.detailinfo, dto1, dto2, dto3, dto4);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //キーリスト取得
                var keyList = Converter.GetKeyList(req.detailinfo, req.cd);
                //汎用マスタ:差分更新
                db.tm_afhanyo.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl);

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}