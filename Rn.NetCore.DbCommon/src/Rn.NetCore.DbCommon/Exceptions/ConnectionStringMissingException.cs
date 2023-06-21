using System;
using System.Runtime.Serialization;

namespace Rn.NetCore.DbCommon;

[Serializable]
public class ConnectionStringMissingException : Exception
{
  public string? ConnectionString { get; set; }

  public ConnectionStringMissingException(string connectionString)
  : base($"Unable to find connection string: {connectionString}")
  {
    ConnectionString = connectionString;
  }

  protected ConnectionStringMissingException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  { }
}
