using System;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.Configuration.Services;

namespace DevConsole.DevTesting;

public class ServiceDev
{
  private readonly IServiceProvider _serviceProvider;

  public ServiceDev(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  public void TestConfigService()
  {
    var service = _serviceProvider.GetRequiredService<IConfigurationService>();
    const string category = "Rn.DevTesting";

    var configSection = service.GetConfigSection(category).GetAwaiter().GetResult();

    Console.WriteLine();
  }
}
