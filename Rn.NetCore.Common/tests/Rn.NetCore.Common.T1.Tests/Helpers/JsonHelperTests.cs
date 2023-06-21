using NUnit.Framework;
using Rn.NetCore.Common.Helpers;
using Rn.NetCore.Common.T1.Tests.TestSupport;

namespace Rn.NetCore.Common.T1.Tests.Helpers;

[TestFixture]
public class JsonHelperTests
{
  private const string InvalidJson = "<>fd23";
  private const string ValidJson = "{ \"name\": \"my name\" }";

  [Test]
  public void TryDeserializeObject_GivenInvalidJson_ShouldReturnFalse()
  {
    // arrange
    var jsonHelper = new JsonHelper();
    
    // act
    var success = jsonHelper.TryDeserializeObject<TestJsonObject>(InvalidJson, out var _);

    // assert
    Assert.That(success, Is.False);
  }

  [Test]
  public void TryDeserializeObject_GivenValidJson_ShouldReturnTrue()
  {
    // arrange
    var jsonHelper = new JsonHelper();

    // act
    var success = jsonHelper.TryDeserializeObject<TestJsonObject>(ValidJson, out var _);

    // assert
    Assert.That(success, Is.True);
  }

  [Test]
  public void TryDeserializeObject_GivenValidJson_ShouldReturnMappedObject()
  {
    // arrange
    var jsonHelper = new JsonHelper();

    // act
    jsonHelper.TryDeserializeObject<TestJsonObject>(ValidJson, out var mapped);

    // assert
    Assert.That(mapped, Is.InstanceOf<TestJsonObject>());
    Assert.That(mapped.Name, Is.EqualTo("my name"));
  }
}
