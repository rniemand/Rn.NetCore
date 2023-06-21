using System;
using System.IO;
using DevConsole.DatabaseTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Rn.NetCore.DbCommon;
using Rn.NetCore.Metrics.Extensions;
using Rn.NetCore.Metrics.Rabbit.Extensions;

namespace DevConsole;

internal class DIContainer
{
  public static IServiceProvider GetContainer()
  {
    var services = new ServiceCollection();

    var config = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
      .Build();

    services
      .AddSingleton(config)
      .AddRnMetricsBase(config)
      .AddRnMetricRabbitMQ()
      .AddRnDbMySql(config)

      .AddSingleton<IUserRepo, UserRepo>()
      .AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(LogLevel.Trace);
        loggingBuilder.AddNLog(config);
      });

    return services.BuildServiceProvider();
  }
}
