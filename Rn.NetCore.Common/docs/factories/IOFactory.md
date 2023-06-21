[Home](/README.md) / [Factories](/docs/factories/README.md) / IOFactory

# IOFactory
More to come...

```cs
public interface IIOFactory
{
  IFileInfo GetFileInfo(string fileName);
  IFileInfo GetFileInfo(FileInfo fileInfo);
  IDirectoryInfo GetDirectoryInfo(string path);
  IDirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo);
}
```