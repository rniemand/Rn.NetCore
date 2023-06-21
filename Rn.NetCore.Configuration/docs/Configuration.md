[Home](/README.md) / Configuration

# Configuration
**Rn.NetCore.Configuration** will load it's configuration from the provided `IConfiguration` instance - generally this is provided by the running host context and loaded from the projects `appsettings.json` file, the configuration should  look something like this:

```json
{
  "Rn.DbConfiguration": {
    "addDateTimeHandler": true
  }
}
```

Where the following is true:

| Property | Type | Required | Default | Notes |
| --- | --- | --- | --- | --- |
| addDateTimeHandler | bool | Optional | `false` | When enabled will register an instance of the `DateTimeHandler` class via `SqlMapper.AddTypeHandler`. |