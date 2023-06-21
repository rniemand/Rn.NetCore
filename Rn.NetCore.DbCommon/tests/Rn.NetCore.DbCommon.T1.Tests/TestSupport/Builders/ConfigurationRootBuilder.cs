using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;

public class ConfigurationRootBuilder
{
  private readonly Dictionary<string, string> _config = new();

  public ConfigurationRootBuilder WithConnectionString(string name, string value)
  {
    _config[$"ConnectionStrings:{name}"] = value;
    return this;
  }

  public IConfigurationRoot Build()
  {
    return new ConfigurationBuilder()
      .AddInMemoryCollection(_config)
      .Build();
  }
}
