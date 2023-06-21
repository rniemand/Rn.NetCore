using System;
using Rn.NetCore.Configuration.Enums;

namespace Rn.NetCore.Configuration.Database;

public class ConfigurationEntity
{
  public int ConfigId { get; set; }
  public bool Deleted { get; set; }
  public bool IsCollection { get; set; }
  public DateTime DateAddedUtc { get; set; } = DateTime.MinValue;
  public DateTime DateUpdatedUtc { get; set; } = DateTime.MinValue;
  public ConfigurationType ConfigType { get; set; } = ConfigurationType.String;
  public string ConfigCategory { get; set; } = string.Empty;
  public string ConfigKey { get; set; } = string.Empty;
  public string ConfigValue { get; set; } = string.Empty;
  public ConfigurationState State { get; set; } = ConfigurationState.Pristine;
}
