using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAd.Framework.Persistence
{
    public static class Set
    {
        internal static Dictionary<string, object> InMemoryValuesForUnitTesting = new Dictionary<string, object>();

        public static void Current<T>(T value)
        {
            var context = HttpContext.Current;
            var key = typeof(T).FullName;

            if (context == null)
                InMemoryValuesForUnitTesting[key] = value;
            else
                context.Items[key] = value;
        }
    }
}
