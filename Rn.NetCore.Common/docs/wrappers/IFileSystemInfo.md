[Home](/README.md) / [Wrappers](/docs/wrappers/README.md) / IFileSystemInfo

# IFileSystemInfo
More to come...

```cs
public interface IFileSystemInfo
{
  FileAttributes Attributes { get; set; }
  DateTime CreationTime { get; set; }
  DateTime CreationTimeUtc { get; set; }
  DateTime LastAccessTime { get; set; }
  DateTime LastAccessTimeUtc { get; set; }
  DateTime LastWriteTime { get; set; }
  DateTime LastWriteTimeUtc { get; set; }
  string FullName { get; }
  string Extension { get; }
  string Name { get; }
  bool Exists { get; }

  void Refresh();
  void Delete();
  string ToString();
}
```