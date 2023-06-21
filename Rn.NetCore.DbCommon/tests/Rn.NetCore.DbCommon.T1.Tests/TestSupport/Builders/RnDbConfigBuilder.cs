namespace Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;

public class RnDbConfigBuilder
{
  public static RnDbConfig Default => new RnDbConfigBuilder().Build();

  private readonly RnDbConfig _config = new();

  public RnDbConfigBuilder WithDefaultConnection(string defaultConnection)
  {
    _config.DefaultConnection = defaultConnection;
    return this;
  }

  public RnDbConfigBuilder WithLogSqlCommands(bool enabled)
  {
    _config.LogSqlCommands = enabled;
    return this;
  }

  public RnDbConfigBuilder WithEnableMetrics(bool enabled)
  {
    _config.EnableMetrics = enabled;
    return this;
  }

  public RnDbConfigBuilder WithAliasLookup(string alias, string connectionStringName)
  {
    _config.AliasLookups[alias] = connectionStringName;
    return this;
  }

  public RnDbConfig Build() => _config;
}
