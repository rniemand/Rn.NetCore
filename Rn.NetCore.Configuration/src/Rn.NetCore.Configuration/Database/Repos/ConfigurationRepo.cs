using System.Collections.Generic;
using System.Threading.Tasks;
using Rn.NetCore.DbCommon;

namespace Rn.NetCore.Configuration.Database;

public interface IConfigurationRepo
{
  Task<ConfigurationEntity> GetConfigEntity(string category, string key);
  Task<int> AddConfigEntry(ConfigurationEntity entity);
  Task<int> UpdateConfigEntry(ConfigurationEntity entity);
  Task<List<ConfigurationEntity>> GetConfig(string category);
  Task<List<ConfigurationEntity>> GetAll(string category);
  Task<ConfigurationEntity> GetById(int configId);
  Task<int> Delete(int configId);
}

public class ConfigurationRepo : BaseRepo<ConfigurationRepo>, IConfigurationRepo
{
  private readonly IConfigurationRepoQueries _queries;

  public ConfigurationRepo(IBaseRepoHelper baseRepoHelper, IConfigurationRepoQueries queries)
    : base(baseRepoHelper)
  {
    _queries = queries;
  }

  // Interface methods
  public async Task<ConfigurationEntity> GetConfigEntity(string category, string key)
  {
    return await GetSingle<ConfigurationEntity>(
      nameof(GetConfigEntity),
      _queries.GetConfigEntity(),
      new
      {
        ConfigCategory = category,
        ConfigKey = key
      }
    );
  }

  public async Task<int> AddConfigEntry(ConfigurationEntity entity)
  {
    return await ExecuteAsync(
      nameof(AddConfigEntry),
      _queries.AddConfigEntry(),
      entity
    );
  }

  public async Task<int> UpdateConfigEntry(ConfigurationEntity entity)
  {
    return await ExecuteAsync(
      nameof(UpdateConfigEntry),
      _queries.UpdateConfigEntry(),
      entity
    );
  }

  public async Task<List<ConfigurationEntity>> GetConfig(string category)
  {
    return await GetList<ConfigurationEntity>(
      nameof(GetConfig),
      _queries.GetConfig(),
      new { ConfigCategory = category }
    );
  }

  public async Task<List<ConfigurationEntity>> GetAll(string category)
  {
    return await GetList<ConfigurationEntity>(
      nameof(GetAll),
      _queries.GetAll(),
      new { ConfigCategory = category }
    );
  }

  public async Task<ConfigurationEntity> GetById(int configId)
  {
    return await GetSingle<ConfigurationEntity>(
      nameof(GetById),
      _queries.GetById(),
      new { ConfigId = configId }
    );
  }

  public async Task<int> Delete(int configId)
  {
    return await ExecuteAsync(
      nameof(Delete),
      _queries.Delete(),
      new { ConfigId = configId }
    );
  }
}
