[Home](/README.md) / [Misc.](/docs/misc/README.md) / ServiceExtensions

# ServiceExtensions
To simplify registration of the `Rn.NetCore.DbCommon` library the following extension methods are available based on your selected SQL engine.

## AddRnDbMySql()
Registers all required components to use with a [MySQL](https://www.mysql.com/) or [MariaDB](https://mariadb.org/) compatible SQL engine.

```cs
public static IServiceCollection AddMySqlRnDbCommon(IConfiguration configuration)
{
  services.AddRnDbCommon(configuration);
  services.TryAddSingleton<IDbConnectionHelper, MySqlConnectionHelper>();
  return services;
}
```

## AddRnDbMSSql()
Registers all required components needed to wotk with a [MS SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) instance.

```cs
public static IServiceCollection AddRnDbMSSql(IConfiguration configuration)
{
  services.AddRnDbCommon(configuration);
  services.TryAddSingleton<IDbConnectionHelper, MSSqlConnectionHelper>();
  return services;
}
```

## AddRnDbCommon
The following components are registered regardless of the selected SQL engine.

```cs
public static IServiceCollection AddRnDbCommon(IConfiguration configuration)
{
  services.TryAddSingleton(configuration);
  services.TryAddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
  services.TryAddSingleton<IDateTimeAbstraction, DateTimeAbstraction>();
  services.TryAddSingleton<IConnectionResolver, ConnectionResolver>();
  services.TryAddSingleton<IJsonHelper, JsonHelper>();
  services.TryAddSingleton<ISqlFormatter, SqlFormatter>();
  services.TryAddSingleton<IBaseRepoHelper, BaseRepoHelper>();
  services.TryAddSingleton(BindRnDbConfig(configuration));
  return services;
}
```