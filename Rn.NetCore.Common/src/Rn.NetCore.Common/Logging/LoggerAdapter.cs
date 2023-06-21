using System;
using Microsoft.Extensions.Logging;

namespace Rn.NetCore.Common.Logging;

// DOCS: docs\logging\LoggerAdapter.md
public class LoggerAdapter<T> : ILoggerAdapter<T>
{
  private readonly ILogger<T> _logger;

  // Constructor
  public LoggerAdapter(ILogger<T> logger)
  {
    _logger = logger;
  }


  public void LogTrace(string message)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(message);
  }

  public void LogTrace<T0>(string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(message, arg1);
  }

  public void LogTrace<T0, T1>(string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(message, arg1, arg2);
  }

  public void LogTrace<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(message, arg1, arg2, arg3);
  }

  public void LogTrace(string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(message, args);
  }

  public void LogTrace(Exception ex, string message)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(ex, message);
  }

  public void LogTrace<T0>(Exception ex, string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(ex, message, arg1);
  }

  public void LogTrace<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(ex, message, arg1, arg2);
  }

  public void LogTrace<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(ex, message, arg1, arg2, arg3);
  }

  public void LogTrace(Exception ex, string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Trace))
      return;

    _logger.LogTrace(ex, message, args);
  }


  public void LogDebug(string message)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(message);
  }

  public void LogDebug<T0>(string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(message, arg1);
  }

  public void LogDebug<T0, T1>(string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(message, arg1, arg2);
  }

  public void LogDebug<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(message, arg1, arg2, arg3);
  }

  public void LogDebug(string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(message, args);
  }

  public void LogDebug(Exception ex, string message)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(ex, message);
  }

  public void LogDebug<T0>(Exception ex, string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(ex, message, arg1);
  }

  public void LogDebug<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(ex, message, arg1, arg2);
  }

  public void LogDebug<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(ex, message, arg1, arg2, arg3);
  }

  public void LogDebug(Exception ex, string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Debug))
      return;

    _logger.LogDebug(ex, message, args);
  }


  public void LogInformation(string message)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(message);
  }

  public void LogInformation<T0>(string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(message, arg1);
  }

  public void LogInformation<T0, T1>(string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(message, arg1, arg2);
  }

  public void LogInformation<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(message, arg1, arg2, arg3);
  }

  public void LogInformation(string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(message, args);
  }

  public void LogInformation(Exception ex, string message)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(ex, message);
  }

  public void LogInformation<T0>(Exception ex, string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(ex, message, arg1);
  }

  public void LogInformation<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(ex, message, arg1, arg2);
  }

  public void LogInformation<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(ex, message, arg1, arg2, arg3);
  }

  public void LogInformation(Exception ex, string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Information))
      return;

    _logger.LogInformation(ex, message, args);
  }


  public void LogWarning(string message)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(message);
  }

  public void LogWarning<T0>(string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(message, arg1);
  }

  public void LogWarning<T0, T1>(string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(message, arg1, arg2);
  }

  public void LogWarning<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(message, arg1, arg2, arg3);
  }

  public void LogWarning(string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(message, args);
  }

  public void LogWarning(Exception ex, string message)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(ex, message);
  }

  public void LogWarning<T0>(Exception ex, string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(ex, message, arg1);
  }

  public void LogWarning<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(ex, message, arg1, arg2);
  }

  public void LogWarning<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(ex, message, arg1, arg2, arg3);
  }

  public void LogWarning(Exception ex, string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Warning))
      return;

    _logger.LogWarning(ex, message, args);
  }


  public void LogError(string message)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(message);
  }

  public void LogError<T0>(string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(message, arg1);
  }

  public void LogError<T0, T1>(string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(message, arg1, arg2);
  }

  public void LogError<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(message, arg1, arg2, arg3);
  }

  public void LogError(string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(message, args);
  }

  public void LogError(Exception ex, string message)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(ex, message);
  }

  public void LogError<T0>(Exception ex, string message, T0 arg1)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(ex, message, arg1);
  }

  public void LogError<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(ex, message, arg1, arg2);
  }

  public void LogError<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(ex, message, arg1, arg2, arg3);
  }

  public void LogError(Exception ex, string message, params object[] args)
  {
    if (!_logger.IsEnabled(LogLevel.Error))
      return;

    _logger.LogError(ex, message, args);
  }
}
