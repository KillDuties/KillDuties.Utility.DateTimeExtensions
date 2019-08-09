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
		public static bool IsStartOfMonth(this DateTime input);
		public static bool IsStartOfWeek(this DateTime input, DayOfWeek weekStart = DayOfWeek.Sunday);
		public static bool WillChangeMonth(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static DateTime Add(this DateTime input, double value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static DateTime FromUnixTime(this int unixTimestamp);
		public static DateTime FromUnixTime(this double unixTimestamp);
		public static double CompareTo(this DateTime input, DateTime value, DateTimeDifferenceFormat differenceFormat = DateTimeDifferenceFormat.Days);
		public static double CurrentUnixTime;
		public static double GetTimeZone;
		public static double ToUnixTime(this DateTime input);
	}

	public enum DateTimeDifferenceFormat;
}
```

## License
[MIT](https://github.com/KillDuties/KillDuties.Utility.StringExtensions/blob/master/LICENSE)
