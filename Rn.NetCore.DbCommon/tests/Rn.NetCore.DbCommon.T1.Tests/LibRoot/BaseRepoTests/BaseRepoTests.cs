using NSubstitute;
using NUnit.Framework;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot.BaseRepoTests;

[TestFixture]
public class BaseRepoTests
{
  [Test]
  public void Constructor_GivenCalled_ShouldResolveLogger()
  {
    // arrange
    var baseRepoHelper = TestHelper.GetBaseRepoHelper();

    // act
    var _ = new TestRepo(baseRepoHelper);

    // assert
    baseRepoHelper.Received(1).ResolveLogger<TestRepo>();
  }

  [Test]
  public void Constructor_GivenCalled_ShouldResolveDbConnectionHelper()
  {
    // arrange
    var baseRepoHelper = TestHelper.GetBaseRepoHelper();

    // act
    var _ = new TestRepo(baseRepoHelper);

    // assert
    baseRepoHelper.Received(1).ResolveConnectionHelper();
  }

  [Test]
  public void Constructor_GivenCalled_ShouldResolveMetricService()
  {
    // arrange
    var baseRepoHelper = TestHelper.GetBaseRepoHelper();

    // act
    var _ = new TestRepo(baseRepoHelper);

    // assert
    baseRepoHelper.Received(1).ResolveMetricService();
  }

  [Test]
  public void Constructor_GivenCalled_ShouldResolveSqlFormatter()
  {
    // arrange
    var baseRepoHelper = TestHelper.GetBaseRepoHelper();

    // act
    var _ = new TestRepo(baseRepoHelper);

    // assert
    baseRepoHelper.Received(1).ResolveSqlFormatter();
  }

  [Test]
  public void Constructor_GivenCalled_ShouldResolveRnDbConfig()
  {
    // arrange
    var baseRepoHelper = TestHelper.GetBaseRepoHelper();

    // act
    var _ = new TestRepo(baseRepoHelper);

    // assert
    baseRepoHelper.Received(1).GetRnDbConfig();
  }
}
