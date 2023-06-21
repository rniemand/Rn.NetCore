using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.Configuration.Enums;
using Rn.NetCore.Configuration.Helpers;
using Rn.NetCore.Configuration.Models;

namespace Rn.NetCore.Configuration.Services;

public interface IConfigurationService
{
  Task<bool> DeleteConfig(ConfigurationEntity entity);
  Task<bool> UpdateConfig(ConfigurationEntity entity);

  Task<bool> SetValue(ConfigurationEntity entity);
  Task<bool> SetValue(string category, string key, string value);
  Task<bool> SetIntValue(string category, string key, int value);
  Task<bool> SetLongValue(string category, string key, long value);
  Task<bool> SetFloatValue(string category, string key, float value);
  Task<bool> SetDoubleValue(string category, string key, double value);
  Task<bool> SetBoolValue(string category, string key, bool value);
  Task<bool> SetDateTimeValue(string category, string key, DateTime value);

  Task<bool> GetBoolValue(string category, string key, bool fallback);

  Task<IRnConfigSection> GetConfigSection(string category);

  Task<List<ConfigurationEntity>> GetConfigValues(string category);
  Task<List<ConfigurationEntity>> GetAllConfigValues(string category);
}

public class ConfigurationService : IConfigurationService
{
  private readonly ILoggerAdapter<ConfigurationService> _logger;
  private readonly IConfigurationRepo _configRepo;
  private readonly IServiceProvider _serviceProvider;

  public ConfigurationService(
    ILoggerAdapter<ConfigurationService> logger,
    IServiceProvider serviceProvider,
    IConfigurationRepo configRepo)
  {
    _logger = logger;
    _configRepo = configRepo;
    _serviceProvider = serviceProvider;
  }

    
  // Interface methods
  public async Task<bool> DeleteConfig(ConfigurationEntity entity)
  {
    return await _configRepo.Delete(entity.ConfigId) == 1;
  }

  public async Task<bool> UpdateConfig(ConfigurationEntity entity)
  {
    var updated = await _configRepo.UpdateConfigEntry(entity) == 1;

    if (updated)
    {
      _logger.LogDebug(
        "Configuration '{category}.{key}' (id: {id}) updated",
        entity.ConfigCategory,
        entity.ConfigKey,
        entity.ConfigId
      );
    }
    else
    {
      _logger.LogWarning(
        "Configuration '{category}.{key}' (id: {id}) failed to update",
        entity.ConfigCategory,
        entity.ConfigKey,
        entity.ConfigId
      );
    }

    return updated;
  }

  public async Task<bool> SetValue(ConfigurationEntity entity)
  {
    // Add new entry
    if (entity.ConfigId == 0)
    {
      return await AddConfig(
        entity.ConfigCategory,
        entity.ConfigKey,
        entity.ConfigType,
        entity.ConfigValue
      );
    }

    // Handle deleted entries
    if (entity.State == ConfigurationState.Deleted)
      return await DeleteConfig(entity);

    // Update existing entry
    var dbEntity = await GetConfigEntity(entity);
    dbEntity.ConfigValue = entity.ConfigValue;
    dbEntity.ConfigType = entity.ConfigType;
    return await UpdateConfig(dbEntity);
  }

  public async Task<bool> SetValue(string category, string key, string value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.String, value);

    dbEntry.ConfigValue = value;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> SetIntValue(string category, string key, int value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    var safeValue = ConfigValueHelper.FromInt(value);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.Int, safeValue);

    dbEntry.ConfigValue = safeValue;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> SetLongValue(string category, string key, long value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    var safeValue = ConfigValueHelper.FromLong(value);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.Long, safeValue);

    dbEntry.ConfigValue = safeValue;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> SetFloatValue(string category, string key, float value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    var safeValue = ConfigValueHelper.FromFloat(value);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.Float, safeValue);

    dbEntry.ConfigValue = safeValue;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> SetDoubleValue(string category, string key, double value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    var safeValue = ConfigValueHelper.FromDouble(value);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.Double, safeValue);

    dbEntry.ConfigValue = safeValue;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> SetBoolValue(string category, string key, bool value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    var safeValue = ConfigValueHelper.FromBool(value);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.Bool, safeValue);

    dbEntry.ConfigValue = safeValue;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> SetDateTimeValue(string category, string key, DateTime value)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    var safeValue = ConfigValueHelper.FromDateTime(value);

    if (dbEntry == null)
      return await AddConfig(category, key, ConfigurationType.DateTime, safeValue);

    dbEntry.ConfigValue = safeValue;
    return await UpdateConfig(dbEntry);
  }

  public async Task<bool> GetBoolValue(string category, string key, bool fallback)
  {
    var dbEntry = await _configRepo.GetConfigEntity(category, key);
    if (dbEntry == null)
    {
      _logger.LogWarning("Unable to find '{category}.{key}' returning default", category, key);
      return fallback;
    }

    if (ConfigValueHelper.TryExtractBool(dbEntry, out var parsed))
      return parsed;

    LogWrongDataType(dbEntry, ConfigurationType.Bool);
    dbEntry.ConfigType = ConfigurationType.Bool;
    dbEntry.ConfigValue = ConfigValueHelper.FromBool(fallback);
    await _configRepo.UpdateConfigEntry(dbEntry);
    return fallback;
  }

  public async Task<IRnConfigSection> GetConfigSection(string category)
  {
    var configSection = new RnConfigSection(
      _serviceProvider.GetRequiredService<ILoggerAdapter<RnConfigSection>>(),
      this,
      category
    );

    await configSection.ReloadValues();
    return configSection;
  }

  public async Task<List<ConfigurationEntity>> GetConfigValues(string category)
  {
    return await _configRepo.GetConfig(category);
  }

  public async Task<List<ConfigurationEntity>> GetAllConfigValues(string category)
  {
    return await _configRepo.GetAll(category);
  }


  // Internal methods
  private void LogWrongDataType(ConfigurationEntity entity, ConfigurationType expected)
  {
    _logger.LogWarning(
      "Current data type for '{category}.{key}' is '{current}', however it was " +
      "expected to be '{expected}'. This has been rectified using the provided fallback value",
      entity.ConfigCategory,
      entity.ConfigKey,
      entity.ConfigType.ToString("G"),
      expected.ToString("G")
    );
  }

  private async Task<bool> AddConfig(string category, string key, ConfigurationType type, string value)
  {
    var configEntity = new ConfigurationEntity
    {
      ConfigCategory = category,
      ConfigKey = key,
      ConfigValue = value,
      ConfigType = type
    };

    var added = await _configRepo.AddConfigEntry(configEntity) == 1;

    if (added)
    {
      _logger.LogInformation(
        "Added new {type} configuration entry '{category}.{key}'",
        type.ToString("G"), category, key
      );
    }
    else
    {
      _logger.LogWarning(
        "Failed to add new {type} configuration entry '{category}.{key}'",
        type.ToString("G"), category, key
      );
    }

    return added;
  }

  private async Task<ConfigurationEntity> GetConfigEntity(ConfigurationEntity entity)
  {
    if (entity.ConfigId == 0)
      return entity;

    var dbEntity = await _configRepo.GetById(entity.ConfigId);

    if (dbEntity == null)
    {
      // TODO: [REVISE] (ConfigurationService.GetConfigEntity) Better exception
      throw new Exception("Unable to find entity");
    }

    return dbEntity;
  }
}
