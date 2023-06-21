using NUnit.Framework;
using System;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers.DbConnectionHelperBaseTests;

[TestFixture]
public class GetConnectionTests
{
  [Test]
  public void GetConnection_GivenNotOverriden_ShouldThrow()
  {
    // arrange
    var connectionHelper = TestHelper.GetTestDbConnectionHelper();

    // act
    var ex = Assert.Throws<NotImplementedException>(() => connectionHelper.GetConnection(""));

    // assert
    Assert.That(ex.Message, Is.EqualTo("GetConnection() not implemented"));
  }
}
