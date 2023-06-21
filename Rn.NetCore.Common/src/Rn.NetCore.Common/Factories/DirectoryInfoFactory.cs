using System;
using System.IO;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Factories;

// DOCS: docs\factories\DirectoryInfoFactory.md
[Obsolete("DirectoryInfoFactory is obsolete, please make use of IOFactory")]
public interface IDirectoryInfoFactory
{
  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  IDirectoryInfo GetDirectoryInfo(string path);

  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  IDirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo);
}

[Obsolete("DirectoryInfoFactory is obsolete, please make use of IOFactory")]
public class DirectoryInfoFactory : IDirectoryInfoFactory
{
  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  public IDirectoryInfo GetDirectoryInfo(string path)
    => new DirectoryInfoWrapper(path);

  [Obsolete("FileInfoFactory is obsolete, please make use of IOFactory")]
  public IDirectoryInfo GetDirectoryInfo(DirectoryInfo directoryInfo)
    => new DirectoryInfoWrapper(directoryInfo);
}
