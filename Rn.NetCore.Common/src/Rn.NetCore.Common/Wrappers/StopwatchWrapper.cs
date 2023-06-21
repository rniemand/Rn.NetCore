using System;
using System.Diagnostics;

namespace Rn.NetCore.Common.Wrappers;

// DOCS: docs\wrappers\StopwatchWrapper.md
public interface IStopwatch
{
  bool IsRunning { get; }
  TimeSpan Elapsed { get; }
  long ElapsedMilliseconds { get; }
  long ElapsedTicks { get; }

  void Start();
  void Stop();
  void Reset();
  void Restart();
}

public class StopwatchWrapper : IStopwatch
{
  public bool IsRunning => _stopwatch.IsRunning;
  public TimeSpan Elapsed => _stopwatch.Elapsed;
  public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;
  public long ElapsedTicks => _stopwatch.ElapsedTicks;

  private readonly Stopwatch _stopwatch;

  // Constructors
  public StopwatchWrapper()
  {
    _stopwatch = new Stopwatch();
  }

  public StopwatchWrapper(Stopwatch stopwatch)
  {
    _stopwatch = stopwatch;
  }


  // Interface methods
  public void Start() => _stopwatch.Start();
  public void Stop() => _stopwatch.Stop();
  public void Reset() => _stopwatch.Reset();
  public void Restart() => _stopwatch.Restart();
}
