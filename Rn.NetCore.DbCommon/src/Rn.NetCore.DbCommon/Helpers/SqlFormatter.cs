using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Text;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon;

public interface ISqlFormatter
{
  string Format(string sql, object? param = null);
  string GetLoggableError(Exception ex, IDbConnection cnn, string sql, object? param = null);
}

public class SqlFormatter : ISqlFormatter
{
  private readonly ILoggerAdapter<SqlFormatter> _logger;

  public SqlFormatter(ILoggerAdapter<SqlFormatter> logger)
  {
    _logger = logger;
  }


  // Public methods
  public string Format(string sql, object? param = null)
  {
    if (param is null)
      return sql;

    var formattedSql = sql;

    foreach (var (placeholder, sqlValue) in GetReplacementDictionary(param))
      formattedSql = formattedSql.Replace(placeholder, sqlValue);

    return formattedSql;
  }

  public static string GetSqlString(object value)
  {
    return value switch
    {
      DateTime dateValue => $"'{dateValue:O}'",
      int intValue => intValue.ToString("D"),
      string stringValue => $"'{stringValue}'",
      long longValue => longValue.ToString("D"),
      double doubleValue => doubleValue.ToString("N").Replace(",", "").Replace(".00", ""),
      bool booleanValue => booleanValue ? "1" : "0",
      _ => "NULL"
    };
  }

  public string GetLoggableError(Exception ex, IDbConnection cnn, string sql, object? param = null)
  {
    try
    {
      return new StringBuilder()
        .Append("Exception thrown while running SQL command on DB '")
        .Append(cnn.Database)
        .Append("' \"")
        .Append(Format(sql, param))
        .Append("\" :: ")
        .Append(ex.GetType().Name)
        .Append(": ")
        .Append(ex.Message)
        .ToString();
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error generating loggable error: {msg}", e.Message);
      return $"{ex.GetType().Name}: {ex.Message}";
    }
  }


  // Internal methods
  private Dictionary<string, string> GetReplacementDictionary(object param)
  {
    var properties = param.GetType().GetProperties();
    var replacementDictionary = new Dictionary<string, string>();

    // ReSharper disable once LoopCanBeConvertedToQuery
    foreach (var propertyInfo in properties)
    {
      replacementDictionary.Add($"@{propertyInfo.Name}", GetFormattedValue(param, propertyInfo));
    }

    return replacementDictionary;
  }

  private string GetFormattedValue(object param, PropertyInfo propertyInfo) =>
    propertyInfo.PropertyType.IsEnum
      ? GetEnumValue(param, propertyInfo)
      : GetNullableValue(param, propertyInfo);

  [ExcludeFromCodeCoverage]
  private string GetEnumValue(object param, PropertyInfo propertyInfo)
  {
    try
    {
      var value = propertyInfo.GetValue(param);
      if (value is null)
        return "-1";

      var changeType = Convert.ChangeType(value, propertyInfo.PropertyType);
      var intValue = (int)changeType;
      return intValue.ToString("D");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Unable to cast enum value: {message}", ex.Message);
      return "-1";
    }
  }

  private static string GetNullableValue(object param, PropertyInfo propertyInfo)
  {
    var rawValue = propertyInfo.GetValue(param);
    return rawValue is null ? "NULL" : GetSqlString(rawValue);
  }
}
