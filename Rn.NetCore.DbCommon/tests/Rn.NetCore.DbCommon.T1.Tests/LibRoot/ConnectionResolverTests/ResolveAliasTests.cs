using NUnit.Framework;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot.ConnectionResolverTests;

[TestFixture]
public class ResolveAliasTests
{
  private const string DefaultConnection = "DefaultConnection";

  [Test]
  public void ResolveAlias_GivenEmptyString_ShouldReturnDefaultAlias()
  {
    // arrange
    var rnDbConfig = new RnDbConfigBuilder()
      .WithDefaultConnection(DefaultConnection)
      .Build();

    var resolver = TestHelper.GetConnectionResolver(
      dbConfig: rnDbConfig);

    // act
    var resolveAlias = resolver.ResolveAlias(string.Empty);

    // assert
    Assert.That(resolveAlias, Is.EqualTo(DefaultConnection));
  }

  [Test]
  public void ResolveAlias_GivenNoLookupsDefined_ShouldReturnDefaultAlias()
  {
    // arrange
    var rnDbConfig = new RnDbConfigBuilder()
      .WithDefaultConnection(DefaultConnection)
      .Build();

    var resolver = TestHelper.GetConnectionResolver(
      dbConfig: rnDbConfig);

    // act
    var resolveAlias = resolver.ResolveAlias("TestRepo");

    // assert
    Assert.That(resolveAlias, Is.EqualTo(DefaultConnection));
  }

  [Test]
  public void ResolveAlias_GivenNoLookupValue_ShouldReturnDefaultAlias()
  {
    // arrange
    var rnDbConfig = new RnDbConfigBuilder()
      .WithDefaultConnection(DefaultConnection)
      .Build();

    var resolver = TestHelper.GetConnectionResolver(
      dbConfig: rnDbConfig);

    resolver.RegisterAlias("Alias1", "ConnectionString1");

    // act
    var resolveAlias = resolver.ResolveAlias("TestRepo");

    // assert
    Assert.That(resolveAlias, Is.EqualTo(DefaultConnection));
  }

  [Test]
  public void ResolveAlias_GivenHasLookup_ShouldReturnLookupValue()
  {
    // arrange
    var rnDbConfig = new RnDbConfigBuilder()
      .WithDefaultConnection(DefaultConnection)
      .Build();

    var resolver = TestHelper.GetConnectionResolver(
      dbConfig: rnDbConfig);

    resolver.RegisterAlias("Alias1", "ConnectionString1");

    // act
    var resolveAlias = resolver.ResolveAlias("alias1");

    // assert
    Assert.That(resolveAlias, Is.EqualTo("ConnectionString1"));
  }

  [Test]
  public void ResolveAlias_GivenHasGlobalAliasLookups_ShouldBeAbleToResolveGlobalAlias()
  {
    // arrange
    var rnDbConfig = new RnDbConfigBuilder()
      .WithDefaultConnection(DefaultConnection)
      .WithAliasLookup("Alias2", "ConnectionString2")
      .Build();

    var resolver = TestHelper.GetConnectionResolver(
      dbConfig: rnDbConfig);

    resolver.RegisterAlias("Alias1", "ConnectionString1");

    // act
    var resolveAlias = resolver.ResolveAlias("alias2");

    // assert
    Assert.That(resolveAlias, Is.EqualTo("ConnectionString2"));
  }
}
