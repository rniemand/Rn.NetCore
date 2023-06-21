using System;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Common.T1.Tests.TestSupport;

public static class Stub
{
  private const string DateRegex01 = @"(\d{4})-(\d{1,2})-(\d{1,2})";
  private const string DateRegex02 = @"(\d{4})-(\d{1,2})-(\d{1,2}) (\d{1,2}):(\d{1,2}):(\d{1,2})";

  public static DateTime UtcDateTime(int year, int month, int day, int hour = 0, int min = 0, int sec = 0)
  {
    return new DateTime(year, month, day, hour, min, sec, DateTimeKind.Utc);
  }

  public static DateTime UtcDateTime(string dateString)
  {
    // TODO: [TESTS] (Stub.UtcDateTime) Add tests
    // TODO: [EXTRACT] (Stub.UtcDateTime) Create helper method for this
    var now = DateTime.UtcNow;

    var year = now.Year;
    var month = now.Month;
    var day = now.Day;
    var hour = 0;
    var min = 0;
    var seconds = 0;

    if (dateString.MatchesRegex(DateRegex01))
    {
      var matches = dateString.GetRegexMatch(DateRegex01);
      year = matches.Groups[1].Value.AsInt(year);
      month = matches.Groups[2].Value.AsInt(month);
      day = matches.Groups[3].Value.AsInt(day);
    }

    if (dateString.MatchesRegex(DateRegex02))
    {
      var matches = dateString.GetRegexMatch(DateRegex02);
      year = matches.Groups[1].Value.AsInt(year);
      month = matches.Groups[2].Value.AsInt(month);
      day = matches.Groups[3].Value.AsInt(day);
      hour = matches.Groups[4].Value.AsInt(hour);
      min = matches.Groups[5].Value.AsInt(min);
      seconds = matches.Groups[6].Value.AsInt(seconds);
    }

    return UtcDateTime(year, month, day, hour, min, seconds);
  }
}