using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Rn.NetCore.DbCommon;

// DOCS: docs\config\RnDbConfig.md
public class RnDbConfig
{
  [ConfigurationKeyName("enableMetrics")]
  public bool EnableMetrics { get; set; } = false;

  [ConfigurationKeyName("logSqlCommands")]
  public bool LogSqlCommands { get; set; } = false;

  [ConfigurationKeyName("defaultConnection")]
  public string DefaultConnection { get; set; } = "default";

  [ConfigurationKeyName("aliasLookups")]
  public Dictionary<string, string> AliasLookups { get; set; } = new();
}
