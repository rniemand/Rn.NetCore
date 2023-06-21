using System;
using System.IO;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\DirectoryAbstraction.md
public interface IDirectoryAbstraction
{
  IDirectoryInfo CreateDirectory(string path);
  bool Exists(string? path);
  DateTime GetCreationTime(string path);
  DateTime GetCreationTimeUtc(string path);
  DateTime GetLastWriteTime(string path);
  DateTime GetLastWriteTimeUtc(string path);
  DateTime GetLastAccessTime(string path);
  DateTime GetLastAccessTimeUtc(string path);
  string[] GetFiles(string path);
  string[] GetFiles(string path, string searchPattern);
  string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
  string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
  string[] GetDirectories(string path);
  string[] GetDirectories(string path, string searchPattern);
  string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
  string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
  string GetCurrentDirectory();
  void Move(string sourceDirName, string destDirName);
  void Delete(string path);
  void Delete(string path, bool recursive);
}

public class DirectoryAbstraction : IDirectoryAbstraction
{
  public IDirectoryInfo CreateDirectory(string path) => new DirectoryInfoWrapper(Directory.CreateDirectory(path));
  public bool Exists(string? path) => Directory.Exists(path);
  public DateTime GetCreationTime(string path) => Directory.GetCreationTime(path);
  public DateTime GetCreationTimeUtc(string path) => Directory.GetCreationTimeUtc(path);
  public DateTime GetLastWriteTime(string path) => Directory.GetLastWriteTime(path);
  public DateTime GetLastWriteTimeUtc(string path) => Directory.GetLastWriteTimeUtc(path);
  public DateTime GetLastAccessTime(string path) => Directory.GetLastAccessTime(path);
  public DateTime GetLastAccessTimeUtc(string path) => Directory.GetLastAccessTimeUtc(path);
  public string[] GetFiles(string path) => Directory.GetFiles(path);
  public string[] GetFiles(string path, string searchPattern) => Directory.GetFiles(path, searchPattern);
  public string[] GetFiles(string path, string searchPattern, SearchOption searchOption) => Directory.GetFiles(path, searchPattern, searchOption);
  public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.GetFiles(path, searchPattern, enumerationOptions);
  public string[] GetDirectories(string path) => Directory.GetDirectories(path);
  public string[] GetDirectories(string path, string searchPattern) => Directory.GetDirectories(path, searchPattern);
  public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption) => Directory.GetDirectories(path, searchPattern, searchOption);
  public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions) => Directory.GetDirectories(path, searchPattern, enumerationOptions);
  public string GetCurrentDirectory() => Directory.GetCurrentDirectory();
  public void Move(string sourceDirName, string destDirName) => Directory.Move(sourceDirName, destDirName);
  public void Delete(string path) => Directory.Delete(path);
  public void Delete(string path, bool recursive) => Directory.Delete(path, recursive);
}
