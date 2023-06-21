using System;
using System.Data;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers.SqlFormatterTests;

[TestFixture]
public class GetLoggableErrorTests
{
  private const string DatabaseName = "MyDB";
  private const string SampleSql = "SELECT * FROM Users WHERE UserId = @UserId";

  [Test]
  public void GetLoggableError_GivenCalled_ShouldGenerateExpectedMessage()
  {
    // arrange
    var dbConnection = Substitute.For<IDbConnection>();
    var ex = new Exception("Whoops");

    dbConnection.Database.Returns(DatabaseName);

    // act
    var formatter = TestHelper.GetSqlFormatter();
    var error = formatter.GetLoggableError(ex, dbConnection, SampleSql, new
    {
      UserId = 10
    });

    // assert
    Assert.That(error, Is.EqualTo("Exception thrown while running SQL command on DB 'MyDB' " +
                                  "\"SELECT * FROM Users WHERE UserId = 10\" " +
                                  ":: Exception: Whoops"));
  }

  [Test]
  public void GetLoggableError_GivenExceptionThrown_ShouldLog()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<SqlFormatter>>();
    var dbConnection = Substitute.For<IDbConnection>();
    var ex = new Exception("Whoops");

    dbConnection.Database.Throws(ex);

    // act
    var formatter = TestHelper.GetSqlFormatter(logger);
    formatter.GetLoggableError(ex, dbConnection, SampleSql);

    // assert
    logger.Received(1).LogError(ex, "Error generating loggable error: {msg}", ex.Message);
  }
}
