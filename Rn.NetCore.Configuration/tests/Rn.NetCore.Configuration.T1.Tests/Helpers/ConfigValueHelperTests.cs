using NUnit.Framework;
using Rn.NetCore.Configuration.Enums;
using Rn.NetCore.Configuration.Helpers;
using Rn.NetCore.Configuration.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.Configuration.T1.Tests.Helpers;

[TestFixture]
public class ConfigValueHelperTests
{
  // Int
  [TestCase(int.MinValue, "-2147483648")]
  [TestCase(int.MaxValue, "2147483647")]
  public void FromInt_Given_Value_ShouldReturn_String(int input, string expected)
    => Assert.AreEqual(expected, ConfigValueHelper.FromLong(input));

  [TestCase(int.MinValue, "-2147483648", true)]
  [TestCase(int.MaxValue, "2147483647", true)]
  [TestCase(0, "hello world", false)]
  public void TryExtractInt_Given_String_ShouldReturn_ExpectedResult(int expected, string input, bool shouldParse)
  {
    // arrange
    var configEntity = new ConfigurationEntityBuilder()
      .WithDefaults()
      .WithType(ConfigurationType.Int)
      .WithValue(input)
      .Build();

    // act
    var success = ConfigValueHelper.TryExtractInt(configEntity, out var parsed);

    // assert
    Assert.AreEqual(shouldParse, success);
    Assert.AreEqual(expected, parsed);
  }


  // Long
  [TestCase(long.MinValue, "-9223372036854775808")]
  [TestCase(long.MaxValue, "9223372036854775807")]
  public void FromLong_Given_Value_ShouldReturn_String(long input, string expected)
    => Assert.AreEqual(expected, ConfigValueHelper.FromLong(input));

  [TestCase(long.MinValue, "-9223372036854775808", true)]
  [TestCase(long.MaxValue, "9223372036854775807", true)]
  [TestCase(0, "hello world", false)]
  public void TryExtractLong_Given_String_ShouldReturn_ExpectedResult(long expected, string input, bool shouldParse)
  {
    // arrange
    var configEntity = new ConfigurationEntityBuilder()
      .WithDefaults()
      .WithType(ConfigurationType.Long)
      .WithValue(input)
      .Build();

    // act
    var success = ConfigValueHelper.TryExtractLong(configEntity, out var parsed);

    // assert
    Assert.AreEqual(shouldParse, success);
    Assert.AreEqual(expected, parsed);
  }


  // Float
  [TestCase(float.MinValue, "-340,282,346,638,528,859,811,704,183,484,516,925,440.00")]
  [TestCase(float.MaxValue, "340,282,346,638,528,859,811,704,183,484,516,925,440.00")]
  public void FromFloat_Given_Value_ShouldReturn_String(float input, string expected)
    => Assert.AreEqual(expected, ConfigValueHelper.FromFloat(input));

  [TestCase(float.MinValue, "-340,282,346,638,528,859,811,704,183,484,516,925,440.00", true)]
  [TestCase(float.MaxValue, "340,282,346,638,528,859,811,704,183,484,516,925,440.00", true)]
  [TestCase(0, "hello world", false)]
  public void TryExtractFloat_Given_String_ShouldReturn_ExpectedResult(float expected, string input, bool shouldParse)
  {
    // arrange
    var configEntity = new ConfigurationEntityBuilder()
      .WithDefaults()
      .WithType(ConfigurationType.Float)
      .WithValue(input)
      .Build();

    // act
    var success = ConfigValueHelper.TryExtractFloat(configEntity, out var parsed);

    // assert
    Assert.AreEqual(shouldParse, success);
    Assert.AreEqual(expected, parsed);
  }


  // Double
  [TestCase(-9223372036854775807d, "-9,223,372,036,854,775,808.00")]
  [TestCase(9223372036854775807d, "9,223,372,036,854,775,808.00")]
  public void FromDouble_Given_Value_ShouldReturn_String(double input, string expected)
    => Assert.AreEqual(expected, ConfigValueHelper.FromDouble(input));

  [TestCase(-9223372036854775807d, "-9,223,372,036,854,775,808.00", true)]
  [TestCase(9223372036854775807d, "9,223,372,036,854,775,808.00", true)]
  [TestCase(0, "hello world", false)]
  public void TryExtractDouble_Given_String_ShouldReturn_ExpectedResult(double expected, string input, bool shouldParse)
  {
    // arrange
    var configEntity = new ConfigurationEntityBuilder()
      .WithDefaults()
      .WithType(ConfigurationType.Double)
      .WithValue(input)
      .Build();

    // act
    var success = ConfigValueHelper.TryExtractDouble(configEntity, out var parsed);

    // assert
    Assert.AreEqual(shouldParse, success);
    Assert.AreEqual(expected, parsed);
  }
}