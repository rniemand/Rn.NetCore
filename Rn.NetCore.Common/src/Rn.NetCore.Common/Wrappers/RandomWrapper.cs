using System;

namespace Rn.NetCore.Common.Wrappers;

// DOCS: docs\wrappers\RandomWrapper.md
public interface IRandom
{
  int Next();
  int Next(int minValue, int maxValue);
  int Next(int maxValue);
  double NextDouble();
  void NextBytes(byte[] buffer);
  void NextBytes(Span<byte> buffer);
}

public class RandomWrapper : IRandom
{
  private readonly Random _random;

  // Constructors
  public RandomWrapper()
  {
    _random = new Random();
  }

  public RandomWrapper(Random random)
  {
    _random = random;
  }

  public RandomWrapper(int seed)
  {
    _random = new Random(seed);
  }

  // Interface methods
  public int Next() => _random.Next();
  public int Next(int minValue, int maxValue) => _random.Next(minValue, maxValue);
  public int Next(int maxValue) => _random.Next(maxValue);
  public double NextDouble() => _random.NextDouble();
  public void NextBytes(byte[] buffer) => _random.NextBytes(buffer);
  public void NextBytes(Span<byte> buffer) => _random.NextBytes(buffer);
}
