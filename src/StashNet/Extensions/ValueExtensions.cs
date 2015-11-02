using System.Collections.Generic;
using System.Linq;

namespace StashNet.Extensions
{
    public static class ValueExtensions
    {
        public static bool IsNull<T>(this T value)
            where T : class
        {
            return (value == null);
        }

        public static IEnumerable<string> ToList(this Dictionary<string, object> map)
        {
            return map.Select(mapping => $"{mapping.Key}:{mapping.Value}").ToList();
        }
    }
}