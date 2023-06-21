using System;
using Rn.NetCore.Common.Wrappers;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\AppDomainAbstraction.md
public interface IAppDomainAbstraction
{
  IAppDomain CurrentDomain { get; }
}

public class AppDomainAbstraction : IAppDomainAbstraction
{
  public IAppDomain CurrentDomain
    => new AppDomainWrapper(AppDomain.CurrentDomain);
}
