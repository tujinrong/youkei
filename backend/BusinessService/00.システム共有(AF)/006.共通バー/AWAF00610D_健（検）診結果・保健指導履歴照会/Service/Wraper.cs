// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診結果・保健指導履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.13
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00610D
{
    public class Wraper : CmWraperBase
    {
        private const string FUSYOSTR = "不詳";                             //不詳フラグ判定用

        /// <summary>
        /// 宛名情報(共通)
        /// </summary>
        public static PersonHeaderVM GetVM(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new PersonHeaderVM();
            vm = (PersonHeaderVM)Common.Wraper.GetHeaderVM(db, vm, dto);
            vm.atenano = dto.atenano;                                   //宛名番号 

            return vm;
        }

        /// <summary>
        /// 健（検）診結果・保健指導履歴照会情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, tt_afatenaDto dto,
                                                            List<tm_kksonotasidojigyoDto> dtljigyo,
                                                            List<DaSelectorModel> staffnms, List<tm_afhanyoDto> dtlhanyo,
                                                            List<tm_shkensinjigyoDto> dtlshkensin, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, dto, dtljigyo, staffnms, dtlhanyo, dtlshkensin, r)).ToList();
        }

        /// <summary>
        /// 健（検）診結果・保健指導履歴照会情報を取得
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afatenaDto dto,
                                                   List<tm_kksonotasidojigyoDto> dtljigyo,
                                                   List<DaSelectorModel> staffnms, List<tm_afhanyoDto> dtlhanyo,
                                                   List<tm_shkensinjigyoDto> dtlshkensin, DataRow row)
        {
            RowVM vm = new RowVM();

            //実施時年齢
            string bymd = CStr(dto.bymd);
            bool bymd_fusyoflg = CBool(dto.bymd_fusyoflg);
            string jissiymd = row.Wrap(nameof(tt_shkensinDto.jissiymd));
            if (CDate(bymd) > CDate(jissiymd))
            {
                vm.jissiage = FUSYOSTR;
            }
            else
            {
                vm.jissiage = CmLogicUtil.GetAgeStr2(bymd_fusyoflg, bymd, CDate(jissiymd));
            }
            //健（検）診種別
            string jigyocd = row.Wrap(nameof(tt_shkensinDto.jigyocd));
            //一次 / 精密の場合のみ、値を設定
            string kskbn = row.Wrap(nameof(vm.kskbn));
            if (!string.IsNullOrEmpty(kskbn))
            {
                vm.kstype = string.IsNullOrEmpty(jigyocd) ? string.Empty :
                            DaHanyoService.GetName(db, EnumHanyoKbn.検診種別, Enum名称区分.名称, jigyocd);
            }
            //健（検）診年月日
            vm.ksymd = row.Wrap(nameof(vm.ksymd));
            //一次 / 精密
            vm.kskbn = string.IsNullOrEmpty(kskbn) ? string.Empty :
                       DaSelectorService.GetName(db, kskbn, Enum名称区分.略称,
                       Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.成人保健フリー項目グループ１));
            //検査方法
            var dto2 = dtlshkensin.Where(e => e.jigyocd == jigyocd).FirstOrDefault();
            if (dto2 != null)
            {
                //汎用マスタ
                string hanyomaincd = CStr(dto2.kensahoho_maincd);
                int hanyosubcd = CInt(dto2.kensahoho_subcd);
                string kensahohocd = row.Wrap(nameof(tt_shkensinDto.kensahohocd));
                if (string.IsNullOrEmpty(kensahohocd))
                {
                    vm.kshoho = string.Empty;
                }
                else
                {
                    vm.kshoho = CStr(DaHanyoService.GetHanyoDto(db, hanyomaincd, hanyosubcd, kensahohocd)?.nm);
                }
            }
            //保健指導区分コード
            string hskbn = row.Wrap(nameof(tt_kkhokensido_kekkaDto.hokensidokbn));
            vm.hokensidokbn = hskbn;
            //業務区分
            vm.gyomukbn = row.Wrap(nameof(tt_kkhokensido_kekkaDto.gyomukbn));
            //保健指導区分
            string hskbnnm = string.IsNullOrEmpty(hskbn) ? string.Empty :
                       DaSelectorService.GetName(db, hskbn, Enum名称区分.略称,
                       Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.指導区分));
            string gyomukbnnm = string.IsNullOrEmpty(vm.gyomukbn) ? string.Empty :
                       DaSelectorService.GetName(db, vm.gyomukbn, Enum名称区分.略称,
                       Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.拡張_予約_保健指導業務区分));
            vm.hskbnnm = string.IsNullOrEmpty(gyomukbnnm) ? hskbnnm :
                        $"{hskbnnm}（{gyomukbnnm}）";

            //事業コード
            vm.jigyocd = jigyocd;
            //事業名
            var dtojigyo = dtljigyo.Where(e => e.jigyocd == jigyocd).FirstOrDefault();
            if (dtojigyo != null && string.IsNullOrEmpty(kskbn))
            {
                //一次 / 精密以外の場合、値を設定
                vm.jigyonm = dtojigyo.jigyonm;
            }
            //実施日
            vm.jissiymd = row.Wrap(nameof(tt_kkhokensido_kekkaDto.jissiymd));
            //実施時間
            string tmf = row.Wrap(nameof(tt_kkhokensido_kekkaDto.tmf));
            tmf = string.IsNullOrEmpty(tmf) ? "" : tmf.Insert(2, DaStrPool.COLON); //開始時間
            string tmt = row.Wrap(nameof(tt_kkhokensido_kekkaDto.tmt));
            tmt = string.IsNullOrEmpty(tmt) ? "" : tmt.Insert(2, DaStrPool.COLON); //終了時間
            if (!string.IsNullOrEmpty(tmf) || !string.IsNullOrEmpty(tmt))
            {
                vm.jissitm = $"{tmf}{DaStrPool.C_TILDE_FULL}{tmt}";
            }
            //実施者
            vm.jissistaffnm = CStr(CommaStrToCommaStr2(row.Wrap($"jissi{nameof(tt_kkhokensido_staffDto.staffid)}"), staffnms, true));
            //枝番
            vm.edano = CInt(row.Wrap(nameof(tt_kkhokensido_kekkaDto.edano)));
            //年度
            vm.nendo = CInt(row.Wrap(nameof(tt_shkensinDto.nendo)));
            //検診回数
            vm.kensinkaisu = CInt(row.Wrap(nameof(tt_shkensinDto.kensinkaisu)));

            return vm;
        }
    }
}
