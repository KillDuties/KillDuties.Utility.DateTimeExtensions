using System;
using System.Collections.Generic;
using System.Globalization;

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

        public static bool IsLeapYear(this DateTime input)
            => DateTime.IsLeapYear(input.Year);

        /// <summary>
        /// Compare two DateTime have the same value of date part.
        /// </summary>
        /// <param name="input">DateTime input</param>
        /// <param name="value">DateTime to be compared with</param>
        /// <returns></returns>
        public static bool IsSameDate(this DateTime input, DateTime value)
            => input.Date == value.Date;

        /// <summary>
        /// Compare two DateTime have the same value of time part.
        /// </summary>
        /// <param name="input">DateTime input</param>
        /// <param name="value">DateTime to be compared with</param>
        /// <returns></returns>
        public static bool IsSameTime(this DateTime input, DateTime value)
            => input - input.Date == value - value.Date;

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

        public static double GetTimeZone => (DateTime.Now - DateTimeOffset.UtcNow).TotalHours;

        public static double ToUnixTime(this DateTime input)
            => input.CompareTo(new DateTime(1970, 1, 1), DateTimeDifferenceFormat.Seconds);

        public static int NextLeapYear(this DateTime input)
        {
            int i = 0;
            do
            {
                i++;
                if (input.AddYears(i).IsLeapYear())
                    return input.Year;
            } while (i > 8);
            return 0;
        }

        public static long CurrentUnixTime => DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        /// <summary>
        /// Return list of year, month and day after changing the calendar.
        /// </summary>
        /// <param name="input">DateTime input</param>
        /// <param name="format">Calendar format</param>
        /// <returns></returns>
        public static List<int> GetCalendarChangedList(this DateTime input, CalendarFormat format)
        {
            List<int> result = new List<int>();
            Calendar calendar = new GregorianCalendar();

            switch (format)
            {
                case CalendarFormat.ChineseLunisolar:
                    calendar = new ChineseLunisolarCalendar();
                    break;
                case CalendarFormat.Gregorian:
                    break;
                case CalendarFormat.Hebrew:
                    calendar = new HebrewCalendar();
                    break;
                case CalendarFormat.Hijri:
                    calendar = new HijriCalendar();
                    break;
                case CalendarFormat.Japanese:
                    calendar = new JapaneseCalendar();
                    break;
                case CalendarFormat.JapaneseLunisolar:
                    calendar = new JapaneseLunisolarCalendar();
                    break;
                case CalendarFormat.Julian:
                    calendar = new JulianCalendar();
                    break;
                case CalendarFormat.Korean:
                    calendar = new KoreanCalendar();
                    break;
                case CalendarFormat.KoreanLunisolar:
                    calendar = new KoreanLunisolarCalendar();
                    break;
                case CalendarFormat.Persian:
                    calendar = new PersianCalendar();
                    break;
                case CalendarFormat.Taiwan:
                    calendar = new TaiwanCalendar();
                    break;
                case CalendarFormat.TaiwanLunisolar:
                    calendar = new TaiwanLunisolarCalendar();
                    break;
                case CalendarFormat.ThaiBuddhist:
                    calendar = new ThaiBuddhistCalendar();
                    break;
                case CalendarFormat.UmAlQura:
                    calendar = new UmAlQuraCalendar();
                    break;
            }
            result.AddRange(new int[] { calendar.GetYear(input), calendar.GetMonth(input), calendar.GetDayOfMonth(input) });
            return result;
        }
    }

    public enum CalendarFormat
    {
        ChineseLunisolar,
        Gregorian,
        Hebrew,
        Hijri,
        Japanese,
        JapaneseLunisolar,
        Julian,
        Korean,
        KoreanLunisolar,
        Persian,
        Taiwan,
        TaiwanLunisolar,
        ThaiBuddhist,
        UmAlQura
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
