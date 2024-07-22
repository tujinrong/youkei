// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票新規作成
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00202D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 初期化処理(帳票)
        /// </summary>
        public static List<ReportGroupVM> GetReportGroupVMList(IEnumerable<tm_eurptgroupDto> rptgroupDtl)
        {
            return rptgroupDtl.Select(GetRptGroupVM).ToList();
        }

        /// <summary>
        /// データソースリストを取得
        /// </summary>
        public static List<DatasourceVM> GetDataSourceVMList(IEnumerable<tm_eudatasourceDto> datasourceDtl)
        {
            return datasourceDtl.Select(GetDataSourceVM).OrderBy(e => e.datasourceid).ToList();
        }

        /// <summary>
        /// 様式種別詳細リストを取得
        /// </summary>
        public static List<YoshikiTypeVM> GetYoshikiTypeVMList() => Enum.GetValues<Enum様式種別>().Select(GetYoshikiTypeVM).ToList();

        /// <summary>
        ///初期化処理(別様式)
        /// </summary>
        public static List<ReportVM> GetReportVMList(IEnumerable<tm_eurptDto> rptDtl, IEnumerable<tm_euyosikisyosaiDto> yosikisyosaiDtl, IEnumerable<tm_eudatasourceDto> datasourceDtl,
            Dictionary<string, string> rptId2YosikiIdDic, IEnumerable<tm_eurptgroupDto> rptgroupDtl, IEnumerable<tm_afmeisyoDto> gyoumuList)
        {
            //様式詳細
            var rptIdYosikiId2DtoDic = yosikisyosaiDtl.ToDictionary(x => (x.rptid, x.yosikiid), x => x);
            //データソース
            var datasourceId2NmDic = datasourceDtl.ToDictionary(x => x.datasourceid, x => x.datasourcenm);
            //帳票グループ
            var rptGroupId2DtoDic = rptgroupDtl.ToDictionary(x => x.rptgroupid, x => x);
            //業務
            var gyoumucd2NmDic = gyoumuList.ToDictionary(x => x.nmcd, x => x.nm);

            return rptDtl.Select(x => rptId2YosikiIdDic.TryGetValue(x.rptid, out var yosikiId) && rptIdYosikiId2DtoDic.TryGetValue((x.rptid, yosikiId), out var yosikisyosaiDto)
                ? GetReportVM(x, yosikisyosaiDto, datasourceId2NmDic, rptGroupId2DtoDic, gyoumucd2NmDic)
                : null).Where(x => x != null).ToList()!;
        }

        /// <summary>
        /// サブ帳票初期化処理
        /// </summary>
        public static List<ReportWithYosikiVM> GetReportWithYosikiVMList(IEnumerable<tm_eurptDto> rptDtl, 
                                                                            IEnumerable<tm_euyosikisyosaiDto> yosikisyosaiDtl,
                                                                            Dictionary<string, HashSet<string>> rptId2YosikiIdsDic,
                                                                            IEnumerable<tm_eurptgroupDto> rptgroupDtl, 
                                                                            IEnumerable<tm_afmeisyoDto> gyoumuList)
        {
            //帳票グループ
            var rptGroupId2DtoDic = rptgroupDtl.ToDictionary(x => x.rptgroupid, x => x);
            //業務
            var gyoumucd2NmDic = gyoumuList.ToDictionary(x => x.nmcd, x => x.nm);

            return rptDtl.Select(x =>
            {
                if (!rptId2YosikiIdsDic.TryGetValue(x.rptid, out var yosikiIdSet) || !yosikiIdSet.Any())
                {
                    return null; 
                }

                var filteredYosikisyosaiDtl = yosikisyosaiDtl.Where(y => x.rptid == y.rptid && yosikiIdSet.Contains(y.yosikiid) && y.yosikieda == EucConstant.NOT_SUB_YOSIKIEDA).ToList();
                
                return !filteredYosikisyosaiDtl.Any() ? null : GetReportWithYosikiVM(x, filteredYosikisyosaiDtl, rptGroupId2DtoDic, gyoumucd2NmDic);
            }).Where(x => x != null).ToList()!;
        }

        /// <summary>
        /// 帳票初期化処理
        /// </summary>
        private static ReportGroupVM GetRptGroupVM(tm_eurptgroupDto dto)
        {
            var vm = new ReportGroupVM();
            vm.rptgroupid = dto.rptgroupid; //帳票グループID
            vm.rptgroupnm = dto.rptgroupnm; //帳票グループ名
            vm.gyoumucd = dto.gyomukbn;     //業務コード
            return vm;
        }

        /// <summary>
        /// データソース初期化処理
        /// </summary>
        private static DatasourceVM GetDataSourceVM(tm_eudatasourceDto dto)
        {
            var vm = new DatasourceVM();
            vm.datasourceid = dto.datasourceid; //データソースID
            vm.datasourcenm = dto.datasourcenm; //データソース名称
            vm.gyoumucd = dto.gyoumucd;         //業務コード
            return vm;
        }

        /// <summary>
        /// 別様式情報を取得
        /// </summary>
        private static ReportVM GetReportVM(tm_eurptDto rptDto, tm_euyosikisyosaiDto yosikisyosaiDto, IReadOnlyDictionary<string, string> datasourceId2NmDic,
            IReadOnlyDictionary<string, tm_eurptgroupDto> rptGroupId2DtoDic, IReadOnlyDictionary<string, string> gyoumucd2NmDic)
        {
            //データソース
            string? datasource = null;
            //帳票グループ
            var rptgroup = rptDto.rptgroupid;
            //業務区分
            var gyoumu = string.Empty;
            //データソース
            if (yosikisyosaiDto.yosikihouhou == Enum様式作成方法.データソース && !string.IsNullOrEmpty(yosikisyosaiDto.datasourceid))
            {
                //データソースId
                datasource = yosikisyosaiDto.datasourceid;
                if (datasourceId2NmDic.TryGetValue(yosikisyosaiDto.datasourceid, out var nm))
                {
                    //データソースID : データソース称
                    datasource = $"{yosikisyosaiDto.datasourceid}{DaConst.SELECTOR_DELIMITER}{nm}";
                }
            }

            //帳票グループ
            if (rptGroupId2DtoDic.TryGetValue(rptDto.rptgroupid, out var rptGroupDto))
            {
                //帳票グループID : 帳票グループ名称
                rptgroup = $"{rptGroupDto.rptgroupid}{DaConst.SELECTOR_DELIMITER}{rptGroupDto.rptgroupnm}";

                //業務区分
                gyoumu = rptGroupDto.gyomukbn;
                if (gyoumucd2NmDic.TryGetValue(rptGroupDto.gyomukbn, out var nm))
                {
                    //業務区分 : 業務区分名称
                    gyoumu = $"{rptGroupDto.gyomukbn}{DaConst.SELECTOR_DELIMITER}{nm}";
                }
            }

            var vm = new ReportVM();
            vm.rptid = rptDto.rptid;                                //帳票ID
            vm.rptnm = rptDto.rptnm;                                //帳票名
            return vm;
        }

        /// <summary>
        /// 様式作成方法を取得
        /// </summary>
        private static string GetYosikihouhou(tm_euyosikisyosaiDto yosikisyosaiDto)
        {
            //様式作成方法コード : 様式作成方法名称
            return $"{(int)yosikisyosaiDto.yosikihouhou}{DaConst.SELECTOR_DELIMITER}{yosikisyosaiDto.yosikihouhou}"; 
        }

        /// <summary>
        /// サブ帳票初期化処理
        /// </summary>
        private static ReportWithYosikiVM GetReportWithYosikiVM(tm_eurptDto rptDto, IEnumerable<tm_euyosikisyosaiDto> yosikisyosaiDtl, IReadOnlyDictionary<string, tm_eurptgroupDto> rptGroupId2DtoDic,
            IReadOnlyDictionary<string, string> gyoumucd2NmDic)
        {
            //帳票グループ
            var rptgroup = rptDto.rptgroupid;
            //業務
            var gyoumu = string.Empty;
            if (rptGroupId2DtoDic.TryGetValue(rptDto.rptgroupid, out var rptGroupDto))
            {
                //帳票グループID : 帳票グループ名称
                rptgroup = $"{rptGroupDto.rptgroupid}{DaConst.SELECTOR_DELIMITER}{rptGroupDto.rptgroupnm}";
                //業務区分
                gyoumu = rptGroupDto.gyomukbn;
                if (gyoumucd2NmDic.TryGetValue(rptGroupDto.gyomukbn, out var nm))
                {
                    //業務区分 : 業務区分名称
                    gyoumu = $"{rptGroupDto.gyomukbn}{DaConst.SELECTOR_DELIMITER}{nm}";
                }
            }

            var vm = new ReportWithYosikiVM();
            vm.rptid = rptDto.rptid;                                //帳票ID
            vm.rptnm = rptDto.rptnm;                                //帳票名
            vm.gyoumu = gyoumu;                                     //業務
            vm.rptgroup = rptgroup;                                 //帳票グループ
            vm.atenaflg = rptDto.atenaflg;                          //宛名フラグ
            vm.addresssealflg = rptDto.addresssealflg;              //アドレスシールフラグ
            vm.barcodesealflg = rptDto.barcodesealflg;              //バーコードシール出力フラグ
            vm.hagakiflg = rptDto.hagakiflg;                        //はがき出力フラグ
            vm.atenadaityoflg = rptDto.atenadaityoflg;              //宛名台帳出力フラグ
            vm.kensuhyonenreiflg = rptDto.kensuhyonenreiflg;        //件数表(年齢別)出力フラグ
            vm.kensuhyogyoseikuflg = rptDto.kensuhyogyoseikuflg;    //件数表(行政区別)出力フラグ
            //ドロップダウンリスト(様式)
            vm.selectorlist = yosikisyosaiDtl.Select(x => new DaSelectorModel(x.yosikiid, x.yosikinm)).ToList(); 
            return vm;
        }

        /// <summary>
        /// 帳票初期化処理
        /// </summary>
        private static YoshikiTypeVM GetYoshikiTypeVM(Enum様式種別 yosikisyubetu)
        {
            var vm = new YoshikiTypeVM();
            //様式種別
            vm.yosikisyubetu = yosikisyubetu;
            //様式種別詳細リスト
            vm.yosikikbnlist = EucConstant.YOSHIKI_TYPE_MAPPING_DIC.GetValueOrDefault(yosikisyubetu, new List<DaSelectorModel>()); 
            return vm;
        }
    }
}