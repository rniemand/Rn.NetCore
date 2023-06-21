[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / RuntimeInformationAbstraction

# RuntimeInformationAbstraction
Wraps and exposes common properties from the [RuntimeInformation class](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation?view=net-6.0).

```cs
public interface IRuntimeInformationAbstraction
{
  string FrameworkDescription { get; }
  string RuntimeIdentifier { get; }
  string OSDescription { get; }
  Architecture OSArchitecture { get; }
  Architecture ProcessArchitecture { get; }

  bool IsOSPlatform(OSPlatform osPlatform);
}
```