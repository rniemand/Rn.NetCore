using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Rn.NetCore.Common.Exceptions;

// DOCS: docs\exceptions\ConfigMissingException.md
[Serializable, ExcludeFromCodeCoverage]
public class ConfigMissingException : Exception
{
  public string ConfigurationPath { get; set; } = string.Empty;
  public string? Property { get; set; }

  public ConfigMissingException(string configPath, string? property = null)
    : base($"Configuration section '{configPath}' is missing")
  {
    ConfigurationPath = configPath;
    Property = property;
  }

  protected ConfigMissingException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  { }
}
