using System.Collections.Generic;
using System.Linq;

namespace NAd.Common
{
    public static class StringExtensions
    {
        /// <summary>
        ///   Indicates if the current <see cref = "string" /> is NOT <c>null</c> or <see cref = "string.Empty" />.
        /// </summary>
        public static bool IsNotNullOrEmpty(this string source)
        {
            return !string.IsNullOrEmpty(source);
        }

        /// <summary>
        ///   Indicates if the current <see cref = "string" /> is <c>null</c> or <see cref = "string.Empty" />.
        /// </summary>
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        /// <summary>
        ///   Indicates if all characters in the supplied <paramref name = "value" /> are UPPER case.
        /// </summary>
        public static bool IsUpper(this IEnumerable<char> value)
        {
            return !value.Any(c => char.IsLower(c));
        }

        /// <summary>
        ///   Indicates if all characters in the supplied <paramref name = "value" /> are lower case.
        /// </summary>
        public static bool IsLower(this IEnumerable<char> value)
        {
            return !value.Any(c => char.IsUpper(c));
        }

        /// <summary>
        /// Joins an arbitrary collection of strings using the specified separator.
        /// </summary>
        public static string Join(this IEnumerable<string> values, string separator)
        {
            return string.Join(separator, values.ToArray());
        }
    }
}