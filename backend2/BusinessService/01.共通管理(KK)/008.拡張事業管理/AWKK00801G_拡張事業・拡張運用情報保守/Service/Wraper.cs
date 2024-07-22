// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 拡事業・拡運用情報保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWKK00801G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// ドロップダウンリスト取得(選択画面：種類)
        /// </summary>
        public static List<DaSelectorKeyModel2> GetSelectorList(List<tm_afmeisyoDto> list, Enum名称区分 kbn)
        {
            return list.Select(e => GetVM(e, kbn)).ToList();
        }

        /// <summary>
        /// 検診事業一覧取得
        /// </summary>
        public static List<KensinListRowVM> GetVMList(DaDbContext db, List<tm_afhanyoDto> dtl1, List<tm_shkensinjigyoDto> dtl2)
        {
            var list = new List<KensinListRowVM>();
            foreach (var dto in dtl1)
            {
                var dto2 = dtl2.Find(e => e.jigyocd == dto.hanyocd)!;
                list.Add(GetVM(db, dto, dto2));
            }

            return list.OrderBy(e => CInt(e.jigyokbn)).ThenBy(e => e.jigyocd).ToList();
        }

        /// <summary>
        /// 検診項目一覧画面ヘッダー情報取得
        /// </summary>
        public static KensinCommonHeaderVM GetHeaderVM(DaDbContext db, tm_afhanyoDto? dto)
        {
            var vm = new KensinCommonHeaderVM();
            vm.jigyonm = CStr(dto?.nm);                                                                             //事業名
            vm.jigyoshortnm = CStr(dto?.shortnm);                                                                   //事業名略称

            return vm;
        }

        /// <summary>
        /// 検診項目一覧取得
        /// </summary>
        public static List<KensinItemListRowVM> GetVMList(DaDbContext db, List<tm_shfreeitemDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            var list = new List<KensinItemListRowVM>();
            foreach (var dto in dtl1)
            {
                list.Add(GetVM(db, dto, dtl2));
            }

            return list;
        }

        /// <summary>
        /// 検診事業情報取得(事業内容)
        /// </summary>
        public static KensinDetailJigyoVM GetJigyoVM(DaDbContext db, tm_afkinoDto? dto1, tm_shkensinjigyoDto? dto2)
        {
            var vm = new KensinDetailJigyoVM();

            vm.kinoid = dto1?.kinoid;                   //機能ID
            vm.hyojinm = CStr(dto1?.hyojinm);           //機能表示名称
            if (dto2 != null)
            {
                //精密検査実施区分
                vm.seikenjissikbn = DaNameService.GetCdNm(db, EnumNmKbn.精密検査実施区分, Enum名称区分.名称, EnumToStr(dto2.seikenjissikbn));
                //クーポン券表示区分
                vm.cuponhyojikbn = DaNameService.GetCdNm(db, EnumNmKbn.クーポン券表示区分, Enum名称区分.名称, EnumToStr(dto2.cuponhyojikbn));
                //減免区分
                vm.genmenkbn = DaNameService.GetCdNm(db, EnumNmKbn.減免区分種別, Enum名称区分.名称, EnumToStr(dto2.genmenkbn));
                //生涯１回フラグ
                vm.syogaiikaiflg = DaNameService.GetCdNm(db, EnumNmKbn.生涯一回フラグ, Enum名称区分.名称,
                                                dto2.syogaiikaiflg == false ? EnumToStr(Enum生涯１回フラグ.生涯複数回) : EnumToStr(Enum生涯１回フラグ.生涯1回));
            }

            return vm;
        }

        /// <summary>
        /// 検診事業情報取得(検査方法)
        /// </summary>
        public static KensinDetailHohoVM GetHohoVM(DaDbContext db, string maincd, tm_shkensinjigyoDto? dto1, tm_afhanyo_mainDto? dto2, List<tm_afhanyoDto> dtl)
        {
            var vm = new KensinDetailHohoVM();

            vm.kensahoho_setflg = CBool(dto1?.kensahoho_setflg);                                            //検査方法設定フラグ
            vm.kensahoho_maincdnm = DaNameService.GetName(db, EnumNmKbn.汎用マスタメインコード, maincd);    //検査方法メインコード名
            vm.kensahoho_subcdnm = CStr(dto2?.hanyosubcdnm);                                                //検査方法サブコード名
            vm.kekkalist = GetHohoVMList(dtl);                                                              //検査方法一覧

            return vm;
        }

        /// <summary>
        /// 検診事業情報取得(予約分類)
        /// </summary>
        public static KensinDetailYoyakuVM GetYoyakuVM(DaDbContext db, string maincd, tm_afhanyo_mainDto? dto, List<tm_afhanyoDto> dtl)
        {
            var vm = new KensinDetailYoyakuVM();

            vm.yoyakubunrui_maincdnm = DaNameService.GetName(db, EnumNmKbn.汎用マスタメインコード, maincd);     //予約分類メインコード名
            vm.yoyakubunrui_subcdnm = CStr(dto?.hanyosubcdnm);                                                  //予約分類サブコード名
            vm.kekkalist = GetYoyakuVMList(dtl);                                                                //予約分類一覧

            return vm;
        }

        /// <summary>
        /// 検診事業情報取得(グループ2)
        /// </summary>
        public static KensinDetailFreeVM GetFreeVM(DaDbContext db, string maincd, tm_afhanyo_mainDto? dto, List<tm_afhanyoDto> dtl)
        {
            var vm = new KensinDetailFreeVM();

            vm.groupid2_maincdnm = DaNameService.GetName(db, EnumNmKbn.汎用マスタメインコード, maincd);     //グループ2メインコード
            vm.groupid2_subcdnm = CStr(dto?.hanyosubcdnm);                                                  //グループ2サブコード名
            vm.kekkalist = GetFreeVMList(dtl);                                                              //検査分類名一覧

            return vm;
        }

        /// <summary>
        /// 検診事業情報取得(エラーチェック)
        /// </summary>
        public static KensinDetailErrorchkVM GetErrorchkVM(DaDbContext db, tm_shkensinjigyoDto? dto)
        {
            var vm = new KensinDetailErrorchkVM();
            vm.yoyakuchk = DaNameService.GetCdNm(db, EnumNmKbn.メッセージ切替区分, Enum名称区分.名称, EnumToStr(dto?.yoyakuchk));    //予約画面チェック区分
            vm.kensinchk = DaNameService.GetCdNm(db, EnumNmKbn.メッセージ切替区分, Enum名称区分.名称, EnumToStr(dto?.kensinchk));    //健（検）診画面チェック区分

            return vm;
        }

        /// <summary>
        /// 検診項目情報取得
        /// </summary>
        public static KensinItemDetailInitVM GetVM(DaDbContext db, tm_shfreeitemDto? dto, bool copyflg, string maincd, string jigyocd)
        {
            var vm = new KensinItemDetailInitVM();
            vm.rirekiflg = true;                                                        //履歴管理フラグ
            if (dto != null)
            {
                vm = (KensinItemDetailInitVM)GetVM(db, vm, copyflg, dto.itemcd, dto.itemnm, dto.inputtype, dto.codejoken1, dto.codejoken2, dto.codejoken3,
                                            dto.keta, dto.hissuflg, dto.hanif, dto.hanit, dto.inputflg, dto.msgkbn, dto.tani, dto.syokiti, dto.biko);

                //グループID(コード：名称)
                vm.group = DaNameService.GetCdNm(db, EnumNmKbn.成人保健フリー項目グループ１, Enum名称区分.名称, EnumToStr(dto.groupid));
                //グループID2(コード：名称)
                var subcd = CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.グループ2, jigyocd).ToString();
                vm.group2 = DaSelectorService.GetCdNm(db, CStr(dto.groupid2), Enum名称区分.名称, Enumマスタ区分.汎用マスタ, maincd, subcd);

                vm.rirekiflg = dto.rirekiflg;                                           //履歴管理フラグ
                vm.hyojinendof = dto.hyojinendof;                                       //表示年度（開始）
                vm.hyojinendot = dto.hyojinendot;                                       //表示年度（終了）

                //計算区分(コード：名称)
                vm.keisankbn = DaNameService.GetCdNm(db, EnumNmKbn.計算区分, Enum名称区分.名称, EnumToStr(dto.keisankbn));
                vm.keisansusiki = CStr(dto.keisansusiki);                               //計算数式
                if (dto.keisankbn == Enum計算区分.DB関数 || dto.keisankbn == Enum計算区分.内部関数)
                {
                    if (dto.keisankbn == Enum計算区分.DB関数)
                    {
                        //計算関数ID(コード：名称)
                        vm.keisankansu = DaHanyoService.GetCdNm(db, EnumHanyoKbn.計算関数_DB ,Enum名称区分.名称, dto.keisankansuid!);
                        //計算パラメータ数(画面制御用)
                        var dtoHanyo = DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.計算関数_DB, dto.keisankansuid!);
                        vm.keisanparamnum = CInt(dtoHanyo.hanyokbn1);
                    }
                    else
                    {
                        //計算関数ID(コード：名称)
                        vm.keisankansu = DaNameService.GetCdNm(db, EnumNmKbn.計算関数_内部, Enum名称区分.名称, dto.keisankansuid!);
                        //計算パラメータ数(画面制御用)
                        vm.keisanparamnum = CInt(DaNameService.GetKbn1(db, EnumNmKbn.計算関数_内部, dto.keisankansuid!));
                    }
                    vm.keisanparams = CommaStrToList(dto.keisanparam);                  //計算パラメータ
                }
                vm.komokutokuteikbn = DaNameService.GetCdNm(db, EnumNmKbn.フリー項目特定区分,
                                        Enum名称区分.名称, CStr(dto.komokutokuteikbn));  //項目特定区分
                vm.riyokensahohocds = CommaStrToList(dto.riyokensahohocd);              //利用検査方法コード
            }

            return vm;
        }
        /// <summary>
        /// 入力タイプ備考取得
        /// </summary>
        public static string GetBiko(DaDbContext db, Enum入力タイプ inputtype)
        {
            var biko = string.Empty;
            var kbn = GetCtrlkbn(db, inputtype);
            if (kbn == Enumコントローラー分類.選択)
            {
                biko = DaNameService.GetBiko(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype));
            }
            return biko;
        }
        /// <summary>
        /// コントローラー分類取得
        /// </summary>
        public static Enumコントローラー分類 GetCtrlkbn(DaDbContext db, Enum入力タイプ inputtype)
        {
            return (Enumコントローラー分類)CInt(DaNameService.GetKbn3(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
        }

        /// <summary>
        /// 入力タイプ分類取得
        /// </summary>
        public static Enum入力タイプ分類 GetInputtypekbn(DaDbContext db, Enum入力タイプ inputtype)
        {
            var inputtypekbn = DaNameService.GetKbn2(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype));
            return (Enum入力タイプ分類)CInt(inputtypekbn);
        }
        /// <summary>
        /// 指導フリー項目一覧取得
        /// </summary>
        public static List<SidoItemListRowVM> GetVMList(DaDbContext db, List<tm_kksidofreeitemDto> dtl)
        {
            var list = new List<SidoItemListRowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto));
            }

            return list;
        }
        /// <summary>
        /// ヘッダー情報取得
        /// </summary>
        public static SidoCommonHeaderVM GetHeaderVM(DaDbContext db, SidoCommonRequest req)
        {
            var vm = new SidoCommonHeaderVM();
            vm.sidokbnnm = DaNameService.GetName(db, EnumNmKbn.指導区分, EnumToStr(req.sidokbn));                       //指導区分名称
            vm.gyomukbnnm = DaNameService.GetName(db, EnumNmKbn.拡_予約_保健指導業務区分, req.gyomukbn);              //業務区分名称
            vm.mosikomikekkakbnnm = DaNameService.GetName(db, EnumNmKbn.申込結果区分, EnumToStr(req.mosikomikekkakbn)); //申込結果区分名称
            if (req.sidokbn == Enum指導区分.集団指導)
            {
                vm.itemyotokbnnm = DaNameService.GetName(db, EnumNmKbn.フリー項目用途区分, EnumToStr(req.itemyotokbn)); //項目用途区分名称
            }

            return vm;
        }
        /// <summary>
        /// 指導項目情報取得
        /// </summary>
        public static SidoItemDetailVM GetVM(DaDbContext db, tm_kksidofreeitemDto? dto, bool copyflg)
        {
            var vm = new SidoItemDetailVM();
            if (dto != null)
            {
                vm = (SidoItemDetailVM)GetVM(db, vm, copyflg, dto.itemcd, dto.itemnm, dto.inputtype, dto.codejoken1, dto.codejoken2, dto.codejoken3,
                                            dto.keta, dto.hissuflg, dto.hanif, dto.hanit, dto.inputflg, dto.msgkbn, dto.tani, dto.syokiti, dto.biko);

                //グループID(コード：名称)
                vm.group = DaHanyoService.GetCdNm(db, EnumHanyoKbn.保健指導_集団指導項目グループ, Enum名称区分.名称, CStr(dto.groupid));
                //グループID2(コード：名称)
                vm.group2 = DaHanyoService.GetCdNm(db, EnumHanyoKbn.保健指導_集団指導項目グループ, Enum名称区分.名称, CStr(dto.groupid2));
                vm.syukeikbns = CommaStrToList(dto.syukeikbn);  //利用地域保健集計区分
                vm.komokutokuteikbn = DaNameService.GetCdNm(db, EnumNmKbn.フリー項目特定区分,
                                        Enum名称区分.名称, CStr(dto.komokutokuteikbn));  //項目特定区分
            }

            return vm;
        }
        /// <summary>
        /// 検診予約事業一覧
        /// </summary>
        public static List<KensinYoyakuListRowVM> GetVMList(List<tm_shyoyakujigyoDto> dtl1, List<tm_shyoyakujigyo_subDto> dtl2, List<tm_afhanyoDto> dtl3,
                                                             string maincd, List<string> cdList)
        {
            var list = new List<KensinYoyakuListRowVM>();
            foreach (var dto in dtl1)
            {
                list.Add(GetVM(dto, dtl2, dtl3, maincd, cdList));
            }

            return list;
        }
        /// <summary>
        /// 検診予約事業のメイン情報
        /// </summary>
        public static KensinYoyakuDetailMainVM GetVM(Enum編集区分 kbn, tm_shyoyakujigyoDto dto, List<tm_afhanyoDto> dtl)
        {
            var vm = new KensinYoyakuDetailMainVM();
            if (kbn == Enum編集区分.変更)
            {
                var jigyocd = dto.jigyocd;
                //予約日程事業名(変更の場合のみ)
                vm.jigyonm = DaHanyoService.GetName(dtl, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, jigyocd);
                vm.upddttm = dto.upddttm;//更新日時(排他用)
            }
            //料金パターン(コード：名称)
            vm.ryokinpatterncdnm = DaHanyoService.GetCdNm(dtl, EnumHanyoKbn.料金パターン, Enum名称区分.名称, dto.ryokinpattern);

            return vm;
        }
        /// <summary>
        /// 検診予約事業の検診事業一覧
        /// </summary>
        public static List<KensinYoyakuDetailRowVM> GetVMList(List<tm_shnendoDto> dtl1, List<tm_shyoyakujigyo_subDto> dtl2, List<tm_afhanyoDto> dtl3,
                                                             string maincd, List<string> cdList, List<tt_shkensinkibosyasyosaiDto> dtl5)
        {
            var list = new List<KensinYoyakuDetailRowVM>();
            foreach (var dto in dtl1)
            {
                list.Add(GetVM(dto, dtl2, dtl3, maincd, cdList, dtl5));
            }

            return list;
        }
        /// <summary>
        /// その他予約事業一覧
        /// </summary>
        public static List<YoyakuSidoJigyoRowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            var list = new List<YoyakuSidoJigyoRowVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row));
            }

            return list;
        }
        /// <summary>
        /// 業務区分ドロップダウンリスト
        /// </summary>
        public static List<DaSelectorKeyModel> GetSelectorList(DaDbContext db)
        {
            //業務区分一覧
            var list = DaNameService.GetSelectorList(db, EnumNmKbn.拡_予約_保健指導業務区分, Enum名称区分.名称);
            var list2 = new List<DaSelectorKeyModel>();
            foreach (var row in list)
            {
                list2.Add(new DaSelectorKeyModel(row.value, row.label, GetKey(row.value)));
            }

            return list2;
        }
        /// <summary>
        /// キー取得(指導利用可能フラグ)
        /// </summary>
        private static string GetKey(string cd)
        {
            var kbn = CmLogicUtil.GetKakuYoyakuSidoGyomukbn(cd);
            switch (kbn)
            {
                case Enum拡予約指導業務区分.成人保健:
                case Enum拡予約指導業務区分.母子保健:
                    return BoolToStr(true);
                case Enum拡予約指導業務区分.予防接種:
                    return BoolToStr(false);
                default:
                    throw new Exception("業務区分 error");
            }
        }
        /// <summary>
        /// その他予約事業(1件)
        /// </summary>
        private static YoyakuSidoJigyoRowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new YoyakuSidoJigyoRowVM();
            vm.jigyocd = row.Wrap($"{nameof(tm_kksonotasidojigyoDto.jigyocd)}kk");          //その他日程事業・保健指導事業コード
            vm.jigyonm = row.Wrap(nameof(tm_kksonotasidojigyoDto.jigyonm));                 //その他日程事業・保健指導事業名
            vm.stopflg = row.CBool(nameof(tm_kksonotasidojigyoDto.stopflg));                //使用停止フラグ
            //業務区分
            var gyomukbn = row.Wrap(nameof(tm_kksonotasidojigyoDto.gyomukbn));
            //業務区分(コード：名称)
            vm.gyomukbncdnm = DaNameService.GetCdNm(db, EnumNmKbn.拡_予約_保健指導業務区分, Enum名称区分.名称, gyomukbn);
            vm.yoyakuriyoflg = row.CBool(nameof(tm_kksonotasidojigyoDto.yoyakuriyoflg));    //予約利用フラグ
            vm.homonriyoflg = row.CBool(nameof(tm_kksonotasidojigyoDto.homonriyoflg));      //訪問利用フラグ
            vm.sodanriyoflg = row.CBool(nameof(tm_kksonotasidojigyoDto.sodanriyoflg));      //相談利用フラグ
            vm.syudanriyoflg = row.CBool(nameof(tm_kksonotasidojigyoDto.syudanriyoflg));    //集団利用フラグ
            vm.upddttm = row.CDate(nameof(tm_kksonotasidojigyoDto.upddttm));                //更新日時
            vm.editflg = row.CBool(nameof(YoyakuSidoJigyoRowVM.editflg));                   //編集フラグ(業務区分)

            return vm;
        }
        /// <summary>
        /// 検診予約の検診事業(1件)
        /// </summary>
        private static KensinYoyakuDetailRowVM GetVM(tm_shnendoDto dto1, List<tm_shyoyakujigyo_subDto> dtl2, List<tm_afhanyoDto> dtl3,
                                                    string maincd, List<string> cdList, List<tt_shkensinkibosyasyosaiDto> dtl5)
        {
            var vm = new KensinYoyakuDetailRowVM();
            //検診事業コード
            vm.jigyocd = dto1.jigyocd;
            //検診事業名
            vm.jigyonm = DaHanyoService.GetName(dtl3, EnumHanyoKbn.検診種別, Enum名称区分.名称, vm.jigyocd);
            if (cdList.Contains(vm.jigyocd))
            {
                //検査方法コード
                vm.kensahohocd = dto1.kensahohocd;
                //検査方法名
                vm.kensahohonm = DaHanyoService.GetName(dtl3, maincd, CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, vm.jigyocd),
                                                        Enum名称区分.名称, vm.kensahohocd);
            }
            //実施とオプション情報
            var dto2 = dtl2.Find(e => e.kensin_jigyocd == dto1.jigyocd && e.kensahohocd == dto1.kensahohocd);
            if (dto2 != null)
            {
                vm.jissiflg = true;             //実施フラグ
                vm.optionflg = dto2.optionflg;  //オプションフラグ

                //当年度の予約データが登録されている場合、チェックボックス外す不可
                var existsflg = dtl5.Exists(e => e.jigyocd == dto1.jigyocd && e.kensahohocd == dto1.kensahohocd);
                vm.jissieditflg = existsflg;    //実施編集フラグ
            }

            return vm;
        }
        /// <summary>
        /// 検診予約事業(1件)
        /// </summary>
        private static KensinYoyakuListRowVM GetVM(tm_shyoyakujigyoDto dto, List<tm_shyoyakujigyo_subDto> dtl2, List<tm_afhanyoDto> dtl3,
                                                    string maincd, List<string> cdList)
        {
            var vm = new KensinYoyakuListRowVM();
            //事業コード
            vm.jigyocd = dto.jigyocd;
            //事業名
            vm.jigyonm = DaHanyoService.GetName(dtl3, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, vm.jigyocd);
            //料金パターン名
            vm.ryokinpatternnm = DaHanyoService.GetName(dtl3, EnumHanyoKbn.料金パターン, Enum名称区分.名称, dto.ryokinpattern);
            //該当検診予約事業の検査方法一覧
            var dtl5 = dtl2.Where(e => e.jigyocd == vm.jigyocd).ToList();
            //検診事業一覧
            var dtl6 = DaHanyoService.GetHanyoDtl(dtl3, EnumHanyoKbn.検診種別);
            //検診事業一覧(検診予約が実施)
            var cdList2 = dtl5.Select(e => e.kensin_jigyocd).Distinct().ToList();

            //事業内容
            vm.jigyonaiyo = GetJigyonaiyo(dtl5, dtl6, dtl3, cdList, cdList2, maincd);

            return vm;
        }
        /// <summary>
        /// 検診予約事業内容
        /// </summary>
        private static string GetJigyonaiyo(List<tm_shyoyakujigyo_subDto> dtl1, List<tm_afhanyoDto> dtl2, List<tm_afhanyoDto> dtl3, List<string> cdList, List<string> cdList2, string maincd)
        {
            //検診事業一覧
            var list = new List<string>();
            foreach (var cd in cdList2)
            {
                var jigyonm = dtl2.Find(e => e.hanyocd == cd)!.shortnm!;
                //検査方法がある場合
                if (cdList.Contains(cd))
                {
                    var list2 = new List<string>();
                    var cdList3 = dtl1.Where(e => e.kensin_jigyocd == cd).Select(e => e.kensahohocd).ToList();
                    foreach (var kensahohocd in cdList3)
                    {
                        list2.Add(dtl3.Find(e => e.hanyomaincd == maincd &&
                                            e.hanyosubcd == CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, cd) &&
                                            e.hanyocd == kensahohocd)!.shortnm!);
                    }
                    list.Add($"{jigyonm}{C_LEFT_BRACKET_FULL}{string.Join(C_SLASH_FULL, list2)}{C_RIGHT_BRACKET_FULL}");
                }
                else
                {
                    list.Add(jigyonm);
                }
            }

            return string.Join(C_COMMA2, list);
        }
        /// <summary>
        /// 項目情報取得
        /// </summary>
        private static FreeItemDetailBaseVM GetVM(DaDbContext db, FreeItemDetailBaseVM vm, bool copyflg,
                                                string itemcd, string itemnm, Enum入力タイプ inputtype,
                                                string? codejoken1, string? codejoken2, string? codejoken3,
                                                string? keta, bool hissuflg, string? hanif, string? hanit,
                                                bool inputflg, EnumMsgCtrlKbn msgkbn,
                                                string? tani, string? syokiti, string? biko)
        {
            if (!copyflg)
            {
                vm.itemcd = itemcd;                     //項目コード
                vm.itemnm = itemnm;                     //項目名
            }
            //入力タイプ(コード：名称)
            vm.inputtype = DaNameService.GetCdNm(db, EnumNmKbn.フリー項目データタイプ, Enum名称区分.名称, EnumToStr(inputtype));
            // 名称取得(条件コード)リスト
            var codejokens = CmLogicUtil.GetFreeItemCdNm(db, Enum名称区分.名称, inputtype, codejoken1, codejoken2, codejoken3);
            vm.codejoken1 = codejokens[0];              //コード条件1(コード：名称)
            vm.codejoken2 = codejokens[1];              //コード条件2(コード：名称)
            vm.codejoken3 = codejokens[2];              //コード条件3(コード：名称)
            vm.keta = keta;                             //入力桁
            vm.hissuflg = hissuflg;                     //必須フラグ
            vm.hanif = CStr(hanif);                     //入力範囲（開始）
            vm.hanit = CStr(hanit);                     //入力範囲（終了）
            vm.inputflg = inputflg;                     //入力フラグ
                                                        //メッセージ区分(コード：名称)
            vm.msgkbn = DaNameService.GetCdNm(db, EnumNmKbn.メッセージ切替区分, Enum名称区分.名称, EnumToStr(msgkbn));
            vm.tani = CStr(tani);                       //単位
            vm.syokiti = CStr(syokiti);                 //初期値
            vm.biko = CStr(biko);                       //備考

            return vm;
        }
        /// <summary>
        /// 種類データ取得
        /// </summary>
        private static DaSelectorKeyModel2 GetVM(tm_afmeisyoDto dto, Enum名称区分 kbn)
        {
            var vm = new DaSelectorKeyModel2();
            vm.value = dto.nmcd;                //コード
            vm.key = dto.hanyokbn1!;            //キー項目(連動フィルター用)
            vm.comment = CStr(dto.hanyokbn2);   //説明
                                                //名称
            switch (kbn)
            {
                case Enum名称区分.名称:
                    vm.label = dto.nm;
                    break;
                case Enum名称区分.カナ:
                    vm.label = CStr(dto.kananm);
                    break;
                case Enum名称区分.略称:
                    vm.label = CStr(dto.shortnm);
                    break;
                default:
                    throw new Exception("Enum名称区分 error");
            }

            return vm;
        }

        /// <summary>
        /// 検診事業(1行)
        /// </summary>
        private static KensinListRowVM GetVM(DaDbContext db, tm_afhanyoDto dto, tm_shkensinjigyoDto dto2)
        {
            var vm = new KensinListRowVM();
            vm.jigyocd = dto.hanyocd;                                                                                   //事業コード
            vm.jigyonm = dto.nm;                                                                                        //事業名
            vm.kinoid = CmLogicUtil.GetKensinKinoid(vm.jigyocd);                                                        //機能ID
            vm.jigyokbn = dto2.kihonkakutyokbn;                                                                         //基本／拡事業区分
            vm.jigyokbnnm = DaNameService.GetName(db, EnumNmKbn.事業区分, EnumToStr(dto2.kihonkakutyokbn));             //基本／拡事業区分名
            vm.seikenjissikbn = dto2.seikenjissikbn;                                                                    //精密検査実施区分
            vm.seikenjissikbnnm = DaNameService.GetName(db, EnumNmKbn.精密検査実施区分, EnumToStr(vm.seikenjissikbn));  //精密検査実施区分名

            return vm;
        }

        /// <summary>
        /// 検診項目(1行)
        /// </summary>
        private static KensinItemListRowVM GetVM(DaDbContext db, tm_shfreeitemDto dto, List<tm_afhanyoDto> dtl)
        {
            var vm = new KensinItemListRowVM();
            vm = (KensinItemListRowVM)GetVM(db, vm, dto.itemcd, dto.itemnm, dto.itemkbn, dto.inputtype);
            var cds = dto.riyokensahohocd;                                                                              //利用検査方法コード
                                                                                                                        //検査方法コードリスト
            List<string> cdList = new List<string>();
            //検査方法名称リスト
            List<string> cdNmList = new List<string>();
            //利用検査方法コードがある場合
            if (!string.IsNullOrEmpty(cds))
            {
                cdList = cds.Split(C_COMMA).ToList();
            }
            if (cdList.Count > 0)
            {
                foreach (var cd in cdList)
                {
                    var nm = dtl.Find(e => e.hanyocd == cd)!.shortnm!;
                    cdNmList.Add(nm);
                }
            }
            vm.riyokensahohonms = string.Join(C_COMMA, cdNmList);                                                       //利用検査方法名(複数)
            var groupid = dto.groupid;                                                                                  //グループID
            vm.groupid = EnumToStr(groupid);                                                                            //グループID
            vm.groupnm = DaNameService.GetShortName(db, EnumNmKbn.成人保健フリー項目グループ１, EnumToStr(groupid));    //グループID名
            vm.haitiflg = dto.haitiflg;                                                                                 //画面配置フラグ

            return vm;
        }

        /// <summary>
        /// 検査方法一覧取得
        /// </summary>
        private static List<KensinDetailHohoRowVM> GetHohoVMList(List<tm_afhanyoDto> dtl)
        {
            var list = new List<KensinDetailHohoRowVM>();
            foreach (var dto in dtl)
            {
                list.Add(new KensinDetailHohoRowVM()
                {
                    kensahohocd = dto.hanyocd,              //検査方法コード
                    kensahohonm = dto.nm,                   //検査方法名
                    kensahohoshortnm = CStr(dto.shortnm)    //検査方法略称
                });
            }

            return list;
        }

        /// <summary>
        /// 予約分類一覧取得
        /// </summary>
        private static List<KensinDetailYoyakuRowVM> GetYoyakuVMList(List<tm_afhanyoDto> dtl)
        {
            var list = new List<KensinDetailYoyakuRowVM>();
            foreach (var dto in dtl)
            {
                list.Add(new KensinDetailYoyakuRowVM()
                {
                    yoyakubunrui = dto.hanyocd,                         //予約分類コード
                    yoyakubunruinm = dto.nm,                            //予約分類名
                    yoyakubunruishortnm = CStr(dto.shortnm),            //予約分類表示名
                    yoyakubunruilist = CommaStrToList(dto.hanyokbn1!)   //検査方法コード一覧
                });
            }

            return list;
        }

        /// <summary>
        /// 検査分類一覧取得
        /// </summary>
        private static List<DaSelectorModel> GetFreeVMList(List<tm_afhanyoDto> dtl)
        {
            var list = new List<DaSelectorModel>();
            foreach (var dto in dtl)
            {
                list.Add(new DaSelectorModel(dto.hanyocd, dto.nm));
            }

            return list;
        }

        /// <summary>
        /// 指導項目(1行)
        /// </summary>
        private static SidoItemListRowVM GetVM(DaDbContext db, tm_kksidofreeitemDto dto)
        {
            var vm = new SidoItemListRowVM();
            vm = (SidoItemListRowVM)GetVM(db, vm, dto.itemcd, dto.itemnm, dto.itemkbn, dto.inputtype);
            //グループID名
            vm.groupnm = DaHanyoService.GetName(db, EnumHanyoKbn.保健指導_集団指導項目グループ, Enum名称区分.略称, CStr(dto.groupid)); ;
            vm.itemyotokbn = dto.itemyotokbn;   //項目用途区分

            return vm;
        }
        /// <summary>
        /// フリー項目(1行)
        /// </summary>
        private static ItemListRowBaseVM GetVM(DaDbContext db, ItemListRowBaseVM vm, string itemcd, string itemnm, Enumフリー項目区分区分 itemkbn, Enum入力タイプ inputtype)
        {
            vm.itemcd = itemcd;                                                                                         //項目コード
            vm.itemnm = itemnm;                                                                                         //項目名
            vm.kakutyokbn = itemkbn == Enumフリー項目区分区分.PKG標準項目拡領域不使用 ? "―" : "○";                  //拡領域使用
            vm.pkgdokujikbn = vm.kakutyokbn == "○" ? Enum事業区分.市区町村拡事業 : Enum事業区分.基本事業;            //PKG標準・独自区分
            vm.pkgdokujikbnnm = DaNameService.GetShortName(db, EnumNmKbn.項目区分, EnumToStr(itemkbn));                 //PKG標準・独自区分名称
            vm.inputtypekbn = GetInputtypekbn(db, inputtype);                                                           //入力タイプ分類
            vm.inputtypekbnnm = DaNameService.GetName(db, EnumNmKbn.独自施策項目パターン, EnumToStr(vm.inputtypekbn));  //項目タイプ
            vm.itemkbn = itemkbn;                                                                                       //項目区分

            return vm;
        }
    }
}