// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検診結果管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.07.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaConvertUtil;
using System.Text.RegularExpressions;

namespace BCC.Affect.Service.AWSH001
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検診結果一覧取得
        /// </summary>
        public static List<KsRowVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r, alertviewflg, adrsFlg)).ToList();
        }

        /// <summary>
        /// 検診全回目のベース情報
        /// </summary>
        public static List<KsTimeVM> GetVMList(DataRowCollection rows, List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            return rows.Cast<DataRow>().Select(e => GetVM(e, dtl1, dtl2)).ToList();
        }

        /// <summary>
        /// 個人基本情報
        /// </summary>
        public static KsHeaderVM GetHeaderVM(DaDbContext db, tt_afatenaDto? dto, bool personalflg, bool alertviewflg, string publickey, bool kensinkibosyasyosaiflg)
        {
            var vm = new KsHeaderVM();
            if (dto == null) return vm;
            vm.name = dto.simei_yusen;                                                              //氏名
            vm.kname = CStr(dto.simei_kana_yusen);                                                  //カナ氏名
            vm.sexhyoki = CmLogicUtil.GetSex(db, dto.sex);                                          //性別
            vm.bymd = CmLogicUtil.GetYMDStr(dto.bymd_fusyoflg, dto.bymd, dto.bymd_fusyohyoki);      //生年月日
            vm.juminkbn = DaNameService.GetName(db, EnumNmKbn.住民区分, dto.juminkbn);               //住民区分
            vm.age = CmLogicUtil.GetAgeStr(dto.bymd_fusyoflg, dto.bymd, DaUtil.Today);              //年齢
            vm.agekijunymd = DaFormatUtil.FormatWaKjYMD(DaUtil.Today);                              //年齡計算基準日
            vm.personalno = (personalflg && !string.IsNullOrEmpty(dto.personalno)) ?
                DaEncryptUtil.AesDecryptAndRsaEncrypt(dto.personalno, publickey) : string.Empty;    //個人番号(暗号化)
            vm.keikoku = CmLogicUtil.GetKeikoku(db, dto.siensotikbn, alertviewflg);                 //警告内容
            vm.kensinkibosyasyosaiflg = kensinkibosyasyosaiflg;                                     //健（検）診予約希望者詳細フラグ
            return vm;
        }

        /// <summary>
        /// 回目項目
        /// </summary>
        public static KsTimeSearchVM GetVM(DaDbContext db, KsTimeVM timeVM, List<tm_shfreeitemDto> mstDtl, List<tt_shfreeDto> dataDtl, string kinoid)
        {
            var vm = new KsTimeSearchVM();
            //成人保健フリー項目データタイプ
            var datatypes = DaNameService.GetNameList(db, EnumNmKbn.フリー項目データタイプ);

            vm.kensinkaisu = timeVM.kensinkaisu;//検診回数

            //一次項目(固定)：マスタデータ
            var mstDtl1 = mstDtl.Where(e => e.haitiflg && e.groupid == EnumKensinKbn.一次).ToList();
            //一次項目(固定)：項目コード一覧
            var fixCds1 = mstDtl1.Select(e => e.itemcd).ToList();
            //一次項目(固定)：検診結果データ
            var itemDtl1 = dataDtl.Where(e => fixCds1.Contains(e.itemcd)).ToList();

            //一次項目
            vm.jissiymd1 = timeVM.jissiymd1;        //実施日(一次)
            vm.upddttm1 = timeVM.upddttm1;          //更新日時(一次)
            vm.jissiage1 = timeVM.jissiage1;        //実施年齢(一次)
            vm.kensahoho1 = timeVM.kensahoho1;      //検査方法(一次)
            vm.regsisyo1 = timeVM.regsisyo1;        //登録支所(一次固定)
            vm.regsisyonm1 = timeVM.regsisyonm1;    //登録支所名(一次固定)
            //固定項目(一次)
            vm.itemlist1 = GetVMList(db, mstDtl1, itemDtl1, datatypes, timeVM.kensinkaisu, kinoid).Cast<KsFixItemVM>().ToList();

            //精密項目(固定)：マスタデータ
            var mstDtl2 = mstDtl.Where(e => e.haitiflg && e.groupid == EnumKensinKbn.精密).ToList();
            //精密項目(固定)：項目コード一覧
            var fixCds2 = mstDtl2.Select(e => e.itemcd).ToList();
            //精密項目(固定)：検診結果データ
            var itemDtl2 = dataDtl.Where(e => fixCds2.Contains(e.itemcd)).ToList();

            //精密項目
            vm.jissiymd2 = timeVM.jissiymd2;        //実施日(精密)
            vm.upddttm2 = timeVM.upddttm2;          //更新日時(精密)
            vm.jissiage2 = timeVM.jissiage2;        //実施年齢(精密)
            vm.regsisyo2 = timeVM.regsisyo2;        //登録支所(精密固定)
            vm.regsisyonm2 = timeVM.regsisyonm2;    //登録支所名(精密固定)
            //固定項目(精密)
            vm.itemlist2 = GetVMList(db, mstDtl2, itemDtl2, datatypes, timeVM.kensinkaisu, kinoid).Cast<KsFixItemVM>().ToList();

            //フリー項目：検診結果データ
            var itemDtl3 = dataDtl.Where(e => (!fixCds1.Contains(e.itemcd)) && (!fixCds2.Contains(e.itemcd))).ToList();
            //フリー項目：マスタデータ
            var mstDtl3 = mstDtl.Where(e => (!fixCds1.Contains(e.itemcd)) && (!fixCds2.Contains(e.itemcd))).ToList();
            //フリー項目
            vm.itemlist3 = GetVMList(db, mstDtl3, itemDtl3, datatypes, timeVM.kensinkaisu, kinoid);

            return vm;
        }

        /// <summary>
        /// 状態一覧取得(保存処理)
        /// </summary>
        public static List<KsStatusVM> GetVMList(EnumAtenaActionType kbn, int kensinkaisu)
        {
            var list = new List<KsStatusVM>();
            list.Add(new KsStatusVM
            {
                statuskbn = (EnumActionType)kbn,
                kensinkaisubefore = kbn == EnumAtenaActionType.追加 ? null : kensinkaisu,
                kensinkaisuafter = kensinkaisu
            });
            return list;
        }

        /// <summary>
        /// 状態一覧取得(削除処理)
        /// </summary>
        public static List<KsStatusVM> GetVMList(List<int> keylist, int? kensinkaisu, Enum削除区分 kbn)
        {
            var list = new List<KsStatusVM>();
            foreach (int i in keylist)
            {
                var vm = new KsStatusVM();
                vm.statuskbn = EnumActionType.Delete;
                vm.kensinkaisubefore = i;
                vm.kensinkaisuafter = null;
                if (kbn == Enum削除区分.単一削除 && i != kensinkaisu!)
                {
                    vm.statuskbn = EnumActionType.Update;
                    vm.kensinkaisuafter = i - 1;
                }

                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 計算結果一覧取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="tolist">計算対象リスト</param>
        /// <param name="fromlist">入力済項目リスト</param>
        /// <param name="valuelist">データリスト</param>
        /// <param name="dtl">マスタ情報</param>
        /// <returns></returns>
        public static List<KsCalculateVM> GetVMList(DaDbContext db, List<string> tolist, List<string> fromlist, List<KsKekkaItemVM> valuelist, List<tm_shfreeitemDto> dtl)
        {
            var list = new List<KsCalculateVM>();
            //パラメータリスト(DB関数用)
            var procList = new List<ProcModel>();
            //キーリスト(DB関数用)
            var keyList = new List<string>();

            foreach (var cd in tolist)
            {
                var item = dtl.Find(e => e.itemcd == cd)!;
                //パラメータリスト
                var paralist = new List<string>();
                if (!string.IsNullOrEmpty(item.keisanparam))
                {
                    paralist = item.keisanparam.Split(C_COMMA).ToList();
                    
                }
                else if(item.keisankbn == Enum計算区分.数式計算)
                {
                    string pattern = @"\{([^}]+)\}";
                    MatchCollection matches = Regex.Matches(item.keisansusiki!, pattern);
                    foreach (Match match in matches)
                    {
                        paralist.Add(match.Groups[1].Value);
                    }
                }
                //パラメータの中で、入力済ではない項目が存在する場合、計算しない
                if (paralist.Exists(e => !fromlist.Contains(e))) continue;

                var vm = new KsCalculateVM();
                //項目コード
                vm.itemcd = cd;
                //値
                switch (item.keisankbn)
                {
                    case Enum計算区分.数式計算:
                        vm.value = CmLogicUtil.KensinCalculate1(item.keisansusiki!, paralist, valuelist);
                        break;
                    case Enum計算区分.内部関数:
                        vm.value = CmLogicUtil.KensinCalculate2(db, item.keisankansuid!, paralist, valuelist);
                        break;
                    case Enum計算区分.DB関数:
                        //性能向上のため、一旦保留
                        //vm.value = CmLogicUtil.KensinCalculate3(db, item.keisankansuid!, paralist, valuelist);
                        procList.Add(CmLogicUtil.GetKensinCalculatePara(db, item.keisankansuid!, paralist, valuelist));
                        break;
                    default:
                        throw new Exception("Enum計算区分 error");
                }
                //DB関数の場合、パラメータリストに格納
                if (item.keisankbn == Enum計算区分.DB関数)
                {
                    keyList.Add(vm.itemcd);
                }
                //上記以外の場合、結果リストに格納
                else
                {
                    list.Add(vm);
                }
            }
            //DB関数の場合、パラメータリストから結果を取得して、結果リストに格納
            var valueList = DaDbUtil.GetProcedureValueList(db, procList);
            for (var i = 0; i < procList.Count; i++)
            {
                var vm = new KsCalculateVM();
                vm.itemcd = keyList[i];
                vm.value = valueList[i];
                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 基準値一覧取得
        /// </summary>
        public static List<Common.KjItemVM> GetVMList(List<KjFreeItemVM> freeItems, List<tm_kkkijunDto> kijunDtl, bool ageSureFlg, bool sexSureFlg, Enum性別 sex)
        {
            return freeItems.Select(item => CmKijunUtil.GetVM(item, kijunDtl, ageSureFlg, sexSureFlg, sex)).ToList();
        }

        /// <summary>
        /// 検診結果(1行)
        /// </summary>
        private static KsRowVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new KsRowVM();
            vm.kensinkaisu = row.CNInt(nameof(KensinView.kensinkaisu));             //検診回数
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                   //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                  //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));            //カナ氏名
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                              //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                     //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                            //住所
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, row);                       //行政区
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                         //住民区分
            vm.jissiymd1 = row.CNDate(nameof(KensinView.jissiymd1));                //受診年月日(一次)
            vm.jissiymd2 = row.CNDate(nameof(KensinView.jissiymd2));                //受診年月日(精密)
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));          //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);     //警告内容

            return vm;
        }

        /// <summary>
        /// ベース情報(各回目)
        /// </summary>
        private static KsTimeVM GetVM(DataRow row, List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            var vm = new KsTimeVM();
            vm.kensinkaisu = row.CNInt($"{nameof(KsTimeVM.kensinkaisu)}_out");                      //検診回数
            vm.jissiymd1 = row.CNDate(nameof(KsTimeVM.jissiymd1));                                  //実施日（一次）
            vm.jissiymd2 = row.CNDate(nameof(KsTimeVM.jissiymd2));                                  //実施日（精密）
            vm.jissiage1 = row.CNInt(nameof(KsTimeVM.jissiage1));                                   //実施年齢（一次）
            vm.jissiage2 = row.CNInt(nameof(KsTimeVM.jissiage2));                                   //実施年齢（精密）
            var kensahoho1cd = row.Wrap(nameof(KsTimeVM.kensahoho1));
            vm.kensahoho1 = DaHanyoService.GetCdNm(dtl2, Enum名称区分.名称, kensahoho1cd);          //検査方法（一次）
            vm.upddttm1 = row.CNDate(nameof(KsTimeVM.upddttm1));                                    //更新日時（一次）
            vm.upddttm2 = row.CNDate(nameof(KsTimeVM.upddttm2));                                    //更新日時（精密）
            vm.regsisyo1 = row.ToNStr(nameof(KsTimeVM.regsisyo1));                                  //登録支所（一次）
            vm.regsisyo2 = row.ToNStr(nameof(KsTimeVM.regsisyo2));                                  //登録支所（精密）
            vm.regsisyonm1 = DaHanyoService.GetName(dtl1, Enum名称区分.名称, CStr(vm.regsisyo1));   //登録支所名（一次）
            vm.regsisyonm2 = DaHanyoService.GetName(dtl1, Enum名称区分.名称, CStr(vm.regsisyo2));   //登録支所名（精密）
            return vm;
        }

        /// <summary>
        /// 項目一覧取得
        /// </summary>
        private static List<KsFreeItemVM> GetVMList(DaDbContext db, List<tm_shfreeitemDto> mstDtl, List<tt_shfreeDto> dataDtl, List<tm_afmeisyoDto> datatypes, int? kensinkaisu, string kinoid)
        {
            var list = new List<KsFreeItemVM>();
            foreach (var item in mstDtl)
            {
                var vm = new KsFreeItemVM();
                var dto = dataDtl.Find(x => x.itemcd == item.itemcd);
                vm = GetVM(db, item, dto, datatypes, kensinkaisu, kinoid);
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// 項目情報取得(1行)
        /// </summary>
        private static KsFreeItemVM GetVM(DaDbContext db, tm_shfreeitemDto mstDto, tt_shfreeDto? dataDto, List<tm_afmeisyoDto> datatypes, int? kensinkaisu, string kinoid)
        {
            var vm = new KsFreeItemVM();
            vm = (KsFreeItemVM)CmLogicUtil.GetFreeVM(db, vm, datatypes, Enumフリーマスタ分類.成人, kinoid, null, dataDto?.numvalue, dataDto?.strvalue, dataDto?.fusyoflg,
                                            mstDto.itemcd, mstDto.itemnm, mstDto.groupid2, mstDto.tani, mstDto.keta, mstDto.hissuflg, mstDto.hanif, mstDto.hanit, mstDto.inputflg,
                                            mstDto.msgkbn, mstDto.biko, mstDto.syokiti, mstDto.inputtype, mstDto.codejoken1, mstDto.codejoken2, mstDto.codejoken3);

            vm.groupid = mstDto.groupid;
            vm.groupid2 = CNStr(mstDto.groupid2);       //グループID2
            //利用検査方法コード一覧
            vm.riyokensahohocds = CommaStrToList(mstDto.riyokensahohocd);

            //vm.kekkaflg = mstDto.kekkaflg;              //結果項目フラグ//TODO_CNC_20240426_DB定義生成
            vm.komokutokuteikbn = mstDto.komokutokuteikbn;

            //既存データがある場合
            if (dataDto != null)
            {
                vm.kensinkaisu = dataDto.kensinkaisu;   //検診回数
            }
            else
            {
                //検診回数
                switch (vm.groupid)
                {
                    case EnumKensinKbn.一次:
                        vm.kensinkaisu = mstDto.rirekiflg ? kensinkaisu : Service.TSUNEN;
                        break;
                    case EnumKensinKbn.精密:
                        vm.kensinkaisu = mstDto.rirekiflg ? kensinkaisu : Service.TSUNEN;
                        break;
                    default:
                        throw new Exception("groupid error");
                }
            }

            return vm;
        }
    }
}