[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / FileAbstraction

# FileAbstraction
Wraps and exposes common properties from the [File class](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=net-6.0).

```cs
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
```