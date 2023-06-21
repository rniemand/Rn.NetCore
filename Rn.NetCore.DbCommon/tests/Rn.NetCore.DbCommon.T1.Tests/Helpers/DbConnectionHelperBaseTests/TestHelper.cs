using NSubstitute;
using Rn.NetCore.Common.Logging;

namespace Rn.NetCore.DbCommon.T1.Tests.Helpers.DbConnectionHelperBaseTests;

public class TestDbConnectionHelper : DbConnectionHelperBase<TestDbConnectionHelper>
{
  public TestDbConnectionHelper(ILoggerAdapter<TestDbConnectionHelper> logger, IConnectionResolver connectionResolver, ISqlFormatter sqlFormatter)
    : base(logger, connectionResolver, sqlFormatter)
  { }
}

public static class TestHelper
{
  public static TestDbConnectionHelper GetTestDbConnectionHelper(
    ILoggerAdapter<TestDbConnectionHelper>? logger = null,
    IConnectionResolver? connectionResolver = null,
    ISqlFormatter? sqlFormatter = null)
  {
    return new TestDbConnectionHelper(logger ?? Substitute.For<ILoggerAdapter<TestDbConnectionHelper>>(),
      connectionResolver ?? Substitute.For<IConnectionResolver>(),
      sqlFormatter ?? Substitute.For<ISqlFormatter>());
  }
}
