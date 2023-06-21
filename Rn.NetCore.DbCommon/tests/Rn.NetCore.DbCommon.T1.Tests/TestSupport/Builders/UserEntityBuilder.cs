namespace Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;

public class UserEntityBuilder
{
  public static UserEntity Default => new UserEntityBuilder().Build();

  private readonly UserEntity _entity = new();

  public UserEntityBuilder WithUserId(int userId)
  {
    _entity.UserId = userId;
    return this;
  }

  public UserEntity Build() => _entity;
}
