[Home](/README.md) / [Extensions](/docs/extensions/README.md) / DateExtensions

# DateExtensions
Utility methods for working with the `DateTime` object.

## Methods
The following methods are available.

| Method | Returns | Since | Notes |
| --- | --- | --- | --- |
| `AsWebUtcString()` | `string` | - | Formats the provided `DateTime` as a `WebUtcString`. |
| `AsUtcShortDate()` | `string` | - | Formats the provided `DateTime` as a `UTC` short string. |
| `ToStartOfDay()` | `DateTime` | - | Returns a new `DateTime` for the start of the provided `DateTime`s day. |
| `ToStartOfMonth()` | `DateTime` | - | Returns the first day of the provided `DateTime`s month. |
| `GetNextWeekDay()` | `DateTime` | - | Returns the next week day for the given `DateTime`, i.e. `Sunday` -> `Monday`. |
