using System.Runtime.InteropServices;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\RuntimeInformationAbstraction.md
public interface IRuntimeInformationAbstraction
{
  string FrameworkDescription { get; }
  string RuntimeIdentifier { get; }
  string OSDescription { get; }
  Architecture OSArchitecture { get; }
  Architecture ProcessArchitecture { get; }

  bool IsOSPlatform(OSPlatform osPlatform);
}

public class RuntimeInformationAbstraction : IRuntimeInformationAbstraction
{
  public string FrameworkDescription => RuntimeInformation.FrameworkDescription;
  public string RuntimeIdentifier => RuntimeInformation.RuntimeIdentifier;
  public string OSDescription => RuntimeInformation.OSDescription;
  public Architecture OSArchitecture => RuntimeInformation.OSArchitecture;
  public Architecture ProcessArchitecture => RuntimeInformation.ProcessArchitecture;

  public bool IsOSPlatform(OSPlatform osPlatform) => RuntimeInformation.IsOSPlatform(osPlatform);
}
