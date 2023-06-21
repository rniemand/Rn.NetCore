using System;
using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers;

[TestFixture]
public class BaseRepoHelperTests
{
  private const string RepoName = "TestRepo";
  private const string RepoConnectionName = "RepoConnectionName";
  private const string CustomConnectionName = "CustomConnectionName";

  [Test]
  public void ResolveLogger_GivenCalled_ShouldResolveLogger()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();

    services
      .GetService(typeof(ILoggerAdapter<BaseRepoHelperTests>))
      .Returns(Substitute.For<ILoggerAdapter<BaseRepoHelperTests>>());

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    baseRepoHelper.ResolveLogger<BaseRepoHelperTests>();

    // assert
    services.Received(1).GetService(typeof(ILoggerAdapter<BaseRepoHelperTests>));
  }

  [Test]
  public void ResolveConnectionHelper_GivenCalled_ShouldResolveDbConnectionHelper()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();

    services
      .GetService(typeof(IDbConnectionHelper))
      .Returns(Substitute.For<IDbConnectionHelper>());

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    baseRepoHelper.ResolveConnectionHelper();

    // assert
    services.Received(1).GetService(typeof(IDbConnectionHelper));
  }

  [Test]
  public void ResolveMetricService_GivenCalled_ShouldResolveMetricService()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();

    services
      .GetService(typeof(IMetricService))
      .Returns(Substitute.For<IMetricService>());

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    baseRepoHelper.ResolveMetricService();

    // assert
    services.Received(1).GetService(typeof(IMetricService));
  }

  [Test]
  public void ResolveSqlFormatter_GivenCalled_ShouldResolveSqlFormatter()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();

    services
      .GetService(typeof(ISqlFormatter))
      .Returns(Substitute.For<ISqlFormatter>());

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    baseRepoHelper.ResolveSqlFormatter();

    // assert
    services.Received(1).GetService(typeof(ISqlFormatter));
  }

  [Test]
  public void GetRnDbConfig_GivenCalled_ShouldResolveRnDbConfig()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();

    services
      .GetService(typeof(RnDbConfig))
      .Returns(Substitute.For<RnDbConfig>());

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    baseRepoHelper.GetRnDbConfig();

    // assert
    services.Received(1).GetService(typeof(RnDbConfig));
  }

  [Test]
  public void ResolveConnectionName_GivenNoConnectionName_ShouldReturnRepoConnectionName()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();
    var connectionResolver = Substitute.For<IConnectionResolver>();

    services
      .GetService(typeof(IConnectionResolver))
      .Returns(connectionResolver);

    connectionResolver
      .ResolveAlias(RepoName)
      .Returns(RepoConnectionName);

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    var connectionName = baseRepoHelper.ResolveConnectionName(RepoName);

    // assert
    Assert.That(connectionName, Is.EqualTo(RepoConnectionName));
  }

  [Test]
  public void ResolveConnectionName_GivenEmptyConnectionName_ShouldReturnRepoConnectionName()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();
    var connectionResolver = Substitute.For<IConnectionResolver>();

    services
      .GetService(typeof(IConnectionResolver))
      .Returns(connectionResolver);

    connectionResolver
      .ResolveAlias(RepoName)
      .Returns(RepoConnectionName);

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    var connectionName = baseRepoHelper.ResolveConnectionName(RepoName, "");

    // assert
    Assert.That(connectionName, Is.EqualTo(RepoConnectionName));
  }

  [Test]
  public void ResolveConnectionName_GivenConnectionName_ShouldReturnResolvedName()
  {
    // arrange
    var services = Substitute.For<IServiceProvider>();
    var connectionResolver = Substitute.For<IConnectionResolver>();

    services
      .GetService(typeof(IConnectionResolver))
      .Returns(connectionResolver);

    connectionResolver
      .ResolveAlias("MyConnection")
      .Returns(CustomConnectionName);

    // act
    var baseRepoHelper = GetBaseRepoHelper(services);
    var connectionName = baseRepoHelper.ResolveConnectionName(RepoName, "MyConnection");

    // assert
    Assert.That(connectionName, Is.EqualTo(CustomConnectionName));
  }


  // Internal methods
  private static BaseRepoHelper GetBaseRepoHelper(IServiceProvider? serviceProvider = null) =>
    new(serviceProvider ?? Substitute.For<IServiceProvider>());
}
