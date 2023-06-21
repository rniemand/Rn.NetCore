using Newtonsoft.Json;

namespace Rn.NetCore.Common.T1.Tests.TestSupport;

public class TestJsonObject
{
  [JsonProperty("name")]
  public string Name { get; set; } = string.Empty;
}
