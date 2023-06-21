using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Rn.NetCore.Common.Logging;

// docs\logging\LoggerExtensions.md
public static class LoggerExtensions
{
  public static void LogUnexpectedException<TLogger>(this ILoggerAdapter<TLogger> logger, Exception ex) =>
    logger.LogError("An unexpected exception of type {exType} was thrown in {method}. {exMessage}. | {exStack}",
      ex.GetType().Name,
      GetFullMethodName(2),
      ex.Message,
      ex.HumanStackTrace());

  public static string HumanStackTrace(this Exception ex)
  {
    var sb = new StringBuilder();
    WalkException(sb, ex, 1);
    return sb.ToString();
  }

  private static void WalkException(StringBuilder sb, Exception ex, int level)
  {
    sb.Append(level == 1 ? "" : "    ")
      .Append(level)
      .Append($" ({ex.GetType().FullName}) ")
      .Append(ex.Message)
      .AppendLine();

    if (ex.InnerException != null)
    {
      // ReSharper disable once TailRecursiveCall
      WalkException(sb, ex.InnerException, level + 1);
    }
  }

  [ExcludeFromCodeCoverage]
  public static string GetFullMethodName(int frameIndex)
  {
    try
    {
      var methodBase = new StackTrace().GetFrame(frameIndex)?.GetMethod();
      if (methodBase is null)
        return "(unknown)";

      var methodName = methodBase.Name;
      var className = methodBase.ReflectedType?.FullName;
      return string.IsNullOrWhiteSpace(className) ? methodName : $"{className}.{methodName}";
    }
    catch
    {
      // Swallow
      return "(unknown)";
    }
  }
}
