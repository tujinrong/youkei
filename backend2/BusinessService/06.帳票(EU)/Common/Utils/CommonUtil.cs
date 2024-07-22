// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//             共通ツール
// 作成日　　: 2023.10.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using AIplus.AiReport.Models;
using BCC.Affect.Service.AWAF00703D;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Org.BouncyCastle.Ocsp;
using System.Collections;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.Common;

public static class CommonUtil
{
    /// <summary>
    /// EUCドロップダウンリスト
    /// </summary>
    public static List<DaSelectorModel> GetSelectorList(DaDbContext db, string? mastercd, string? masterpara)
    {
        if (mastercd == "999") return new List<DaSelectorModel>();

        var tableItemNameDto = DaEucBasicService.GetTableItemNameDtoByMastercd(db, mastercd);
        if (tableItemNameDto == null) return new List<DaSelectorModel>();
        if ((!string.IsNullOrEmpty(tableItemNameDto.maincd) || !string.IsNullOrEmpty(tableItemNameDto.subcd)) && string.IsNullOrEmpty(masterpara)) return new List<DaSelectorModel>();

        var order = $"{tableItemNameDto.keynm}";
        if (tableItemNameDto.tablenm == tm_afhanyoDto.TABLE_NAME)
        {
            order = @$" {nameof(tm_afhanyoDto.orderseq)} , {nameof(tm_afhanyoDto.hanyocd)}";
        }

        var sql = $"SELECT {tableItemNameDto.keynm},{tableItemNameDto.meisyonm} FROM {tableItemNameDto.tablenm}{GetWhereSql(tableItemNameDto, masterpara)} ORDER BY {order};";
        var result = DaDbUtil.GetDataTable(db, sql).Rows.Cast<DataRow>()
            .Select(r => new DaSelectorModel(r.Wrap(tableItemNameDto.keynm), r.Wrap(tableItemNameDto.meisyonm)))
            .ToList();

        //地区情報マスタ
        if (tableItemNameDto.tablenm == "tm_aftiku")
        {
            result = result.OrderBy(r => CInt(r.value)).ToList();
        }

        return result;

    }

    /// <summary>
    /// 検索情報
    /// </summary>
    public static Dictionary<string, object> GetSearchDict(List<KensakuJyokenVM>? jyokenList, TyusyutuVM tyusyutuinfo)
    {
        var searchDic=new Dictionary<string, object>();

        if (!(jyokenList == null || !jyokenList.Any()))
        {
            //todo 検索情報
            searchDic = jyokenList
                .Where(x => x.value != null)
                .Select(x => (x.jyokenlabel, GetObjValue(x.value, x.controlkbn)))
                .Where(x => x.Item2 != null)
                .ToDictionary(x => x.jyokenlabel, x => x.Item2!);
        }

        //空ではないデータをフィルタリングする
       var filterDic = new Dictionary<string, object>();

        foreach (var kvp in searchDic)
        {
            string key = kvp.Key;
            object value = kvp.Value;

            if (value == null)
            {
                continue;
            }

            if (value is string stringValue)
            {
                if (!string.IsNullOrEmpty(stringValue))
                {
                    filterDic[key] = value;
                }
            }
            else if (value is ArPair arPair)
            {
                //時間範囲フィルター
                if (arPair.First != null || arPair.Second != null)
                {
                    filterDic[key] = value;
                }
            }
            else
            {
                filterDic[key] = value;
            }
        }

        //抽出パネル検索情報をセット
        SetTyusyutuJyoken(ref filterDic, tyusyutuinfo);

        filterDic ??= new Dictionary<string, object>();

        return filterDic;
    }

    /// <summary>
    /// 抽出パネル検索情報をセット
    /// </summary>
    public static void SetTyusyutuJyoken(ref Dictionary<string, object>? searchDic, TyusyutuVM tyusyutuinfo)
    {
        if (tyusyutuinfo == null || string.IsNullOrEmpty(tyusyutuinfo.tyusyututaisyocd))
        {
            return;
        }

        searchDic ??= new Dictionary<string, object>();

        //年度管理しない場合は「(固定値)9999」を設定
        if(string.IsNullOrEmpty(tyusyutuinfo.nendo))
        {
            tyusyutuinfo.nendo = "9999";
        }

        //抽出パネル情報
        Dictionary<string, object> tyusyutuDic = new Dictionary<string, object>
            {
                //抽出対象コード
                { EnumSystemParameter.P_TYUSYUTU_TAISYO_CD.ToString(), tyusyutuinfo.tyusyututaisyocd },
                //年度
                { EnumSystemParameter.P_NENDO.ToString(), tyusyutuinfo.nendo },
                //抽出シーケンス
                { EnumSystemParameter.P_TYUSYUTU_SEQ.ToString(), tyusyutuinfo.tyusyutunaiyo },
                //帳票出力区分
                { EnumSystemParameter.P_TYUSYUTU_KBN.ToString(), tyusyutuinfo.tyusyutukbn },
                //様式種別
                { EnumSystemParameter.P_YOSIKI_SYUBETU.ToString(), tyusyutuinfo.yosikisyubetu }
            };

        foreach (var key in tyusyutuDic.Keys)
        {
            if (!searchDic.ContainsKey(key))
            {
                searchDic.Add(key, tyusyutuDic[key]);
            }
            else
            {
                searchDic[key] = tyusyutuDic[key];
            }
        }
    }

    /// <summary>
    /// 検索詳細情報
    /// </summary>
    public static Dictionary<string, object> GetDetailSearchDict(List<DetailKensakuJyokenVM>? jyokenList)
    {
        if (jyokenList == null || !jyokenList.Any()) return new Dictionary<string, object>(0);
        var dict = new Dictionary<string, object>(jyokenList.Count + 1);
        foreach (var vm in jyokenList)
        {
            switch (vm.ctrltype)
            {
                case Enumコントローラータイプ.通用項目:
                    if (!string.IsNullOrEmpty(vm.itemvm?.value1)) dict.Add(vm.komokunm1, vm.itemvm.value1);
                    break;
                case Enumコントローラータイプ.年齢生年月日:
                    if (vm.agevm != null)
                    {
                        var manAges = CmLogicUtil.ParseAgeRanges(vm.agevm.man);
                        var womanAges = CmLogicUtil.ParseAgeRanges(vm.agevm.woman);
                        var bothAges = CmLogicUtil.ParseAgeRanges(vm.agevm.both);
                        var otherAges = CmLogicUtil.ParseAgeRanges(vm.agevm.unknown);
                        var ageFilter = new DaAgeFilter
                        {
                            kijunymd = vm.agevm.basedate,
                            Male = manAges.Any() ? manAges.OrderBy(x => x).ToArray() : null,
                            Female = womanAges.Any() ? womanAges.OrderBy(x => x).ToArray() : null,
                            Both = bothAges.Any() ? bothAges.OrderBy(x => x).ToArray() : null,
                            Other = otherAges.Any() ? otherAges.OrderBy(x => x).ToArray() : null
                        };
                        dict.Add("age", ageFilter);
                    }

                    if (vm.birthvm != null)
                    {
                        var birthdayFilter = new DaBirthdayFilter
                        {
                            Male = GetDaBirthdayModel(vm.birthvm.man),
                            Female = GetDaBirthdayModel(vm.birthvm.woman),
                            Both = GetDaBirthdayModel(vm.birthvm.both),
                            Other = GetDaBirthdayModel(vm.birthvm.unknown)
                        };
                        dict.Add(nameof(tt_afatenaDto.bymd), birthdayFilter);
                    }

                    break;
                case Enumコントローラータイプ.一覧選択:
                    if (vm.cdlist != null)
                    {
                        var cdArray = vm.cdlist.Where(x => !string.IsNullOrEmpty(x)).Distinct().ToArray();
                        if (cdArray.Any()) dict.Add(vm.komokunm1, cdArray);
                    }

                    break;
                case Enumコントローラータイプ.参照ダイアログ:
                    if (!string.IsNullOrEmpty(vm.itemvm?.value1)) dict.Add(vm.komokunm1, vm.itemvm.value1);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(vm.ctrltype));
            }
        }

        return dict;
    }

    /// <summary>
    /// 初期表示年度と最大年度を取得
    /// </summary>
    public static (string nendo, string nendomax) GetNendoAndNendomax(DaDbContext db, string? nendohanikbn)
    {
        //初期表示年度
        string nendo;
        //最大年度
        string nendomax;

        switch (ParseEnum<Enum年度範囲区分>(string.IsNullOrEmpty(nendohanikbn) ? "1" : nendohanikbn))
        {
            //システム年度~システム年度の場合
            case Enum年度範囲区分.システム年度_システム年度:
                nendo = CStr(DaUtil.Now.Year);
                nendomax = CStr(DaUtil.Now.Year);
                break;

            //システム年度~システム年度 + 1の場合
            case Enum年度範囲区分.システム年度_システム年度Plus1:
                nendo = CStr(DaUtil.Now.Year);
                nendomax = CStr(DaUtil.Now.Year + 1);
                break;

            //メニュー引き継ぐ~コントロールマスタ年度の場合
            case Enum年度範囲区分.メニュー引き継ぐ_コントロールマスタ年度:
                nendo = string.Empty;
                nendomax = CStr(DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._02).IntValue1);
                break;

            default:
                nendo = string.Empty;
                nendomax = string.Empty;
                break;
        }
        return (nendo, nendomax);
    }

    /// <summary>
    /// 削除前確認する
    /// </summary>
    /// <returns></returns>
    public static string GetSqlColnumVerification(DaDbContext db, string datasourceid, HashSet<string> deleteSqlColumnSet)
    {
        var msg = string.Empty;
        //削除前占有されているかどうかを確認する
        var eurpList = db.tm_eurpt.SELECT.WHERE.ByFilter("datasourceid = @datasourceid", datasourceid).GetDtoList();
        if (eurpList.Count > 0)
        {
            var eurpIdSet = eurpList.Select(x => x.rptid).ToHashSet();
            //datasourceidクエリデータ
            const string eupfilter = $"{nameof(tm_eurptitemDto.rptid)} = ANY(@{nameof(tm_eurptitemDto.rptid)}) " +
                                $"AND {nameof(tm_eurptitemDto.sqlcolumn)} = ANY(@{nameof(tm_eurptitemDto.sqlcolumn)})";
            //EUC帳票項目マスタ
            var itemSqlColumns = db.tm_eurptitem.SELECT.WHERE.ByFilter(eupfilter, eurpIdSet.ToArray(), deleteSqlColumnSet.ToArray()).GetDtoList()
            .Select(x => x.sqlcolumn)
            .ToHashSet();
            if (itemSqlColumns.Count > 0)
            {
                var resultColumn = itemSqlColumns.Count == 1 ? itemSqlColumns.Single() : string.Join(",", itemSqlColumns);
                return DaMessageService.GetMsg(EnumMessage.E014001, $"{resultColumn} ");
            }
        }
        return msg;
    }

    /// <summary>
    /// ソート順情報
    /// </summary>
    /// <returns></returns>
    public static List<string> GetOrderByList()
    {
        //todo ソート順情報
        return new List<string>();
    }

    /// <summary>
    /// Excelの最大の行を取得
    /// </summary>
    public static int GetExcelEndRow(byte[]? excelBytes)
    {
        if (excelBytes == null || !excelBytes.Any()) return EucConstant.MIN_ROW;
        using var stream = new MemoryStream(excelBytes);
        IWorkbook workbook = new XSSFWorkbook(stream);
        var sheet = workbook.GetSheetAt(0);
        return Math.Min(Math.Max(EucConstant.MIN_ROW, sheet.LastRowNum + 1), EucConstant.ROW_LIMIT);
    }

    /// <summary>
    /// Excelの最大の列を取得
    /// </summary>
    public static int GetExcelEndCol(byte[]? excelBytes)
    {
        if (excelBytes == null || !excelBytes.Any()) return EucConstant.MIN_COL;
        using var stream = new MemoryStream(excelBytes);
        IWorkbook workbook = new XSSFWorkbook(stream);
        var sheet = workbook.GetSheetAt(0);
        var maxCol = EucConstant.MIN_COL;
        for (var rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
        {
            var row = sheet.GetRow(rowIndex);
            if (row == null) continue;
            maxCol = Math.Max(maxCol, row.LastCellNum);
            if (maxCol >= EucConstant.COL_LIMIT)
            {
                break;
            }
        }

        return Math.Min(maxCol, EucConstant.COL_LIMIT);
    }

    /// <summary>
    /// Excelの最大の行と列を取得
    /// </summary>
    public static void GetExcelEndRowAndCol(byte[]? excelBytes, out int endrow, out int endcol)
    {
        if (excelBytes == null || !excelBytes.Any())
        {
            endrow = EucConstant.MIN_ROW;
            endcol = EucConstant.MIN_COL;
            return;
        }

        using var stream = new MemoryStream(excelBytes);
        IWorkbook workbook = new XSSFWorkbook(stream);
        var sheet = workbook.GetSheetAt(0);
        endrow = Math.Min(Math.Max(EucConstant.MIN_ROW, sheet.LastRowNum + 1), EucConstant.ROW_LIMIT);
        var maxCol = EucConstant.MIN_COL;
        for (var rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
        {
            var row = sheet.GetRow(rowIndex);
            if (row == null) continue;
            maxCol = Math.Max(maxCol, row.LastCellNum);
            if (maxCol >= EucConstant.COL_LIMIT)
            {
                break;
            }
        }

        endcol = Math.Min(maxCol, EucConstant.COL_LIMIT);
    }

    /// <summary>
    /// 権限区分
    /// </summary>
    public static RptAuthVM GetRptAuthVM(DaDbContext db, string rptgrouopid, string token, string userid, string? regsisyo)
    {
        var tokenSeq = DaTokenService.GetTokenUD(token, userid, regsisyo);
        var tokenDto = db.tt_aftoken.GetDtoByKey(tokenSeq);
        if (tokenDto == null!) return RptAuthVM.NO_AUTH;
        var roleId = tokenDto.rolekbn == Enumロール区分.ユーザー ? tokenDto.userid : tokenDto.syozokucd;
        if (string.IsNullOrEmpty(roleId)) return RptAuthVM.NO_AUTH;
        var authreportDto = db.tt_afauthreport.GetDtoByKey(DaConvertUtil.EnumToStr(tokenDto.rolekbn), roleId, rptgrouopid);
        return GetRptAuthVM(authreportDto, tokenDto.alertviewflg);
    }

    ///// <summary>
    ///// tm_afhanyo
    ///// </summary>
    //public static List<tm_afhanyoDto> GetSearchInfoList(DaDbContext db, String hanyomaincd_info, int hanyosubcd_info)
    //{
    //    var filter = $"{nameof(tm_afhanyoDto.hanyomaincd)} = @{nameof(tm_afhanyoDto.hanyomaincd)} and {nameof(tm_afhanyoDto.hanyosubcd)} = @{nameof(tm_afhanyoDto.hanyosubcd)}";
    //    var groupJyokenDtl = db.tm_afhanyo.SELECT.WHERE.ByFilter(filter, hanyomaincd_info, hanyosubcd_info).ORDER.By(nameof(tm_afhanyoDto.hanyosubcd)).GetDtoList();
    //    return groupJyokenDtl;
    //}

    /// <summary>
    /// 
    /// </summary>
    private static object? GetObjValue(object? obj, Enumコントロール? controlkbn)
    {
        if (controlkbn != null
            && (controlkbn == Enumコントロール.数値範囲
            || controlkbn == Enumコントロール.文字範囲
            || controlkbn == Enumコントロール.日付範囲
            || controlkbn == Enumコントロール.時間範囲))
        {
            var pair = new ArPair(null, null);
            if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
            {
                var arrValue = obj.ToString()!.Split(@",");
                pair.First = controlkbn == Enumコントロール.数値範囲 ? DaConvertUtil.CNInt(arrValue[0]) : arrValue[0];
                if (arrValue.Length > 1)
                {
                    pair.Second = controlkbn == Enumコントロール.数値範囲 ? DaConvertUtil.CNInt(arrValue[1]) : arrValue[1];
                }
            }
            return pair;
        }

        if (obj != null && !string.IsNullOrEmpty(obj.ToString()) && controlkbn != null)
        {
            if (controlkbn == Enumコントロール.選択)
            {
                return DaSelectorService.GetCd(obj.ToString());
            }
        } 

        switch (obj)
        {
            case null:
                return null;
            case string s:
                return string.IsNullOrEmpty(s) ? null : s;
            case IEnumerable coll:
            {
                var objArray = coll.Cast<object?>().ToArray();
                var firstNotNullElement = objArray.FirstOrDefault(c => c != null);
                var existNullElement = objArray.Any(c => c == null);
                return firstNotNullElement switch
                {
                    null => null,
                    string => existNullElement ? objArray.Cast<string?>().ToArray() : objArray.Cast<string>().ToArray(),
                    byte => existNullElement ? objArray.Cast<byte?>().ToArray() : objArray.Cast<byte>().ToArray(),
                    short => existNullElement ? objArray.Cast<short?>().ToArray() : objArray.Cast<short>().ToArray(),
                    int => existNullElement ? objArray.Cast<int?>().ToArray() : objArray.Cast<int>().ToArray(),
                    long => existNullElement ? objArray.Cast<long?>().ToArray() : objArray.Cast<long>().ToArray(),
                    float => existNullElement ? objArray.Cast<float?>().ToArray() : objArray.Cast<float>().ToArray(),
                    double => existNullElement ? objArray.Cast<double?>().ToArray() : objArray.Cast<double>().ToArray(),
                    _ => existNullElement ? objArray.Select(o => o?.ToString()).ToArray() : objArray.Select(o => o!.ToString()).ToArray()
                };
            }
            default:
                return obj switch
                {
                    byte b => b,
                    short sr => sr,
                    int i => i,
                    long l => l,
                    float f => f,
                    double d => d,
                    bool bl => bl,
                    _ => obj.ToString()
                };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private static string GetObjValueStr(object? obj)
    {
        switch (obj)
        {
            case null:
                return string.Empty;
            case string s:
                return string.IsNullOrEmpty(s) ? string.Empty : s;
            case IEnumerable coll:
            {
                var objArray = coll.Cast<object?>().ToList();
                var firstNotNullElement = objArray.FirstOrDefault(c => c != null);
                return firstNotNullElement == null ? string.Empty : string.Join(DaStrPool.C_COMMA, objArray);
            }
            default:
                return obj.ToString() ?? string.Empty;
        }
    }

    /// <summary>
    /// 帳票操作権限
    /// </summary>
    private static RptAuthVM GetRptAuthVM(tt_afauthreportDto? dto, bool alertviewflg)
    {
        var vm = new RptAuthVM();

        //TODO ユーザー権限設定
        //vm.personalnoflg = dto.personalnoflg; //個人番号利用フラグ
        vm.personalnoflg = false; //個人番号利用フラグ（一時利用停止）
        vm.alertviewflg = alertviewflg; //警告参照フラグ

        //TODO 帳票グループ権限設定
        if (dto == null)
        {
            vm.tutisyooutflg = false; //通知書出力フラグ
            vm.pdfoutflg = false; //PDF出力フラグ
            vm.exceloutflg = false; //EXCEL出力フラグ
            vm.othersflg = false; //その他出力フラグ
        }
        else
        {
            //vm.tutisyooutflg = dto.tutisyooutflg; //通知書出力フラグ（一時利用停止）
            vm.tutisyooutflg = false; //通知書出力フラグ
            vm.pdfoutflg = dto.pdfoutflg; //PDF出力フラグ
            vm.exceloutflg = dto.exceloutflg; //EXCEL出力フラグ
            vm.othersflg = dto.othersflg; //その他出力フラグ
        } ;
        
        return vm;
    }

    private static string GetWhereSql(tm_eutableitemnameDto tableItemNameDto, string? masterpara)
    {
        if (string.IsNullOrEmpty(tableItemNameDto.maincd) && string.IsNullOrEmpty(tableItemNameDto.subcd)) return string.Empty;
        if (!string.IsNullOrEmpty(tableItemNameDto.maincd) && string.IsNullOrEmpty(tableItemNameDto.subcd))
        {
            if (!tableItemNameDto.maincdnumflg)
                return string.IsNullOrEmpty(masterpara) ? $" WHERE {tableItemNameDto.maincd} IS NULL OR {tableItemNameDto.maincd} = ''" : $" WHERE {tableItemNameDto.maincd} = '{masterpara}'";
            var numValue = double.TryParse(masterpara, out var d) ? d : int.MinValue;
            return $" WHERE {tableItemNameDto.maincd} = {numValue}";
        }

        if (string.IsNullOrEmpty(tableItemNameDto.maincd) && !string.IsNullOrEmpty(tableItemNameDto.subcd))
        {
            if (string.IsNullOrEmpty(masterpara))
            {
                return $" WHERE {tableItemNameDto.subcd} IS NULL";
            }

            if (!masterpara.Contains(DaStrPool.C_TILDE_HALF))
            {
                var subCdValue = double.TryParse(masterpara, out var d) ? d : int.MinValue;
                return $" WHERE {tableItemNameDto.subcd} = {subCdValue}";
            }

            var subcdSplit = masterpara.Split(DaStrPool.C_TILDE_HALF, StringSplitOptions.TrimEntries);
            var subCdValue1 = double.TryParse(subcdSplit[0], out var d1) ? d1 : int.MinValue;
            var subCdValue2 = double.TryParse(subcdSplit[1], out var d2) ? d2 : int.MaxValue;
            var maxSubCd = Math.Max(subCdValue1, subCdValue2);
            var minSubCd = Math.Min(subCdValue1, subCdValue2);
            return $" WHERE {tableItemNameDto.subcd} >= {minSubCd} AND {tableItemNameDto.subcd} <= {maxSubCd}";
        }

        if (string.IsNullOrEmpty(masterpara))
        {
            return tableItemNameDto.maincdnumflg
                ? $" WHERE {tableItemNameDto.maincd} = {int.MinValue} AND {tableItemNameDto.subcd} IS NULL"
                : $" WHERE ({tableItemNameDto.maincd} IS NULL OR {tableItemNameDto.maincd} = '') AND {tableItemNameDto.subcd} IS NULL";
        }

        var split = masterpara.Split(DaStrPool.C_COMMA, StringSplitOptions.TrimEntries);
        if (split.Length == 1)
        {
            if (!tableItemNameDto.maincdnumflg)
            {
                return string.IsNullOrEmpty(split[0])
                    ? $" WHERE ({tableItemNameDto.maincd} IS NULL OR {tableItemNameDto.maincd} = '') AND {tableItemNameDto.subcd} IS NULL"
                    : $" WHERE {tableItemNameDto.maincd} = '{split[0]}' AND {tableItemNameDto.subcd} IS NULL";
            }

            var numValue = double.TryParse(split[0], out var d) ? d : int.MinValue;
            return $" WHERE {tableItemNameDto.maincd} = {numValue} AND {tableItemNameDto.subcd} IS NULL";
        }

        string whereSql;
        if (!tableItemNameDto.maincdnumflg)
        {
            whereSql = string.IsNullOrEmpty(split[0])
                ? $" WHERE ({tableItemNameDto.maincd} IS NULL OR {tableItemNameDto.maincd} = '')"
                : $" WHERE {tableItemNameDto.maincd} = '{split[0]}'";
        }
        else
        {
            var numValue = double.TryParse(split[0], out var d) ? d : int.MinValue;
            whereSql = $" WHERE {tableItemNameDto.maincd} = {numValue}";
        }

        if (!split[1].Contains(DaStrPool.C_TILDE_HALF))
        {
            var subCdValue = double.TryParse(split[1], out var d) ? d : int.MinValue;
            return $"{whereSql} AND {tableItemNameDto.subcd} = {subCdValue}";
        }

        var subCdSplit = split[1].Split(DaStrPool.C_TILDE_HALF, StringSplitOptions.TrimEntries);
        var subCd1 = double.TryParse(subCdSplit[0], out var sub1) ? sub1 : int.MinValue;
        var subCd2 = double.TryParse(subCdSplit[1], out var sub2) ? sub2 : int.MaxValue;
        var maxSubValue = Math.Max(subCd1, subCd2);
        var minSubValue = Math.Min(subCd1, subCd2);
        return $"{whereSql} AND {tableItemNameDto.subcd} >= {minSubValue} AND {tableItemNameDto.subcd} <= {maxSubValue}";
    }

    private static DaBirthdayModel? GetDaBirthdayModel(ItemVM? vm)
    {
        return vm == null
            ? null
            : new DaBirthdayModel
            {
                DateFrom = DateTime.TryParse(vm.value1, out var md1) ? md1 : null,
                DateTo = DateTime.TryParse(vm.value2, out var md2) ? md2 : null,
                UnknownY = vm.yearflg,
                UnknownM = vm.monthflg,
                UnknownD = vm.dayflg
            };
    }

    /// <summary>
    /// 出力情報を取得
    /// </summary>
    public static Dictionary<string,object> GetOutPutInfo(OutPutInfoVM? outPutInfo, string filenm)
    {
        //出力情報
        var outputInfoDic = new Dictionary<string, object>();
        if (outPutInfo != null)
        {
            //発行日
            outputInfoDic.Add(DaEucService.CONDITION_PRINTDATE, outPutInfo.printdate);
            //枚目から
            outputInfoDic.Add(DaEucService.CONDITION_START_COUNT, outPutInfo.startdetailcount);
        }
        if (!string.IsNullOrEmpty(filenm))
        {
            int index = filenm.IndexOf('.');
            //ドットの前の部分を取得し、それ以外の場合は文字列全体を返します。
            filenm = index >= 0 ? filenm.Substring(0, index) : filenm;
            //ファイル名
            outputInfoDic.Add(DaEucService.CONDITION_FILE_NM, filenm);
        }
        return outputInfoDic;
    }
}

/// <summary>
/// 帳票操作権限
/// </summary>
public class RptAuthVM
{
    public static readonly RptAuthVM NO_AUTH = new(); //何の権限もない

    [JsonIgnore] public bool tutisyooutflg { get; set; } //通知書出力フラグ
    public bool pdfoutflg { get; set; } //PDF出力フラグ
    public bool exceloutflg { get; set; } //EXCEL出力フラグ
    public bool othersflg { get; set; } //その他出力フラグ

    [JsonIgnore] public bool personalnoflg { get; set; } //個人番号利用フラグ
    // [JsonIgnore] public Enum帳票種別? rptsbt { get; set; } //帳票種別
    // public bool tutisyooutwarningflg => rptsbt == Enum帳票種別.通知書_証明書 && !tutisyooutflg; //通知書出力警告フラグ

    public bool alertviewflg { get; set; } //警告参照フラグ
}

/// <summary>
/// 検索条件
/// </summary>
public class KensakuJyokenVM
{
    public int jyokenseq { get; set; }              //条件シーケンス
    public Enum検索条件区分 jyokenkbn { get; set; } //検索条件区分
    public string jyokenlabel { get; set; }         //ラベル
    public string? variables { get; set; }         //変数名
    public string sql { get; set; }                //SQL
    public string tablealias { get; set; }         //テーブル別名
    public Enumコントロール? controlkbn { get; set; } //コントロール区分
    public bool hissuflg { get; set; }             //必須フラグ
    public EnumDataType datatype { get; set; }     //データ型
    public List<DaSelectorModel>? selectorlist { get; set; } //選択リスト
    public object? value { get; set; }             //値
}

/// <summary>
/// 詳細検索条件
/// </summary>
public class DetailKensakuJyokenVM : SearchVM
{
    public string komokunm1 { get; set; } //項目物理名1
    public Enumコントローラータイプ ctrltype { get; set; } //コントローラータイプ
}

/// <summary>
/// 抽出パネル検索情報
/// </summary>
public class TyusyutuVM
{
    public string tyusyututaisyocd { get; set; }    //抽出対象コード
    public string nendo { get; set; }               //年度
    public string tyusyutunaiyo { get; set; }       //抽出内容
    public string tyusyutukbn { get; set; }         //帳票出力区分
    public string yosikisyubetu { get; set; }       //様式種別
}

/// <summary>
/// 出力情報
/// </summary>
public class OutPutInfoVM
{
    public string printdate { get; set; }       //発行日
    public int startdetailcount { get; set; }   //枚目から
}
