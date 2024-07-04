// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 基幹系他システム情報照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.03
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00101G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 住民・住登外一覧取得
        /// </summary>
        public static List<PersonRowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg, adrsFlg)).ToList();
        }
        /// <summary>
        /// 世帯主情報
        /// </summary>
        public static SetaiHeaderVM GetVM(DaDbContext db, tt_afatenaDto dto, List<tm_afmeisyoDto> tikuList, List<tm_aftikuDto> dtl, bool adrsFlg)
        {
            var vm = new SetaiHeaderVM();
            vm.setaino = dto.setaino;                                                                           //世帯番号
            vm.kname = CStr(dto.simei_kana_yusen);                                                              //カナ氏名
            vm.name = dto.simei_yusen;                                                                          //氏名
            vm.kazeikbn_setai = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, CStr(dto.kazeikbn_setai));  //課税非課税区分
            //指定都市_行政区等
            vm.tosi_gyoseiku = DaSelectorService.GetCdNm(db, CStr(dto.tosi_gyoseikucd), Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.指定都市_行政区等コード));
            vm.adrs_yubin = dto.adrs_yubin;                                                                     //郵便番号
            vm.adrs = CmLogicUtil.GetAdrs(dto.jutokbn, dto.adrs1, dto.adrs2, adrsFlg);                          //住所
            vm.tikulist = GetVMList(dto, null, tikuList, dtl, false);                                           //地区一覧(ラベル、値)

            return vm;
        }
        /// <summary>
        /// 世帯成員一覧取得
        /// </summary>
        public static List<SetaiRowVM> GetVMList(DaDbContext db, List<tt_afatenaDto> dtl, bool alertviewflg)
        {
            var list = new List<SetaiRowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto, alertviewflg));
            }
            return list;
        }
        /// <summary>
        /// 住民情報(ヘッダー)
        /// </summary>
        public static PersonHeaderVM GetHeaderVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new PersonHeaderVM();
            vm = (PersonHeaderVM)Common.Wraper.GetHeaderVM(db, vm, dto, alertviewflg);
            vm.kazeikbn_setai = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, CStr(dto.kazeikbn_setai));  //課税非課税区分（世帯）
            vm.hokenkbn = DaNameService.GetName(db, EnumNmKbn.保険区分_共通管理, CStr(dto.hokenkbn));           //保険区分

            return vm;
        }
        /// <summary>
        /// 住民情報(明細)
        /// </summary>
        public static JuminVM GetVM(DaDbContext db, tt_afjumin_rekiDto dto, List<tm_afmeisyoDto> tikuList, List<tm_aftikuDto> dtl, string senusinm, bool personalflg, string publickey)
        {
            var vm = new JuminVM();
            vm.kojinrirekino = dto.kojinrirekino;                                                                           //個人履歴番号
            vm.kojinrireki_edano = dto.kojinrireki_edano;                                                                   //個人履歴番号_枝番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                      //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                     //最新フラグ
            vm.setaino = dto.setaino;                                                                                       //世帯番号
            vm.senusinm = senusinm;                                                                                         //世帯主名(最新)
            vm.personalno = (personalflg && !string.IsNullOrEmpty(dto.personalno)) ?
                DaEncryptUtil.AesDecryptAndRsaEncrypt(dto.personalno, publickey) : string.Empty;                            //個人番号(暗号化)
            vm.atenano = dto.atenano;                                                                                       //宛名番号
            vm.juminsyubetu = dto.juminsyubetu;                                                                             //住民種別
            vm.juminsyubetunm = DaNameService.GetName(db, EnumNmKbn.住民種別_住民基本台帳, EnumToStr(dto.juminsyubetu));    //住民種別(名称)
            vm.juminjotai = DaNameService.GetName(db, EnumNmKbn.住民状態_住民基本台帳, dto.juminjotai);                     //住民状態
            vm.simeiyusenkbn = DaNameService.GetName(db, EnumNmKbn.氏名優先区分, CStr(dto.simeiyusenkbn));                  //氏名優先区分(外国人のみ)
            vm.kokunm = CStr(dto.kokunm);                                                                                   //国籍名等(外国人のみ)
            vm.simei_kana = CStr(dto.simei_kana_yusen);                                                                     //氏名_フリガナ
            vm.simei = dto.simei_yusen;                                                                                     //氏名
            vm.simei_gaikanji = CStr(dto.simei_gaikanji);                                                                   //氏名_外国人漢字(外国人のみ)
            vm.simei_gairoma = CStr(dto.simei_gairoma);                                                                     //氏名_外国人ローマ字(外国人のみ)
            vm.tusyo_kana = CStr(dto.tusyo_kana);                                                                           //通称_フリガナ(外国人のみ)
            vm.tusyo = CStr(dto.tusyo);                                                                                     //通称(外国人のみ)
            vm.bymd = dto.bymd;                                                                                             //生年月日(不詳自動変換)
            vm.bymd_fusyohyoki = CStr(dto.bymd_fusyohyoki);                                                                 //生年月日_不詳表記
            vm.zokuhyoki = dto.zokuhyoki;                                                                                   //続柄表記
            vm.kyusi_kana = CStr(dto.kyusi_kana);                                                                           //旧氏_フリガナ(日本人のみ)
            vm.kyusi = CStr(dto.kyusi);                                                                                     //旧氏(日本人のみ)
            vm.adrs_yubin = dto.adrs_yubin;                                                                                 //住所_郵便番号
            vm.tosi_gyoseikunm = DaNameService.GetName(db, EnumNmKbn.指定都市_行政区等コード, CStr(dto.tosi_gyoseikucd));   //指定都市_行政区等(名称)
            vm.adrs_katagaki_kana = CStr(dto.adrs_katagaki_kana);                                                           //住所_方書_フリガナ
            vm.adrs = $"{dto.adrs_tyoaza}{dto.adrs_bantihyoki}{dto.adrs_katagaki}";                                         //住所(住所_町字、住所_番地号表記、住所_方書)
            vm.tikulist = GetVMList(null, dto, tikuList, dtl, true);                                                        //地区一覧(ラベル、値)
            vm.kiteikbn = DaNameService.GetName(db, EnumNmKbn.第30条45規定区分, CStr(dto.kiteikbn));                        //第30条45規定区分(外国人のみ)
            vm.zairyu = DaNameService.GetName(db, EnumNmKbn.在留資格等, CStr(dto.zairyucd));                                //在留資格等(名称)(外国人のみ)
            vm.zairyu_year = DaNameService.GetName(db, EnumNmKbn.在留期間等コード年, CStr(dto.zairyucd_year));              //在留期間（年）(外国人のみ)
            vm.zairyu_month = DaNameService.GetName(db, EnumNmKbn.在留期間等コード月, CStr(dto.zairyucd_month));            //在留期間（月）(外国人のみ)
            vm.zairyu_day = DaNameService.GetName(db, EnumNmKbn.在留期間等コード日, CStr(dto.zairyucd_day));                //在留期間（日）(外国人のみ)
            vm.zairyumanryoymd = FormatWaKjYMD(CNDate(dto.zairyumanryoymd));                                                //在留期間の満了の日(外国人のみ)
            vm.juymd = CStr(dto.juymd);                                                                                     //住民となった年月日(不詳自動変換)(日本人のみ)
            vm.juymd_fusyohyoki = CStr(dto.juymd_fusyohyoki);                                                               //住民となった年月日_不詳表記(日本人のみ)
            vm.gaijuymd = CStr(dto.gaijuymd);                                                                               //外国人住民となった年月日(不詳自動変換)(外国人のみ)
            vm.gaijuymd_fusyohyoki = CStr(dto.gaijuymd_fusyohyoki);                                                         //外国人住民となった年月日_不詳表記(外国人のみ)
            vm.tennyututiymd = FormatWaKjYMD(CNDate(dto.tennyututiymd));                                                    //転入通知年月日
            vm.delidoymd = CStr(dto.delidoymd);                                                                             //消除の異動年月日(不詳自動変換)
            vm.delidoymd_fusyohyoki = CStr(dto.delidoymd_fusyohyoki);                                                       //消除の異動年月日_不詳表記
            vm.todokeymd = FormatWaKjYMD(CNDate(dto.todokeymd));                                                            //消除の届出年月日
            vm.idoymd = dto.idoymd;                                                                                         //異動年月日(不詳自動変換)
            vm.idoymd_fusyohyoki = CStr(dto.idoymd_fusyohyoki);                                                             //異動年月日_不詳表記
            vm.idotodokeymd = FormatWaKjYMD(CNDate(dto.idotodokeymd));                                                      //異動届出年月日
            //異動事由
            var idojiyu1 = DaNameService.GetName(db, EnumNmKbn.記載の事由, dto.idojiyu);
            var idojiyu2 = DaNameService.GetName(db, EnumNmKbn.消除の事由, dto.idojiyu);
            var idojiyu3 = DaNameService.GetName(db, EnumNmKbn.修正の事由, dto.idojiyu);
            vm.idojiyu = $"{idojiyu1}{idojiyu2}{idojiyu3}";
            vm.tennyumaeadrs_yubin = CStr(dto.tennyumaeadrs_yubin);                                                         //転入前住所_郵便番号
            //転入前住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
            vm.tennyumaeadrs = $"{dto.tennyumaeadrs_todofuken}{dto.tennyumaeadrs_sikunm}{dto.tennyumaeadrs_tyoaza}{dto.tennyumaeadrs_bantihyoki}{dto.tennyumaeadrs_katagaki}";
            vm.tennyumaeadrs_kokunm = CStr(dto.tennyumaeadrs_kokunm);                                                       //転入前住所_国名等
            vm.tennyumaeadrs_gaiadrs = CStr(dto.tennyumaeadrs_gaiadrs);                                                     //転入前住所_国外住所
            vm.tennyumaeadrs_senusisimei = CStr(dto.tennyumaeadrs_senusisimei);                                             //転入前住所_世帯主氏名
            vm.tensyutuyoteiadrs_yubin = CStr(dto.tensyutuyoteiadrs_yubin);                                                 //転出先住所（予定）_郵便番号
            //転出先住所（予定）(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
            vm.tensyutuyoteiadrs = $"{dto.tensyutuyoteiadrs_todofuken}{dto.tensyutuyoteiadrs_sikunm}{dto.tensyutuyoteiadrs_tyoaza}{dto.tensyutuyoteiadrs_bantihyoki}{dto.tensyutuyoteiadrs_katagaki}";
            vm.tensyutuyoteiadrs_kokunm = CStr(dto.tensyutuyoteiadrs_kokunm);                                               //転出先住所（予定）_国名等
            vm.tensyutuyoteiadrs_gaiadrs = CStr(dto.tensyutuyoteiadrs_gaiadrs);                                             //転出先住所（予定）_国外住所
            vm.tensyutukakuteiadrs_yubin = CStr(dto.tensyutukakuteiadrs_yubin);                                             //転出先住所（確定）_郵便番号
            //転出先住所（確定）(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
            vm.tensyutukakuteiadrs = $"{dto.tensyutukakuteiadrs_todofuken}{dto.tensyutukakuteiadrs_sikunm}{dto.tensyutukakuteiadrs_tyoaza}{dto.tensyutukakuteiadrs_bantihyoki}{dto.tensyutukakuteiadrs_katagaki}";
            vm.tenkyomaeadrs_yubin = CStr(dto.tenkyomaeadrs_yubin);                                                         //転居前住所_郵便番号
            vm.tenkyomaeadrs_katagaki_kana = CStr(dto.tenkyomaeadrs_katagaki_kana);                                         //転居前住所_方書_フリガナ
            //転居前住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
            vm.tenkyomaeadrs = $"{dto.tenkyomaeadrs_todofuken}{dto.tenkyomaeadrs_sikunm}{dto.tenkyomaeadrs_tyoaza}{dto.tenkyomaeadrs_bantihyoki}{dto.tenkyomaeadrs_katagaki}";

            return vm;
        }
        /// <summary>
        /// 課税情報
        /// </summary>
        public static KazeiVM GetVM(DaDbContext db, tt_afkojinzeikazei_rekiDto dto)
        {
            var vm = new KazeiVM();

            vm.kazeinendo = dto.kazeinendo;                                                                                     //課税年度
            vm.kazeirirekino = dto.kazeirirekino;                                                                               //課税情報履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                          //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                         //最新フラグ
            vm.kazeikbn = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, dto.kazeikbn);                                    //課税非課税区分
            //指定都市_行政区等(名称)
            vm.tosi_gyoseiku = DaNameService.GetName(db, EnumNmKbn.指定都市_行政区等コード, CStr(dto.tosi_gyoseikucd));

            return vm;
        }
        /// <summary>
        /// 納税義務者情報
        /// </summary>
        public static NozeiVM GetVM(DaDbContext db, tt_afkojinzeigimusya_rekiDto dto, List<tm_afsikutyosonDto> dtl)
        {
            var vm = new NozeiVM();

            vm.kazeinendo = dto.kazeinendo;                                                                                                 //課税年度
            vm.kojinrirekino = dto.kojinrirekino;                                                                                           //個人履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                                      //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                                     //最新フラグ
            vm.misinkokukbn = DaNameService.GetName(db, EnumNmKbn.未申告区分, dto.misinkokukbn);                                            //未申告区分
            vm.takazeikbn = DaNameService.GetName(db, EnumNmKbn.他団体課税対象者区分, dto.takazeikbn);                                      //他団体課税対象者区分
            //他団体課税対象者の課税先市区町村(名称)
            var dto2 = dtl.Find(e => e.sikucd == CStr(dto.takazeisikucd));
            if (dto2 != null)
            {
                vm.takazeisiku = $"{dto2.todofukennm}{dto2.gunnm}{dto2.sikunm}{dto2.seireisikunm}";
            }
            //指定都市_行政区等(名称)
            vm.tosi_gyoseiku = DaNameService.GetName(db, EnumNmKbn.指定都市_行政区等コード, CStr(dto.tosi_gyoseikucd));

            return vm;
        }
        /// <summary>
        /// 控除情報(ヘッダー)
        /// </summary>
        public static KojoHeaderVM GetVM(DaDbContext db, tt_afkojinzeikojo_rekiDto dto)
        {
            var vm = new KojoHeaderVM();

            vm.kazeinendo = dto.kazeinendo;             //課税年度
            vm.kojorirekino = dto.kojorirekino;         //税額控除情報履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);  //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg); //最新フラグ

            return vm;
        }
        /// <summary>
        /// 控除情報一覧(明細)
        /// </summary>
        public static List<KojoRowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(row => GetVM(db, row)).ToList();
        }
        /// <summary>
        /// 国保情報
        /// </summary>
        public static KokuhoVM GetVM(DaDbContext db, tt_afkokuho_rekiDto dto)
        {
            var vm = new KokuhoVM();

            vm.hihokensyarirekino = dto.hihokensyarirekino;                                                             //被保険者履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                  //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                 //最新フラグ
            vm.sikutyosonhokenjano = dto.sikutyosonhokenjano;                                                           //市区町村保険者番号
            vm.hokenjanm = CStr(dto.hokenjanm);                                                                         //保険者名称
            vm.kokuho_kigono = dto.kokuho_kigono;                                                                       //国保記号番号
            vm.kokuho_edano = dto.kokuho_edano;                                                                         //枝番
            vm.kokuho_sikakukbn = DaNameService.GetName(db, EnumNmKbn.国保資格区分, dto.kokuho_sikakukbn);              //国保資格区分
            vm.kokuho_sikakusyutokuymd = FormatWaKjYMD(CDate(dto.kokuho_sikakusyutokuymd));                             //国保資格取得年月日
            //国保資格取得事由
            vm.kokuho_sikakusyutokujiyu = DaNameService.GetName(db, EnumNmKbn.国保資格取得事由_集約システム, dto.kokuho_sikakusyutokujiyu);
            vm.kokuho_sikakusosituymd = FormatWaKjYMD(CNDate(dto.kokuho_sikakusosituymd));                              //国保資格喪失年月日
            //国保資格喪失事由
            vm.kokuho_sikakusositujiyu = DaNameService.GetName(db, EnumNmKbn.国保資格喪失事由_集約システム, CStr(dto.kokuho_sikakusositujiyu));
            vm.kokuho_tekiyoymdf = FormatWaKjYMD(CDate(dto.kokuho_tekiyoymdf));                                         //国保適用開始年月日
            vm.kokuho_tekiyoymdt = FormatWaKjYMD(CNDate(dto.kokuho_tekiyoymdt));                                        //国保適用終了年月日
            vm.syokbn = DaNameService.GetName(db, EnumNmKbn.証区分, dto.syokbn);                                        //証区分
            vm.yukokigenymd = FormatWaKjYMD(CDate(dto.yukokigenymd));                                                   //有効期限
            vm.marugakumaruenkbn = DaNameService.GetName(db, EnumNmKbn.マル学マル遠区分, CStr(dto.marugakumaruenkbn));  //マル学マル遠区分

            return vm;
        }
        /// <summary>
        /// 後期情報
        /// </summary>
        public static KokiVM GetVM(DaDbContext db, tt_afkokihoken_rekiDto dto)
        {
            var vm = new KokiVM();

            vm.rirekino = dto.rirekino;                                                                                                 //履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                                  //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                                 //最新フラグ
            vm.hihokensyano = dto.hihokensyano;                                                                                         //被保険者番号
            vm.kojinkbnnm = DaNameService.GetName(db, EnumNmKbn.個人区分コード, dto.kojinkbncd);                                        //個人区分(名称)
            vm.hiho_sikakusyutokujiyunm = DaNameService.GetName(db, EnumNmKbn.資格取得事由コード, dto.hiho_sikakusyutokujiyucd);        //被保険者資格取得事由(名称)
            vm.hiho_sikakusyutokuymd = FormatWaKjYMD(CDate(dto.hiho_sikakusyutokuymd));                                                 //被保険者資格取得年月日
            vm.hiho_sikakusositujiyunm = DaNameService.GetName(db, EnumNmKbn.資格喪失事由コード, CStr(dto.hiho_sikakusositujiyucd));    //被保険者資格喪失事由(名称)
            vm.hiho_sikakusosituymd = FormatWaKjYMD(CNDate(dto.hiho_sikakusosituymd));                                                  //被保険者資格喪失年月日
            vm.hoken_tekiyoymdf = FormatWaKjYMD(CDate(dto.hoken_tekiyoymdf));                                                           //保険者番号適用開始年月日
            vm.hoken_tekiyoymdt = FormatWaKjYMD(CNDate(dto.hoken_tekiyoymdt));                                                          //保険者番号適用終了年月日

            return vm;
        }
        /// <summary>
        /// 生保情報
        /// </summary>
        public static SeihoVM GetVM(DaDbContext db, tt_afseiho_rekiDto dto)
        {
            var vm = new SeihoVM();
            vm.sinseirirekino = dto.sinseirirekino;                                                     //申請履歴番号
            vm.ketteirirekino = dto.ketteirirekino;                                                     //決定履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                  //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                 //最新フラグ
            vm.fukusijimusyocd = dto.fukusijimusyocd;                                                   //福祉事務所コード
            vm.caseno = dto.caseno;                                                                     //ケース番号
            vm.inno = dto.inno;                                                                         //員番号
            vm.seihoymdf = FormatWaKjYMD(CDate(dto.seihoymdf));                                         //生活保護開始年月日
            vm.teisiymd = FormatWaKjYMD(CDate(dto.teisiymd));                                           //停止年月日
            vm.teisikaijoymd = FormatWaKjYMD(CNDate(dto.teisikaijoymd));                                //停止解除年月日
            vm.tanheikyukbn = DaNameService.GetName(db, EnumNmKbn.単併給区分, CStr(dto.tanheikyukbn));  //単併給区分(名称)
            vm.seikatufujoflg = CBool(dto.seikatufujoflg);                                              //生活扶助フラグ
            vm.jutakufujoflg = CBool(dto.jutakufujoflg);                                                //住宅扶助フラグ
            vm.kyoikufujoflg = CBool(dto.kyoikufujoflg);                                                //教育扶助フラグ
            vm.iryofujoflg = CBool(dto.iryofujoflg);                                                    //医療扶助フラグ
            vm.syussanfujoflg = CBool(dto.syussanfujoflg);                                              //出産扶助フラグ
            vm.seigyofujoflg = CBool(dto.seigyofujoflg);                                                //生業扶助フラグ
            vm.sosaifujoflg = CBool(dto.sosaifujoflg);                                                  //葬祭扶助フラグ
            vm.haisiymd = FormatWaKjYMD(CNDate(dto.haisiymd));                                          //廃止年月日

            return vm;
        }
        /// <summary>
        /// 介護情報
        /// </summary>
        public static KaigoVM GetVM(DaDbContext db, tt_afkaigo_rekiDto dto)
        {
            var vm = new KaigoVM();

            vm.sikakurirekino = dto.sikakurirekino;                                                                      //資格履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                   //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                  //最新フラグ
            vm.kaigohokensyano = dto.kaigohokensyano;                                                                    //介護保険者番号
            vm.hihokensyano = dto.hihokensyano;                                                                          //被保険者番号
            vm.hihokensyakbn = DaNameService.GetName(db, EnumNmKbn.被保険者区分コード, dto.hihokensyakbncd);             //被保険者区分(名称)
            vm.sikakusyutokuymd = FormatWaKjYMD(CDate(dto.sikakusyutokuymd));                                            //資格取得日
            vm.sikakusosituymd = FormatWaKjYMD(CDate(dto.sikakusosituymd));                                              //資格喪失日
            vm.yokaigoninteijokyo = DaNameService.GetName(db, EnumNmKbn.要介護認定状況コード, dto.yokaigoninteijokyocd); //要介護認定状況(名称)
            vm.yokaigojotaikbn = DaNameService.GetName(db, EnumNmKbn.要介護状態区分コード, CStr(dto.yokaigojotaikbncd)); //要介護状態区分(名称)
            vm.yokaigoninteiymd = FormatWaKjYMD(CNDate(dto.yokaigoninteiymd));                                           //要介護認定日
            vm.yokaigoyukoymdf = FormatWaKjYMD(CNDate(dto.yokaigoyukoymdf));                                             //要介護認定有効期間開始日
            vm.yokaigoyukoymdt = FormatWaKjYMD(CNDate(dto.yokaigoyukoymdt));                                             //要介護認定有効期間終了日
            vm.kohijukyusyano = dto.kohijukyusyano;                                                                      //公費受給者番号

            return vm;
        }
        /// <summary>
        /// 障害情報
        /// </summary>
        public static SyogaiVM GetVM(DaDbContext db, tt_afsyogaitetyo_rekiDto dto)
        {
            var vm = new SyogaiVM();

            vm.rirekino = dto.rirekino;                                                                                  //履歴番号
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                   //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                  //最新フラグ
            vm.sikakujotai = DaNameService.GetName(db, EnumNmKbn.資格状態, dto.sikakujotaicd);                           //資格状態(名称)
            vm.tetyono = CStr(dto.tetyono);                                                                              //手帳番号
            vm.syokaikofuymd = FormatWaKjYMD(CNDate(dto.syokaikofuymd));                                                 //初回交付日
            vm.henkanymd = FormatWaKjYMD(CNDate(dto.henkanymd));                                                         //返還日
            vm.syogaisyubetu = DaNameService.GetName(db, EnumNmKbn.身体障害者手帳障害種別, CStr(dto.syogaisyubetucd));   //障害種別(名称)
            vm.sogotokyu = DaNameService.GetName(db, EnumNmKbn.身体障害者手帳総合等級, CStr(dto.sogotokyucd));           //総合等級(名称)
            vm.tokeibui = DaNameService.GetName(db, EnumNmKbn.身体障害者手帳障害部位, CStr(dto.tokeibuicd));             //統計部位(名称)
            vm.syogainm = CStr(dto.syogainm);                                                                            //障害名

            return vm;
        }

        /// <summary>
        /// 住民・住登外情報(1行)
        /// </summary>
        private static PersonRowVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new PersonRowVM();
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                   //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                  //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));            //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                              //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                     //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                            //住所
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, row);                       //行政区
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                         //住民区分
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));          //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);     //警告内容
            vm.jutokbn = (Enum住登区分)row.CInt(nameof(tt_afatenaDto.jutokbn));     //住登区分

            return vm;
        }
        /// <summary>
        /// 地区情報一覧
        /// </summary>
        private static List<TikuVM> GetVMList(tt_afatenaDto? dto1, tt_afjumin_rekiDto? dto2, List<tm_afmeisyoDto> dtl1, List<tm_aftikuDto> dtl2, bool rirekiflg)
        {
            var list = new List<TikuVM>();
            foreach (var d in dtl1)
            {
                list.Add(GetVM(dto1, dto2, d, dtl2, rirekiflg));
            }
            return list;
        }
        /// <summary>
        /// 地区情報(1行)
        /// </summary>
        private static TikuVM GetVM(tt_afatenaDto? dto1, tt_afjumin_rekiDto? dto2, tm_afmeisyoDto dto3, List<tm_aftikuDto> dtl, bool rirekiflg)
        {
            var vm = new TikuVM();
            //地区区分
            var tikukbn = (Enum地区区分)CInt(dto3.nmcd);
            //地区コード一覧
            var tikuList = dtl.Where(e => e.tikukbn == tikukbn).ToList();

            //地区区分(名称)
            vm.tikukbn = dto3.nm;
            //行政区標記
            if (CBool(dto3.hanyokbn2))
            {
                vm.tikukbn = $"{dto3.nm}(行政区)";//要らないかも
            }
            //地区(名称)
            switch (tikukbn)
            {
                case Enum地区区分.地区1:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd1 : dto1!.tikukanricd1);
                    break;
                case Enum地区区分.地区2:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd2 : dto1!.tikukanricd2);
                    break;
                case Enum地区区分.地区3:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd3 : dto1!.tikukanricd3);
                    break;
                case Enum地区区分.地区4:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd4 : dto1!.tikukanricd4);
                    break;
                case Enum地区区分.地区5:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd5 : dto1!.tikukanricd5);
                    break;
                case Enum地区区分.地区6:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd6 : dto1!.tikukanricd6);
                    break;
                case Enum地区区分.地区7:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd7 : dto1!.tikukanricd7);
                    break;
                case Enum地区区分.地区8:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd8 : dto1!.tikukanricd8);
                    break;
                case Enum地区区分.地区9:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd9 : dto1!.tikukanricd9);
                    break;
                case Enum地区区分.地区10:
                    vm.tiku = GetTikuNm(tikuList, rirekiflg ? dto2!.tikukanricd10 : dto1!.tikukanricd10);
                    break;
                default:
                    throw new Exception("Enum地区区分 error");
            }

            return vm;
        }
        /// <summary>
        /// 地区取得(名称)
        /// </summary>
        private static string GetTikuNm(List<tm_aftikuDto> dtl, string? cd)
        {
            if (!string.IsNullOrEmpty(cd))
            {
                var dto = dtl.Find(e => e.tikucd == cd);
                return dto!.tikunm;
            }
            return string.Empty;
        }
        /// <summary>
        /// 世帯成員情報(1行)
        /// </summary>
        private static SetaiRowVM GetVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new SetaiRowVM();
            vm.atenano = dto.atenano;                                                                   //宛名番号
            vm.name = dto.simei_yusen;                                                                  //氏名
            vm.kname = CStr(dto.simei_kana_yusen);                                                      //カナ氏名
            vm.sex = CmLogicUtil.GetSex(db, dto.sex);                                                   //性別
            vm.bymd = CmLogicUtil.GetYMDStr(dto.bymd_fusyoflg, dto.bymd, dto.bymd_fusyohyoki);          //生年月日
            vm.age = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd);                                //年齢
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, dto.juminkbn);                  //住民区分
            vm.zokuhyoki = dto.zokuhyoki;                                                               //続柄
            vm.hokenkbn = DaNameService.GetName(db, EnumNmKbn.保険区分_共通管理, CStr(dto.hokenkbn));   //保険区分
            vm.kazeikbn = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, CStr(dto.kazeikbn));      //課税非課税区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto.siensotikbn, alertviewflg);                     //警告内容
            vm.jutokbn = dto.jutokbn;                                                                   //住登区分

            return vm;
        }
        /// <summary>
        /// 控除情報(1件)
        /// </summary>
        private static KojoRowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new KojoRowVM();

            vm.kojocd = row.Wrap(nameof(KojoRowVM.kojocd));                                         //税額・税額控除コード
            vm.kojonm = DaNameService.GetName(db, EnumNmKbn.税額_税額控除, vm.kojocd);              //税額・税額控除名
            var cd = row.Wrap(nameof(tt_afkojinzeikojo_rekiDto.tosi_gyoseikucd));                   //指定都市_行政区等コード
            vm.tosi_gyoseikunm = DaNameService.GetName(db, EnumNmKbn.指定都市_行政区等コード, cd);  //指定都市_行政区等(名称)
            vm.kojokingaku = row.CLng(nameof(KojoRowVM.kojokingaku));                               //税額控除金額

            return vm;
        }
    }
}