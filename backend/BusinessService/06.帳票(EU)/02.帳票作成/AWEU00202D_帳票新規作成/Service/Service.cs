// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票新規作成
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00201G;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00202D
{
    [DisplayName("帳票新規作成")]
    public class Service : CmServiceBase
    {
        private const string CONFIG_GURACIONES = "新規作成";

        private static readonly List<DaSelectorModel> MEISAIFLG_OPTION = new()
        {
            new DaSelectorModel(true.ToString().ToLower(), Enum明細有無.明細あり.ToString()),
            new DaSelectorModel(false.ToString().ToLower(), Enum明細有無.明細なし.ToString()),
        };

        [DisplayName("初期化処理(帳票)")]
        public InitReportResponse InitReport(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitReportResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //帳票グループマスタ
                var rptgroupDtl = db.tm_eurptgroup.SELECT.SetSelectItems(nameof(tm_eurptgroupDto.rptgroupid), nameof(tm_eurptgroupDto.rptgroupnm), nameof(tm_eurptgroupDto.gyomukbn))
                    .ORDER.By(nameof(tm_eurptgroupDto.rptgroupid))
                    .GetDtoList();

                //EUCデータソースマスタ
                var datasourceDtl = db.tm_eudatasource.SELECT.SetSelectItems(nameof(tm_eudatasourceDto.datasourceid), nameof(tm_eudatasourceDto.datasourcenm), nameof(tm_eudatasourceDto.gyoumucd))
                    .ORDER.By(nameof(tm_eudatasourceDto.orderseq))
                    .GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(業務)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);
                //ドロップダウンリスト(作成方法)//TODO 後で元に戻す
                res.selectorlist2 = EucConstant.YOSIKIHOUHOU_OPTIONS.Where(item => item.label != Enum様式作成方法.SQL.ToString()).ToList();
                //ドロップダウンリスト(様式種別)
                res.selectorlist3 = EucConstant.YOSIKISYUBETU_OPTIONS;
                //ドロップダウンリスト(内外区分)
                res.selectorlist4 = EucConstant.NAIGAI_OPTIONS;
                //ドロップダウンリスト(明細有無)
                res.selectorlist5 = MEISAIFLG_OPTION;
                //ドロップダウンリスト(行列固定)
                res.selectorlist6 = EucConstant.MEISAIKOTEI_OPTIONS;
                //帳票グループリスト
                res.rptgrouplist = Wraper.GetReportGroupVMList(rptgroupDtl);
                //データソースリスト
                res.datasourcelist = Wraper.GetDataSourceVMList(datasourceDtl);
                //様式種別詳細リスト
                res.yoshikitypelist = Wraper.GetYoshikiTypeVMList();

                var functionList = DaEucBasicService.GetFunctionListPrefixed(db, EucConstant.EUC_FUNCTION_PREFIX);
                //関数リスト
                res.functionlist = functionList.Select(x => new DaSelectorModel(x.name, x.description)).ToList();
                //最初の行新規設定をプルダウンします
                res.functionlist.Insert(0, new DaSelectorModel(CONFIG_GURACIONES, string.Empty));

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(別様式)")]
        public InitOtherYosikiResponse InitOtherYosiki(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitOtherYosikiResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //業務リスト
                var gyoumuList = DaNameService.GetNameList(db, EnumNmKbn.EUC業務区分);
                //EUC帳票マスタ
                var rptDtl = db.tm_eurpt.SELECT.ORDER.By(nameof(tm_eurptDto.rptid)).GetDtoList();
                //帳票グループIDリスト
                var rptGroupIdList = rptDtl.Select(x => x.rptgroupid).Distinct().ToList();
                //帳票グループマスタ
                var rptgroupDtl = db.tm_eurptgroup.SELECT.WHERE.ByKeyList(rptGroupIdList).GetDtoList();

                var filter = $"{nameof(tm_euyosikiDto.rptid)} = ANY(@{nameof(tm_euyosikiDto.rptid)})";
                //EUC様式マスタから帳票の様式を取得
                var rptId2YosikiIdDic = db.tm_euyosiki.SELECT.SetSelectItems(nameof(tm_euyosikiDto.rptid), nameof(tm_euyosikiDto.yosikiid))
                    .WHERE.ByFilter(filter, rptDtl.Select(x => x.rptid).ToArray() as object)
                    .ORDER.By(nameof(tm_euyosikiDto.orderseq), nameof(tm_euyosikiDto.regdttm))
                    .GetDtoList()
                    .GroupBy(x => x.rptid)
                    .ToDictionary(g => g.Key, g => g.First().yosikiid);

                var keyList = rptId2YosikiIdDic.Select(pair => new object[] { pair.Key, pair.Value, EucConstant.NOT_SUB_YOSIKIEDA }).ToList();

                //EUC様式詳細マスタ
                var yosikisyosaiDtl = db.tm_euyosikisyosai.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //データソースIdリストを取得
                var datasourceIdSet = yosikisyosaiDtl.Where(x => !string.IsNullOrEmpty(x.datasourceid))
                .Select(x => x.datasourceid!).ToHashSet();

                filter = $"{nameof(tm_eudatasourceDto.datasourceid)} = ANY(@{nameof(tm_eudatasourceDto.datasourceid)})";
                //EUCデータソースマスタを取得
                var datasourceDtl = db.tm_eudatasource.SELECT.SetSelectItems(nameof(tm_eudatasourceDto.datasourceid), nameof(tm_eudatasourceDto.datasourcenm))
                    .WHERE.ByFilter(filter, datasourceIdSet.ToArray() as object).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理TODOi
                //-------------------------------------------------------------
                //帳票情報リスト
                res.reportlist = Wraper.GetReportVMList(rptDtl, yosikisyosaiDtl, datasourceDtl, rptId2YosikiIdDic, rptgroupDtl, gyoumuList);
                //ドロップダウンリスト(様式種別)
                res.selectorlist1 = EucConstant.YOSIKISYUBETU_OPTIONS;
                //ドロップダウンリスト(内外区分)
                res.selectorlist2 = EucConstant.NAIGAI_OPTIONS;
                //ドロップダウンリスト(明細有無)
                res.selectorlist3 = MEISAIFLG_OPTION;
                //ドロップダウンリスト(行列固定)
                res.selectorlist4 = EucConstant.MEISAIKOTEI_OPTIONS;
                //様式種別詳細リスト
                res.yoshikitypelist = Wraper.GetYoshikiTypeVMList();

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(サブ帳票)")]
        public InitSubReportResponse InitSubReport(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitSubReportResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //業務
                var gyoumuList = DaNameService.GetNameList(db, EnumNmKbn.EUC業務区分);
                //EUC帳票マスタ
                var rptDtl = db.tm_eurpt.SELECT.ORDER.By(nameof(tm_eurptDto.orderseq)).GetDtoList();
                //帳票グループIDリスト
                var rptGroupIdList = rptDtl.Select(x => x.rptgroupid).Distinct().ToList();
                //帳票グループマスタ
                var rptgroupDtl = db.tm_eurptgroup.SELECT.WHERE.ByKeyList(rptGroupIdList).GetDtoList();

                const string filter = $"{nameof(tm_euyosikiDto.rptid)} = ANY(@{nameof(tm_euyosikiDto.rptid)})";
                //EUC様式マスタから帳票の様式を取得
                var yosikiDtl = db.tm_euyosiki.SELECT.SetSelectItems(nameof(tm_euyosikiDto.rptid), nameof(tm_euyosikiDto.yosikiid))
                    .WHERE.ByFilter(filter, rptDtl.Select(x => x.rptid).ToArray() as object)
                    .ORDER.By(nameof(tm_euyosikiDto.orderseq), nameof(tm_euyosikiDto.regdttm))
                    .GetDtoList();

                var rptId2YosikiIdsDic = yosikiDtl.GroupBy(x => x.rptid).ToDictionary(g => g.Key, g => g.Select(d => d.yosikiid).ToHashSet());

                var keyList = yosikiDtl.Select(x => new object[] { x.rptid, x.yosikiid, EucConstant.NOT_SUB_YOSIKIEDA }).ToList();

                //EUC様式詳細マスタ
                var yosikisyosaiDtl = db.tm_euyosikisyosai.SELECT.WHERE.ByKeyList(keyList).ORDER.By(nameof(tm_euyosikisyosaiDto.regdttm)).GetDtoList();

                //EUCデータソースマスタ
                var datasourceDtl = db.tm_eudatasource.SELECT.SetSelectItems(nameof(tm_eudatasourceDto.datasourceid), nameof(tm_eudatasourceDto.datasourcenm), nameof(tm_eudatasourceDto.gyoumucd))
                    .ORDER.By(nameof(tm_eudatasourceDto.orderseq))
                    .GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理TODOi
                //-------------------------------------------------------------
                //ドロップダウンリスト(作成方法)
                res.selectorlist1 = EucConstant.YOSIKIHOUHOU_OPTIONS;
                //ドロップダウンリスト(帳票種別)
                res.selectorlist2 = EucConstant.YOSIKISYUBETU_OPTIONS;
                //ドロップダウンリスト(明細有無)
                res.selectorlist3 = MEISAIFLG_OPTION;
                //ドロップダウンリスト(行列固定)
                res.selectorlist4 = EucConstant.MEISAIKOTEI_OPTIONS;
                //データソースリスト
                res.datasourcelist = Wraper.GetDataSourceVMList(datasourceDtl);
                //ドロップダウンリスト(帳票様式)
                res.reportwithyosikilist = Wraper.GetReportWithYosikiVMList(rptDtl, yosikisyosaiDtl, rptId2YosikiIdsDic, rptgroupDtl, gyoumuList);
                //様式種別詳細リスト
                res.yoshikitypelist = Wraper.GetYoshikiTypeVMList();

                //正常返し
                return res;
            });
        }

        [DisplayName("チェック処理(次へ押下)")]
        public DaResponseBase Check(CheckRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (req.kbn == Enum帳票様式.帳票)
                {
                    //帳票IDの存在チェック
                    if (db.tm_eurpt.SELECT.WHERE.ByKey(req.rptid).Exists())
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "帳票ID");
                        res.SetServiceError(msg);
                        return res;
                    }

                    //帳票名の存在チェック
                    if (db.tm_eurpt.SELECT.WHERE.ByFilter("rptnm = @rptnm", req.rptnm).Exists())
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "帳票名");
                        res.SetServiceError(msg);
                        return res;
                    }
                }

                //様式名の存在チェック
                var stylefilter = $"{nameof(tm_euyosikisyosaiDto.rptid)} = @{nameof(tm_euyosikisyosaiDto.rptid)} and {nameof(tm_euyosikisyosaiDto.yosikinm)} = @{nameof(tm_euyosikisyosaiDto.yosikinm)}";
                if (db.tm_euyosikisyosai.SELECT.WHERE.ByFilter(stylefilter, req.rptid, req.yosikinm).Exists())
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "様式名");
                    res.SetServiceError(msg);
                    return res;
                }

                //正常返し
                return res;
            });
        }
    }
}