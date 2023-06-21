using System;
using System.IO;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\PathAbstraction.md
public interface IPathAbstraction
{
  char DirectorySeparatorChar { get; }
  char AltDirectorySeparatorChar { get; }
  char VolumeSeparatorChar { get; }
  char PathSeparator { get; }

  string GetFileName(string path);
  string GetFileNameWithoutExtension(string path);
  string GetRandomFileName();
  bool HasExtension(string path);
  string Combine(string path1, string path2);
  string Combine(string path1, string path2, string path3);
  string Combine(string path1, string path2, string path3, string path4);
  string Combine(params string[] paths);
  string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);
  string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);
  string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, ReadOnlySpan<char> path4);
  string Join(string path1, string path2);
  string Join(string path1, string path2, string path3);
  string Join(string path1, string path2, string path3, string path4);
  string Join(params string[] paths);
  string GetRelativePath(string relativeTo, string path);
  string TrimEndingDirectorySeparator(string path);
  bool EndsInDirectorySeparator(string path);
  string? GetDirectoryName(string? path);
  string GetFullPath(string path);
  string GetFullPath(string path, string basePath);
  string GetTempPath();
  string GetTempFileName();
}

public class PathAbstraction : IPathAbstraction
{
  public char DirectorySeparatorChar => Path.AltDirectorySeparatorChar;
  public char AltDirectorySeparatorChar => Path.AltDirectorySeparatorChar;
  public char VolumeSeparatorChar => Path.VolumeSeparatorChar;
  public char PathSeparator => Path.PathSeparator;

  public string GetFileName(string path) => Path.GetFileName(path);
  public string GetFileNameWithoutExtension(string path) => Path.GetFileNameWithoutExtension(path);
  public string GetRandomFileName() => Path.GetRandomFileName();
  public bool HasExtension(string path) => Path.HasExtension(path);
  public string Combine(string path1, string path2) => Path.Combine(path1, path2);
  public string Combine(string path1, string path2, string path3) => Path.Combine(path1, path2, path3);
  public string Combine(string path1, string path2, string path3, string path4) => Path.Combine(path1, path2, path3, path4);
  public string Combine(params string[] paths) => Path.Combine(paths);
  public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2) => Path.Join(path1, path2);
  public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3) => Path.Join(path1, path2, path3);
  public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, ReadOnlySpan<char> path4) => Path.Join(path1, path2, path3, path4);
  public string Join(string path1, string path2) => Path.Join(path1, path2);
  public string Join(string path1, string path2, string path3) => Path.Join(path1, path2, path3);
  public string Join(string path1, string path2, string path3, string path4) => Path.Join(path1, path2, path3, path4);
  public string Join(params string[] paths) => Path.Join(paths);
  public string GetRelativePath(string relativeTo, string path) => Path.GetRelativePath(relativeTo, path);
  public string TrimEndingDirectorySeparator(string path) => Path.TrimEndingDirectorySeparator(path);
  public bool EndsInDirectorySeparator(string path) => Path.EndsInDirectorySeparator(path);
  public string? GetDirectoryName(string? path) => Path.GetDirectoryName(path);
  public string GetFullPath(string path) => Path.GetFullPath(path);
  public string GetFullPath(string path, string basePath) => Path.GetFullPath(path, basePath);
  public string GetTempPath() => Path.GetTempPath();
  public string GetTempFileName() => Path.GetTempFileName();
}
