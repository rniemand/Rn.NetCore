using System;
using System.Collections.Generic;
using System.Linq;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Common.Helpers;

// DOCS: docs\helpers\DateHelper.md
public static class DateHelper
{
  public static DayOfWeek ToDayOfWeek(string input, DayOfWeek fallback)
  {
    if (string.IsNullOrWhiteSpace(input))
      return fallback;

    return input.LowerTrim() switch
    {
      "mon" => DayOfWeek.Monday,
      "monday" => DayOfWeek.Monday,
      "1" => DayOfWeek.Monday,

      "tue" => DayOfWeek.Tuesday,
      "tuesday" => DayOfWeek.Tuesday,
      "2" => DayOfWeek.Tuesday,
        
      "wed" => DayOfWeek.Wednesday,
      "wednesday" => DayOfWeek.Wednesday,
      "3" => DayOfWeek.Wednesday,
        
      "thu" => DayOfWeek.Thursday,
      "thursday" => DayOfWeek.Thursday,
      "4" => DayOfWeek.Thursday,
        
      "fri" => DayOfWeek.Friday,
      "friday" => DayOfWeek.Friday,
      "5" => DayOfWeek.Friday,
        
      "sat" => DayOfWeek.Saturday,
      "saturday" => DayOfWeek.Saturday,
      "6" => DayOfWeek.Saturday,
        
      "sun" => DayOfWeek.Sunday,
      "sunday" => DayOfWeek.Sunday,
      "7" => DayOfWeek.Sunday,
      "0" => DayOfWeek.Sunday,
        
      _ => fallback
    };
  }

  public static DayOfWeek[] ToDaysOfWeek(string input, DayOfWeek fallback)
  {
    if (string.IsNullOrWhiteSpace(input))
      return Array.Empty<DayOfWeek>();

    var parts = input.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 0)
      return Array.Empty<DayOfWeek>();

    var dayOfWeeks = new List<DayOfWeek>();

    foreach (var part in parts)
    {
      var castDow = ToDayOfWeek(part, fallback);
      if (!dayOfWeeks.Contains(castDow)) dayOfWeeks.Add(castDow);
    }

    return dayOfWeeks.OrderBy(x => x).ToArray();
  }
}
