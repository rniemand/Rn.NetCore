using System;

namespace Rn.NetCore.Common.Extensions;

// DOCS: docs\extensions\DateExtensions.md
public static class DateExtensions
{
  public static string AsWebUtcString(this DateTime date, bool replaceMinAndSecs = false)
  {
    var formattingMask = replaceMinAndSecs
      ? "yyyy'-'MM'-'dd'T'HH':00:00.000Z'"
      : "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

    return date.ToUniversalTime().ToString(formattingMask);
  }

  public static string AsUtcShortDate(this DateTime date)
  {
    var uDate = date.ToUniversalTime();

    return $"{uDate.Year}-" +
           $"{uDate.Month.ToString("D").PadLeft(2, '0')}-" +
           $"{uDate.Day.ToString("D").PadLeft(2, '0')}";
  }
  
  public static DateTime ToStartOfDay(this DateTime date)
    => new(date.Year, date.Month, date.Day, 0, 0, 0, date.Kind);

  public static DateTime ToStartOfMonth(this DateTime date)
    => new(date.Year, date.Month, 1, 0, 0, 0, date.Kind);

  public static DateTime GetNextWeekDay(this DateTime date, DayOfWeek dayOfWeek)
  {
    var tomorrow = date.AddDays(1);
    var daysUntil = ((int)dayOfWeek - (int)tomorrow.DayOfWeek + 7) % 7;
    return tomorrow.AddDays(daysUntil);
  }
}
