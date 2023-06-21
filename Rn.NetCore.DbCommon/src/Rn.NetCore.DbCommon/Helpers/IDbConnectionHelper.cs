using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Rn.NetCore.DbCommon;

public interface IDbConnectionHelper
{
  IDbConnection GetConnection(string alias);
  Task<int> ExecuteAsync(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
  Task<IEnumerable<T>> QueryAsync<T>(IDbConnection cnn, string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
}
