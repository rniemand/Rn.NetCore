using System;
using System.Linq;

namespace Rn.NetCore.Common.Extensions;

// DOCS: docs\extensions\StringExtensions.md
public static class StringExtensions
{
  public static string AppendIfMissing(this string input, string append)
  {
    if (string.IsNullOrWhiteSpace(input) || string.IsNullOrWhiteSpace(append))
      return input;

    if (input.EndsWith(append))
      return input;

    return input + append;
  }

  public static string LowerTrim(this string input) => string.IsNullOrWhiteSpace(input)
    ? string.Empty
    : input.ToLower().Trim();

  public static string UpperTrim(this string input) => string.IsNullOrWhiteSpace(input)
    ? string.Empty
    : input.ToUpper().Trim();

  public static bool AsBool(this string input, bool fallback = false)
  {
    if (string.IsNullOrWhiteSpace(input))
      return fallback;

    return input.LowerTrim() switch
    {
      "true" => true,
      "1" => true,
      "yes" => true,
      "on" => true,
      "enabled" => true,
      "false" => false,
      "0" => false,
      "no" => false,
      "off" => false,
      "disabled" => false,
      _ => fallback
    };
  }

  public static int AsInt(this string input, int fallback = 0)
  {
    if (string.IsNullOrWhiteSpace(input))
      return fallback;

    return int.TryParse(input, out var parsed) ? parsed : fallback;
  }

  public static long AsLong(this string input, long fallback = 0)
  {
    if (string.IsNullOrWhiteSpace(input))
      return fallback;

    return long.TryParse(input, out var parsed) ? parsed : fallback;
  }

  public static float AsFloat(this string input, float fallback = 0)
  {
    if (string.IsNullOrWhiteSpace(input))
      return fallback;

    return float.TryParse(input, out var parsed) ? parsed : fallback;
  }

  public static bool IgnoreCaseEquals(this string? value, string? compare)
  {
    if (value == null || compare == null)
      return false;

    return value.Equals(compare, StringComparison.InvariantCultureIgnoreCase);
  }

  public static bool IgnoreCaseContains(this string? value, string? contains)
  {
    if (value == null || contains == null)
      return false;

    return value.Contains(contains, StringComparison.InvariantCultureIgnoreCase);
  }

  public static bool IgnoreCaseEndsWith(this string? value, string? endsWith)
  {
    if (value == null || endsWith == null)
      return false;

    return value.EndsWith(endsWith, StringComparison.InvariantCultureIgnoreCase);
  }

  public static bool IgnoreCaseStartsWith(this string? value, string? startsWith)
  {
    if (value == null || startsWith == null)
      return false;

    return value.StartsWith(startsWith, StringComparison.InvariantCultureIgnoreCase);
  }

  public static string FallbackTo(this string input, string fallback)
    => string.IsNullOrWhiteSpace(input.LowerTrim()) ? fallback : input;

  public static bool SameByteArray(this byte[] input, byte[] compare)
  {
    if (input.Length != compare.Length)
      return false;

    return !input.Where((t, i) => t != compare[i]).Any();
  }
}
