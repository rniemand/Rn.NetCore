using NUnit.Framework;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Common.T1.Tests.Extensions;

[TestFixture]
public class StringExtensionsTests
{
  [TestCase(null, "input")]
  [TestCase("", "input")]
  [TestCase(" ", "input")]
  [TestCase("put", "input")]
  [TestCase("s", "inputs")]
  public void AppendIfMissing_GivenInput_ShouldReturnExpected(string append, string expected)
    => Assert.AreEqual(expected, "input".AppendIfMissing(append));

  [TestCase(null, "")]
  [TestCase("", "")]
  [TestCase(" ", "")]
  [TestCase("hello", "hello")]
  [TestCase("hello ", "hello")]
  [TestCase("HELLO", "hello")]
  [TestCase("  HELLO", "hello")]
  [TestCase("HEllO", "hello")]
  public void LowerTrim_GivenBadInput_ShouldReturnExpected(string input, string expected)
    => Assert.AreEqual(expected, input.LowerTrim());

  [TestCase(null, "")]
  [TestCase("", "")]
  [TestCase(" ", "")]
  [TestCase("hello", "HELLO")]
  [TestCase("hello ", "HELLO")]
  [TestCase("HELLO", "HELLO")]
  [TestCase("  HELLO", "HELLO")]
  [TestCase("HEllO", "HELLO")]
  public void UpperTrim_GivenBadInput_ShouldReturnExpected(string input, string expected)
    => Assert.AreEqual(expected, input.UpperTrim());

  [TestCase("", true, true)]
  [TestCase(null, false, false)]
  [TestCase(" ", false, false)]
  [TestCase("true", true, false)]
  [TestCase("1", true, false)]
  [TestCase("On", true, false)]
  [TestCase("YES", true, false)]
  [TestCase("Enabled", true, false)]
  [TestCase("false", false, true)]
  [TestCase("0", false, true)]
  [TestCase("OFF", false, true)]
  [TestCase("Disabled", false, true)]
  [TestCase("NO", false, true)]
  [TestCase("Unsupported", false, false)]
  public void AsBool_GivenInput_ShouldReturnExpected(string input, bool expected, bool fallback)
    => Assert.AreEqual(expected, input.AsBool(fallback));

  [TestCase(null, 0, 0)]
  [TestCase("", 0, 0)]
  [TestCase(" ", 0, 0)]
  [TestCase("1", 1, 0)]
  [TestCase("12 ", 12, 0)]
  [TestCase("NaN", 0, 0)]
  public void AsInt_GivenInput_ShouldReturnExpected(string input, int expected, int fallback)
    => Assert.AreEqual(expected, input.AsInt(fallback));

  [TestCase(null, 0, 0)]
  [TestCase("", 0, 0)]
  [TestCase(" ", 0, 0)]
  [TestCase("1", 1, 0)]
  [TestCase("12 ", 12, 0)]
  [TestCase("NaN", 0, 0)]
  public void AsLong_GivenInput_ShouldReturnExpected(string input, long expected, long fallback)
    => Assert.AreEqual(expected, input.AsLong(fallback));

  [TestCase(null, 0, 0)]
  [TestCase("", 0, 0)]
  [TestCase(" ", 0, 0)]
  [TestCase("1", 1, 0)]
  [TestCase("12 ", 12, 0)]
  [TestCase("NaN", float.NaN, 0)]
  [TestCase("bob", 0, 0)]
  public void AsFloat_GivenInput_ShouldReturnExpected(string input, float expected, float fallback)
    => Assert.AreEqual(expected, input.AsFloat(fallback));

  [TestCase("bob", "", false)]
  [TestCase("bob", "BOB", true)]
  [TestCase("bob", "BoB", true)]
  [TestCase("", "", true)]
  [TestCase(null, "", false)]
  [TestCase("", null, false)]
  public void IgnoreCaseEquals_GivenInput_ShouldReturnExpected(string input, string compare, bool expected)
    => Assert.AreEqual(expected, input.IgnoreCaseEquals(compare));

  [TestCase("this is my search string", "bob", false)]
  [TestCase("this is my search string", "SEarCH", true)]
  [TestCase("this is my search string", "my ", true)]
  [TestCase("", "bob", false)]
  [TestCase(null, "", false)]
  [TestCase("", null, false)]
  public void IgnoreCaseContains_GivenInput_ShouldReturnExpected(string input, string search, bool expected)
    => Assert.AreEqual(expected, input.IgnoreCaseContains(search));

  [TestCase("this is my search string", "bob", false)]
  [TestCase("this is my search string", "STRING", true)]
  [TestCase("this is my search string", "ng", true)]
  [TestCase("", "bob", false)]
  [TestCase(null, "", false)]
  [TestCase("", null, false)]
  public void IgnoreCaseEndsWith_GivenInput_ShouldReturnExpected(string input, string ending, bool expected)
    => Assert.AreEqual(expected, input.IgnoreCaseEndsWith(ending));

  [TestCase("this is my search string", "bob", false)]
  [TestCase("this is my search string", "THIS", true)]
  [TestCase("this is my search string", "th", true)]
  [TestCase("", "bob", false)]
  [TestCase(null, "", false)]
  [TestCase("", null, false)]
  public void IgnoreCaseStartsWith_GivenInput_ShouldReturnExpected(string input, string start, bool expected)
    => Assert.AreEqual(expected, input.IgnoreCaseStartsWith(start));

  [TestCase("test", "bob", "test")]
  [TestCase(null, "bob", "bob")]
  [TestCase("", "bob", "bob")]
  [TestCase(" ", "bob", "bob")]
  public void FallbackTo_GivenInput_ShouldReturnExpected(string input, string fallback, string expected)
    => Assert.AreEqual(expected, input.FallbackTo(fallback));

  [TestCase(new byte[] { 1, 2 }, new byte[0], false)]
  [TestCase(new byte[] { 1, 2 }, new byte[] { 1, 2, 3 }, false)]
  [TestCase(new byte[] { 1, 2 }, new byte[] { 1, 2 }, true)]
  [TestCase(new byte[] { 2, 1 }, new byte[] { 1, 2 }, false)]
  public void SameByteArray_GivenInput_ShouldReturnExpected(byte[] input, byte[] compare, bool expected)
    => Assert.AreEqual(expected, input.SameByteArray(compare));
}