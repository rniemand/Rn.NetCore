[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / StopwatchAbstraction

# StopwatchAbstraction
Wraps and exposes common properties from the [Stopwatch class](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.stopwatch?view=net-6.0).

```cs
public interface IStopwatchAbstraction
{
  long Frequency { get; }
  bool IsHighResolution { get; }
  IStopwatch StartNew();
  long GetTimestamp();
}
```