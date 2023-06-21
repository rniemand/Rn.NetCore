[Home](/README.md) / [Wrappers](/docs/wrappers/README.md) / DirectoryInfoWrapper

# DirectoryInfoWrapper
Wrapper for the [DirectoryInfo class](https://docs.microsoft.com/en-us/dotnet/api/system.io.directoryinfo?view=net-6.0).

```cs
public interface IDirectoryInfo : IFileSystemInfo
{
  IDirectoryInfo? Parent { get; }
  IDirectoryInfo Root { get; }

  IFileInfo[] GetFiles();
  IFileInfo[] GetFiles(string searchPattern);
  IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption);
  IFileInfo[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions);
  IDirectoryInfo[] GetDirectories();
  IDirectoryInfo[] GetDirectories(string searchPattern);
  IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption);
  IDirectoryInfo[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions);
  void Delete(bool recursive);
}
```