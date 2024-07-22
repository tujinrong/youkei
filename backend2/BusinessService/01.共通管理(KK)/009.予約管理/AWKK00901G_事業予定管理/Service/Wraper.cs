// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業予定管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.03.01
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using NPOI.SS.Formula.Functions;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00901G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 予約事業一覧
        /// </summary>
        public static List<DaSelectorKeyModel> GetSelectorList(List<tm_kksonotasidojigyoDto> dtl)
        {
            return dtl.Select(e => new DaSelectorKeyModel(e.jigyocd, e.jigyonm, e.gyomukbn)).ToList();
        }

        /// <summary>
        /// 日程情報一覧
        /// </summary>
        public static List<NitteiRowVM> GetVMList(DaDbContext db, DataRowCollection rows,
                                                    List<DaSelectorModel> list1, List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            List<NitteiRowVM> list = new List<NitteiRowVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row, list1, list2, list3));
            }
            return list;
        }

        /// <summary>
        /// コース情報一覧
        /// </summary>
        public static List<CourseRowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            List<CourseRowVM> list = new List<CourseRowVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 日程情報(ヘッダー)
        /// </summary>
        public static NitteiHeaderVM GetHeaderVM(List<DaSelectorKeyModel> list, tt_kkjigyoyoteiDto? dto, string regsisyonm)
        {
            var vm = new NitteiHeaderVM();
            vm.gyomukbn = CStr(list.Find(e => e.key == dto?.jigyocd)?.value);   //業務区分
            vm.regsisyonm = regsisyonm;                                         //登録支所名

            return vm;
        }

        /// <summary>
        /// 日程情報(明細)
        /// </summary>
        public static NitteiDetailVM GetVM(NitteiDetailVM vm, tt_kkjigyoyoteiDto? dto, List<string> staffids, bool yoyakuflg,
                                            List<DaSelectorKeyModel> list1, List<DaSelectorModel> list2,
                                            List<DaSelectorModel> list3, List<DaSelectorModel> list4)
        {
            if (dto != null)
            {
                vm.jissinaiyo = CStr(dto.jissinaiyo);   //実施内容
                vm.jissiyoteiymd = dto.jissiyoteiymd;   //実施予定日
                vm.tmf = dto.tmf;                       //開始時間
                vm.tmt = CStr(dto.tmt);                 //終了時間
                vm.teiin = dto.teiin;                   //定員
                vm.editflg = !yoyakuflg;                //編集フラグ(事業)
                var list = list1.Select(e => new DaSelectorModel(e.value, e.label)).ToList();
                if (list1.Exists(e => e.value == dto.jigyocd))
                {
                    vm.jigyocdnm = DaSelectorService.GetCdNm(list, dto.jigyocd);        //その他日程事業・保健指導事業(コード：名称)
                }
                if (list2.Exists(e => e.value == dto.kaijocd))
                {
                    vm.kaijocdnm = DaSelectorService.GetCdNm(list2, dto.kaijocd);       //会場(コード：名称)
                }
                if (list3.Exists(e => e.value == dto.kikancd) && !string.IsNullOrEmpty(dto.kikancd))
                {
                    vm.kikancdnm = DaSelectorService.GetCdNm(list3, CStr(dto.kikancd)); //医療機関(コード：名称)
                }
                var staffidList = new List<string>();
                foreach (var staffid in staffids)
                {
                    if (list4.Exists(e => e.value == staffid))
                    {
                        var item = list4.Find(e => e.value == staffid);
                        if (item != null) {
                            staffidList.Add(item.label);   //担当者
                        }
                    }
                }
                vm.staffids = staffidList;          //担当者(複数)
            }
            else
            {
                vm.staffids = new List<string>();
            }

            return vm;
        }

        /// <summary>
        /// コース情報(ヘッダー)
        /// </summary>
        public static CourseHeaderVM GetHeaderVM(List<DaSelectorKeyModel> list, tt_kkjigyoyoteicourseDto? dto, string? jigyocd, string regsisyonm)
        {
            var vm = new CourseHeaderVM();
            vm.gyomukbn = CStr(list.Find(e => e.key == jigyocd)?.value);    //業務区分
            vm.regsisyonm = regsisyonm;                                     //登録支所名
            vm.coursenm = CStr(dto?.coursenm);                              //コース名

            return vm;
        }

        /// <summary>
        /// コース情報(明細)
        /// </summary>
        public static List<CourseDetailVM> GetVMList(List<tt_kkjigyoyoteiDto> dtl1, List<tt_kkjigyoyotei_staffDto> dtl2,
                                            List<tt_kkjigyoyoyakukibosyaDto> dtl3, bool copyflg,
                                            List<DaSelectorKeyModel> list1, List<DaSelectorModel> list2,
                                            List<DaSelectorModel> list3, List<DaSelectorModel> list4)
        {
            var list = new List<CourseDetailVM>();
            foreach (var dto in dtl1)
            {
                var flg = dtl3.Exists(e => e.nitteino == dto.nitteino);
                list.Add(GetVM(dto, dtl2, flg, copyflg, list1, list2, list3, list4));
            }

            return list;
        }

        /// <summary>
        /// コース情報(明細)：日程番号設定
        /// </summary>
        public static List<CourseDetailVM> GetVMList(List<CourseDetailVM> list, int nitteino)
        {
            foreach (var vm in list)
            {
                var no = vm.nitteino;
                if (no == null)
                {
                    vm.nitteino = nitteino;
                    nitteino++;
                }
            }

            return list;
        }

        /// <summary>
        /// 日程情報(1件)
        /// </summary>
        private static NitteiRowVM GetVM(DaDbContext db, DataRow row, List<DaSelectorModel> list1, List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            NitteiRowVM vm = new NitteiRowVM();
            vm.nitteino = row.CInt(nameof(NitteiRowVM.nitteino));                                       //日程番号
            var gyomukbn = row.Wrap(nameof(tm_kksonotasidojigyoDto.gyomukbn));                          //業務区分
            vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.拡_予約_保健指導業務区分, gyomukbn);  //業務区分名
            vm.jigyonm = row.Wrap(nameof(NitteiRowVM.jigyonm));                                         //その他日程事業・保健指導事業名
            vm.jissinaiyo = row.Wrap(nameof(NitteiRowVM.jissinaiyo));                                   //実施内容
            vm.jissiyoteiymd = row.Wrap(nameof(NitteiRowVM.jissiyoteiymd));                             //実施予定日
            var tmf = row.Wrap(nameof(tt_kkjigyoyoteiDto.tmf));                                         //開始時間
            var tmt = row.Wrap(nameof(tt_kkjigyoyoteiDto.tmt));                                         //終了時間
            vm.time = FormatTimeRange(tmf, tmt);                                                        //開始時間～終了時間
            var kaijocd = row.Wrap(nameof(tt_kkjigyoyoteiDto.kaijocd));                                 //会場コード
            vm.kaijonm = CStr(list1.Find(e => e.value == kaijocd)?.label);                              //会場名
            var kikancd = row.Wrap(nameof(tt_kkjigyoyoteiDto.kikancd));                                 //医療機関コード
            vm.kikannm = CStr(list2.Find(e => e.value == kikancd)?.label);                              //医療機関名
            var staffid = row.Wrap($"{nameof(tt_kkjigyoyotei_staffDto.staffid)}s");                     //担当者(複数)
            vm.staffidnms = CStr(CommaStrToCommaStr2(staffid, list3));                                  //担当者名(複数)
            vm.teiin = row.CInt(nameof(NitteiRowVM.teiin));                                             //定員

            return vm;
        }

        /// <summary>
        /// コース情報(1件)
        /// </summary>
        private static CourseRowVM GetVM(DaDbContext db, DataRow row)
        {
            CourseRowVM vm = new CourseRowVM();
            vm.courseno = row.CInt(nameof(CourseRowVM.courseno));                                       //コース番号
            var gyomukbn = row.Wrap(nameof(tm_kksonotasidojigyoDto.gyomukbn));                          //業務区分
            vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.拡_予約_保健指導業務区分, gyomukbn);  //業務区分名
            vm.coursenm = row.Wrap(nameof(CourseRowVM.coursenm));                                       //コース名
            vm.kaisu = row.CInt(nameof(CourseRowVM.kaisu));                                             //回数
            vm.jissikikan = FormatWaKjYMDRange(row.Wrap($"{nameof(tt_kkjigyoyoteiDto.jissiyoteiymd)}f"),
                                            row.Wrap($"{nameof(tt_kkjigyoyoteiDto.jissiyoteiymd)}t"));  //実施期間

            return vm;
        }

        /// <summary>
        /// コース日程情報(1件)
        /// </summary>
        private static CourseDetailVM GetVM(tt_kkjigyoyoteiDto dto, List<tt_kkjigyoyotei_staffDto> dtl, bool yoyakuflg, bool copyflg,
                                            List<DaSelectorKeyModel> list1, List<DaSelectorModel> list2,
                                            List<DaSelectorModel> list3, List<DaSelectorModel> list4)
        {
            //担当者一覧
            var staffids = dtl.Where(e => e.nitteino == dto.nitteino).Select(e => e.staffid).OrderBy(e => e).ToList();
            //日程関連項目設定
            var vm = (CourseDetailVM)GetVM(new CourseDetailVM(), dto, staffids, yoyakuflg, list1, list2, list3, list4);
            if (!copyflg) { 
                vm.nitteino = dto.nitteino;     //日程番号
            }
            vm.kaisu = dto.kaisu!.Value;    //回数

            return vm;
        }
    }
}