[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / EnvironmentAbstraction

# EnvironmentAbstraction
Wraps and exposes common properties from the [Environment class](https://docs.microsoft.com/en-us/dotnet/api/system.environment?view=net-6.0).

```cs
public interface IEnvironmentAbstraction
{
  int CurrentManagedThreadId { get; }
  int ExitCode { get; }
  int ProcessorCount { get; }
  string CommandLine { get; }
  string CurrentDirectory { get; }
  int ProcessId { get; }
  bool Is64BitProcess { get; }
  bool Is64BitOperatingSystem { get; }
  string NewLine { get; }
  OperatingSystem OSVersion { get; }
  Version Version { get; }
  string UserName { get; }
  string UserDomainName { get; }
  int SystemPageSize { get; }
  string MachineName { get; }
  string SystemDirectory { get; }
  bool UserInteractive { get; }
  long WorkingSet { get; }


  void Exit(int exitCode);
  void FailFast(string message);
  void FailFast(string message, Exception exception);
  string[] GetCommandLineArgs();
  string? GetEnvironmentVariable(string variable);
  string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target);
  IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target);
  void SetEnvironmentVariable(string variable, string? value);
  void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target);
  string ExpandEnvironmentVariables(string name);
  string GetFolderPath(Environment.SpecialFolder folder);
  string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option);
  string[] GetLogicalDrives();
  IDictionary GetEnvironmentVariables();
}
```