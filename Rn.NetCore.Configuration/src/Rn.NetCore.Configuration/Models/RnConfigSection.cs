using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rn.NetCore.Common.Extensions;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.Configuration.Enums;
using Rn.NetCore.Configuration.Exceptions;
using Rn.NetCore.Configuration.Helpers;
using Rn.NetCore.Configuration.Services;

namespace Rn.NetCore.Configuration.Models;

public interface IRnConfigSection
{
  string Category { get; }

  // DB value management
  Task ReloadValues();
  Task SyncChanges();
  Task SyncAndDispose();

  // Single properties
  string GetString(string key, string fallback);
  int GetInt(string key, int fallback);
  long GetLong(string key, long fallback);
  float GetFloat(string key, float fallback);
  double GetDouble(string key, double fallback);
  bool GetBool(string key, bool fallback);
  DateTime GetDateTime(string key, DateTime fallback);

  // Collections
  void UpdateIntCollection(string key, List<int> values);
}

public class RnConfigSection : IRnConfigSection
{
  public string Category { get; }
  public bool Disposed { get; private set; }

  private readonly ILoggerAdapter<RnConfigSection> _logger;
  private readonly IConfigurationService _configService;
  private readonly List<ConfigurationEntity> _rawConfig;

  public RnConfigSection(
    ILoggerAdapter<RnConfigSection> logger,
    IConfigurationService configService,
    string category)
  {
    _logger = logger;
    _configService = configService;
    _rawConfig = new List<ConfigurationEntity>();
      
    Disposed = false;
    Category = category;
  }


  // DB value management
  public async Task ReloadValues()
  {
    _rawConfig.Clear();
    _rawConfig.AddRange(await _configService.GetAllConfigValues(Category));

    _logger.LogDebug("Loaded {count} value(s) for '{category}'",
      _rawConfig.Count,
      Category
    );

    Disposed = false;
  }

  public async Task SyncChanges()
  {
    if (Disposed)
      throw new ConfigSectionDisposedException(Category);

    await SyncChangesInternal();
    await ReloadValues();
  }

  public async Task SyncAndDispose()
  {
    if (Disposed)
      throw new ConfigSectionDisposedException(Category);

    Disposed = true;
    await SyncChangesInternal();
    _rawConfig.Clear();
  }

  // Single properties
  public string GetString(string key, string fallback)
  {
    var dbEntry = GetEntity(key);

    if (dbEntry != null)
    {
      if (dbEntry.ConfigType == ConfigurationType.String)
        return dbEntry.ConfigValue;

      LogWrongDataType(ConfigurationType.String, dbEntry, fallback);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.String;
      dbEntry.ConfigValue = fallback;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.String,
      ConfigKey = key,
      ConfigValue = fallback,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  public int GetInt(string key, int fallback)
  {
    var dbEntry = GetEntity(key);
    var fallbackString = ConfigValueHelper.FromInt(fallback);

    if (dbEntry != null)
    {
      if (ConfigValueHelper.TryExtractInt(dbEntry, out var parsed))
        return parsed;

      LogWrongDataType(ConfigurationType.Int, dbEntry, fallbackString);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.Int;
      dbEntry.ConfigValue = fallbackString;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.Int,
      ConfigKey = key,
      ConfigValue = fallbackString,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  public long GetLong(string key, long fallback)
  {
    var dbEntry = GetEntity(key); 
    var fallbackString = ConfigValueHelper.FromLong(fallback);

    if (dbEntry != null)
    {
      if (ConfigValueHelper.TryExtractLong(dbEntry, out var parsed))
        return parsed;

      LogWrongDataType(ConfigurationType.Long, dbEntry, fallbackString);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.Long;
      dbEntry.ConfigValue = fallbackString;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.Long,
      ConfigKey = key,
      ConfigValue = fallbackString,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  public float GetFloat(string key, float fallback)
  {
    var dbEntry = GetEntity(key); 
    var fallbackString = ConfigValueHelper.FromFloat(fallback);

    if (dbEntry != null)
    {
      if (ConfigValueHelper.TryExtractFloat(dbEntry, out var parsed))
        return parsed;

      LogWrongDataType(ConfigurationType.Float, dbEntry, fallbackString);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.Float;
      dbEntry.ConfigValue = fallbackString;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.Float,
      ConfigKey = key,
      ConfigValue = fallbackString,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  public double GetDouble(string key, double fallback)
  {
    var dbEntry = GetEntity(key); 
    var fallbackString = ConfigValueHelper.FromDouble(fallback);

    if (dbEntry != null)
    {
      if (ConfigValueHelper.TryExtractDouble(dbEntry, out var parsed))
        return parsed;

      LogWrongDataType(ConfigurationType.Double, dbEntry, fallbackString);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.Double;
      dbEntry.ConfigValue = fallbackString;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.Double,
      ConfigKey = key,
      ConfigValue = fallbackString,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  public bool GetBool(string key, bool fallback)
  {
    var dbEntry = GetEntity(key); 
    var fallbackString = ConfigValueHelper.FromBool(fallback);

    if (dbEntry != null)
    {
      if (ConfigValueHelper.TryExtractBool(dbEntry, out var parsed))
        return parsed;

      LogWrongDataType(ConfigurationType.Bool, dbEntry, fallbackString);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.Bool;
      dbEntry.ConfigValue = fallbackString;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.Bool,
      ConfigKey = key,
      ConfigValue = fallbackString,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  public DateTime GetDateTime(string key, DateTime fallback)
  {
    var dbEntry = GetEntity(key); 
    var fallbackString = ConfigValueHelper.FromDateTime(fallback);

    if (dbEntry != null)
    {
      if (ConfigValueHelper.TryExtractDateTime(dbEntry, out var parsed))
        return parsed;

      LogWrongDataType(ConfigurationType.DateTime, dbEntry, fallbackString);
      dbEntry.State = ConfigurationState.Modified;
      dbEntry.ConfigType = ConfigurationType.DateTime;
      dbEntry.ConfigValue = fallbackString;
      return fallback;
    }

    _rawConfig.Add(new ConfigurationEntity
    {
      ConfigType = ConfigurationType.DateTime,
      ConfigKey = key,
      ConfigValue = fallbackString,
      ConfigCategory = Category,
      IsCollection = false,
      State = ConfigurationState.New
    });

    return fallback;
  }

  // Collections
  public void UpdateIntCollection(string key, List<int> values)
  {
    var currentValues = _rawConfig
      .Where(x => x.ConfigKey.IgnoreCaseEquals(key))
      .ToList();

    foreach (var value in values)
    {
      var configValue = ConfigValueHelper.FromInt(value);
      var dbEntry = currentValues.FirstOrDefault(x => x.ConfigValue == configValue);

      if (dbEntry == null)
      {
        _rawConfig.Add(new ConfigurationEntity
        {
          ConfigKey = key,
          ConfigType = ConfigurationType.Int,
          ConfigValue = configValue,
          ConfigCategory = Category,
          IsCollection = true,
          State = ConfigurationState.New
        });
      }
      else if(dbEntry.Deleted)
      {
        dbEntry.Deleted = false;
        dbEntry.State = ConfigurationState.Modified;
      }
    }
  }


  // Internal methods
  private ConfigurationEntity GetEntity(string key)
  {
    if (Disposed)
      throw new ConfigSectionDisposedException(Category, key);

    return _rawConfig.FirstOrDefault(x => x
      .ConfigKey.IgnoreCaseEquals(key)
    );
  }

  private void LogWrongDataType(ConfigurationType expected, ConfigurationEntity entity, string fallback)
  {
    _logger.LogWarning(
      "Incorrect data type set for '{category}.{key}' (current: {current}) " +
      "(expected: {expected}) - resetting value to given fallback: {fallback}",
      entity.ConfigCategory,
      entity.ConfigKey,
      entity.ConfigType.ToString("G"),
      expected.ToString("G"),
      fallback
    );
  }

  private async Task SyncChangesInternal()
  {
    var modifiedConfig = _rawConfig
      .Where(x => x.State != ConfigurationState.Pristine)
      .ToList();

    if (modifiedConfig.Count == 0)
      return;

    _logger.LogInformation("Persisting {count} change(s) for '{category}'",
      modifiedConfig.Count,
      Category
    );

    foreach (var entity in modifiedConfig)
      await _configService.SetValue(entity);
  }
}
