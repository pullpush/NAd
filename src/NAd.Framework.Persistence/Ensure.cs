using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NAd.Framework.Persistence
{
    public static class Ensure
    {
        public static void That(bool condition)
        {
            if (!condition)
                throw new Exception("an expected condition was not met.");
        }

        public static void That<TType>(bool condition, string message) where TType : Exception
        {
            if (!condition)
                throw (TType)Activator.CreateInstance(typeof(TType), message);
        }
    }
}
