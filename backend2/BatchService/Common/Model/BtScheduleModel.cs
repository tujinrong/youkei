// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: バッチ共通モデルクラス
//            
// 作成日　　: 
// 作成者　　: 
// 変更履歴　: 
// *******************************************************************

using NPOI.Util;

namespace BCC.Affect.BatchService
{

    /// <summary>
    /// バッチスケジュールモデル
    /// </summary>
    public class BtScheduleModel
    {
        /// <summary>
        /// 祝日次営業日実行フラグ 0:しない　1:する
        /// </summary>
        public bool syukustopflg { get; set; }

        /// <summary>
        /// 有効開始日
        /// </summary>
        public DateTime yukoymdf { get; set; }

        /// <summary>
        /// 有効開始時間
        /// </summary>
        public TimeSpan yukotmf { get; set; }

        //有効開始日時
        public DateTime StartTime => yukoymdf + yukotmf;

        /// <summary>
        /// 頻度区分[0：一回のみ、1：毎日、2：毎週、3：毎月]
        /// </summary>
        public EnumHinDoKBN hindokbn { get; set; }

        /// <summary>
        /// 毎週の曜日
        /// </summary>
        public List<int> yobi { get; set; }

        /// <summary>
        /// 毎月の日
        /// </summary>
        public List<int> maitukituki { get; set; }

        /// <summary>
        /// 月末設定あり
        /// </summary>
        public bool IsMonthEnd {  get; set; }

        /// <summary>
        /// 毎月の週
        /// </summary>
        public List<int> maitukisyu { get; set; }

        /// <summary>
        /// 引数
        /// </summary>
        public string hikisu { get; set; }

        /// <summary>
        /// 繰り返しフラグ 0:しない　1:する
        /// </summary>
        public bool kurikaeshikanFlg { get; set; }


        /// <summary>
        /// 繰り返し間隔区分 0：5分間、1：10分間、2：15分間、3：30分間、4：1時間
        /// </summary>
        public EnumIntervalType kurikaesikankbn { get; set; }

        public int GetMinIntv()
        {
            switch (kurikaesikankbn)
            {
                case EnumIntervalType.Minutes5: return 5;
                case EnumIntervalType.Minutes10: return 10;
                case EnumIntervalType.Minutes15: return 15;
                case EnumIntervalType.Minutes30: return 30;
                default: return 60;
            }
        }

        /// <summary>
        /// 選択された年中の月
        /// </summary>
        public List<int> maitukihi { get; set; } =new List<int>();

        /// <summary>
        /// 時間帯開始_時
        /// </summary>
        public int beginhour { get; set; }

        /// <summary>
        /// 時間帯終了_時
        /// </summary>
        public int endhour { get; set; }

        /// <summary>
        /// 時間内開始_分
        /// </summary>
        public int beginminute { get; set; }

        /// <summary>
        /// 時間内終了_分
        /// </summary>
        public int endminute { get; set; }

        public string GetCorn(DaDbContext db, DateTime holidayStartDay)
        {
            switch (hindokbn)
            {
                case EnumHinDoKBN.OneTime:
                    return GetOneTime();
                case EnumHinDoKBN.EveryDay:
                    return GetEveryDay();

                //2：毎週(毎週特定の時間に実行する)
                case EnumHinDoKBN.EveryWeek:
                    return (syukustopflg) ? 
                        GetEveryWeek_Holiday(db, holidayStartDay) 
                        : GetEveryWeek();

                //3 毎月の日
                case EnumHinDoKBN.EveryMonth:
                    //祝日及び月末の場合、一カ月分だけ作成する。
                    return (syukustopflg || IsMonthEnd) ? 
                        GetEveryMonth_Holiday(db, holidayStartDay) 
                        : GetEveryMonth();

                default:
                    throw new ArgumentException();
            }
        }


        //一回のみ特定の時間に実行する
        private string GetOneTime()
        {
            return GetCornString($"{StartTime.Day} {StartTime.Month} *");
        }


        //毎日特定の時間に実行する
        private string GetEveryDay()
        {
            return GetCornString($"* * *");
        }

        /// <summary>
        /// 毎週　（祝日次営業日実行)
        /// </summary>
        private string GetEveryWeek_Holiday(DaDbContext db, DateTime startDay)
        {
            var dt = (yukoymdf > DateTime.Today) ? yukoymdf : DateTime.Today;
            return GetSpecialCorn_Week(db, startDay);
        }

        /// <summary>
        /// 毎週
        /// </summary>
        private string GetEveryWeek()
        {
            List<int> listWeekDays = this.yobi;
            string weekDays = string.Join(",", listWeekDays);

            return GetCornString($"* * {weekDays}");
        }

        private string GetEveryMonth_Holiday(DaDbContext db, DateTime startDay)
        {
            var dt = (yukoymdf > DateTime.Today) ? yukoymdf : DateTime.Today;
            return GetSpecialCorn_Month(db, startDay, IsMonthEnd);
        }

        /// <summary>
        /// 毎月
        /// </summary>
        private string GetEveryMonth()
        {
            List<int> listMonthDays = this.maitukituki;
            string MM = string.Join(",", listMonthDays);


            string WW = "*";
            if (this.yobi.Count > 0)
            {
                WW = string.Join(",", yobi);
            }

            string DD = "*";
            if (this.maitukihi.Count > 0)
            {
                DD = string.Join(",", this.maitukihi);
            }

            return GetCornString($"{DD} {MM} {WW}");
        }

        public string GetCornString(string DMW)
        {
            if (kurikaeshikanFlg)
            {
                //繰り返しの場合
                //開始分/間隔　開始時 - 終了時
                var vm = GetMinIntv();
                return $"{beginminute}-{endminute}/{vm} {beginhour}-{endhour} {DMW}";
               
            }
            else
            {
                //一日1回の場合
                return $"{StartTime.Minute} {StartTime.Hour} {DMW}";
            }
        }

        private string GetSpecialCorn_Month(DaDbContext db, DateTime startDate, bool isMonthEnd)
        {
            List<int> list = maitukihi.Copy();
            var todayd = startDate.Day;
            var thism = startDate.Month;
            var today = DateTime.Today;
            //このタスクのスケジュールを設定し直す
            if (isMonthEnd)
            {
                var next = DateTime.Today.AddMonths(1);
                var next1 = new DateTime(next.Year, next.Month, 1);
                var lastDay = next1.AddDays(-1).Day;
                if (list.Contains(lastDay)==false)
                {
                    list.Add(lastDay);
                }
            }
            foreach (int day in maitukihi)
            {
                if (day <= todayd)
                {
                    //来月の日は稼働日か確認
                    var nextm=today.AddMonths(1);
                    var dt = new DateTime(nextm.Year, nextm.Month, day);
                    if (BtHolidayService.IsHoliday(db, dt))
                    {
                        var dt2=BtHolidayService.GetNextWorkDay(db, dt);
                        var day2=dt2.Day;
                        if (list.Contains(day2)==false)
                        {
                            list.Add(day2);
                        }
                    }

                }
                else
                {
                    //当月残りの日は稼働日かを確認
                    var dt = new DateTime(today.Year, today.Month, day);
                    if (BtHolidayService.IsHoliday(db, dt))
                    {
                        var dt2 = BtHolidayService.GetNextWorkDay(db, dt);
                        var day2 = dt2.Day;
                        if (list.Contains(day2) == false)
                        {
                            list.Add(day2);
                        }
                    }
                }
            }

            string DD = "*";
            if (this.maitukihi.Count > 0)
            {
                DD = string.Join(",", list);
            }

            return GetCornString($"{DD} * *");
        }

        private string GetSpecialCorn_Week(DaDbContext db, DateTime startDate)
        {
            List<int> list =new List<int>();
            var todayd = startDate.Day;
            var thism = startDate.Month;
            var today = DateTime.Today;
            //このタスクのスケジュールを設定し直す
            for (int day = todayd; day <= 31; day++)
            {
                //当月残りの日は稼働日かを確認
                var nextm = today.AddMonths(1);
                var maxd=new DateTime(nextm.Year, nextm.Month, 1).AddDays(-1).Day;
                if (day > maxd) break;
                var dt = new DateTime(today.Year, today.Month, day);
                var weekday = (int)dt.DayOfWeek;
                if (yobi.Contains(weekday))
                {

                    if (BtHolidayService.IsHoliday(db, dt))
                    {
                        var dt2 = BtHolidayService.GetNextWorkDay(db, dt);
                        var day2 = dt2.Day;
                        if (list.Contains(day2) == false)
                        {
                            list.Add(day2);
                        }
                    }
                    else {
                        if (list.Contains(day) == false)
                        {
                            list.Add(day);
                        }
                    }
                }
            }
            for (int day = 1; day < todayd; day++)
            {
                //来月の日は稼働日か確認
                var nextm = today.AddMonths(1);
                var maxd = new DateTime(nextm.Year, nextm.Month, 1).AddDays(-1).Day;
                if (day > maxd) break;

                var dt = new DateTime(nextm.Year, nextm.Month, day);
                var weekday=(int)dt.DayOfWeek;
                if (yobi.Contains(weekday))
                {
                    if (BtHolidayService.IsHoliday(db, dt))
                    {
                        var dt2 = BtHolidayService.GetNextWorkDay(db, dt);
                        var day2 = dt2.Day;
                        if (list.Contains(day2) == false)
                        {
                            list.Add(day2);
                        }
                    }
                    else
                    {
                        if (list.Contains(day) == false)
                        {
                            list.Add(day);
                        }
                    }
                }
            }

            string DD = "*";
            if (list.Count > 0)
            {
                DD = string.Join(",", list);
            }
            //string DD = string.Join(",", list);
            return GetCornString($"{DD} * *");
        }
        #region 削除
        //20240301 RIN DEL
        //public enum Duration
        //{
        //    UnLimited = 0,      // 0：無期限
        //    Minutes15 = 1,      // 1：15分間
        //    Minutes30 = 2,      // 2：30分間
        //    Hour1 = 3,          // 3：1時間
        //    Hour12 = 4,         // 4：12時間
        //    Day1 = 5,           // 5：1日間
        //}
        #region comments

        //public int taskstarthour24 { get; set; } //

        //public int taskstartminutes { get; set; } //

        //public int hour24 { get; set; }

        //public int minute { get; set; }

        //public int duration { get; set; } // 継続時間 0：無期限、1：15分間、2：30分間、3：1時間、4：12時間、5：1日間

        //public int taskavailablehours { get; set; }

        //public DateTime taskendtime { get; set; } //

        //public int taskendhour24 { get; set; } //

        //public int taskendminutes { get; set; } //

        //public List<WeekFrequency> weekfrequency { get; set; } //

        //public List<MonthFrequency> listmonthlyfrequency { get; set; } //

        //public int kankakunichi { get; set; } // 間隔日 実行頻度が「1：毎日」の場合に設定する。

        //public int kankakusyu { get; set; } //間隔週 実行頻度が「2：毎週」の場合に設定する。

        #endregion

        ////3.1 毎月の日
        //case EnumHinDoKBN.EveryMonthDaysRepeatByFixPeriod:
        //    return EveryMonthDaysRepeatByFixPeriod();

        //////3.2 毎月の曜日
        ////case "32":
        ////    return EveryMonthWeekDaysAtATime();
        //////3.2 毎月の曜日
        ////case "321":
        ////    return EveryMonthWeekDaysRepeatByFixPeriod();

        ////15.毎月の月(毎年の月)
        //case EnumHinDoKBN.EveryYearAtATime:
        //    return EveryYearAtATime();

        ////18.毎月の最終日
        //case EnumHinDoKBN.EveryMonthLastDay:
        //    return GetEveryDayAtATime();

        ////19.毎月、選択した週(週1,週2,週3,週4,週5)
        //case EnumHinDoKBN.EveryMonthWeeksAtATime:
        //    return GetEveryDayAtATime();

        //20.毎月の最終週
        //毎日(特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。
        private string GetEveryDayRepeatByFixPeriod()
            {
                var intervalType = this.kurikaesikankbn;

                //毎日(特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。
                if ((int)intervalType != 4)
                {
                    int intervalMinutes = GetIntervalMinutes(intervalType);

                    return $"*/{intervalMinutes} {beginhour}-{endhour} * * *";
                    //return "*/" + intervalMinutes + " " + this.beginhour + "-" + this.endhour + " * * *";
                }
                //毎日(特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。一定の分数間隔:1時間
                else
                {
                    return $"0 {beginhour}-{endhour} * * *";
                    //return "0 " + this.beginhour + "-" + this.endhour + " * * *";
                }
            }


            //毎週選択した曜日で、毎日一定の間隔で実行
            private string GetEveryWeekRepeatByFixPeriod()
            {
                List<int> listWeekDays = this.yobi;
                string weekDays = string.Join(",", listWeekDays);

                var intervalType = this.kurikaesikankbn;

                //毎日(特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。
                if ((int)intervalType != 4)
                {
                    int intervalMinutes = GetIntervalMinutes(intervalType);

                    return $"*/{intervalMinutes} {beginhour}-{endhour} * * {weekDays}";
                    //return "*/" + intervalMinutes + " " + this.beginhour + "-" + this.endhour + " * * " + weekDays;
                }
                //毎日(特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。一定の分数間隔:1時間
                else
                {
                    return "0 " + this.beginhour + "-" + this.endhour + " * * " + weekDays;
                    //return "0 " + this.beginhour + "-" + this.endhour + " * * " + weekDays;
                }
            }


            //毎月の指定された日に、ある時間から別の時間まで、一定の間隔で実行
            //private string EveryMonthDaysRepeatByFixPeriod()
            //{
            //    List<int> listMonthDays = this.maitukituki;
            //    string monthDays = string.Join(",", listMonthDays);

            //    var intervalType = this.kurikaesikankbn;
            //    int intervalMinutes = GetIntervalMinutes(intervalType);

            //    int startHour = this.yukotm.Hour;

            //    DateTime endDateTime = GetEndTimeByStartTimeAndDuration(this.yukotm);
            //    int endHour = endDateTime.Hour;

            //    return $"*/{intervalMinutes} {startHour}-{endHour} {monthDays} * *";
            //    //return "*/" + intervalMinutes + " " + startHour + "-" + endHour + " " + monthDays + " * *";
            //}


            //private string EveryMonthWeekDaysAtATime()
            //{
            //    return GetEveryWeekAtATime();
            //}

            //private string EveryMonthWeekDaysRepeatByFixPeriod()
            //{
            //    return GetEveryWeekRepeatByFixPeriod();
            //}

            //private string EveryYearAtATime()
            //{
            //    string strMonths = string.Join(",", this.maitukihi);

            //    List<int> listMonthDays = this.maitukituki;
            //    string monthDays = string.Join(",", listMonthDays);

            //    return $"{startdttm.Minute} {startdttm.Hour} {monthDays} {strMonths} *";
            //    //return startdttm.Minute + " " + startdttm.Hour + " " + monthDays + " " + strMonths + " *";
            //}


            public int GetIntervalMinutes(EnumIntervalType intervalType)
            {
                int nIntervalMinutes = 0;

                if ((int)intervalType == -2)
                {
                    nIntervalMinutes = 1;
                }
                else if ((int)intervalType == -1)
                {
                    nIntervalMinutes = 2;
                }
                else if ((int)intervalType == 0)
                {
                    nIntervalMinutes = 5;
                }
                else if ((int)intervalType == 1)
                {
                    nIntervalMinutes = 10;
                }
                else if ((int)intervalType == 2)
                {
                    nIntervalMinutes = 15;
                }
                else if ((int)intervalType == 3)
                {
                    nIntervalMinutes = 30;
                }

                return nIntervalMinutes;
            }

            private DateTime GetEndTimeByStartTimeAndDuration(DateTime startTime)
            {
                DateTime endTime = DateTime.MinValue;
                //20240301 RIN DEL todo start
                //var duration = this.keizokujikan;
                ////if ((int)duration == 1)
                ////{
                ////    endTime = startTime.AddMinutes(15);
                ////}
                ////if ((int)duration == 2)
                ////{
                ////    endTime = startTime.AddMinutes(30);
                ////}
                //if ((int)duration == 3)
                //{
                //    endTime = startTime.AddHours(1);
                //}
                //if ((int)duration == 4)
                //{
                //    endTime = startTime.AddHours(12);
                //}
                //20240301 RIN DEL todo end
                return endTime;
            }

            private string GetEveryYear()
            {
                string cron = "";
                return cron;
            }

            private string GetWeekDaysEveryMonth()
            {
                string cron = "";
                return cron;
            }

            private string GetMonthsEveryYear()
            {
                string cron = "";
                return cron;
            }

            private string GetLastDayEveryMonth()
            {
                string cron = "";
                return cron;
            }

            private string GetLastWeekEveryMonth()
            {
                string cron = "";
                return cron;
            }
            #endregion
        }
    }