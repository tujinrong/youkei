// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.13
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using log4net.Core;
using Microsoft.Extensions.Primitives;
using NPOI.SS.Formula.Functions;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWKK00301G
{
    public class Wraper : CmWraperBase
    {
        public enum EnumNmKbn1 : long
        {
            保健指導フリー項目グループ１ = 1001 * 100000000L + 2,
        }

        //定数定義
        private const string FUSYO = "不詳";          //生年月日が不詳の場合は利用

        //================================= 1.住民一覧画面検索処理(一覧画面) =================================
        /// <summary>
        /// 住民情報一覧
        /// </summary>
        public static List<JyuminListVM> GetJyuminVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetJyuminVM(db, r, alertviewflg, adrsFlg)).ToList();
        }

        /// <summary>
        /// 住民情報（一行）
        public static JyuminListVM GetJyuminVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new JyuminListVM();

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

            return vm;
        }

        //================================= 2.3.住民詳細画面検索処理(一覧画面) =================================
        /// <summary>
        /// 世帯固定情報
        public static SetaiBaseInfoVM GetSetaiVM(DaDbContext db, tt_afatenaDto dto)
        {
            var vm = new SetaiBaseInfoVM();

            vm.atenano = CStr(dto.atenano);                                             //宛名番号
            vm.name = CStr(dto.simei_yusen);                                            //氏名（氏名_優先）
            vm.kname = CStr(dto.simei_kana_yusen);                                      //カナ氏名（氏名_フリガナ_優先）
            vm.adrs_yubin = CStr(dto.adrs_yubin);                                       //郵便番号
            var gyoseikucd = CStr(dto.tosi_gyoseikucd);                                 //指定都市_行政区等コード
            vm.tosi_gyoseiku = MNm(db, gyoseikucd, EnumNmKbn.指定都市_行政区等コード);  //行政区名称
            vm.adrs = GetAdrs(dto);                                                     //住所(住所1、住所2)

            return vm;
        }

        /// <summary>
        /// 世帯地区情報（一覧）
        /// </summary>
        public static List<SetaiTikuListVM> GetTikuVMList(DaDbContext db, DataTable rows)
        {
            List<SetaiTikuListVM> list = new List<SetaiTikuListVM>();
            foreach (DataRow row in rows.Rows)
            {
                list.Add(GetTikuVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 世帯地区情報（一行）
        public static SetaiTikuListVM GetTikuVM(DaDbContext db, DataRow row)
        {
            var vm = new SetaiTikuListVM();

            vm.tikukbn = row.Wrap(nameof(vm.tikukbn));          //地区区分
            vm.tiku = row.Wrap(nameof(vm.tiku));                //地区名称

            return vm;
        }

        /// <summary>
        /// 世帯構成員情報一覧
        /// </summary>
        public static List<SetaiListVM> GetSetaiVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg)
        {
            List<SetaiListVM> list = new List<SetaiListVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetSetaiVM(db, row, alertviewflg));
            }
            return list;
        }

        /// <summary>
        /// 世帯構成員情報（一行）
        public static SetaiListVM GetSetaiVM(DaDbContext db, DataRow row, bool alertviewflg)
        {
            var vm = new SetaiListVM();

            vm.atenano = row.Wrap(nameof(vm.atenano));                                  //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                      //氏名（氏名_優先）
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));                //カナ氏名（氏名_フリガナ_優先）
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                                  //性別
            vm.bymd = GetBymd(row);                                                     //生年月日
            var juminkbn = row.Wrap(nameof(vm.juminkbn));                               //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分名称
            vm.zokuhyoki = row.Wrap(nameof(tt_afatenaDto.zokuhyoki));                   //続柄（続柄表記）
            vm.homonyoteiymd = row.Wrap(nameof(vm.homonyoteiymd));                      //訪問指導予定日
            vm.homonjissiymd = row.Wrap(nameof(vm.homonjissiymd));                      //訪問指導実施日
            vm.kobetuyoteiymd = row.Wrap(nameof(vm.kobetuyoteiymd));                    //個別指導予定日
            vm.kobetujissiymd = row.Wrap(nameof(vm.kobetujissiymd));                    //個別指導実施日
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));              //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        //================================= 4.世帯詳細画面検索処理(一覧画面) =================================
        /// <summary>
        /// 詳細画面--ヘッダー部
        /// </summary>
        public static PersonalHeaderInfoVM GetPersonalHeaderVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg)
        {
            var vm = new PersonalHeaderInfoVM();

            //ヘッダー部
            vm.atenano = CStr(dto.atenano);                                             //宛名番号
            vm.name = CStr(dto.simei_yusen);                                            //氏名（氏名_優先）
            vm.sex = CmLogicUtil.GetSex(db, CStr(dto.sex));                             //性別
            var juminkbn = CStr(dto.juminkbn);                                          //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分名称
            vm.bymd = GetBymd(dto);                                                     //生年月日
            vm.kijunymd = FormatWaKjYMD(DateTime.Now);                                  //年齢計算基準日（システム日付の和暦表示）
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                               //生年月日_不詳フラグ
            var bymd = CStr(dto.bymd);                                                  //生年月日
            vm.age = GetNenrei(bymd_fusyoflg, bymd, DateTime.Now);                      //年齢
            var siensotikbn = CStr(dto.siensotikbn);                                    //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容

            return vm;
        }

        //================================= 4.世帯詳細画面検索処理(一覧画面) =================================
        //================================= 5.世帯詳細画面検索処理(一覧絞込) =================================
        /// <summary>
        /// 指導情報一覧
        /// </summary>
        public static List<ShidouInfoListVM> GetHoumonVMList(DaDbContext db, DataRowCollection rows)
        {
            List<ShidouInfoListVM> list = new List<ShidouInfoListVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetHoumonVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 指導情報（一行）
        public static ShidouInfoListVM GetHoumonVM(DaDbContext db, DataRow row)
        {
            var vm = new ShidouInfoListVM();

            var gyomukbn = row.Wrap(nameof(tt_kkhokensido_mosikomiDto.gyomukbn));       //業務区分コード
            vm.gyomunm = MNm(db, gyomukbn, EnumNmKbn.拡張_予約_保健指導業務区分);       //業務名称
            vm.jigyocd = row.Wrap(nameof(vm.jigyocd));                                  //事業コード
            vm.jigyonm = Service.GetJigyoNm(db, vm.jigyocd);                            //事業名称
            vm.yoteiymd = FormatWaKjYMD(row.Wrap(nameof(vm.yoteiymd)));                 //実施予定日
            vm.yoteitm = GetTimeDisp(row.Wrap(nameof(vm.yoteitm)));                     //予定開始時間
            vm.yoteikaijo = row.Wrap(nameof(vm.yoteikaijo));                            //実施場所（申込）
            vm.yoteisya = row.Wrap(nameof(vm.yoteisya));                                //予定者
            vm.jissiymd = FormatWaKjYMD(row.Wrap(nameof(vm.jissiymd)));                 //実施日

            vm.jissitm = GetTimeDisp(row.Wrap(nameof(vm.jissitm)));                     //予定開始時間

            vm.jissikaijo = row.Wrap(nameof(vm.jissikaijo));                            //実施場所（結果）

            var bymd_fusyoflg = CBool(row.Wrap(nameof(tt_afatenaDto.bymd_fusyoflg)));   //生年月日_不詳フラグ
            var bymd = row.Wrap(nameof(tt_afatenaDto.bymd));                            //生年月日
            if (!string.IsNullOrEmpty(vm.jissiymd))
            {
                var jissiymd = DateTime.Parse(vm.jissiymd);                             //実施日（DateTime型）
                vm.nenrei = GetNenrei(bymd_fusyoflg, bymd, jissiymd);                   //実施日時点年齢（結果）
            }
            vm.jissisya = row.Wrap(nameof(vm.jissisya));                                //実施者
            vm.edano = CInt(row.Wrap(nameof(vm.edano)));                                //枝番

            return vm;
        }

        //================================= 6.個人詳細画面検索処理(一覧画面) =================================
        /// <summary>
        /// 個人詳細申込情報（表示用）
        /// </summary>
        public static FixDispInfoVM GetMosikomiBaseVM(DaDbContext db, tt_kkhokensido_mosikomiDto dto, string kaijonm, List<StaffListVM> stafflist, string regsisyocd, EnumActionType? kbn)
        {
            var vm = new FixDispInfoVM();

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合は、ログイン時選択された支所を表示
                vm.inputflg = false;
                vm.regsisyocd = regsisyocd;                                             //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            else if (kbn == EnumActionType.Update)
            {
                vm.inputflg = true;
                var jigyocd = CStr(dto.jigyocd);                                        //事業コード
                vm.jigyo = Service.GetJigyoCdNm(db, jigyocd);                           //事業（コード : 名称）
                vm.yoteiymd = CStr(dto.yoteiymd);                                       //実施予定日
                vm.yoteitm = CStr(dto.yoteitm);                                         //予定開始時間
                vm.kaijo = kaijonm;                                                     //実施場所
                vm.stafflist = stafflist;                                               //事業従事者リスト（予定者）
                vm.regsisyocd = CStr(dto.regsisyo);                                     //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            return vm;
        }

        /// <summary>
        /// 個人詳細結果情報（表示用）
        /// </summary>
        public static FixDispInfoVM GetKekkaBaseVM(DaDbContext db, tt_kkhokensido_kekkaDto dto, string kaijonm, List<StaffListVM> stafflist, string regsisyocd, EnumActionType? kbn)
        {
            var vm = new FixDispInfoVM();

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合は、ログイン時選択された支所を表示
                vm.inputflg = false;
                vm.regsisyocd = regsisyocd;                                             //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            else if (kbn == EnumActionType.Update)
            {
                vm.inputflg = true;
                var jigyocd = CStr(dto.jigyocd);                                        //事業コード
                vm.jigyo = Service.GetJigyoCdNm(db, jigyocd);                           //事業（コード : 名称）
                vm.jissiymd = CStr(dto.jissiymd);                                       //実施日
                vm.tmf = CStr(dto.tmf);                                                 //開始時間
                vm.tmt = CStr(dto.tmt);                                                 //終了時間
                vm.kaijo = kaijonm;                                                     //実施場所
                vm.stafflist = stafflist;                                               //事業従事者リスト（予定者）
                var syukeikbn = CStr(dto.syukeikbn);                                    //地域保健集計区分（コード）
                vm.syukeikbn = MCdNm(db, syukeikbn, EnumNmKbn.地域保健集計区分);        //地域保健集計区分（コード : 名称）
                vm.regsisyocd = CStr(dto.regsisyo);                                     //登録支所コード
                vm.regsisyonm = HNm(db, vm.regsisyocd, EnumHanyoKbn.部署_支所);         //登録支所名称
            }
            return vm;
        }

        /// <summary>
        /// 初期化処理(個人詳細画面)
        /// </summary>
        public static InitDetailVM GetVM(DaDbContext db, List<DaSelectorModel> kaijodtl, List<DaSelectorModel> staffdtl)
        {
            var vm = new InitDetailVM();

            //ドロップダウンリスト初期設定
            vm.kaijolist = kaijodtl;                                                    //実施場所リスト
            vm.stafflist = staffdtl;                                                　  //実施者リスト
            vm.syukeikbnlist = MList(db, EnumNmKbn.地域保健集計区分);                   //地域保健集計区分
            vm.group1list = Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ);//グループ１ 
            vm.group2list = Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ2);//グループ２
            vm.gyomulist = MList(db, EnumNmKbn.拡張_予約_保健指導業務区分);             //業務リスト

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

        /// <summary>
        /// 項目一覧取得
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_kksidofreeitemDto> mstDtl, List<tt_kkhokensidofreeDto> dataDtl, string kinoid, int patternno)
        {
            //保健指導フリー項目データタイプ
            var datatypes = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            var list = new List<FreeItemDispInfoVM>();
            foreach (var item in mstDtl)
            {
                var vm = new FreeItemDispInfoVM();
                var dto = dataDtl.Find(x => x.itemcd == item.itemcd);
                vm = GetVM(db, item, dto, datatypes, kinoid, patternno);
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// 項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_kksidofreeitemDto mstDto, tt_kkhokensidofreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.指導, kinoid, patternno, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                            mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                            mstDto.msgkbn, mstDto.biko, mstDto.syokiti, mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                //グループID
            //分類（略称）
            vm.itemkbn = DaSelectorService.GetName(db, CStr(vm.groupid), Enum名称区分.略称, Enumマスタ区分.汎用マスタ, EnumToStr(EnumHanyoKbn.保健指導_集団指導項目グループ));
            vm.groupid2 = CNStr(mstDto.groupid2);       //グループID2
            vm.syukeikbn = CStr(mstDto.syukeikbn);      //利用地域保健集計区分

            return vm;
        }

        /// <summary>
        /// 初期化処理(個人詳細画面)
        /// </summary>
        public static string GetVM(DaDbContext db, tt_afatenaDto dto, string jissiymd)
        {
            var nenrei = string.Empty;
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                       //生年月日_不詳フラグ
            var bymd = CStr(dto.bymd);                                          //生年月日
            if (!string.IsNullOrEmpty(jissiymd))
            {
                var ymd = DateTime.Parse(jissiymd);                             //実施日（DateTime型）
                nenrei = GetNenrei(bymd_fusyoflg, bymd, ymd);                   //実施日時点年齢（結果）
            }
            return nenrei;
        }

        //************************************************************** 関数 **************************************************************

        /// <summary>
        /// 住所取得
        /// </summary>
        private static string GetAdrs(DataRow row)
        {
            var adrs = string.Empty;

            var jutokbn = row.Wrap(nameof(tt_afatenaDto.jutokbn));  //住登区分（1:住民情報、2:住登外情報）

            //コードから列挙型に変更
            var jutokbnenum = (Enum住登区分)Enum.Parse(typeof(Enum住登区分), jutokbn);

            if (jutokbnenum.Equals(Enum住登区分.住民))
            {
                adrs = row.Wrap(nameof(tt_afatenaDto.adrs1));       //住所1
            }
            else if (jutokbnenum.Equals(Enum住登区分.住登外))
            {
                adrs = $"{row.Wrap(nameof(tt_afatenaDto.adrs1))}{row.Wrap(nameof(tt_afatenaDto.adrs2))}";   //住所1＋住所2
            }

            return adrs;
        }

        /// <summary>
        /// 住所取得
        /// </summary>
        private static string GetAdrs(tt_afatenaDto dto)
        {
            var adrs = string.Empty;

            var jutokbn = dto.jutokbn;                              //住登区分（1:住民情報、2:住登外情報）
            if (jutokbn.Equals(Enum住登区分.住民))
            {
                adrs = CStr(dto.adrs2);                             //住所2
            }
            else if (jutokbn.Equals(Enum住登区分.住登外))
            {
                adrs = $"{CStr(dto.adrs1)}{CStr(dto.adrs2)}";       //住所1＋住所2
            }

            return adrs;
        }

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
        public static List<DaSelectorModel> MList(DaDbContext db, EnumNmKbn kbn)
        {
            return DaNameService.GetSelectorList(db, kbn, Enum名称区分.名称);
        }

        private static List<DaSelectorModel> MRefList(DaDbContext db, List<tm_afhanyoDto> list)
        {
            return list.Select(e => new DaSelectorModel(e.hanyocd, e.nm)).ToList();
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
        /// 名称マスタからコード：名称 拡張名称1 拡張名称2取得（市区町村リスト用）
        /// </summary>
        private static string MCdNmExp(string? cd, string? expname1, string? expname2)
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
        private static string HCdNm(DaDbContext db, string cd, EnumHanyoKbn kbn)
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

        /// <summary>
        /// 生年月日と実施日からから結果情報の実施日時点年齢を取得（「〇歳〇カ月」）
        /// </summary>
        public static string GetNenrei(bool bymd_fusyoflg, string bymd, DateTime kijyundate)
        {
            var agestr = string.Empty;

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (CBool(bymd_fusyoflg))
            {
                agestr = FUSYO;
            }
            else if (string.IsNullOrEmpty(bymd))
            {
                agestr = string.Empty;
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

        /// <summary>
        /// 開始時間と終了時間から実施時間実施を取得時
        /// </summary>
        private static string GetTimeDisp(string tm)
        {
            var arr = tm.Split(C_TILDE_FULL);
            var str = string.Empty;
            if (arr.Length == 0) return string.Empty;

            if (arr[0].Length == 4) { str = $"{arr[0].Substring(0, 2)}:{arr[0].Substring(2, 2)}"; }

            if (arr.Length == 1) { return str; }

            str = $"{str}{C_TILDE_FULL}";

            if (arr[1].Length == 4) { str = $"{str}{arr[1].Substring(0, 2)}:{arr[1].Substring(2, 2)}"; }

            return str;
        }
    }
}