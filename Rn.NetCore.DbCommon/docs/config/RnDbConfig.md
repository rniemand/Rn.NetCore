[Home](/README.md) / [Config](/docs/config/README.md) / RnDbConfig

# RnDbConfig
More to come...

```json
{
  "Rn.DbCommon": {
    "enableMetrics": true,
    "logSqlCommands": true,
    "defaultConnection": "MyApp",
    "aliasLookups": {
      "TestRepo": "TestRepoConnectionString"
    }
  }
}
```

| Property | Type | Required | Default | Notes |
| --- | --- | --- | --- | --- |
| enableMetrics | `bool` | optional | `false` | Enabled logging of repo based metrics |
| logSqlCommands | `bool` | optional | `false` | Enables the logging of executed SQL commands. |
| defaultConnection | `string` | optional | `default` | The default connection string to use when none is supplied by the wrapping repo. |
| aliasLookups | `Dictionary<>` | optional | `{}` | `RepoName` to defined `ConnectionString` lookup table. |
