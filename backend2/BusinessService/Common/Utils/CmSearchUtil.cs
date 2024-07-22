// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 詳細条件共通関数
//
// 作成日　　: 2023.05.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using BCC.Affect.Service.AWAF00703D;
using NodaTime;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service
{
    public static class CmSearchUtil
    {
        /// <summary>
        /// 検索条件設定
        /// </summary>
        /// <param name="db"></param>
        /// <param name="kinoid"></param>
        /// <param name="syosailist"></param>
        /// <param name="fixedCondition"></param>
        /// <param name="pagenum"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public static FrCondition GetSearchJyoken(DaDbContext db, string? kinoid, List<SearchVM>? syosailist, FrConditionModel fixedCondition, int? pagenum = null, int? pagesize = null)
        {
            var jyoken = new FrCondition();
            if (pagenum != null && pagesize != null)
            {
                jyoken.PageNo = pagenum.Value;
                jyoken.PageRowCount = pagesize.Value;
            }
            jyoken.ConditionModel = fixedCondition;
            if (syosailist != null && syosailist.Any())
            {
                var keylist = syosailist.Select(e => new object[] { kinoid!, e.jyokbn, e.jyoseq }).ToList();
                var dtl = db.tt_affilter.SELECT.WHERE.ByKeyList(keylist).GetDtoList();
                foreach (var jyo in syosailist)
                {
                    var dto = dtl.FirstOrDefault(x => x.jyokbn == jyo.jyokbn && x.jyoseq == jyo.jyoseq);
                    jyoken.ConditionModel.And(GetFr(dto!, jyo));
                }
            }

            return jyoken;
        }

        /// <summary>
        /// 条件取得(1件)
        /// </summary>
        private static FrConditionModel GetFr(tt_affilterDto dto, SearchVM jyo)
        {
            switch (dto.ctrltype)
            {
                case Enumコントローラータイプ.通用項目:
                    return GetFr1(dto, jyo.itemvm!);
                case Enumコントローラータイプ.年齢生年月日:
                    return GetFr2(dto, jyo.agevm, jyo.birthvm);
                case Enumコントローラータイプ.一覧選択:
                    return GetFr3(dto, jyo.cdlist!);
                case Enumコントローラータイプ.参照ダイアログ:
                    return GetFr4(dto, jyo.itemvm!);
                default:
                    throw new Exception("Enumコントローラータイプ error");
            }
        }

        /// <summary>
        /// 条件取得(通用項目)
        /// </summary>
        private static FrConditionModel GetFr1(tt_affilterDto dto, ItemVM vm)
        {
            var kbn = (Enum項目区分)CInt(dto.sethanyokbn1);
            if (dto.getkbn == Enum取得元区分.テーブル固定項目)
            {
                return GetFr1Sql(kbn, dto.rangeflg, dto.tablenm1, string.Empty, dto.komokunm1!, dto.tablenm2!, dto.komokunm2!, vm);
            }
            else
            {
                return GetFr1Sql(kbn, dto.rangeflg, $"{dto.tablenm1}_{dto.keycd1}_{dto.itemcd1}", dto.itemcd1, dto.komokunm1!, $"{dto.tablenm2}_{dto.keycd2}_{dto.itemcd2}", dto.komokunm2!, vm);
            }
        }

        /// <summary>
        /// 条件取得(年齢/生年月日)
        /// </summary>
        private static FrConditionModel GetFr2(tt_affilterDto dto, AgeVM? agevm, BirthVM? birthvm)
        {
            var kbn = EnumBirthSearchKbn.年齢;
            if (birthvm != null) kbn = EnumBirthSearchKbn.生年月日;
            if (dto.getkbn == Enum取得元区分.テーブル固定項目)
            {
                return GetFr2Sql(dto.tablenm1, dto.komokunm1!, dto.tablenm2!, dto.komokunm2!, dto.tablenm3!, dto.komokunm3!, kbn, agevm, birthvm);
            }
            else//要らないかも
            {
                return GetFr2Sql($"{dto.tablenm1}_{dto.keycd1}_{dto.itemcd1}", dto.komokunm1!,
                                 $"{dto.tablenm2}_{dto.keycd2}_{dto.itemcd2}", dto.komokunm2!,
                                 $"{dto.tablenm3}_{dto.keycd3}_{dto.itemcd3}", dto.komokunm3!, kbn, agevm, birthvm);
            }
        }

        /// <summary>
        /// 条件取得(一覧選択)
        /// </summary>
        private static FrConditionModel GetFr3(tt_affilterDto dto, List<string> list)
        {
            if (dto.getkbn == Enum取得元区分.テーブル固定項目)
            {
                return new FrConditionModel(dto.tablenm1, dto.komokunm1!, FrEnumValueOprator.IN, list);
            }
            else
            {
                return new FrConditionModel($"{dto.tablenm1}_{dto.keycd1}_{dto.itemcd1}", dto.komokunm1!, FrEnumValueOprator.IN, list);
            }
        }

        /// <summary>
        /// 条件取得(一覧選択参照ダイアログ)
        /// </summary>
        private static FrConditionModel GetFr4(tt_affilterDto dto, ItemVM vm)
        {
            if (dto.getkbn == Enum取得元区分.テーブル固定項目)
            {
                return new FrConditionModel(dto.tablenm1, dto.komokunm1!, FrEnumValueOprator.EQ, CStr(vm.value1));
            }
            else
            {
                return new FrConditionModel($"{dto.tablenm1}_{dto.keycd1}_{dto.itemcd1}", dto.komokunm1!, FrEnumValueOprator.EQ, CStr(vm.value1));
            }
        }

        /// <summary>
        /// 通用項目sql取得
        /// </summary>
        private static FrConditionModel GetFr1Sql(Enum項目区分 kbn, bool rangeflg, string tablenm1, string? keyCode, string komokunm1, string tablenm2, string komokunm2, ItemVM vm)
        {
            if (rangeflg)
            {
                switch (kbn)
                {
                    case Enum項目区分.文字:
                    case Enum項目区分.数字:
                        {
                            return GetRangeSql(tablenm1, keyCode, komokunm1, vm.value1, vm.value2, kbn);
                        }
                    case Enum項目区分.日付:
                    case Enum項目区分.日時:
                        {
                            var cond = GetRangeSql(tablenm1, keyCode, komokunm1, vm.value1, vm.value2, kbn);
                            if (!string.IsNullOrEmpty(tablenm2) && !string.IsNullOrEmpty(komokunm2))
                            {
                                cond.And(tablenm2, komokunm2, FrEnumValueOprator.NE, true);
                            }
                            return cond;
                        }
                    case Enum項目区分.日付不明:
                        {
                            var cond = GetRangeSql(tablenm1, keyCode, komokunm1, vm.value1, vm.value2, kbn)
                                .And(tablenm2, komokunm2, FrEnumValueOprator.NE, true);
                            return GetUnkown(vm, cond, tablenm1, komokunm1, tablenm2, komokunm2);
                        }
                    default:
                        throw new Exception("Enum項目区分 error");
                }
            }
            else
            {
                switch (kbn)
                {
                    case Enum項目区分.文字:
                        {
                            return new FrConditionModel(tablenm1, komokunm1, FrEnumValueOprator.LK, $"%{vm.value1!}%");
                        }
                    case Enum項目区分.数字:
                        {
                            return new FrConditionModel(tablenm1, komokunm1, FrEnumValueOprator.EQ, CInt(vm.value1!));
                        }
                    case Enum項目区分.日付:
                    case Enum項目区分.日付不明:
                    case Enum項目区分.日時:
                        {
                            return new FrConditionModel(tablenm1, komokunm1, FrEnumValueOprator.EQ, vm.value1!);
                        }
                    default:
                        throw new Exception("Enum項目区分 error");
                }
            }
        }

        /// <summary>
        /// 範囲sql取得
        /// </summary>
        private static FrConditionModel GetRangeSql(string tablenm, string? keyCode, string komokunm, object? value1, object? value2, Enum項目区分 kbn, FrConditionModel? preCondition = null)
        {
            if (value1 is string str1 && string.IsNullOrEmpty(str1)) value1 = null;
            if (value2 is string str2 && string.IsNullOrEmpty(str2)) value2 = null;

            //値(開始)のみ
            if (value1 != null && value2 == null)
            {
                return preCondition == null
                    ? new FrConditionModel(tablenm, keyCode, komokunm, FrEnumValueOprator.GE, GetVal(value1, kbn))
                    : preCondition.Sub().Sub(tablenm, komokunm, FrEnumValueOprator.GE, GetVal(value1, kbn));
            }
            //値(終了)のみ
            if (value1 == null && value2 != null)
            {
                return preCondition == null
                    ? new FrConditionModel(tablenm, komokunm, FrEnumValueOprator.LE, GetVal(value2, kbn))
                    : preCondition.Sub().Sub(tablenm, komokunm, FrEnumValueOprator.LE, GetVal(value2, kbn));
            }
            //値(開始)と値(終了)　両方あり
            if (value1 != null && value2 != null)
            {
                return preCondition == null
                    ? new FrConditionModel(tablenm, komokunm, FrEnumValueOprator.GE, GetVal(value1, kbn))
                        .And(tablenm, komokunm, FrEnumValueOprator.LE, GetVal(value2, kbn))
                    : preCondition.Sub().Sub(tablenm, komokunm, FrEnumValueOprator.GE, GetVal(value1, kbn))
                        .And(tablenm, komokunm, FrEnumValueOprator.LE, GetVal(value2, kbn));
            }
            throw new Exception("範囲必須チェック漏れ");
        }

        /// <summary>
        /// 値の取得
        /// </summary>
        private static object GetVal(object value, Enum項目区分 kbn)
        {
            switch (kbn)
            {
                case Enum項目区分.文字:
                case Enum項目区分.日付:
                case Enum項目区分.日付不明:
                case Enum項目区分.日時:
                    return value;
                case Enum項目区分.数字:
                    return CDbl(value);
                default:
                    throw new Exception("Enum項目区分 error");
            }
        }

        /// <summary>
        /// 年齢/生年月日範囲sql取得
        /// </summary>
        private static FrConditionModel GetFr2Sql(string tablenm1, string komokunm1, string tablenm2, string komokunm2, string tablenm3, string komokunm3, EnumBirthSearchKbn kbn, AgeVM? agevm,
            BirthVM? birthvm)
        {
            switch (kbn)
            {
                case EnumBirthSearchKbn.年齢:
                    return GetAgeSql(tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3, agevm!);
                case EnumBirthSearchKbn.生年月日:
                    return GetBirthSql(tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3, birthvm!);
                default:
                    throw new Exception("EnumBirthSearchKbn error");
            }
        }

        /// <summary>
        /// 年齢範囲sql取得
        /// </summary>
        private static FrConditionModel GetAgeSql(string tablenm1, string komokunm1, string tablenm2, string komokunm2, string tablenm3, string komokunm3, AgeVM vm)
        {
            //男性年齢範囲
            var manAges = CmLogicUtil.ParseAgeRanges(vm.man);
            //女性年齢範囲
            var womanAges = CmLogicUtil.ParseAgeRanges(vm.woman);
            //両方年齢範囲
            var bothAges = CmLogicUtil.ParseAgeRanges(vm.both);
            //不明年齢範囲
            var unknownAges = CmLogicUtil.ParseAgeRanges(vm.unknown);

            //両方年齢範囲が男性と女性へ追加
            manAges.UnionWith(bothAges);
            womanAges.UnionWith(bothAges);

            //男性生年月日範囲
            var manList = GetBirthVMList(manAges, vm.basedate);
            //女性生年月日範囲
            var womanList = GetBirthVMList(womanAges, vm.basedate);
            //不明生年月日範囲
            var unknownList = GetBirthVMList(unknownAges, vm.basedate);

            //sql取得
            return GetBirthRangeSql(EnumBirthSearchKbn.年齢, manList, womanList, unknownList, tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3);
        }

        /// <summary>
        /// 生年月日範囲sql取得
        /// </summary>
        private static FrConditionModel GetBirthSql(string tablenm1, string komokunm1, string tablenm2, string komokunm2, string tablenm3, string komokunm3, BirthVM vm)
        {
            //男性生年月日範囲
            var manList = new List<ItemVM>();
            //女性生年月日範囲
            var womanList = new List<ItemVM>();
            //不明生年月日範囲
            var unknownList = new List<ItemVM>();

            //データ格納
            if (vm.man != null) manList.Add(vm.man!);
            if (vm.woman != null) womanList.Add(vm.woman!);
            if (vm.both != null)
            {
                manList.Add(vm.both!);
                womanList.Add(vm.both!);
            }
            if (vm.unknown != null) unknownList.Add(vm.unknown!);

            //sql取得
            return GetBirthRangeSql(EnumBirthSearchKbn.生年月日, manList, womanList, unknownList, tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3);
        }

        /// <summary>
        /// 生年月日範囲sql取得
        /// </summary>
        private static FrConditionModel GetBirthRangeSql(EnumBirthSearchKbn kbn, List<ItemVM> manList, List<ItemVM> womanList, List<ItemVM> unknownList,
            string tablenm1, string komokunm1, string tablenm2, string komokunm2, string tablenm3, string komokunm3)
        {
            FrConditionModel? condition = null;
            if (manList.Any())
            {
                condition = GetBirthCondition(kbn, manList, tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3, Enum性別.男, condition);
            }
            if (womanList.Any())
            {
                condition = GetBirthCondition(kbn, womanList, tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3, Enum性別.女, condition);
            }
            if (unknownList.Any())
            {
                condition = GetBirthCondition(kbn, unknownList, tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3, Enum性別.不明, condition);
                condition.Or(GetBirthCondition(kbn, unknownList, tablenm1, komokunm1, tablenm2, komokunm2, tablenm3, komokunm3, Enum性別.その他, null).EndSub());
            }
            return condition!.EndSub();
        }

        /// <summary>
        /// 生年月日の絞り込み 
        /// </summary>
        private static FrConditionModel GetBirthCondition(EnumBirthSearchKbn kbn, List<ItemVM> vmList,
            string tablenm1, string komokunm1, string tablenm2, string komokunm2, string tablenm3, string komokunm3,
            Enum性別 sex, FrConditionModel? prevCondition)
        {
            //性別設定
            var condition = prevCondition == null
                ? new FrConditionModel().Sub().Sub(tablenm1, komokunm1, FrEnumValueOprator.EQ, EnumToStr(sex))
                : new FrConditionModel().Sub(tablenm1, komokunm1, FrEnumValueOprator.EQ, EnumToStr(sex));

            //生年月日範囲設定
            var condition2 = new FrConditionModel().Sub();

            switch (kbn)
            {
                case EnumBirthSearchKbn.年齢:
                    foreach (var vm in vmList)
                    {
                        var cond = GetRangeSql(tablenm2, null, komokunm2, vm.value1, vm.value2, Enum項目区分.日付).And(tablenm3, komokunm3, FrEnumValueOprator.NE, true);
                        condition2.Or(cond);
                    }
                    break;
                case EnumBirthSearchKbn.生年月日:
                    foreach (var vm in vmList)
                    {
                        var cond = GetRangeSql(tablenm2, null, komokunm2, vm.value1, vm.value2, Enum項目区分.日付不明).And(tablenm3, komokunm3, FrEnumValueOprator.NE, true);
                        cond = GetUnkown(vm, cond, tablenm2, komokunm2, tablenm3, komokunm3);
                        condition2.Or(cond);
                    }
                    break;
                default:
                    throw new Exception("EnumBirthSearchKbn error");
            }
            condition.And(condition2.EndSub()).EndSub();

            return prevCondition == null ? condition : prevCondition.Or(condition);
        }

        /// <summary>
        /// 生年月日範囲モデル取得
        /// </summary>
        private static List<ItemVM> GetBirthVMList(HashSet<int> ages, DateTime baseDate)
        {
            var list = new List<ItemVM>();
            var births = GetBirthdayPeriods(ages, baseDate).Select(x => (x.Item1.ToString(DaConst.DateFormat), x.Item2.ToString(DaConst.DateFormat))).ToList();
            foreach (var birth in births)
            {
                ItemVM vm = new ItemVM();
                vm.value1 = birth.Item1;
                vm.value2 = birth.Item2;
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        /// 生年月日範囲を取得する(年齢範囲、基準日)
        /// </summary>
        private static List<(DateTime, DateTime)> GetBirthdayPeriods(IEnumerable<int> ages, DateTime baseDate)
        {
            var sortedAges = ages.Distinct().OrderByDescending(x => x).ToList();
            if (!sortedAges.Any())
            {
                return new List<(DateTime, DateTime)>(0);
            }

            var referenceDate = LocalDateTime.FromDateTime(baseDate).Date;
            var ageRanges = new List<(int, int)>();
            var start = sortedAges[0];
            var prev = start;
            for (var i = 1; i < sortedAges.Count; i++)
            {
                if (sortedAges[i] != prev - 1)
                {
                    ageRanges.Add((start, prev));
                    start = sortedAges[i];
                }

                prev = sortedAges[i];
            }

            ageRanges.Add((start, prev));
            return ageRanges.Select(ageRange =>
            {
                var from = Period.FromYears(ageRange.Item1);
                var to = Period.FromYears(ageRange.Item2);
                var fromDate = referenceDate.Minus(from).PlusYears(-1).PlusDays(1).AtStartOfDayInZone(DaConst.TOKYO_TIME_ZONE).ToDateTimeUnspecified();
                var toDate = referenceDate.Minus(to).AtStartOfDayInZone(DaConst.TOKYO_TIME_ZONE).ToDateTimeUnspecified();
                if (DateTime.IsLeapYear(fromDate.Year))
                {
                    fromDate = fromDate.AddDays(1);
                }

                return (fromDate, toDate);
            }).ToList();
        }

        /// <summary>
        /// 不詳日付sql取得
        /// </summary>
        private static FrConditionModel GetUnkown(ItemVM vm, FrConditionModel cond, string tablenm1, string komokunm1, string tablenm2, string komokunm2)
        {
            //不詳チェックがない場合
            if (vm is { yearflg: false, monthflg: false, dayflg: false }) return cond;
            //不詳年
            var unknownYear = "0000";
            //不詳日
            var unknownDayTags = new List<string> { "A1", "A2", "A3", "00" };
            //不詳月
            var unknownMonthTags = new List<string> { "A1", "A2", "A3", "A4", "00" };

            //不詳sql
            var conditionModel = new FrConditionModel();

            //半開区間の場合
            if (string.IsNullOrEmpty(vm.value1) || string.IsNullOrEmpty(vm.value2))
            {
                //不詳年
                if (vm.yearflg)
                {
                    conditionModel.OrSub(tablenm1, komokunm1, FrEnumValueOprator.LK, $"{unknownYear}-%");
                }

                //不詳月、不詳日
                if (vm.monthflg || vm.dayflg)
                {
                    //開始日
                    if (!string.IsNullOrEmpty(vm.value1))
                    {
                        conditionModel.OrSub(tablenm1, komokunm1, FrEnumValueOprator.GE, $"{vm.value1.Split(DaStrPool.C_DASHED)[0]}-00-00");
                    }
                    //終了日
                    else if (!string.IsNullOrEmpty(vm.value2))
                    {
                        conditionModel.OrSub(tablenm1, komokunm1, FrEnumValueOprator.LE, $"{vm.value2.Split(DaStrPool.C_DASHED)[0]}-ZZ-ZZ");
                        conditionModel.And(tablenm1, komokunm1, FrEnumValueOprator.NL, $"{unknownYear}-%");
                    }

                    //不詳月、不詳日sql
                    var monthDayCondition = new FrConditionModel().Sub();
                    //不詳月
                    if (vm.monthflg)
                    {
                        foreach (var month in unknownMonthTags)
                        {
                            monthDayCondition.Or(tablenm1, komokunm1, FrEnumValueOprator.LK, $"%-{month}-%");
                        }
                    }
                    //不詳日
                    if (vm.dayflg)
                    {
                        foreach (var day in unknownDayTags)
                        {
                            monthDayCondition.Or(tablenm1, komokunm1, FrEnumValueOprator.LK, $"%-{day}");
                        }
                    }
                    conditionModel.And(monthDayCondition.EndSub()).EndSub();
                }
                else
                {
                    conditionModel.EndSub();
                }
                //不詳フラグ
                conditionModel.And(tablenm2, komokunm2, FrEnumValueOprator.EQ, true);
            }
            //閉区間の場合
            else
            {
                //開始日
                var startDate = CDate(vm.value1);
                //終了日
                var endDate = CDate(vm.value2);
                //日付リスト(全て)
                var dates = new List<string>();
                //年リスト(不詳ではない範囲)
                var years = new HashSet<string>();
                //月リスト(不詳ではない範囲)
                var months = new HashSet<string>();
                //日リスト(不詳ではない範囲)
                var days = new HashSet<string>();

                //不詳ではない範囲を取得：入り替えため
                for (var date = startDate; date <= endDate; date = date.AddDays(1))
                {
                    years.Add(date.ToString("yyyy"));
                    months.Add(date.ToString("MM"));
                    days.Add(date.ToString("dd"));
                }
                //年月日不詳の場合
                if (vm.yearflg && vm.monthflg && vm.dayflg)
                {
                    dates = GetDateList(new List<string>() { unknownYear }, unknownMonthTags, unknownDayTags, dates);
                }
                //年月不詳の場合
                if (vm.yearflg && vm.monthflg)
                {
                    dates = GetDateList(new List<string>() { unknownYear }, unknownMonthTags, days.ToList(), dates);
                }
                //年日不詳の場合
                if (vm.yearflg && vm.dayflg)
                {
                    dates = GetDateList(new List<string>() { unknownYear }, months.ToList(), unknownDayTags, dates);
                }
                //月日不詳の場合
                if (vm.monthflg && vm.dayflg)
                {
                    dates = GetDateList(years.ToList(), unknownMonthTags, unknownDayTags, dates);
                }
                //年不詳の場合
                if (vm.yearflg)
                {
                    dates = GetDateList(new List<string>() { unknownYear }, months.ToList(), days.ToList(), dates);
                }
                //月不詳の場合
                if (vm.monthflg)
                {
                    dates = GetDateList(years.ToList(), unknownMonthTags, days.ToList(), dates);
                }
                //日不詳の場合
                if (vm.dayflg)
                {
                    dates = GetDateList(years.ToList(), months.ToList(), unknownDayTags, dates);
                }

                conditionModel.Sub(tablenm1, komokunm1, FrEnumValueOprator.IN, dates);
            }

            return cond.Or(conditionModel.EndSub());
        }
        /// <summary>
        /// 不詳日付リスト取得(各パターンごと)
        /// </summary>
        private static List<string> GetDateList(List<string> years, List<string> months, List<string> days, List<string> dates)
        {
            foreach (var year in years)
            {
                foreach (var month in months)
                {
                    foreach (var day in days)
                    {
                        dates.Add($"{year}-{month}-{day}");
                    }
                }
            }
            return dates;
        }
    }
}