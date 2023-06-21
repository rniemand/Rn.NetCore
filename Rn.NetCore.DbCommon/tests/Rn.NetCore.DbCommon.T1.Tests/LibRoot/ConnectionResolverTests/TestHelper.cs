using Microsoft.Extensions.Configuration;
using NSubstitute;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot.ConnectionResolverTests;

public static class TestHelper
{
  public static ConnectionResolver GetConnectionResolver(
    IConfiguration? configuration = null,
    RnDbConfig? dbConfig = null)
  {
    return new ConnectionResolver(
      configuration ?? Substitute.For<IConfiguration>(),
      dbConfig ?? RnDbConfigBuilder.Default);
  }
}
