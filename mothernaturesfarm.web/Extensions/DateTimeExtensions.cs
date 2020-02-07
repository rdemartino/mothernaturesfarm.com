using System;

namespace mothernaturesfarm.web.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToString(this DateTime dateTime, string format, bool useExtendedSpecifiers)
        {
            return useExtendedSpecifiers
                ? dateTime.ToString(format)
                    .Replace("nn", dateTime.Day.ToOccurrenceSuffix().ToLower())
                    .Replace("NN", dateTime.Day.ToOccurrenceSuffix().ToUpper())
                : dateTime.ToString(format);
        }
    }
}