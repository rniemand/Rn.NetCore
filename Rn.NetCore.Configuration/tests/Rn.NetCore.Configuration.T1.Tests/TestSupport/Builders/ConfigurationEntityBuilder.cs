using System;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.Configuration.Enums;

namespace Rn.NetCore.Configuration.T1.Tests.TestSupport.Builders;

public class ConfigurationEntityBuilder
{
  private readonly ConfigurationEntity _entity;

  public ConfigurationEntityBuilder()
  {
    _entity = new ConfigurationEntity();
  }

  public ConfigurationEntityBuilder WithDefaults()
  {
    _entity.ConfigId = 1;
    _entity.Deleted = false;
    _entity.IsCollection = false;
    _entity.DateAddedUtc = DateTime.UtcNow.AddDays(-14);
    _entity.DateUpdatedUtc = _entity.DateAddedUtc.AddDays(5);
    _entity.ConfigType = ConfigurationType.String;
    _entity.ConfigCategory = "Category";
    _entity.ConfigKey = "Key";
    _entity.ConfigValue = "Hello World";
    _entity.State = ConfigurationState.Pristine;

    return this;
  }

  public ConfigurationEntityBuilder WithValue(string value)
  {
    _entity.ConfigValue = value;
    return this;
  }

  public ConfigurationEntityBuilder WithType(ConfigurationType type)
  {
    _entity.ConfigType = type;
    return this;
  }

  public ConfigurationEntity Build() => _entity;
}
