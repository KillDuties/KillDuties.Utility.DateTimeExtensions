using System;

namespace KillDuties.Utility
{
    public static class DateTimeExtensions
    {
        public static bool IsEarlierThan(this DateTime input, DateTime value)
            => input.CompareTo(value) < 0;

        public static bool IsEndOfMonth(this DateTime input)
            => input.Day == DateTime.DaysInMonth(input.Year, input.Month);

        public static bool IsEndOfWeek(this DateTime input, DayOfWeek weekEnd = DayOfWeek.Saturday)
            => input.DayOfWeek == weekEnd;

        public static bool IsLaterThan(this DateTime input, DateTime value)
            => input.CompareTo(value) > 0;

        public static bool IsStartOfMonth(this DateTime input)
            => input.Day == 1;

        public static bool IsStartOfWeek(this DateTime input, DayOfWeek weekStart = DayOfWeek.Sunday)
            => input.DayOfWeek == weekStart;

        /// <summary>
        /// Check after the month is changed when adding / subtracting a value of DateTimeDifferenceFormat.
        /// </summary>
        /// <param name="input">DateTime input</param>
        /// <param name="value">Value to be adding / subtracting</param>
        /// <param name="differenceFormat">DateTime difference format</param>
        /// <returns></returns>
        public static bool WillChangeMonth(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days)
            => input.Month != input.Add(value, differenceFormat).Month;

        public static DateTime Add(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days)
        {
            switch (differenceFormat)
            {
                case DateTimeDifferenceFormat.Days:
                    return input.AddDays(value);
                case DateTimeDifferenceFormat.Hours:
                    return input.AddHours(value);
                case DateTimeDifferenceFormat.Milliseconds:
                    return input.AddMilliseconds(value);
                case DateTimeDifferenceFormat.Minutes:
                    return input.AddMinutes(value);
                case DateTimeDifferenceFormat.Months:
                    return input.AddMonths(Convert.ToInt32(value));
                case DateTimeDifferenceFormat.Seconds:
                    return input.AddSeconds(value);
                case DateTimeDifferenceFormat.Weeks:
                    return input.AddDays(value * 7);
                case DateTimeDifferenceFormat.Years:
                    return input.AddYears(Convert.ToInt32(value));
            }
            return DateTime.Now;
        }

        public static DateTime FromUnixTime(this int unixTimestamp)
            => new DateTime(1970, 1, 1).Add(unixTimestamp, DateTimeDifferenceFormat.Seconds);

        public static DateTime FromUnixTime(this double unixTimestamp)
            => new DateTime(1970, 1, 1).Add(unixTimestamp, DateTimeDifferenceFormat.Seconds);

        public static double CompareTo(this DateTime input, DateTime value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days)
        {
            TimeSpan result = input - value;
            switch (differenceFormat)
            {
                case DateTimeDifferenceFormat.Days:
                    return result.TotalDays;
                case DateTimeDifferenceFormat.Hours:
                    return result.TotalHours;
                case DateTimeDifferenceFormat.Milliseconds:
                    return result.TotalMilliseconds;
                case DateTimeDifferenceFormat.Minutes:
                    return result.TotalMinutes;
                case DateTimeDifferenceFormat.Months:
                    return result.TotalDays / 30;
                case DateTimeDifferenceFormat.Seconds:
                    return result.TotalSeconds;
                case DateTimeDifferenceFormat.Weeks:
                    return result.TotalDays / 7;
                case DateTimeDifferenceFormat.Years:
                    return result.TotalDays / 365;
            }
            return 0;
        }

        public static double CurrentUnixTime => DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        public static double GetTimeZone => (DateTime.Now - DateTimeOffset.UtcNow).TotalHours;

        public static double ToUnixTime(this DateTime input)
            => input.CompareTo(new DateTime(1970, 1, 1), DateTimeDifferenceFormat.Seconds);
    }

    public enum DateTimeDifferenceFormat
    {
        Milliseconds,
        Seconds,
        Minutes,
        Hours,
        Days,
        Weeks,
        Months,
        Years
    }
}
