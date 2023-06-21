#nullable enable
using System;

namespace Rn.NetCore.Common.Wrappers;

// DOCS: docs\wrappers\AppDomainWrapper.md
public interface IAppDomain
{
  string BaseDirectory { get; }
  string FriendlyName { get; }
  int Id { get; }
}

public class AppDomainWrapper : IAppDomain
{
  public string BaseDirectory => _appDomain.BaseDirectory;
  public string FriendlyName => _appDomain.FriendlyName;
  public int Id => _appDomain.Id;

  private readonly AppDomain _appDomain;

  public AppDomainWrapper(AppDomain appDomain)
  {
    _appDomain = appDomain;
  }
}
