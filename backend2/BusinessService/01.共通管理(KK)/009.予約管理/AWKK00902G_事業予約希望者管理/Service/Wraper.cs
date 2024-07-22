// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業予約希望者管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.03.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00902G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 日程情報一覧
        /// </summary>
        public static List<NitteiRowVM> GetVMList(DaDbContext db, DataRowCollection rows, List<DaSelectorModel> list1, List<DaSelectorModel> list2)
        {
            List<NitteiRowVM> list = new List<NitteiRowVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row, list1, list2));
            }
            return list;
        }

        /// <summary>
        /// コース情報一覧
        /// </summary>
        public static List<CourseRowVM> GetVMList(DataRowCollection rows, List<DaSelectorModel> list1, List<DaSelectorModel> list2)
        {
            List<CourseRowVM> list = new List<CourseRowVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(row, list1, list2));
            }
            return list;
        }

        /// <summary>
        /// コース情報(ヘッダー)
        /// </summary>
        public static CourseHeaderVM GetHeaderVM(DaDbContext db, tt_kkjigyoyoteicourseDto dto, DataRow row)
        {
            var vm = new CourseHeaderVM();
            var gyomukbn = row.Wrap(nameof(tm_kksonotasidojigyoDto.gyomukbn));                          //業務区分
            vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.拡_予約_保健指導業務区分, gyomukbn);  //業務区分名
            vm.coursenm = CStr(dto.coursenm);                                                           //コース名

            return vm;
        }

        /// <summary>
        /// 日程基本情報(ヘッダー)
        /// </summary>
        public static PersonHeaderVM GetHeaderVM(DaDbContext db, tt_kkjigyoyoteiDto dto1, tm_kksonotasidojigyoDto dto2, tt_kkjigyoyoteicourseDto? dto3,
                                                List<string> staffids, List<DaSelectorModel> list1, List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            var vm = new PersonHeaderVM();
            vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.拡_予約_保健指導業務区分, dto2.gyomukbn); //業務区分名
            vm.jigyonm = dto2.jigyonm;                                                                      //その他日程事業・保健指導事業名
            vm.jissinaiyo = dto1.jissinaiyo;                                                                //実施内容
            vm.courseno = dto1.courseno;                                                                    //コース番号
            vm.coursenm = CStr(dto3?.coursenm);                                                             //コース名
            vm.kaisu = dto1.kaisu;                                                                          //回数
            vm.jissiyoteiymd = dto1.jissiyoteiymd;                                                          //実施予定日
            vm.tmf = FormatTime(dto1.tmf);                                                                  //開始時間
            vm.tmt = FormatTime(dto1.tmt);                                                                  //終了時間
            vm.kaijonm = CStr(list1.Find(e => e.value == dto1.kaijocd)?.label);                             //会場名
            vm.kikannm = CStr(list2.Find(e => e.value == dto1.kikancd)?.label);                             //医療機関名
            var staffnmList = staffids.Select(e => list3.Find(a => a.value == e)!.label).ToList();
            vm.staffnms = string.Join(DaStrPool.C_COMMA2, staffnmList);                                     //担当者一覧

            return vm;
        }

        /// <summary>
        /// 日程基本情報(明細)
        /// </summary>
        public static PersonDetailVM GetVM(tt_kkjigyoyoteiDto dto, List<tt_kkjigyoyoyakukibosyaDto> dtl)
        {
            var vm = new PersonDetailVM();
            vm.teiin = dto.teiin;                                   //定員
            var ct1 = CInt(dtl.Where(e => e.cancelmatiflg == Enum待機フラグ.希望しない).ToList().Count());
            vm.moushikominum = ct1 == 0 ? null : ct1;               //申込人数
            var ct2 = CInt(dtl.Where(e => e.cancelmatiflg == Enum待機フラグ.希望する).ToList().Count());
            vm.taikinum = ct2 == 0 ? null : ct2;                    //待機人数
            vm.status = CmLogicUtil.GetYoyakuStatus(vm.teiin, ct1); //状態

            return vm;
        }

        /// <summary>
        /// 希望者情報(検索用)
        /// </summary>
        public static List<PersonRowVM> GetVMList(DaDbContext db, List<tt_kkjigyoyoyakukibosyaDto> dtl1, List<tt_afatenaDto> dtl2, bool alertviewflg)
        {
            var list = new List<PersonRowVM>();
            foreach (var dto1 in dtl1)
            {
                var dto2 = dtl2.Find(e => e.atenano == dto1.atenano);
                list.Add(GetVM(db, dto1, dto2, alertviewflg));
            }

            return list;
        }

        /// <summary>
        /// 予約情報
        /// </summary>
        public static DetailVM GetVM(tt_kkjigyoyoyakukibosyaDto dto)
        {
            var vm = new DetailVM();
            vm.yoyakuno = dto.yoyakuno;                                     //予約番号
            vm.taikiflg = (dto.cancelmatiflg == Enum待機フラグ.希望する);   //待機フラグ
            vm.jusinkingaku = dto.jusinkingaku;                             //受診金額
            vm.kingaku_sityosonhutan = dto.kingaku_sityosonhutan;           //金額（市区町村負担）
            vm.syokaiuketukeymd = CStr(dto.syokaiuketukeymd);               //初回受付日
            vm.biko = CStr(dto.biko);                                       //備考

            return vm;
        }

        /// <summary>
        /// 日程情報(1件)
        /// </summary>
        private static NitteiRowVM GetVM(DaDbContext db, DataRow row, List<DaSelectorModel> list1, List<DaSelectorModel> list2)
        {
            NitteiRowVM vm = (NitteiRowVM)GetVM(row, new NitteiRowVM(), list1, list2);
            var gyomukbn = row.Wrap(nameof(tm_kksonotasidojigyoDto.gyomukbn));                          //業務区分
            vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.拡_予約_保健指導業務区分, gyomukbn);  //業務区分名
            vm.courseno = row.CNInt(nameof(NitteiRowVM.courseno));                                      //コース番号
            vm.coursenm = row.Wrap(nameof(NitteiRowVM.coursenm));                                       //コース名
            var tmf = row.Wrap(nameof(tt_kkjigyoyoteiDto.tmf));                                         //開始時間
            var tmt = row.Wrap(nameof(tt_kkjigyoyoteiDto.tmt));                                         //終了時間
            vm.time = FormatTimeRange(tmf, tmt);                                                        //開始時間～終了時間

            return vm;
        }

        /// <summary>
        /// 日程情報(1件)
        /// </summary>
        private static CourseRowVM GetVM(DataRow row, List<DaSelectorModel> list1, List<DaSelectorModel> list2)
        {
            CourseRowVM vm = (CourseRowVM)GetVM(row, new CourseRowVM(), list1, list2);
            vm.tmf = FormatTime(row.Wrap(nameof(tt_kkjigyoyoteiDto.tmf)));  //開始時間
            vm.tmt = FormatTime(row.Wrap(nameof(tt_kkjigyoyoteiDto.tmt)));  //終了時間

            return vm;
        }

        /// <summary>
        /// 共通情報(1件)
        /// </summary>
        private static RowBaseVM GetVM(DataRow row, RowBaseVM vm, List<DaSelectorModel> list1, List<DaSelectorModel> list2)
        {
            vm.nitteino = row.CInt(nameof(NitteiRowVM.nitteino));                                       //日程番号
            vm.kaisu = row.CNInt(nameof(NitteiRowVM.kaisu));                                            //回数
            vm.jigyonm = row.Wrap(nameof(NitteiRowVM.jigyonm));                                         //その他日程事業・保健指導事業名
            vm.jissinaiyo = row.Wrap(nameof(NitteiRowVM.jissinaiyo));                                   //実施内容
            vm.jissiyoteiymd = row.Wrap(nameof(NitteiRowVM.jissiyoteiymd));                             //実施予定日
            var kaijocd = row.Wrap(nameof(tt_kkjigyoyoteiDto.kaijocd));                                 //会場コード
            vm.kaijonm = CStr(list1.Find(e => e.value == kaijocd)?.label);                              //会場名
            var kikancd = row.Wrap(nameof(tt_kkjigyoyoteiDto.kikancd));                                 //医療機関コード
            vm.kikannm = CStr(list2.Find(e => e.value == kikancd)?.label);                              //医療機関名
            vm.staffidnms = row.Wrap(nameof(NitteiRowVM.staffidnms));                                   //担当者名(複数)
            var teiin = row.CInt(nameof(tt_kkjigyoyoteiDto.teiin));                                     //定員
            var ct1 = row.CInt("ct1");                                                                  //申
            vm.status = CmLogicUtil.GetYoyakuStatus(teiin, ct1);                                        //状態
            vm.ninzu = $"{ct1}{DaStrPool.C_SLASH}{teiin}";                                              //申/定員
            vm.taikinum = row.CNInt("ct2");                                                             //待機

            return vm;
        }

        /// <summary>
        /// 希望者情報(1行)
        /// </summary>
        private static PersonRowVM GetVM(DaDbContext db, tt_kkjigyoyoyakukibosyaDto dto1, tt_afatenaDto? dto2, bool alertviewflg)
        {
            var vm = new PersonRowVM();
            vm.yoyakuno = dto1.yoyakuno;                                                                //予約番号
            vm.atenano = dto1.atenano;                                                                  //宛名番号
            vm.name = CStr(dto2?.simei_yusen);                                                          //氏名
            vm.kname = CStr(dto2?.simei_kana_yusen);                                                    //カナ氏名
            vm.sex = CmLogicUtil.GetSex(db, CStr(dto2?.sex));                                           //性別
            vm.bymd = CmLogicUtil.GetYMDStr(dto2?.bymd_fusyoflg, dto2?.bymd, dto2?.bymd_fusyohyoki);    //生年月日
            vm.age = CmLogicUtil.GetAgeStr(dto2?.bymd_fusyoflg, dto2?.bymd);                            //年齢
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, CStr(dto2?.juminkbn));          //住民区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto2?.siensotikbn, alertviewflg);                   //警告内容
            vm.upddttm = dto1.upddttm;                                                                  //更新日時(排他用)
            vm.status = CmLogicUtil.GetYoyakuStatus2(EnumToStr(dto1.cancelmatiflg));                    //予約状態

            return vm;
        }
    }
}