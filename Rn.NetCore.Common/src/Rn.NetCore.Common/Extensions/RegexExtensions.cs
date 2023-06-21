using System.Text.RegularExpressions;

namespace Rn.NetCore.Common.Extensions;

// DOCS: docs\extensions\RegexExtensions.md
public static class RegexExtensions
{
  public static bool MatchesRegex(this string input, string pattern) => 
    !string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

  public static Match GetRegexMatch(this string input, string pattern) => 
    Regex.Match(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);

  public static MatchCollection GetRegexMatches(this string input, string pattern) => 
    Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
}
