using Microsoft.Extensions.Configuration;

namespace Rn.NetCore.Configuration.Models;

public class RnConfigurationConfig
{
  [ConfigurationKeyName("addDateTimeHandler")]
  public bool AddDateTimeHandler { get; set; }
}
