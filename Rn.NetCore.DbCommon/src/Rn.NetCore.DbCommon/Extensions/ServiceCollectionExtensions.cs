using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Helpers;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon;

// DOCS: docs\misc\ServiceExtensions.md
public static class ServiceCollectionExtensions
{
  [ExcludeFromCodeCoverage]
  public static IServiceCollection AddRnDbCommon(this IServiceCollection services, IConfiguration configuration)
  {
    services.TryAddSingleton(configuration);
    services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
    services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();
    services.TryAddSingleton<IConnectionResolver, ConnectionResolver>();
    services.TryAddSingleton<IJsonHelper, JsonHelper>();
    services.TryAddSingleton<ISqlFormatter, SqlFormatter>();
    services.TryAddSingleton<IBaseRepoHelper, BaseRepoHelper>();
    services.TryAddSingleton(BindRnDbConfig(configuration));
    return services;
  }

  public static IServiceCollection AddRnDbMySql(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddRnDbCommon(configuration);
    services.TryAddSingleton<IDbConnectionHelper, MySqlConnectionHelper>();
    return services;
  }

  public static IServiceCollection AddRnDbMSSql(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddRnDbCommon(configuration);
    services.TryAddSingleton<IDbConnectionHelper, MSSqlConnectionHelper>();
    return services;
  }

  private static RnDbConfig BindRnDbConfig(IConfiguration configuration)
  {
    var boundConfig = new RnDbConfig();

    var section = configuration.GetSection("Rn.DbCommon");
    if (!section.Exists())
      return boundConfig;

    section.Bind(boundConfig);
    return boundConfig;
  }
}
