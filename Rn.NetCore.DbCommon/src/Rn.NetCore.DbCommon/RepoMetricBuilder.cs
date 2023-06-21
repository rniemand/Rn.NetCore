using System;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Metrics;
using Rn.NetCore.Metrics.Builders;

namespace Rn.NetCore.DbCommon;

public class RepoMetricBuilder : CoreMetricBuilder<RepoMetricBuilder>
{
  private int _queryCount;
  private int _resultsCount;
  private string _repoName = string.Empty;
  private string _repoMethod = string.Empty;
  private string _commandType = string.Empty;
  private string _connection = string.Empty;
  private string _modelName = string.Empty;
  private bool _hasParameters;

  // Constructors
  public RepoMetricBuilder()
    : base("repo_call")
  { }

  public RepoMetricBuilder(string repoName, string repoMethod, string commandType, bool skipToLower = true)
    : this()
  {
    ForRepo(repoName, repoMethod, commandType, skipToLower);
  }

  public RepoMetricBuilder(string repoName, string repoMethod, string commandType, string connection, bool skipToLower = true)
    : this(repoName, repoMethod, commandType, skipToLower)
  {
    WithConnection(connection);
  }


  // Builder methods
  public RepoMetricBuilder ForRepo(string repoName, string repoMethod, string commandType, bool skipToLower = true)
  {
    _repoName = skipToLower ? repoName : repoName.LowerTrim();
    _repoMethod = skipToLower ? repoMethod : repoMethod.LowerTrim();
    _commandType = skipToLower ? commandType : commandType.LowerTrim();
    return this;
  }

  public RepoMetricBuilder WithModel(Type modelType)
  {
    _modelName = modelType.Name;
    return this;
  }

  public RepoMetricBuilder WithOptionalModel(object? model) =>
    model is null ? this : WithModel(model.GetType());

  public RepoMetricBuilder WithConnection(string connection, bool skipToLower = true)
  {
    _connection = skipToLower ? connection : connection.LowerTrim();
    return this;
  }

  public RepoMetricBuilder WithParameters(object? param = null)
  {
    _hasParameters = param is not null;
    return this;
  }

  public RepoMetricBuilder WithQueryCount(int queryCount)
  {
    _queryCount = queryCount;
    return this;
  }

  public RepoMetricBuilder IncrementQueryCount(int amount = 1)
  {
    _queryCount += amount;
    return this;
  }

  public RepoMetricBuilder WithException(Exception ex)
  {
    SetException(ex);
    return this;
  }

  public RepoMetricBuilder WithResultCount(int resultCount)
  {
    _resultsCount = resultCount;
    return this;
  }

  public RepoMetricBuilder CountResult(object? result = null)
  {
    if (result != null)
      _resultsCount += 1;

    return this;
  }

  public RepoMetricBuilder IncrementResultCount(int amount = 1)
  {
    _resultsCount += amount;
    return this;
  }

  public RepoMetricBuilder MarkFailed()
  {
    SetSuccess(false);
    return this;
  }

  public override CoreMetric Build()
  {
    // Set repo specific Fields and Tags
    AddAction(m => { m.SetTag("repo_name", _repoName, true); })
      .AddAction(m => { m.SetTag("repo_method", _repoMethod, true); })
      .AddAction(m => { m.SetTag("command_type", _commandType, true); })
      .AddAction(m => { m.SetTag("connection", _connection, true); })
      .AddAction(m => { m.SetTag("has_params", _hasParameters); })
      .AddAction(m => { m.SetTag("model", _modelName, true); })
      .AddAction(m => { m.SetField("query_count", _queryCount); })
      .AddAction(m => { m.SetField("results_count", _resultsCount); });

    // Bake in all other Fields and Tags
    return base.Build();
  }
}
