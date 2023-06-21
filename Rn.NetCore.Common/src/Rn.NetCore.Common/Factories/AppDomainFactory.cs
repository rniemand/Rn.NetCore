using System;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Factories;

// DOCS: docs\factories\AppDomainFactory.md
public interface IAppDomainFactory
{
  IAppDomain GetAppDomain();
  IAppDomain GetAppDomain(AppDomain appDomain);
}

public class AppDomainFactory : IAppDomainFactory
{
  public IAppDomain GetAppDomain()
    => new AppDomainWrapper(AppDomain.CurrentDomain);

  public IAppDomain GetAppDomain(AppDomain appDomain)
    => new AppDomainWrapper(appDomain);
}
