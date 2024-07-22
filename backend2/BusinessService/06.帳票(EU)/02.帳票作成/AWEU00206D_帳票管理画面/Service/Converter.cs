// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理画面 
// 　　　　    画面項目からDB項目に変換　　 
// 作成日　　: 2024.01.16
// 作成者　　: ショウ
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00206D
{
    public class Converter : CmConerterBase
    {
        internal static readonly string SUB_CD = ((long)EnumHanyoKbn.自治体情報 % DaNameService.MAINCODE_DIGIT).ToString();
        internal static readonly string MAIN_CD = ((long)EnumHanyoKbn.自治体情報 / DaNameService.MAINCODE_DIGIT).ToString();

        /// <summary>
        /// EUC様式マスタ情報を取得
        /// </summary>
        public static List<tm_euyosikiDto> GetSaveRptDtl(List<BaseKoinReportVM> koinreportlist, List<BaseContactInfoReportVM> contactinforeportlist, IEnumerable<tm_euyosikiDto> rptDtl)
        {
            return rptDtl.Select(x => GetSaveRptDto(x, koinreportlist, contactinforeportlist)).ToList();
        }

        /// <summary>
        /// 公印マスタ情報を取得
        /// </summary>
        public static tm_eukoinDto GetKoinDto(List<DaFileModel> files)
        {
            if (files.Count != 2)
            {
                throw new ArgumentException(null, nameof(files));
            }

            var dto = new tm_eukoinDto();
            dto.koinid = EucConstant.KOIN_INFO_ID;      //公印ID
            dto.sikutyosontyokoin = files[0].filedata;  //市区町村長公印
            dto.dairisyakoin = files[1].filedata;       //職務代理者公印
            return dto;
        }

        /// <summary>
        /// 汎用マスタ(市区町村長名+職務代理者)情報を取得
        /// </summary>
        public static List<tm_afhanyoDto> GetHanyoDtl(List<tm_afhanyoDto> dtl, SonchoVM soncho, DairishaVM dairisha)
        {
            var sonchoHanyoDto = dtl.Find(x => x.hanyocd == EucConstant.SITYOMEI_HANYO_CD);
            var dairishaHanyoDto = dtl.Find(x => x.hanyocd == EucConstant.DAIRISYA_HANYO_CD);

            //市区町村長情報を取得
            var dtl1 = GetSonchoInfoDto(sonchoHanyoDto, soncho);
            //職務代理者情報を取得
            var dtl2 = GetDairishaHanyoDto(dairishaHanyoDto, dairisha);

            return new List<tm_afhanyoDto> { dtl1, dtl2 };
        }

        /// <summary>
        /// 職務代理者情報を取得
        /// </summary>
        private static tm_afhanyoDto GetDairishaHanyoDto(tm_afhanyoDto? dto, DairishaVM dairisha)
        {
            dto ??= new tm_afhanyoDto();
            dto.hanyomaincd = MAIN_CD;                                          //汎用メインコード
            dto.hanyosubcd = CInt(SUB_CD);                                      //汎用サブコード
            dto.hanyocd = EucConstant.DAIRISYA_HANYO_CD;                        //汎用コード
            dto.nm = CStr(dairisha.dairisha);                                   //名称
            dto.hanyokbn1 = dairisha.dairiymdf?.ToString(DaConst.DateFormat);   //汎用区分1
            dto.hanyokbn2 = dairisha.dairiymdt?.ToString(DaConst.DateFormat);   //汎用区分2
            dto.stopflg = false;
            return dto;
        }

        /// <summary>
        /// 市区町村長情報を取得
        /// </summary>
        private static tm_afhanyoDto GetSonchoInfoDto(tm_afhanyoDto? dto, SonchoVM soncho)
        {
            dto ??= new tm_afhanyoDto();
            dto.hanyomaincd = MAIN_CD;                  //汎用メインコード
            dto.hanyosubcd = CInt(SUB_CD);              //汎用サブコード
            dto.hanyocd = EucConstant.SITYOMEI_HANYO_CD;  //汎用コード
            dto.nm = CStr(soncho.sonchomei);            //名称
            dto.stopflg = false;
            return dto;
        }

        /// <summary>
        ///  EUC様式マスタ情報を取得
        /// </summary>
        private static tm_euyosikiDto GetSaveRptDto(tm_euyosikiDto rptDto, List<BaseKoinReportVM> koinreportlist, List<BaseContactInfoReportVM> contactinforeportlist)
        {
            //公印情報
            var koinReportVm = koinreportlist.Find(k => k.rptid == rptDto.rptid && k.yosikiid == rptDto.yosikiid)!;
            //問い合わせ先設定情報
            var contactInfoReportVm = contactinforeportlist.Find(c => c.rptid == rptDto.rptid && c.yosikiid == rptDto.yosikiid)!;

            rptDto.koinnmflg = koinReportVm.koinnmflg;                  //市区町村長名の印字フラグ
            rptDto.koinpicflg = koinReportVm.koinpicflg;                //電子公印の印字フラグ
            rptDto.dairisyaflg = koinReportVm.dairisyaflg;              //電子公印の職務代理者適用フラグ
            rptDto.toiawasesakicd = contactInfoReportVm.toiawasesakicd; //問い合わせ先コード
            rptDto.kakaricd = contactInfoReportVm.kakaricd;             //係コード
            rptDto.kacd = contactInfoReportVm.kacd;                     //課コード
            return rptDto;
        }
    }
}