namespace BetterThanAliexpress;

using System.Text.Json;

public static class SessionExtensions
{
    public static void Set<T>(this ISession session, string key, T value)
    {
        session.SetString(key: key, value: JsonSerializer.Serialize(value));
    }

    public static T? Get<T>(this ISession session, string key)
    {
        var value = session.GetString(key);

        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}
