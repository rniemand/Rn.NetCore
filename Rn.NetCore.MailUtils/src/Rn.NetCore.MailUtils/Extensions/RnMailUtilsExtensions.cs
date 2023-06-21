using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Rn.NetCore.Common.Abstractions;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.MailUtils;

[ExcludeFromCodeCoverage]
public static class RnMailUtilsExtensions
{
  public static IServiceCollection AddRnMailUtils(this IServiceCollection services, IConfiguration configuration)
  {
    // Optional service registration
    services.TryAddSingleton<IEnvironmentAbstraction, EnvironmentAbstraction>();
    services.TryAddSingleton<IPathAbstraction, PathAbstraction>();
    services.TryAddSingleton<IDirectoryAbstraction, DirectoryAbstraction>();
    services.TryAddSingleton<IFileAbstraction, FileAbstraction>();
    services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));

    return services
      .AddSingleton(BindConfig(configuration))
      .AddSingleton<IRnMailUtilsFactory, RnMailUtilsFactory>()
      .AddSingleton<IMailTemplateProvider, MailTemplateProvider>()
      .AddSingleton<IMailTemplateHelper, MailTemplateHelper>();
  }

  private static RnMailConfig BindConfig(IConfiguration configuration)
  {
    var boundConfig = new RnMailConfig();
    var configSection = configuration.GetSection("Rn.MailUtils");

    if (!configSection.Exists())
      return boundConfig;

    configSection.Bind(boundConfig);
    return boundConfig;
  }
}
