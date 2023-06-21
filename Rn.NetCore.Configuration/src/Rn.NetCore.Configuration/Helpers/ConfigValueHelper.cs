using System;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.Configuration.Enums;

namespace Rn.NetCore.Configuration.Helpers;

public static class ConfigValueHelper
{
  public static string FromInt(int value)
  {
    return value.ToString("D");
  }

  public static string FromLong(long value)
  {
    return value.ToString("G");
  }

  public static string FromFloat(float value)
  {
    return value.ToString("N");
  }

  public static string FromDouble(double value)
  {
    return value.ToString("N");
  }

  public static string FromBool(bool value)
  {
    return value ? "true" : "false";
  }

  public static string FromDateTime(DateTime value)
  {
    return value.ToString("u");
  }

  public static bool TryExtractInt(ConfigurationEntity entity, out int parsed)
  {
    parsed = 0;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (entity?.ConfigType != ConfigurationType.Int)
      return false;

    return int.TryParse(entity.ConfigValue, out parsed);
  }

  public static bool TryExtractLong(ConfigurationEntity entity, out long parsed)
  {
    parsed = 0;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (entity?.ConfigType != ConfigurationType.Long)
      return false;

    return long.TryParse(entity.ConfigValue, out parsed);
  }

  public static bool TryExtractFloat(ConfigurationEntity entity, out float parsed)
  {
    parsed = 0;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (entity?.ConfigType != ConfigurationType.Float)
      return false;

    return float.TryParse(entity.ConfigValue, out parsed);
  }

  public static bool TryExtractDouble(ConfigurationEntity entity, out double parsed)
  {
    parsed = 0;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (entity?.ConfigType != ConfigurationType.Double)
      return false;

    return double.TryParse(entity.ConfigValue, out parsed);
  }

  public static bool TryExtractBool(ConfigurationEntity entity, out bool parsed)
  {
    parsed = false;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (entity?.ConfigType != ConfigurationType.Bool)
      return false;

    return bool.TryParse(entity.ConfigValue, out parsed);
  }

  public static bool TryExtractDateTime(ConfigurationEntity entity, out DateTime parsed)
  {
    parsed = DateTime.MinValue;

    // ReSharper disable once ConvertIfStatementToReturnStatement
    if (entity?.ConfigType != ConfigurationType.DateTime)
      return false;

    return DateTime.TryParse(entity.ConfigValue, out parsed);
  }
}
