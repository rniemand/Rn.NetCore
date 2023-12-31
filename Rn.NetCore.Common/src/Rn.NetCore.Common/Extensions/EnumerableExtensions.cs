using System;
using System.Collections.Generic;
using System.Linq;

namespace Rn.NetCore.Common.Extensions;

// DOCS: docs\extensions\EnumerableExtensions.md
public static class EnumerableExtensions
{
  public static T PickRandom<T>(this IEnumerable<T> source) =>
    source.PickRandom(1).Single();

  public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) =>
    source.Shuffle().Take(count);

  public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) =>
    source.OrderBy(x => Guid.NewGuid());

  public static List<string> TrimAndLowerAll(this IEnumerable<string> source) =>
    source.Select(entry => entry.LowerTrim()).ToList();
}
