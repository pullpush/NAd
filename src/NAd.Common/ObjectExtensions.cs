
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NAd.Common
{
    public static class ObjectExtensions
    {
        /// <summary>
        ///   Wraps an existing object into a collection.
        /// </summary>
        public static IEnumerable<T> ToEnumerable<T>(this T t)
        {
            return new[] {t};
        }

        /// <summary>
        ///   Wraps an existing object into a collection.
        /// </summary>
        public static IQueryable<T> ToQueryable<T>(this T t)
        {
            return t.ToEnumerable().AsQueryable();
        }

        /// <summary>
        /// Returns the value of the specified string property if <paramref name="owner"/> is not <c>null</c>, 
        /// and an empty string otherwise.
        /// </summary>
        public static string EmptyOr<T>(this T owner, Expression<Func<T, string>> propertySelector) where T : class
        {
            return (owner != null) ? propertySelector.Compile()(owner) : string.Empty;
        }

        /// <summary>
        /// Returns the value of the specified property if <paramref name="owner"/> is not <c>null</c>, 
        /// and a default value otherwise.
        /// </summary>
        public static TProperty DefaultOr<TOwner, TProperty>(this TOwner owner, Expression<Func<TOwner, TProperty>> propertySelector) 
            where TOwner : class
        {
            return (owner != null) ? propertySelector.Compile()(owner) : default(TProperty);
        }
    }
}