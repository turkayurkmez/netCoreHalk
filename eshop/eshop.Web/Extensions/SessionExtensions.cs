using Newtonsoft.Json;

namespace eshop.Web.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T instance)
        {
            var serialized = JsonConvert.SerializeObject(instance);
            session.SetString(key, serialized);
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}
