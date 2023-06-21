using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.DbCommon;

// DOCS: docs\ConnectionResolver.md
public interface IConnectionResolver
{
  IConnectionResolver RegisterAlias(string alias, string connectionName);
  string ResolveAlias(string alias);
  string? GetConnectionString(string? alias);
  IDbConnection CreateMSSqlConnection(string connectionString);
  IDbConnection MyCreateSqlConnection(string connectionString);
}

public class ConnectionResolver : IConnectionResolver
{
  public const string ConnectionStringsKey = "ConnectionStrings";

  private readonly string _defaultAlias;
  private readonly Dictionary<string, string> _aliasLookup = new();
  private readonly Dictionary<string, string> _connectionStrings = new();

  public ConnectionResolver(IConfiguration configuration, RnDbConfig dbConfig)
  {
    _defaultAlias = dbConfig.DefaultConnection;

    foreach (var (alias, connName) in dbConfig.AliasLookups)
    {
      RegisterAlias(alias, connName);
    }

    Initialize(configuration);
  }

  public IConnectionResolver RegisterAlias(string alias, string connectionName)
  {
    if (string.IsNullOrWhiteSpace(alias) || string.IsNullOrWhiteSpace(connectionName))
      return this;

    _aliasLookup[alias.LowerTrim()] = connectionName;
    return this;
  }

  public string ResolveAlias(string alias)
  {
    if (string.IsNullOrWhiteSpace(alias))
      return _defaultAlias;

    if (_aliasLookup.Count == 0)
      return _defaultAlias;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (!_aliasLookup.Any(x => x.Key.IgnoreCaseEquals(alias)))
      return _defaultAlias;

    return _aliasLookup.First(x => x.Key.IgnoreCaseEquals(alias)).Value;
  }

  public string? GetConnectionString(string? alias)
  {
    if (string.IsNullOrWhiteSpace(alias))
      return null;

    if (_connectionStrings.Count == 0)
      return null;

    if (!_connectionStrings.Any(x => x.Key.IgnoreCaseEquals(alias)))
      return null;

    return _connectionStrings
      .First(x => x.Key.IgnoreCaseEquals(alias))
      .Value;
  }

  public IDbConnection CreateMSSqlConnection(string connectionString) =>
    new SqlConnection(connectionString);

  public IDbConnection MyCreateSqlConnection(string connectionString) =>
    new MySqlConnection(connectionString);

  private void Initialize(IConfiguration configuration)
  {
    _connectionStrings.Clear();

    var connStringsSection = configuration.GetSection(ConnectionStringsKey);
    var connStrings = connStringsSection?.GetChildren() ?? Array.Empty<IConfigurationSection>();

    foreach (var connectionString in connStrings)
    {
      _connectionStrings[connectionString.Key.LowerTrim()] = connectionString.Value;
    }
  }
}
