using NSubstitute;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.MailUtils.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.MailUtils.T1.Tests.Helpers.MailTemplateHelperTests;

public static class TestHelper
{
  public static MailTemplateHelper GetMailTemplateHelper(
    ILoggerAdapter<MailTemplateHelper>? logger = null,
    IMailTemplateProvider? tplProvider = null,
    RnMailConfig? mailConfig = null) =>
    new(
      logger ?? Substitute.For<ILoggerAdapter<MailTemplateHelper>>(),
      tplProvider ?? Substitute.For<IMailTemplateProvider>(),
      mailConfig ?? RnMailConfigBuilder.Default);
}
