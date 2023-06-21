using System;

namespace Rn.NetCore.Common.Abstractions;

// DOCS: docs\abstractions\DateTimeAbstraction.md
public interface IDateTimeAbstraction
{
  DateTime MinValue { get; }
  DateTime MaxValue { get; }
  DateTime Now { get; }
  DateTime UtcNow { get; }
}

public class DateTimeAbstraction : IDateTimeAbstraction
{
  public DateTime MinValue => DateTime.MinValue;
  public DateTime MaxValue => DateTime.MaxValue;
  public DateTime Now => DateTime.Now;
  public DateTime UtcNow => DateTime.UtcNow;
}
