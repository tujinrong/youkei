// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ロジック共通関数
//
// 作成日　　: 2023.05.12
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using static BCC.Affect.DataAccess.DaCodeConst;
using BCC.Affect.Service.Common;
using Newtonsoft.Json;
using BCC.Affect.Service.AWAF00803G;
using BCC.Affect.Service.AWSH001;

namespace BCC.Affect.Service
{
    public static class CmLogicUtil
    {
        //予約状態
        public const string YOYAKUSTATUS1 = "空";
        public const string YOYAKUSTATUS2 = "満";
        public const string YOYAKUSTATUS3 = "超過";
        //基本事業保留個数(検診)
        public const int AWSH001_CT = 49;
        //拡張事業開始事業コード(検診)
        public const int AWSH001_ST = 50;
        //不詳表記
        private const string Fusyohyoki = "不詳";
        //警告非表示内容
        private const string NoAuthWarningtext = "＊＊＊＊＊＊＊＊＊＊";
        //警告内容
        private const string WarningtextPrefix = "支援措置対象者";
        //機能ID(検診固定頭)
        private const string AWSH001 = "AWSH001";
        //予約状態
        private const string YOYAKUSTATUS5 = "○";
        private const string YOYAKUSTATUS6 = "待";

        /// <summary>
        /// 個人番号(DB)取得
        /// </summary>
        /// <param name="personalno">個人番号(画面表示)</param>
        /// <returns></returns>
        public static string? GetPersonalnoDB(string? personalno)
        {
            if (!string.IsNullOrEmpty(personalno))
            {
                return DaEncryptUtil.RsaDecryptAndAesEncrypt(personalno);
            }
            return null;
        }

        /// <summary>
        /// 日付(不詳含む)表記取得
        /// </summary>
        /// <param name="fusyoflg">不詳フラグ</param>
        /// <param name="ymd">日付</param>
        /// <param name="fusyohyoki">不詳表記</param>
        /// <returns></returns>
        public static string GetYMDStr(bool? fusyoflg, string? ymd, string? fusyohyoki)
        {
            if (CBool(fusyoflg) || (fusyoflg == null && ymd == null) || ymd == null)
            {
                return CStr(fusyohyoki);
            }
            else if (DateTime.TryParse(ymd, out DateTime i))
            {
                return FormatWaKjYMD(CDate(ymd!));
            }
            else
            {
                return CStr(fusyohyoki);
            }
        }

        /// <summary>
        /// 年齢(不詳含む)表記取得
        /// </summary>
        /// <param name="row">データ行</param>
        /// <param name="kijunday">基準日</param>
        /// <returns></returns>
        public static string GetAgeStr(DataRow row, DateTime? kijunday = null)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = row.CNBool(nameof(tt_afatenaDto.bymd_fusyoflg));
            //生年月日
            var bymd = row.ToNStr(nameof(AtenaRowVM.bymd));
            return GetAgeStr(bymd_fusyoflg, bymd, kijunday);
        }

        /// <summary>
        /// 年齢(不詳含む)表記取得
        /// </summary>
        /// <param name="bymd_fusyoflg">生年月日不詳フラグ</param>
        /// <param name="bymd">生年月日</param>
        /// <param name="kijunymd">基準日</param>
        /// <returns></returns>
        public static string GetAgeStr(bool? bymd_fusyoflg, string? bymd, DateTime? kijunymd = null)
        {
            var age = GetAge(bymd_fusyoflg, bymd, kijunymd);
            if (age == null) return Fusyohyoki;
            return CInt(age).ToString();
        }

        /// <summary>
        /// 年齢(不詳含む)表記取得(○○か月)
        /// </summary>
        public static string GetAgeStr2(bool? bymd_fusyoflg, string? bymd, DateTime? kijunymd = null)
        {
            if (CBool(bymd_fusyoflg)) return Fusyohyoki;
            return kijunymd == null
                ? GetAgeStr(CDate(bymd!), DaUtil.Today)
                : GetAgeStr(CDate(bymd!), kijunymd.Value);
        }

        /// <summary>
        /// 年齢取得(○○か月)
        /// </summary>
        public static string GetAgeStr(DateTime bymd, DateTime kijunymd)
        {
            int years = kijunymd.Year - bymd.Year;
            int months = kijunymd.Month - bymd.Month;
            int days = kijunymd.Day - bymd.Day;
            if (days < 0)
            {
                months -= 1;
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }

            return $"{years}歳{months}か月";
        }

        /// <summary>
        /// 年齢取得
        /// </summary>
        /// <param name="bymd_fusyoflg">生年月日不詳フラグ</param>
        /// <param name="bymd">生年月日</param>
        /// <param name="kijunymd">基準日</param>
        /// <returns></returns>
        public static int? GetAge(bool? bymd_fusyoflg, string? bymd, DateTime? kijunymd = null)
        {
            if (CBool(bymd_fusyoflg)) return null;
            if (!DateTime.TryParse(bymd, out DateTime i)) return null;
            return kijunymd == null
                ? DaUtil.GetAge(CDate(bymd!))
                : DaUtil.GetAge(CDate(bymd!), kijunymd.Value);
        }

        /// <summary>
        /// 年齢計算基準日取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="nendo">年度</param>
        /// <param name="sex">性別</param>
        /// <param name="jigyocd">事業コード</param>
        /// <param name="kensahohocd">検査方法コード(一次)</param>
        /// <returns></returns>
        public static string GetNendoKijunymd(DaDbContext db, int nendo, Enum性別 sex, string jigyocd, string kensahohocd)
        {
            //検査方法なし事業一覧
            var cdList = db.tm_shkensinjigyo.SELECT.WHERE.ByFilter($"{nameof(tm_shkensinjigyoDto.kensahoho_setflg)} = @{nameof(tm_shkensinjigyoDto.kensahoho_setflg)}", false).
                            GetKeyList().Select(e => e[0]).Cast<string>().ToList();
            if (cdList.Contains(jigyocd))
            {
                kensahohocd = AWSH00301G.Service.KENSAHOHOCD;
            }
            if (string.IsNullOrEmpty(kensahohocd)) return string.Empty;
            //年度マスタ
            var dto = db.tm_shnendo.GetDtoByKey(nendo, jigyocd, kensahohocd);

            if (dto == null)
            {
                return string.Empty;
            }
            else
            {
                switch (sex)
                {
                    case Enum性別.男:
                    case Enum性別.女:
                        if ((dto.kijunkbn == Enum年齢基準日区分.指定日) && (string.IsNullOrEmpty(dto.sex) || (dto.sex == EnumToStr(sex))))
                        {
                            return dto.kijunymd!;
                        }
                        break;
                    default:
                        if ((dto.kijunkbn == Enum年齢基準日区分.指定日) && (string.IsNullOrEmpty(dto.sex)))
                        {
                            return dto.kijunymd!;
                        }
                        break;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 年度範囲チェック
        /// </summary>
        public static bool CheckNendo(int nendo, DateTime day)
        {
            if ((day.Year == nendo && day.Month > 3) || (day.Year == nendo + 1 && day.Month < 4))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 一覧警告内容取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="siensotikbn">支援措置区分</param>
        /// <param name="alertviewflg">警告参照フラグ</param>
        /// <returns></returns>
        public static string GetKeikoku(DaDbContext db, string? siensotikbn, bool alertviewflg)
        {
            var str = string.Empty;
            if (!string.IsNullOrEmpty(siensotikbn))
            {
                str = alertviewflg
                    ? $"{WarningtextPrefix}{C_LEFT_BRACKET_FULL}{DaNameService.GetName(db, EnumNmKbn.支援措置区分, siensotikbn)}{C_RIGHT_BRACKET_FULL}"
                    : NoAuthWarningtext;
            }
            return str;
        }

        /// <summary>
        /// 行政区名称取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="gyoseikucd">行政区コード</param>
        /// <returns></returns>
        public static string GetGyoseiku(DaDbContext db, string? gyoseikucd)
        {
            //行政区の地区区分
            var dtl = DaNameService.GetNameList(db, EnumNmKbn.地区区分);
            var dto = dtl.Find(e => CBool(e.hanyokbn1) && CBool(e.hanyokbn2));
            var tikukbn = dto!.nmcd;

            //地区マスタから取得
            var mstDtl = db.tm_aftiku.SELECT.WHERE.ByKey(tikukbn).GetDtoList();

            return GetGyoseiku((Enum地区区分)CInt(tikukbn), mstDtl, gyoseikucd);
        }

        /// <summary>
        /// 行政区名称取得
        /// </summary>
        public static string GetGyoseikuNm(DaDbContext db, string? gyoseikucd)
        {
            var cdnm = GetGyoseiku(db, gyoseikucd);

            if (string.IsNullOrEmpty(cdnm))
            {
                return string.Empty;
            }
            return cdnm.Split(DaConst.SELECTOR_DELIMITER)[1];
        }

        /// <summary>
        /// 行政区名称取得
        /// </summary>
        public static string GetGyoseikuNm(DaDbContext db, DataRow row)
        {
            //行政区コード
            var gyoseikucd = row.Wrap(nameof(tt_afatenaDto.gyoseikucd));
            //行政区名称
            return GetGyoseikuNm(db, gyoseikucd);
        }

        /// <summary>
        /// 住民区分取得
        /// </summary>
        public static string GetJuminkbn(DaDbContext db, DataRow row)
        {
            var juminkbn = row.Wrap(nameof(tt_afatenaDto.juminkbn));
            return DaNameService.GetName(db, EnumNmKbn.住民区分, juminkbn);
        }

        /// <summary>
        /// 性別取得
        /// </summary>
        public static string GetSexByRow(DaDbContext db, DataRow row)
        {
            var sex = row.Wrap(nameof(tt_afatenaDto.sex));
            return DaNameService.GetName(db, EnumNmKbn.性別_システム共有, sex);
        }

        /// <summary>
        /// 性別取得
        /// </summary>
        public static string GetSex(DaDbContext db, string sex)
        {
            if (string.IsNullOrEmpty(sex))
            {
                return string.Empty;
            }
            return DaNameService.GetName(db, EnumNmKbn.性別_システム共有, sex);
        }

        /// <summary>
        /// 住所取得
        /// </summary>
        public static string GetAdrs(Enum住登区分 jutokbn, string adrs1, string? adrs2, bool adrsFlg)
        {
            //住登区分により表示パターンが異なる
            switch (jutokbn)
            {
                case Enum住登区分.住民:
                    //住所
                    if (adrsFlg)
                    {
                        return $"{adrs1}{adrs2}";
                    }
                    return CStr(adrs2);
                case Enum住登区分.住登外:
                    //住所
                    return $"{adrs1}{adrs2}";
                default: throw new ArgumentException("Enum住登区分 error");
            }
        }

        /// <summary>
        /// 住所取得
        /// </summary>
        public static string GetAdrs(DataRow row, bool adrsFlg)
        {
            var adrs1 = row.Wrap(nameof(tt_afatenaDto.adrs1));                      //住所1
            var adrs2 = row.Wrap(nameof(tt_afatenaDto.adrs2));                      //住所2
            var jutokbn = (Enum住登区分)row.CInt(nameof(tt_afatenaDto.jutokbn));    //住登区分
            return GetAdrs(jutokbn, adrs1, adrs2, adrsFlg);
        }

        /// <summary>
        /// 生年月日表記取得
        /// </summary>
        public static string GetBymd(DataRow row)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = row.CNBool(nameof(tt_afatenaDto.bymd_fusyoflg));
            //生年月日
            var bymd = row.ToNStr(nameof(AtenaRowVM.bymd));
            //生年月日_不詳表記
            var bymd_fusyohyoki = row.Wrap(nameof(tt_afatenaDto.bymd_fusyohyoki));

            return GetYMDStr(bymd_fusyoflg, bymd, bymd_fusyohyoki);
        }

        /// <summary>
        /// 世帯主宛名番号取得
        /// </summary>
        public static string GetSetainushi(DaDbContext db, string setaino)
        {
            //世帯成員一覧取得
            var dtl = db.tt_afatena.SELECT.WHERE.ByItem(nameof(tt_afatenaDto.setaino), setaino).GetDtoList().
                            OrderBy(e => CIntJuminjotaiSort(e.juminjotai)). //住民状態
                            ThenBy(e => e.jutokbn).                         //住登区分
                            ThenBy(e => e.zokucd1).                         //続柄コード1
                            ThenBy(e => e.zokucd2).                         //続柄コード2
                            ThenBy(e => e.zokucd3).                         //続柄コード3
                            ThenBy(e => e.zokucd4).                         //続柄コード4
                            ThenBy(e => e.bymd).                            //生年月日
                            ThenBy(e => e.atenano).                         //宛名番号
                            ToList();

            return GetSetainushi(dtl);
        }

        /// <summary>
        /// 世帯主宛名番号取得
        /// </summary>
        public static string GetSetainushi(List<tt_afatenaDto> dtl)
        {
            //世帯主コード
            var cd = 名称マスタ.標準版.続柄._02;
            //世帯主の宛名番号取得
            var atenano = dtl.Where(x => x.zokucd1 == cd || x.zokucd2 == cd || x.zokucd3 == cd || x.zokucd4 == cd)?.FirstOrDefault()?.atenano ?? string.Empty;

            return atenano;
        }

        /// <summary>
        /// 個人番号存在フラグ取得
        /// </summary>
        public static bool GetPersonalnoFlg(DaDbContext db, string atenano)
        {
            var dto = db.tt_afatena.GetDtoByKey(atenano);
            return !string.IsNullOrEmpty(dto?.personalno);
        }

        /// <summary>
        /// 警告参照フラグ取得
        /// </summary>
        public static bool GetAlertviewflg(DaDbContext db, string token, string userid, string? regsisyo)
        {
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);
            return dto.alertviewflg;
        }

        /// <summary>
        /// 更新可能支所一覧取得
        /// </summary>
        public static List<string> GetSisyoList(DaDbContext db, string token, string userid, string? regsisyo)
        {
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);
            return GetSisyoList(dto);
        }

        /// <summary>
        /// 個人番号権限フラグ取得
        /// </summary>
        public static bool GetPersonalflg(DaDbContext db, string token, string userid, string? regsisyo, string kinoid)
        {
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);
            var list = GetAuthList(dto);
            return GetPersonalflg(list, kinoid);
        }

        /// <summary>
        /// 画面権限一覧取得
        /// </summary>
        public static List<GamenModel> GetAuthList(DaDbContext db, string token, string userid, string? regsisyo)
        {
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);
            return GetAuthList(dto);
        }

        /// <summary>
        /// 権限取得
        /// </summary>
        public static CmAuthVM GetAuthVM(DaDbContext db, string token, string userid, string? regsisyo, string kinoid)
        {
            var vm = new CmAuthVM();
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);
            vm.alertviewflg = dto.alertviewflg;
            vm.editSisyos = GetSisyoList(dto);
            var list = GetAuthList(dto);
            vm.personalflg = GetPersonalflg(list, kinoid);

            return vm;
        }

        /// <summary>
        /// EXCEL出力フラグ取得
        /// </summary>
        public static bool GetExceloutflg(DaDbContext db, string token, string userid, string? regsisyo, string kinoid)
        {
            tt_afauthreportDto dto = GetRptAuth(db, token, userid, regsisyo, kinoid);

            return CBool(dto?.exceloutflg);
        }

        /// <summary>
        /// CSV出力フラグ取得
        /// </summary>
        public static bool GetCsvoutflg(DaDbContext db, string token, string userid, string? regsisyo, string kinoid)
        {
            tt_afauthreportDto dto = GetRptAuth(db, token, userid, regsisyo, kinoid);

            return CBool(dto?.othersflg);
        }

        /// <summary>
        /// 帳票権限取得
        /// </summary>
        public static tt_afauthreportDto GetRptAuth(DaDbContext db, string token, string userid, string? regsisyo, string kinoid)
        {
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);

            var roleid = userid;
            if (dto.rolekbn == Enumロール区分.所属)
            {
                roleid = dto.syozokucd!;
            }

            return db.tt_afauthreport.GetDtoByKey(EnumToStr(dto.rolekbn), roleid, GetRptGroupID(db, kinoid));
        }

        /// <summary>
        /// 個人番号操作権限付与フラグ(ログインユーザー)取得
        /// </summary>
        public static bool GetPnoeditflg(DaDbContext db, string token, string userid, string? regsisyo)
        {
            tt_aftokenDto dto = GetDto(db, token, userid, regsisyo);
            return dto.pnoeditflg;
        }

        /// <summary>
        /// 事業コード一覧を取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="kbn">事業コード区分</param>
        /// <param name="kinoid">機能ID</param>
        /// <param name="no">画面選択の場合のみ</param>
        /// <returns></returns>
        public static List<string> GetJigyocdList(DaDbContext db, Enum事業コード区分 kbn, string kinoid, string? no, bool hasStopFlg)
        {
            //集約コードパターンEnum
            var kbn2 = GetPatternEnum(kinoid);
            //集約コードパターンNo
            int? patternno = no == null ? null : GetPatternno(kinoid, no);

            return GetJigyocdList(db, kbn, kinoid, kbn2, patternno, hasStopFlg);
        }

        /// <summary>
        /// 事業コード一覧を取得
        /// </summary>
        /// <param name="db"></param>
        /// <param name="kbn">事業コード区分</param>
        /// <param name="kinoid">機能ID</param>
        /// <param name="kbn2">取得パターン：DB設定(1);画面選択(2)</param>
        /// <param name="patternno">パターンNo.：画面選択の場合のみ</param>
        /// <returns></returns>
        public static List<string> GetJigyocdList(DaDbContext db, Enum事業コード区分 kbn, string kinoid, Enum事業コードパターン kbn2, int? patternno, bool hasStopFlg)
        {
            var list = GetJigyocdSelectorList(db, kbn, kinoid, Enum名称区分.名称, kbn2, patternno, hasStopFlg);
            return list.Select(e => e.value).ToList();
        }
        /// <summary>
        /// パターンNoを取得
        /// </summary>
        /// <param name="kinoid">機能ID</param>
        /// <param name="no">画面選択</param>
        /// <returns></returns>
        public static int GetPatternno(string kinoid, string no)
        {
            switch (kinoid)
            {
                //保健指導管理
                case "AWKK00301G":
                //集団指導管理
                case "AWKK00303G":
                    //modify by zhang 20240604 begin
                    //switch (no)
                    switch (no.PadLeft(2, '0'))
                    //modify by zhang 20240604 end
                    {
                        case 名称マスタ.システム.拡張_予約_保健指導業務区分._01:
                        case 名称マスタ.システム.拡張_予約_保健指導業務区分._02:
                            return CInt(no);
                        default:
                            throw new Exception("集約コードパターン error");
                    }
                //妊産婦情報管理
                case "AWBH00301G":
                //乳幼児情報管理
                case "AWBH00401G":
                //予防接種情報管理
                case "AWYS00101G":
                    return CInt(no);
                default:
                    throw new Exception("集約コードパターン設定の機能ID error");
            }
        }

        /// <summary>
        /// 事業コード一覧を取得
        /// </summary>
        public static List<DaSelectorModel> GetJigyocdSelectorList(DaDbContext db, Enum事業コード区分 kbn, string kinoid, Enum名称区分 kbn2, string? no, bool hasStopFlg)
        {
            //集約コードパターンEnum
            var kbn3 = GetPatternEnum(kinoid);
            //集約コードパターンNo
            int? patternno = no == null ? null : GetPatternno(kinoid, no);

            return GetJigyocdSelectorList(db, kbn, kinoid, kbn2, kbn3, patternno, false);
        }

        /// <summary>
        /// 事業コード一覧を取得
        /// </summary>
        public static List<DaSelectorModel> GetJigyocdSelectorList(DaDbContext db, Enum事業コード区分 kbn, string kinoid, Enum名称区分 kbn2, Enum事業コードパターン kbn3, int? patternno, bool hasStopFlg)
        {
            //汎用コードを取得
            var code = kinoid;
            if (kbn3 == Enum事業コードパターン.画面選択)
            {
                code = $"{code}{C_DASHED}{patternno}";
            }

            switch (kbn)
            {
                case Enum事業コード区分.メモ:
                    return GetJigyocdSelectorList(db, code, EnumHanyoKbn.メモ事業コード管理, EnumHanyoKbn.メモ事業コード, Enum事業コード取得方法.集約区分, kbn2, hasStopFlg);
                case Enum事業コード区分.電子ファイル:
                    return GetJigyocdSelectorList(db, code, EnumHanyoKbn.電子ファイル事業コード管理, EnumHanyoKbn.電子ファイル事業コード, Enum事業コード取得方法.集約区分, kbn2, hasStopFlg);
                case Enum事業コード区分.医療機関:
                    return GetJigyocdSelectorList(db, code, EnumHanyoKbn.医療機関事業コード管理, EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード, Enum事業コード取得方法.事業コード, kbn2, hasStopFlg);
                case Enum事業コード区分.事業従事者:
                    return GetJigyocdSelectorList(db, code, EnumHanyoKbn.事業従事者事業コード管理, EnumHanyoKbn.医療機関_事業従事者_担当者_事業コード, Enum事業コード取得方法.事業コード, kbn2, hasStopFlg);
                case Enum事業コード区分.連絡先:
                    return GetJigyocdSelectorList(db, code, EnumHanyoKbn.連絡先事業コード管理, EnumHanyoKbn.連絡先用事業コード, Enum事業コード取得方法.集約区分, kbn2, hasStopFlg);
                case Enum事業コード区分.フォロー事業:
                    return GetJigyocdSelectorList(db, code, EnumHanyoKbn.フォロー事業コード管理, EnumHanyoKbn.フォロー把握事業コード, Enum事業コード取得方法.集約区分, kbn2, hasStopFlg);

                default:
                    throw new Exception("Enum事業コード区分 error");
            }
        }

        /// <summary>
        /// 連絡先の事業コード取得
        /// </summary>
        public static string GetRenrakujigyocd(DaDbContext db, string kinoid)
        {
            //利用事業コード
            return GetJigyocdSelectorList(db, Enum事業コード区分.連絡先, kinoid, Enum名称区分.名称, Enum事業コードパターン.DB設定, null, false)![0].value;
        }

        /// <summary>
        /// 検索パラメータ取得(ドロップダウンリストのコード)
        /// </summary>
        public static string? GetSearchPara(string? para)
        {
            return string.IsNullOrEmpty(para) ? null : DaSelectorService.GetCd(para);
        }

        /// <summary>
        /// 住民状態取得(ソート用)
        /// </summary>
        public static int CIntJuminjotaiSort(string juminjotai)
        {
            var kbn = CInt(juminjotai);
            if (kbn == 1)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// 計算処理(数式)
        /// </summary>
        public static double Calculate(string keisansusiki)
        {
            DataTable table = new DataTable();
            table.Columns.Add("keisansusiki", typeof(string), keisansusiki);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["keisansusiki"]);
        }

        /// <summary>
        /// 計算処理(数式計算)
        /// </summary>
        /// <param name="keisansusiki">数式</param>
        /// <param name="paralist">パラメータリスト</param>
        /// <param name="valuelist">引数入力値</param>
        /// <returns></returns>
        public static double KensinCalculate1(string keisansusiki, List<string> paralist, List<KsKekkaItemVM> valuelist)
        {
            foreach (var paracd in paralist)
            {
                var val = valuelist.Find(e => e.itemcd == paracd)!.value;
                keisansusiki = keisansusiki.Replace($"{{{paracd}}}", val);
            }
            return Calculate(keisansusiki);
        }

        /// <summary>
        /// 計算処理(内部関数)
        /// </summary>
        /// <param name="keisankansuid">関数ID</param>
        /// <param name="paralist">パラメータリスト</param>
        /// <param name="valuelist">引数入力値</param>
        /// <returns></returns>
        public static double KensinCalculate2(DaDbContext db, string keisankansuid, List<string> paralist, List<KsKekkaItemVM> valuelist)
        {
            //関数内部区分を取得
            var kbn = DaNameService.GetKbn2(db, EnumNmKbn.計算関数_内部, keisankansuid);
            //todo 各関数使うロジックswitch=>暫定なし

            return 0;
        }

        /// <summary>
        /// 計算処理(DB関数)：性能向上のため、一旦保留
        /// </summary>
        /// <param name="keisankansuid">関数ID</param>
        /// <param name="paralist">パラメータリスト</param>
        /// <param name="valuelist">引数入力値</param>
        /// <returns></returns>
        public static double KensinCalculate3(DaDbContext db, string keisankansuid, List<string> paralist, List<KsKekkaItemVM> valuelist)
        {
            //関数名を取得
            var kansunm = DaHanyoService.GetName(db, EnumHanyoKbn.計算関数_DB, Enum名称区分.名称, keisankansuid);
            var list = new List<object>();
            foreach (var paracd in paralist)
            {
                var val = valuelist.Find(e => e.itemcd == paracd)!.value;
                list.Add(val!);
            }

            return CDbl(DaDbUtil.GetProcedureValue(db, kansunm, list!));
        }

        /// <summary>
        /// 計算処理(DB関数)パラメータ取得
        /// </summary>
        /// <param name="keisankansuid">関数ID</param>
        /// <param name="paralist">パラメータリスト</param>
        /// <param name="valuelist">引数入力値</param>
        /// <returns></returns>
        public static ProcModel GetKensinCalculatePara(DaDbContext db, string keisankansuid, List<string> paralist, List<KsKekkaItemVM> valuelist)
        {
            //関数名を取得
            var kansunm = DaHanyoService.GetName(db, EnumHanyoKbn.計算関数_DB, Enum名称区分.名称, keisankansuid);
            var list = new List<object>();
            foreach (var paracd in paralist)
            {
                var val = valuelist.Find(e => e.itemcd == paracd)!.value;
                list.Add(val!);
            }

            return new ProcModel(kansunm, paralist);
        }

        /// <summary>
        /// 拡張事業：検診関連汎用マスタデータのサブコードを取得
        /// </summary>
        /// <param name="kbn">データ種類</param>
        /// <param name="jigyocd">事業コード</param>
        /// <returns></returns>
        public static int GetHanyoSubcd(Enum検診関連汎用マスタ区分 kbn, string jigyocd)
        {
            var ct = CInt(jigyocd);
            switch (kbn)
            {
                case Enum検診関連汎用マスタ区分.検査方法:
                    //標準
                    if (ct <= AWSH001_CT) return 210001 + 200 * (ct - 1);
                    //拡張
                    return 240001 + 200 * ct;

                case Enum検診関連汎用マスタ区分.予約分類:
                    //標準
                    if (ct <= AWSH001_CT) return 100 + CInt(jigyocd);
                    return 101 + CInt(jigyocd);
                case Enum検診関連汎用マスタ区分.グループ2:
                    //標準
                    if (ct <= AWSH001_CT) return 200 + CInt(jigyocd);
                    return 201 + CInt(jigyocd);

                default:
                    throw new Exception("Enum検診関連汎用マスタ区分 error");
            }
        }
        /// <summary>
        /// 拡張事業機能ID取得(検診)
        /// </summary>
        /// <param name="jigyocd">事業コード</param>
        /// <returns></returns>
        public static string GetKensinKinoid(string jigyocd)
        {
            //機能ID番号取得
            return $"{AWSH001}{jigyocd.PadLeft(2, '0')}G";
        }

        /// <summary>
        /// コード一覧取得(詳細条件)
        /// </summary>
        public static List<DaSelectorModel> GetFilterCdList(DaDbContext db, tt_affilterDto dto, Enum名称区分 nmkbn)
        {
            var kbn = (Enumマスタ区分)CInt(dto.sethanyokbn1);
            switch (kbn)
            {
                case Enumマスタ区分.名称マスタ:
                case Enumマスタ区分.汎用マスタ:
                    return GetCommonCdList(db, kbn, nmkbn, null, dto.sethanyokbn2!, dto.sethanyokbn3!);
                case Enumマスタ区分.ユーザーマスタ:
                case Enumマスタ区分.地区情報マスタ:
                    return GetCommonCdList(db, kbn, nmkbn, null, CStr(dto.sethanyokbn2));
                case Enumマスタ区分.所属グループマスタ:
                case Enumマスタ区分.会場情報マスタ:
                case Enumマスタ区分.医療機関マスタ:               //詳細条件制限なし
                case Enumマスタ区分.事業従事者担当者情報マスタ:   //詳細条件制限なし
                    return GetCommonCdList(db, kbn, nmkbn, null);
                //todo
                default:
                    throw new Exception("詳細条件設定のマスタ区分エラー");
            }
        }
        /// <summary>
        /// 一覧選択リスト(条件コード)
        /// </summary>
        public static List<DaSelectorModel> GetFreeItemCdList(DaDbContext db, Enum名称区分 nmkbn, Enum入力タイプ inputtype, Enum条件コード区分 kbn, params string[] keys)
        {
            switch (inputtype)
            {
                case Enum入力タイプ.コード_名称マスタ:
                    switch (kbn)
                    {
                        case Enum条件コード区分.コード1:
                            return DaNameService.GetSelectorList(db, EnumNmKbn.名称マスタメインコード, nmkbn);
                        case Enum条件コード区分.コード2:
                            if (keys.Length == 0)
                            {
                                return new List<DaSelectorModel>();
                            }
                            return DaSelectorService.GetSelectorList(db, nmkbn, Enumシステムマスタ区分.名称メインマスタ, keys);
                        case Enum条件コード区分.コード3:
                            return new List<DaSelectorModel>();
                        default:
                            throw new Exception("Enum条件コード区分 error");
                    }
                case Enum入力タイプ.コード_汎用マスタ:
                    switch (kbn)
                    {
                        case Enum条件コード区分.コード1:
                            return DaNameService.GetSelectorList(db, EnumNmKbn.汎用マスタメインコード, nmkbn);
                        case Enum条件コード区分.コード2:
                            if (keys.Length == 0)
                            {
                                return new List<DaSelectorModel>();
                            }
                            else if (keys.Length == 3 && CStr(keys[0]) == 名称マスタ.システム.名称マスタメインコード._3019)
                            {
                                //検診フリー項目の場合
                                var dtl = db.tm_afhanyo_main.SELECT.WHERE.ByKey(CStr(keys[0])).GetDtoList();
                                //成人健（検）診事業コード=>No.
                                var ct = CInt(keys[1]);
                                //グループID
                                var kensinKbn = (EnumKensinKbn)CInt(keys[2]);
                                int subcdMin = 230001;
                                int subcdMax = 270000;
                                //標準
                                if (ct <= AWSH001_CT)
                                {
                                    if (kensinKbn == EnumKensinKbn.一次)
                                    {
                                        subcdMin = 230001 + 200 * (ct - 1);
                                    }
                                    else
                                    {
                                        subcdMin = 240001 + 200 * (ct - 1);
                                    }
                                    subcdMax = subcdMin + 199;
                                }
                                //拡張
                                else
                                {
                                    if (kensinKbn == EnumKensinKbn.一次)
                                    {
                                        subcdMin = 250002 + 200 * (ct - AWSH001_ST - 1);
                                        subcdMax = subcdMin + 198;
                                    }
                                    else
                                    {
                                        subcdMin = 260001 + 200 * (ct - AWSH001_ST - 1);
                                        subcdMax = subcdMin + 199;
                                    }
                                }
                                dtl = dtl.Where(e => (e.hanyosubcd < 210001 && e.hanyosubcd > 270000) || (e.hanyosubcd >= subcdMin && e.hanyosubcd <= subcdMax)).ToList();
                                return dtl.Select(e =>
                                {
                                    string? name;
                                    switch (nmkbn)
                                    {
                                        case Enum名称区分.名称:
                                            name = e.hanyosubcdnm;
                                            break;
                                        case Enum名称区分.カナ:
                                            name = e.kananm;
                                            break;
                                        case Enum名称区分.略称:
                                            name = e.shortnm;
                                            break;
                                        default:
                                            throw new Exception("Enum名称区分 error");
                                    }
                                    return new DaSelectorModel(CStr(e.hanyosubcd), name);
                                }).ToList();
                            }
                            return DaSelectorService.GetSelectorList(db, nmkbn, Enumシステムマスタ区分.汎用メインマスタ, keys);
                        case Enum条件コード区分.コード3:
                            return new List<DaSelectorModel>();
                        default:
                            throw new Exception("Enum条件コード区分 error");
                    }
                case Enum入力タイプ.コード_ユーザーマスタ:
                    switch (kbn)
                    {
                        case Enum条件コード区分.コード1:
                            return DaSelectorService.GetSelectorList(db, nmkbn, Enumマスタ区分.所属グループマスタ);
                        case Enum条件コード区分.コード2:
                        case Enum条件コード区分.コード3:
                            return new List<DaSelectorModel>();
                        default:
                            throw new Exception("Enum条件コード区分 error");
                    }
                case Enum入力タイプ.コード_地区情報マスタ:
                    switch (kbn)
                    {
                        case Enum条件コード区分.コード1:
                            return DaNameService.GetSelectorList(db, EnumNmKbn.地区区分, nmkbn);
                        case Enum条件コード区分.コード2:
                        case Enum条件コード区分.コード3:
                            return new List<DaSelectorModel>();
                        default:
                            throw new Exception("Enum条件コード区分 error");
                    }
                case Enum入力タイプ.コード_所属グループマスタ:
                case Enum入力タイプ.コード_会場情報マスタ:
                case Enum入力タイプ.医療機関:
                case Enum入力タイプ.事業従事者:
                    switch (kbn)
                    {
                        case Enum条件コード区分.コード1:
                        case Enum条件コード区分.コード2:
                        case Enum条件コード区分.コード3:
                            return new List<DaSelectorModel>();
                        default:
                            throw new Exception("Enum条件コード区分 error");
                    }
                //todo
                default:
                    throw new Exception("Enum入力タイプ error");
            }
        }

        /// <summary>
        /// 参照画面項目一覧取得(詳細条件)
        /// </summary>
        public static List<DaSelectorModel> GetSearchItemCdList(DaDbContext db, Enum参照ダイアログ項目区分 kbn, Enum名称区分 nmkbn, List<string> keyList, bool hasStopFlg = false)
        {
            switch (kbn)
            {
                case Enum参照ダイアログ項目区分.宛名番号:
                    return new List<DaSelectorModel>();
                case Enum参照ダイアログ項目区分.医療機関:
                    return DaSelectorService.GetSelectorList(db, nmkbn, Enumマスタ区分.医療機関マスタ, hasStopFlg, CStr(ListToCommaStr(keyList)));
                case Enum参照ダイアログ項目区分.事業従事者:
                    return DaSelectorService.GetSelectorList(db, nmkbn, Enumマスタ区分.事業従事者担当者情報マスタ, hasStopFlg, CStr(ListToCommaStr(keyList)));
                case Enum参照ダイアログ項目区分.検診実施機関:
                    return DaSelectorService.GetSelectorList(db, nmkbn, Enumマスタ区分.医療機関マスタ_保険, hasStopFlg, CStr(ListToCommaStr(keyList)));
                default:
                    throw new Exception("詳細条件設定の参照ダイアログ項目区分エラー");
            }
        }

        /// <summary>
        /// 名称取得(項目)
        /// </summary>
        public static string GetFreeItemCdNm(DaDbContext db, string cd, Enumフリーマスタ分類 kbn, Enum入力タイプ inputtype,
                                                    string? codejoken1, string? codejoken2, string? codejoken3,
                                                    Enum名称区分 nmkbn, string kinoid, int? patternno)
        {
            var list = GetFreeItemCdList(db, nmkbn, kbn, inputtype, codejoken1, codejoken2, codejoken3, kinoid, patternno);
            var name = list.Find(e => e.value == cd);
            return GetCdNm(name, cd);
        }
        /// <summary>
        /// 名称取得(条件コード)リスト
        /// </summary>
        public static string?[] GetFreeItemCdNm(DaDbContext db, Enum名称区分 nmkbn, Enum入力タイプ inputtype, string? codejoken1, string? codejoken2, string? codejoken3)
        {
            var strs = new string?[3];
            if (!string.IsNullOrEmpty(codejoken1))
            {
                //コード条件1(コード：名称)
                strs[0] = GetFreeItemCdNm(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード1, codejoken1);
                if (!string.IsNullOrEmpty(codejoken2))
                {
                    //コード条件2(コード：名称)
                    strs[1] = GetFreeItemCdNm(db, Enum名称区分.名称, inputtype, Enum条件コード区分.コード2, codejoken2, codejoken1);
                }
            }
            return strs;
        }
        /// <summary>
        /// 詳細条件のコントローラータイプを取得
        /// </summary>
        public static Enumコントローラータイプ GetFreeKoumokuCtrltype(DaDbContext db, Enum入力タイプ inputtype)
        {
            var kbn = (Enumコントローラー分類)CInt(DaNameService.GetKbn3(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
            switch (kbn)
            {
                case Enumコントローラー分類.数値:
                case Enumコントローラー分類.日付:
                case Enumコントローラー分類.文字:
                    return Enumコントローラータイプ.通用項目;
                case Enumコントローラー分類.選択:
                    return Enumコントローラータイプ.一覧選択;
                case Enumコントローラー分類.検索:
                case Enumコントローラー分類.選択_検索:
                    return Enumコントローラータイプ.参照ダイアログ;
                default:
                    throw new Exception("Enumコントローラー分類 error");
            }
        }
        /// <summary>
        /// 詳細条件のコントローラータイプを取得
        /// </summary>
        public static bool GetFreeKoumokuRangeflg(DaDbContext db, Enum入力タイプ inputtype)
        {
            var kbn = (Enumコントローラー分類)CInt(DaNameService.GetKbn3(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
            switch (kbn)
            {
                case Enumコントローラー分類.数値:
                case Enumコントローラー分類.日付:
                    return true;
                case Enumコントローラー分類.文字:
                case Enumコントローラー分類.選択:
                case Enumコントローラー分類.検索:
                case Enumコントローラー分類.選択_検索:
                    return false;
                default:
                    throw new Exception("Enumコントローラー分類 error");
            }
        }
        /// <summary>
        /// 詳細条件のコントローラータイプを取得
        /// </summary>
        public static string GetFreeKoumokuSethanyokbn1(Enum入力タイプ inputtype, Enumコントローラータイプ ctrltype)
        {
            switch (ctrltype)
            {
                case Enumコントローラータイプ.通用項目:
                    return EnumToStr(GetSearchSetType(inputtype));
                case Enumコントローラータイプ.一覧選択:
                    return EnumToStr(GetMstKbn(inputtype));
                case Enumコントローラータイプ.参照ダイアログ:
                    return EnumToStr(GetSearchDialogSetType(inputtype));
                default:
                    throw new Exception("Enumコントローラータイプ error");
            }
        }
        /// <summary>
        /// フリー項目マスタ保存カラムのDB名を取得
        /// </summary>
        public static string GetFreeKoumokuNm(DaDbContext db, Enum入力タイプ inputtype, string strNm, string numNm)
        {
            var kbn = (Enum入力タイプ型)CInt(DaNameService.GetKbn1(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
            switch (kbn)
            {
                case Enum入力タイプ型.数値:
                    return numNm;
                case Enum入力タイプ型.文字:
                    return strNm;
                default:
                    throw new Exception("Enum入力タイプ型 error");
            }
        }
        /// <summary>
        /// フリー項目のデータ取得
        /// </summary>
        public static object?[] GetFreeValues(DaDbContext db, Enum入力タイプ inputtype, object? value)
        {
            var savekbn = (Enum入力値保存型)int.Parse(DaNameService.GetKbn1(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
            var inputkbn = (Enum画面項目入力)int.Parse(DaNameService.GetKbn3(db, EnumNmKbn.フリー項目データタイプ, EnumToStr(inputtype)));
            double? numvalue = null;
            string? strvalue = null;
            if (savekbn == Enum入力値保存型.数値)
            {
                numvalue = CDbl(value);
            }
            else
            {
                //ドロップダウンリストの場合、コード取得
                strvalue = (inputkbn == Enum画面項目入力.選択 || inputkbn == Enum画面項目入力.選択_検索)
                    ? DaSelectorService.GetCd(CStr(value))
                    : CStr(value);
            }
            return new object?[] { numvalue, strvalue };
        }
        /// <summary>
        /// 入力桁取得
        /// </summary>
        public static (int? keta1, int? keta2) GetKetas(string? keta)
        {
            //入力桁リスト取得
            var ketas = CommaStrToList(keta);
            int? keta1 = (ketas.Count > 0) ? CInt(ketas[0]) : null;                   //入力桁(整数)
            int? keta2 = (ketas.Count == 2) ? CInt(ketas[1]) : null;                  //入力桁(小数)

            return (keta1, keta2);
        }
        /// <summary>
        /// フリー項目初期設定(共通部分)
        /// </summary>
        public static FixFreeItemBaseVM GetFreeVM(DaDbContext db, FixFreeItemBaseVM vm, List<tm_afmeisyoDto> datatypes, Enumフリーマスタ分類 kbn,
                                                    string kinoid, int? patternno,
                                                    double? numvalue, string? strvalue, bool? fusyoflg,
                                                    string itemcd, string itemnm, string? groupid2, string? tani, string? keta, bool hissuflg,
                                                    string? hanif, string? hanit, bool inputflg, EnumMsgCtrlKbn msgkbn, string? biko, string? syokiti,
                                                    Enum入力タイプ inputtype, string? codejoken1, string? codejoken2, string? codejoken3)
        {
            vm.itemcd = itemcd;             //項目コード

            //項目名
            if (!string.IsNullOrEmpty(tani))
            {
                vm.itemnm = $"{itemnm}{C_LEFT_BRACKET_FULL}{tani}{C_RIGHT_BRACKET_FULL}";
            }
            else
            {
                vm.itemnm = itemnm;
            }
            vm.inputtypekbn = inputtype;    //入力タイプ区分
            var ketas = GetKetas(keta);
            vm.keta1 = ketas.keta1;         //入力桁(整数部/文字)
            vm.keta2 = ketas.keta2;         //入力桁(小数部)
            vm.hissuflg = hissuflg;         //必須フラグ
            vm.hanif = CStr(hanif);         //入力範囲（開始）
            vm.hanit = CStr(hanit);         //入力範囲（終了）
            vm.inputflg = inputflg;         //入力フラグ
            vm.msgkbn = msgkbn;             //メッセージ区分
            vm.biko = CStr(biko);           //備考

            //入力区分関連情報を取得
            var nmDto = datatypes.Find(x => x.nmcd == EnumToStr(inputtype))!;
            //保存型取得
            var savekbn = (Enum入力値保存型)CInt(nmDto.hanyokbn1!);

            vm.inputkbn = (Enum画面項目入力)CInt(nmDto.hanyokbn3!);   //画面項目入力区分

            //初期値
            if (!(string.IsNullOrEmpty(syokiti)) && (vm.inputkbn == Enum画面項目入力.選択))
            {
                vm.syokiti = GetFreeItemCdNm(db, syokiti!, kbn, inputtype, codejoken1, codejoken2, codejoken3, Enum名称区分.名称, kinoid, patternno);
            }
            else
            {
                vm.syokiti = CStr(syokiti);
            }

            //既存データがある場合
            if (numvalue != null || !(string.IsNullOrEmpty(strvalue)))
            {
                //値
                switch (savekbn)
                {
                    case Enum入力値保存型.数値:
                        vm.value = numvalue;
                        break;
                    case Enum入力値保存型.文字:
                        vm.value = strvalue;
                        if (vm.inputkbn == Enum画面項目入力.選択 || vm.inputkbn == Enum画面項目入力.選択_検索)
                        {
                            vm.value = GetFreeItemCdNm(db, strvalue!, kbn, inputtype, codejoken1, codejoken2, codejoken3, Enum名称区分.名称, kinoid, patternno);
                        }
                        break;
                    default:
                        throw new Exception("Enum入力値保存型 error");
                }
                vm.fusyoflg = fusyoflg; //不詳フラグ
            }

            //一覧選択リスト
            vm.cdlist = new List<DaSelectorModel>();
            if (vm.inputkbn == Enum画面項目入力.選択)
            {
                vm.cdlist = GetFreeItemCdList(db, Enum名称区分.名称, kbn, inputtype, codejoken1, codejoken2, codejoken3, kinoid, patternno);
            }

            //参照ダイアログ
            if (vm.inputkbn == Enum画面項目入力.選択_検索)
            {
                Enum参照ダイアログ項目区分 kbn2;
                switch (vm.inputtypekbn)
                {
                    case Enum入力タイプ.医療機関:
                        kbn2 = Enum参照ダイアログ項目区分.医療機関;
                        break;
                    case Enum入力タイプ.事業従事者:
                        kbn2 = Enum参照ダイアログ項目区分.事業従事者;
                        break;
                    case Enum入力タイプ.検診実施機関:
                        kbn2 = Enum参照ダイアログ項目区分.検診実施機関;
                        break;
                    default:
                        throw new Exception("Enum入力値保存型 error");
                }

                vm.cdlist = GetCdList(db, kinoid, CNStr(patternno), kbn2);
            }

            return vm;
        }
        /// <summary>
        /// 業務区分取得(基準値)
        /// </summary>
        public static Enum基準値業務区分 GetKijunGyomukbn(string gyomukbn)
        {
            switch (gyomukbn)
            {
                case 名称マスタ.システム.基準値業務区分._01:
                    return Enum基準値業務区分.成人保健;
                case 名称マスタ.システム.基準値業務区分._02:
                    return Enum基準値業務区分.母子保健;
                case 名称マスタ.システム.基準値業務区分._03:
                    return Enum基準値業務区分.予防接種;
                default:
                    throw new Exception("業務区分 error");
            }
        }
        /// <summary>
        /// 業務区分取得(拡張・予約・指導)
        /// </summary>
        public static Enum拡張予約指導業務区分 GetKakuYoyakuSidoGyomukbn(string gyomukbn)
        {
            switch (gyomukbn)
            {
                case 名称マスタ.システム.拡張_予約_保健指導業務区分._01:
                    return Enum拡張予約指導業務区分.成人保健;
                case 名称マスタ.システム.拡張_予約_保健指導業務区分._02:
                    return Enum拡張予約指導業務区分.母子保健;
                case 名称マスタ.システム.拡張_予約_保健指導業務区分._03:
                    return Enum拡張予約指導業務区分.予防接種;
                default:
                    throw new Exception("業務区分 error");
            }
        }
        /// <summary>
        /// 一覧選択リスト(項目)
        /// </summary>
        public static List<DaSelectorModel> GetFreeItemCdList(DaDbContext db, Enum名称区分 nmkbn, Enumフリーマスタ分類 freemstkbn,
                                                            Enum入力タイプ inputtype, string? codejoken1, string? codejoken2, string? codejoken3,
                                                            string kinoid, int? patternno)
        {
            List<string>? keyList1 = null;
            List<string>? keyList2 = null;
            switch (freemstkbn)
            {
                case Enumフリーマスタ分類.成人:
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, null, false);
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, null, false);
                    break;
                case Enumフリーマスタ分類.指導:
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.画面選択, patternno, false);
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.画面選択, patternno, false);
                    break;
                case Enumフリーマスタ分類.母子:
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, null, false);
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, null, false);
                    break;
                case Enumフリーマスタ分類.対象者抽出:
                    keyList1 = GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, null, false);
                    keyList2 = GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, null, false);
                    break;
                default:
                    throw new Exception("Enumフリーマスタ分類 error");
            }

            var kbn = GetMstKbn(inputtype);
            switch (kbn)
            {
                case Enumマスタ区分.名称マスタ:
                case Enumマスタ区分.汎用マスタ:
                    return GetCommonCdList(db, kbn, nmkbn, null, codejoken1!, codejoken2!);
                case Enumマスタ区分.ユーザーマスタ:
                case Enumマスタ区分.地区情報マスタ:
                    return GetCommonCdList(db, kbn, nmkbn, null, CStr(codejoken1));
                case Enumマスタ区分.所属グループマスタ:
                case Enumマスタ区分.会場情報マスタ:
                    return GetCommonCdList(db, kbn, nmkbn, null);
                case Enumマスタ区分.医療機関マスタ:
                case Enumマスタ区分.医療機関マスタ_保険:
                    return GetCommonCdList(db, kbn, nmkbn, keyList1);
                case Enumマスタ区分.事業従事者担当者情報マスタ:
                    return GetCommonCdList(db, kbn, nmkbn, keyList2);
                //todo
                default:
                    throw new Exception("フリー項目設定のマスタ区分エラー");
            }
        }
        /// <summary>
        /// 年齢範囲リスト取得
        /// </summary>
        public static HashSet<int> ParseAgeRanges(string? ageStr)
        {
            if (string.IsNullOrEmpty(ageStr)) return new HashSet<int>(0);
            var ranges = new HashSet<int>();
            foreach (var part in ageStr.Split(C_COMMA))
            {
                if (part.Contains(C_DASHED))
                {
                    var rangeParts = part.Split(C_DASHED);
                    var min = int.Parse(rangeParts[0]);
                    var max = int.Parse(rangeParts[1]);
                    for (var i = min; i <= max; i++)
                    {
                        ranges.Add(i);
                    }
                }
                else
                {
                    ranges.Add(int.Parse(part));
                }
            }
            return ranges;
        }

        /// <summary>
        /// 予約状態
        /// </summary>
        /// <param name="teiin">定員数</param>
        /// <param name="ct">申込人数</param>
        /// <returns></returns>
        public static string GetYoyakuStatus(int teiin, int ct)
        {
            var i = teiin - ct;
            if (i == 0)
            {
                return YOYAKUSTATUS2;
            }
            else if (i > 0)
            {
                return YOYAKUSTATUS1;
            }
            else
            {
                return YOYAKUSTATUS3;
            }
        }

        /// <summary>
        /// 予約状態
        /// </summary>
        public static string GetYoyakuStatus2(string taikiflg)
        {
            if (string.IsNullOrEmpty(taikiflg))
            {
                return string.Empty;
            }
            else if (taikiflg == 名称マスタ.標準版.キャンセル待ち._1)
            {
                return YOYAKUSTATUS5;
            }
            else
            {
                return YOYAKUSTATUS6;
            }
        }

        /// <summary>
        /// 名称取得(条件コード)
        /// </summary>
        private static string GetFreeItemCdNm(DaDbContext db, Enum名称区分 nmkbn, Enum入力タイプ inputtype, Enum条件コード区分 kbn, string cd, params string[] keys)
        {
            var list = GetFreeItemCdList(db, nmkbn, inputtype, kbn, keys);
            var name = list.Find(e => e.value == cd);
            return GetCdNm(name, cd);
        }
        /// <summary>
        /// 名称取得
        /// </summary>
        private static string GetCdNm(DaSelectorModel? model, string cd)
        {
            if (model == null) return $"{cd}{DaConst.SELECTOR_DELIMITER}";
            return $"{cd}{DaConst.SELECTOR_DELIMITER}{model.label}";
        }
        /// <summary>
        /// 行政区名称取得
        /// </summary>
        private static string GetGyoseiku(Enum地区区分 kbn, List<tm_aftikuDto> dtl, string? code)
        {
            if (string.IsNullOrEmpty(code)) return string.Empty;
            var dto = dtl.Find(e => e.tikukbn == kbn && e.tikucd == code);
            if (dto == null) return string.Empty;
            return $"{code}{DaConst.SELECTOR_DELIMITER}{dto!.tikunm}";
        }
        /// <summary>
        /// ログイン時権限データ取得
        /// </summary>
        private static tt_aftokenDto GetDto(DaDbContext db, string token, string userid, string? regsisyo)
        {
            long tokenseq = DaTokenService.GetTokenUD(token, userid, regsisyo);
            return db.tt_aftoken.GetDtoByKey(tokenseq);
        }
        /// <summary>
        /// 画面権限一覧取得
        /// </summary>
        private static List<GamenModel> GetAuthList(tt_aftokenDto dto)
        {
            var list = new List<GamenModel>();
            if (!string.IsNullOrEmpty(dto.gamenauth))
            {
                list = JsonConvert.DeserializeObject<List<GamenModel>>(dto.gamenauth)!;
            }
            return list;
        }
        /// <summary>
        /// 更新可能支所一覧取得
        /// </summary>
        private static List<string> GetSisyoList(tt_aftokenDto dto)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(dto.sisyocd))
            {
                list = dto.sisyocd.Split(COMMA).ToList();
            }
            return list;
        }
        /// <summary>
        /// 個人番号権限フラグ取得
        /// </summary>
        private static bool GetPersonalflg(List<GamenModel> list, string kinoid)
        {
            var auth = list?.Find(e => e.menuid == kinoid);
            if (auth != null)
            {
                return auth.personalnoflg;
            }
            return false;
        }
        /// <summary>
        /// 帳票権限グループID取得
        /// </summary>
        private static string GetRptGroupID(DaDbContext db, string kinoid)
        {
            //kinoidで帳票IDを取得
            var rptid = GetRptID(kinoid);
            //帳票IDで帳票権限グループIDを特定
            return db.tm_eurpt.GetDtoByKey(rptid).rptgroupid;
        }
        /// <summary>
        /// 帳票ID取得
        /// </summary>
        private static string GetRptID(string kinoid)
        {
            //todo euc
            //kinoidで

            return "0001";
        }
        /// <summary>
        /// 集約コード取得(事業コード)
        /// </summary>
        private static HashSet<string> GetCodeSet(DaDbContext db, string code, EnumHanyoKbn kbn)
        {
            //名称マスタから画面対応する集約コードを取得する
            var dto = DaHanyoService.GetHanyoDtl(db, kbn).Find(e => e.hanyocd == code);
            //集約コード一覧を取得
            if (dto != null && dto.hanyokbn1 != null)
            {
                return dto.hanyokbn1.Split(C_COMMA).ToHashSet();
            }

            return new HashSet<string>();
        }
        /// <summary>
        /// 事業コード一覧を取得
        /// </summary>
        private static List<DaSelectorModel> GetJigyocdSelectorList(DaDbContext db, string code, EnumHanyoKbn kbn1, EnumHanyoKbn kbn2, Enum事業コード取得方法 kbn3, Enum名称区分 kbn4, bool hasStopFlg)
        {
            //集約コード一覧を取得
            var codeSet = GetCodeSet(db, code, kbn1);
            //事業コード情報一覧
            var dtl = new List<tm_afhanyoDto>();
            switch (kbn3)
            {
                case Enum事業コード取得方法.集約区分:
                    dtl = hasStopFlg ? DaHanyoService.GetHanyoDtl(db, kbn2) : DaHanyoService.GetHanyoNoDelDtl(db, kbn2);
                    dtl = dtl.Where(x => codeSet.Contains(x.hanyokbn1!)).OrderBy(x => x.orderseq).ThenBy(x => x.hanyocd).ToList();
                    break;
                case Enum事業コード取得方法.事業コード:
                    dtl = hasStopFlg ? DaHanyoService.GetHanyoDtl(db, kbn2) : DaHanyoService.GetHanyoNoDelDtl(db, kbn2);
                    dtl = dtl.Where(x => codeSet.Contains(x.hanyocd)).OrderBy(x => x.orderseq).OrderBy(x => x.hanyocd).ToList();
                    break;
                default:
                    throw new Exception("Enum事業コード取得方法 error");
            }

            return DaHanyoService.GetSelectorList(dtl, kbn4);
        }

        /// <summary>
        /// マスタ区分取得
        /// </summary>
        private static Enumマスタ区分 GetMstKbn(Enum入力タイプ inputtype)
        {
            switch (inputtype)
            {
                case Enum入力タイプ.コード_名称マスタ:
                    return Enumマスタ区分.名称マスタ;
                case Enum入力タイプ.コード_汎用マスタ:
                    return Enumマスタ区分.汎用マスタ;
                case Enum入力タイプ.コード_ユーザーマスタ:
                    return Enumマスタ区分.ユーザーマスタ;
                case Enum入力タイプ.コード_所属グループマスタ:
                    return Enumマスタ区分.所属グループマスタ;
                case Enum入力タイプ.コード_地区情報マスタ:
                    return Enumマスタ区分.地区情報マスタ;
                case Enum入力タイプ.コード_会場情報マスタ:
                    return Enumマスタ区分.会場情報マスタ;
                case Enum入力タイプ.医療機関:
                    return Enumマスタ区分.医療機関マスタ;
                case Enum入力タイプ.事業従事者:
                    return Enumマスタ区分.事業従事者担当者情報マスタ;
                case Enum入力タイプ.検診実施機関:
                    return Enumマスタ区分.医療機関マスタ_保険;
                //todo
                default:
                    throw new Exception("Enum入力タイプ error");
            }
        }

        /// <summary>
        /// 参照ダイアログ区分取得
        /// </summary>
        private static Enum参照ダイアログ項目区分 GetSearchDialogSetType(Enum入力タイプ inputtype)
        {
            switch (inputtype)
            {
                case Enum入力タイプ.宛名番号:
                    return Enum参照ダイアログ項目区分.宛名番号;
                case Enum入力タイプ.医療機関:
                    return Enum参照ダイアログ項目区分.医療機関;
                case Enum入力タイプ.事業従事者:
                    return Enum参照ダイアログ項目区分.事業従事者;
                case Enum入力タイプ.検診実施機関:
                    return Enum参照ダイアログ項目区分.検診実施機関;
                //todo
                default:
                    throw new Exception("Enum入力タイプ error");
            }
        }
        /// <summary>
        /// コード一覧取得
        /// </summary>
        private static List<DaSelectorModel> GetCommonCdList(DaDbContext db, Enumマスタ区分 kbn, Enum名称区分 nmkbn, List<string>? keyList, params string[] keys)
        {
            switch (kbn)
            {
                case Enumマスタ区分.名称マスタ:
                case Enumマスタ区分.汎用マスタ:
                case Enumマスタ区分.所属グループマスタ:
                case Enumマスタ区分.会場情報マスタ:
                    return DaSelectorService.GetSelectorList(db, nmkbn, kbn, false, keys);
                case Enumマスタ区分.ユーザーマスタ:
                case Enumマスタ区分.地区情報マスタ:
                    if (!string.IsNullOrEmpty(keys[0]))
                    {
                        return DaSelectorService.GetSelectorList(db, nmkbn, kbn, false, keys);
                    }
                    return DaSelectorService.GetSelectorList(db, nmkbn, kbn);
                case Enumマスタ区分.医療機関マスタ:
                case Enumマスタ区分.医療機関マスタ_保険:
                case Enumマスタ区分.事業従事者担当者情報マスタ:
                    if (keyList != null)
                    {
                        return DaSelectorService.GetSelectorList(db, nmkbn, kbn, false, CStr(ListToCommaStr(keyList)));
                    }
                    return DaSelectorService.GetSelectorList(db, nmkbn, kbn);
                //todo
                default:
                    throw new Exception("Enumマスタ区分 error");
            }
        }
        /// <summary>
        /// 詳細条件項目区分取得
        /// </summary>
        private static Enum項目区分 GetSearchSetType(Enum入力タイプ inputtype)
        {
            switch (inputtype)
            {
                case Enum入力タイプ.数値_整数:
                case Enum入力タイプ.数値_小数点付き実数:
                case Enum入力タイプ.数値_符号付き整数:
                    return Enum項目区分.数字;
                case Enum入力タイプ.半角文字_半角数字:
                case Enum入力タイプ.半角文字_半角英数字:
                case Enum入力タイプ.半角文字_年:
                case Enum入力タイプ.半角文字_年_不詳あり:
                case Enum入力タイプ.半角文字_年月:
                case Enum入力タイプ.半角文字_年月_不詳あり:
                case Enum入力タイプ.半角文字_時刻:
                case Enum入力タイプ.半角文字_半角:
                case Enum入力タイプ.全角文字_全角_改行不可:
                case Enum入力タイプ.全角文字_全角_改行可:
                case Enum入力タイプ.全角半角文字_全角半角_改行不可:
                case Enum入力タイプ.全角半角文字_全角半角_改行可:
                    return Enum項目区分.文字;
                case Enum入力タイプ.日付_年月日:
                    return Enum項目区分.日付;
                case Enum入力タイプ.日付_年月日_不詳あり:
                    return Enum項目区分.日付不明;
                case Enum入力タイプ.日時_年月日時分秒:
                    return Enum項目区分.日時;
                default:
                    throw new Exception("Enum入力タイプ error");
            }
        }
        /// <summary>
        /// 事業コードパターンを取得
        /// </summary>
        /// <param name="kinoid">機能ID</param>
        /// <returns></returns>
        private static Enum事業コードパターン GetPatternEnum(string kinoid)
        {
            switch (kinoid)
            {
                //保健指導管理
                case "AWKK00301G":
                //集団指導管理
                case "AWKK00303G":
                    return Enum事業コードパターン.画面選択;
                default:
                    return Enum事業コードパターン.DB設定;
            }
        }

        /// <summary>
        /// 一覧選択リストを取得（参照ダイアログ項目用）
        /// </summary>
        public static List<DaSelectorModel> GetCdList(DaDbContext db, string kinoid, string? patternno, Enum参照ダイアログ項目区分 kbn, bool hasStopFlg = false)
        {
            //参照ダイアログ項目区分
            if (kbn == Enum参照ダイアログ項目区分.医療機関
                || kbn == Enum参照ダイアログ項目区分.事業従事者
                || kbn == Enum参照ダイアログ項目区分.検診実施機関)
            {
                //実施事業(表示範囲)
                List<string> keyList;
                keyList = GetJigyocdList(db, kbn == Enum参照ダイアログ項目区分.事業従事者 ?
                                        Enum事業コード区分.事業従事者 : Enum事業コード区分.医療機関, kinoid!, patternno, false);

                //参照画面項目一覧取得(詳細条件)
                return GetSearchItemCdList(db, kbn, Enum名称区分.名称, keyList, hasStopFlg);
            }

            return new List<DaSelectorModel>();
        }

        /// <summary>
        /// ユーザ領域コード最大値を取得
        /// </summary>
        public static int GetUserRyoikiMaxCd(int? keta)
        {
            var maxCd = 0;

            if (CInt(keta) > 0)
            {
                maxCd = (int)Math.Pow(10, CInt(keta)) - 1;
            }
            else
            {
                maxCd = int.MaxValue;
            }

            return maxCd;
        }
    }
}