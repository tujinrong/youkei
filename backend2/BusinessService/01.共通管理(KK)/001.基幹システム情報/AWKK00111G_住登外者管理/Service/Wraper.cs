// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 住登外者管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.09
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWKK00111G
{
    public class Wraper : CmWraperBase
    {

        //定数定義
        private const string TYOAZA_ALL0 = "0000000";     //町字コードは0000000の場合：空白で表示
        private const string TYOAZA_ALL9 = "9999999";     //町字コードは9999999の場合：町字マスタデータなし、町字名を空白表示
        private const string JYUTOGAIINFO = "2";          //町字コードは9999999の場合：町字マスタデータなし、町字名を空白表示

        /// <summary>
        /// 住登外者情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg)).ToList();
        }

        /// <summary>
        /// 住登外者参照業務情報(一覧)
        public static RowVM GetVM(DaDbContext db, DataRow row, bool alertviewflg)
        {
            var vm = new RowVM();

            vm.atenano = row.Wrap(nameof(vm.atenano));                                  //宛名番号
            vm.rirekino = CInt(row.Wrap(nameof(vm.rirekino)));                          //履歴番号
            vm.stopflg = FormatFlgStr(row.CBool(nameof(tt_afjutogaiDto.stopflg)));      //削除
            vm.name = row.Wrap(nameof(tt_afjutogaiDto.simei_yusen));                    //氏名
            vm.kname = row.Wrap(nameof(tt_afjutogaiDto.simei_kana_yusen));              //カナ氏名
            vm.sexhyoki = row.Wrap(nameof(tt_afjutogaiDto.sexhyoki));                   //性別（名称）
            var jutokbn = row.Wrap(nameof(tt_afatenaDto.jutokbn));                      //住登区分
            var juminbetu = row.Wrap(nameof(tt_afjutogaiDto.jutogaisyasyubetu));        //住民種別コード
            var juminjotai = row.Wrap(nameof(tt_afjutogaiDto.jutogaisyajotai));         //住民状態コード
            vm.juminkbn = Service.GetJuminkbn(db, jutokbn, juminbetu, juminjotai);      //住民区分（住登外者種別、住登外者状態の値から住民区分の表示内容を取得）
            vm.bymd = GetBymd(row);                                                     //生年月日
            vm.adrs = GetAdrs(row);                                                     //住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));              //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        /// <summary>
        /// 初期化処理(詳細画面)
        public static InitDetailVM GetVM(DaDbContext db, List<DaSelectorModelExp> dtl1, List<DaSelectorKeyModel> dtl2)
        {
            var vm = new InitDetailVM();

            //チェックボックス初期設定
            //vm.fusyoflg = false;        //生年月日不詳フラグフラグ

            //ドロップダウンリスト初期設定
            vm.selectorlist1 = MList(db, EnumNmKbn.住登外者異動事由);                   //異動事由
            vm.selectorlist2 = MList(db, EnumNmKbn.指定都市_行政区等コード);            //行政区等
            vm.selectorlist3 = dtl1;                                                    //市区町村
            vm.selectorlist4 = dtl2;                                                    //町字
            vm.selectorlist5 = MList(db, EnumNmKbn.住民種別);                  //住民種別
            vm.selectorlist6 = MList(db, EnumNmKbn.住民状態);                  //住民状態
            vm.selectorlist7 = MList(db, EnumNmKbn.性別_団体内統合宛名);                //性別
            vm.selectorlist8 = MList(db, EnumNmKbn.国名コード);                         //国名等
            vm.selectorlist9 = MList(db, EnumNmKbn.保険区分_共通管理);                  //保険区分
            vm.selectorlist10 = MList(db, EnumNmKbn.他業務参照不可フラグ);              //他業務参照不可
            var dokujisystemnmlist = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.独自施策システム等ID);
            vm.dokujisystemnmlist = MRefList(db, dokujisystemnmlist);                   //独自施策システム等ID
            var sansyogyomunmlist = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.業務ID);
            vm.sansyogyomunmlist = MRefList(db, sansyogyomunmlist);                     //業務ID
            vm.selectorlist11 = MList(db, EnumNmKbn.名寄せ元フラグ);                    //名寄せ元
            vm.selectorlist12 = MList(db, EnumNmKbn.統合宛名フラグ);                    //統合宛名フラグ
            var busyolist = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.登録部署);
            vm.selectorlist13 = MRefList(db, busyolist);                                //登録部署

            return vm;
        }

        /// <summary>
        /// 詳細画面--ヘッダー部
        /// </summary>
        public static BaseInfoVM GetVM(DaDbContext db, tt_afatenaDto dto1, tt_afjutogaiDto? dto2, bool alertviewflg)
        {
            var vm = new BaseInfoVM();

            //ヘッダー部
            vm.atenano = CStr(dto1.atenano);                                            //宛名番号
            vm.name = CStr(dto1.simei_yusen);                                           //氏名（氏名_優先）
            vm.kname = CStr(dto1.simei_kana_yusen);                                     //カナ氏名（氏名_フリガナ_優先）
            vm.sex = CmLogicUtil.GetSex(db, CStr(dto1.sex));                            //性別

            vm.bymd = GetBymd(dto1);                                                    //生年月日
            var juminkbn = CStr(dto1.juminkbn);
            vm.juminkbnnm = MNm(db, juminkbn, EnumNmKbn.住民区分);                      //住民区分
            vm.age = CmLogicUtil.GetAgeStr(dto1.bymd_fusyoflg, dto1.bymd);              //年齢
            vm.agekijunymd = FormatWaKjYMD(DaUtil.Today);                               //年齡計算基準日
            var kazeikbn_setai = CStr(dto1.kazeikbn_setai);
            vm.kazeikbn_setai = MNm(db, kazeikbn_setai, EnumNmKbn.課税非課税区分);      //課税非課税区分（世帯）
            var hokenkbn = CStr(dto1.hokenkbn);
            vm.hokenkbn = MNm(db, hokenkbn, EnumNmKbn.保険区分_共通管理);               //保険区分
            if (dto2 != null) vm.stop = FormatFlgStr(dto2.stopflg);                     //削除
            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto1.siensotikbn, alertviewflg);    //警告有無

            return vm;
        }

        /// <summary>
        /// 詳細画面--住登外者詳細_基本情報等タブ
        /// </summary>
        public static MainInfoVM GetVM(DaDbContext db, tt_afjutogaiDto dto, string? personalno, string simei_yusen, string jutokbn, bool personalflg, string publickey)
        {
            var vm = new MainInfoVM();

            //明細部(基本情報等タブ)
            vm.rirekino = dto.rirekino;                                                             //履歴番号
            vm.upddttm = dto.upddttm;                                                               //更新日時(排他も利用)
            vm.saisin = FormatFlgStr(dto.saisinflg);                                                //最新
            vm.stop = FormatFlgStr(dto.stopflg);                                                    //削除

            //明細部(異動情報)
            vm.idoymd = CNStr(dto.idoymd);                                                          //異動年月日
            vm.idotodokeymd = CStr(dto.idotodokeymd);                                               //異動届出年月日
            vm.idojiyu = MCdNm(db, CStr(dto.idojiyu), EnumNmKbn.住登外者異動事由);                  //異動事由（コード：名称）

            //明細部(基本情報（世帯）)
            vm.setaino = CStr(dto.setaino);                                                         //世帯番号
            vm.senusinm = simei_yusen;                                                              //世帯主名
            vm.adrs_yubin = CNStr(dto.adrs_yubin);                                                  //郵便番号
            //指定都市_行政区等コード（コード：名称）
            vm.tosi_gyoseikucd = MCdNm(db, CStr(dto.tosi_gyoseikucd), EnumNmKbn.指定都市_行政区等コード);
            vm.adrs_sikucd = MCdNmExp(dto.adrs_sikucd, dto.adrs_todofuken, dto.adrs_sikunm);        //市区町村
            vm.adrs_todofuken = CStr(dto.adrs_todofuken);                                           //都道府県
            vm.adrs_sikunm = CStr(dto.adrs_sikunm);                                                 //市区町村名
            vm.adrs_tyoazacd = $"{dto.adrs_tyoazacd}{C_SPACE}{C_COLON}{C_SPACE}{dto.adrs_tyoaza}";  //町字コード
            vm.adrs_tyoaza = CNStr(dto.adrs_tyoaza);                                                //町字名
            vm.adrs_bantihyoki = CStr(dto.adrs_bantihyoki);                                         //番地号表記
            vm.adrs_katagaki_kana = CStr(dto.adrs_katagaki_kana);                                   //方書(フリガナ)
            vm.adrs_katagaki = CStr(dto.adrs_katagaki);                                             //方書(漢字)

            //明細部(基本情報（個人）)
            vm.atenano = CStr(dto.atenano);                                                         //宛名番号
            vm.personalno = (personalflg && !string.IsNullOrEmpty(personalno)) ?
                    DaEncryptUtil.AesDecryptAndRsaEncrypt(personalno, publickey) : string.Empty;    //個人番号(暗号化)
            vm.jutogaisyasyubetu = MCdNm(db, CStr(dto.jutogaisyasyubetu), EnumNmKbn.住民種別); //住登外者種別(コード)
            vm.jutogaisyajotai = MCdNm(db, CStr(dto.jutogaisyajotai), EnumNmKbn.住民状態);     //住登外者状態(コード)
            var juminbetu = CStr(dto.jutogaisyasyubetu);                                            //住民種別コード
            var juminjotai = CStr(dto.jutogaisyajotai);                                             //住民状態コード
            vm.juminkbn = Service.GetJuminkbn(db, jutokbn, juminbetu, juminjotai);                  //住民区分（住登外者種別、住登外者状態の値から住民区分の表示内容を取得）
            vm.si_kana = CNStr(dto.si_kana);                                                        //氏_日本人_フリガナ
            vm.mei_kana = CNStr(dto.mei_kana);                                                      //名_日本人_フリガナ
            vm.si = CNStr(dto.si);                                                                  //氏_日本人
            vm.mei = CNStr(dto.mei);                                                                //名_日本人
            vm.simei_kana = CNStr(dto.simei_kana);                                                  //氏名_フリガナ
            vm.simei_gaikanji = CNStr(dto.simei_gaikanji);                                          //氏名_外国人漢字
            vm.simei_gairoma = CNStr(dto.simei_gairoma);                                            //氏名_外国人ローマ字
            vm.tusyo_kana = CNStr(dto.tusyo_kana);                                                  //通称_フリガナ
            vm.tusyo = CNStr(dto.tusyo);                                                            //通称漢字
            vm.tusyo_kanastatus = CNStr(dto.tusyo_kanastatus);                                      //通称_フリガナ確認状況
            vm.sex = MCdNm(db, CStr(dto.sex), EnumNmKbn.性別_団体内統合宛名);                       //性別（コード：名称）
            vm.bymd = CNStr(dto.bymd);                                                              //生年月日
            vm.bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                                            //生年月日_不詳フラグ
            vm.bymd_fusyohyoki = CNStr(dto.bymd_fusyohyoki);                                        //生年月日(不詳表記)
            vm.adrs_kokunmcd = CStr(dto.adrs_kokunmcd);                                             //住所_国名コード
            vm.adrs_kokunm = CStr(dto.adrs_kokunm);                                                 //住所_国名等
            vm.adrs_gaiadrs = CNStr(dto.adrs_gaiadrs);                                              //住所_国外住所	

            //明細部(その他情報)
            vm.hokenkbn = MCdNm(db, CStr(dto.hokenkbn), EnumNmKbn.保険区分_共通管理);              //保険区分（コード：名称）
            vm.sansyofuka = MCdNm(db, CStr(dto.sansyofukaflg), EnumNmKbn.他業務参照不可フラグ);    //他業務参照不可
            vm.nayosemotoflg = MCdNm(db, CStr(dto.nayosemotoflg), EnumNmKbn.名寄せ元フラグ);       //名寄せ元
            vm.nayosesakiatenano = CStr(dto.nayosesakiatenano);                                    //名寄せ先宛名番号
            vm.togoatenaflg = MCdNm(db, CStr(dto.togoatenaflg), EnumNmKbn.統合宛名フラグ);         //統合宛名フラグ
            vm.regbusyocd = HCdNm(db, CStr(dto.regbusyocd), EnumHanyoKbn.登録部署);     //登録部署

            return vm;
        }

        /// <summary>
        /// 詳細画面--世帯情報
        /// </summary>
        public static SeitaiInfoVM GetVM(DaDbContext db, tt_afjutogaiDto dto, SeitaiInfoVM vm)
        {
            //明細部(基本情報（世帯）)
            vm.setaino = CStr(dto.setaino);                                             //世帯番号
            vm.adrs_yubin = CNStr(dto.adrs_yubin);                                      //郵便番号
            vm.tosi_gyoseikucd = CStr(dto.tosi_gyoseikucd);                             //指定都市_行政区等コード
            vm.adrs_sikucd = CNStr(dto.adrs_sikucd);                                    //市区町村
            vm.adrs_tyoazacd = CStr(dto.adrs_tyoazacd);                                 //町字コード
            vm.adrs_tyoaza = CNStr(dto.adrs_tyoaza);                                    //町字名
            vm.adrs_bantihyoki = CStr(dto.adrs_bantihyoki);                             //番地号表記
            vm.adrs_katagaki_kana = CStr(dto.adrs_katagaki_kana);                       //方書(フリガナ)
            vm.adrs_katagaki = CStr(dto.adrs_katagaki);                                 //方書(漢字)

            vm.adrs_todofuken = CStr(dto.adrs_todofuken);                               //都道府県
            vm.adrs_sikunm = CStr(dto.adrs_sikunm);                                     //市区町村名

            return vm;
        }

        /// <summary>
        /// 詳細画面--異動情報
        /// </summary>
        public static IdoInfoVM GetVM(DaDbContext db, tt_afjutogaiDto dto, IdoInfoVM vm)
        {
            //明細部(基本情報（異動）)
            vm.idoymd = CStr(dto.idoymd);                                               //異動年月日
            vm.idotodokeymd = CStr(dto.idotodokeymd);                                   //異動届出年月日
            vm.idojiyu = CStr(dto.idojiyu);                                             //異動事由

            return vm;
        }

        /// <summary>
        /// 初期化処理(詳細画面)
        public static YubinInfoVM GetVM(DaDbContext db, tm_aftyoazaDto dto1, tm_afsikutyosonDto? dto2)
        {
            var vm = new YubinInfoVM();

            vm.adrs_sikucd = dto1.sikucd;                   //市区町村コード		
            vm.adrs_tyoazacd = dto1.tyoazaid;               //町字コード		
            vm.adrs_tyoaza = GetTyoaza(vm, dto1);           //町字名
            if (dto2 != null)
            {
                vm.adrs_todofuken = dto2.todofukennm;       //都道府県
                vm.adrs_sikunm = dto2.sikunm;               //市区町村名
            }

            return vm;
        }


        /// <summary>
        /// 参照系情報一覧（参照業務リストと参照独自施策システム等リスト用）
        /// </summary>
        public static List<RefListVM> GetVMList(DaDbContext db, List<string> keylist, EnumHanyoKbn kbn)
        {
            var list = new List<RefListVM>();

            foreach (string key in keylist)
            {
                var nm = HNm(db, key, kbn);
                var vm = new RefListVM()
                {
                    hanyocd = key,              //汎用コード
                    nm = nm,                    //名称
                };

                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 状態一覧取得(保存処理)
        /// </summary>
        public static List<StatusVM> GetVMList(EnumAtenaActionType kbn)
        {
            var list = new List<StatusVM>();
            list.Add(new StatusVM
            {
                statuskbn = (EnumActionType)kbn,
            });
            return list;
        }

        /// <summary>
        /// 住所取得
        /// </summary>
        public static string GetAdrs(DataRow row)
        {
            var adrs1 = row.Wrap(nameof(tt_afjutogaiDto.adrs_todofuken));               //住所_都道府県
            var adrs2 = row.Wrap(nameof(tt_afjutogaiDto.adrs_sikunm));                  //住所_市区郡町村名
            var adrs3 = row.Wrap(nameof(tt_afjutogaiDto.adrs_tyoaza));                  //住所_町字
            var adrs4 = row.Wrap(nameof(tt_afjutogaiDto.adrs_bantihyoki));              //住所_番地号表記
            var adrs5 = row.Wrap(nameof(tt_afjutogaiDto.adrs_katagaki));                //住所_方書

            return $"{adrs1}{adrs2}{adrs3}{adrs4}{adrs5}";
        }

        /// <summary>
        /// 氏名フリガナ取得
        /// </summary>
        public static string GetTyoaza(YubinInfoVM vm, tm_aftyoazaDto? dto)
        {
            string str = string.Empty;

            //氏名_フリガナを取得
            switch (vm.adrs_tyoazacd)
            {
                case TYOAZA_ALL0:     // 町字コードは0000000の場合：空白で表示
                    str = string.Empty;
                    break;

                case TYOAZA_ALL9:     // 町字コードは9999999の場合：町字マスタデータなし、町字名を空白表示
                    str = CStr(vm.adrs_tyoaza);
                    break;
                default:            //上記以外の場合、町字区分コードにより判断
                    //町字区分コードにより判断
                    if (dto == null) { return str; }

                    switch (dto.tyoazakbn)
                    {
                        case Enum町字区分.大字町名:     // 大字・町名（oazatyonm）を利用する
                            str = CStr(dto.oazatyonm);
                            break;
                        case Enum町字区分.丁目:         // 丁目名（tyomeinm）を利用する
                            str = CStr(dto.tyomeinm);
                            break;
                        case Enum町字区分.小字:         // 小字名（koazanm）を利用する
                            str = CStr(dto.koazanm);
                            break;
                        default:                        //上記以外の場合、町字区分コードにより判断
                            str = string.Empty;
                            break;
                    }
                    break;
            }

            return str;
        }

        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        public static string MNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 汎用マスタから名称取得
        /// </summary>
        public static string HNm(DaDbContext db, string cd, EnumHanyoKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 名称マスタからコード：名称リストを取得
        /// </summary>
        public static List<DaSelectorModel> MList(DaDbContext db, EnumNmKbn kbn)
        {
            return DaNameService.GetSelectorList(db, kbn, Enum名称区分.名称);
        }

        public static List<DaSelectorModel> MRefList(DaDbContext db, List<tm_afhanyoDto> list)
        {
            return list.Select(e => new DaSelectorModel(e.hanyocd, e.nm)).ToList();
        }

        /// <summary>
        /// 名称マスタからコード：名称取得
        /// </summary>
        public static string MCdNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            if (string.IsNullOrEmpty(cd)) { return string.Empty; }

            var nm = DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));

            return $"{cd}{C_SPACE}{C_COLON}{C_SPACE}{nm}";
        }

        /// <summary>
        /// 名称マスタからコード：名称 拡名称1 拡名称2取得（市区町村リスト用）
        /// </summary>
        public static string MCdNmExp(string? cd, string? expname1, string? expname2)
        {
            if (string.IsNullOrEmpty(cd)) { return string.Empty; }

            if (!string.IsNullOrEmpty(expname1) && !string.IsNullOrEmpty(expname2))
            {
                return $"{cd}{C_SPACE}{C_COLON}{C_SPACE}{expname1}{expname2}{C_SPACE}{expname1}{C_SPACE}{expname2}";
            }

            return string.Empty;
        }

        /// <summary>
        /// 汎用マスタからコード：名称取得
        /// </summary>
        public static string HCdNm(DaDbContext db, string cd, EnumHanyoKbn kbn)
        {
            if (string.IsNullOrEmpty(cd)) { return string.Empty; }

            var nm = DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, EnumToStr(kbn));

            return $"{cd}{C_SPACE}{C_COLON}{C_SPACE}{nm}";
        }

        /// <summary>
        /// 生年月日表記取得
        /// </summary>
        public static string GetBymd(tt_afatenaDto dto)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);
            //生年月日
            var bymd = CStr(dto.bymd);
            //生年月日_不詳表記
            var bymd_fusyohyoki = CNStr(dto.bymd_fusyohyoki);

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (!CBool(bymd_fusyoflg) && string.IsNullOrEmpty(bymd.Trim())) { return string.Empty; }

            return CmLogicUtil.GetYMDStr(bymd_fusyoflg, bymd, bymd_fusyohyoki);
        }

        /// <summary>
        /// 生年月日表記取得（不詳フラグ=falseまたは生年月日=nullの場合空白で戻る）
        /// </summary>
        public static string GetBymd(DataRow row)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = row.CNBool(nameof(tt_afatenaDto.bymd_fusyoflg));
            //生年月日
            var bymd = row.CStr(nameof(tt_afatenaDto.bymd));
            //生年月日_不詳表記
            var bymd_fusyohyoki = row.CStr(nameof(tt_afatenaDto.bymd_fusyohyoki));

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (!CBool(bymd_fusyoflg) && string.IsNullOrEmpty(bymd.Trim())) { return string.Empty; }

            return CmLogicUtil.GetYMDStr(bymd_fusyoflg, bymd, bymd_fusyohyoki);
        }
    }
}
