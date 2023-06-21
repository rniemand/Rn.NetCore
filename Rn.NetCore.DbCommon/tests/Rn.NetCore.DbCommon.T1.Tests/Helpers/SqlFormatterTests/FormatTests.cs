using NUnit.Framework;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers.SqlFormatterTests;

[TestFixture]
public class FormatTests
{
  private const string SampleSql = "SELECT * FROM Users WHERE UserId = @UserId";

  [Test]
  public void Format_GivenNoParameter_ShouldReturnOriginalQuery()
  {
    // arrange
    var formatter = TestHelper.GetSqlFormatter();

    // act
    var formatted = formatter.Format(SampleSql);

    // assert
    Assert.That(formatted, Is.EqualTo(SampleSql));
  }

  [Test]
  public void Format_GivenPlaceholderNotFound_ShouldReturnOriginalQuery()
  {
    // arrange
    var formatter = TestHelper.GetSqlFormatter();

    // act
    var formatted = formatter.Format(SampleSql, new
    {
      Something = 10
    });

    // assert
    Assert.That(formatted, Is.EqualTo(SampleSql));
  }

  [Test]
  public void Format_GivenPlaceholderFound_ShouldReturnFormattedQuery()
  {
    // arrange
    var formatter = TestHelper.GetSqlFormatter();
    var expected = SampleSql.Replace("@UserId", "10");

    // act
    var formatted = formatter.Format(SampleSql, new
    {
      UserId = 10
    });

    // assert
    Assert.That(formatted, Is.EqualTo(expected));
  }

  [Test]
  public void Format_GivenEnumValue_ShouldReturnFormattedQuery()
  {
    // arrange
    var formatter = TestHelper.GetSqlFormatter();
    var expected = SampleSql.Replace("@UserId", "15");

    // act
    var formatted = formatter.Format(SampleSql, new
    {
      UserId = TestEnum.HelloWorld
    });

    // assert
    Assert.That(formatted, Is.EqualTo(expected));
  }
}
