using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Dapper;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon;

public abstract class DbConnectionHelperBase<TClass> : IDbConnectionHelper
{
  internal ILoggerAdapter<TClass> Logger { get; }
  internal IConnectionResolver ConnectionResolver { get; }
  internal ISqlFormatter SqlFormatter { get; }

  protected DbConnectionHelperBase(ILoggerAdapter<TClass> logger,
    IConnectionResolver connectionResolver,
    ISqlFormatter sqlFormatter)
  {
    Logger = logger;
    ConnectionResolver = connectionResolver;
    SqlFormatter = sqlFormatter;
  }

  public virtual IDbConnection GetConnection(string alias) =>
    throw new NotImplementedException($"{nameof(GetConnection)}() not implemented");

  [ExcludeFromCodeCoverage]
  public async Task<int> ExecuteAsync(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
  {
    try
    {
      return await cnn.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, SqlFormatter.GetLoggableError(ex, cnn, sql, param));
      throw;
    }
  }

  [ExcludeFromCodeCoverage]
  public async Task<IEnumerable<T>> QueryAsync<T>(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null)
  {

    try
    {
      return await cnn.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
    }
    catch (Exception ex)
    {
      Logger.LogError(ex, SqlFormatter.GetLoggableError(ex, cnn, sql, param));
      throw;
    }
  }
}
