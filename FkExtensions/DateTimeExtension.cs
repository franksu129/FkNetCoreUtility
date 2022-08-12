namespace FkExtensions;
public static class DateTimeExtension
{
    public static string ToDefaultString(this DateTime time)
        => time.ToString("yyyy-MM-dd HH:mm:ss.fff");
    public static long ToTimeStamp(this DateTime time)
    {
        if (time == DateTime.MinValue)
            return 0;
        else
            return new DateTimeOffset(time).ToUnixTimeSeconds();
    }

    public static DateTime ToDateTime(this long time)
    {
        if (time == 0)
            return DateTime.MinValue;
        else
            return DateTimeOffset.FromUnixTimeSeconds(time).DateTime;
    }

    public static long ToMilliTimeStamp(this DateTime time)
    {
        if (time == DateTime.MinValue)
            return 0;
        else
            return new DateTimeOffset(time).ToUnixTimeMilliseconds();
    }

    public static DateTime StartOfDay(this DateTime time)
        => new DateTime(time.Year, time.Month, time.Day);

    public static DateTime EndOfDay(this DateTime time)
        => new DateTime(time.Year, time.Month, time.Day).AddDays(1).AddMilliseconds(-1);
}
