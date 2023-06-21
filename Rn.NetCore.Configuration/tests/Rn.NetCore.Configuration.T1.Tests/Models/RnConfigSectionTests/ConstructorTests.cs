using NSubstitute;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.Configuration.Models;
using Rn.NetCore.Configuration.Services;

namespace Rn.NetCore.Configuration.T1.Tests.Models.RnConfigSectionTests;

[TestFixture]
public class ConstructorTests
{
  private const string Category = "Rn.DevTesting";

  [Test]
  public void RnConfigSection_Given_Constructed_ShouldSet_Category()
  {
    // arrange
    var logger = Substitute.For<ILoggerAdapter<RnConfigSection>>();
    var configService = Substitute.For<IConfigurationService>();

    // act
    var configSection = new RnConfigSection(logger, configService, Category);

    // assert
    Assert.AreEqual(Category, configSection.Category);
  }
}