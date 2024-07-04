// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: システム共通
//             区分列挙型
// 作成日　　: 2024.02.08
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.BatchService
{
    public enum ResultStatusCode
    {
        FAIL = -1,
        SUCCESS = 1
    }
    /// <summary>
    ///頻度区分 
    /// </summary>
    public enum EnumHinDoKBN
    {
        OneTime = 0,
        EveryDay = 1,       //1：毎日(毎日特定の時間に実行する)
        EveryWeek = 2,      //2：毎週(毎週特定の時間に実行する)
        EveryMonth = 3      //3.1 毎月
    }
    /// <summary>
    /// 繰り返し間隔
    /// </summary>
    public enum EnumIntervalType
    {
        Minutes5 = 1,       // 1：5分間
        Minutes10 = 2,      // 2：10分間
        Minutes15 = 3,      // 3：15分間
        Minutes30 = 4       // 4：30分間
    }



    #region 削除
    //毎日実行(祝日を含む,営業日を含む);
    //毎日の[特定の時刻]から始まり、[特定の時刻]まで;
    //毎日の[この時間帯]内、[一定の間隔で]繰り返し実行する;
    ////EveryDayRepeatByFixPeriod = 11,
    //EveryWeekRepeatByFixPeriod = 21,//21：毎週(毎週(毎週選択した曜日で、特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。)
    ////EveryMonthDaysAtATime = 31,//3.1 毎月の日
    //EveryMonthDaysRepeatByFixPeriod = 311,//3.1 毎月の日
    //EveryYearAtATime = 15,//15.毎月の月(毎年の月)
    //EveryMonthLastDay = 18, //18.毎月の最終日
    //EveryMonthWeeksAtATime = 19 //毎月、選択した週(週1,週2,週3,週4,週5)

    //public enum FrequencyDetailType
    //{
    //    DailyAtTime = 1, // 毎日実行し、毎日の特定の時間に実行する
    //    DailyByInterval = 2, // 毎日実行し、一日の間に一定の時間間隔で実行する
    //    WeeklyAtTime = 3, // 毎週選択された日にちの特定の時間
    //    WeeklyByInterval = 4 // 毎週選定された日数で、一定の時間間隔ごとに実行する
    //}

    //public enum KurikaeshikanFlg
    //{
    //    Minutes5 = 5,//0：5分間
    //    Minutes10 = 10,//1：10分間
    //    Minutes15 = 15,//2：15分間
    //    Minutes30 = 30,//3：30分間
    //    Minutes60 = 60//4：1時間
    //}
    #endregion

}