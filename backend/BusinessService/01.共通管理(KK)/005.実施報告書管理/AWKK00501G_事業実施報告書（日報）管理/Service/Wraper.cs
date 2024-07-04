// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業実施報告書（日報）管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.20
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00501G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 日報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(GetVM).ToList();
        }

        /// <summary>
        /// 実施報告書（日報）情報
        /// </summary>
        public static JissihokokusyoVM GetJissihokokusyoVM(tt_kkjissihokokusyoDto dto, List<tm_afkaijoDto> kaijoDtl, List<tm_afhanyoDto> jigyoHanyoDtl)
        {
            var jigyonm = jigyoHanyoDtl.Find(x => x.hanyocd == dto.jigyocd)?.nm;
            var jigyoCdNm = string.IsNullOrEmpty(jigyonm) ? dto.jigyocd : $"{dto.jigyocd}{DaConst.SELECTOR_DELIMITER}{jigyonm}";
            var kaijonm = kaijoDtl.Find(x => x.kaijocd == dto.kaijocd)?.kaijonm;
            var kaijoCdNm = string.IsNullOrEmpty(kaijonm) ? dto.kaijocd : $"{dto.kaijocd}{DaConst.SELECTOR_DELIMITER}{kaijonm}";

            var vm = new JissihokokusyoVM();
            vm.jigyo = jigyoCdNm; //事業
            vm.kaijo = kaijoCdNm; //会場
            vm.jissiymd = dto.jissiymd; //実施日
            vm.timef = dto.timef ?? ""; //開始時間
            vm.timet = dto.timet ?? ""; //終了時間
            vm.mantotalnum = dto.mantotalnum ?? 0; //男性延べ人数
            vm.womantotalnum = dto.womantotalnum ?? 0; //女性延べ人数
            vm.fumeitotalnum = dto.fumeitotalnum ?? 0; //性別不明延べ人数
            vm.mannum = dto.mannum ?? 0; //男性実人数
            vm.womannum = dto.womannum ?? 0; //女性実人数
            vm.fumeinum = dto.fumeinum ?? 0; //性別不明実人数
            vm.syussekisya = dto.syussekisya ?? 0; //出席者数
            vm.jissinaiyo = dto.jissinaiyo; //実施内容
            vm.baitai = dto.baitai; //媒体
            vm.haifusiryo = dto.haifusiryo; //配布資料
            vm.comment = dto.comment; //コメント
            vm.hanseipoint = dto.hanseipoint; //反省点
            vm.jigyomokuteki = dto.jigyomokuteki; //事業目的
            return vm;
        }

        /// <summary>
        /// 事業従事者リスト
        /// </summary>
        public static List<StaffVM> GetStaffVMList(DaDbContext db, IEnumerable<tm_afstaffDto> staffDtl)
        {
            return staffDtl.Select(x => GetStaffVM(db, x)).ToList();
        }

        /// <summary>
        /// 日報一覧(1行)
        /// </summary>
        private static RowVM GetVM(DataRow row)
        {
            var vm = new RowVM();
            vm.hokokusyono = row.CInt(nameof(RowVM.hokokusyono)); //事業報告書番号
            vm.jissiymd = FormatWaKjYMD(CNDate(row.Wrap(nameof(RowVM.jissiymd)))); //実施日
            if (string.IsNullOrEmpty(row.Wrap("timef")) && string.IsNullOrEmpty(row.Wrap("timet")))
            {
                vm.jissitime = string.Empty; //時間
            }
            else
            {
                vm.jissitime = FormatTimeRange(row.Wrap("timef"), row.Wrap("timet")); //時間
            }
            vm.kaijonm = row.Wrap(nameof(RowVM.kaijonm)); //会場名
            vm.jigyonm = row.Wrap(nameof(RowVM.jigyonm)); //事業名
            vm.staffnm = row.Wrap(nameof(RowVM.staffnm)); //従事者
            vm.upddttm = FormatWaKjDttm(row.CDate(nameof(RowVM.upddttm))); //更新日時
            vm.updusernm = row.Wrap(nameof(RowVM.updusernm)); //更新者
            vm.regsisyo = row.Wrap(nameof(RowVM.regsisyo)); //登録支所
            return vm;
        }

        /// <summary>
        /// 事業従事者(1行)
        /// </summary>
        public static StaffVM GetStaffVM(DaDbContext db, tm_afstaffDto dto)
        {
            var vm = new StaffVM();
            vm.staffid = dto.staffid; //事業従事者ID
            vm.staffsimei = dto.staffsimei; //事業従事者氏名
            vm.kanastaffsimei = dto.kanastaffsimei; //事業従事者カナ氏名
            vm.syokusyu = DaNameService.GetCdNm(db, EnumNmKbn.職種, Enum名称区分.名称, dto.syokusyu); //職種
            vm.katudokbn = DaNameService.GetCdNm(db, EnumNmKbn.活動区分, Enum名称区分.名称, dto.katudokbn); //活動区分
            var stopflg = BoolToStr(dto.stopflg);
            vm.stopflg = DaNameService.GetName(db, EnumNmKbn.停止フラグ, stopflg); //利用状態

            return vm;
        }
    }
}