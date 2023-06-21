using System;
using NUnit.Framework;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Common.T1.Tests.TestSupport;

namespace Rn.NetCore.Common.T1.Tests.Extensions;

[TestFixture]
public class DateExtensionsTests
{
  [Test]
  public void ToStartOfDay_Given_Date_ShouldReturn_ExpectedDate()
  {
    // arrange
    var baseDate = new DateTime(2021, 3, 27, 16, 45, 22, DateTimeKind.Utc);

    // act
    var startOfDay = baseDate.ToStartOfDay();

    // assert
    Assert.AreEqual(
      new DateTime(2021, 3, 27, 0, 0, 0, DateTimeKind.Utc),
      startOfDay);
  }

  [Test]
  public void ToStartOfMonth_Given_Date_ShouldReturn_ExpectedDate()
  {
    // arrange
    var baseDate = new DateTime(2021, 3, 27, 16, 45, 22, DateTimeKind.Utc);

    // act
    var startOfDay = baseDate.ToStartOfMonth();

    // assert
    Assert.AreEqual(new DateTime(2021, 3, 1, 0, 0, 0, DateTimeKind.Utc),
      startOfDay);
  }

  [TestCase("2021-06-02", "2021-06-04", DayOfWeek.Friday)]
  [TestCase("2021-06-04", "2021-06-11", DayOfWeek.Friday)]
  [TestCase("2021-06-04", "2021-06-10", DayOfWeek.Thursday)]
  [TestCase("2021-06-04", "2021-06-05", DayOfWeek.Saturday)]
  public void GetNextWeekDay_Given_Date_ShouldReturn_ExpectedDate(string baseDateStr, string expectedDateStr, DayOfWeek dayOfWeek)
  {
    // arrange
    var baseDate = Stub.UtcDateTime(baseDateStr);
    var expectedDate = Stub.UtcDateTime(expectedDateStr);

    // act
    var nextWeekDay = baseDate.GetNextWeekDay(dayOfWeek);

    // assert
    Assert.AreEqual(expectedDate, nextWeekDay);
  }

  [TestCase("2022-03-27 16:33:12", "2022-03-27T16:33:12.000Z", false)]
  [TestCase("2022-03-27 16:33:12", "2022-03-27T16:00:00.000Z", true)]
  public void AsWebUtcString_GivenValue_ShouldReturn_FormattedString(string input, string expected, bool replaceSeconds)
  {
    // Arrange
    var parsedDate = Stub.UtcDateTime(input);

    // Act
    var formatted = parsedDate.AsWebUtcString(replaceSeconds);

    // Assert
    Assert.AreEqual(expected, formatted);
  }

  [TestCase("2022-03-27 16:33:12", "2022-03-27")]
  public void AsUtcShortDate_GivenValue_ShouldReturn_FormattedString(string input, string expected)
  {
    // Arrange
    var parsedDate = Stub.UtcDateTime(input);

    // Act
    var formatted = parsedDate.AsUtcShortDate();

    // Assert
    Assert.AreEqual(expected, formatted);
  }
}
