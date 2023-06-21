[Home](/README.md) / Service Registration

# Service Registration
In order to use **Rn.NetCore.Configuration** in your application the following libs are expected to be registered:

- `Rn.NetCore.DbCommon` - used to interact with the DB ([Github](https://github.com/rniemand/Rn.NetCore.DbCommon) - [NuGet](https://www.nuget.org/packages/Rn.NetCore.DbCommon/))
- `Rn.NetCore.Metrics` - used to submit metrics by **Rn.NetCore.DbCommon** ([Github](https://github.com/rniemand/Rn.NetCore.Metrics) - [NuGet](https://www.nuget.org/packages/Rn.NetCore.Metrics/))

Once you meet these requirements you can add **Rn.NetCore.Configuration** using the `.AddRnConfiguration()` extension method:

```cs
private static void ConfigureDI(IServiceCollection services)
{
  // ...
  services
    .AddRnDbMySql(config) // or .AddRnDbMSSql() or .AddRnDbCommon()
    .AddRnMetricsBase(config)
    .AddRnConfiguration(config);
}
```

It's that simple.
