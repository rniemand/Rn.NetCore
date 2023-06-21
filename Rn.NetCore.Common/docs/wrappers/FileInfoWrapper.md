[Home](/README.md) / [Wrappers](/docs/wrappers/README.md) / FileInfoWrapper

# FileInfoWrapper
Wrapper for the [FileInfo class](https://docs.microsoft.com/en-us/dotnet/api/system.io.fileinfo?view=net-6.0).

```cs
public interface IFileInfo : IFileSystemInfo
{
  long Length { get; }
  string? DirectoryName { get; }
  IDirectoryInfo? Directory { get; }
  bool IsReadOnly { get; }
}
```