// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 対象サイン
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00404D
{
    public class Wraper : CmWraperBase
    {
        private const string FUSYOSTR = "不詳";                               //年齢不祥の場合表示用

        /// <summary>
        /// 検診状況一覧取得
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, tt_afatenaDto dto1, tt_shkensinyoteiDto dto5, List<tm_shnendoDto> dtl1, List<tm_afhanyoDto> dtl2,
                                            List<tt_shkensinrirekikanriDto> dtl3, List<tt_shjyusinkyohiriyuDto> dtl4, List<DaSelectorModel> cdnmList,
                                            List<object[]> keyList, List<DaSelectorModel> cdnmList2)
        {
            var list = new List<RowVM>();
            foreach (var dto2 in dtl1)
            {
                var vm = new RowVM();
                vm = (RowVM)Wraper.GetVM(db, vm, dto1, dto2, dto5, dtl2, dtl3, dtl4, cdnmList, cdnmList2, keyList);
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// 検診状況(1行)
        /// </summary>
        public static RowVM GetVM(DaDbContext db, RowVM vm, tt_afatenaDto dto1, tm_shnendoDto dto2, tt_shkensinyoteiDto dto5, List<tm_afhanyoDto> dtl2,
                                    List<tt_shkensinrirekikanriDto> dtl3, List<tt_shjyusinkyohiriyuDto> dtl4, List<DaSelectorModel> cdnmList, List<DaSelectorModel> cdnmList2,
                                    List<object[]>? keyList = null)
        {
            //健（検）診予定テーブルの予約状況
            object[]? key = keyList?.Find(e => CStr(e[0]) == dto2.jigyocd && CStr(e[1]) == dto2.kensahohocd);

            vm.jigyocd = dto2.jigyocd;                                                                           //検診事業コード
            vm.kensahohocd = dto2.kensahohocd;                                                                   //検査方法コード
            var jigyonm = cdnmList.Find(e => e.value == vm.jigyocd)!.label;
            var kensahohonm = dtl2.Find(e => e.hanyosubcd == CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, vm.jigyocd) &&
                                        e.hanyocd == vm.kensahohocd)?.nm;
            vm.kensahoho = $"{DaStrPool.BRACKET2_START}{jigyonm}{DaStrPool.BRACKET2_END}{kensahohonm}";          //成人健（検）診事業・検査方法
            
            if (dto2.kijunkbn == Enum年齢基準日区分.指定日)
            {
                vm.kijunymd = dto2.kijunymd!;                                                                    //年齢計算基準日
            }
            else
            {
                vm.kijunymd = key != null ? CStr(key[2]) : dto5.yoteiymd;                                         //年齢計算基準日
            }

            //一時対象サイン
            var kbn = Enum対象区分.対象外;
            var dto = dtl3.Find(e => e.jigyocd == vm.jigyocd && e.kensahohocd == vm.kensahohocd && e.atenano == dto1.atenano);
            if (dto != null)
            {
                var flg = dto.taisyoflg;
                if (flg == EnumToStr(Enum対象区分.対象)) kbn = Enum対象区分.対象;
                if (flg == EnumToStr(Enum対象区分.不明)) kbn = Enum対象区分.不明;
            }

            vm.sign1 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn));

            //年齢初期値
            var age = 0;
            //不祥フラグ対象サイン判断用
            var fusyoflg = true;
            //年齢取得
            if (!CBool(dto1.bymd_fusyoflg) && !string.IsNullOrEmpty(vm.kijunymd))
            {
                fusyoflg = false;
                //基準日
                var kijunymd = CDate(vm.kijunymd);
                age = DaUtil.GetAge(CDate(dto1.bymd), kijunymd);
                vm.age = $"{age}歳";                                                                             //年齢

                var kbn2 = Common.Wraper.GetKbn(dto1, dto2, fusyoflg, CInt(age), dtl4, kbn);
                vm.sign2 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn2));                     //対象サイン
            }
            else
            {
                //生年月日が不詳の場合、「不詳」を表示する
                vm.age = FUSYOSTR;

                var kbn2 = Common.Wraper.GetKbn(dto1, dto2, fusyoflg, CInt(age), dtl4, kbn);
                vm.sign2 = DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(kbn2));                     //対象サイン
            }

            //受診拒否理由
            var kyohiriyu = CStr(dtl4.Find(e => e.jigyocd == vm.jigyocd)?.kyohiriyu);
            vm.kyohiriyu = DaSelectorService.GetName(cdnmList2, kyohiriyu);

            return vm;
        }

        /// <summary>
        /// 検査方法と予定日の関係取得
        /// </summary>
        public static List<object[]> GetKeyList(List<tt_shkensinkibosyasyosaiDto> dtl1, List<tt_shkensinyoteiDto> dtl2)
        {
            var list = new List<object[]>();
            foreach (var dto in dtl1)
            {
                var yoteiymd = dtl2.Find(e => e.nitteino == dto.nitteino)!.yoteiymd;
                list.Add(new object[] { dto.jigyocd, dto.kensahohocd, yoteiymd });
            }
            return list;
        }
    }
}