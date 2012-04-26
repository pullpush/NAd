using System;
using System.Collections.Generic;
using System.Linq;

namespace NAd.Common
{
    public static class EnumerableExtensions
    {
        private const int FirstPageNumber = 1;

        public static Type GetEnumeratedType<T>(this IEnumerable<T> list)
        {
            Type[] enumeratedTypes = list.GetType().GetInterfaces()
                .Where(x => IsGenericEnumerable(x))
                .Select(x => x.GetGenericArguments().Single()).ToArray();

            if (enumeratedTypes.Count() > 1)
            {
                throw new ArgumentException("list implements more than one IEnumerable<>");
            }

            return enumeratedTypes.Single();
        }

        private static bool IsGenericEnumerable(Type interfaceType)
        {
            return interfaceType.IsGenericType && (interfaceType.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        }

        public static IQueryable<TSource> TakePage<TSource>(this IQueryable<TSource> source, int pageNumber, int pageSize)
        {
            ValidatePageNumber(pageNumber);

            return source.Skip((pageNumber - FirstPageNumber) * pageSize).Take(pageSize);
        }

        public static IEnumerable<TSource> TakePage<TSource>(this IEnumerable<TSource> source, int pageNumber, int pageSize)
        {
            ValidatePageNumber(pageNumber);

            return source.Skip((pageNumber - FirstPageNumber) * pageSize).Take(pageSize);
        }

        private static void ValidatePageNumber(int pageNumber)
        {
            if (pageNumber < FirstPageNumber)
            {
                throw new ArgumentException("Page numbers should start at " + FirstPageNumber, "pageNumber");
            }
        }
    }
}
