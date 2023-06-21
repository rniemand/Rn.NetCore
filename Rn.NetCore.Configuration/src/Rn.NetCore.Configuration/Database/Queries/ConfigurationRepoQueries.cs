namespace Rn.NetCore.Configuration.Database;

public interface IConfigurationRepoQueries
{
  string GetConfigEntity();
  string AddConfigEntry();
  string UpdateConfigEntry();
  string GetConfig();
  string GetAll();
  string GetById();
  string Delete();
}

public class ConfigurationRepoQueries : IConfigurationRepoQueries
{
  public string GetConfigEntity()
  {
    return @"SELECT *
      FROM `Configuration`
      WHERE
	      `Deleted` = 0 AND
	      `IsCollection` = 0 AND
	      `ConfigCategory` = @ConfigCategory AND
	      `ConfigKey` = @ConfigKey
      LIMIT 1";
  }

  public string AddConfigEntry()
  {
    return @"INSERT INTO `Configuration`
	      (`ConfigType`, `ConfigCategory`, `ConfigKey`, `ConfigValue`)
      VALUES
	      (@ConfigType, @ConfigCategory, @ConfigKey, @ConfigValue)";
  }

  public string UpdateConfigEntry()
  {
    return @"UPDATE `Configuration`
      SET
	      `DateUpdatedUtc` = UTC_TIMESTAMP(6),
	      `ConfigValue` = @ConfigValue,
        `ConfigType` = @ConfigType
      WHERE
	      `ConfigId` = @ConfigId";
  }

  public string GetConfig()
  {
    return @"SELECT *
      FROM `Configuration`
      WHERE
	      `Deleted` = 0 AND
	      `ConfigCategory` = @ConfigCategory
      ORDER BY `ConfigKey` ASC";
  }

  public string GetAll()
  {
    return @"SELECT *
      FROM `Configuration`
      WHERE
	      `ConfigCategory` = @ConfigCategory
      ORDER BY `ConfigKey` ASC";
  }

  public string GetById()
  {
    return @"SELECT *
      FROM `Configuration`
      WHERE
	      `ConfigId` = @ConfigId";
  }

  public string Delete()
  {
    return @"UPDATE `Configuration`
      SET
	      `Deleted` = 1,
	      `DateUpdatedUtc` = UTC_TIMESTAMP(6)
      WHERE
	      `ConfigId` = @ConfigId";
  }
}
