using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NAd.Framework.Persistence
{
    public static class Get
    {
        public static T Current<T>() where T : class
        {
            var context = HttpContext.Current;
            var key = typeof(T).FullName;

            var value = context == null ? (T)Set.InMemoryValuesForUnitTesting[key] : (T)context.Items[key];

            Ensure.That(value != null);

            return value;
        }
    }
}
