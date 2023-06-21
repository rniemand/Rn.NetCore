using System;
using System.IO;

namespace Rn.NetCore.Common.Wrappers;

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
