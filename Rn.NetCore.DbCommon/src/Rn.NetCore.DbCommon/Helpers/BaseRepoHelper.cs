using System;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics;

namespace Rn.NetCore.DbCommon;

public interface IBaseRepoHelper
{
  ILoggerAdapter<TRepo> ResolveLogger<TRepo>();
  IDbConnectionHelper ResolveConnectionHelper();
  IMetricService ResolveMetricService();
  ISqlFormatter ResolveSqlFormatter();
  RnDbConfig GetRnDbConfig();
  string ResolveConnectionName(string repoName, string? connectionName = null);
}

public class BaseRepoHelper : IBaseRepoHelper
{
  private readonly IServiceProvider _serviceProvider;

  public BaseRepoHelper(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public ILoggerAdapter<TRepo> ResolveLogger<TRepo>() =>
    (ILoggerAdapter<TRepo>)_serviceProvider.GetRequiredService(typeof(ILoggerAdapter<TRepo>));

  public IDbConnectionHelper ResolveConnectionHelper() =>
    _serviceProvider.GetRequiredService<IDbConnectionHelper>();

  public IMetricService ResolveMetricService() =>
    _serviceProvider.GetRequiredService<IMetricService>();

  public ISqlFormatter ResolveSqlFormatter() =>
    _serviceProvider.GetRequiredService<ISqlFormatter>();

  public RnDbConfig GetRnDbConfig() =>
    _serviceProvider.GetRequiredService<RnDbConfig>();

  public string ResolveConnectionName(string repoName, string? connectionName = null)
  {
    connectionName ??= repoName;

    if (string.IsNullOrWhiteSpace(connectionName))
      connectionName = repoName;

    return _serviceProvider
      .GetRequiredService<IConnectionResolver>()
      .ResolveAlias(connectionName);
  }
}
