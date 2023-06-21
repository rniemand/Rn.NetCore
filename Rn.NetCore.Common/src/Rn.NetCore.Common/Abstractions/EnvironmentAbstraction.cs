using System;
using System.Collections;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\EnvironmentAbstraction.md
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

public class EnvironmentAbstraction : IEnvironmentAbstraction
{
  public int CurrentManagedThreadId => Environment.CurrentManagedThreadId;
  public int ExitCode => Environment.ExitCode;
  public int ProcessorCount => Environment.ProcessorCount;
  public string CommandLine => Environment.CommandLine;
  public string CurrentDirectory => Environment.CurrentDirectory;
  public int ProcessId => Environment.ProcessId;
  public bool Is64BitProcess => Environment.Is64BitProcess;
  public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;
  public string NewLine => Environment.NewLine;
  public OperatingSystem OSVersion => Environment.OSVersion;
  public Version Version => Environment.Version;
  public string UserName => Environment.UserName;
  public string UserDomainName => Environment.UserDomainName;
  public int SystemPageSize => Environment.SystemPageSize;
  public string MachineName => Environment.MachineName;
  public string SystemDirectory => Environment.SystemDirectory;
  public bool UserInteractive => Environment.UserInteractive;
  public long WorkingSet => Environment.WorkingSet;


  public void Exit(int exitCode) => Environment.Exit(exitCode);
  public void FailFast(string message) => Environment.FailFast(message);
  public string[] GetCommandLineArgs() => Environment.GetCommandLineArgs();
  public string? GetEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);
  public IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target) => Environment.GetEnvironmentVariables(target);
  public void SetEnvironmentVariable(string variable, string? value) => Environment.SetEnvironmentVariable(variable, value);
  public void SetEnvironmentVariable(string variable, string? value, EnvironmentVariableTarget target) => Environment.SetEnvironmentVariable(variable, value, target);
  public string ExpandEnvironmentVariables(string name) => Environment.ExpandEnvironmentVariables(name);
  public string GetFolderPath(Environment.SpecialFolder folder) => Environment.GetFolderPath(folder);
  public string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option) => Environment.GetFolderPath(folder, option);
  public string[] GetLogicalDrives() => Environment.GetLogicalDrives();
  public IDictionary GetEnvironmentVariables() => Environment.GetEnvironmentVariables();
  public void FailFast(string message, Exception exception) => Environment.FailFast(message, exception);
  public string? GetEnvironmentVariable(string variable, EnvironmentVariableTarget target) => Environment.GetEnvironmentVariable(variable, target);
}
