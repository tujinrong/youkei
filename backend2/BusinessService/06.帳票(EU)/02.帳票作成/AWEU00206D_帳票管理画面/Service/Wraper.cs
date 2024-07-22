// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理画面 
// 　　　　    DB項目から画面項目に変換　　 
// 作成日　　: 2024.01.16
// 作成者　　: ショウ
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00206D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 印字設定情報リストを取得
        /// </summary>
        public static List<KoinReportVM> GetKoinReportVMList(DataTable rptDtl)
        {
            var koinReportList = new List<KoinReportVM>(rptDtl.Rows.Count);
            foreach (DataRow row in rptDtl.Rows)
            {
                //帳票名
                var rptnm = row.Wrap(nameof(ContactInfoReportVM.rptnm));
                //帳票ID
                var rptid = row.Wrap(nameof(ContactInfoReportVM.rptid));
                if (!string.IsNullOrEmpty(rptnm) && !string.IsNullOrEmpty(rptid))
                {
                    //印字設定情報を取得
                    koinReportList.Add(GetKoinReportVM(row));
                }
            }

            return koinReportList;
        }

        /// <summary>
        /// 問い合わせ先設定情報リストを取得
        /// </summary>
        public static List<ContactInfoReportVM> GetContactInfoReportVMList(DataTable rptDtl, List<tm_afhanyoDto> hanyoDtl)
        {
            var contactInfoReportVMList = new List<ContactInfoReportVM>(rptDtl.Rows.Count);
            foreach (DataRow row in rptDtl.Rows)
            {
                //帳票名
                var rptnm = row.Wrap(nameof(ContactInfoReportVM.rptnm));
                //帳票ID
                var rptid = row.Wrap(nameof(ContactInfoReportVM.rptid));
                if (!string.IsNullOrEmpty(rptnm) && !string.IsNullOrEmpty(rptid))
                {
                    //問い合わせ先設定情報を取得
                    contactInfoReportVMList.Add(GetContactInfoReportVM(row, hanyoDtl));
                }
            }

            return contactInfoReportVMList;
        }

        /// <summary>
        /// 職務代理者情報を取得
        /// </summary>
        public static DairishaVM GetDairishaVM(List<tm_afhanyoDto> hanyoDtl)
        {
            var vm = new DairishaVM();

            var dto = hanyoDtl.Find(x => x.hanyocd == EucConstant.DAIRISYA_HANYO_CD);
            var dto1 = hanyoDtl.Find(x => x.hanyocd == EucConstant.DAIRIMEI_HANYO_CD);
            if (dto == null || dto1 == null)
            {
                return vm;
            }

            vm.dairimei = CStr(dto1.nm);            //職務代理名
            vm.dairisha = CStr(dto.nm);             //職務代理者
            vm.dairiymdf = CNDate(dto.hanyokbn1);   //代理適用年月日（開始）
            vm.dairiymdt = CNDate(dto.hanyokbn2);   //代理適用年月日（終了）
            vm.upddttm = dto.upddttm;               //更新日時
            return vm;
        }

        /// <summary>
        /// 市区町村長情報を取得
        /// </summary>
        public static SonchoVM GetSonchoVM(List<tm_afhanyoDto> hanyoDtl)
        {
            var vm = new SonchoVM();

            var dto = hanyoDtl.Find(x => x.hanyocd == EucConstant.SITYOMEI_HANYO_CD);
            if (dto == null)
            {
                return vm;
            }

            vm.sonchomei = CStr(dto.nm);    //市区町村長名
            vm.upddttm = dto.upddttm;       //更新日時
            return vm;
        }
        
        /// <summary>
        /// 印字設定情報を取得
        /// </summary>
        private static KoinReportVM GetKoinReportVM(DataRow row)
        {
            var vm = new KoinReportVM();
            vm.rptid = row.Wrap(nameof(vm.rptid));              //帳票ID
            vm.rptnm = row.Wrap(nameof(vm.rptnm));              //帳票名
            vm.yosikiid = row.Wrap(nameof(vm.yosikiid));        //様式ID
            vm.koinnmflg = row.CBool(nameof(vm.koinnmflg));     //市区町村長名の印字フラグ
            vm.koinpicflg = row.CBool(nameof(vm.koinpicflg));   //電子公印の印字フラグ
            vm.dairisyaflg = row.CBool(nameof(vm.dairisyaflg)); //電子公印の職務代理者適用フラグ
            vm.upddttm = row.CDate(nameof(vm.upddttm));         //更新日時
            return vm;
        }

        /// <summary>
        /// 問い合わせ先設定情報を取得
        /// </summary>
        private static ContactInfoReportVM GetContactInfoReportVM(DataRow row, List<tm_afhanyoDto> hanyoDtl)
        {
            var vm = new ContactInfoReportVM();
            vm.rptid = row.Wrap(nameof(vm.rptid));                      //帳票ID
            vm.rptnm = row.Wrap(nameof(vm.rptnm));                      //帳票名
            vm.yosikiid = row.Wrap(nameof(vm.yosikiid));                //様式ID
            vm.toiawasesakicd = row.Wrap(nameof(vm.toiawasesakicd));    //問い合わせ先コード
            vm.kakaricd = row.Wrap(nameof(vm.kakaricd));                //係コード
            vm.kacd = row.Wrap(nameof(vm.kacd));                        //課コード

            var dto = hanyoDtl.Find(x => x.hanyocd == vm.toiawasesakicd);
            if (dto != null)
            {
                vm.nm = dto.nm;                         //名称
                vm.detail = CStr(dto.hanyokbn1);        //詳細
            }

            vm.upddttm = row.CDate(nameof(vm.upddttm)); //更新日時
            return vm;
        }
    }
}