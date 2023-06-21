using NSubstitute;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.MailUtils.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.MailUtils.T1.Tests.Factories.RnMailUtilsFactoryTests;

public static class TestHelper
{
  public static RnMailUtilsFactory GetRnMailUtilsFactory(
    ILoggerAdapter<RnMailUtilsFactory>? logger = null,
    RnMailConfig? mailConfig = null) =>
    new(
      logger ?? Substitute.For<ILoggerAdapter<RnMailUtilsFactory>>(),
      mailConfig ?? RnMailConfigBuilder.Default);
}
