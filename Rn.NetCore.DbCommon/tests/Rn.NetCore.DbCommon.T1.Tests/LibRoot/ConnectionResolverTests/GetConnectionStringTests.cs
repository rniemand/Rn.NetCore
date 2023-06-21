using NUnit.Framework;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot.ConnectionResolverTests;

[TestFixture]
public class GetConnectionStringTests
{
  [Test]
  public void GetConnectionString_GivenEmptyString_ShouldReturnNull()
  {
    // arrange
    var resolver = TestHelper.GetConnectionResolver();

    // act
    var connectionString = resolver.GetConnectionString(string.Empty);

    // assert
    Assert.That(connectionString, Is.Null);
  }

  [Test]
  public void GetConnectionString_GivenHasNoConnectionStrings_ShouldReturnNull()
  {
    // arrange
    var resolver = TestHelper.GetConnectionResolver();

    // act
    var connectionString = resolver.GetConnectionString("alias");

    // assert
    Assert.That(connectionString, Is.Null);
  }

  [Test]
  public void GetConnectionString_GivenConnectionStringMissing_ShouldReturnNull()
  {
    // arrange
    var configuration = new ConfigurationRootBuilder()
      .WithConnectionString("One", "ConnectionString1")
      .Build();

    var resolver = TestHelper.GetConnectionResolver(configuration: configuration);

    // act
    var connectionString = resolver.GetConnectionString("alias");

    // assert
    Assert.That(connectionString, Is.Null);
  }

  [Test]
  public void GetConnectionString_GivenConnectionStringExists_ShouldReturnConnectionString()
  {
    // arrange
    var configuration = new ConfigurationRootBuilder()
      .WithConnectionString("One", "ConnectionString1")
      .Build();

    var resolver = TestHelper.GetConnectionResolver(configuration: configuration);

    // act
    var connectionString = resolver.GetConnectionString("one");

    // assert
    Assert.That(connectionString, Is.EqualTo("ConnectionString1"));
  }
}
