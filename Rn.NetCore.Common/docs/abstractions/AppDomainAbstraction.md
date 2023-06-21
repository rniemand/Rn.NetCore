[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / AppDomainAbstraction

# AppDomainAbstraction
Wraps and exposes common properties from the [AppDomain class](https://docs.microsoft.com/en-us/dotnet/api/system.appdomain?view=net-6.0).

```cs
public interface IAppDomainAbstraction
{
  IAppDomain CurrentDomain { get; }
}
```