using NUnit.Framework;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Common.T1.Tests.Extensions;

[TestFixture]
public class RegexExtensionsTests
{
  [TestCase("Hello world", @"\d{1,}", false)]
  [TestCase("2021-12-3", @"\d{1,}", true)]
  [TestCase("Hello World", @"\w+", true)]
  public void MatchesRegex_GivenCalled_ShouldReturn_ExpectedValue(string input, string regex, bool expected) =>
    Assert.AreEqual(expected, input.MatchesRegex(regex));

  [TestCase("\\w{1,}", true)]
  [TestCase("\\d{1,}", false)]
  public void GetRegexMatch_GivenValidExpression_ShouldReturnMatch(string pattern, bool expected) =>
    Assert.That("Hello world".GetRegexMatch(pattern).Success, Is.EqualTo(expected));

  [TestCase("\\w{1,}", 2)]
  [TestCase("\\d{1,}", 0)]
  public void GetRegexMatches_GivenValidExpression_ShouldReturnMatch(string pattern, int expected) =>
    Assert.That("Hello world".GetRegexMatches(pattern).Count, Is.EqualTo(expected));
}
