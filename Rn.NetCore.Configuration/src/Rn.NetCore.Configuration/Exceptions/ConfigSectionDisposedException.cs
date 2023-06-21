using System;
using System.Runtime.Serialization;

namespace Rn.NetCore.Configuration.Exceptions;

[Serializable]
public class ConfigSectionDisposedException : Exception
{
  public string Category { get; set; }
  public string Key { get; set; }

  protected ConfigSectionDisposedException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  { }

  public ConfigSectionDisposedException()
    : base("Currently marked as disposed, please call .ReloadValues() to sync state with the DB")
  {
    Category = string.Empty;
    Key = string.Empty;
  }

  public ConfigSectionDisposedException(string category)
    : this()
  {
    Category = category;
  }

  public ConfigSectionDisposedException(string category, string key)
    : this()
  {
    Category = category;
    Key = key;
  }
}
