using System;
using System.Threading.Tasks;
using Rn.NetCore.DbCommon;

namespace DevConsole.DatabaseTesting;

public interface IUserRepo
{
  Task<UserEntity> GetUser();
}

public class UserRepo : BaseRepo<UserRepo>, IUserRepo
{
  public UserRepo(IBaseRepoHelper baseRepoHelper)
    : base(baseRepoHelper)
  { }

  public async Task<UserEntity> GetUser()
  {
    return await GetSingle<UserEntity>(
      nameof(GetUser),
      "SELECT * FROM `Users` WHERE `Username` = @Username LIMIT 1",
      new TestParams1
      {
        Username = "niemandr",
        Int1 = 67,
        Date2 = DateTime.Now,
        LongValue = 22222,
        NullableLong = null,
        Date = DateTime.UtcNow,
        DoubleValue = 89.2,
        NullableDouble = 2.2,
        Bool = true
      });
  }
}

public class TestParams1
{
  public string? Username { get; set; } = null;
  public DateTime? Date { get; set; }
  public int Int1 { get; set; }
  public DateTime? Date2 { get; set; }
  public long LongValue { get; set; }
  public long? NullableLong { get; set; }
  public double DoubleValue { get; set; }
  public double? NullableDouble { get; set; }
  public bool Bool { get; set; }
  public bool? NullableBool { get; set; }
}
