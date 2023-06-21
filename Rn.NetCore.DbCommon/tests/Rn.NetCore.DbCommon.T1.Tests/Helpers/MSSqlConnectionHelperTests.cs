using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using System.Data;
using NSubstitute.ReturnsExtensions;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers;

[TestFixture]
public class MSSqlConnectionHelperTests
{
  private const string Alias = "ConnectionAlias";
  private const string ResolvedConnString = "ResolvedConnectionString";

  [Test]
  public void GetConnection_GivenNoConnectionStringFound_ShouldThrow()
  {
    // arrange
    var connectionResolver = Substitute.For<IConnectionResolver>();

    connectionResolver
      .GetConnectionString(Alias)
      .ReturnsNull();

    // act
    var connectionHelper = GetMSSqlConnectionHelper(
      connectionResolver: connectionResolver);

    var ex = Assert.Throws<ConnectionStringMissingException>(() =>
      connectionHelper.GetConnection(Alias));

    // assert
    connectionResolver.Received(1).GetConnectionString(Alias);
    Assert.That(ex, Is.InstanceOf<ConnectionStringMissingException>());
    Assert.That(ex!.ConnectionString, Is.EqualTo(Alias));
  }

  [Test]
  public void GetConnection_GivenConnectionStringFound_ShouldCreateSqlConnection()
  {
    // arrange
    var connectionResolver = Substitute.For<IConnectionResolver>();
    var dbConnection = Substitute.For<IDbConnection>();

    connectionResolver
      .GetConnectionString(Alias)
      .Returns(ResolvedConnString);

    connectionResolver
      .CreateMSSqlConnection(ResolvedConnString)
      .Returns(dbConnection);

    // act
    var connectionHelper = GetMSSqlConnectionHelper(
      connectionResolver: connectionResolver);

    connectionHelper.GetConnection(Alias);

    // assert
    connectionResolver.Received(1).CreateMSSqlConnection(ResolvedConnString);
  }

  [Test]
  public void GetConnection_GivenConnectionClosed_ShouldOpenConnection()
  {
    // arrange
    var connectionResolver = Substitute.For<IConnectionResolver>();
    var dbConnection = Substitute.For<IDbConnection>();

    connectionResolver
      .GetConnectionString(Alias)
      .Returns(ResolvedConnString);

    connectionResolver
      .CreateMSSqlConnection(ResolvedConnString)
      .Returns(dbConnection);

    dbConnection.State.Returns(ConnectionState.Closed);

    // act
    var connectionHelper = GetMSSqlConnectionHelper(
      connectionResolver: connectionResolver);

    connectionHelper.GetConnection(Alias);

    // assert
    dbConnection.Received(1).Open();
  }

  [Test]
  public void GetConnection_GivenConnectionCreated_ShouldReturnConnection()
  {
    // arrange
    var connectionResolver = Substitute.For<IConnectionResolver>();
    var dbConnection = Substitute.For<IDbConnection>();

    connectionResolver
      .GetConnectionString(Alias)
      .Returns(ResolvedConnString);

    connectionResolver
      .CreateMSSqlConnection(ResolvedConnString)
      .Returns(dbConnection);

    dbConnection.State.Returns(ConnectionState.Open);

    // act
    var connectionHelper = GetMSSqlConnectionHelper(
      connectionResolver: connectionResolver);

    var connection = connectionHelper.GetConnection(Alias);

    // assert
    Assert.That(connection, Is.EqualTo(dbConnection));
  }


  // Internal methods
  private static MSSqlConnectionHelper GetMSSqlConnectionHelper(
    ILoggerAdapter<MSSqlConnectionHelper>? logger = null,
    IConnectionResolver? connectionResolver = null,
    ISqlFormatter? sqlFormatter = null) =>
    new(logger ?? Substitute.For<ILoggerAdapter<MSSqlConnectionHelper>>(),
      connectionResolver ?? Substitute.For<IConnectionResolver>(),
      sqlFormatter ?? Substitute.For<ISqlFormatter>());
}
