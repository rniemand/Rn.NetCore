[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / PathAbstraction

# PathAbstraction
Wraps and exposes common properties from the [Path class](https://docs.microsoft.com/en-us/dotnet/api/system.io.path?view=net-6.0).

```cs
public interface IPathAbstraction
{
  char DirectorySeparatorChar { get; }
  char AltDirectorySeparatorChar { get; }
  char VolumeSeparatorChar { get; }
  char PathSeparator { get; }

  string GetFileName(string path);
  string GetFileNameWithoutExtension(string path);
  string GetRandomFileName();
  bool HasExtension(string path);
  string Combine(string path1, string path2);
  string Combine(string path1, string path2, string path3);
  string Combine(string path1, string path2, string path3, string path4);
  string Combine(params string[] paths);
  string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);
  string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);
  string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, ReadOnlySpan<char> path4);
  string Join(string path1, string path2);
  string Join(string path1, string path2, string path3);
  string Join(string path1, string path2, string path3, string path4);
  string Join(params string[] paths);
  string GetRelativePath(string relativeTo, string path);
  string TrimEndingDirectorySeparator(string path);
  bool EndsInDirectorySeparator(string path);
  string? GetDirectoryName(string? path);
  string GetFullPath(string path);
  string GetFullPath(string path, string basePath);
  string GetTempPath();
  string GetTempFileName();
}
```