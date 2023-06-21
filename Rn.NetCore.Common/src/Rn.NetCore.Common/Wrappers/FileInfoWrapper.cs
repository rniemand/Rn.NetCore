using System;
using System.IO;

namespace Rn.NetCore.Common.Wrappers;

// DOCS: docs\wrappers\FileInfoWrapper.md
public interface IFileInfo : IFileSystemInfo
{
  long Length { get; }
  string? DirectoryName { get; }
  IDirectoryInfo? Directory { get; }
  bool IsReadOnly { get; }
}

public class FileInfoWrapper : IFileInfo
{
  public FileAttributes Attributes
  {
    get => _fileInfo.Attributes;
    set => _fileInfo.Attributes = value;
  }

  public DateTime CreationTime
  {
    get => _fileInfo.CreationTime;
    set => _fileInfo.CreationTime = value;
  }

  public DateTime CreationTimeUtc
  {
    get => _fileInfo.CreationTimeUtc;
    set => _fileInfo.CreationTimeUtc = value;
  }

  public DateTime LastAccessTime
  {
    get => _fileInfo.LastAccessTime;
    set => _fileInfo.LastAccessTime = value;
  }

  public DateTime LastAccessTimeUtc
  {
    get => _fileInfo.LastAccessTimeUtc;
    set => _fileInfo.LastAccessTimeUtc = value;
  }

  public DateTime LastWriteTime
  {
    get => _fileInfo.LastWriteTime;
    set => _fileInfo.LastWriteTime = value;
  }

  public DateTime LastWriteTimeUtc
  {
    get => _fileInfo.LastWriteTimeUtc;
    set => _fileInfo.LastWriteTimeUtc = value;
  }

  public string FullName => _fileInfo.FullName;
  public string Extension => _fileInfo.Extension;
  public string Name => _fileInfo.Name;
  public bool Exists => _fileInfo.Exists;

  public long Length => _fileInfo.Length;
  public string? DirectoryName => _fileInfo.DirectoryName;
  public bool IsReadOnly => _fileInfo.IsReadOnly;
  public IDirectoryInfo? Directory
  {
    get
    {
      var info = _fileInfo.Directory;
      return info == null ? null : new DirectoryInfoWrapper(info);
    }
  }

  private readonly FileInfo _fileInfo;

  // Constructors
  public FileInfoWrapper(string fileName)
  {
    _fileInfo = new FileInfo(fileName);
  }

  public FileInfoWrapper(FileInfo fileInfo)
  {
    _fileInfo = fileInfo;
  }


  // Interface methods
  public void Refresh() => _fileInfo.Refresh();
  public void Delete() => _fileInfo.Delete();
}
