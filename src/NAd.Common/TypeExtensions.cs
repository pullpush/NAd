﻿using System;
using System.Linq;
using System.Reflection;

namespace NAd.Common
{
    public static class TypeExtensions
    {
        public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return (type.GetCustomAttributes(typeof(TAttribute), true).Length > 0);
        }

        public static TAttribute FindAttribute<TAttribute>(this Type type) where TAttribute : Attribute
        {
            return (TAttribute)type.GetCustomAttributes(typeof(TAttribute), true).SingleOrDefault();
        }

        public static bool HasAttribute<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
        {
            return (memberInfo.GetCustomAttributes(typeof(TAttribute), true).Length > 0);
        }

        public static bool Implements<TInterface>(this Type type)
        {
            return typeof(TInterface).IsAssignableFrom(type) && (type != typeof(TInterface));
        }

        /// <summary>
        /// Alternative version of <see cref="Type.IsSubclassOf"/> that supports raw generic types (generic types without
        /// any type parameters).
        /// </summary>
        /// <param name="baseType">The base type class for which the check is made.</param>
        /// <param name="toCheck">To type to determine for whether it derives from <paramref name="baseType"/>.</param>
        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type baseType)
        {
            if (toCheck != null && toCheck != typeof(object))
            {
                Type cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (baseType == cur || baseType.IsAssignableFrom(cur))
                {
                    return true;
                }

                if (toCheck.BaseType.IsSubclassOfRawGeneric(baseType))
                {
                    return true;
                }

                foreach (var @interface in toCheck.GetInterfaces())
                {
                    if (@interface.IsSubclassOfRawGeneric(baseType))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
