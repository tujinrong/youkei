// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.09.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00606D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 個人基本情報(ヘッダー部)
        /// </summary>
        public static HeaderVM GetVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new HeaderVM();

            vm = (HeaderVM)Common.Wraper.GetHeaderVM(db, vm, dto, alertviewflg);
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, dto.gyoseikucd);                        //行政区

            return vm;
        }

        /// <summary>
        /// 住民情報その他情報
        /// </summary>
        public static Tab1DetailVM GetVM(DaDbContext db, tt_afatenaDto dto, List<tt_afatenaDto> dtl, bool alertviewflg)
        {
            var vm = new Tab1DetailVM();
            var agekijunymd_nendo = DaUtil.GetNendoLastday();                                       //基準日(年度末)
            vm.age_nendo = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd, agekijunymd_nendo);   //年齢(年度末)
            vm.agekijunymd_nendo = FormatWaKjYMD(agekijunymd_nendo);                                //年齢計算基準日(年度末)
            vm.setaino = dto.setaino;                                                               //世帯番号
            vm.kekkalist = GetVMList(db, dtl, alertviewflg);                                        //世帯情報一覧

            return vm;
        }

        /// <summary>
        /// 課税・保険・介護情報
        /// </summary>
        public static Tab2DetailVM GetVM(DaDbContext db, tt_afatenaDto dto1, tt_afkojinzeikazeiDto? dto2, tt_afkokuhoDto? dto3, tt_afkokihokenDto? dto4, tt_afseihoDto? dto5, tt_afkaigoDto? dto6)
        {
            var vm = new Tab2DetailVM();
            vm.kazeikbn_setai = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, CStr(dto1.kazeikbn_setai));                 //課税非課税区分（世帯）
            vm.hokenkbn = DaNameService.GetName(db, EnumNmKbn.保険区分_共通管理, CStr(dto1.hokenkbn));                          //保険区分
            vm.kazeikbn = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, CStr(dto2?.kazeikbn));                            //課税非課税区分
            vm.kokuho_kigono = CStr(dto3?.kokuho_kigono);                                                                       //国保記号番号
            vm.kokuho_edano = CStr(dto3?.kokuho_edano);                                                                         //枝番
            vm.kokuho_sikakusyutokuymd = FormatWaKjYMD(CNDate(dto3?.kokuho_sikakusyutokuymd));                                  //国保資格取得年月日
            vm.kokuho_sikakusosituymd = FormatWaKjYMD(CNDate(dto3?.kokuho_sikakusosituymd));                                    //国保資格喪失年月日
            vm.hihokensyano1 = CStr(dto4?.hihokensyano);                                                                        //被保険者番号(後期高齢者医療)
            vm.hiho_sikakusyutokuymd = FormatWaKjYMD(CNDate(dto4?.hiho_sikakusyutokuymd));                                      //被保険者資格取得年月日
            vm.hiho_sikakusosituymd = FormatWaKjYMD(CNDate(dto4?.hiho_sikakusosituymd));                                        //被保険者資格喪失年月日
            vm.seihoymdf = FormatWaKjYMD(CNDate(dto5?.seihoymdf));                                                              //生活保護開始年月日
            vm.teisiymd = FormatWaKjYMD(CNDate(dto5?.teisiymd));                                                                //停止年月日
            vm.teisikaijoymd = FormatWaKjYMD(CNDate(dto5?.teisikaijoymd));                                                      //停止解除年月日
            vm.haisiymd = FormatWaKjYMD(CNDate(dto5?.haisiymd));                                                                //廃止年月日
            vm.yokaigojotaikbnnm = DaNameService.GetName(db, EnumNmKbn.要介護状態区分コード, CStr(dto6?.yokaigojotaikbncd));    //要介護状態区分(名称)
            vm.hihokensyano2 = CStr(dto6?.hihokensyano);                                                                        //被保険者番号(介護保険)
            vm.yokaigoninteiymd = FormatWaKjYMD(CNDate(dto6?.yokaigoninteiymd));                                                //要介護認定日
            vm.yokaigoyukoymdf = FormatWaKjYMD(CNDate(dto6?.yokaigoyukoymdf));                                                  //要介護認定有効期間開始日
            vm.yokaigoyukoymdt = FormatWaKjYMD(CNDate(dto6?.yokaigoyukoymdt));                                                  //要介護認定有効期間終了日

            return vm;
        }

        /// <summary>
        /// 世帯情報一覧
        /// </summary>
        private static List<RowVM> GetVMList(DaDbContext db, List<tt_afatenaDto> dtl, bool alertviewflg)
        {
            var list = new List<RowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetRowVM(db, dto, alertviewflg));
            }
            return list;
        }

        /// <summary>
        /// 世帯情報(1行)
        /// </summary>
        private static RowVM GetRowVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new RowVM();
            vm.atenano = dto.atenano;                                                           //宛名番号
            vm.name = dto.simei_yusen;                                                          //氏名
            vm.kname = CStr(dto.simei_kana_yusen);                                              //カナ氏名
            vm.zokuhyoki = dto.zokuhyoki;                                                       //続柄
            vm.sex = CmLogicUtil.GetSex(db, dto.sex);                                           //性別
            vm.bymd = CmLogicUtil.GetYMDStr(dto.bymd_fusyoflg, dto.bymd, dto.bymd_fusyohyoki);  //生年月日
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, dto.juminkbn);          //住民区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto.siensotikbn, alertviewflg);             //警告内容
            //除票者の判断：住民区分 >＝ 5
            vm.stopflg = (CInt(dto.juminkbn) >= 5);                                             //除票者フラグ

            return vm;
        }
    }
}