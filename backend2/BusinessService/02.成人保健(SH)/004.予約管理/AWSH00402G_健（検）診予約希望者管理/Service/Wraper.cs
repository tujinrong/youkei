// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予約希望者管理
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.19
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWSH00402G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 列情報取得
        /// </summary>
        public static List<ColumnInfoVM> GetVMList(DataColumnCollection cols, int num)
        {
            var list = new List<ColumnInfoVM>();
            for (var i = 0; i < cols.Count - num; i++)
            {
                var vm = new ColumnInfoVM();
                vm.title = cols[i].Caption;     //項目論理名
                vm.key = cols[i].ColumnName;    //項目物理名
                list.Add(vm);
                //日程一覧画面の場合
                if (cols[i].ColumnName == nameof(tt_shkensinyoteiDto.nitteino))
                {
                    var vm1 = new ColumnInfoVM();
                    vm1.title = $"事業名{Environment.NewLine}時間{Environment.NewLine}医療機関";
                    vm1.key = "naiyo1";
                    list.Add(vm1);

                    var vm2 = new ColumnInfoVM();
                    vm2.title = $"実施予定日{Environment.NewLine}会場{Environment.NewLine}担当者";
                    vm2.key = "naiyo2";
                    list.Add(vm2);

                    var vm3 = new ColumnInfoVM();
                    vm3.title = string.Empty;
                    vm3.key = "title";
                    list.Add(vm3);
                }
                //予約者一覧画面の場合
                if (cols[i].ColumnName == nameof(tt_afatenaDto.bymd))
                {
                    var vm1 = new ColumnInfoVM();
                    vm1.title = "年齢";
                    vm1.key = "age";
                    list.Add(vm1);
                }
            }
            return list;
        }

        /// <summary>
        /// 結果一覧(予約情報：日程一覧画面)取得
        /// </summary>
        public static List<List<DataInfoVM>> GetVMList(DataRowCollection rows, List<string> keys, List<DaSelectorModel> list1,
                                                        List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            var list = new List<List<DataInfoVM>>();
            foreach (DataRow dr in rows)
            {
                list.Add(GetVM(dr, keys, list1, list2, list3));
            }

            return list;
        }

        /// <summary>
        /// 日程基本情報取得
        /// </summary>
        public static HeaderVM GetHeaderVM(tt_shkensinyoteiDto dto, List<string> staffids, List<DaSelectorModel> list1,
                                            List<DaSelectorModel> list2, List<DaSelectorModel> list3, List<DaSelectorModel> list4)
        {
            var vm = new HeaderVM();
            vm.jigyonm = list1.Find(e => e.value == dto.jigyocd)!.label;                                                    //成人健（検）診予約日程事業名
            vm.yoteiymd = dto.yoteiymd;                                                                                     //実施予定日
            vm.timef = FormatTime(dto.tmf);                                                                                 //開始時間
            vm.timet = FormatTime(dto.tmt);                                                                                 //終了時間
            vm.kaijonm = list2.Find(e => e.value == dto.kaijocd)!.label;                                                    //会場名
            vm.kikannm = string.IsNullOrEmpty(dto.kikancd) ? string.Empty : list3.Find(e => e.value == dto.kikancd)!.label; //医療機関名
            var staffnmList = staffids.Select(e => list4.Find(a => a.value == e)!.label).ToList();
            vm.staffnms = string.Join(DaStrPool.C_COMMA2, staffnmList);                                                     //担当者一覧

            return vm;
        }

        /// <summary>
        /// 結果一覧(予約情報：予約者一覧画面)取得
        /// </summary>
        public static List<RowVM> GetVMList(DataRow dr, List<object[]> nmList)
        {
            var list = new List<RowVM>();

            //1列目
            var vm = new RowVM();
            //定員(全体)
            var teiin = dr.CStr(nameof(tt_shkensinyoteiDto.teiin));
            //予約合計人数(全体)
            var ct1 = dr.CStr(nameof(KensinyoyakuView2.ct1));
            //キャンセル待ち人数(全体)
            var ct2 = dr.CStr(nameof(KensinyoyakuView2.ct2));
            vm.title = "計";                                        //タイトル
            vm.status = CmLogicUtil.GetYoyakuStatus(CInt(teiin), CInt(ct1));    //状態
            vm.teiin = teiin;                                //定員
            vm.moshikominum = ct1;                           //申込人数
            vm.taikinum = ct2;                               //待機数
            list.Add(vm);

            //2列目以降
            foreach (var row in nmList)
            {
                list.Add(GetVM(dr, row));
            }

            return list;
        }
        public static bool GetOverflg(DataRow dr, Enum編集区分 kbn)
        {
            //1列目
            //定員(全体)
            var teiin = dr.CInt(nameof(tt_shkensinyoteiDto.teiin));
            //予約合計人数(全体)
            var ct1 = dr.CInt(nameof(KensinyoyakuView2.ct1));
            //キャンセル待ち人数(全体)
            var ct2 = dr.CInt(nameof(KensinyoyakuView2.ct2));
            //予約済人数(全体)
            var ct3 = ct1 - ct2;
            //状態
            var status = CmLogicUtil.GetYoyakuStatus(teiin, ct3);
            if (status != CmLogicUtil.YOYAKUSTATUS1 && kbn == Enum編集区分.新規)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 結果一覧(定員オーバー検診)取得
        /// </summary>
        public static List<string> GetCheckVMList(DataRow dr, List<object[]> nmList)
        {
            var list = new List<string>();

            //2列目以降
            foreach (var row in nmList)
            {
                var cd = GetCd(dr, row);
                if (!string.IsNullOrEmpty(cd))
                {
                    list.Add(cd);
                }
            }

            return list;
        }

        /// <summary>
        /// 結果一覧(予約情報：予約者一覧画面)取得
        /// </summary>
        public static List<List<DataInfoVM>> GetVMList(DaDbContext db, DataRowCollection rows, List<string> keys, bool alertviewflg)
        {
            var list = new List<List<DataInfoVM>>();
            foreach (DataRow dr in rows)
            {
                list.Add(GetVM(db, dr, keys, alertviewflg));
            }

            return list;
        }

        /// <summary>
        /// 個人基本情報
        /// </summary>
        public static PersonVM GetVM(DaDbContext db, tt_afatenaDto dto, bool alertviewflg, bool adrsFlg)
        {
            var vm = (PersonVM)Common.Wraper.GetHeaderVM(db, new PersonVM(), dto, alertviewflg, adrsFlg);
            vm.kazeikbn_setai = DaNameService.GetName(db, EnumNmKbn.課税非課税区分, CStr(dto.kazeikbn_setai));              //課税非課税区分（世帯）
            vm.hokenkbn = DaNameService.GetName(db, EnumNmKbn.保険区分_共通管理, CStr(dto.hokenkbn));                       //保険区分
            vm.genmenkbn_tokutei = DaHanyoService.GetName(db, EnumHanyoKbn.減免区分_特定健診,
                                                            Enum名称区分.名称, CStr(dto.genmenkbn_tokutei));                //減免区分（特定健診）
            vm.genmenkbn_gan = DaHanyoService.GetName(db, EnumHanyoKbn.減免区分_がん検診,
                                                          Enum名称区分.名称, CStr(dto.genmenkbn_gan));                      //減免区分（がん検診）

            return vm;
        }

        /// <summary>
        /// 予約一覧取得
        /// </summary>
        public static List<DetailRowVM> GetVMList(DaDbContext db, List<DaSelectorModel> list1, List<tm_shkensinjigyoDto> dtl1, List<tm_afhanyoDto> dtl2,
                                                List<tt_shkensinkibosyasyosaiDto> dtl3, List<tt_shkensinyoteiDto> dtl4,
                                                List<tm_shyoyakujigyo_subDto> dtl5, List<tm_shnendoDto> dtl6, List<tt_kkhakkenDto> dtl9, List<tt_shkensinDto> dtl10,
                                                List<string> cdList, int nitteino, bool existB, bool existC, List<AWSH00404D.RowVM> signList, DataRowCollection rows)
        {
            var list = new List<DetailRowVM>();
            var vmList = GetVMList(rows);
            foreach (var kensin in list1)
            {
                list.Add(GetVM(db, kensin, dtl1, dtl2, dtl3, dtl4, dtl5, dtl6, dtl9, dtl10, cdList, nitteino, existB, existC, signList, vmList));
            }

            return list;
        }

        /// <summary>
        /// 自己負担金
        /// </summary>
        public static MoneyVM GetVM(List<AWSH00403D.RowVM> list)
        {
            var vm = new MoneyVM();

            if (list.Exists(e => e.jusinkingaku == AWSH00403D.Service.ERR_MSG))
            {
                vm.jusinkingaku = AWSH00403D.Service.ERR_MSG;                                   //受診金額
            }
            else
            {
                vm.jusinkingaku = CStr(list.Sum(e => CInt(e.jusinkingaku)));                    //受診金額
            }
            if (list.Exists(e => e.kingaku_sityosonhutan == AWSH00403D.Service.ERR_MSG))
            {
                vm.kingaku_sityosonhutan = AWSH00403D.Service.ERR_MSG;                          //（市区町村負担）金額
            }
            else
            {
                vm.kingaku_sityosonhutan = CStr(list.Sum(e => CInt(e.kingaku_sityosonhutan)));  //（市区町村負担）金額
            }

            return vm;
        }
        /// <summary>
        /// 予約情報(1行)
        /// </summary>
        private static DetailRowVM GetVM(DaDbContext db, DaSelectorModel kensin, List<tm_shkensinjigyoDto> dtl1, List<tm_afhanyoDto> dtl2,
                                                List<tt_shkensinkibosyasyosaiDto> dtl3, List<tt_shkensinyoteiDto> dtl4,
                                                List<tm_shyoyakujigyo_subDto> dtl5, List<tm_shnendoDto> dtl6, List<tt_kkhakkenDto> dtl9, List<tt_shkensinDto> dtl10,
                                                List<string> cdList, int nitteino, bool existB, bool existC, List<AWSH00404D.RowVM> signList, List<Row2VM> vmList)
        {
            var vm = new DetailRowVM();
            vm.jigyocd = kensin.value;  //検診種別
            vm.jigyonm = kensin.label;  //検診名

            //健（検）診予約希望者詳細テーブル
            var dto = dtl3.Find(e => e.jigyocd == vm.jigyocd);
            //検査方法一覧
            var dtl = new List<tm_afhanyoDto>();
            if (cdList.Contains(vm.jigyocd))
            {
                dtl = dtl2.Where(e => e.hanyosubcd == CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.検査方法, vm.jigyocd)).ToList();
            }
            //成人健（検）診予約日程事業サブマスタ
            var dtl7 = dtl5.Where(e => e.kensin_jigyocd == vm.jigyocd).ToList();

            //年度マスタ
            var dtl8 = dtl6.Where(e => e.jigyocd == vm.jigyocd).ToList();

            //検査方法一覧
            var vmList2 = vmList.Where(e => e.jigyocd == vm.jigyocd).ToList();

            //対象検査方法一覧
            var vmList3 = vmList2.Where(e => e.flg3).ToList();

            //予約画面チェック区分
            vm.yoyakuchk = dtl1.Find(e => e.jigyocd == vm.jigyocd)!.yoyakuchk;

            //対象サイン一覧
            var signList2 = signList.Where(e => e.jigyocd == vm.jigyocd).ToList();

            vm.selectorlist = new List<DaSelectorDisabledModelSign>();
            //検査方法がある場合
            if (cdList.Contains(vm.jigyocd))
            {
                vm.selectorlist = GetSelectorList(db, dtl, dtl7, dtl8, signList2, vmList3, vm.yoyakuchk);                            //検査方法一覧
            }

            //検査方法コード一覧(有効)
            var cdList2 = vm.selectorlist.Where(e => !e.disabled).Select(e => e.value).ToList();

            //検査方法コード一覧(有効、かつ、オプションではない)
            var cdList3 = dtl7.Where(e => !e.optionflg && cdList2.Contains(e.kensahohocd)).Select(e => e.kensahohocd).ToList();

            //予約データがある場合
            if (dto != null)
            {
                vm.nitteino = dto.nitteino;                                                             //日程番号
                vm.taikiflg = (dto.cancelmatiflg == Enum待機フラグ.希望する);                           //待機フラグ
                vm.syokaiuketukeymd = CStr(dto.syokaiuketukeymd);                                       //初回受付日
                vm.henkouketukeymd = CStr(dto.henkouketukeymd);                                         //受付変更日
                //検査方法がある場合
                if (cdList.Contains(vm.jigyocd))
                {
                    vm.kensahohocdnm = DaHanyoService.GetCdNm(dtl, Enum名称区分.名称, dto.kensahohocd); //検査方法(コード：名称)
                }
            }
            else if (cdList3.Count() > 0)
            {
                vm.nitteino = nitteino;                                                                 //日程番号
                vm.syokaiuketukeymd = FormatYMD(DaUtil.Today);                                          //初回受付日
                if (cdList3.Count() >= 1)
                {
                    vm.kensahohocdnm = DaHanyoService.GetCdNm(dtl, Enum名称区分.名称, cdList3[0]);      //検査方法(コード：名称)
                }
            }

            if (vm.nitteino != null)
            {
                //健（検）診予定テーブル
                var dto2 = dtl4.Find(e => e.nitteino == vm.nitteino)!;
                vm.yoteiymd = dto2.yoteiymd;                    //実施予定日
                vm.time = FormatTimeRange(dto2.tmf, dto2.tmt);  //時間範囲
            }
            //編集フラグ
            //false:①該当日程事業含まない検診
            vm.editflg = dtl7.Count() > 0;
            //検査方法がある場合
            if (cdList.Contains(vm.jigyocd) && vm.editflg)
            {
                //false:②検査方法全て対象外③受診済
                vm.editflg = cdList2.Count() > 0;
            }

            //生涯１回フラグ
            var syogaiikaiflg = dtl1.Find(e => e.jigyocd == vm.jigyocd)!.syogaiikaiflg;
 
            //状態
            vm.status = Getstatus(dtl, dtl10, vmList2, syogaiikaiflg, existB, existC);

            //クーポン表示区分
            var cuponhyojikbn = dtl1.Find(e => e.jigyocd == vm.jigyocd)!.cuponhyojikbn;
            if (cuponhyojikbn == Enum画面表示区分.表示)
            {
                //クーポン
                vm.cupon = dtl9.FindAll(e => e.hakkendatasyosaikbn.Substring(0, 2) == vm.jigyocd)?.OrderBy(e => e.tyusyututaisyocd).FirstOrDefault()?.tyusyututaisyocd ?? string.Empty;
            }
            else 
            {
                vm.cupon = string.Empty;
            }

            return vm;
        }
        /// <summary>
        /// 受診状態取得
        /// </summary>
        private static string Getstatus(List<tm_afhanyoDto> dtl, List<tt_shkensinDto> dtl10, List<Row2VM> vmList, bool syogaiikaiflg, bool existB, bool existC)
        {
            var list = new List<string>();
            //検査方法がある場合
            if (dtl.Count() > 0)
            {
                foreach (var dto in dtl)
                {
                    var shortnm = $"{DaStrPool.C_LEFT_BRACKET_HALF}{dto.shortnm}{DaStrPool.C_RIGHT_BRACKET_HALF}";

                    var vm = vmList.Find(e => e.kensahohocd == dto.hanyocd);
                    if (vm != null)
                    {
                        if (syogaiikaiflg)
                        {
                            //肝炎
                            if (vm.jigyocd == "02")
                            {
                                if (existB && existC)
                                {
                                    list.Add($"済");
                                }
                                else
                                {
                                    if (existB)
                                    {
                                        list.Add($"B済");
                                    }
                                    else if (existC)
                                    {
                                        list.Add($"C済");
                                    }
                                }
                            }
                            //肝炎以外
                            else
                            {
                                if (dtl10.Exists(e => e.jigyocd == vm.jigyocd && e.kensahohocd == vm.kensahohocd))
                                {
                                    list.Add($"済");
                                }
                            }
                        }
                        else
                        {
                            if (!vm.flg2)
                            {
                                list.Add($"受{shortnm}");
                            }
                            else if (!vm.flg1)
                            {
                                list.Add($"昨{shortnm}");
                            }
                        }
                    }
                }
            }
            //検査方法がない場合
            else if (vmList.Count() == 1)
            {
                var vm = vmList[0];
                if (syogaiikaiflg)
                {
                    //肝炎
                    if (vm.jigyocd == "02")
                    {
                        if (existB && existC)
                        {
                            list.Add($"済");
                        }
                        else
                        {
                            if (existB)
                            {
                                list.Add($"B済");
                            }
                            else if (existC)
                            {
                                list.Add($"C済");
                            }
                        }
                    }
                    //肝炎以外
                    else
                    {
                        if (dtl10.Exists(e => e.jigyocd == vm.jigyocd && e.kensahohocd == vm.kensahohocd))
                        {
                            list.Add($"済");
                        }
                    }
                }
                else
                {
                    if (!vm.flg2)
                    {
                        list.Add($"受");
                    }
                    else if (!vm.flg1)
                    {
                        list.Add($"昨");
                    }
                }
            }

            return string.Join(DaStrPool.C_COMMA2, list);
        }
        /// <summary>
        /// 対象検査方法一覧取得
        /// </summary>
        private static List<Row2VM> GetVMList(DataRowCollection rows)
        {
            var list = new List<Row2VM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(row));
            }

            return list;
        }

        /// <summary>
        /// 対象検査方法(1行)
        /// </summary>
        private static Row2VM GetVM(DataRow dr)
        {
            var vm = new Row2VM();
            vm.jigyocd = dr.Wrap(nameof(Row2VM.jigyocd));           //検診種別
            vm.kensahohocd = dr.Wrap(nameof(Row2VM.kensahohocd));   //検査方法コード
            vm.flg1 = dr.CBool(nameof(Row2VM.flg1));                //昨年フラグ(false:受診済)
            vm.flg2 = dr.CBool(nameof(Row2VM.flg2));                //今年フラグ(false:受診済)
            vm.flg3 = dr.CBool(nameof(Row2VM.flg3));                //対象フラグ(true:対象)

            return vm;
        }

        /// <summary>
        /// 検査方法一覧取得
        /// </summary>
        private static List<DaSelectorDisabledModelSign> GetSelectorList(DaDbContext db, List<tm_afhanyoDto> dtl1, List<tm_shyoyakujigyo_subDto> dtl2,
                                                                    List<tm_shnendoDto> dtl3, List<AWSH00404D.RowVM> signList, List<Row2VM> vmList, EnumMsgCtrlKbn yoyakuchk)
        {
            var list = new List<DaSelectorDisabledModelSign>();
            foreach (var dto in dtl1)
            {
                var vm = vmList.Find(e => e.kensahohocd == dto.hanyocd);

                //対象サイン
                var sign = signList?.Find(e => e.kensahohocd == dto.hanyocd)?.sign2;

                var flg3 = sign == DaNameService.GetName(db, EnumNmKbn.対象サイン, EnumToStr(Enum対象区分.対象));

                if (yoyakuchk != EnumMsgCtrlKbn.エラー || flg3) { 
                    list.Add(new DaSelectorDisabledModelSign(dto.hanyocd, dto.nm, sign, vm?.flg1, vm?.flg2, vm == null));
                }
            }

            return list;
        }

        /// <summary>
        /// 結果一覧(予約情報：予約者一覧画面)(1行)
        /// </summary>
        private static List<DataInfoVM> GetVM(DaDbContext db, DataRow dr, List<string> keys, bool alertviewflg)
        {
            var list = new List<DataInfoVM>();
            foreach (var key in keys)
            {
                var vm = new DataInfoVM();
                //項目物理名
                vm.key = key;
                switch (key)
                {
                    //生年月日
                    case nameof(tt_afatenaDto.bymd):
                        //値
                        vm.value = CmLogicUtil.GetBymd(dr);
                        break;
                    //性別
                    case nameof(tt_afatenaDto.sex):
                        //値
                        vm.value = CmLogicUtil.GetSexByRow(db, dr);
                        break;
                    //年齢
                    case "age":
                        //値
                        vm.value = CmLogicUtil.GetAgeStr(dr, DaUtil.Today);
                        break;
                    //住民区分
                    case nameof(tt_afatenaDto.juminkbn):
                        //値
                        vm.value = CmLogicUtil.GetJuminkbn(db, dr);
                        break;
                    //警告内容
                    case nameof(tt_afatenaDto.siensotikbn):
                        //支援措置区分
                        var siensotikbn = dr.Wrap(key);
                        //値
                        vm.value = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);
                        break;
                    default:
                        if (key.StartsWith(KensinyoyakuView5.taikiflg))
                        {
                            //値
                            vm.value = CmLogicUtil.GetYoyakuStatus2(dr.Wrap(key));
                        }
                        else
                        {
                            //値
                            vm.value = dr.Wrap(key);
                        }
                        break;
                }
                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 結果一覧(予約情報：予約者一覧画面)(1行)
        /// </summary>
        private static RowVM GetVM(DataRow dr, object[] row)
        {
            var vm = new RowVM();

            var jigyocd = CStr(row[0]);         //検診種別
            var yoyakubunruicd = CStr(row[1]);  //予約分類コード
            var yoyakubunruinm = CStr(row[2]);  //予約分類名称

            var keycd = $"{jigyocd}{DaStrPool.UNDERLINE}{yoyakubunruicd}";
            //定員
            var teiin_kensin = dr.CStr($"{nameof(KensinyoyakuView3.ct3)}{DaStrPool.UNDERLINE}{keycd}");
            //予約申込人数
            var ct1_kensin = dr.CStr($"{nameof(KensinyoyakuView3.ct1)}{DaStrPool.UNDERLINE}{keycd}");
            //キャンセル待ち人数
            var ct2_kensin = dr.CStr($"{nameof(KensinyoyakuView3.ct2)}{DaStrPool.UNDERLINE}{keycd}");

            vm.title = yoyakubunruinm;                                          //タイトル
            vm.status = CmLogicUtil.GetYoyakuStatus(CInt(teiin_kensin), CInt(ct1_kensin));  //状態
            vm.teiin = teiin_kensin;                                     //定員
            vm.moshikominum = ct1_kensin;                                //申込人数
            vm.taikinum = ct2_kensin;                                    //待機数

            return vm;
        }

        /// <summary>
        /// 結果一覧(予約情報：日程一覧画面)(1行)
        /// </summary>
        private static List<DataInfoVM> GetVM(DataRow dr, List<string> keys, List<DaSelectorModel> list1,
                                                List<DaSelectorModel> list2, List<DaSelectorModel> list3)
        {
            var list = new List<DataInfoVM>();
            foreach (var key in keys)
            {
                var vm = new DataInfoVM();
                //項目物理名
                vm.key = key;
                switch (key)
                {
                    //列2
                    case "naiyo1":
                        //成人健（検）診予約日程事業名
                        var jigyocdnm = CStr(list1.Find(e => e.value == dr.Wrap(nameof(tt_shkensinyoteiDto.jigyocd)))?.label);
                        //時間
                        var timef = dr.Wrap(nameof(tt_shkensinyoteiDto.tmf));
                        var timet = dr.Wrap(nameof(tt_shkensinyoteiDto.tmt));
                        var time = FormatTimeRange(timef, timet);
                        //医療機関名
                        var kikancdnm = CStr(list3.Find(e => e.value == dr.Wrap(nameof(tt_shkensinyoteiDto.kikancd)))?.label);
                        //値
                        vm.value = $"{jigyocdnm}{Environment.NewLine}{time}{Environment.NewLine}{kikancdnm}";
                        break;
                    //列3
                    case "naiyo2":
                        //実施予定日
                        var yoteiymd = FormatWaKjYMD(dr.Wrap(nameof(tt_shkensinyoteiDto.yoteiymd)));
                        //会場名
                        var kaijocdnm = CStr(list2.Find(e => e.value == dr.Wrap(nameof(tt_shkensinyoteiDto.kaijocd)))?.label);
                        //担当者
                        var staffidnms = dr.Wrap(nameof(KensinyoyakustaffView.staffidnms));
                        //値
                        vm.value = $"{yoteiymd}{Environment.NewLine}{kaijocdnm}{Environment.NewLine}{staffidnms}";
                        break;
                    //列4
                    case "title":
                        //値
                        vm.value = $"状態{Environment.NewLine}申{DaStrPool.C_SLASH}定員{Environment.NewLine}待機";
                        break;
                    //定員(全体)
                    case nameof(tt_shkensinyoteiDto.teiin):
                        //定員(全体)
                        var teiin = dr.CStr(key);
                        //予約済人数(全体)
                        var ct1 = dr.CStr(nameof(KensinyoyakuView2.ct1));
                        //キャンセル待ち人数(全体)
                        var ct2 = dr.CStr(nameof(KensinyoyakuView2.ct2));
                        //値
                        if (!string.IsNullOrEmpty(teiin))
                        {
                            var status = CmLogicUtil.GetYoyakuStatus(CInt(teiin), CInt(ct1));
                            vm.value = $"{status}{Environment.NewLine}{CInt(ct1)}{DaStrPool.C_SLASH}{teiin}{Environment.NewLine}{ct2}";
                        }
                        break;
                    //日程番号
                    case nameof(tt_shkensinyoteiDto.nitteino):
                        //値
                        vm.value = dr.Wrap(key);
                        break;
                    default:
                        var keycd = vm.key.Replace(nameof(KensinyoyakuView3.naiyo), string.Empty);
                        //定員
                        var teiin_kensin = dr.CStr($"{nameof(KensinyoyakuView3.ct3)}{keycd}");
                        //予約申込人数
                        var ct1_kensin = dr.CStr($"{nameof(KensinyoyakuView3.ct1)}{keycd}");
                        //キャンセル待ち人数
                        var ct2_kensin = dr.CStr($"{nameof(KensinyoyakuView3.ct2)}{keycd}");
                        //値
                        if (!string.IsNullOrEmpty(teiin_kensin))
                        {
                            var status = CmLogicUtil.GetYoyakuStatus(CInt(teiin_kensin), CInt(ct1_kensin));
                            vm.value = $"{status}{Environment.NewLine}{CInt(ct1_kensin)}{DaStrPool.C_SLASH}{teiin_kensin}{Environment.NewLine}{ct2_kensin}";
                        }
                        break;
                }
                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 結果一覧(定員オーバー検診)(1行)
        /// </summary>
        private static string? GetCd(DataRow dr, object[] row)
        {
            var jigyocd = CStr(row[0]);         //検診種別
            var yoyakubunruicd = CStr(row[1]);  //予約分類コード

            var keycd = $"{jigyocd}{DaStrPool.UNDERLINE}{yoyakubunruicd}";
            //定員
            var teiin_kensin = dr.CInt($"{nameof(KensinyoyakuView3.ct3)}{DaStrPool.UNDERLINE}{keycd}");
            //予約申込人数
            var ct1_kensin = dr.CInt($"{nameof(KensinyoyakuView3.ct1)}{DaStrPool.UNDERLINE}{keycd}");
            //状態
            var status = CmLogicUtil.GetYoyakuStatus(teiin_kensin, ct1_kensin);
            if (status != CmLogicUtil.YOYAKUSTATUS1)
            {
                return jigyocd;
            }
            return null;
        }
    }
}