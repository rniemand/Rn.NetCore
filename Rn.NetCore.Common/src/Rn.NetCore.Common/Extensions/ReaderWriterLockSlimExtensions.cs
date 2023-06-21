using System;
using System.Threading;

namespace Rn.NetCore.Common.Extensions;

// DOCS: docs\extensions\ReaderWriterLockSlimExtensions.md
[Obsolete("This class is marked for removal soon")]
public static class ReaderWriterLockSlimExtensions
{
  private sealed class WriteLockToken : IDisposable
  {
    private ReaderWriterLockSlim _sync;

    public WriteLockToken(ReaderWriterLockSlim sync)
    {
      _sync = sync;
      sync.EnterWriteLock();
    }

    public void Dispose()
    {
      if (_sync == null)
        return;

      _sync.ExitWriteLock();
      _sync = null;
    }
  }

  private sealed class ReadLockToken : IDisposable
  {
    private ReaderWriterLockSlim _sync;

    public ReadLockToken(ReaderWriterLockSlim sync)
    {
      _sync = sync;
      sync.EnterReadLock();
    }

    public void Dispose()
    {
      if (_sync == null)
        return;

      _sync.ExitReadLock();
      _sync = null;
    }
  }

  [Obsolete("This class is marked for removal soon")]
  public static IDisposable Write(this ReaderWriterLockSlim obj)
  {
    return new WriteLockToken(obj);
  }

  [Obsolete("This class is marked for removal soon")]
  public static IDisposable Read(this ReaderWriterLockSlim obj)
  {
    return new ReadLockToken(obj);
  }
}
