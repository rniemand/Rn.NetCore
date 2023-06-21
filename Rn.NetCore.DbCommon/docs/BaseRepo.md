[Home](/README.md) / BaseRepo

# BaseRepo
Base class for `Rn.NetCore.DbCommon` compatable repositories.

> **Note**: You can define the [default connection](/docs/config/RnDbConfig.md) in your applications `IConfiguration` object.

The following logic is used when resolving connection strings for your repository.

- The initial value for `connectionName` is resolved
  - If you provided the `connectionName` parameter it will be used
  - Otherwise the value of `RepoName` will be used
- If no connection name could be determined the [default connection](/docs/config/RnDbConfig.md) will be used
- The provided connection name is checked against the registered alias'
  - If there is no alias override for the current `connectionName` the default connection will be used
  - If there is an override (e.g. `{ "Repo": "connection" }`) the override value will be used (e.g. `connection`)

This ensures that at a minimum the [default connection](/docs/config/RnDbConfig.md) will be used, followed by any overrides defined in configuration.

## Properties
Holder.

```cs
public string RepoName { get; }
public string ConnectionName { get; }
public ILoggerAdapter<TRepo> Logger { get; }
public IDbConnectionHelper ConnectionHelper { get; }
public IMetricService Metrics { get; }

private readonly RnDbConfig _config;
private readonly ISqlFormatter _sqlFormatter;
```

- RepoName - set by `GetType().Name;`
