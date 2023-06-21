[Home](/README.md) / [Abstractions](/docs/abstractions/README.md) / DateTimeAbstraction

# DateTimeAbstraction
Wraps and exposes common properties from the [DateTime struct](https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=net-6.0).

```cs
public interface IDateTimeAbstraction
{
  DateTime MinValue { get; }
  DateTime MaxValue { get; }
  DateTime Now { get; }
  DateTime UtcNow { get; }
}
```