using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\FileAbstraction.md
public interface IFileAbstraction
{
  StreamReader OpenText(string path);
  StreamWriter CreateText(string path);
  StreamWriter AppendText(string path);
  void Copy(string sourceFileName, string destFileName);
  void Copy(string sourceFileName, string destFileName, bool overwrite);
  FileStream Create(string path);
  FileStream Create(string path, int bufferSize);
  FileStream Create(string path, int bufferSize, FileOptions options);
  void Delete(string path);
  bool Exists(string path);
  FileStream Open(string path, FileMode mode);
  FileStream Open(string path, FileMode mode, FileAccess access);
  FileStream Open(string path, FileMode mode, FileAccess access, FileShare share);
  void SetCreationTime(string path, DateTime creationTime);
  void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
  DateTime GetCreationTime(string path);
  DateTime GetCreationTimeUtc(string path);
  void SetLastAccessTime(string path, DateTime lastAccessTime);
  void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
  DateTime GetLastAccessTime(string path);
  DateTime GetLastAccessTimeUtc(string path);
  void SetLastWriteTime(string path, DateTime lastWriteTime);
  void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
  DateTime GetLastWriteTime(string path);
  DateTime GetLastWriteTimeUtc(string path);
  FileAttributes GetAttributes(string path);
  void SetAttributes(string path, FileAttributes fileAttributes);
  FileStream OpenRead(string path);
  FileStream OpenWrite(string path);
  string ReadAllText(string path);
  string ReadAllText(string path, Encoding encoding);
  void WriteAllText(string path, string contents);
  void WriteAllText(string path, string contents, Encoding encoding);
  byte[] ReadAllBytes(string path);
  void WriteAllBytes(string path, byte[] bytes);
  string[] ReadAllLines(string path);
  string[] ReadAllLines(string path, Encoding encoding);
  IEnumerable<string> ReadLines(string path);
  IEnumerable<string> ReadLines(string path, Encoding encoding);
  void WriteAllLines(string path, string[] contents);
  void WriteAllLines(string path, IEnumerable<string> contents);
  void WriteAllLines(string path, string[] contents, Encoding encoding);
  void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding);
  void AppendAllText(string path, string contents);
  void AppendAllText(string path, string contents, Encoding encoding);
  void AppendAllLines(string path, IEnumerable<string> contents);
  void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding);
  void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName);
  void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
  void Move(string sourceFileName, string destFileName);
  void Move(string sourceFileName, string destFileName, bool overwrite);
  void Encrypt(string path);
  void Decrypt(string path);
  Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default(CancellationToken));
  Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken));
  Task WriteAllTextAsync(string path, string contents, CancellationToken cancellationToken = default(CancellationToken));
  Task WriteAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken));
  Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default(CancellationToken));
  Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default(CancellationToken));
  Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default(CancellationToken));
  Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken));
  Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default(CancellationToken));
  Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken));
  Task AppendAllTextAsync(string path, string contents, CancellationToken cancellationToken = default(CancellationToken));
  Task AppendAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken));
  Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default(CancellationToken));
  Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default(CancellationToken));
}

public class FileAbstraction : IFileAbstraction
{
  public StreamReader OpenText(string path) => File.OpenText(path);
  public StreamWriter CreateText(string path) => File.CreateText(path);
  public StreamWriter AppendText(string path) => File.AppendText(path);
  public void Copy(string sourceFileName, string destFileName) => File.Copy(sourceFileName, destFileName);
  public void Copy(string sourceFileName, string destFileName, bool overwrite) => File.Copy(sourceFileName, destFileName, overwrite);
  public FileStream Create(string path) => File.Create(path);
  public FileStream Create(string path, int bufferSize) => File.Create(path, bufferSize);
  public FileStream Create(string path, int bufferSize, FileOptions options) => File.Create(path, bufferSize, options);
  public void Delete(string path) => File.Delete(path);
  public bool Exists(string path) => File.Exists(path);
  public FileStream Open(string path, FileMode mode) => File.Open(path, mode);
  public FileStream Open(string path, FileMode mode, FileAccess access) => File.Open(path, mode, access);
  public FileStream Open(string path, FileMode mode, FileAccess access, FileShare share) => File.Open(path, mode, access, share);
  public void SetCreationTime(string path, DateTime creationTime) => File.SetCreationTimeUtc(path, creationTime);
  public void SetCreationTimeUtc(string path, DateTime creationTimeUtc) => File.SetCreationTimeUtc(path, creationTimeUtc);
  public DateTime GetCreationTime(string path) => File.GetCreationTime(path);
  public DateTime GetCreationTimeUtc(string path) => File.GetCreationTimeUtc(path);
  public void SetLastAccessTime(string path, DateTime lastAccessTime) => File.SetLastAccessTime(path, lastAccessTime);
  public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc) => File.SetCreationTimeUtc(path, lastAccessTimeUtc);
  public DateTime GetLastAccessTime(string path) => File.GetLastAccessTime(path);
  public DateTime GetLastAccessTimeUtc(string path) => File.GetLastAccessTimeUtc(path);
  public void SetLastWriteTime(string path, DateTime lastWriteTime) => File.SetLastWriteTime(path, lastWriteTime);
  public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc) => File.SetLastWriteTimeUtc(path, lastWriteTimeUtc);
  public DateTime GetLastWriteTime(string path) => File.GetLastWriteTime(path);
  public DateTime GetLastWriteTimeUtc(string path) => File.GetLastWriteTimeUtc(path);
  public FileAttributes GetAttributes(string path) => File.GetAttributes(path);
  public void SetAttributes(string path, FileAttributes fileAttributes) => File.SetAttributes(path, fileAttributes);
  public FileStream OpenRead(string path) => File.OpenRead(path);
  public FileStream OpenWrite(string path) => File.OpenWrite(path);
  public string ReadAllText(string path) => File.ReadAllText(path);
  public string ReadAllText(string path, Encoding encoding) => File.ReadAllText(path, encoding);
  public void WriteAllText(string path, string contents) => File.WriteAllText(path, contents);
  public void WriteAllText(string path, string contents, Encoding encoding) => File.WriteAllText(path, contents, encoding);
  public byte[] ReadAllBytes(string path) => File.ReadAllBytes(path);
  public void WriteAllBytes(string path, byte[] bytes) => File.WriteAllBytes(path, bytes);
  public string[] ReadAllLines(string path) => File.ReadAllLines(path);
  public string[] ReadAllLines(string path, Encoding encoding) => File.ReadAllLines(path, encoding);
  public IEnumerable<string> ReadLines(string path) => File.ReadLines(path);
  public IEnumerable<string> ReadLines(string path, Encoding encoding) => File.ReadLines(path, encoding);
  public void WriteAllLines(string path, string[] contents) => File.WriteAllLines(path, contents);
  public void WriteAllLines(string path, IEnumerable<string> contents) => File.WriteAllLines(path, contents);
  public void WriteAllLines(string path, string[] contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);
  public void WriteAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.WriteAllLines(path, contents, encoding);
  public void AppendAllText(string path, string contents) => File.AppendAllText(path, contents);
  public void AppendAllText(string path, string contents, Encoding encoding) => File.AppendAllText(path, contents, encoding);
  public void AppendAllLines(string path, IEnumerable<string> contents) => File.AppendAllLines(path, contents);
  public void AppendAllLines(string path, IEnumerable<string> contents, Encoding encoding) => File.AppendAllLines(path, contents, encoding);
  public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName) => File.Replace(sourceFileName, destinationFileName, destinationBackupFileName);
  public void Replace(string sourceFileName, string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors) => File.Replace(sourceFileName, destinationFileName, destinationBackupFileName, ignoreMetadataErrors);
  public void Move(string sourceFileName, string destFileName) => File.Move(sourceFileName, destFileName);
  public void Move(string sourceFileName, string destFileName, bool overwrite) => File.Move(sourceFileName, destFileName, overwrite);

  [SupportedOSPlatform("windows")]
  public void Encrypt(string path) => File.Encrypt(path);

  [SupportedOSPlatform("windows")]
  public void Decrypt(string path) => File.Decrypt(path);

  public async Task<string> ReadAllTextAsync(string path, CancellationToken cancellationToken = default) => await File.ReadAllTextAsync(path, cancellationToken);
  public async Task<string> ReadAllTextAsync(string path, Encoding encoding, CancellationToken cancellationToken = default) => await File.ReadAllTextAsync(path, encoding, cancellationToken);
  public async Task WriteAllTextAsync(string path, string contents, CancellationToken cancellationToken = default) => await File.WriteAllTextAsync(path, contents, cancellationToken);
  public async Task WriteAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default) => await File.WriteAllTextAsync(path, contents, encoding, cancellationToken);
  public async Task<byte[]> ReadAllBytesAsync(string path, CancellationToken cancellationToken = default) => await File.ReadAllBytesAsync(path, cancellationToken);
  public async Task WriteAllBytesAsync(string path, byte[] bytes, CancellationToken cancellationToken = default) => await File.WriteAllBytesAsync(path, bytes, cancellationToken);
  public async Task<string[]> ReadAllLinesAsync(string path, CancellationToken cancellationToken = default) => await File.ReadAllLinesAsync(path, cancellationToken);
  public async Task<string[]> ReadAllLinesAsync(string path, Encoding encoding, CancellationToken cancellationToken = default) => await File.ReadAllLinesAsync(path, encoding, cancellationToken);
  public async Task WriteAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default) => await File.WriteAllLinesAsync(path, contents, cancellationToken);
  public async Task WriteAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default) => await File.WriteAllLinesAsync(path, contents, cancellationToken);
  public async Task AppendAllTextAsync(string path, string contents, CancellationToken cancellationToken = default) => await File.AppendAllTextAsync(path, contents, cancellationToken);
  public async Task AppendAllTextAsync(string path, string contents, Encoding encoding, CancellationToken cancellationToken = default) => await File.AppendAllTextAsync(path, contents, encoding, cancellationToken);
  public async Task AppendAllLinesAsync(string path, IEnumerable<string> contents, CancellationToken cancellationToken = default) => await File.AppendAllLinesAsync(path, contents, cancellationToken);
  public async Task AppendAllLinesAsync(string path, IEnumerable<string> contents, Encoding encoding, CancellationToken cancellationToken = default) => await File.AppendAllLinesAsync(path, contents, cancellationToken);
}
