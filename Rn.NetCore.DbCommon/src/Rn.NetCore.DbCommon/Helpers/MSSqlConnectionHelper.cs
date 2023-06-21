using System.Data;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon;

// DOCS: docs\helpers\MSSqlConnectionHelper.md
public class MSSqlConnectionHelper : DbConnectionHelperBase<MSSqlConnectionHelper>
{
  public MSSqlConnectionHelper(
    ILoggerAdapter<MSSqlConnectionHelper> logger,
    IConnectionResolver connectionResolver,
    ISqlFormatter sqlFormatter)
  : base(logger, connectionResolver, sqlFormatter)
  { }

  public override IDbConnection GetConnection(string alias)
  {
    var conString = ConnectionResolver.GetConnectionString(alias);
    if (conString == null)
      throw new ConnectionStringMissingException(alias);

    var sqlCon = ConnectionResolver.CreateMSSqlConnection(conString);
    if (sqlCon.State != ConnectionState.Open)
      sqlCon.Open();

    return sqlCon;
  }
}
