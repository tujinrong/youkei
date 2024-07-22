// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行対象外者管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.20
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK01001G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 一覧取得(一覧画面)
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg, adrsFlg)).ToList();
        }

        /// <summary>
        /// 一覧取得(明細画面)
        /// </summary>
        public static List<InitVM> GetVMList(DaDbContext db, List<tm_eurptgroupDto> mstDtl2, List<tt_kkrpthakkotaisyogaisyaDto> dtl)
        {
            var list = new List<InitVM>();
            foreach (var group in mstDtl2)
            {
                var vm = new InitVM();
                vm.rptgroupid = group.rptgroupid;                                                                      //帳票グループID
                vm.rptgroupnm = group.rptgroupnm;                                                                      //帳票グループ名
                vm.gyomukbn = group.gyomukbn!;                                                                         //業務区分(フィルター用)
                vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.EUC業務区分, group.gyomukbn);        //業務区分名
                //その他項目設定
                vm = GetVM(vm, dtl);
                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 一覧画面一覧情報(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new RowVM();
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                   //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                  //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));            //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                              //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                     //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                            //住所
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, row);                       //行政区
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                         //住民区分
            var taisyogaikbn = row.CBool(nameof(RowVM.taisyogaikbn));               //対象外者区分
            vm.taisyogaikbn = FormatFlgStr(taisyogaikbn);                           //対象外者区分(○)
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));          //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);     //警告内容

            return vm;
        }

        /// <summary>
        /// 明細画面一覧情報(1行)
        /// </summary>
        private static InitVM GetVM(InitVM vm, List<tt_kkrpthakkotaisyogaisyaDto> dtl)
        {
            var dto = dtl.Find(e => e.rptgroupid == vm.rptgroupid);
            if (dto != null)
            {
                vm.taisyogaikbn = true;                         //対象外者区分
                vm.uketukeymd = dto.uketukeymd;                 //受付日
                vm.taisyogairiyu = CStr(dto.taisyogairiyu);     //対象外理由
                vm.upddttm = dto.upddttm;                       //更新日時
            }
            else
            {
                vm.taisyogaikbn = false;                        //対象外者区分
            }
            return vm;
        }
    }
}