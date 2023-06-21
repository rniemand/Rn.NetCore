using System;
using NUnit.Framework;
using Rn.NetCore.Configuration.Database;
using Rn.NetCore.Configuration.Enums;

namespace Rn.NetCore.Configuration.T1.Tests.Entities;

[TestFixture]
public class ConfigurationEntityTests
{
  [Test]
  public void ConfigurationEntity_Given_Constructed_ShouldDefault_AllProperties()
  {
    // arrange
    var entity = new ConfigurationEntity();

    // assert
    Assert.AreEqual(0, entity.ConfigId);
    Assert.IsFalse(entity.Deleted);
    Assert.IsFalse(entity.IsCollection);
    Assert.AreEqual(DateTime.MinValue, entity.DateAddedUtc);
    Assert.AreEqual(DateTime.MinValue, entity.DateUpdatedUtc);
    Assert.AreEqual(ConfigurationType.String, entity.ConfigType);
    Assert.AreEqual(string.Empty, entity.ConfigCategory);
    Assert.AreEqual(string.Empty, entity.ConfigKey);
    Assert.AreEqual(string.Empty, entity.ConfigValue);
    Assert.AreEqual(ConfigurationState.Pristine, entity.State);
  }
}
