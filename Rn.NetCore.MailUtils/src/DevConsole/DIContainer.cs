using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Rn.NetCore.MailUtils;

namespace DevConsole;

public static class DIContainer
{
  public static IServiceProvider Services { get; }

#pragma warning disable S1075 // URIs should not be hardcoded
  private const string FilePath = "\\\\192.168.0.60\\appdata\\cron-tool\\mail-settings.json";
#pragma warning restore S1075 // URIs should not be hardcoded

#pragma warning disable S3963 // "static" fields should be initialized inline
  static DIContainer()
  {
    var services = new ServiceCollection();

    var configBuilderRoot = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", true, true);

    if (File.Exists(FilePath))
      configBuilderRoot.AddJsonFile(FilePath);

    var config = configBuilderRoot.Build();

    services
      .AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(LogLevel.Trace);
        loggingBuilder.AddNLog(config);
      })
      .AddRnMailUtils(config);

    Services = services.BuildServiceProvider();
  }
#pragma warning restore S3963 // "static" fields should be initialized inline
}
