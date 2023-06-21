using NSubstitute;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers.SqlFormatterTests;

public static class TestHelper
{
  public static SqlFormatter GetSqlFormatter(ILoggerAdapter<SqlFormatter>? logger = null) =>
    new(logger ?? Substitute.For<ILoggerAdapter<SqlFormatter>>());
}
