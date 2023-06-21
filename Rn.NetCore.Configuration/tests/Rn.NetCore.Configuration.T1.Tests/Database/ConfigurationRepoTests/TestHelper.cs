using NSubstitute;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.DbCommon;
using Rn.NetCore.Metrics;

namespace Rn.NetCore.Configuration.T1.Tests.Database.ConfigurationRepoTests;

public static class TestHelper
{
  public static IBaseRepoHelper BuildBaseRepoHelper(
    ILoggerAdapter<ConfigurationRepo>? logger = null,
    IDbConnectionHelper? connectionHelper = null,
    IMetricService? metrics = null,
    ISqlFormatter? sqlFormatter = null,
    RnDbConfig? config = null,
    string? connectionName = null)
  {
    var baseRepoHelper = Substitute.For<IBaseRepoHelper>();

    baseRepoHelper
      .ResolveLogger<ConfigurationRepo>()
      .Returns(logger ?? Substitute.For<ILoggerAdapter<ConfigurationRepo>>());

    baseRepoHelper
      .ResolveMetricService()
      .Returns(metrics ?? Substitute.For<IMetricService>());

    baseRepoHelper
      .ResolveConnectionHelper()
      .Returns(connectionHelper ?? Substitute.For<IDbConnectionHelper>());

    baseRepoHelper
      .ResolveSqlFormatter()
      .Returns(sqlFormatter ?? Substitute.For<ISqlFormatter>());

    baseRepoHelper
      .GetRnDbConfig()
      .Returns(config ?? new RnDbConfig());

    baseRepoHelper
      .ResolveConnectionName(Arg.Any<string>(), Arg.Any<string>())
      .Returns(string.IsNullOrEmpty(connectionName) ? nameof(ConfigurationRepo) : connectionName);

    return baseRepoHelper;
  }

  public static ConfigurationRepo GetConfigurationRepo(IBaseRepoHelper? baseRepoHelper = null,
    IConfigurationRepoQueries? repoQueries = null) =>
    new(baseRepoHelper ?? BuildBaseRepoHelper(),
      repoQueries ?? Substitute.For<IConfigurationRepoQueries>());
}
