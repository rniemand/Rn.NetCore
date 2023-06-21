using NSubstitute;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot.BaseRepoTests;

public static class TestHelper
{
  public static IBaseRepoHelper GetBaseRepoHelper(
    ILoggerAdapter<TestRepo>? logger = null,
    IDbConnectionHelper? connectionHelper = null,
    IMetricService? metricService = null,
    ISqlFormatter? sqlFormatter = null,
    string? connectionName = null,
    RnDbConfig? dbConfig = null)
  {
    var baseRepoHelper = Substitute.For<IBaseRepoHelper>();

    baseRepoHelper
      .ResolveLogger<TestRepo>()
      .Returns(logger ?? Substitute.For<ILoggerAdapter<TestRepo>>());

    baseRepoHelper
      .ResolveConnectionHelper()
      .Returns(connectionHelper ?? Substitute.For<IDbConnectionHelper>());

    baseRepoHelper
      .ResolveMetricService()
      .Returns(metricService ?? Substitute.For<IMetricService>());

    baseRepoHelper
      .ResolveSqlFormatter()
      .Returns(sqlFormatter ?? Substitute.For<ISqlFormatter>());
    
    baseRepoHelper
      .GetRnDbConfig()
      .Returns(dbConfig ?? new RnDbConfig());

    if (string.IsNullOrWhiteSpace(connectionName))
      connectionName = nameof(TestRepo);

    baseRepoHelper
      .ResolveConnectionName(Arg.Any<string>(), Arg.Any<string>())
      .Returns(connectionName);

    return baseRepoHelper;
  }
}
