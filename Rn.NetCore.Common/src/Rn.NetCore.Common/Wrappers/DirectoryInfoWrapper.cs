using System;
using System.IO;
using System.Linq;

namespace Rn.NetCore.Common.Wrappers;

// DOCS: docs\wrappers\DirectoryInfoWrapper.md
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

public class DirectoryInfoWrapper : IDirectoryInfo
{
  public FileAttributes Attributes
  {
    get => _directoryInfo.Attributes;
    set => _directoryInfo.Attributes = value;
  }

  public DateTime CreationTime
  {
    get => _directoryInfo.CreationTime;
    set => _directoryInfo.CreationTime = value;
  }

  public DateTime CreationTimeUtc
  {
    get => _directoryInfo.CreationTimeUtc;
    set => _directoryInfo.CreationTimeUtc = value;
  }

  public DateTime LastAccessTime
  {
    get => _directoryInfo.LastAccessTime;
    set => _directoryInfo.LastAccessTime = value;
  }

  public DateTime LastAccessTimeUtc
  {
    get => _directoryInfo.LastAccessTimeUtc;
    set => _directoryInfo.LastAccessTimeUtc = value;
  }

  public DateTime LastWriteTime
  {
    get => _directoryInfo.LastWriteTime;
    set => _directoryInfo.LastWriteTime = value;
  }

  public DateTime LastWriteTimeUtc
  {
    get => _directoryInfo.LastWriteTimeUtc;
    set => _directoryInfo.LastWriteTimeUtc = value;
  }

  public string FullName => _directoryInfo.FullName;
  public string Extension => _directoryInfo.Extension;
  public string Name => _directoryInfo.Name;
  public bool Exists => _directoryInfo.Exists;

  public IDirectoryInfo? Parent
  {
    get
    {
      var parent = _directoryInfo.Parent;
      return parent == null ? null : new DirectoryInfoWrapper(parent);
    }
  }

  public IDirectoryInfo Root => new DirectoryInfoWrapper(_directoryInfo.Root);

  private readonly DirectoryInfo _directoryInfo;

  // Constructors
  public DirectoryInfoWrapper(string path)
  {
    _directoryInfo = new DirectoryInfo(path);
  }

  public DirectoryInfoWrapper(DirectoryInfo directoryInfo)
  {
    _directoryInfo = directoryInfo;
  }


  // Interface methods
  public IFileInfo[] GetFiles() => _directoryInfo
    .GetFiles()
    .Select(x => new FileInfoWrapper(x))
    .Cast<IFileInfo>()
    .ToArray();

  public IFileInfo[] GetFiles(string searchPattern) => _directoryInfo
    .GetFiles(searchPattern)
    .Select(x => new FileInfoWrapper(x))
    .Cast<IFileInfo>()
    .ToArray();

  public IFileInfo[] GetFiles(string searchPattern, SearchOption searchOption) => _directoryInfo
    .GetFiles(searchPattern, searchOption)
    .Select(x => new FileInfoWrapper(x))
    .Cast<IFileInfo>()
    .ToArray();

  public IFileInfo[] GetFiles(string searchPattern, EnumerationOptions enumerationOptions) => _directoryInfo
    .GetFiles(searchPattern, enumerationOptions)
    .Select(x => new FileInfoWrapper(x))
    .Cast<IFileInfo>()
    .ToArray();
  
  public IDirectoryInfo[] GetDirectories() => _directoryInfo
    .GetDirectories()
    .Select(x => new DirectoryInfoWrapper(x))
    .Cast<IDirectoryInfo>()
    .ToArray();

  public IDirectoryInfo[] GetDirectories(string searchPattern) => _directoryInfo
    .GetDirectories(searchPattern)
    .Select(x => new DirectoryInfoWrapper(x))
    .Cast<IDirectoryInfo>()
    .ToArray();

  public IDirectoryInfo[] GetDirectories(string searchPattern, SearchOption searchOption) => _directoryInfo
    .GetDirectories(searchPattern, searchOption)
    .Select(x => new DirectoryInfoWrapper(x))
    .Cast<IDirectoryInfo>()
    .ToArray();

  public IDirectoryInfo[] GetDirectories(string searchPattern, EnumerationOptions enumerationOptions) => _directoryInfo
    .GetDirectories(searchPattern, enumerationOptions)
    .Select(x => new DirectoryInfoWrapper(x))
    .Cast<IDirectoryInfo>()
    .ToArray();

  public void Refresh() => _directoryInfo.Refresh();
  public void Delete() => _directoryInfo.Delete();
  public void Delete(bool recursive) => _directoryInfo.Delete(recursive);
}
