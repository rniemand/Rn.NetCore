using System;
using NUnit.Framework;
using Rn.NetCore.Common.Helpers;

namespace Rn.NetCore.Common.T1.Tests.Helpers;

[TestFixture]
public class DateHelperTests
{
  [TestCase(null, DayOfWeek.Friday)]
  [TestCase("", DayOfWeek.Friday)]
  [TestCase(" ", DayOfWeek.Friday)]
  public void ToDayOfWeek_Given_InvalidInput_ShouldReturn_Fallback(string input, DayOfWeek fallback)
  {
    // act
    var dayOfWeek = DateHelper.ToDayOfWeek(input, fallback);

    // assert
    Assert.AreEqual(fallback, dayOfWeek);
  }

  [TestCase("mon,monday,1", DayOfWeek.Friday, DayOfWeek.Monday)]
  [TestCase("tue,tuesday,2", DayOfWeek.Friday, DayOfWeek.Tuesday)]
  [TestCase("wed,wednesday,3", DayOfWeek.Friday, DayOfWeek.Wednesday)]
  [TestCase("thu,thursday,4", DayOfWeek.Friday, DayOfWeek.Thursday)]
  [TestCase("fri,friday,5", DayOfWeek.Monday, DayOfWeek.Friday)]
  [TestCase("sat,saturday,6", DayOfWeek.Friday, DayOfWeek.Saturday)]
  [TestCase("sun,sunday,7,0", DayOfWeek.Friday, DayOfWeek.Sunday)]
  public void ToDayOfWeek_Given_ValidInput_ShouldReturn_CastDayOfWeek(string inputs, DayOfWeek fallback, DayOfWeek expected)
  {
    foreach (var input in inputs.Split(","))
    {
      Assert.AreEqual(expected, DateHelper.ToDayOfWeek(input, fallback));
      Assert.AreEqual(expected, DateHelper.ToDayOfWeek(input.ToUpper(), fallback));
      Assert.AreEqual(expected, DateHelper.ToDayOfWeek($" {input} ", fallback));
    }
  }

  [TestCase("unsupported", DayOfWeek.Friday, DayOfWeek.Friday)]
  public void ToDayOfWeek_Given_InvalidInput_ShouldReturn_Fallback(string inputs, DayOfWeek fallback, DayOfWeek expected)
  {
    foreach (var input in inputs.Split(","))
    {
      Assert.AreEqual(expected, DateHelper.ToDayOfWeek(input, fallback));
      Assert.AreEqual(expected, DateHelper.ToDayOfWeek(input.ToUpper(), fallback));
      Assert.AreEqual(expected, DateHelper.ToDayOfWeek($" {input} ", fallback));
    }
  }

  [TestCase(null)]
  [TestCase(" ")]
  [TestCase("")]
  [TestCase(",,,,")]
  public void ToDaysOfWeek_Given_BlankInput_ShouldReturn_EmptyArray(string input)
  {
    // act
    var daysOfWeek = DateHelper.ToDaysOfWeek(input, DayOfWeek.Sunday);

    // assert
    Assert.IsNotNull(daysOfWeek);
    Assert.IsInstanceOf<DayOfWeek[]>(daysOfWeek);
    Assert.AreEqual(0, daysOfWeek.Length);
  }

  [Test]
  public void ToDaysOfWeek_Given_DuplicateDays_ShouldReturn_UniqueValues()
  {
    // act
    var daysOfWeek = DateHelper.ToDaysOfWeek("mon,mon,mon", DayOfWeek.Sunday);

    // assert
    Assert.IsNotNull(daysOfWeek);
    Assert.IsInstanceOf<DayOfWeek[]>(daysOfWeek);
    Assert.AreEqual(1, daysOfWeek.Length);
    Assert.AreEqual(DayOfWeek.Monday, daysOfWeek[0]);
  }

  [Test]
  public void ToDaysOfWeek_Given_ValidInputs_ShouldReturn_OrderedDays()
  {
    // act
    var daysOfWeek = DateHelper.ToDaysOfWeek("wed,,mon,tuesday,,,", DayOfWeek.Sunday);

    // assert
    Assert.IsNotNull(daysOfWeek);
    Assert.IsInstanceOf<DayOfWeek[]>(daysOfWeek);
    Assert.AreEqual(3, daysOfWeek.Length);
    Assert.AreEqual(DayOfWeek.Monday, daysOfWeek[0]);
    Assert.AreEqual(DayOfWeek.Tuesday, daysOfWeek[1]);
    Assert.AreEqual(DayOfWeek.Wednesday, daysOfWeek[2]);
  }
}