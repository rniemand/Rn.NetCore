using System.Diagnostics;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Factories;

// DOCS: docs\factories\StopwatchFactory.md
public interface IStopwatchFactory
{
  IStopwatch GetStopwatch();
  IStopwatch GetStopwatch(Stopwatch stopwatch);
  IStopwatch StartNew();
}

public class StopwatchFactory : IStopwatchFactory
{
  public IStopwatch GetStopwatch()
    => new StopwatchWrapper();

  public IStopwatch GetStopwatch(Stopwatch stopwatch)
    => new StopwatchWrapper(stopwatch);

  public IStopwatch StartNew()
    => new StopwatchWrapper(Stopwatch.StartNew());
}
