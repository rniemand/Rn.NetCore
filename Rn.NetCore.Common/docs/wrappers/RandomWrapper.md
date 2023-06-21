[Home](/README.md) / [Wrappers](/docs/wrappers/README.md) / RandomWrapper

# RandomWrapper
More to come...

```cs
public interface IRandom
{
  int Next();
  int Next(int minValue, int maxValue);
  int Next(int maxValue);
  double NextDouble();
  void NextBytes(byte[] buffer);
  void NextBytes(Span<byte> buffer);
}
```