using System.Collections.Generic;

namespace extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<TKey, TValue> ToSafeKeyDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (var e in source)
            {
                result[e.Key] = e.Value;
            }

            return result;
        }
    }
}
