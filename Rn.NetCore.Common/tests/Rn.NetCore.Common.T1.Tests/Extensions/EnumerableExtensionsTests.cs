using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rn.NetCore.Common.Extensions;

namespace Rn.NetCore.Common.T1.Tests.Extensions;

[TestFixture]
public class EnumerableExtensionsTests
{
  private readonly List<int> _values = new() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

  [Test]
  public void PickRandom_GivenCalled3Times_ShouldReturn_DifferentValues()
  {
    // Arrange
    var picks = new List<int>();

    // Act
    for (var i = 0; i < 3; i++)
    {
      picks.Add(_values.PickRandom());
    }

    // Assert
    Assert.Greater(picks.Distinct().Count(), 1);
  }

  [Test]
  public void TrimAndLowerAll_GivenCalled_ShouldReturn_ParsedCollection()
  {
    // Arrange
    var strings = new List<string>{"Hello" ,"  WOrld   "};

    // Act
    var processed = strings.TrimAndLowerAll();

    // Assert
    Assert.AreEqual("hello", processed[0]);
    Assert.AreEqual("world", processed[1]);
  }
}