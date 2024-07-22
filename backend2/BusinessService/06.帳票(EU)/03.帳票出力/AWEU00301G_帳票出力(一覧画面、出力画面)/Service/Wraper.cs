// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using System.Globalization;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00301G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 利用目的
        /// </summary>
        private const int JYOKEN_ID = -5;

        /// <summary>
        /// 基准日
        /// </summary>
        private const int JYOKEN_TIME = -1;


        public const string Cアドレスシール = "0Z01";
        public const string Cはがき = "0Z02";
        public const string C宛名台帳 = "0Z03";
        public const string Cバーコード = "0Z04";
        public const string C件数表年齢 = "0Z05";
        public const string C件数表行政区 = "0Z06";

        /// <summary>
        /// 一覧画面検索処理
        /// </summary>
        public static List<ReportVM> GetReportVMList(DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(GetReportVM).ToList();
        }

        /// <summary>
        /// 一覧画面検索処理
        /// </summary>
        private static ReportVM GetReportVM(DataRow row)
        {
            var vm = new ReportVM();
            vm.rptid = row.Wrap(nameof(ReportVM.rptid));            //帳票ID
            vm.rptnm = row.Wrap(nameof(ReportVM.rptnm));            //帳票名
            vm.rptgroupnm = row.Wrap(nameof(ReportVM.rptgroupnm));  //帳票グループ名
            vm.rptbiko = row.ToNStr(nameof(ReportVM.rptbiko));      //帳票説明
            vm.regusernm = row.Wrap(nameof(ReportVM.regusernm));    //作成者
            vm.regdttm = row.CDate(nameof(ReportVM.regdttm));       //作成日時
            vm.rptgroupid = row.Wrap(nameof(ReportVM.rptgroupid));  //帳票グループID
            return vm;
        }

        /// <summary>
        /// 出力画面初期化処理
        /// </summary>
        public static List<KensakuJyokenInitVM> GetKensakuJyokenVMList(DaDbContext db, List<tm_eurptkensakuDto> rptkensakuDtl,
                                            out List<KensakuJyokenInitVM> kensakuJyokenVmList2)
        {

            var dsfilter = $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} and {nameof(tm_eudatasourcekensakuDto.jyokenid)} = ANY(@{nameof(tm_eudatasourcekensakuDto.jyokenid)})";
            //jyokenIDリスト
            var itemIdSet = rptkensakuDtl.Where(x => !string.IsNullOrEmpty(x.datasourceid) && x.jyokenid > 0)
                .Select(x => (x.jyokenid)).ToHashSet();
            //EUCテーブル項目マスタ
            var dsBunruiDts = db.tm_eudatasourcekensaku.SELECT.WHERE.ByFilter(dsfilter, rptkensakuDtl[0].datasourceid!, itemIdSet.ToArray() as object).GetDtoList();

            //検索条件リスト
            var kensakuJyokenVmList1 = new List<KensakuJyokenInitVM>();
            //検索条件以外リスト
            kensakuJyokenVmList2 = new List<KensakuJyokenInitVM>();

            //参照元データ
            var kanrekensaDic = new Dictionary<string, string>();
            foreach (var rptkensakuDto in rptkensakuDtl)
            {
                if(rptkensakuDto.mastercd == "999" && !string.IsNullOrEmpty(rptkensakuDto.sansyomotosql))
                {
                    string pattern = @"\[(.*?)\]";
                    MatchCollection matches = Regex.Matches(rptkensakuDto.sansyomotosql, pattern);
                    if (matches.Count>0)
                    {
                        kanrekensaDic.Add(CStr(rptkensakuDto.jyokenid!), CStr(matches[0].Groups[1].Value));
                    }
                }
            }

            foreach (var rptkensakuDto in rptkensakuDtl)
            {
                if (rptkensakuDto.orderseq < 1000)
                {
                    //通常条件
                    kensakuJyokenVmList1.Add(GetKensakuJyokenVM(db, rptkensakuDto, dsBunruiDts, kanrekensaDic));
                }
                else
                {
                    //その他条件
                    kensakuJyokenVmList2.Add(GetKensakuJyokenVM(db, rptkensakuDto, dsBunruiDts, kanrekensaDic));
                }
            }

            return kensakuJyokenVmList1;
        }

        /// <summary>
        /// 出力画面検索処理
        /// </summary>
        public static List<AtenaVM> GetAtenaVMList(DaDbContext db, DataRowCollection rows, RptAuthVM authVm, string? publickey = null)
        {
            return rows.Cast<DataRow>().Select(x => GetAtenaVM(db, x, authVm, publickey)).ToList();
        }

        /// <summary>
        /// 出力画面検索処理
        /// </summary>
        private static AtenaVM GetAtenaVM(DaDbContext db, DataRow row, RptAuthVM authVm, string? publicKey = null)
        {
            var vm = new AtenaVM();

            //生年月日表記
            var bymdhyoki = row.Wrap(nameof(AtenaVM.bymdhyoki));
            bymdhyoki = row.CBool(nameof(tt_afatenaDto.bymd_fusyoflg)) ? bymdhyoki : DaFormatUtil.FormatWaKjYMD(bymdhyoki);

            vm.formflg = row.CBool(nameof(AtenaVM.formflg));                                                             //出力フラグ
            vm.atenano = row.Wrap(nameof(AtenaVM.atenano));                                                              //宛名番号
            vm.simei_yusen = row.Wrap(nameof(AtenaVM.simei_yusen));                                                      //氏名_優先
            vm.sex = CmLogicUtil.GetSexByRow(db, row);                                                                   //性別
            vm.bymdhyoki = bymdhyoki;                                                                                    //生年月日表記
            vm.gyoseikunm = row.Wrap(nameof(AtenaVM.gyoseikunm));                                                        //行政区
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                                                              //住民区分
            vm.taisyogairiyu = string.IsNullOrEmpty(row.Wrap(nameof(AtenaVM.taisyogairiyu))) ? string.Empty : "○";      //発行対象外者対象外理由
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));                                               //支援措置区分
            vm.warningtext = CmLogicUtil.GetKeikoku(db, siensotikbn, authVm.alertviewflg);                               //警告内容
            return vm;
        }

        /// <summary>
        /// 検索条件情報を取得
        /// </summary>
        public static KensakuJyokenInitVM GetKensakuJyokenVM(DaDbContext db, tm_eurptkensakuDto rptkensakuDto, List<tm_eudatasourcekensakuDto> dsBunruiDts, Dictionary<string, string> kanrekensaDic)
        {
            var vm = new KensakuJyokenInitVM();

            //コントロール区分
            Enumコントロール? controlkbn = Enum.TryParse<Enumコントロール>(rptkensakuDto.controlkbn?.ToString(), out var ck) ? ck : null;
            //帳票検索条件区分
            var jyokenkbn = Enum.TryParse<Enum検索条件区分>(rptkensakuDto.jyokenkbn, out var jk) ? jk : Enum検索条件区分.通常条件;
            //データ型
            var datatype = Enum.TryParse<EnumDataType>(rptkensakuDto.datatype?.ToString(), out var d) ? d : EnumDataType.文字列;

            var mastercd = string.Empty;
            var masterpara = string.Empty;

            vm.jyokenseq = rptkensakuDto.jyokenseq;             //条件シーケンス
            vm.jyokenid = rptkensakuDto.jyokenid;               //条件ID
            vm.jyokenkbn = jyokenkbn;                           //検索条件区分
            vm.jyokenlabel = CStr(rptkensakuDto.jyokenlabel);   //ラベル
            vm.hissuflg = CBool(rptkensakuDto.hissuflg);        //必須フラグ
            
            var dskensaku = dsBunruiDts.FirstOrDefault(rpt => rpt.datasourceid == rptkensakuDto.datasourceid && rpt.jyokenid == rptkensakuDto.jyokenid);
            if (dskensaku != null)
            {
                vm.sql = dskensaku.sql;                                //SQL
                vm.variables = CStr(dskensaku.variables);              //変数名
                vm.tablealias = CStr(dskensaku.tablealias);            //テーブル名
                vm.nendohanikbn = dskensaku.nendohanikbn;              //年度範囲区分
                vm.syokiti = dskensaku.syokiti;                        //初期値
                vm.controlkbn = dskensaku.controlkbn;                  //コントロール区分
                vm.datatype = dskensaku.datatype;                      //データ型
                mastercd = dskensaku.mastercd;
                masterpara = dskensaku.masterpara;
            }
            else 
            {
                vm.sql = CStr(rptkensakuDto.sql);                   //SQL
                vm.variables = CStr(rptkensakuDto.variables);       //変数名
                vm.tablealias = CStr(rptkensakuDto.tablealias);     //テーブル別名
                vm.controlkbn = controlkbn;                         //コントロール区分
                vm.datatype = datatype;                             //データ型
                vm.syokiti = CStr(rptkensakuDto.syokiti);           //初期値
                vm.nendohanikbn = CStr(rptkensakuDto.nendohanikbn); //年度範囲区分
                mastercd = rptkensakuDto.mastercd;
                masterpara = rptkensakuDto.masterpara;
            }

            if (controlkbn is Enumコントロール.選択 or Enumコントロール.複数選択)
            {
                //選択リスト(マスタ)
                vm.selectorlist = CommonUtil.GetSelectorList(db, mastercd, masterpara);

                var matchingKeys = kanrekensaDic.Where(kvp => kvp.Value == rptkensakuDto.jyokenlabel).Select(kvp => kvp.Key).ToList();
                if (matchingKeys.Count > 0)
                {
                    //参照先項目ID
                    vm.targetitemseq = string.Join(',', matchingKeys);
                }
            }

            //年度範囲
            if (controlkbn is Enumコントロール.年度 && !string.IsNullOrEmpty(vm.nendohanikbn))
            {
                (vm.nendo, vm.nendomax) = CommonUtil.GetNendoAndNendomax(db, vm.nendohanikbn); 
            }

            //if (jyokenkbn == Enum検索条件区分.固定条件 && !string.IsNullOrEmpty(vm.sql))
            //{
            //    //値(SQL)
            //    vm.value = GetValueFromSql(datatype, vm.sql);
            //}

            //利用目的
            if (jyokenkbn == Enum検索条件区分.通常条件 && JYOKEN_ID == rptkensakuDto.jyokenid && rptkensakuDto.orderseq >= 1000)
            {
                //選択リスト(利用目的)
                vm.selectorlist = GetHanyoSelectorList(db, EnumHanyoKbn.利用目的); 
            }

            // 基准日
            if (jyokenkbn == Enum検索条件区分.通常条件 && JYOKEN_TIME == rptkensakuDto.jyokenid && rptkensakuDto.orderseq >= 1000)
            {
                DateTime currentTime = DaUtil.Now;
                vm.value = currentTime;
            }

            return vm;
        }


        /// <summary>
        /// 様式一覧の取得
        /// </summary>
        public static List<YosikiInfo> GetYosikiInfoList(DaDbContext db, YosikiInfoRequest req, tm_eurptDto rpt,
                                        List<tm_euyosikiDto> yosikiDtl,List<tm_euyosikisyosaiDto> rptDetails, RptAuthVM authVM)
        {
            //様式一覧
            var infoList = new List<YosikiInfo>();
            foreach (var yosikiDto in yosikiDtl)
            {
                var info = new YosikiInfo();

                //更新フラグ
                info.updateflg = CBool(yosikiDto.updateflg);
                //帳票発行履歴管理フラグ
                info.hakoflg = CBool(yosikiDto.hakoflg);

                //帳票権限テーブル
                //if (authVm != null)
                //{
                //    //PDF出力フラグ
                //    info.pdfflg = CBool(yosikiDto.pdfflg) ? CBool(authVm.pdfoutflg) : false;
                //    //Excel出力フラグ
                //    info.excelflg = CBool(yosikiDto.excelflg) ? CBool(authVm.exceloutflg) : false;
                //    //その他出力フラグ
                //    info.otherflg = CBool(yosikiDto.otherflg) ? CBool(authVm.othersflg) : false;
                //    //通知書出力フラグ
                //    info.tutisyooutflg = CBool(yosikiDto.tutisyoflg) ? CBool(authVm.tutisyooutflg) : false;

                //}
                //else
                //{

                //}
                //特別様式の場合
                if (EucConstant.SPECIAL_YOSHIKI_ID_SET.Contains(yosikiDto.yosikiid))
                {
                    info.pdfflg = true;      //PDF出力フラグ
                    info.excelflg = true;    //Excel出力フラグ
                }
                //PDF出力フラグ
                info.pdfflg = CBool(yosikiDto.pdfflg);
                //Excel出力フラグ
                info.excelflg = CBool(yosikiDto.excelflg);
                //その他出力フラグ
                info.otherflg = CBool(yosikiDto.otherflg);
                //通知書出力フラグ
                info.tutisyooutflg = CBool(yosikiDto.tutisyoflg);
                var rptDetail = rptDetails.FirstOrDefault(e => e.yosikiid == yosikiDto.yosikiid);
                if (rptDetail != null)
                {
                    info.yosikiid = rptDetail.yosikiid;
                    info.yosikinm = rptDetail.yosikinm;
                    info.yosikisyubetu = rptDetail.yosikisyubetu;
                }

                infoList.Add(info);
            }

            if ((!rpt.tyusyutupanelflg && (string.IsNullOrEmpty(req.himozukevalue) || infoList.Count > 0))
                || (rpt.tyusyutupanelflg && (string.IsNullOrEmpty(req.tyusyutukbn) || infoList.Count > 0)))
            {
                var templateList = DaControlService.GetList(db, EnumCtrlKbn.テンプレート名);
                //固定様式
                var fixDic = new Dictionary<string, (bool,string)>
                {
                    { Cアドレスシール, (rpt.addresssealflg, "アドレスシール")  },
                    { Cバーコード, (rpt.barcodesealflg, "バーコードシール" ) },
                    { Cはがき, (rpt.hagakiflg, "はがき" ) },
                    { C宛名台帳, (rpt.atenadaityoflg, "宛名台帳" ) },
                    { C件数表年齢, ( rpt.kensuhyonenreiflg, "件数表(年齢別)" ) },
                    { C件数表行政区, (rpt.kensuhyogyoseikuflg, "件数表(行政区別)") }
                };

                foreach (var cd in fixDic.Keys)
                {
                    var obj = fixDic[cd];
                    if (obj.Item1)
                    {
                        //固定様式を取得する
                        infoList.Add(GetYosikiInfo(cd, obj.Item2, string.Empty, templateList));
                    }
                }

                //リストの順番をバリューによって並び替える
                infoList = infoList.OrderBy(item => item.yosikiid).ToList();
            } 
            return infoList;
        }

        /// <summary>
        /// 固定様式を取得する
        /// </summary>
        public static YosikiInfo GetYosikiInfo(string yosikiid, string yosikinm, string yosikisyubetu, List<tm_afctrlDtoEx> tm_afctrlDtoExList) 
        {
            var yosiki = new YosikiInfo
            {
                yosikiid = yosikiid, //様式ID
                yosikinm = yosikinm, //様式名
                otherflg = false,    //CSV出力フラグ
                pdfflg = true,       //PDF出力フラグ
                excelflg = true,     //Excel出力フラグ
                rirekiupdkbn = tm_afctrlDtoExList.Find(e => e.ctrlcd == yosikiid)!.value1         //発送履歴テーブル更新区分
            };
            return yosiki;
        }

        /// <summary>
        /// 出力画面初期化処理
        /// </summary>
        public static List<DetailJyokenInitVM>? GetDetailJyokenInitVMList(DaDbContext db, IEnumerable<tt_affilterDto>? detailJyokenDtl)
        {
            return detailJyokenDtl?.Select(x => GetDetailJyokenInitVM(db, x)).ToList();
        }

        /// <summary>
        /// 出力画面初期化処理
        /// </summary>
        private static DetailJyokenInitVM GetDetailJyokenInitVM(DaDbContext db, tt_affilterDto dto)
        {
            var vm = new DetailJyokenInitVM();
            vm.jyoseq = dto.jyoseq;                 //条件シーケンス
            vm.jyokbn = dto.jyokbn;                 //条件区分
            vm.hyojinm = dto.hyojinm;               //詳細条件表示名
            vm.placeholder = CStr(dto.placeholder); //入力説明
            vm.ctrltype = dto.ctrltype;             //コントローラータイプ
            vm.rangeflg = dto.rangeflg;             //範囲フラグ
            vm.komokunm1 = dto.komokunm1;           //項目物理名1
            switch (vm.ctrltype)
            {
                case Enumコントローラータイプ.年齢生年月日:
                    vm.manflg = CInt(dto.sethanyokbn1) == 1;                //男性フラグ
                    vm.womanflg = CInt(dto.sethanyokbn2) == 1;              //女性フラグ
                    vm.bothflg = vm is { manflg: true, womanflg: true };    //両方フラグ
                    vm.unknownflg = CInt(dto.sethanyokbn3) == 1;            //不明フラグ
                    break;
                case Enumコントローラータイプ.一覧選択:
                    //一覧選択リスト
                    vm.cdlist = CmLogicUtil.GetFilterCdList(db, dto, Enum名称区分.名称); 
                    break;
                case Enumコントローラータイプ.通用項目:
                    //通用項目区分
                    vm.itemkbn = Enum.TryParse<Enum項目区分>(dto.sethanyokbn1, out var itemkbn) ? itemkbn : Enum項目区分.文字; 
                    break;
                case Enumコントローラータイプ.参照ダイアログ:
                    var kbn = (Enum参照ダイアログ項目区分)CInt(dto.sethanyokbn1);
                    vm.searchitemkbn = kbn;  //参照ダイアログ項目区分
                    vm.cdlist = CmLogicUtil.GetSearchItemCdList(db, kbn, Enum名称区分.名称, new List<string>());      //一覧選択リスト
                    break;
                default:
                    throw new Exception("Enumコントローラータイプ error");
            }

            return vm;
        }

        /// <summary>
        /// SQL から値を取得
        /// </summary>
        private static string GetValueFromSql(EnumDataType dataType, string sql)
        {
            var formattedValue = sql.Split(DaStrPool.C_EQ, 2, StringSplitOptions.TrimEntries)[1];
            formattedValue = RemoveStartAndEndQuotes(formattedValue);
            return dataType switch
            {
                EnumDataType.整数 => int.TryParse(formattedValue, out var num) ? num.ToString() : 0.ToString(),
                EnumDataType.小数 => decimal.TryParse(formattedValue, out var num) ? num.ToString(CultureInfo.InvariantCulture) : 0.ToString(),
                EnumDataType.文字列 => formattedValue,
                EnumDataType.日付 => DateTime.TryParse(formattedValue, out var date) ? $"{date:yyyy-MM-dd}" : $"{DateTime.Today:yyyy-MM-dd}",
                EnumDataType.時間 => DateTime.TryParse(formattedValue, out var time) ? $"{time:yyyy-MM-dd HH:mm:ss}" : $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}",
                EnumDataType.フラグ => bool.TryParse(formattedValue, out var flag) ? flag.ToString() : false.ToString().ToLower(),
                _ => formattedValue
            };
        }

        /// <summary>
        /// 開始と終了のシングルクォートを削除
        /// </summary>
        private static string RemoveStartAndEndQuotes(string? str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            if(str.StartsWith(DaStrPool.C_SQT) && str.EndsWith(DaStrPool.C_SQT))
            {
                return str.Substring(1, Math.Max(0, str.Length - 2));
            }
            else
            {
                return str;
            }
        }

        /// <summary>
        /// 汎用マスタからドロップダウンリスト
        /// </summary>
        private static List<DaSelectorModel> GetHanyoSelectorList(DaDbContext db, EnumHanyoKbn kbn)
        {
            return DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(kbn)).ToList();
        }
    }
}