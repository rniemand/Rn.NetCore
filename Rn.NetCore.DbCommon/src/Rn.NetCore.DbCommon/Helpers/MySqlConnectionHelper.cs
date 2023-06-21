using System.Data;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon;

// DOCS: docs\helpers\MySqlConnectionHelper.md
public class MySqlConnectionHelper : DbConnectionHelperBase<MySqlConnectionHelper>
{
  public MySqlConnectionHelper(
    ILoggerAdapter<MySqlConnectionHelper> logger,
    IConnectionResolver connectionResolver,
    ISqlFormatter sqlFormatter)
  : base(logger, connectionResolver, sqlFormatter)
  { }

  public override IDbConnection GetConnection(string alias)
  {
    var conString = ConnectionResolver.GetConnectionString(alias);
    if (conString == null)
      throw new ConnectionStringMissingException(alias);

    var sqlCon = ConnectionResolver.MyCreateSqlConnection(conString);
    if (sqlCon.State != ConnectionState.Open)
      sqlCon.Open();

    return sqlCon;
  }
}
