namespace BCC.Affect.BatchService
{
    public static class BtUtil
    {
        public static DateTime GetJapanTime(DateTime executeTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(executeTime.ToUniversalTime(), DaConst.TOKYO_TIME_ZONE_INFO);
        }
    }
}