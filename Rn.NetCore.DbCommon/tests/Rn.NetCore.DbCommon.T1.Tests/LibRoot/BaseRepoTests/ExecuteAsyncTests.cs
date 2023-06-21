using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Rn.NetCore.Common.Logging;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport;
using Rn.NetCore.DbCommon.T1.Tests.TestSupport.Builders;
using Rn.NetCore.Metrics;

namespace Rn.NetCore.DbCommon.T1.Tests.LibRoot.BaseRepoTests;

[TestFixture]
public class ExecuteAsyncTests
{
  private const string ConnectionName = "MyConnection";
  private const string SqlQuery = "UPDATE USERS ...";
  private static readonly UserEntity UpdateEntity = new UserEntityBuilder().WithUserId(12).Build();

  [Test]
  public async Task GetList_GivenCalled_ShouldLogSqlCommand()
  {
    // arrange
    var sqlFormatter = Substitute.For<ISqlFormatter>();
    var logger = Substitute.For<ILoggerAdapter<TestRepo>>();

    var dbConfig = new RnDbConfigBuilder()
      .WithLogSqlCommands(true)
      .Build();

    sqlFormatter
      .Format(Arg.Any<string>(), Arg.Any<object>())
      .Returns("EXECUTED_SQL");

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      sqlFormatter: sqlFormatter,
      dbConfig: dbConfig,
      logger: logger);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    await testRepo.UpdateUser(UpdateEntity);

    // assert
    sqlFormatter.Received(1).Format(SqlQuery, Arg.Any<object>());
    logger.Received(1).LogDebug("Running SQL command for {repo}.{method}() :: {sql}",
      nameof(TestRepo),
      nameof(TestRepo.UpdateUser),
      "EXECUTED_SQL");
  }

  [Test]
  public async Task GetList_GivenCalled_ShouldSubmitMetric()
  {
    // arrange
    var metricsService = Substitute.For<IMetricService>();
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    CoreMetric builtMetric = null;

    var dbConfig = new RnDbConfigBuilder().WithEnableMetrics(true).Build();

    metricsService
      .When(x => x.SubmitAsync(Arg.Any<RepoMetricBuilder>()))
      .Do(info =>
      {
        if (info.Args().First() is RepoMetricBuilder first)
          builtMetric = first.Build();
      });

    connectionHelper
      .ExecuteAsync(Arg.Any<IDbConnection>(), Arg.Any<string>(), Arg.Any<object>())
      .Returns(1);

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      dbConfig: dbConfig,
      metricService: metricsService,
      connectionHelper: connectionHelper,
      connectionName: ConnectionName);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    await testRepo.UpdateUser(UpdateEntity);

    // assert
    Assert.That(builtMetric, Is.Not.Null);
    Assert.That(builtMetric.Measurement, Is.EqualTo("repo_call"));
    Assert.That(builtMetric.Tags["repo_name"], Is.EqualTo("TestRepo"));
    Assert.That(builtMetric.Tags["repo_method"], Is.EqualTo("UpdateUser"));
    Assert.That(builtMetric.Tags["command_type"], Is.EqualTo("ExecuteAsync"));
    Assert.That(builtMetric.Tags["connection"], Is.EqualTo(ConnectionName));
    Assert.That(builtMetric.Tags["has_params"], Is.EqualTo("true"));
    Assert.That(builtMetric.Tags["success"], Is.EqualTo("true"));
    Assert.That(builtMetric.Tags["has_ex"], Is.EqualTo("false"));
    Assert.That(builtMetric.Tags["ex_name"], Is.EqualTo(""));
    Assert.That(builtMetric.Tags["model"], Is.EqualTo("UserEntity"));
    Assert.That(builtMetric.Fields["query_count"], Is.EqualTo(1));
    Assert.That(builtMetric.Fields["results_count"], Is.EqualTo(1));
    Assert.That(builtMetric.Fields["value"], Is.GreaterThanOrEqualTo(0));
  }

  [Test]
  public async Task GetList_GivenExceptionThrown_ShouldSubmitMetric()
  {
    // arrange
    var metricsService = Substitute.For<IMetricService>();
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    var dbConfig = new RnDbConfigBuilder().WithEnableMetrics(true).Build();
    var ex = new Exception("Something bad");
    CoreMetric builtMetric = null;

    metricsService
      .When(x => x.SubmitAsync(Arg.Any<RepoMetricBuilder>()))
      .Do(info =>
      {
        if (info.Args().First() is RepoMetricBuilder first)
          builtMetric = first.Build();
      });

    connectionHelper
      .ExecuteAsync(Arg.Any<IDbConnection>(), Arg.Any<string>(), Arg.Any<object>())
      .Throws(ex);

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      dbConfig: dbConfig,
      metricService: metricsService,
      connectionHelper: connectionHelper,
      connectionName: ConnectionName);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    await testRepo.UpdateUser(UpdateEntity);

    // assert
    Assert.That(builtMetric, Is.Not.Null);
    Assert.That(builtMetric.Measurement, Is.EqualTo("repo_call"));
    Assert.That(builtMetric.Tags["repo_name"], Is.EqualTo("TestRepo"));
    Assert.That(builtMetric.Tags["repo_method"], Is.EqualTo("UpdateUser"));
    Assert.That(builtMetric.Tags["command_type"], Is.EqualTo("ExecuteAsync"));
    Assert.That(builtMetric.Tags["connection"], Is.EqualTo(ConnectionName));
    Assert.That(builtMetric.Tags["has_params"], Is.EqualTo("true"));
    Assert.That(builtMetric.Tags["success"], Is.EqualTo("false"));
    Assert.That(builtMetric.Tags["has_ex"], Is.EqualTo("true"));
    Assert.That(builtMetric.Tags["ex_name"], Is.EqualTo("Exception"));
    Assert.That(builtMetric.Tags["model"], Is.EqualTo("UserEntity"));
    Assert.That(builtMetric.Fields["query_count"], Is.EqualTo(1));
    Assert.That(builtMetric.Fields["results_count"], Is.EqualTo(0));
    Assert.That(builtMetric.Fields["value"], Is.GreaterThanOrEqualTo(0));
  }

  [Test]
  public async Task GetList_GivenExceptionThrown_ShouldLog()
  {
    // arrange
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    var sqlFormatter = Substitute.For<ISqlFormatter>();
    var logger = Substitute.For<ILoggerAdapter<TestRepo>>();
    var ex = new Exception("Something bad");
    var dbConfig = new RnDbConfigBuilder().WithEnableMetrics(true).Build();

    connectionHelper
      .ExecuteAsync(Arg.Any<IDbConnection>(), Arg.Any<string>(), Arg.Any<object>())
      .Throws(ex);

    sqlFormatter
      .Format(SqlQuery, Arg.Any<object>())
      .Returns("EXECUTED_SQL");

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      dbConfig: dbConfig,
      connectionHelper: connectionHelper,
      logger: logger,
      sqlFormatter: sqlFormatter,
      connectionName: ConnectionName);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    await testRepo.UpdateUser(UpdateEntity);

    // assert
    logger.Received(1).LogError(ex, "Error running SQL query: {sql}", "EXECUTED_SQL");
  }

  [Test]
  public async Task GetList_GivenExceptionThrown_ShouldReturnNull()
  {
    // arrange
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    var ex = new Exception("Something bad");
    var dbConfig = new RnDbConfigBuilder().WithEnableMetrics(true).Build();

    connectionHelper
      .ExecuteAsync(Arg.Any<IDbConnection>(), Arg.Any<string>(), Arg.Any<object>())
      .Throws(ex);

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      dbConfig: dbConfig,
      connectionHelper: connectionHelper,
      connectionName: ConnectionName);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    var resultCount = await testRepo.UpdateUser(UpdateEntity);

    // assert
    Assert.That(resultCount, Is.EqualTo(0));
  }

  [Test]
  public async Task GetList_GivenCalled_ShouldCallExecuteAsync()
  {
    // arrange
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    var dbConnection = Substitute.For<IDbConnection>();
    var logger = Substitute.For<ILoggerAdapter<TestRepo>>();

    var dbConfig = new RnDbConfigBuilder()
      .WithLogSqlCommands(true)
      .Build();

    connectionHelper
      .GetConnection(ConnectionName)
      .Returns(dbConnection);

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      dbConfig: dbConfig,
      logger: logger,
      connectionHelper: connectionHelper,
      connectionName: ConnectionName);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    await testRepo.UpdateUser(UpdateEntity);

    // assert
    await connectionHelper.Received(1).ExecuteAsync(dbConnection, SqlQuery, Arg.Any<object>());
  }

  [Test]
  public async Task GetList_GivenResultsReturned_ShouldReturnResult()
  {
    // arrange
    var connectionHelper = Substitute.For<IDbConnectionHelper>();
    var logger = Substitute.For<ILoggerAdapter<TestRepo>>();
    var userEntity = UserEntityBuilder.Default;

    var dbConfig = new RnDbConfigBuilder()
      .WithLogSqlCommands(true)
      .Build();

    connectionHelper
      .ExecuteAsync(Arg.Any<IDbConnection>(), SqlQuery, Arg.Any<object>())
      .Returns(2);

    var baseRepoHelper = TestHelper.GetBaseRepoHelper(
      dbConfig: dbConfig,
      logger: logger,
      connectionHelper: connectionHelper,
      connectionName: ConnectionName);

    var testRepo = new TestRepo(baseRepoHelper);

    // act
    var rowCount = await testRepo.UpdateUser(userEntity);

    // assert
    Assert.That(rowCount, Is.EqualTo(2));
  }
}
