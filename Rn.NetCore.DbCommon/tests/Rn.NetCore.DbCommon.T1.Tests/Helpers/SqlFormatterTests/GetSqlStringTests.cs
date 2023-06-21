using System;
using NUnit.Framework;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers.SqlFormatterTests;

[TestFixture]
public class GetSqlStringTests
{
  [TestCase(15, "15")]
  [TestCase(2147483647, "2147483647")]
  [TestCase("Hello", "'Hello'")]
  [TestCase((long)10, "10")]
  [TestCase(9223372036854775807, "9223372036854775807")]
  [TestCase(10.1, "10.10")]
  [TestCase((double)10, "10")]
  [TestCase(true, "1")]
  [TestCase(false, "0")]
  public void GetSqlString_GivenObjectValue_ShouldReturnExpectedValue(object date, string expected)
  {
    Assert.That(SqlFormatter.GetSqlString(date), Is.EqualTo(expected));
  }

  [Test]
  public void GetSqlString_GivenDateTime_ShouldReturnExpectedValue()
  {
    var dateTime = new DateTime(2022,2,2,14,5,12, DateTimeKind.Utc);
    Assert.That(SqlFormatter.GetSqlString(dateTime), Is.EqualTo("'2022-02-02T14:05:12.0000000Z'"));
  }
}
