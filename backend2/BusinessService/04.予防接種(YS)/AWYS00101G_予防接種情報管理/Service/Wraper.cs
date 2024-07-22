// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 予防接種情報管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.06.18
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWYS00101G
{
    ///<summary>
    ///固定項目表示区分
    ///</summary>
    public class 固定項目区分
    {
        //接種情報詳細画面
        ///<summary>接種種類</summary>
        public const string _接種_接種種類 = "1";
        ///<summary>接種区分</summary>
        public const string _接種_接種区分 = "2";
        ///<summary>ワクチン名</summary>
        public const string _接種_ワクチン名 = "3";
        ///<summary>ワクチンメーカー</summary>
        public const string _接種_ワクチンメーカー = "4";
        ///<summary>実施区分</summary>
        public const string _接種_実施区分 = "5";
        ///<summary>法定区分</summary>
        public const string _接種_法定区分 = "6";
        ///<summary>実施機関</summary>
        public const string _接種_実施機関 = "7";
        ///<summary>会場</summary>
        public const string _接種_会場 = "8";
        ///<summary>医師</summary>
        public const string _接種_医師 = "9";
        ///<summary>特別の事情</summary>
        public const string _接種_特別の事情 = "10";

        //接種依頼情報詳細画面
        ///<summary>接種種類</summary>
        public const string _依頼_接種種類 = "11";

        //風疹抗体検査情報詳細画面
        ///<summary>抗体検査方法</summary>
        public const string _風疹_抗体検査方法 = "12";
        ///<summary>単位</summary>
        public const string _風疹_単位 = "13";
        ///<summary>接種判定</summary>
        public const string _風疹_接種判定 = "14";
        ///<summary>実施機関</summary>
        public const string _風疹_実施機関 = "15";
        ///<summary>医師</summary>
        public const string _風疹_医師 = "16";
        ///<summary>抗体検査番号</summary>
        public const string _風疹_抗体検査番号 = "17";
    }

    public class Wraper : CmWraperBase
    {
        //================================= ヘッダー情報取得処理 =================================
        /// <summary>
        /// ヘッダー情報
        /// </summary>
        public static HeaderInfoVM GetSessyuHeaderVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg, bool adrsFlg, string sessyukenno)
        {
            var vm = new HeaderInfoVM();

            //ヘッダー部
            vm.atenano = CStr(dto.atenano);                                             //宛名番号
            vm.name = CStr(dto.simei_yusen);                                            //氏名（氏名_優先）
            vm.kname = CStr(dto.simei_kana_yusen);                                      //カナ氏名（氏名_フリガナ_優先）
            vm.sex = CmLogicUtil.GetSex(db, CStr(dto.sex));                             //性別
            vm.bymd = AWKK00301G.Wraper.GetBymd(dto);                                   //生年月日
            var bymd_fusyoflg = CBool(dto.bymd_fusyoflg);                               //生年月日_不詳フラグ
            var bymd = CStr(dto.bymd);                                                  //生年月日
            vm.age = AWKK00301G.Wraper.GetNenrei(bymd_fusyoflg, bymd, DateTime.Now);    //年齢
            vm.agekijunymd = FormatWaKjYMD(DateTime.Now);                               //年齢計算基準日（システム日付の和暦表示）

            var jutokbn = dto.jutokbn;                                                  //住登区分
            var adrs1 = CStr(dto.adrs1);                                                //住所1
            var adrs2 = CStr(dto.adrs2);                                                //住所2
            vm.adrs = CmLogicUtil.GetAdrs(jutokbn, adrs1, adrs2, adrsFlg);              //住所
            var gyoseikucd = CStr(dto.gyoseikucd);                                      //行政区コード
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, gyoseikucd);                    //行政区
            var juminkbn = CStr(dto.juminkbn);                                          //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                        //住民区分名称
            var siensotikbn = CStr(dto.siensotikbn);                                    //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);         //警告内容
            vm.sessyukenno = sessyukenno!;                                              //接種券番号（接種情報詳細画面以外は空白で設定）

            return vm;
        }

        //================================= 一覧情報取得処理 =====================================
        /// <summary>
        /// 住民・住登外一覧取得
        /// </summary>
        public static List<JyuminListVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg, adrsFlg)).ToList();
        }

        /// <summary>
        /// 住民・住登外情報(1行)
        /// </summary>
        private static JyuminListVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new JyuminListVM();
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                   //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                  //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));            //カナ氏名
            vm.sexhyoki = CmLogicUtil.GetSexByRow(db, row);                         //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                     //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                            //住所
            var gyoseikucd = row.Wrap(nameof(tt_afatenaDto.gyoseikucd));            //行政区(コード)
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, gyoseikucd);                //行政区名称
            var juminkbn = row.Wrap(nameof(vm.juminkbn));                           //住民区分コード
            vm.juminkbn = MNm(db, juminkbn, EnumNmKbn.住民区分);                    //住民区分名称
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));          //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);     //警告内容

            return vm;
        }

        /// <summary>
        /// 接種情報（一覧）
        /// </summary>
        public static List<SessyuOneVm> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            List<SessyuOneVm> list = new List<SessyuOneVm>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 接種情報（１行）
        /// </summary>
        public static SessyuOneVm GetVM(DaDbContext db, DataRow row)
        {
            var vm = new SessyuOneVm();

            //生涯1回の場合は表示項目、複数回の場合は非表示項目
            vm.sessyucd = CStr(row.Wrap(nameof(vm.sessyucd)));                                                                  //接種種類（コード)（5桁）
            vm.kaisu = CStr(row.Wrap(nameof(vm.kaisu)));                                                                        //回数（2桁）
            var sessyucd = $"{vm.sessyucd}{vm.kaisu}";                                                                          //接種種類（コード + 回数）（7桁）
            vm.sessyu = DaHanyoService.GetCdNm(db, EnumHanyoKbn.接種種類詳細コード, Enum名称区分.名称, sessyucd);               //接種種類（コード : 名称）
            vm.edano = CInt(row.Wrap(nameof(vm.edano)));                                                                        //枝番

            //表示項目
            vm.jissiymd = CStr(row.Wrap(nameof(vm.jissiymd)));                                                                  //実施日
            vm.sessyukbncd = CStr(row.Wrap(nameof(vm.sessyukbn)));                                                              //接種区分（コード)
            vm.sessyukbn = DaNameService.GetCdNm(db, EnumNmKbn.接種区分, Enum名称区分.名称, vm.sessyukbncd);                    //接種区分（コード : 名称）
            vm.lotno = CStr(row.Wrap(nameof(vm.lotno)));                                                                        //ロット番号
            vm.vaccinenmcd = CStr(row.Wrap(nameof(vm.vaccinenmcd)));                                                            //ワクチン名（コード)
            vm.vaccinenm = DaHanyoService.GetCdNm(db, EnumHanyoKbn.ワクチン, Enum名称区分.名称, vm.vaccinenmcd);                //ワクチン名（コード : 名称）
            vm.vaccinemakercd = CStr(row.Wrap(nameof(vm.vaccinemakercd)));                                                      //チンメーカー（コード)
            vm.vaccinemaker = DaHanyoService.GetCdNm(db, EnumHanyoKbn.ワクチンメーカー, Enum名称区分.名称, vm.vaccinemakercd);  //チンメーカー（コード : 名称）
            vm.sessyuryo = CDbl(row.Wrap(nameof(vm.sessyuryo)));                                                                //接種量
            vm.jissikbncd = CStr(row.Wrap(nameof(vm.jissikbn)));                                                                //実施区分（コード)
            vm.jissikbn = DaNameService.GetCdNm(db, EnumNmKbn.予防接種の実施方式, Enum名称区分.名称, vm.jissikbncd);            //実施区分（コード : 名称）
            vm.hoteikbncd = CStr(row.Wrap(nameof(vm.hoteikbn)));                                                                //法定区分（コード)
            vm.hoteikbn = DaNameService.GetCdNm(db, EnumNmKbn.予防接種区分, Enum名称区分.名称, vm.hoteikbncd);                  //法定区分（コード : 名称）
            vm.tokubetunojijyocd = CStr(row.Wrap(nameof(vm.tokubetunojijyo)));                                                  //特別の事情（コード)
            vm.tokubetunojijyo = DaNameService.GetCdNm(db, EnumNmKbn.特別の事情, Enum名称区分.名称, vm.tokubetunojijyocd);      //特別の事情（コード : 名称）

            //非表示項目
            vm.sessyufilter = CStr(row.Wrap(nameof(vm.sessyufilter)));                                                          //接種種類フィルター区分（Front側選択用）
            vm.sortseq = CStr(row.Wrap(nameof(vm.sortseq)));                                                                    //汎用区分1:3～5桁目（表示順）

            return vm;
        }

        /// <summary>
        /// 罹患情報（一覧）
        /// </summary>
        public static List<SessyuRikanVm> GetVMList(DaDbContext db, List<tt_ysrikanDto> sessyuList, List<string> sisyoList)
        {
            var list = new List<SessyuRikanVm>();
            foreach (var dto in sessyuList)
            {
                list.Add(GetVM(db, dto, sisyoList));
            }
            return list;
        }

        /// <summary>
        /// 罹患情報（１行）
        /// </summary>
        public static SessyuRikanVm GetVM(DaDbContext db, tt_ysrikanDto dto, List<string> sisyoList)
        {
            var vm = new SessyuRikanVm()
            {
                editflg = string.IsNullOrEmpty(dto?.regsisyo) || sisyoList.Contains(CStr(dto?.regsisyo)),           //編集フラグ
                rikancd = CStr(dto.rikancd),                                                                        //罹患コード 
                rikannm = DaHanyoService.GetName(db, EnumHanyoKbn.罹患項目, Enum名称区分.名称, CStr(dto.rikancd)),  //罹患種類（名称）
                haakuymd = CStr(dto.haakuymd),                                                                      //把握日
                rikanjotai = !string.IsNullOrEmpty(CStr(dto.haakuymd)) ? "〇" : string.Empty,                       //罹患状態（把握日が入力された場合、○を表示する）
            };

            return vm;
        }

        /// <summary>
        /// 接種依頼情報（一覧）
        /// </summary>
        public static List<SessyuIraiVm> GetIraiVMList(DaDbContext db, DataRowCollection rows)
        {
            List<SessyuIraiVm> list = new List<SessyuIraiVm>();
            foreach (DataRow row in rows)
            {
                list.Add(GetIraiVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 接種依頼情報（１行）
        /// </summary>
        public static SessyuIraiVm GetIraiVM(DaDbContext db, DataRow row)
        {
            var vm = new SessyuIraiVm();

            //表示項目
            vm.uketukeymd = FormatWaKjYMD(CStr(row.Wrap(nameof(vm.uketukeymd))));   //受付日
            vm.iraisaki = CStr(row.Wrap(nameof(vm.iraisaki)));                      //依頼先
            vm.irairiyu = CStr(row.Wrap(nameof(vm.irairiyu)));                      //依頼理由
            vm.hogosya_atenano = CStr(row.Wrap(nameof(vm.hogosya_atenano)));        //保護者_宛名番号
            vm.hogosya_simei = CStr(row.Wrap(nameof(vm.hogosya_simei)));            //保護者_氏名

            //非表示項目
            vm.edano = CInt(row.Wrap(nameof(vm.edano)));                            //枝番

            return vm;
        }

        //================================= フリー項目一覧取得処理 =====================================
        /// <summary>
        /// フリー項目一覧取得（予防接種（フリー項目）接種テーブル）
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_ysfreeitemDto> mstDtl, List<tt_yssessyufreeDto> dataDtl, string kinoid, int patternno)
        {
            //フリー項目データタイプ
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
        /// フリー項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_ysfreeitemDto mstDto, tt_yssessyufreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.母子, kinoid, patternno, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                                           mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                                           (EnumMsgCtrlKbn)mstDto.msgkbn, mstDto.biko, mstDto.syokiti, (Enum入力タイプ)mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                    //グループID
            vm.groupid2 = mstDto.groupid2;                  //グループID

            vm.orderseq = mstDto.orderseq;                  //並びシーケンス

            return vm;
        }

        /// <summary>
        /// フリー項目一覧取得（予防接種依頼（フリー項目）テーブル）
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_ysfreeitemDto> mstDtl, List<tt_yssessyuiraifreeDto> dataDtl, string kinoid, int patternno)
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
        /// フリー項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_ysfreeitemDto mstDto, tt_yssessyuiraifreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.母子, kinoid, patternno, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                                           mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                                           (EnumMsgCtrlKbn)mstDto.msgkbn, mstDto.biko, mstDto.syokiti, (Enum入力タイプ)mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                    //グループID
            vm.groupid2 = mstDto.groupid2;                  //グループID

            vm.orderseq = mstDto.orderseq;                  //並びシーケンス

            return vm;
        }

        /// <summary>
        /// フリー項目一覧取得（風しん抗体検査（フリー項目）テーブル）
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_ysfreeitemDto> mstDtl, List<tt_yskojinfreeDto> dataDtl, string kinoid, int patternno)
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
        /// フリー項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_ysfreeitemDto mstDto, tt_yskojinfreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.母子, kinoid, patternno, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                                           mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                                           (EnumMsgCtrlKbn)mstDto.msgkbn, mstDto.biko, mstDto.syokiti, (Enum入力タイプ)mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                    //グループID
            vm.groupid2 = mstDto.groupid2;                  //グループID

            vm.orderseq = mstDto.orderseq;                  //並びシーケンス

            return vm;
        }

        /// <summary>
        /// フリー項目一覧取得（風しん抗体検査（フリー項目）テーブル）
        /// </summary>
        public static List<FreeItemDispInfoVM> GetFreeItemVMList(DaDbContext db, List<tm_ysfreeitemDto> mstDtl, List<tt_ysfusinkotaifreeDto> dataDtl, string kinoid, int patternno)
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
        /// フリー項目情報取得(1行)
        /// </summary>
        private static FreeItemDispInfoVM GetVM(DaDbContext db, tm_ysfreeitemDto mstDto, tt_ysfusinkotaifreeDto? dataDto, List<tm_afmeisyoDto> datatypes, string kinoid, int patternno)
        {
            var vm = new FreeItemDispInfoVM();
            vm = (FreeItemDispInfoVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.母子, kinoid, patternno, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                                           mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                                           (EnumMsgCtrlKbn)mstDto.msgkbn, mstDto.biko, mstDto.syokiti, (Enum入力タイプ)mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);
            vm.groupid = mstDto.groupid;                    //グループID
            vm.groupid2 = mstDto.groupid2;                  //グループID

            vm.orderseq = mstDto.orderseq;                  //並びシーケンス

            return vm;
        }

        //================================= 接種情報詳細画面検索処理（固定情報） =================================
        /// <summary>
        /// 接種情報詳細画面の固定情報（表示用）
        /// </summary>
        public static FixItemSessyuVM GetSessyuFixVM(DaDbContext db, tt_yssessyuDto? dto, FixItemSessyuVM vm, EnumActionType? kbn)
        {
            if (dto == null) { return vm; }

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合（仕様には特別な初期設定がない為、いま項目はないです）

            }
            else if (kbn == EnumActionType.Update)
            {
                var sessyucd = $"{CStr(dto.sessyucd)}{CStr(dto.kaisu)}";                                            //接種種類（コード + 回数）
                vm.sessyu = GetDispItem(vm, 固定項目区分._接種_接種種類, sessyucd);                                 //接種種類
                vm.jissiymd = CStr(dto.jissiymd);                                                                   //実施日
                vm.sessyukbn = GetDispItem(vm, 固定項目区分._接種_接種区分, CStr(dto.sessyukbn));                   //接種区分
                vm.lotno = CStr(dto.lotno);                                                                         //ロット番号
                vm.vaccinenm = GetDispItem(vm, 固定項目区分._接種_ワクチン名, CStr(dto.vaccinenmcd));               //ワクチン名
                vm.vaccinemaker = GetDispItem(vm, 固定項目区分._接種_ワクチンメーカー, CStr(dto.vaccinemakercd));   //ワクチンメーカー
                vm.sessyuryo = CDbl(dto.sessyuryo);                                                                 //接種量
                vm.sessyukenno = CStr(dto.sessyukenno);                                                             //接種券番号
                vm.jissikbn = GetDispItem(vm, 固定項目区分._接種_実施区分, CStr(dto.jissikbn));                     //実施区分
                vm.hoteikbn = GetDispItem(vm, 固定項目区分._接種_法定区分, CStr(dto.hoteikbn));                     //法定区分

                vm.jissikikan = GetDispItem(vm, 固定項目区分._接種_実施機関, CStr(dto.jissikikancd));               //実施機関名
                vm.kaijo = GetDispItem(vm, 固定項目区分._接種_会場, CStr(dto.kaijocd));                             //会場名
                vm.isi = GetDispItem(vm, 固定項目区分._接種_医師, CStr(dto.isicd));                                 //医師名

                vm.tokubetunojijyo = GetDispItem(vm, 固定項目区分._接種_特別の事情, CStr(dto.tokubetunojijyo));     //特別の事情
            }
            return vm;
        }

        /// <summary>
        /// 接種依頼情報詳細画面の固定情報（表示用）
        /// </summary>
        public static FixItemSessyuIraiVM GetSessyuIraiFixVM(DaDbContext db, tt_yssessyuiraiDto? dto, FixItemSessyuIraiVM vm, EnumActionType? kbn)
        {
            if (dto == null) { return vm; }

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合（仕様には特別な初期設定がない為、いま項目はないです）

            }
            else if (kbn == EnumActionType.Update)
            {
                vm.uketukeymd = CStr(dto.uketukeymd);                   //受付日
                vm.iraisaki = CStr(dto.iraisaki);                       //依頼先
                vm.irairiyu = CStr(dto.irairiyu);                       //依頼理由
                vm.hogosya_atenano = CStr(dto.hogosya_atenano);         //保護者_宛名番号
                vm.hogosya_simei = CStr(dto.hogosya_simei);             //保護者_氏名
            }
            return vm;
        }

        /// <summary>
        /// 風疹抗体検査情報詳細画面の固定情報（表示用）
        /// </summary>
        public static FixItemFusinVM GetFusinFixVM(DaDbContext db, tt_ysfusinkotaiDto? dto, FixItemFusinVM vm, EnumActionType? kbn)
        {
            if (dto == null) { return vm; }

            if (kbn == EnumActionType.Insert)
            {
                //新規作成の場合（仕様には特別な初期設定がない為、いま項目はないです）

            }
            else if (kbn == EnumActionType.Update)
            {
                vm.sessyukenno = CStr(dto.sessyukenno);                                                           //接種券番号
                vm.kotaikensahoho = GetDispItem(vm, 固定項目区分._風疹_抗体検査方法, CStr(dto.kotaikensahohocd)); //抗体検査方法
                vm.kotaika = CStr(dto.kotaika);                                                                   //抗体価
                vm.tani = GetDispItem(vm, 固定項目区分._風疹_単位, CStr(dto.tanicd));                             //単位（抗体価）
                vm.sessyuhantei = GetDispItem(vm, 固定項目区分._風疹_接種判定, CStr(dto.tanicd));                 //接種判定
                vm.jissiymd = CStr(dto.jissiymd);                                                                 //実施日
                vm.jissikikan = GetDispItem(vm, 固定項目区分._風疹_実施機関, CStr(dto.jissikikancd));             //実施機関名
                vm.isi = GetDispItem(vm, 固定項目区分._風疹_医師, CStr(dto.isicd));                               //医師名
                vm.kotaikensano = GetDispItem(vm, 固定項目区分._風疹_抗体検査番号, CStr(dto.kotaikensanocd));     //抗体検査番号
            }
            return vm;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        public static string MNm(DaDbContext db, string cd, EnumNmKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// リストから該当「項目コード : 名称」を取得（接種情報明細画面）
        /// </summary>
        public static string GetDispItem(FixItemSessyuVM vm, string kbn, string itemcd)
        {
            var dto = new DaSelectorModel();
            switch (kbn)
            {
                case 固定項目区分._接種_接種種類:
                    dto = vm.sessyulist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_接種区分:
                    dto = vm.sessyukbnlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_ワクチン名:
                    dto = vm.vaccinenmlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_ワクチンメーカー:
                    dto = vm.vaccinemakerlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_実施区分:
                    dto = vm.jissikbnlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_法定区分:
                    dto = vm.hoteikbnlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_実施機関:
                    dto = vm.jissikikanlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_会場:
                    dto = vm.kaijolist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_医師:
                    dto = vm.isilist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._接種_特別の事情:
                    dto = vm.tokubetunojijyolist.Find(x => x.value == itemcd);
                    break;
                default:
                    return string.Empty;
            }

            if (dto == null) { return string.Empty; }
            return $"{dto.value}{SPACE}{COLON}{SPACE}{dto.label}";
        }

        /// <summary>
        /// リストから該当「項目コード : 名称」を取得（風疹抗体検査情報明細画面）
        /// </summary>
        public static string GetDispItem(FixItemFusinVM vm, string kbn, string itemcd)
        {
            var dto = new DaSelectorModel();
            switch (kbn)
            {
                case 固定項目区分._風疹_抗体検査方法:
                    dto = vm.kotaikensahoholist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._風疹_単位:
                    dto = vm.tanilist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._風疹_接種判定:
                    dto = vm.sessyuhanteilist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._風疹_実施機関:
                    dto = vm.jissikikanlist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._風疹_医師:
                    dto = vm.isilist.Find(x => x.value == itemcd);
                    break;
                case 固定項目区分._風疹_抗体検査番号:
                    dto = vm.kotaikensanolist.Find(x => x.value == itemcd);
                    break;
                default:
                    return string.Empty;
            }

            if (dto == null) { return string.Empty; }
            return $"{dto.value}{SPACE}{COLON}{SPACE}{dto.label}";
        }

    }
}