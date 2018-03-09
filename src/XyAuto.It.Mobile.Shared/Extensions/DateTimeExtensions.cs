using System;

namespace XyAuto.It.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? GetEndOfDate(this DateTime? date)
        {
            return date?.Date.AddDays(1).AddTicks(-1);
        }
    }
}
