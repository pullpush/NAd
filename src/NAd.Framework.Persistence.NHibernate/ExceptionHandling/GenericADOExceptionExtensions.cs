
using System;
using System.Text.RegularExpressions;

using NHibernate.Exceptions;

namespace NAd.Framework.Persistence.NHibernate.ExceptionHandling
{
    internal static class GenericADOExceptionExtensions
    {
        public static Type GetEntityType(this GenericADOException exception)
        {
            Match matches = Regex.Match(exception.Message, @"\[(.+?)((#\d+)|\].+)");
            string qualifiedTypeName = matches.Groups[1].Value;

            return Type.GetType(qualifiedTypeName);
        }
    }
}
