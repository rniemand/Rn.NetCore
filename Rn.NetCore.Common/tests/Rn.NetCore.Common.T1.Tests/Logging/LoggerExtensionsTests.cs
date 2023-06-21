using System;
using System.Text;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.Common.T1.Tests.Logging;

[TestFixture]
public class LoggerExtensionsTests
{
  private readonly Exception _testException = new("Whoops",
    new Exception("Inner exception 1",
      new Exception("Inner Exception 2")));

  [Test]
  public void HumanStackTrace_GivenCalled_ShouldGenerate_ExceptionString()
  {
    // Arrange
    var expected = new StringBuilder()
      .AppendLine("1 (System.Exception) Whoops")
      .AppendLine("    2 (System.Exception) Inner exception 1")
      .AppendLine("    3 (System.Exception) Inner Exception 2")
      .ToString();

    // Act
    var generated = _testException.HumanStackTrace();

    // Assert
    Assert.AreEqual(expected, generated);
  }

  [Test]
  public void GetFullMethodName_GivenCalled_ShouldReturn_ExpectedName() =>
    Assert.AreEqual("Rn.NetCore.Common.Logging.LoggerExtensions.GetFullMethodName",
      LoggerExtensions.GetFullMethodName(0));

  [Test]
  public void LogUnexpectedException_GivenCalled_ShouldGenerateExpectedException()
  {
    // Arrange
    var logger = Substitute.For<ILoggerAdapter<LoggerExtensionsTests>>();
    var ex = new Exception("Whoops");

    // Act
    logger.LogUnexpectedException(ex);

    // Assert
    logger.Received(1).LogError(
      "An unexpected exception of type {exType} was thrown in {method}. {exMessage}. | {exStack}",
      ex.GetType().Name,
      "Rn.NetCore.Common.T1.Tests.Logging.LoggerExtensionsTests.LogUnexpectedException_GivenCalled_ShouldGenerateExpectedException",
      ex.Message,
      ex.HumanStackTrace());
  }
}
