using System.Diagnostics;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\StopwatchAbstraction.md
public interface IStopwatchAbstraction
{
  long Frequency { get; }
  bool IsHighResolution { get; }
  IStopwatch StartNew();
  long GetTimestamp();
}

public class StopwatchAbstraction : IStopwatchAbstraction
{
  public long Frequency => Stopwatch.Frequency;
  public bool IsHighResolution => Stopwatch.IsHighResolution;

  public IStopwatch StartNew() => new StopwatchWrapper(Stopwatch.StartNew());
  public long GetTimestamp() => Stopwatch.GetTimestamp();
}
