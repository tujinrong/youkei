// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 送付先管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.14
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00608D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 送付先管理情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        /// 送付先管理情報(詳細画面)
        /// </summary>
        public static MainInfoVM GetVM(tt_afsofusakiDto dto, List<string> sisyoList, 
                                                             List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2,
                                                             bool existsflg1, bool existsflg2)
        {
            var vm = new MainInfoVM();
            vm.atenano = dto.atenano;                                                      //宛名番号
            vm.riyomokuteki = dto.riyomokuteki;                                            //利用目的
            vm.torokujiyu = dto.torokujiyu;                                                //登録事由
            vm.adrs_yubin = CStr(dto.adrs_yubin);                                          //郵便番号
            if(existsflg1) vm.adrs_sikucd = dto.adrs_sikucd;                               //市区町村コード
            if (existsflg2 || dto.adrs_tyoazacd == AWAF00608D.Service.TYOAZACD_NULL)
            {
                vm.adrs_tyoazacd = dto.adrs_tyoazacd;                                      //町字コード
            }
            //町字コード='9999999'の場合
            if (dto.adrs_tyoazacd == AWAF00608D.Service.TYOAZACD_NULL)
            {
                vm.adrs_tyoaza_in = CStr(dto.adrs_tyoaza);                                 //町字(手入力)
            }
            else
            {
                vm.adrs_tyoaza = CStr(dto.adrs_tyoaza);                                    //町字
            }
            vm.adrs_bantihyoki = dto.adrs_bantihyoki;                                      //番地号表記
            vm.adrs_katagaki = dto.adrs_katagaki;                                          //方書
            vm.sofusaki_simei = dto.sofusaki_simei;                                        //氏名
            var regsisyo = dto.regsisyo;
            if (!string.IsNullOrEmpty(regsisyo))
            {
                vm.regsisyo = DaHanyoService.GetCdNm(dtl2, Enum名称区分.名称, regsisyo);  //登録支所
            }
            vm.upddttm = dto.upddttm;                                                     //更新日時

            //更新権限フラグ
            vm.updflg = string.IsNullOrEmpty(regsisyo) || sisyoList.Contains(regsisyo);

            return vm;
        }

        /// <summary>
        /// 宛名情報(共通)
        /// </summary>
        public static PersonHeaderVM GetVM(DaDbContext db, tt_afatenaDto dto, bool adrsFlg)
        {
            var vm = new PersonHeaderVM();
            vm = (PersonHeaderVM)Common.Wraper.GetHeaderVM(db, vm, dto);
            vm.jutokbnnm = CStr(dto.jutokbn);                    　　　　　　　                     //住登区分                           
            vm.juminsyubetunm = DaNameService.GetName(db,
                EnumNmKbn.住民種別_住民基本台帳, EnumToStr(dto.juminsyubetu));                      //住民種別
            vm.juminjotainm = DaNameService.GetName(db,
                EnumNmKbn.住民状態_住民基本台帳, dto.juminjotai);                                   //住民状態
            vm.adrs_yubin = DaFormatUtil.FormatYubin(dto.adrs_yubin);                               //郵便番号
            vm.adrs = CmLogicUtil.GetAdrs(dto.jutokbn, dto.adrs1, dto.adrs2, adrsFlg);              //住所

            return vm;
        }

        /// <summary>
        /// 送付先管理情報(一覧)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM();
            var riyomokutekicd = row.Wrap(nameof(vm.riyomokutekicd));
            vm.riyomokutekicd = riyomokutekicd;
            vm.riyomokutekinm = DaSelectorService.GetName(db, riyomokutekicd, Enum名称区分.名称,
                                        Enumマスタ区分.汎用マスタ, EnumToStr(EnumHanyoKbn.利用目的));   //利用目的
            var torokujiyu = row.Wrap(nameof(vm.torokujiyu));
            vm.torokujiyu = DaSelectorService.GetName(db, torokujiyu, Enum名称区分.名称,
                                        Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.登録事由));      //登録事由
            vm.sofusaki_yubin = DaFormatUtil.FormatYubin(row.Wrap(nameof(vm.sofusaki_yubin)));          //送付先郵便番号
            vm.sofusaki_adrs = row.Wrap(nameof(vm.sofusaki_adrs));                                      //送付先住所
            vm.sofusaki_simei = row.Wrap(nameof(vm.sofusaki_simei));                                    //送付先氏名

            return vm;
        }

        /// <summary>
        /// 自動入力情報
        /// </summary>
        public static AutoSetVM GetVM(tm_aftyoazaDto? dto1, tm_afsikutyosonDto? dto2)
        {
            var vm = new AutoSetVM();
            if (dto1 != null)
            {
                vm.adrs_tyoazacd = dto1.tyoazaid;                        //町字ID
            }
            if (dto2 != null)
            {
                vm.adrs_sikucd = dto2.sikucd;                            //市区町村コード
            }

            return vm;
        }

        /// <summary>
        /// 利用目的ドロップダウンリスト
        /// </summary>
        public static List<DaSelectorModel> GetVMList(List<tm_afhanyoDto> dtl)
        {
            var list = new List<DaSelectorModel>();
            foreach (var dto in dtl)
            {
                list.Add(new DaSelectorModel(dto.hanyocd, CStr(dto.nm)));
            }

            return list.OrderBy(e => e.value).ToList();
        }

        /// <summary>
        /// 町字リスト
        /// </summary>
        public static List<DaSelectorKeyModel> GetVMTyoazaList(List<tm_aftyoazaDto> dtl)
        {
            var list = new List<DaSelectorKeyModel>();
            foreach (var dto in dtl)
            {
                list.Add(GetVMTyoaza(dto));
            }

            list.Add(new DaSelectorKeyModel("9999999", "町字マスタデータなし", ""));  //TODO　const
            return list;
        }

        /// <summary>
        /// 町字リスト行
        /// </summary>
        private static DaSelectorKeyModel GetVMTyoaza(tm_aftyoazaDto dto)
        {
            var labelnm = string.Empty;
            switch (dto.tyoazakbn)
            {
                case Enum町字区分.大字町名:
                    labelnm = CStr(dto.oazatyonm);
                    break;
                case Enum町字区分.丁目:
                    labelnm = CStr(dto.tyomeinm);
                    break;
                case Enum町字区分.小字:
                    labelnm = CStr(dto.koazanm);
                    break;
            }
            if (dto.tyoazaid == "0000000")  //TODO　const
            {
                labelnm = "町字なし";  //TODO  const
            }
            return new DaSelectorKeyModel(dto.tyoazaid, labelnm, dto.sikucd);
        }
    }
}
