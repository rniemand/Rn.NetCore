[Home](/README.md) / [Wrappers](/docs/wrappers/README.md) / AppDomainWrapper

# AppDomainWrapper
Wrapper for the [AppDomain class](https://docs.microsoft.com/en-us/dotnet/api/system.appdomain?view=net-6.0).

```cs
public interface IAppDomain
{
  string BaseDirectory { get; }
  string FriendlyName { get; }
  int Id { get; }
}
```