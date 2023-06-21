using System;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Factories;

// DOCS: docs\factories\RandomFactory.md
public interface IRandomFactory
{
  IRandom GetRandom();
  IRandom GetRandom(int seed);
  IRandom GetRandom(Random random);
}

public class RandomFactory : IRandomFactory
{
  public IRandom GetRandom()
    => new RandomWrapper();
    
  public IRandom GetRandom(int seed) 
    => new RandomWrapper(seed);

  public IRandom GetRandom(Random random) 
    => new RandomWrapper(random);
}
