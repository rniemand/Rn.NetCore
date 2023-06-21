using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.DbCommon;

namespace Rn.NetCore.Configuration.T1.Tests.Database.ConfigurationRepoTests;

[TestFixture]
public class ConstructorTests
{
  private const string ConnectionName = "MyConnection";

  [Test]
  public void ConfigurationRepo_Given_Constructed_ShouldSet_Logger()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<ConfigurationRepo>>();
    var baseRepoHelper = TestHelper.BuildBaseRepoHelper(logger: logger);

    // act
    var repo = TestHelper.GetConfigurationRepo(baseRepoHelper);

    // assert
    Assert.IsNotNull(repo.Logger);
    Assert.IsInstanceOf<ILoggerAdapter<ConfigurationRepo>>(repo.Logger);
    Assert.AreEqual(logger, repo.Logger);
  }

  [Test]
  public void ConfigurationRepo_Given_Constructed_ShouldSet_DbHelper()
  {
    // arrange
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    var baseRepoHelper = TestHelper.BuildBaseRepoHelper(connectionHelper: connectionHelper);

    // act
    var repo = TestHelper.GetConfigurationRepo(baseRepoHelper);

    // assert
    Assert.IsNotNull(repo.ConnectionHelper);
    Assert.IsInstanceOf<IDbConnectionHelper>(repo.ConnectionHelper);
    Assert.AreEqual(connectionHelper, repo.ConnectionHelper);
  }

  [Test]
  public void ConfigurationRepo_Given_Constructed_ShouldSet_ConnectionName()
  {
    // arrange
    var baseRepoHelper = TestHelper.BuildBaseRepoHelper(connectionName: ConnectionName);

    // act
    var repo = TestHelper.GetConfigurationRepo(baseRepoHelper);

    // assert
    Assert.That(repo.ConnectionName, Is.EqualTo(ConnectionName));
  }
}
