# KillDuties.Utility.DateTimeExtensions

## Objective

Create easy to use library for datetime operations.

## Framework

The code is written using VS 2019 with dotnet core 2.2. 

|C# Version | Supported          |
| --------- | ------------------ |
| >= 3.0    | :white_check_mark: |
| < 3.0     | :x:                |
  
|.Net Framwork Version | Supported          |
| -------------------- | ------------------ |
| >= 3.5               | :white_check_mark: |
| < 3.5                | :x:                |

|.Net Core Version | Supported          |
| ---------------- | ------------------ |
| >= 1.0           | :white_check_mark: |

## How to use

Add / copy the code file to your project, or build as assembly and include reference in your project.

## Warning

The project is still under development state and the code has not been well tested.

## Metadata View

```C#
namespace KillDuties.Utility
{
	public static class DateTimeExtensions
	{
		public static bool IsEarlierThan(this DateTime input, DateTime value);
		public static bool IsEndOfMonth(this DateTime input);
		public static bool IsEndOfWeek(this DateTime input, DayOfWeek weekEnd = DayOfWeek.Saturday);
		public static bool IsLaterThan(this DateTime input, DateTime value);
		public static bool IsLeapYear(this DateTime input);
		public static bool IsSameDate(this DateTime input, DateTime value);
        public static bool IsSameTime(this DateTime input, DateTime value);
		public static bool IsStartOfMonth(this DateTime input);
		public static bool IsStartOfWeek(this DateTime input, DayOfWeek weekStart = DayOfWeek.Sunday);
		public static bool WillChangeDate(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Hours);
		public static bool WillChangeMonth(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static bool WillChangeYear(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static DateTime Add(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static DateTime FromUnixTime(this int unixTimestamp);
		public static DateTime FromUnixTime(this double unixTimestamp);
		public static DateTime LastMonth(this DateTime input);
		public static DateTime LastWeek(this DateTime input);
		public static DateTime LastYear(this DateTime input);
		public static DateTime NextMonth(this DateTime input);
		public static DateTime NextWeek(this DateTime input);
		public static DateTime NextYear(this DateTime input);
		public static double CompareTo(this DateTime input, DateTime value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static double GetTimeZone;
		public static double ToUnixTime(this DateTime input);
		public static int WeekNumber(this DateTime input, CalendarWeekRule weekRule = CalendarWeekRule.FirstDay, DayOfWeek weekStart = DayOfWeek.Monday);
		public static int MaxWeekNumber(this DateTime input, CalendarWeekRule weekRule = CalendarWeekRule.FirstDay, DayOfWeek weekStart = DayOfWeek.Monday)
		public static int MaxWeekNumber(int year, CalendarWeekRule weekRule = CalendarWeekRule.FirstDay, DayOfWeek weekStart = DayOfWeek.Monday);
		public static int LastLeapYear(this DateTime input);
		public static int NextLeapYear(this DateTime input);
		public static long CurrentUnixTime;
		public static IEnumerable<DateTime> GetDateListInCurrentWeekNumber(this DateTime input, CalendarWeekRule weekRule = CalendarWeekRule.FirstDay, DayOfWeek weekStart = DayOfWeek.Monday);
		public static List<int> GetCalendarChangedList(this DateTime input, CalendarFormat format);
	}

	public enum CalendarFormat;
	public enum DateTimeDifferenceFormat;
}
```

## License
[MIT](https://github.com/KillDuties/KillDuties.Utility.StringExtensions/blob/master/LICENSE)
