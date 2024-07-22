// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予定管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.13
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWSH00401G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 列情報取得
        /// </summary>
        public static List<ColumnInfoVM> GetVMList(DataColumnCollection cols, int num)
        {
            var list = new List<ColumnInfoVM>();
            for (var i = 0; i < cols.Count - num; i++)
            {
                var vm = new ColumnInfoVM();
                vm.title = cols[i].Caption;     //項目論理名
                vm.key = cols[i].ColumnName;    //項目物理名
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// 結果一覧(予約情報)取得
        /// </summary>
        public static List<List<DataInfoVM>> GetVMList(DataRowCollection rows, List<string> keys, List<DaSelectorModel> list1,
                                                        List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            var list = new List<List<DataInfoVM>>();
            foreach (DataRow dr in rows)
            {
                list.Add(GetVM(dr, keys, list1, list2, list3));
            }

            return list;
        }

        /// <summary>
        /// 予定メイン情報取得
        /// </summary>
        public static DetailVM GetVM(tt_shkensinyoteiDto? dto, List<tt_shkensinyotei_staffDto> dtl, List<tm_afhanyoDto> dtl2,
                                    List<DaSelectorModel> list1, List<DaSelectorModel> list2, List<DaSelectorModel> list3, List<DaSelectorModel> list4)
        {
            var vm = new DetailVM();
            if (dto != null)
            {
                if (list1.Exists(e => e.value == dto.jigyocd)) 
                {
                    vm.jigyocdnm = DaSelectorService.GetCdNm(list1, dto.jigyocd);                       //成人健（検）診予約日程事業(コード：名称)
                }
                vm.yoteiymd = dto.yoteiymd;                                                             //実施予定日
                vm.timef = dto.tmf;                                                                     //開始時間
                vm.timet = CStr(dto.tmt);                                                               //終了時間
                if (list2.Exists(e => e.value == dto.kaijocd))
                {
                    vm.kaijocdnm = DaSelectorService.GetCdNm(list2, dto.kaijocd);                       //会場(コード：名称)
                }
                if (list3.Exists(e => e.value == dto.kikancd))
                {
                    vm.kikancdnm = DaSelectorService.GetCdNm(list3, CStr(dto.kikancd));                 //医療機関(コード：名称)
                }
                var staffids = dtl.Select(e => e.staffid).OrderBy(e => e).ToList();                     
                var staffidList = new List<string>();
                foreach (var staffid in staffids)
                {
                    if (list4.Exists(e => e.value == staffid))
                    {
                        var item = list4.Find(e => e.value == staffid);
                        if (item != null)
                        {
                            staffidList.Add(item.label);   //担当者
                        }
                    }
                }
                vm.staffids = staffidList;                                                              //担当者一覧
                vm.teiin = dto.teiin;                                                                   //定員
                vm.regsisyonm = DaHanyoService.GetName(dtl2, Enum名称区分.名称, CStr(dto.regsisyo));    //登録支所名称
            }
            else
            {
                vm.staffids = new List<string>();
            }

            return vm;
        }

        /// <summary>
        /// 予定定員情報一覧取得
        /// </summary>
        public static List<RowVM> GetVMList(List<tt_shkensinyoteisyosaiDto> dtl, List<object[]> nmList)
        {
            var list = new List<RowVM>();
            foreach (var row in nmList)
            {
                list.Add(GetVM(dtl, row));
            }

            return list;
        }

        /// <summary>
        /// 予定定員情報(制御用)一覧取得
        /// </summary>
        public static List<RowKeyVM> GetVMList(List<tm_shyoyakujigyo_subDto> dtl, List<object[]> nmList)
        {
            var list = new List<RowKeyVM>();
            foreach (var dto in dtl)
            {
                var row = nmList.Find(e => CStr(e[0]) == dto.kensin_jigyocd && CStr(e[2]) == dto.kensahohocd);
                if (row != null)
                {
                    var vm = new RowKeyVM() { jigyocd = dto.kensin_jigyocd, yoyakubunruicd = CStr(row[1]) };
                    if (!list.Exists(e => e.jigyocd == vm.jigyocd && e.yoyakubunruicd == vm.yoyakubunruicd))
                    {
                        list.Add(vm);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 予定定員情報(1行)
        /// </summary>
        private static RowVM GetVM(List<tt_shkensinyoteisyosaiDto> dtl, object[] row)
        {
            var vm = new RowVM();
            vm.jigyocd = CStr(row[0]);                  //検診種別
            vm.yoyakubunruicd = CStr(row[1]);           //予約分類コード
            vm.yoyakubunruinm = CStr(row[2]);           //予約分類名称
            var dto = dtl.Find(e => e.jigyocd == vm.jigyocd && e.yoyakubunruicd == vm.yoyakubunruicd);
            if (dto != null)
            {
                vm.teiin_kensin = dto.teiin_kensin;     //定員(検診)
            }

            return vm;
        }

        /// <summary>
        /// 結果一覧(予約情報)(1行)
        /// </summary>
        private static List<DataInfoVM> GetVM(DataRow dr, List<string> keys, List<DaSelectorModel> list1,
                                                List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            var list = new List<DataInfoVM>();
            foreach (var key in keys)
            {
                var vm = new DataInfoVM();
                vm.key = key;                                                               //項目物理名
                switch (key)
                {
                    //成人健（検）診予約日程事業名
                    case nameof(tt_shkensinyoteiDto.jigyocd):
                        vm.value = CStr(list1.Find(e => e.value == dr.Wrap(key))?.label);   //値
                        break;
                    //会場名
                    case nameof(tt_shkensinyoteiDto.kaijocd):
                        vm.value = CStr(list2.Find(e => e.value == dr.Wrap(key))?.label);   //値
                        break;
                    //医療機関名
                    case nameof(tt_shkensinyoteiDto.kikancd):
                        vm.value = CStr(list3.Find(e => e.value == dr.Wrap(key))?.label);   //値
                        break;
                    //時間
                    case "time":
                        var timef = dr.Wrap(nameof(tt_shkensinyoteiDto.tmf));
                        var timet = dr.Wrap(nameof(tt_shkensinyoteiDto.tmt));
                        vm.value = FormatTimeRange(timef, timet);
                        break;
                    //実施予定日
                    case nameof(tt_shkensinyoteiDto.yoteiymd):
                        vm.value = FormatWaKjYMD(dr.Wrap(nameof(tt_shkensinyoteiDto.yoteiymd)));   //値
                        break;
                    default:
                        if (key.StartsWith(nameof(KensinyoyakuView.useflg)))
                        {
                            vm.value = FormatFlgStr(dr.CBool(key));                         //値
                        }
                        else
                        {
                            vm.value = dr.Wrap(key);                                        //値
                        }
                        break;
                }
                list.Add(vm);
            }

            return list;
        }
    }
}