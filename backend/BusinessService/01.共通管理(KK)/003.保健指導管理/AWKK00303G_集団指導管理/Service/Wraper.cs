// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 集団指導管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWKK00303G
{
    public class Wraper : CmWraperBase
    {
        //定数定義
        private const string FUSYO = "不詳";          //生年月日が不詳の場合利用

        //================================= 1.初期化処理(詳細画面) =================================
        /// <summary>
        /// 初期化処理(個人詳細画面)
        /// </summary>
        public static InitDetailVM GetVM(DaDbContext db, List<DaSelectorModel> jigyolist, List<DaSelectorModel> kaijodtl, List<StaffListVM> staffdtl)
        {
            var vm = new InitDetailVM();

            //ドロップダウンリスト初期設定
            vm.gyomulist = MList(db, EnumNmKbn.拡張_予約_保健指導業務区分);                  //業務リスト
            vm.jigyolist = jigyolist;                                                        //事業リスト
            vm.kaijolist = kaijodtl;                                                         //実施場所リスト
            vm.stafflist = staffdtl;                                                　       //予定者／実施者リスト
            vm.courselist = MList(db, EnumNmKbn.コース区分);                                 //コース区分
            vm.syukeikbnlist = MList(db, EnumNmKbn.地域保健集計区分);                        //地域保健集計区分
            vm.group1list = Service.GetSyudansidoGroupList(db, Enumフリー項目グループNo.グループ, Enum項目用途区分.事業用);            //グループ1
            vm.group2list = Service.GetSyudansidoGroupList(db, Enumフリー項目グループNo.グループ2, Enum項目用途区分.事業用);           //グループ2
            vm.sankasyagroup1list = Service.GetSyudansidoGroupList(db, Enumフリー項目グループNo.グループ, Enum項目用途区分.参加者用);  //参加者グループ1
            vm.sankasyagroup2list = Service.GetSyudansidoGroupList(db, Enumフリー項目グループNo.グループ2, Enum項目用途区分.参加者用); //参加者グループ2

            vm.syukketuswitch = MList(db, EnumNmKbn.出欠区分);                               //出欠区分

            return vm;
        }

        /// <summary>
        /// 事業リスト（一覧）
        /// </summary>
        public static List<DaSelectorModel> GetJigyoVMList(DaDbContext db, DataTable rows)
        {
            List<DaSelectorModel> list = new List<DaSelectorModel>();
            foreach (DataRow row in rows.Rows)
            {
                list.Add(GetJigyoVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 事業リスト（一行）
        public static DaSelectorModel GetJigyoVM(DaDbContext db, DataRow row)
        {
            var vm = new DaSelectorModel();

            vm.value = row.Wrap("jigyocd");         //コード
            vm.label = row.Wrap("jigyonm");         //名称

            return vm;
        }

        //================================= 2.集団指導一覧画面検索処理(一覧画面) =================================
        /// <summary>
        /// 集団指導一覧
        /// </summary>
        public static List<SyudanListVM> GetSyudanVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GeSyudanVM(db, r)).ToList();
        }

        /// <summary>
        /// 集団指導（一行）
        public static SyudanListVM GeSyudanVM(DaDbContext db, DataRow row)
        {
            var vm = new SyudanListVM();

            vm.edano = CInt(row.Wrap(nameof(vm.edano)));                                //枝番（キー項目、非表示）
            vm.gyomukbn = CStr(row.Wrap(nameof(tt_kksyudansido_mosikomiDto.gyomukbn))); //業務区分コード
            vm.gyomu = MNm(db, vm.gyomukbn, EnumNmKbn.拡張_予約_保健指導業務区分);      //業務名称
            vm.jigyocd = row.Wrap(nameof(tt_kksyudansido_mosikomiDto.jigyocd));         //事業コード
            vm.jigyo = AWKK00301G.Service.GetJigyoNm(db, vm.jigyocd);                   //事業名称
            var yoteiymd = CStr(row.Wrap(nameof(vm.yoteiymd)));                         //実施予定日
            vm.yoteiymd = FormatWaKjYMD(yoteiymd);                                      //実施予定日（和暦表示）
            var yoteitm = CStr(row.Wrap(nameof(tt_kksyudansido_mosikomiDto.yoteitm)));  //予定開始時間（4桁）
            vm.yotetmf = GetTimeDisp(yoteitm);                                          //予定開始時間（表示用HH:MM）
            vm.yotebasyo = CStr(row.Wrap(nameof(vm.yotebasyo)));                        //実施場所（申込）（会場名称）
            vm.yoteisya = CStr(row.Wrap(nameof(vm.yoteisya)));                          //予定者
            vm.nitteno = CNInt(row.Wrap(nameof(vm.nitteno)));                           //日程番号
            vm.nittesyosaino = CNInt(row.Wrap(nameof(vm.nittesyosaino)));               //日程詳細番号
            vm.coursenm = CStr(row.Wrap(nameof(vm.coursenm)));                          //コース名
            var jissiymd = CStr(row.Wrap(nameof(vm.jissiymd)));                         //実施日
            vm.jissiymd = FormatWaKjYMD(jissiymd);                                      //実施日（和暦表示）
            var tmf = CStr(row.Wrap(nameof(tt_kksyudansido_kekkaDto.tmf)));             //開始時間
            var tmt = CStr(row.Wrap(nameof(tt_kksyudansido_kekkaDto.tmt)));             //終了時間
            vm.jissitm = GetJissitm(tmf, tmt);                                          //実施時間
            vm.jissibasyo = CStr(row.Wrap(nameof(vm.jissibasyo)));                      //実施場所（結果）（会場名称）
            vm.jissisya = CStr(row.Wrap(nameof(vm.jissisya)));                          //実施者

            return vm;
        }

        //=================================  3.個別入力画面検索処理(一覧画面から) =================================
        //=================================  4.指導情報検索処理(申込／結果タブ切り替え) ===========================
        /// <summary>
        /// 集団指導申込情報（表示用）
        /// </summary>
        public static JigyoFixInfoVM GetMosikomiBaseVM(DaDbContext db, tt_kksyudansido_mosikomiDto dto, string kaijonm, List<StaffListVM> stafflist, string regsisyocd, EnumActionType? kbn)
        {
            var vm = new JigyoFixInfoVM();

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合は、ログイン時選択された支所を表示
                vm.inputflg = false;
                vm.regsisyocd = regsisyocd;                                                  //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);              //登録支所名称
            }
            else if (kbn == EnumActionType.Update)
            {
                vm.inputflg = true;
                var jigyocd = CStr(dto.jigyocd);                                             //事業コード
                vm.jigyo = AWKK00301G.Service.GetJigyoCdNm(db, jigyocd);                     //事業（コード : 名称）
                vm.yoteiymd = CStr(dto.yoteiymd);                                            //実施予定日
                vm.yoteitm = CStr(dto.yoteitm);                                              //予定開始時間
                vm.kaijo = kaijonm;                                                          //実施場所
                vm.stafflist = stafflist;                                                    //事業従事者リスト（予定者）
                vm.regsisyocd = CStr(dto.regsisyo);                                          //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);              //登録支所名称
            }
            return vm;
        }

        /// <summary>
        /// 集団指導結果情報（表示用）
        /// </summary>
        public static JigyoFixInfoVM GetKekkaBaseVM(DaDbContext db, tt_kksyudansido_kekkaDto dto, string kaijonm, List<StaffListVM> stafflist, string regsisyocd, EnumActionType? kbn)
        {
            var vm = new JigyoFixInfoVM();

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合は、ログイン時選択された支所を表示
                vm.inputflg = false;
                vm.regsisyocd = regsisyocd;                                                  //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);              //登録支所名称
            }
            else if (kbn == EnumActionType.Update)
            {
                vm.inputflg = true;
                var jigyocd = CStr(dto.jigyocd);                                             //事業コード
                vm.jigyo = AWKK00301G.Service.GetJigyoCdNm(db, jigyocd);                     //事業（コード : 名称）
                var syukeikbn = CStr(dto.syukeikbn);                                         //地域保健集計区分（コード）
                vm.syukeikbn = MCdNm(db, syukeikbn, EnumNmKbn.地域保健集計区分);             //地域保健集計区分（コード : 名称）
                vm.jissiymd = CStr(dto.jissiymd);                                            //実施日
                vm.tmf = CStr(dto.tmf);                                                      //開始時間
                vm.tmt = CStr(dto.tmt);                                                      //終了時間
                vm.kaijo = kaijonm;                                                          //実施場所
                vm.stafflist = stafflist;                                                    //事業従事者リスト（予定者）
                vm.regsisyocd = CStr(dto.regsisyo);                                          //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);              //登録支所名称
            }
            return vm;
        }

        /// <summary>
        /// フリー項目一覧取得
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_kksidofreeitemDto> mstDtl, List<tt_kksyudansidofreeDto> dataDtl, string kinoid, int patternno)
        {
            //集団指導フリー項目データタイプ
            var datatypes = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            var list = new List<FreeItemDispInfoVM>();
            foreach (var item in mstDtl)
            {
                var vm = new FreeItemDispInfoVM();
                var dto = dataDtl.Find(x => x.itemcd == item.itemcd);
                if (dto == null)
                {
                    //新規の場合
                    vm = GetVM(db, item, null, null, null, datatypes, kinoid, patternno);
                }
                else
                {
                    //更新の場合
                    vm = GetVM(db, item, dto.fusyoflg, dto.numvalue, dto.strvalue, datatypes, kinoid, patternno);
                }
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// フリー項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_kksidofreeitemDto mstDto, bool? fusyoflg, double? numvalue, string? strvalue, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.指導, kinoid, patternno, numvalue, strvalue, fusyoflg,
                                            mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                            mstDto.msgkbn, mstDto.biko, mstDto.syokiti, mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                //グループID
            //分類（略称）
            vm.itemkbn = DaSelectorService.GetName(db, CStr(vm.groupid), Enum名称区分.略称, Enumマスタ区分.汎用マスタ, EnumToStr(EnumHanyoKbn.保健指導_集団指導項目グループ));
            vm.groupid2 = CNStr(mstDto.groupid2);       //グループID2
            vm.syukeikbn = CStr(mstDto.syukeikbn);      //利用地域保健集計区分



            return vm;
        }

        //===================== 5.参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ）） =====================
        /// <summary>
        /// 参加者情報一覧
        /// </summary>
        public static List<SankasyaInfoVM> GetSankasyaInfoVMList(DaDbContext db, DataTable rows, bool alertviewflg)
        {
            List<SankasyaInfoVM> list = new List<SankasyaInfoVM>();
            foreach (DataRow row in rows.Rows)
            {
                list.Add(GetSankasyaInfoVM(db, row, alertviewflg));
            }
            return list;
        }

        /// <summary>
        /// 詳細画面--ヘッダー部
        /// </summary>
        public static SankasyaInfoVM GetSankasyaInfoVM(DaDbContext db, DataRow row, bool alertviewflg)
        {
            var vm = new SankasyaInfoVM();

            vm.syukketukbn = row.Wrap(nameof(vm.syukketukbn));                          //出欠区分
            vm.atenano = row.Wrap(nameof(vm.atenano));                                  //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                      //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));                //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                                  //性別

            var juminkbn = row.Wrap(nameof(vm.juminkbn));                               //住民区分（コード）
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分（名称）
            vm.bymd = GetBymd(row);                                                     //生年月日
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));              //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        //================================= 8.参加者個人詳細画面検索処理（参加者一覧から） =================================
        //================================= 9.参加者詳細情報検索処理（申込／結果タブ切り替え） =============================
        /// <summary>
        /// 詳細画面--ヘッダー部
        /// </summary>
        public static HeaderInfoVM GetHeaderVM(DaDbContext db, tt_afatenaDto dto, string syukketukbn, bool alertviewflg)
        {
            var vm = new HeaderInfoVM();

            //ヘッダー部
            vm.atenano = CStr(dto.atenano);                                             //宛名番号
            vm.name = CStr(dto.simei_yusen);                                            //氏名（氏名_優先）
            vm.kname = CStr(dto.simei_kana_yusen);                                      //カナ氏名（氏名_フリガナ_優先）
            vm.sex = CmLogicUtil.GetSex(db, CStr(dto.sex));                             //性別（性別表記）

            var juminkbn = CStr(dto.juminkbn);                                          //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分名称
            vm.bymd = GetBymd(dto);                                                     //生年月日
            vm.kijunymd = FormatWaKjYMD(DateTime.Now);                                  //年齢計算基準日（システム日付の和暦表示）
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                               //生年月日_不詳フラグ
            var bymd = CStr(dto.bymd);                                                  //生年月日
            vm.age = GetNenrei(bymd_fusyoflg, bymd, DateTime.Now);                      //年齢
            var siensotikbn = CStr(dto.siensotikbn);                                    //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容
            vm.syukketukbn = MNm(db, syukketukbn, EnumNmKbn.出欠区分);                  //出欠区分名称

            return vm;
        }

        /// <summary>
        /// 参加者詳細画面申込タブ（表示用）
        /// </summary>
        public static SankasyaFixInfoVM GetMosikomiBaseVM(DaDbContext db, tt_kksyudansido_sankasyamosikomiDto dto, string regsisyocd, EnumActionType? kbn)
        {
            var vm = new SankasyaFixInfoVM();

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合は、ログイン時選択された支所を表示
                vm.regsisyocd = regsisyocd;                                             //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            else if (kbn == EnumActionType.Update)
            {
                vm.regsisyocd = CStr(dto.regsisyo);                                     //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            return vm;
        }

        /// <summary>
        /// 参加者詳細画面結果タブ（表示用）
        /// </summary>
        public static SankasyaFixInfoVM GetKekkaBaseVM(DaDbContext db, tt_kksyudansido_sankasyakekkaDto dto, string regsisyocd, EnumActionType? kbn)
        {
            var vm = new SankasyaFixInfoVM();

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合は、ログイン時選択された支所を表示
                vm.regsisyocd = regsisyocd;                                             //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            else if (kbn == EnumActionType.Update)
            {
                var syukeikbn = CStr(dto.syukeikbn);                                    //地域保健集計区分（コード）
                vm.syukeikbn = MCdNm(db, syukeikbn, EnumNmKbn.地域保健集計区分);        //地域保健集計区分（コード : 名称）
                vm.regsisyocd = CStr(dto.regsisyo);                                     //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            return vm;
        }

        /// <summary>
        /// 参加者詳細画面フリー項目一覧取得
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_kksidofreeitemDto> mstDtl, List<tt_kksyudansido_sankasyafreeDto> dataDtl, string kinoid, int patternno)
        {
            //保健指導フリー項目データタイプ
            var datatypes = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            var list = new List<FreeItemDispInfoVM>();
            foreach (var item in mstDtl)
            {
                var vm = new FreeItemDispInfoVM();
                var dto = dataDtl.Find(x => x.itemcd == item.itemcd);

                if (dto == null)
                {
                    vm = GetVM(db, item, null, null, null, datatypes, kinoid, patternno);
                }
                else
                {
                    vm = GetVM(db, item, dto.fusyoflg, dto.numvalue, dto.strvalue, datatypes, kinoid, patternno);
                }

                list.Add(vm);
            }
            return list;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        private static string MNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 汎用マスタから名称取得
        /// </summary>
        private static string HNm(DaDbContext db, string cd, EnumHanyoKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 名称マスタからコード：名称リストを取得
        /// </summary>
        private static List<DaSelectorModel> MList(DaDbContext db, EnumNmKbn kbn)
        {
            return DaNameService.GetSelectorList(db, kbn, Enum名称区分.名称);
        }

        /// <summary>
        /// 名称マスタからコード：名称取得
        /// </summary>
        private static string MCdNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            if (string.IsNullOrEmpty(cd)) { return string.Empty; }

            var nm = DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));

            return $"{cd}{C_SPACE}{C_COLON}{C_SPACE}{nm}";
        }

        /// <summary>
        /// 汎用マスタからコード：名称取得
        /// </summary>
        private static string HCdNm(DaDbContext db, string cd, EnumHanyoKbn kbn)
        {
            if (string.IsNullOrEmpty(cd)) { return string.Empty; }

            var nm = DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, EnumToStr(kbn));

            return $"{cd}{C_SPACE}{C_COLON}{C_SPACE}{nm}";
        }

        /// <summary>
        /// 生年月日表記取得
        /// </summary>
        private static string GetBymd(tt_afatenaDto dto)
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
        private static string GetBymd(DataRow row)
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

        /// <summary>
        /// 開始時間と終了時間から実施時間を取得
        /// </summary>
        private static string GetJissitm(string tmf, string tmt)
        {
            var str = string.Empty;

            if (tmf.Length != 4) { return string.Empty; }
            str = $"{tmf.Substring(0, 2)}:{tmf.Substring(2, 2)}";

            if (tmt.Length == 4)
            { str = $"{str}～{tmt.Substring(0, 2)}:{tmt.Substring(2, 2)}"; }
            else
            { str = $"{str}～"; }

            return str;
        }

        /// <summary>
        /// 時間を取得時
        /// </summary>
        private static string GetTimeDisp(string tm)
        {
            if (tm.Length == 4) { return $"{tm.Substring(0, 2)}:{tm.Substring(2, 2)}"; }
            return string.Empty;
        }

        /// <summary>
        /// 生年月日と実施日からから結果情報の実施日時点年齢を取得（「〇歳〇カ月」）
        /// </summary>
        private static string GetNenrei(bool bymd_fusyoflg, string bymd, DateTime kijyundate)
        {
            var agestr = string.Empty;

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (CBool(bymd_fusyoflg))
            {
                agestr = FUSYO;
            }
            else
            {
                DateTime sysymd = DateTime.Parse(bymd);              //生年月日（DateTime型）

                DateTime time;
                if (kijyundate <= sysymd)
                {
                    time = DateTime.MinValue + (sysymd - kijyundate);
                }
                else
                {
                    time = DateTime.MinValue + (kijyundate - sysymd);
                }

                agestr = $"{time.Year - 1}歳{time.Month - 1}カ月";
            }

            return agestr;
        }
    }
}