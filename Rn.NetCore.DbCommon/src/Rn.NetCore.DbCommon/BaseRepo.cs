using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Metrics;
using Rn.NetCore.Metrics.Extensions;

namespace Rn.NetCore.DbCommon;

// DOCS: docs\BaseRepo.md
public abstract class BaseRepo<TRepo>
{
  public string RepoName { get; }
  public string ConnectionName { get; }
  public ILoggerAdapter<TRepo> Logger { get; }
  public IDbConnectionHelper ConnectionHelper { get; }
  public IMetricService Metrics { get; }

  private readonly RnDbConfig _config;
  private readonly ISqlFormatter _sqlFormatter;

  // Constructor
  protected BaseRepo(IBaseRepoHelper baseRepoHelper, string? connectionName = null)
  {
    RepoName = GetType().Name;

    Logger = baseRepoHelper.ResolveLogger<TRepo>();
    ConnectionHelper = baseRepoHelper.ResolveConnectionHelper();
    Metrics = baseRepoHelper.ResolveMetricService();
    ConnectionName = baseRepoHelper.ResolveConnectionName(RepoName, connectionName);

    _sqlFormatter = baseRepoHelper.ResolveSqlFormatter();
    _config = baseRepoHelper.GetRnDbConfig();
  }


  // Public methods
  protected async Task<List<T>> GetList<T>(string method, string sql, object? param = null)
  {
    var metricBuilder = new RepoMetricBuilder(RepoName, method, nameof(GetList), ConnectionName)
      .WithSuccess(false)
      .WithParameters(param)
      .WithModel(typeof(T));

    LogSqlCommand(method, sql, param);

    try
    {
      using (metricBuilder.IncrementQueryCount().WithTiming())
      {
        using var dbConnection = ConnectionHelper.GetConnection(ConnectionName);
        var dbResults = (await ConnectionHelper.QueryAsync<T>(dbConnection, sql, param))
          .ToList();

        metricBuilder
          .WithResultCount(dbResults.Count)
          .MarkSuccess();

        return dbResults;
      }
    }
    catch (Exception ex)
    {
      var executedSql = _sqlFormatter.Format(sql, param);
      Logger.LogError(ex, "Error running SQL query: {sql}", executedSql);
      metricBuilder.WithException(ex);
      return new List<T>();
    }
    finally
    {
      if (_config.EnableMetrics)
        await Metrics.SubmitAsync(metricBuilder);
    }
  }

  protected async Task<T?> GetSingle<T>(string method, string sql, object? param = null)
  {
    var metricBuilder = new RepoMetricBuilder(RepoName, method, nameof(GetSingle), ConnectionName)
      .WithSuccess(false)
      .WithParameters(param)
      .WithModel(typeof(T));

    LogSqlCommand(method, sql, param);

    try
    {
      using (metricBuilder.IncrementQueryCount().WithTiming())
      {
        using var dbConnection = ConnectionHelper.GetConnection(ConnectionName);
        var dbResult = (await ConnectionHelper.QueryAsync<T>(dbConnection, sql, param))
          .FirstOrDefault();

        metricBuilder
          .CountResult(dbResult)
          .MarkSuccess();

        return dbResult;
      }
    }
    catch (Exception ex)
    {
      var executedSql = _sqlFormatter.Format(sql, param);
      Logger.LogError(ex, "Error running SQL query: {sql}", executedSql);
      metricBuilder.WithException(ex);
      return default;
    }
    finally
    {
      await Metrics.SubmitAsync(metricBuilder);
    }
  }

  protected async Task<int> ExecuteAsync(string method, string sql, object? param = null)
  {
    var metricBuilder = new RepoMetricBuilder(RepoName, method, nameof(ExecuteAsync), ConnectionName)
      .WithSuccess(false)
      .WithParameters(param)
      .WithModel(typeof(int))
      .WithOptionalModel(param);

    LogSqlCommand(method, sql, param);

    try
    {
      using (metricBuilder.IncrementQueryCount().WithTiming())
      {
        using var dbConnection = ConnectionHelper.GetConnection(ConnectionName);
        var affectedRows = await ConnectionHelper.ExecuteAsync(dbConnection, sql, param);

        metricBuilder
          .WithResultCount(affectedRows)
          .MarkSuccess();

        return affectedRows;
      }
    }
    catch (Exception ex)
    {
      var executedSql = _sqlFormatter.Format(sql, param);
      Logger.LogError(ex, "Error running SQL query: {sql}", executedSql);
      metricBuilder.WithException(ex);
      return 0;
    }
    finally
    {
      await Metrics.SubmitAsync(metricBuilder);
    }
  }


  // Internal methods
  public void LogSqlCommand(string methodName, string sql, object? param = null)
  {
    if (!_config.LogSqlCommands)
      return;

    Logger.LogDebug("Running SQL command for {repo}.{method}() :: {sql}",
      RepoName,
      methodName,
      _sqlFormatter.Format(sql, param));
  }
}
