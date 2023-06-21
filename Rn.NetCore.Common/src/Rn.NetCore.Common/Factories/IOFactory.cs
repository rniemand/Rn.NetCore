using System.IO;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Factories;

// DOCS: docs\factories\IOFactory.md
public interface IIOFactory
{
  IFileInfo GetFileInfo(string fileName);
  IFileInfo GetFileInfo(FileInfo fileInfo);
  IDirectoryInfo GetDirectoryInfo(string path);
  IDirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo);
}

public class IOFactory : IIOFactory
{
  public IFileInfo GetFileInfo(string fileName) =>
    new FileInfoWrapper(fileName);

  public IFileInfo GetFileInfo(FileInfo fileInfo) =>
    new FileInfoWrapper(fileInfo);

  public IDirectoryInfo GetDirectoryInfo(string path)
    => new DirectoryInfoWrapper(path);

  public IDirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo)
    => new DirectoryInfoWrapper(directoryInfo);
}
