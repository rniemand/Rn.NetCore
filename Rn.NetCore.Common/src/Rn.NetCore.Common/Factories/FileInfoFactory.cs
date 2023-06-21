using System;
using System.IO;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Factories;

// DOCS: docs\factories\FileInfoFactory.md
[Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
public interface IFileInfoFactory
{
  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  IFileInfo GetFileInfo(string fileName);

  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  IFileInfo GetFileInfo(FileInfo fileInfo);
}

[Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
public class FileInfoFactory : IFileInfoFactory
{
  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  public IFileInfo GetFileInfo(string fileName)
    => new FileInfoWrapper(fileName);

  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  public IFileInfo GetFileInfo(FileInfo fileInfo)
    => new FileInfoWrapper(fileInfo);
}
