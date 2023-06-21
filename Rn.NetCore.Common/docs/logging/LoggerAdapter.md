[Home](/README.md) / [Logging](/docs/logging/README.md) / LoggerAdapter

# LoggerAdapter
More to come...

```cs
public interface ILoggerAdapter<T>
{
  void LogTrace(string message);
  void LogTrace<T0>(string message, T0 arg1);
  void LogTrace<T0, T1>(string message, T0 arg1, T1 arg2);
  void LogTrace<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3);
  void LogTrace(string message, params object[] args);
  void LogTrace(Exception ex, string message);
  void LogTrace<T0>(Exception ex, string message, T0 arg1);
  void LogTrace<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2);
  void LogTrace<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3);
  void LogTrace(Exception ex, string message, params object[] args);

  void LogDebug(string message);
  void LogDebug<T0>(string message, T0 arg1);
  void LogDebug<T0, T1>(string message, T0 arg1, T1 arg2);
  void LogDebug<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3);
  void LogDebug(string message, params object[] args);
  void LogDebug(Exception ex, string message);
  void LogDebug<T0>(Exception ex, string message, T0 arg1);
  void LogDebug<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2);
  void LogDebug<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3);
  void LogDebug(Exception ex, string message, params object[] args);

  void LogInformation(string message);
  void LogInformation<T0>(string message, T0 arg1);
  void LogInformation<T0, T1>(string message, T0 arg1, T1 arg2);
  void LogInformation<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3);
  void LogInformation(string message, params object[] args);
  void LogInformation(Exception ex, string message);
  void LogInformation<T0>(Exception ex, string message, T0 arg1);
  void LogInformation<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2);
  void LogInformation<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3);
  void LogInformation(Exception ex, string message, params object[] args);

  void LogWarning(string message);
  void LogWarning<T0>(string message, T0 arg1);
  void LogWarning<T0, T1>(string message, T0 arg1, T1 arg2);
  void LogWarning<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3);
  void LogWarning(string message, params object[] args);
  void LogWarning(Exception ex, string message);
  void LogWarning<T0>(Exception ex, string message, T0 arg1);
  void LogWarning<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2);
  void LogWarning<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3);
  void LogWarning(Exception ex, string message, params object[] args);

  void LogError(string message);
  void LogError<T0>(string message, T0 arg1);
  void LogError<T0, T1>(string message, T0 arg1, T1 arg2);
  void LogError<T0, T1, T2>(string message, T0 arg1, T1 arg2, T2 arg3);
  void LogError(string message, params object[] args);
  void LogError(Exception ex, string message);
  void LogError<T0>(Exception ex, string message, T0 arg1);
  void LogError<T0, T1>(Exception ex, string message, T0 arg1, T1 arg2);
  void LogError<T0, T1, T2>(Exception ex, string message, T0 arg1, T1 arg2, T2 arg3);
  void LogError(Exception ex, string message, params object[] args);
}
```