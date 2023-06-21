using System.Collections.Generic;
using System.Threading.Tasks;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot;

public class TestRepo : BaseRepo<TestRepo>
{
  public TestRepo(IBaseRepoHelper baseRepoHelper, string? connectionName = null)
    : base(baseRepoHelper, connectionName)
  { }

  public async Task<List<UserEntity>> GetUsers() =>
    await GetList<UserEntity>(nameof(GetUsers), "SELECT * FROM USERS", new object());

  public async Task<UserEntity?> GetUser() =>
    await GetSingle<UserEntity>(nameof(GetUser), "SELECT TOP 1 * FROM USERS", new object());

  public async Task<int> UpdateUser(UserEntity user) =>
    await ExecuteAsync(nameof(UpdateUser), "UPDATE USERS ...", user);
}
