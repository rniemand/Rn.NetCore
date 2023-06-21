using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Helpers;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.Configuration.Services;
using Rn.NetCore.Configuration.Models;

namespace Rn.NetCore.Configuration.Extensions;

public static class ServiceCollectionExtensions
{
  public static IServiceCollection AddRnConfiguration(this IServiceCollection services, IConfiguration configuration)
  {
    // Ensure that required services are available
    services.TryAddSingleton<IJsonHelper, JsonHelper>();
    services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();

    // Bind our configuration and register the "DateTimeHandler" if enabled
    var libConfig = BindConfiguration(configuration);
    if (libConfig.AddDateTimeHandler)
      SqlMapper.AddTypeHandler(new DateTimeHandler());

    // Register all other service entries
    return services
      .AddSingleton(libConfig)
      .AddSingleton<IConfigurationRepo, ConfigurationRepo>()
      .AddSingleton<IConfigurationRepoQueries, ConfigurationRepoQueries>()
      .AddSingleton<IConfigurationService, ConfigurationService>();
  }

  private static RnConfigurationConfig BindConfiguration(IConfiguration configuration)
  {
    var boundConfig = new RnConfigurationConfig();

    var configSection = configuration.GetSection("Rn.DbConfiguration");
    if (!configSection.Exists())
      return boundConfig;

    configSection.Bind(boundConfig);
    return boundConfig;
  }
}
