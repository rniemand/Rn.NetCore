[Home](/README.md) / [Helpers](/docs/helpers/README.md) / JsonHelper

# JsonHelper
More to come...

```cs
public interface IJsonHelper
{
  T DeserializeObject<T>(string value);
  object? DeserializeObject(string value, Type type);
  bool TryDeserializeObject<T>(string json, out T parsed);
  string SerializeObject(object value);
  string SerializeObject(object value, bool formatted);
}
```