// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理画面 
// 　　　　    サービス処理　　 
// 作成日　　: 2024.01.16
// 作成者　　: ショウ
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00206D
{
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //市区町村長名 汎用マスタ
                var hanyoDtl1 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.自治体情報);
                //問い合わせ内容コード 汎用マスタ
                var hanyoDtl2 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.問い合わせ内容コード);
                //公印マスタ
                var koinDto = db.tm_eukoin.SELECT.WHERE.ByKey(EucConstant.KOIN_INFO_ID).GetDto();
                //通知書一覧取得
                var rptDtl = GetData(db,EnumToStr(Enum様式種別詳細.台帳), EnumToStr(Enum内外区分.外部帳票));

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------

                //市区町村長情報
                res.soncho = Wraper.GetSonchoVM(hanyoDtl1);
                //職務代理者情報
                res.dairisha = Wraper.GetDairishaVM(hanyoDtl1);

                //課コードリスト
                res.kacdList = GetHanyoSelectorList(db, EnumHanyoKbn.課);
                //係コードリスト
                res.kakaricdList = GetHanyoSelectorList(db, EnumHanyoKbn.係);
                //問い合わせ先リスト
                res.toiawasesakicdList = GetHanyoSelectorList(db, EnumHanyoKbn.問い合わせ内容コード);
                //市区町村長公印画像
                res.sonchokoindata = koinDto.sikutyosontyokoin;
                //職務代理者公印画像
                res.dairishakoindata = koinDto.dairisyakoin;
                //公印更新日時
                res.upddttm = koinDto.upddttm;

                //印字設定結果リスト
                res.kekkalist1 = Wraper.GetKoinReportVMList(rptDtl);
                //問い合わせ先設定結果リスト
                res.kekkalist2 = Wraper.GetContactInfoReportVMList(rptDtl, hanyoDtl2);

                // 正常返し
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
                var rptIdList = req.koinreportlist.Select(k => new object[] { k.rptid, k.yosikiid }).ToList();

                //現在の帳票リスト
                var rptDtl = db.tm_euyosiki.SELECT.WHERE.ByKeyList(rptIdList).GetDtoList().ToList();
                //汎用マスタ(市区町村長名)
                var hanyoDtl = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.自治体情報)
                    .Where(x => x is { stopflg: false, hanyocd: EucConstant.SITYOMEI_HANYO_CD or EucConstant.DAIRISYA_HANYO_CD })
                    .ToList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(req.koinreportlist, req.contactinforeportlist, rptDtl)
                    || !Check(hanyoDtl, req.soncho, req.dairisha))
                {
                    throw new AiExclusiveException();
                }
                //EUC帳票マスタ
                var saveRptDtl = Converter.GetSaveRptDtl(req.koinreportlist, req.contactinforeportlist, rptDtl);

                //重複を削除する
                var uniqueRptIdList = rptIdList
                    .GroupBy(x => new { rptid = x[0], yosikiid = x[1] })
                    .Select(g => g.First())
                    .ToList();

                var uniqueSaveRptDtl = saveRptDtl
                    .GroupBy(dtl => new { dtl.rptid, dtl.yosikiid })
                    .Select(g => g.First())
                    .ToList();
                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                
                //公印マスタ
                var koinDto = Converter.GetKoinDto(req.files);
                //汎用マスタ(市区町村長名+職務代理者)
                var saveHanyoDtl = Converter.GetHanyoDtl(hanyoDtl, req.soncho, req.dairisha);
                //汎用マスタキーリスト(市区町村長名+職務代理者)
                var saveHanyoKeyList = new List<object[]>
                {
                    new object[] { Converter.MAIN_CD, Converter.SUB_CD, EucConstant.SITYOMEI_HANYO_CD },
                    new object[] { Converter.MAIN_CD, Converter.SUB_CD, EucConstant.DAIRISYA_HANYO_CD }
                };

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //EUC様式マスタを更新
                db.tm_euyosiki.UPDATE.WHERE.ByKeyList(uniqueRptIdList).Execute(uniqueSaveRptDtl);
                //公印マスタを更新
                db.tm_eukoin.UpdateDto(koinDto, req.upddttm);
                //汎用マスタ(市区町村長名+職務代理者)を更新
                db.tm_afhanyo.UPDATE.WHERE.ByKeyList(saveHanyoKeyList).Execute(saveHanyoDtl);

                //正常返し
                return new DaResponseBase();
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<BaseKoinReportVM> koinreportlist, List<BaseContactInfoReportVM> contactinforeportlist, IReadOnlyCollection<tm_euyosikiDto> rptDtl)
        {
            if (koinreportlist.Count != rptDtl.Count || contactinforeportlist.Count != rptDtl.Count)
            {
                return false;
            }
            return rptDtl.All(rptDto =>
                koinreportlist.Exists(k => k.rptid == rptDto.rptid && k.yosikiid == rptDto.yosikiid && k.upddttm == rptDto.upddttm)
                && contactinforeportlist.Exists(c => c.rptid == rptDto.rptid && c.yosikiid == rptDto.yosikiid && c.upddttm == rptDto.upddttm));
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(IReadOnlyList<tm_afhanyoDto> hanyoDtl, SonchoVM soncho, DairishaVM dairisha)
        {
            switch (hanyoDtl.Count)
            {
                case 0:
                    return soncho.upddttm == null && dairisha.upddttm == null;
                case 1:
                    var dto = hanyoDtl[0];
                    return (dto.hanyocd == EucConstant.SITYOMEI_HANYO_CD && dto.upddttm == soncho.upddttm && dairisha.upddttm == null) ||
                           (dto.hanyocd == EucConstant.DAIRISYA_HANYO_CD && dto.upddttm == dairisha.upddttm && soncho.upddttm == null);
                case 2:
                    return hanyoDtl.Count(x => x.hanyocd == EucConstant.SITYOMEI_HANYO_CD && x.upddttm == soncho.upddttm) == 1 &&
                           hanyoDtl.Count(x => x.hanyocd == EucConstant.DAIRISYA_HANYO_CD && x.upddttm == dairisha.upddttm) == 1;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 通知書一覧取得
        /// </summary>
        private DataTable GetData(DaDbContext db, string yosikikbn, string naigaikbn)
        {
            //通知書一覧取得
            var sql = $@"
                            select t3.rptid as rptid                 --帳票ID
                            , t3.rptnm as rptnm                      --帳票名
                            , t1.koinnmflg as koinnmflg              --市区町村印字
                            , t1.koinpicflg as koinpicflg            --電子更新印字
                            , t1.dairisyaflg as dairisyaflg          --職務代理者適用
                            , t1.yosikiid as yosikiid                --様式ID
                            , t1.toiawasesakicd as toiawasesakicd    --問い合わせ先
                            , t1.upddttm as upddttm                  --更新日時
                            , t1.kacd as kacd                        --課コード
                            , t1.kakaricd as kakaricd                --係コード
                            from tm_euyosiki t1 
                            left join tm_eurpt t3 on t1.rptid = t3.rptid 
                            left join tm_euyosikisyosai t4 on t1.rptid = t4.rptid  
                              and t1.yosikiid = t4.yosikiid  
                              and t4.yosikikbn = '{ yosikikbn }'        
                            where t1.naigaikbn = '{ naigaikbn }'                                                           
                            ".Trim();

            var rptDtl = DaDbUtil.GetDataTable(db, sql);

            return rptDtl;
        }

        /// <summary>
        /// 汎用マスタからドロップダウンリスト
        /// </summary>
        private List<DaSelectorModel> GetHanyoSelectorList(DaDbContext db, EnumHanyoKbn kbn)
        {
            return DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(kbn)).ToList();
        }
    }
}