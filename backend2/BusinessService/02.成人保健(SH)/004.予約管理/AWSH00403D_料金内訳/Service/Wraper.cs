// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 料金内訳
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00403D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 個人基本情報(ヘッダー部)
        /// </summary>
        public static HeaderVM GetHeaderVM(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new HeaderVM();
            vm = (HeaderVM)Common.Wraper.GetHeaderVM(db, vm, dto);
            vm.genmenkbn_tokutei = DaHanyoService.GetName(db, EnumHanyoKbn.減免区分_特定健診, Enum名称区分.名称, CStr(dto.genmenkbn_tokutei));    //減免区分（特定健診）
            vm.genmenkbn_gan = DaHanyoService.GetName(db, EnumHanyoKbn.減免区分_がん検診, Enum名称区分.名称, CStr(dto.genmenkbn_gan));            //減免区分（がん検診）

            return vm;
        }

        /// <summary>
        /// 予約情報一覧
        /// </summary>
        public static List<DetailVM> GetVMList(DataRowCollection rows, tt_afatenaDto dto)
        {
            List<DetailVM> list = new List<DetailVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(row, dto));
            }
            return list;
        }

        /// <summary>
        /// キーリスト取得
        /// </summary>
        public static List<MoneyKeyVM> GetKeyList(List<MoneyKeyBase3VM> keyList, List<tm_shkensinjigyoDto> dtl1,
                                                List<tt_shkensinyoteiDto> dtl2, List<tm_shnendoDto> dtl3,
                                                List<tm_shyoyakujigyoDto> dtl4, tt_afatenaDto dto)
        {
            var list = new List<MoneyKeyVM>();
            foreach (var key in keyList)
            {
                var vm = new MoneyKeyVM();
                vm.jigyocd = key.jigyocd;                                                                                   //検診種別
                vm.kensahohocd = key.kensahohocd;                                                                           //検査方法コード
                vm.nitteino = key.nitteino;                                                                                 //日程番号

                //成人健（検）診事業マスタ
                var dto1 = dtl1.Find(e => e.jigyocd == key.jigyocd)!;
                var genmenkbn = dto1.genmenkbn;
                vm.genmenkbn = CStr(genmenkbn == Enum減免区分種別.特定健診 ? dto.genmenkbn_tokutei : dto.genmenkbn_gan);    //減免区分

                //健（検）診予定テーブル
                var dto2 = dtl2.Find(e => e.nitteino == key.nitteino)!;

                //年度マスタ
                var dto3 = dtl3.Find(e => e.jigyocd == key.jigyocd && e.kensahohocd == key.kensahohocd)!;

                vm.kijunymd = dto3.kijunkbn == Enum年齢基準日区分.受診日時点 ? dto2.yoteiymd! : dto3.kijunymd!;             //年齢計算基準日

                //成人健（検）診予約日程事業コード
                var jigyocd = dto2.jigyocd;
                vm.ryokinpattern = dtl4.Find(e => e.jigyocd == jigyocd)!.ryokinpattern;                                     //料金パターン

                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 自己負担金情報
        /// </summary>
        public static List<RowVM> GetVMList(List<object[]> keys, List<tm_shjikofutankinDto> dtl, List<tm_afhanyoDto> dtl2, tt_afatenaDto dto, List<DaSelectorModel> nmList)
        {
            List<RowVM> list = new List<RowVM>();
            foreach (var key in keys)
            {
                list.Add(GetVM(CStr(key[0]), CStr(key[1]), CStr(key[2]), dtl, dtl2, dto, nmList));
            }
            return list;
        }
        /// <summary>
        /// 自己負担金情報(1件)
        /// </summary>
        private static RowVM GetVM(string jigyocd, string kensahohocd, string kijunymd, List<tm_shjikofutankinDto> dtl, List<tm_afhanyoDto> dtl2, tt_afatenaDto dto, List<DaSelectorModel> nmList)
        {
            RowVM vm = new RowVM();

            var jigyonm = nmList.Find(e => e.value == jigyocd)!.label;                        //検診名
            var kensahohonm = dtl2.Find(e => e.hanyosubcd == CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, jigyocd) &&
                                        e.hanyocd == kensahohocd)?.nm;                        //検査方法名
            vm.kensahoho = $"{DaStrPool.BRACKET2_START}{jigyonm}{DaStrPool.BRACKET2_END}{kensahohonm}";          //成人健（検）診事業・検査方法

            var age = CmLogicUtil.GetAge(dto.bymd_fusyoflg, dto.bymd, CDate(kijunymd));
            //年齢不明の場合
            if (age == null)
            {
                vm.jusinkingaku = Service.ERR_MSG;                                      //受診金額
                vm.kingaku_sityosonhutan = Service.ERR_MSG;                             //（市区町村負担）金額
            }
            else
            {
                var list = dtl.Where(e => e.kensin_jigyocd == jigyocd && CommaStrToList(e.sex).Contains(dto.sex) &&
                                    CmLogicUtil.ParseAgeRanges(e.agehani).Contains(CInt(age))).ToList();
                //自己負担金マスタデータ取得失敗の場合
                if (list.Count() != 1)
                {
                    vm.jusinkingaku = Service.ERR_MSG;                                  //受診金額
                    vm.kingaku_sityosonhutan = Service.ERR_MSG;                         //（市区町村負担）金額
                }
                else
                {
                    vm.jusinkingaku = CStr(list[0].jusinkingaku);                       //受診金額
                    vm.kingaku_sityosonhutan = CStr(list[0].kingaku_sityosonhutan);     //（市区町村負担）金額
                }
            }

            return vm;
        }

        /// <summary>
        /// 予約情報(1件)
        /// </summary>
        private static DetailVM GetVM(DataRow row, tt_afatenaDto dto)
        {
            DetailVM vm = new DetailVM();

            vm.jigyocd = row.Wrap(nameof(DetailVM.jigyocd));                                                            //検診種別
            vm.kensahohocd = row.Wrap(nameof(DetailVM.kensahohocd));                                                    //検査方法コード
            vm.kijunymd = row.Wrap(nameof(DetailVM.kijunymd));                                                          //年齢基準日
            var genmenkbn = (Enum減免区分種別)row.CInt(nameof(DetailVM.genmenkbn));
            vm.genmenkbn = CStr(genmenkbn == Enum減免区分種別.特定健診 ? dto.genmenkbn_tokutei : dto.genmenkbn_gan);    //減免区分
            vm.ryokinpattern = row.Wrap(nameof(DetailVM.ryokinpattern));                                                //料金パターン

            return vm;
        }
    }
}