using NUnit.Framework;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Common.Helpers;

namespace Rn.NetCore.Common.T1.Tests.Helpers;

[TestFixture]
public class RandomHelperTests
{
  [Test]
  public void RandomString_GivenCalled_ShouldReturn_GeneratedString()
  {
    // Arrange
    var helper = new RandomHelper();

    // Act
    var random1 = helper.RandomString(10, RandomHelper.Alpha);
    var random2 = helper.RandomString(5, RandomHelper.Numeric);
    var random3 = helper.RandomString(50);

    // Assert
    Assert.IsTrue(random1.MatchesRegex("\\w{10}"));
    Assert.IsTrue(random2.MatchesRegex("\\d{5}"));
    Assert.IsTrue(random3.MatchesRegex("\\w{50}"));
  }

  [Test]
  public void RandomInt_GivenCalled_ShouldReturnRandomInt()
  {
    // arrange
    var helper = new RandomHelper();

    // act
    var int1 = helper.RandomInt(1, 10);
    var int2 = helper.RandomInt(110);

    // assert
    Assert.That(int1, Is.GreaterThan(0).And.LessThan(11));
    Assert.That(int2, Is.GreaterThan(0).And.LessThan(111));
  }

  [Test]
  public void RandomFloat_GivenCalled_ShouldReturnRandomFloat()
  {
    // arrange
    var helper = new RandomHelper();

    // act
    var float1 = helper.RandomFloat(1, 10);

    // assert
    Assert.That(float1, Is.GreaterThan(0).And.LessThan(11));
  }

  [Test]
  public void RandomDouble_GivenCalled_ShouldReturnRandomDouble()
  {
    // arrange
    var helper = new RandomHelper();

    // act
    var double1 = helper.RandomDouble(1, 10);

    // assert
    Assert.That(double1, Is.GreaterThan(0).And.LessThan(11));
  }
}
