[Home](/README.md) / [Wrappers](/docs/wrappers/README.md) / StopwatchWrapper

# StopwatchWrapper
More to come...

```cs
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
```