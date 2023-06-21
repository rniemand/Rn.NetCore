[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / DirectoryAbstraction

# DirectoryAbstraction
Wraps and exposes common properties from the [Directory class](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=net-6.0).

```cs
public interface IDirectoryAbstraction
{
  IDirectoryInfo CreateDirectory(string path);
  bool Exists(string? path);
  DateTime GetCreationTime(string path);
  DateTime GetCreationTimeUtc(string path);
  DateTime GetLastWriteTime(string path);
  DateTime GetLastWriteTimeUtc(string path);
  DateTime GetLastAccessTime(string path);
  DateTime GetLastAccessTimeUtc(string path);
  string[] GetFiles(string path);
  string[] GetFiles(string path, string searchPattern);
  string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
  string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
  string[] GetDirectories(string path);
  string[] GetDirectories(string path, string searchPattern);
  string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
  string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
  string GetCurrentDirectory();
  void Move(string sourceDirName, string destDirName);
  void Delete(string path);
  void Delete(string path, bool recursive);
}
```